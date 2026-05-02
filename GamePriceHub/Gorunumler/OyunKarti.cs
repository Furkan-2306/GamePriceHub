using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GamePriceHub.Modeller;
using GamePriceHub.Kontrolculer;

namespace GamePriceHub.Gorunumler
{
    public partial class OyunKarti : UserControl
    {
        private Oyun _oyunVerisi;
        private string _aktifKullaniciAdi;
        private IstekListesiKontrolcusu _istekKontrolcu;
        private bool _istekListesindeMi = false;

        // Butona tıklandığını AnaMenü'ye bildirecek özel olay
        public event EventHandler<Oyun> OyunSecildi;

        public OyunKarti()
        {
            InitializeComponent();
            _istekKontrolcu = new IstekListesiKontrolcusu();

            // ÇÖZÜM 1: Tıklama olaylarını KESİN OLARAK burada bağlıyoruz. (Aksi halde tepki vermez)
            if (btnDetaylar != null)
                btnDetaylar.Click += btnDetaylar_Click;

            if (picKalp != null)
                picKalp.Click += picKalp_Click;
        }

        public void VeriyiDoldur(Oyun oyun, string aktifKullaniciAdi)
        {
            _oyunVerisi = oyun;
            _aktifKullaniciAdi = aktifKullaniciAdi;

            lblOyunAdi.Text = oyun.Ad;

            if (oyun.EnUcuzFiyat <= 0.01)
            {
                lblFiyat.Text = "ÜCRETSİZ";
                lblFiyat.ForeColor = Color.SpringGreen;
            }
            else
            {
                lblFiyat.Text = "$" + oyun.EnUcuzFiyat.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                lblFiyat.ForeColor = Color.White;
            }

            if (oyun.MetacriticPuaniVarMi)
            {
                lblPuan.Text = $"★ {oyun.PuanYildiz} / 5";
                lblPuan.ForeColor = Color.Gold;
                lblPuan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            else
            {
                lblPuan.Text = "Puan Yok";
                lblPuan.ForeColor = Color.Gray;
                lblPuan.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            }

            string resim = !string.IsNullOrEmpty(oyun.YuksekCozunurlukluResimURL) ? oyun.YuksekCozunurlukluResimURL : oyun.ResimURL;
            if (!string.IsNullOrEmpty(resim)) picKapak.LoadAsync(resim);

            _istekListesindeMi = _istekKontrolcu.VarMi(_aktifKullaniciAdi, _oyunVerisi.OyunID);
            KalpIkonunuGuncelle();

            // ÇÖZÜM 2: Logolar GİZLENMEYECEK. Hep görünür kalacak.
            picSteam.Visible = true;
            picEpic.Visible = true;
            picGOG.Visible = true;
            picHumble.Visible = true;

            double enUcuzDeger = -1;
            double enPahaliDeger = -1;

            if (oyun.MagazaFiyatlari != null && oyun.MagazaFiyatlari.Count > 0)
            {
                enUcuzDeger = oyun.MagazaFiyatlari.Values.Min();
                enPahaliDeger = oyun.MagazaFiyatlari.Values.Max();
            }

            void LogoyuAyarla(PictureBox pic, string magazaAdi)
            {
                pic.Visible = true; // Kesin görünür

                if (oyun.MagazaFiyatlari != null && oyun.MagazaFiyatlari.ContainsKey(magazaAdi))
                {
                    double buMagazaninFiyati = oyun.MagazaFiyatlari[magazaAdi];

                    // En ucuzsa yeşil, pahalıysa kırmızı, ortadaysa şeffaf
                    if (buMagazaninFiyati == enUcuzDeger) pic.BackColor = Color.LimeGreen;
                    else if (buMagazaninFiyati == enPahaliDeger && enPahaliDeger != enUcuzDeger) pic.BackColor = Color.Crimson;
                    else pic.BackColor = Color.Transparent;
                }
                else
                {
                    // Bu mağazada satılmıyorsa arka planı şeffaf olsun ama ikon kalsın
                    pic.BackColor = Color.Transparent;
                }
            }

            LogoyuAyarla(picSteam, "Steam");
            LogoyuAyarla(picEpic, "Epic");
            LogoyuAyarla(picGOG, "GOG");
            LogoyuAyarla(picHumble, "Humble Store");
        }

        private void picKalp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_aktifKullaniciAdi) || _aktifKullaniciAdi == "Misafir")
            {
                MessageBox.Show("İstek listesine oyun eklemek için giriş yapmalısınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_istekListesindeMi)
            {
                bool basarili = _istekKontrolcu.Cikar(_aktifKullaniciAdi, _oyunVerisi.OyunID);
                if (basarili) _istekListesindeMi = false;
            }
            else
            {
                bool basarili = _istekKontrolcu.Ekle(_aktifKullaniciAdi, _oyunVerisi);
                if (basarili) _istekListesindeMi = true;
            }

            KalpIkonunuGuncelle();
        }

        private void KalpIkonunuGuncelle()
        {
            try
            {
                if (_istekListesindeMi)
                    picKalp.Image = Properties.Resources.icon_heart_filled;
                else
                    picKalp.Image = Properties.Resources.icon_heart_empty;
            }
            catch
            {
                picKalp.BackColor = _istekListesindeMi ? Color.Red : Color.Transparent;
            }
        }

        private void btnDetaylar_Click(object sender, EventArgs e)
        {
            // Olayı (Event) fırlat, AnaMenu bunu duyup OyunDetayFormu'nu açacak
            OyunSecildi?.Invoke(this, _oyunVerisi);
        }
    }
}