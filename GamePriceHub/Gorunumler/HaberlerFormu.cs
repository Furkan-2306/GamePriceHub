using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GamePriceHub.Kontrolculer;
using GamePriceHub.Modeller;

namespace GamePriceHub.Gorunumler
{
    public partial class HaberlerFormu : Form
    {
        private string _aktifKullaniciAdi;
        private HaberKontrolcusu _haberKontrolcu;
        private List<Haber> _tumHaberler;

        public HaberlerFormu(string kullaniciAdi)
        {
            InitializeComponent();
            _aktifKullaniciAdi = kullaniciAdi;
            _haberKontrolcu = new HaberKontrolcusu();
        }

        private void HaberlerFormu_Load(object sender, EventArgs e)
        {
            HaberleriYukle();
        }

        private void HaberleriYukle()
        {
            _tumHaberler = _haberKontrolcu.HaberleriGetir();
            EkranaDiz(_tumHaberler);
        }

        private void EkranaDiz(List<Haber> liste)
        {
            flpHaberler.Controls.Clear();
            foreach (var haber in liste)
            {
                HaberKarti kart = new HaberKarti();
                kart.VeriyiDoldur(haber);
                // Karta tıklandığında detay açılması için olay bağlama
                kart.HaberSecildi += HaberDetayiniAc;
                flpHaberler.Controls.Add(kart);
            }
        }

        private void HaberDetayiniAc(object sender, Haber secilenHaber)
        {
            // ÇÖZÜM: Artık mesaj kutusu yerine, yeni yaptığımız detay sayfasını açıyoruz.
            HaberDetayFormu detayFormu = new HaberDetayFormu(secilenHaber, _aktifKullaniciAdi);
            this.Hide(); // Haber listesini geçici olarak gizle
            detayFormu.ShowDialog(); // Makaleyi okut
            this.Show(); // Geri tuşuna basınca haber listesini kaldığı yerden (scroll sıfırlanmadan) tekrar göster
        }

        private void txtHaberAra_TextChanged(object sender, EventArgs e)
        {
            string aranan = txtHaberAra.Text.ToLower().Trim();
            var filtrelenmiş = _tumHaberler.Where(h =>
                h.Baslik.ToLower().Contains(aranan) ||
                h.Kategori.ToLower().Contains(aranan)
            ).ToList();

            EkranaDiz(filtrelenmiş);
        }

        private void picGeri_Click(object sender, EventArgs e)
        {
            AnaMenu anaMenu = new AnaMenu(_aktifKullaniciAdi);
            this.Hide();
            anaMenu.ShowDialog();
            this.Close();
        }
    }
}