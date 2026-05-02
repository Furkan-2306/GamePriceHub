namespace GamePriceHub.Modeller
{
    public class Haber
    {
        public int ID { get; set; }
        public string Kategori { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string Icerik { get; set; }
        public string ResimURL { get; set; }
        public string Tarih { get; set; }
            
        public string PdfDosyaAdi { get; set; }
    }
}