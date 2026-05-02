using System;
using MySql.Data.MySqlClient;
using GamePriceHub.Modeller;

namespace GamePriceHub.Kontrolculer
{
    public class KullaniciKontrolcusu
    {
        private VeritabaniBaglantisi _veritabani;


        public KullaniciKontrolcusu()
        {
            _veritabani = new VeritabaniBaglantisi();
        }


        public string GirisYap(string eposta, string sifre)
        {
            string sorgu = "SELECT KullaniciAdi FROM Kullanicilar WHERE Eposta = @eposta AND Sifre = @sifre";

            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@eposta", eposta);
                        komut.Parameters.AddWithValue("@sifre", sifre);

                        baglanti.Open();

                        object sonuc = komut.ExecuteScalar();

                        if (sonuc != null)
                        {
                            return sonuc.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Veritabanı Hatası: " + ex.Message, "MySQL Hatası");
            }

            return null;
        }


        public bool KullaniciMusaitMi(string eposta, string kullaniciAdi)
        {
            return !KullaniciVarMi(eposta, kullaniciAdi);
        }

        public bool KullaniciyiKaydet(string adSoyad, string kullaniciAdi, string eposta, string sifre)
        {
            string sorgu = "INSERT INTO Kullanicilar (AdSoyad, KullaniciAdi, Eposta, Sifre, RolID) VALUES (@adSoyad, @kullaniciAdi, @eposta, @sifre, 2)";

            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@adSoyad", adSoyad);
                        komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                        komut.Parameters.AddWithValue("@eposta", eposta);
                        komut.Parameters.AddWithValue("@sifre", sifre);

                        baglanti.Open();
                        int etkilenenSatir = komut.ExecuteNonQuery();
                        return etkilenenSatir > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private bool KullaniciVarMi(string eposta, string kullaniciAdi)
        {
            string sorgu = "SELECT COUNT(*) FROM Kullanicilar WHERE Eposta = @eposta OR KullaniciAdi = @kullaniciAdi";
            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@eposta", eposta);
                        komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                        baglanti.Open();
                        int kayitSayisi = Convert.ToInt32(komut.ExecuteScalar());
                        return kayitSayisi > 0;
                    }
                }
            }
            catch
            {
                return true;
            }
        }

        public Kullanici KullaniciBilgileriniGetir(string kullaniciAdi)
        {
            Kullanici k = null;
            string sorgu = "SELECT ID, AdSoyad, KullaniciAdi, Eposta, Sifre, RolID, KayitTarihi FROM Kullanicilar WHERE KullaniciAdi = @kullaniciAdi";

            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                        baglanti.Open();
                        using (MySqlDataReader okuyucu = komut.ExecuteReader())
                        {
                            if (okuyucu.Read())
                            {
                                k = new Kullanici
                                {
                                    ID = Convert.ToInt32(okuyucu["ID"]),
                                    AdSoyad = okuyucu["AdSoyad"].ToString(),
                                    KullaniciAdi = okuyucu["KullaniciAdi"].ToString(),
                                    Eposta = okuyucu["Eposta"].ToString(),
                                    Sifre = okuyucu["Sifre"].ToString(),
                                    RolID = Convert.ToInt32(okuyucu["RolID"]),
                                    KayitTarihi = okuyucu["KayitTarihi"] != DBNull.Value ? Convert.ToDateTime(okuyucu["KayitTarihi"]) : DateTime.Now
                                };
                            }
                        }
                    }
                }
            }
            catch { }
            return k;
        }

        public bool KullaniciGuncelle(int id, string adSoyad, string kullaniciAdi, string eposta, string sifre)
        {
            string sorgu = "UPDATE Kullanicilar SET AdSoyad = @adSoyad, KullaniciAdi = @kullaniciAdi, Eposta = @eposta, Sifre = @sifre WHERE ID = @id";
            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@id", id);
                        komut.Parameters.AddWithValue("@adSoyad", adSoyad);
                        komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                        komut.Parameters.AddWithValue("@eposta", eposta);
                        komut.Parameters.AddWithValue("@sifre", sifre);

                        baglanti.Open();
                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }


        public List<Kullanici> TumKullanicilariGetir()
        {
            List<Kullanici> liste = new List<Kullanici>();
            string sorgu = "SELECT ID, AdSoyad, KullaniciAdi, Eposta, Sifre, RolID, KayitTarihi, IsBanned FROM Kullanicilar";

            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        baglanti.Open();
                        using (MySqlDataReader okuyucu = komut.ExecuteReader())
                        {
                            while (okuyucu.Read())
                            {
                                liste.Add(new Kullanici
                                {
                                    ID = Convert.ToInt32(okuyucu["ID"]),
                                    AdSoyad = okuyucu["AdSoyad"].ToString(),
                                    KullaniciAdi = okuyucu["KullaniciAdi"].ToString(),
                                    Eposta = okuyucu["Eposta"].ToString(),
                                    Sifre = okuyucu["Sifre"].ToString(),
                                    RolID = Convert.ToInt32(okuyucu["RolID"]),
                                    KayitTarihi = okuyucu["KayitTarihi"] != DBNull.Value ? Convert.ToDateTime(okuyucu["KayitTarihi"]) : DateTime.Now,

                                    IsBanned = okuyucu["IsBanned"] != DBNull.Value && Convert.ToBoolean(okuyucu["IsBanned"])
                                });
                            }
                        }
                    }
                }
            }
            catch { }
            return liste;
        }

        public bool KullaniciyiBanla(int kullaniciId)
        {
            string sorgu = "UPDATE Kullanicilar SET IsBanned = 1 WHERE ID = @id AND RolID != 1";
            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@id", kullaniciId);
                        baglanti.Open();
                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }

        public bool KullaniciEngelKaldir(int kullaniciId)
        {
            string sorgu = "UPDATE Kullanicilar SET IsBanned = 0 WHERE ID = @id";
            try
            {
                using (MySqlConnection baglanti = _veritabani.BaglantiGetir())
                {
                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@id", kullaniciId);
                        baglanti.Open();
                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }
    }
}