using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GamePriceHub.Modeller;

namespace GamePriceHub.Kontrolculer
{
    public class DestekKontrolcusu
    {
        private VeritabaniBaglantisi _veritabani;

        public DestekKontrolcusu()
        {
            _veritabani = new VeritabaniBaglantisi();
        }

        public bool TalepOlustur(int kullaniciId, string konu, string mesaj)
        {
            string sorgu = "INSERT INTO DestekTalepleri (KullaniciID, Konu, Mesaj) VALUES (@kId, @konu, @mesaj)";
            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kId", kullaniciId);
                        komut.Parameters.AddWithValue("@konu", konu);
                        komut.Parameters.AddWithValue("@mesaj", mesaj);
                        baglanti.Open();
                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }

        public List<DestekTalebi> KullaniciTalepleriniGetir(int kullaniciId)
        {
            List<DestekTalebi> liste = new List<DestekTalebi>();
            string sorgu = "SELECT * FROM DestekTalepleri WHERE KullaniciID = @kId ORDER BY Tarih DESC";
            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kId", kullaniciId);
                        baglanti.Open();
                        using (MySqlDataReader okuyucu = komut.ExecuteReader())
                        {
                            while (okuyucu.Read())
                            {
                                liste.Add(new DestekTalebi
                                {
                                    TalepID = Convert.ToInt32(okuyucu["TalepID"]),
                                    KullaniciID = Convert.ToInt32(okuyucu["KullaniciID"]),
                                    Konu = okuyucu["Konu"].ToString(),
                                    Mesaj = okuyucu["Mesaj"].ToString(),
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
    }
}