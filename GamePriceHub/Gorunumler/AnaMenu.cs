using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GamePriceHub.Kontrolculer;
using GamePriceHub.Modeller;

namespace GamePriceHub.Gorunumler
{
    public partial class AnaMenu : Form
    {
        private ApiKontrolcusu _apiKontrolcu;
        private List<Oyun> _mevcutOyunlar;
        private System.Windows.Forms.Timer _aramaTimer;
        private System.Windows.Forms.Timer _filtreTimer;
        private int _mevcutSayfa = 0;
        private bool _aramaModu = false;
        private string _sonArananKelime = "";

        public AnaMenu(string kullaniciAdi = "Misafir")
        {
            InitializeComponent();
            _apiKontrolcu = new ApiKontrolcusu();
            _mevcutOyunlar = new List<Oyun>();
            lblUser.Text = kullaniciAdi;

            _aramaTimer = new System.Windows.Forms.Timer { Interval = 800 };
            _aramaTimer.Tick += async (s, e) => { _aramaTimer.Stop(); await AramaGerceklestir(true); };

            _filtreTimer = new System.Windows.Forms.Timer { Interval = 300 };
            _filtreTimer.Tick += (s, e) => { _filtreTimer.Stop(); FiltreleriUygula(); };

            txtArama.TextChanged += (s, e) => { _aramaTimer.Stop(); _aramaTimer.Start(); };
            trkFiyat.Scroll += (s, e) => { lblFiyatDegeri.Text = $"$0 - ${trkFiyat.Value}"; _filtreTimer.Stop(); _filtreTimer.Start(); };

            var turler = new[] { chkAction, chkRPG, chkIndie, chkSimulation, chkStrategy, chkShooter };
            foreach (var chk in turler) chk.CheckedChanged += (s, e) => FiltreleriUygula();

            var platformlar = new[] { chkSteam, chkEpic, chkGOG, chkHumble, chkDiger };
            foreach (var chk in platformlar) chk.CheckedChanged += (s, e) => FiltreleriUygula();

            cmbSiralama.SelectedIndexChanged += (s, e) => FiltreleriUygula();

            this.Shown += async (s, e) => await PopulerYukle();
        }

        private async void btnOnceki_Click(object sender, EventArgs e)
        {
            await SayfaDegistir(-1);
        }

        private async void btnSonraki_Click(object sender, EventArgs e)
        {
            await SayfaDegistir(1);
        }

        private async Task SayfaDegistir(int artisMiktari)
        {
            if (_mevcutSayfa + artisMiktari < 0) return;

            _mevcutSayfa += artisMiktari;
            lblSayfaBilgisi.Text = $"Sayfa: {_mevcutSayfa + 1}";

            if (_aramaModu)
                await AramaGerceklestir(false);
            else
                await PopulerYukle();
        }

        private async Task PopulerYukle()
        {
            EkranaMesajBas($"Oyunlar hazırlanıyor... (Sayfa {_mevcutSayfa + 1})");
            _mevcutOyunlar = await _apiKontrolcu.PopulerOyunlariGetirAsync(_mevcutSayfa);
            FiltreleriUygula();
        }

        private async Task AramaGerceklestir(bool yeniArama)
        {
            string kelime = txtArama.Text.Trim();

            if (string.IsNullOrEmpty(kelime))
            {
                _aramaModu = false;
                _mevcutSayfa = 0;
                lblSayfaBilgisi.Text = "Sayfa: 1";
                await PopulerYukle();
                return;
            }

            if (yeniArama)
            {
                _aramaModu = true;
                _mevcutSayfa = 0;
                _sonArananKelime = kelime;
                lblSayfaBilgisi.Text = "Sayfa: 1";
            }

            EkranaMesajBas($"'{_sonArananKelime}' aranıyor... (Sayfa {_mevcutSayfa + 1})");
            _mevcutOyunlar = await _apiKontrolcu.OyunAraAsync(_sonArananKelime, _mevcutSayfa);
            FiltreleriUygula();
        }

        private void FiltreleriUygula()
        {
            if (_mevcutOyunlar == null) return;

            var liste = _mevcutOyunlar.Where(o => o.EnUcuzFiyat <= trkFiyat.Value).ToList();

            List<string> seciliPlatformlar = new List<string>();
            if (chkSteam.Checked) seciliPlatformlar.Add("Steam");
            if (chkEpic.Checked) seciliPlatformlar.Add("Epic");
            if (chkGOG.Checked) seciliPlatformlar.Add("GOG");
            if (chkHumble.Checked) seciliPlatformlar.Add("Humble Store");
            bool digerSecili = chkDiger.Checked;

            if (!seciliPlatformlar.Any() && !digerSecili)
            {
                EkranaMesajBas("Lütfen listelemek için sol menüden en az bir Platform seçin.");
                return;
            }

            liste = liste.Where(o =>
                o.MagazaFiyatlari.Keys.Any(m => seciliPlatformlar.Contains(m)) ||
                (digerSecili && o.MagazaFiyatlari.Keys.Any(m => m != "Steam" && m != "Epic" && m != "GOG" && m != "Humble Store"))
            ).ToList();

            var seciliTurler = GetSeciliTurler();
            if (seciliTurler.Any())
                liste = liste.Where(o => o.Turler != null && o.Turler.Any(t => seciliTurler.Any(s => t.Contains(s)))).ToList();

            if (cmbSiralama.SelectedIndex == 1) liste = liste.OrderBy(o => o.EnUcuzFiyat).ToList();
            else if (cmbSiralama.SelectedIndex == 2) liste = liste.OrderByDescending(o => o.EnUcuzFiyat).ToList();
            else if (cmbSiralama.SelectedIndex == 3) liste = liste.OrderByDescending(o => o.PuanYildiz).ToList();
            else liste = liste.OrderByDescending(o => o.PuanYildiz * o.ToplamInceleme).ToList();

            EkranaOyunlariDiz(liste);
        }

        private List<string> GetSeciliTurler()
        {
            var l = new List<string>();
            if (chkAction.Checked) l.Add("Action"); if (chkRPG.Checked) l.Add("RPG");
            if (chkIndie.Checked) l.Add("Indie"); if (chkSimulation.Checked) l.Add("Simulation");
            if (chkStrategy.Checked) l.Add("Strategy"); if (chkShooter.Checked) l.Add("Shooter");
            return l;
        }

        private void EkranaOyunlariDiz(List<Oyun> oyunlar)
        {
            try
            {
                flpOyunlar.SuspendLayout();
                flpOyunlar.Controls.Clear();
                if (!oyunlar.Any()) { EkranaMesajBas("Bu sayfada veya filtrede sonuç bulunamadı."); return; }

                foreach (var oyun in oyunlar.Take(10))
                {
                    OyunKarti kart = new OyunKarti();
                    kart.VeriyiDoldur(oyun, lblUser.Text);

                    // ÇÖZÜM BURADA: Artık her şeye Click bağlamıyoruz.
                    // Sadece Kartın içindeki "Görüntüle" butonundan gelecek olan OyunSecildi event'ine abone oluyoruz.
                    kart.OyunSecildi += Kart_OyunSecildi;

                    flpOyunlar.Controls.Add(kart);
                }
            }
            finally { flpOyunlar.ResumeLayout(); }
        }

        // OyunKarti'ndan "Görüntüle" butonuna tıklandığında tetiklenir
        private void Kart_OyunSecildi(object sender, Oyun secilenOyun)
        {
            OyunDetayFormu detayEkrani = new OyunDetayFormu(secilenOyun, lblUser.Text);
            detayEkrani.ShowDialog();
        }

        private void EkranaMesajBas(string mesaj)
        {
            flpOyunlar.Controls.Clear();
            flpOyunlar.Controls.Add(new Label { Text = mesaj, ForeColor = Color.White, AutoSize = true, Font = new Font("Segoe UI", 12F) });
        }

        private void picWishlist_Click(object sender, EventArgs e)
        {
            IstekListesi istekListesi = new IstekListesi(lblUser.Text);
            this.Hide();
            istekListesi.ShowDialog();
            this.Close();
        }

        private void picAI_Click(object sender, EventArgs e)
        {
            AiOneri frm = new AiOneri(lblUser.Text);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void picSupport_Click(object sender, EventArgs e)
        {
            DestekFormu df = new DestekFormu(lblUser.Text);
            df.ShowDialog();
        }

        private void picUser_Click(object sender, EventArgs e)
        {
            ProfilFormu profil = new ProfilFormu(lblUser.Text);
            this.Hide();
            profil.ShowDialog();
            this.Close();
        }

        private void picHaberler_Click(object sender, EventArgs e)
        {
            HaberlerFormu hf = new HaberlerFormu(lblUser.Text);
            this.Hide();
            hf.ShowDialog();
            this.Close();
        }
    }
}