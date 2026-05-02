using System;

namespace GamePriceHub.Modeller
{
    public class Yorum
    {
        public int YorumID { get; set; }
        public int KullaniciID { get; set; }

        public string KullaniciAdi { get; set; }

        public string OyunAdi { get; set; }
        public string YorumMetni { get; set; }

        public int PuanDurumu { get; set; }

        public DateTime Tarih { get; set; }
    }
}