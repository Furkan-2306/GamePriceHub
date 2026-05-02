using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GamePriceHub.Modeller;

namespace GamePriceHub.Kontrolculer
{
    public class YorumKontrolcusu
    {
        private VeritabaniBaglantisi _veritabani;

        public YorumKontrolcusu()
        {
            _veritabani = new VeritabaniBaglantisi();
        }

        public List<Yorum> OyunYorumlariniGetir(string oyunAdi)
        {
            List<Yorum> liste = new List<Yorum>();

            string sorgu = @"
                SELECT y.YorumID, y.KullaniciID, k.KullaniciAdi, y.OyunAdi, y.YorumMetni, y.PuanDurumu, y.Tarih 
                FROM Yorumlar y
                INNER JOIN Kullanicilar k ON y.KullaniciID = k.ID
                WHERE y.OyunAdi = @oyunAdi
                ORDER BY y.Tarih DESC"; 

            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@oyunAdi", oyunAdi);
                        baglanti.Open();

                        using (MySqlDataReader okuyucu = komut.ExecuteReader())
                        {
                            while (okuyucu.Read())
                            {
                                liste.Add(new Yorum
                                {
                                    YorumID = Convert.ToInt32(okuyucu["YorumID"]),
                                    KullaniciID = Convert.ToInt32(okuyucu["KullaniciID"]),
                                    KullaniciAdi = okuyucu["KullaniciAdi"].ToString(),
                                    OyunAdi = okuyucu["OyunAdi"].ToString(),
                                    YorumMetni = okuyucu["YorumMetni"].ToString(),
                                    PuanDurumu = Convert.ToInt32(okuyucu["PuanDurumu"]),
                                    Tarih = Convert.ToDateTime(okuyucu["Tarih"])
                                });
                            }
                        }
                    }
                }
            }
            catch { }
            return liste;
        }

   
        public bool YorumEkle(int kullaniciId, string oyunAdi, string yorumMetni, int puanDurumu)
        {
            string sorgu = "INSERT INTO Yorumlar (KullaniciID, OyunAdi, YorumMetni, PuanDurumu) VALUES (@kullaniciId, @oyunAdi, @yorumMetni, @puanDurumu)";
            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                        komut.Parameters.AddWithValue("@oyunAdi", oyunAdi);
                        komut.Parameters.AddWithValue("@yorumMetni", yorumMetni);
                        komut.Parameters.AddWithValue("@puanDurumu", puanDurumu);

                        baglanti.Open();
                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }

        // EKLENECEK YENİ METOT: Oyunun kullanıcı puan ortalamasını hesaplar
        public double OyununKullaniciPuaniniHesapla(string oyunAdi, out int toplamYorum)
        {
            toplamYorum = 0;
            double toplamPuan = 0;

            List<Yorum> yorumlar = OyunYorumlariniGetir(oyunAdi);
            if (yorumlar.Count == 0) return 0;

            toplamYorum = yorumlar.Count;

            foreach (var y in yorumlar)
            {
                // 1: Tavsiye (5 Yıldız), 0: Nötr (2.5 Yıldız), 2: Tavsiye Etmiyor (0 Yıldız)
                if (y.PuanDurumu == 1) toplamPuan += 5.0;
                else if (y.PuanDurumu == 0) toplamPuan += 2.5;
                else if (y.PuanDurumu == 2) toplamPuan += 0.0;
            }

            // Ortalamayı bulup tek ondalık basamağa yuvarlıyoruz (Örn: 4.2)
            return Math.Round(toplamPuan / toplamYorum, 1);
        }
    }
}