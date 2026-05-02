using System;
using System.IO;
using System.Windows.Forms;
using GamePriceHub.Modeller;
using Microsoft.Web.WebView2.Core;

namespace GamePriceHub.Gorunumler
{
    public partial class HaberDetayFormu : Form
    {
        private Haber _secilenHaber;
        private string _aktifKullaniciAdi;

        public HaberDetayFormu(Haber haber, string kullaniciAdi)
        {
            InitializeComponent();
            _secilenHaber = haber;
            _aktifKullaniciAdi = kullaniciAdi;

            // Form yüklenirken PDF'i hazırla
            this.Load += HaberDetayFormu_Load;
        }

        private async void HaberDetayFormu_Load(object sender, EventArgs e)
        {
            try
            {
                // WebView2 başlatılıyor
                await webView21.EnsureCoreWebView2Async();

                // CANLI İÇİN KRİTİK: PDF'in yolunu dinamik olarak belirle
                // Uygulamanın çalıştığı klasör / Haberler / dosya.pdf
                string haberlerKlasoru = Path.Combine(Application.StartupPath, "Haberler");
                string pdfYolu = Path.Combine(haberlerKlasoru, _secilenHaber.PdfDosyaAdi);

                if (File.Exists(pdfYolu))
                {
                    // PDF'i form içinde göster
                    webView21.CoreWebView2.Navigate(pdfYolu);
                }
                else
                {
                    MessageBox.Show("PDF Dosyası bulunamadı: " + pdfYolu, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF Görüntüleyici başlatılamadı: " + ex.Message);
            }
        }

        private void picGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}