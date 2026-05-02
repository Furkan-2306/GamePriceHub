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
    public partial class IstekListesi : Form
    {
        private string _kullaniciAdi;
        private IstekListesiKontrolcusu _kontrolcu;
        private List<Oyun> _tumFavoriler;
        private ApiKontrolcusu _apiKontrolcu;
        private System.Windows.Forms.Timer _aramaTimer;

        public IstekListesi(string kullaniciAdi)
        {
            InitializeComponent();
            _kullaniciAdi = kullaniciAdi;

            _kontrolcu = new IstekListesiKontrolcusu();
            _apiKontrolcu = new ApiKontrolcusu();
            _tumFavoriler = new List<Oyun>();

            lblUser.Text = _kullaniciAdi;
            _oneriListesi.BringToFront();

            _aramaTimer = new System.Windows.Forms.Timer { Interval = 600 };
            _aramaTimer.Tick += async (s, e) =>
            {
                _aramaTimer.Stop();
                await CanliOnerileriGetir();
            };

            OyunlariYukle();
            picSupport.Click += (s, e) => {
                string mail = "gamepricehub.sistem@gmail.com";
                string url = $"https://mail.google.com/mail/?view=cm&fs=1&to={mail}&su=Destek+Talebi";
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
            };
        }

        private void OyunlariYukle()
        {
            flpOyunlar.Controls.Clear();
            _tumFavoriler = _kontrolcu.Listele(_kullaniciAdi);

            if (_tumFavoriler.Count == 0)
            {
                flpOyunlar.Controls.Add(new Label
                {
                    Text = "İstek listeniz şu an boş. Hemen fırsatları keşfetmeye başlayın!",
                    ForeColor = Color.White,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12F)
                });
                return;
            }

            foreach (var oyun in _tumFavoriler)
            {
                OyunKarti kart = new OyunKarti();
                kart.VeriyiDoldur(oyun, _kullaniciAdi);
                flpOyunlar.Controls.Add(kart);
            }
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            _aramaTimer.Stop();

            if (string.IsNullOrEmpty(txtArama.Text.Trim()))
            {
                _oneriListesi.Visible = false;
            }
            else
            {
                _aramaTimer.Start();
            }
        }

        private async Task CanliOnerileriGetir()
        {
            string aranan = txtArama.Text.Trim();
            if (string.IsNullOrEmpty(aranan)) return;

            var sonuclar = await _apiKontrolcu.OyunAraAsync(aranan, 0);

            _oneriListesi.Items.Clear();

            foreach (var oyun in sonuclar.Take(6))
            {
                _oneriListesi.Items.Add(oyun.Ad);
            }

            if (_oneriListesi.Items.Count > 0)
            {
                _oneriListesi.Height = (_oneriListesi.Items.Count * _oneriListesi.ItemHeight) + 5;
                _oneriListesi.Visible = true;
                _oneriListesi.BringToFront();
            }
            else
            {
                _oneriListesi.Visible = false;
            }
        }

        private void OneriSecildi(object sender, EventArgs e)
        {
            if (_oneriListesi.SelectedItem != null)
            {
                string secilenOyun = _oneriListesi.SelectedItem.ToString();

                _oneriListesi.Visible = false;
                txtArama.Text = secilenOyun;

                MessageBox.Show($"'{secilenOyun}' oyununun detaylı bilgi ve analiz sayfası çok yakında eklenecektir!", "GamePriceHub Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _oneriListesi.ClearSelected();
            }
        }

        protected override void OnClick(EventArgs e)
        {
            _oneriListesi.Visible = false;
            base.OnClick(e);
        }

        private void AnaMenuyeDon()
        {
            AnaMenu anaMenu = new AnaMenu(_kullaniciAdi);
            this.Hide();
            anaMenu.ShowDialog();
            this.Close();
        }

        private void picGeri_Click(object sender, EventArgs e) => AnaMenuyeDon();
        private void picAnaMenu_Click(object sender, EventArgs e) => AnaMenuyeDon();
        // IstekListesi.cs içindeki buton kodu
        private void picAI_Click(object sender, EventArgs e)
        {
            // Mevcut sayfadaki kullanıcı adını alıp AI sayfasına gönderiyoruz
            // Eğer buradaki değişkenin adı farklıysa onu yaz (örn: _kullaniciAdi)
            AiOneri frm = new AiOneri(this._kullaniciAdi);

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
    }
}