using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GamePriceHub.Modeller;

namespace GamePriceHub.Kontrolculer
{
    public class IstekListesiKontrolcusu
    {
        private VeritabaniBaglantisi _veritabani = new VeritabaniBaglantisi();

        public bool Ekle(string kullaniciAdi, Oyun oyun)
        {
            if (VarMi(kullaniciAdi, oyun.OyunID)) return true; 

            string sorgu = "INSERT INTO IstekListesi (KullaniciAdi, OyunID, Ad, EnUcuzFiyat, ResimURL, MagazaAdi) VALUES (@kullanici, @id, @ad, @fiyat, @resim, @magaza)";
            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kullanici", kullaniciAdi);
                        komut.Parameters.AddWithValue("@id", oyun.OyunID);
                        komut.Parameters.AddWithValue("@ad", oyun.Ad);
                        komut.Parameters.AddWithValue("@fiyat", oyun.EnUcuzFiyat);
                        komut.Parameters.AddWithValue("@resim", !string.IsNullOrEmpty(oyun.YuksekCozunurlukluResimURL) ? oyun.YuksekCozunurlukluResimURL : oyun.ResimURL);
                        komut.Parameters.AddWithValue("@magaza", oyun.MagazaAdi);

                        baglanti.Open();
                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }

        public bool Cikar(string kullaniciAdi, string oyunID)
        {
            string sorgu = "DELETE FROM IstekListesi WHERE KullaniciAdi = @kullanici AND OyunID = @id";
            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kullanici", kullaniciAdi);
                        komut.Parameters.AddWithValue("@id", oyunID);
                        baglanti.Open();
                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }

        public List<Oyun> Listele(string kullaniciAdi)
        {
            List<Oyun> liste = new List<Oyun>();
            string sorgu = "SELECT OyunID, Ad, EnUcuzFiyat, ResimURL, MagazaAdi FROM IstekListesi WHERE KullaniciAdi = @kullanici";
            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kullanici", kullaniciAdi);
                        baglanti.Open();
                        using (MySqlDataReader okuyucu = komut.ExecuteReader())
                        {
                            while (okuyucu.Read())
                            {
                                Oyun o = new Oyun
                                {
                                    OyunID = okuyucu["OyunID"].ToString(),
                                    Ad = okuyucu["Ad"].ToString(),
                                    EnUcuzFiyat = Convert.ToDouble(okuyucu["EnUcuzFiyat"]),
                                    ResimURL = okuyucu["ResimURL"].ToString(),
                                    YuksekCozunurlukluResimURL = okuyucu["ResimURL"].ToString(),
                                    MagazaAdi = okuyucu["MagazaAdi"].ToString(),
                                    MetacriticPuaniVarMi = false,
                                    PuanMetni = "İstek Listesinde",
                                    MagazaFiyatlari = new Dictionary<string, double> { { okuyucu["MagazaAdi"].ToString(), Convert.ToDouble(okuyucu["EnUcuzFiyat"]) } }
                                };
                                liste.Add(o);
                            }
                        }
                    }
                }
            }
            catch { }
            return liste;
        }

        public bool VarMi(string kullaniciAdi, string oyunID)
        {
            string sorgu = "SELECT COUNT(*) FROM IstekListesi WHERE KullaniciAdi = @kullanici AND OyunID = @id";
            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kullanici", kullaniciAdi);
                        komut.Parameters.AddWithValue("@id", oyunID);
                        baglanti.Open();
                        return Convert.ToInt32(komut.ExecuteScalar()) > 0;
                    }
                }
            }
            catch { return false; }
        }
    }
}