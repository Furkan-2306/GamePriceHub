public class Oyun
{
    public string OyunID { get; set; }
    public string SteamAppID { get; set; }
    public string Ad { get; set; }
    public double EnUcuzFiyat { get; set; }
    public string MagazaAdi { get; set; }
    public Dictionary<string, double> MagazaFiyatlari { get; set; } = new Dictionary<string, double>();
    public string ResimURL { get; set; }
    public string YuksekCozunurlukluResimURL { get; set; }
    public string Aciklama { get; set; }
    public double PuanYildiz { get; set; }
    public bool MetacriticPuaniVarMi { get; set; }
    public string PuanMetni { get; set; }
    public int ToplamInceleme { get; set; }
    public List<string> Turler { get; set; } = new List<string>();
    public string Gelistirici { get; set; } = "Bilinmiyor";
    public string CikisTarihi { get; set; } = "Bilinmiyor";

}