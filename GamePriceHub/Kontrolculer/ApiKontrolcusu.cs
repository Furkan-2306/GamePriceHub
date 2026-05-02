using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using GamePriceHub.Modeller;
using System.Linq;

namespace GamePriceHub.Kontrolculer
{
    public class SteamDetay
    {
        public List<string> Turler { get; set; } = new List<string>();
        public string Aciklama { get; set; } = "";
        public string KapakResmi { get; set; } = "";
        public int MetacriticPuan { get; set; } = 0;
        public string Gelistirici { get; set; } = "Bilinmiyor";
        public string CikisTarihi { get; set; } = "Bilinmiyor";
    }

    public class ApiKontrolcusu
    {
        private readonly HttpClient _istemci;
        private static Dictionary<string, SteamDetay> _steamOnbellek = new Dictionary<string, SteamDetay>();
        private static readonly SemaphoreSlim _steamTrafikPolisi = new SemaphoreSlim(4);

        public ApiKontrolcusu()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _istemci = new HttpClient();
            _istemci.DefaultRequestHeaders.Add("User-Agent", "GamePriceHub-PC-Deals");
            _istemci.Timeout = TimeSpan.FromSeconds(60);
        }

        public async Task<List<Oyun>> PopulerOyunlariGetirAsync(int sayfaNo = 0)
        {
            try
            {
                string url = $"https://www.cheapshark.com/api/1.0/deals?storeID=1,7,11,25&pageNumber={sayfaNo}&pageSize=30&sortBy=Metacritic";
                string json = await _istemci.GetStringAsync(url).ConfigureAwait(false);
                JArray dizi = JArray.Parse(json);

                var gruplanmisListe = await DiziIsleVeGruplaAsync(dizi).ConfigureAwait(false);
                return gruplanmisListe.Take(10).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"API Bağlantı Hatası: {ex.Message}");
            }
        }

        public async Task<List<Oyun>> OyunAraAsync(string kelime, int sayfaNo = 0)
        {
            List<Oyun> aramaSonuclari = new List<Oyun>();
            try
            {
                string temizKelime = Uri.EscapeDataString(kelime);
                string aramaUrl = $"https://www.cheapshark.com/api/1.0/games?title={temizKelime}&limit=60";

                string jsonArama = await _istemci.GetStringAsync(aramaUrl).ConfigureAwait(false);
                JArray bulunanOyunlar = JArray.Parse(jsonArama);

                var sayfadakiOyunlar = bulunanOyunlar.Skip(sayfaNo * 10).Take(10);
                List<Task<Oyun>> detayGorevleri = new List<Task<Oyun>>();

                foreach (JToken token in sayfadakiOyunlar)
                {
                    string gameId = token["gameID"]?.ToString();
                    if (!string.IsNullOrEmpty(gameId))
                    {
                        detayGorevleri.Add(OyunTumDetaylariGetirAsync(gameId));
                    }
                }

                Oyun[] sonuclar = await Task.WhenAll(detayGorevleri).ConfigureAwait(false);
                foreach (var oyun in sonuclar)
                {
                    if (oyun != null && oyun.MagazaFiyatlari.Count > 0)
                    {
                        aramaSonuclari.Add(oyun);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Arama sırasında hata oluştu: {ex.Message}");
            }
            return aramaSonuclari;
        }

        private async Task<Oyun> OyunTumDetaylariGetirAsync(string gameId)
        {
            try
            {
                string url = $"https://www.cheapshark.com/api/1.0/games?id={gameId}";
                string json = await _istemci.GetStringAsync(url).ConfigureAwait(false);
                JObject obj = JObject.Parse(json);

                JToken info = obj["info"];
                string steamAppId = info["steamAppID"]?.ToString();
                string kapakResmi = (!string.IsNullOrEmpty(steamAppId) && steamAppId != "0")
                    ? $"https://cdn.akamai.steamstatic.com/steam/apps/{steamAppId}/header.jpg"
                    : info["thumb"]?.ToString();

                Oyun oyun = new Oyun
                {
                    OyunID = gameId,
                    SteamAppID = steamAppId,
                    Ad = info["title"]?.ToString() ?? "Bilinmeyen Oyun",
                    ResimURL = info["thumb"]?.ToString(),
                    YuksekCozunurlukluResimURL = kapakResmi,
                    MagazaFiyatlari = new Dictionary<string, double>()
                };

                JArray deals = (JArray)obj["deals"];
                foreach (JToken deal in deals)
                {
                    string storeID = deal["storeID"]?.ToString();
                    string magaza = MagazaAdiniBul(storeID);

                    if (magaza != "Diğer")
                    {
                        double.TryParse(deal["price"]?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double fiyat);
                        if (!oyun.MagazaFiyatlari.ContainsKey(magaza) || fiyat < oyun.MagazaFiyatlari[magaza])
                        {
                            oyun.MagazaFiyatlari[magaza] = fiyat;
                        }
                    }
                }

                if (oyun.MagazaFiyatlari.Count > 0)
                {
                    var enUcuz = oyun.MagazaFiyatlari.OrderBy(kvp => kvp.Value).First();
                    oyun.EnUcuzFiyat = enUcuz.Value;
                    oyun.MagazaAdi = enUcuz.Key;
                }

                SteamDetay steamVerisi = await SteamDetaylariniGetirAsync(steamAppId).ConfigureAwait(false);
                oyun.Aciklama = steamVerisi.Aciklama;
                oyun.Turler = steamVerisi.Turler;
                oyun.Gelistirici = steamVerisi.Gelistirici;
                oyun.CikisTarihi = steamVerisi.CikisTarihi;

                oyun.MetacriticPuaniVarMi = steamVerisi.MetacriticPuan > 0;
                oyun.PuanYildiz = oyun.MetacriticPuaniVarMi ? Math.Round(steamVerisi.MetacriticPuan / 20.0, 1) : 0;
                oyun.PuanMetni = oyun.MetacriticPuaniVarMi ? "" : "Henüz bu oyun için puanlama yapılmamıştır.";

                return oyun;
            }
            catch
            {
                return null;
            }
        }

        private async Task<List<Oyun>> DiziIsleVeGruplaAsync(JArray dizi)
        {
            Dictionary<string, Oyun> gruplanmisOyunlar = new Dictionary<string, Oyun>();

            foreach (JToken token in dizi)
            {
                try
                {
                    string gameId = token["gameID"]?.ToString();
                    if (string.IsNullOrEmpty(gameId)) continue;

                    string storeID = token["storeID"]?.ToString();
                    string magaza = MagazaAdiniBul(storeID);
                    double.TryParse(token["salePrice"]?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double fiyat);

                    if (gruplanmisOyunlar.ContainsKey(gameId))
                    {
                        var mevcutOyun = gruplanmisOyunlar[gameId];
                        mevcutOyun.MagazaFiyatlari[magaza] = fiyat;
                        if (fiyat < mevcutOyun.EnUcuzFiyat)
                        {
                            mevcutOyun.EnUcuzFiyat = fiyat;
                            mevcutOyun.MagazaAdi = magaza;
                        }
                    }
                    else
                    {
                        Oyun yeniOyun = OyunOlusturTemel(token, magaza, fiyat);
                        gruplanmisOyunlar[gameId] = yeniOyun;
                    }
                }
                catch { }
            }

            var paraleGorevler = gruplanmisOyunlar.Values.Select(async oyun =>
            {
                if (!string.IsNullOrEmpty(oyun.SteamAppID) && oyun.SteamAppID != "0")
                {
                    SteamDetay detay = await SteamDetaylariniGetirAsync(oyun.SteamAppID).ConfigureAwait(false);
                    oyun.Turler = detay.Turler;
                    oyun.Aciklama = detay.Aciklama;
                    oyun.Gelistirici = detay.Gelistirici;
                    oyun.CikisTarihi = detay.CikisTarihi;

                    if (!oyun.MetacriticPuaniVarMi && detay.MetacriticPuan > 0)
                    {
                        oyun.MetacriticPuaniVarMi = true;
                        oyun.PuanYildiz = Math.Round(detay.MetacriticPuan / 20.0, 1);
                        oyun.PuanMetni = "";
                    }
                }
            });

            await Task.WhenAll(paraleGorevler).ConfigureAwait(false);
            return new List<Oyun>(gruplanmisOyunlar.Values);
        }

        private Oyun OyunOlusturTemel(JToken token, string magaza, double fiyat)
        {
            string steamAppId = token["steamAppID"]?.ToString();
            string metacriticStr = token["metacriticScore"]?.ToString();
            int.TryParse(metacriticStr, out int metacriticPuan);

            bool puanVarMi = metacriticPuan > 0;
            double hesaplananYildiz = puanVarMi ? Math.Round(metacriticPuan / 20.0, 1) : 0;

            string kapakResmi = (!string.IsNullOrEmpty(steamAppId) && steamAppId != "0")
                ? $"https://cdn.akamai.steamstatic.com/steam/apps/{steamAppId}/header.jpg"
                : token["thumb"]?.ToString();

            return new Oyun
            {
                OyunID = token["gameID"]?.ToString() ?? Guid.NewGuid().ToString(),
                SteamAppID = steamAppId,
                Ad = token["title"]?.ToString() ?? "İsimsiz Oyun",
                EnUcuzFiyat = fiyat,
                MagazaAdi = magaza,
                PuanYildiz = hesaplananYildiz,
                MetacriticPuaniVarMi = puanVarMi,
                PuanMetni = puanVarMi ? "" : "Henüz bu oyun için puanlama yapılmamıştır.",
                ResimURL = token["thumb"]?.ToString(),
                YuksekCozunurlukluResimURL = kapakResmi,
                MagazaFiyatlari = new Dictionary<string, double> { { magaza, fiyat } }
            };
        }

        private string MagazaAdiniBul(string storeID)
        {
            switch (storeID)
            {
                case "1": return "Steam";
                case "7": return "GOG";
                case "11": return "Humble Store";
                case "25": return "Epic";
                default: return "Diğer";
            }
        }

        private async Task<SteamDetay> SteamDetaylariniGetirAsync(string appId)
        {
            if (string.IsNullOrEmpty(appId) || appId == "0") return new SteamDetay();
            if (_steamOnbellek.ContainsKey(appId)) return _steamOnbellek[appId];

            await _steamTrafikPolisi.WaitAsync().ConfigureAwait(false);
            try
            {
                SteamDetay detay = new SteamDetay();
                string json = await _istemci.GetStringAsync($"https://store.steampowered.com/api/appdetails?appids={appId}").ConfigureAwait(false);
                JObject obj = JObject.Parse(json);

                if (obj[appId]?["success"]?.ToObject<bool>() == true)
                {
                    var data = obj[appId]["data"];

                    var genres = data["genres"];
                    if (genres != null)
                    {
                        foreach (var g in genres) detay.Turler.Add(g["description"].ToString());
                    }

                    detay.Aciklama = data["short_description"]?.ToString() ?? "";

                    var metacritic = data["metacritic"];
                    if (metacritic != null)
                    {
                        int.TryParse(metacritic["score"]?.ToString(), out int mPuan);
                        detay.MetacriticPuan = mPuan;
                    }

                    var developers = data["developers"];
                    if (developers != null && developers.HasValues)
                    {
                        detay.Gelistirici = developers[0].ToString();
                    }

                    var releaseDate = data["release_date"];
                    if (releaseDate != null && releaseDate["date"] != null)
                    {
                        detay.CikisTarihi = releaseDate["date"].ToString();
                    }

                    _steamOnbellek[appId] = detay;
                    return detay;
                }
                return detay;
            }
            catch
            {
                return new SteamDetay();
            }
            finally
            {
                _steamTrafikPolisi.Release();
            }
        }

    }
}
