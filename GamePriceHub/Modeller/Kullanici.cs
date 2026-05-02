using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace GamePriceHub.Modeller
{
    //Veritabanından kullanıcı verileri çekildiğinde kaydedilen ilk yer.
    public class Kullanici
    {
        public int ID { get; set; }
        public string AdSoyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public int RolID { get; set; }
        public DateTime KayitTarihi { get; set; }
        public bool IsBanned { get; set; }
    }
}