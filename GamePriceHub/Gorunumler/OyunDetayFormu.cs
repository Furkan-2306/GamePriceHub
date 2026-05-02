using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GamePriceHub.Modeller;
using GamePriceHub.Kontrolculer;
using System.Collections.Generic;

namespace GamePriceHub.Gorunumler
{
    public partial class OyunDetayFormu : Form
    {
        private Oyun _oyun;
        private string _aktifKullaniciAdi; // Yorumu atacak kişi

        // DİKKAT: Artık bu sayfa açılırken aktif kullanıcıyı da istiyor
        public OyunDetayFormu(Oyun secilenOyun, string aktifKullaniciAdi)
        {
            InitializeComponent();
            _oyun = secilenOyun;
            _aktifKullaniciAdi = aktifKullaniciAdi;

            // TextBox Hint Temizleme
            txtYeniYorum.Enter += (s, e) => { if (txtYeniYorum.Text == "Yorumunuzu buraya yazın...") txtYeniYorum.Text = ""; };
            txtYeniYorum.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtYeniYorum.Text)) txtYeniYorum.Text = "Yorumunuzu buraya yazın..."; };

            VerileriDoldur();
        }

        private void VerileriDoldur()
        {
            Form anaForm = Application.OpenForms["AnaMenu"];
            if (anaForm != null)
            {
                this.Size = anaForm.Size;
                this.StartPosition = FormStartPosition.Manual;
                this.Location = anaForm.Location;
            }

            if (!string.IsNullOrEmpty(_oyun.YuksekCozunurlukluResimURL))
                pbBanner.LoadAsync(_oyun.YuksekCozunurlukluResimURL);

            lblAd.Text = _oyun.Ad;
            lblDevData.Text = string.IsNullOrWhiteSpace(_oyun.Gelistirici) ? "Bilinmiyor" : _oyun.Gelistirici;
            lblDateData.Text = string.IsNullOrWhiteSpace(_oyun.CikisTarihi) ? "Bilinmiyor" : _oyun.CikisTarihi;

            // --- 1. METACRITIC PUANI (Sabit Kalıyor) ---
            lblMetaPuan.Text = _oyun.MetacriticPuaniVarMi ? (_oyun.PuanYildiz * 20).ToString() : "?";

            // --- 2. USER RATING PUANI (Kendi Veritabanımızdan Hesaplanıyor) ---
            YorumKontrolcusu yk = new YorumKontrolcusu();
            double kullaniciPuani = yk.OyununKullaniciPuaniniHesapla(_oyun.Ad, out int toplamYorum);

            if (toplamYorum > 0)
            {
                // Eğer veritabanında yorum varsa puanı yaz (Örn: 4.5)
                lblUserPuan.Text = kullaniciPuani.ToString("0.0");
            }
            else
            {
                // Eğer hiç yorum yoksa soru işareti göster
                lblUserPuan.Text = "?";
            }

            // --- MAĞAZA FİYATLARINI DOLDUR ---
            string[] sabitMagazalar = { "Steam", "Epic", "GOG", "Humble Store" };
            Color cizgiRengi = Color.FromArgb(42, 45, 57);
            Color griYazi = Color.FromArgb(138, 141, 152);

            foreach (var magazaAdi in sabitMagazalar)
            {
                Panel pnlSatir = new Panel { Size = new Size(330, 60), Margin = new Padding(0, 0, 0, 12), BackColor = cizgiRengi };
                pnlSatir.Controls.Add(new Label { Text = magazaAdi, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 18), AutoSize = true });

                bool magazadaVarMi = _oyun.MagazaFiyatlari != null && _oyun.MagazaFiyatlari.ContainsKey(magazaAdi);

                Label lblFiyat = new Label { AutoSize = true };
                if (magazadaVarMi)
                {
                    lblFiyat.Text = "$" + _oyun.MagazaFiyatlari[magazaAdi].ToString("0.00");
                    lblFiyat.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                    lblFiyat.ForeColor = Color.FromArgb(76, 175, 80);
                    lblFiyat.Location = new Point(150, 16);
                }
                else
                {
                    lblFiyat.Text = "Mevcut Değil";
                    lblFiyat.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                    lblFiyat.ForeColor = griYazi;
                    lblFiyat.Location = new Point(140, 21);
                }
                pnlSatir.Controls.Add(lblFiyat);

                Button btnGit = new Button();
                btnGit.Text = "🔗 GİT";
                btnGit.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btnGit.Size = new Size(70, 34);
                btnGit.Location = new Point(245, 13);
                btnGit.FlatStyle = FlatStyle.Flat;
                btnGit.FlatAppearance.BorderSize = 0;
                btnGit.Cursor = Cursors.Hand;

                if (magazadaVarMi)
                {
                    btnGit.ForeColor = Color.White;
                    btnGit.BackColor = Color.FromArgb(0, 120, 215);
                    string tiklananMagaza = magazaAdi;
                    btnGit.Click += (s, e) => MagazayaOzelLinkAc(_oyun, tiklananMagaza);
                }
                else
                {
                    btnGit.ForeColor = Color.DarkGray;
                    btnGit.BackColor = Color.FromArgb(60, 60, 65);
                    string hataMagazasi = magazaAdi;
                    btnGit.Click += (s, e) => MessageBox.Show($"{hataMagazasi} platformu bu oyunu desteklemiyor.", "Desteklenmiyor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                pnlSatir.Controls.Add(btnGit);
                flpFiyatlar.Controls.Add(pnlSatir);
            }

            // --- YORUMLARI GERÇEK VERİTABANINDAN ÇEK ---
            YorumlariYukle();
        }

        private void YorumlariYukle()
        {
            flpYorumlar.Controls.Clear();
            YorumKontrolcusu yk = new YorumKontrolcusu();
            List<Yorum> gercekYorumlar = yk.OyunYorumlariniGetir(_oyun.Ad);

            if (gercekYorumlar == null || gercekYorumlar.Count == 0)
            {
                Label lblUyari = new Label { Text = "Bu oyuna henüz yorum yapılmamış.\nİlk yorumu sen yap!", Font = new Font("Segoe UI", 10, FontStyle.Italic), ForeColor = Color.Gray, AutoSize = true, Location = new Point(10, 10) };
                flpYorumlar.Controls.Add(lblUyari);
                return;
            }

            foreach (var yorum in gercekYorumlar)
            {
                Panel pnlYorum = new Panel { Size = new Size(330, 90), Margin = new Padding(10, 0, 0, 12), BackColor = Color.FromArgb(42, 45, 57) };

                Label lblKullanici = new Label { Text = yorum.KullaniciAdi, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 10), AutoSize = true };
                pnlYorum.Controls.Add(lblKullanici);

                string durumYazisi = "😐 Nötr";
                Color durumRengi = Color.Gray;

                if (yorum.PuanDurumu == 1) { durumYazisi = "👍 Olumlu"; durumRengi = Color.FromArgb(76, 175, 80); }
                else if (yorum.PuanDurumu == 2) { durumYazisi = "👎 Olumsuz"; durumRengi = Color.Crimson; }

                Label lblDurum = new Label { Text = durumYazisi, Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = durumRengi, Location = new Point(230, 10), AutoSize = true };
                pnlYorum.Controls.Add(lblDurum);

                Label lblMetin = new Label { Text = yorum.YorumMetni, Font = new Font("Segoe UI", 9), ForeColor = Color.LightGray, Location = new Point(15, 35), Size = new Size(300, 45), AutoEllipsis = true };
                pnlYorum.Controls.Add(lblMetin);

                flpYorumlar.Controls.Add(pnlYorum);
            }
        }

        private void btnYorumGonder_Click(object sender, EventArgs e)
        {
            if (_aktifKullaniciAdi == "Misafir")
            {
                MessageBox.Show("Yorum yapabilmek için lütfen giriş yapın veya kayıt olun.", "Üye Girişi Gerekli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtYeniYorum.Text) || txtYeniYorum.Text == "Yorumunuzu buraya yazın...")
            {
                MessageBox.Show("Lütfen bir yorum metni yazın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPuanDurumu.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen yorumunuza bir puan durumu (Olumlu/Nötr/Olumsuz) seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int secilenPuan = 0;
            if (cmbPuanDurumu.SelectedIndex == 0) secilenPuan = 1; 
            else if (cmbPuanDurumu.SelectedIndex == 1) secilenPuan = 0; 
            else if (cmbPuanDurumu.SelectedIndex == 2) secilenPuan = 2; 

            KullaniciKontrolcusu kk = new KullaniciKontrolcusu();
            Kullanici aktifUser = kk.KullaniciBilgileriniGetir(_aktifKullaniciAdi);

            if (aktifUser != null)
            {
                YorumKontrolcusu yk = new YorumKontrolcusu();
                bool basarili = yk.YorumEkle(aktifUser.ID, _oyun.Ad, txtYeniYorum.Text.Trim(), secilenPuan);

                if (basarili)
                {
                    MessageBox.Show("Yorumunuz başarıyla paylaşıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtYeniYorum.Text = "Yorumunuzu buraya yazın..."; 
                    cmbPuanDurumu.SelectedIndex = -1; 
                    YorumlariYukle(); 
                }
                else
                {
                    MessageBox.Show("Yorum kaydedilirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MagazayaOzelLinkAc(Oyun oyun, string magazaAdi)
        {
            try
            {
                string hedefUrl = "";
                string oyunAdiFormatli = Uri.EscapeDataString(oyun.Ad);

                if (magazaAdi == "Steam" && !string.IsNullOrEmpty(oyun.SteamAppID) && oyun.SteamAppID != "0")
                {
                    hedefUrl = $"https://store.steampowered.com/app/{oyun.SteamAppID}";
                }
                else if (magazaAdi == "Epic")
                {
                    hedefUrl = $"https://store.epicgames.com/tr/browse?q={oyunAdiFormatli}";
                }
                else if (magazaAdi == "GOG")
                {
                    hedefUrl = $"https://www.gog.com/games?query={oyunAdiFormatli}";
                }
                else if (magazaAdi == "Humble Store")
                {
                    hedefUrl = $"https://www.humblebundle.com/store/search?sort=bestselling&search={oyunAdiFormatli}";
                }
                else
                {
                    hedefUrl = $"https://www.google.com/search?q={oyunAdiFormatli}+{magazaAdi}+store";
                }

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = hedefUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tarayıcı açılırken bir sorun oluştu.\nDetay: " + ex.Message, "Sistem Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pnlMeta_Paint(object sender, PaintEventArgs e)
        {
            YuvarlakCiz(e.Graphics, pnlMeta.Width, Color.FromArgb(30, 144, 255));
        }

        private void pnlUser_Paint(object sender, PaintEventArgs e)
        {
            YuvarlakCiz(e.Graphics, pnlUser.Width, Color.FromArgb(255, 193, 7));
        }

        private void YuvarlakCiz(Graphics g, int boyut, Color renk)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen penKalin = new Pen(renk, 5);
            Pen penInce = new Pen(Color.FromArgb(60, 60, 60), 5);
            g.DrawArc(penInce, 5, 5, boyut - 10, boyut - 10, 0, 360);
            g.DrawArc(penKalin, 5, 5, boyut - 10, boyut - 10, -90, 270);
        }
    }
}