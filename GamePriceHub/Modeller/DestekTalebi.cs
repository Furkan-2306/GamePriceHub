using System;

namespace GamePriceHub.Modeller
{
    public class DestekTalebi
    {
        public int TalepID { get; set; }
        public int KullaniciID { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }
        public DateTime Tarih { get; set; }
    }
}