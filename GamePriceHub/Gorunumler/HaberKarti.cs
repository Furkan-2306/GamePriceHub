using System;
using System.Drawing;
using System.IO; // YENİ: Dosya yollarını bulmak için eklendi
using System.Windows.Forms;
using GamePriceHub.Modeller;

namespace GamePriceHub.Gorunumler
{
    public partial class HaberKarti : UserControl
    {
        private Haber _haberVerisi;

        public event EventHandler<Haber> HaberSecildi;

        public HaberKarti()
        {
            InitializeComponent();

            pnlArkaPlan.Click += KartaTiklandi;
            lblBaslik.Click += KartaTiklandi;
            lblOzet.Click += KartaTiklandi;
            lblKategori.Click += KartaTiklandi;
            picKapak.Click += KartaTiklandi;
        }

        public void VeriyiDoldur(Haber haber)
        {
            _haberVerisi = haber;

            lblKategori.Text = haber.Kategori;
            lblKategori.ForeColor = Color.Cyan;

            lblBaslik.Text = haber.Baslik;
            lblOzet.Text = haber.Ozet;
            lblTarih.Text = haber.Tarih;

            if (!string.IsNullOrEmpty(haber.ResimURL))
            {
                try
                {
                    string gorselYolu = Path.Combine(Application.StartupPath, "Gorseller", haber.ResimURL);

                    if (File.Exists(gorselYolu))
                    {
                        picKapak.Image = Image.FromFile(gorselYolu);
                        picKapak.SizeMode = PictureBoxSizeMode.Zoom;
                        picKapak.BackColor = Color.Transparent; // Başarılıysa arka plan şeffaf
                    }
                    else
                    {
                        // HATA: DOSYA BULUNAMADI! Beyaz resmi gizle, kutuyu kırmızı yap.
                        picKapak.Image = null;
                        picKapak.BackColor = Color.Crimson;
                    }
                }
                catch
                {
                    picKapak.Image = null;
                    picKapak.BackColor = Color.Crimson;
                }
            }
            else
            {
                picKapak.Image = null;
                picKapak.BackColor = Color.Crimson;
            }
        }

        private void KartaTiklandi(object sender, EventArgs e)
        {
            HaberSecildi?.Invoke(this, _haberVerisi);
        }
    }
}
