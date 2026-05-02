using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using GamePriceHub.Modeller;
using GamePriceHub.Kontrolculer; // API'ye erişmek için eklendi
using System.Threading.Tasks;
using NAudio.Wave;
using System.Net;
using System.Threading;

namespace GamePriceHub.Gorunumler
{
    public partial class AiOneri : Form
    {
        private string _kullaniciAdi;
        private WaveOutEvent _outputDevice;

        public AiOneri(string kullaniciAdi = "Misafir")
        {
            InitializeComponent();
            _kullaniciAdi = string.IsNullOrEmpty(kullaniciAdi) ? "Misafir" : kullaniciAdi;

            if (lblUser != null) lblUser.Text = _kullaniciAdi.ToUpper();

            // Navigasyon olayları
            this.lblIstek.Click += new System.EventHandler(this.lblIstek_Click);
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            this.lblAnaSayfa.Click += new System.EventHandler(this.lblAnaSayfa_Click);
            this.lblDestek.Click += new System.EventHandler(this.lblDestek_Click);

            lblAnaSayfa.BringToFront();
            lblIstek.BringToFront();
            lblDestek.BringToFront();
            lblUser.BringToFront();

            // Sayfa ilk açıldığında Angela gelsin
            AiKarsilamaYap();

            // Sol menüdeki soru butonları
            SoruButonuEkle("En popüler e-spor oyunları?", 455);
            SoruButonuEkle("En iyi spor oyunlarını listele", 530);
            SoruButonuEkle("İstek listeme göre oyun öner", 605);
        }

        private async void SoruCevapla(string soru)
        {
            if (_outputDevice != null)
            {
                try { _outputDevice.Stop(); _outputDevice.Dispose(); } catch { }
                _outputDevice = null;
            }

            if (pnlOyunListesi == null) return;
            pnlOyunListesi.Controls.Clear();
            string s = soru.ToLower();

            if (s.Contains("e-spor"))
            {
                _ = ProfesyonelSeslendir("E-spor dünyasının en rekabetçi oyunlarını listeliyorum.");
                EkleOyun("League of Legends", 0, "https://cdn.akamai.steamstatic.com/steam/apps/1240440/header.jpg");
                EkleOyun("Valorant", 0, "https://images.contentstack.io/v3/assets/bltb6530b271fddd0b1/blt3f00439d3d360060/62327571a3962450000a6e60/031622_Valorant_Crossover_KeyArt_v2.jpg");
                EkleOyun("Counter-Strike 2", 0, "https://cdn.akamai.steamstatic.com/steam/apps/730/header.jpg"); // "CS 2" API'de bulunamayabilir diye tam adı yazıldı
                EkleOyun("Dota 2", 0, "https://cdn.akamai.steamstatic.com/steam/apps/570/header.jpg");
                EkleOyun("Rainbow Six Siege", 230, "https://cdn.akamai.steamstatic.com/steam/apps/359550/header.jpg");
                EkleOyun("Rocket League", 0, "https://cdn.akamai.steamstatic.com/steam/apps/252950/header.jpg");
            }
            else if (s.Contains("spor") && !s.Contains("e-spor"))
            {
                _ = ProfesyonelSeslendir("Sahaya çıkmaya hazır mısın? İşte en iyi spor oyunları.");
                EkleOyun("EA SPORTS FC 24", 1199, "https://cdn.akamai.steamstatic.com/steam/apps/2195250/header.jpg");
                EkleOyun("NBA 2K24", 850, "https://cdn.akamai.steamstatic.com/steam/apps/2338770/header.jpg");
                EkleOyun("F1 23", 950, "https://cdn.akamai.steamstatic.com/steam/apps/2108330/header.jpg");
                EkleOyun("Football Manager 2024", 899, "https://cdn.akamai.steamstatic.com/steam/apps/2252570/header.jpg");
                EkleOyun("WWE 2K23", 750, "https://cdn.akamai.steamstatic.com/steam/apps/1942660/header.jpg");
            }
            else if (s.Contains("popüler"))
            {
                _ = ProfesyonelSeslendir("Şu an dünyayı kasıp kavuran popüler oyunlar listeleniyor.");
                EkleOyun("Elden Ring", 1200, "https://cdn.akamai.steamstatic.com/steam/apps/1245620/header.jpg");
                EkleOyun("Cyberpunk 2077", 799, "https://cdn.akamai.steamstatic.com/steam/apps/1091500/header.jpg");
                EkleOyun("Baldur's Gate 3", 850, "https://cdn.akamai.steamstatic.com/steam/apps/1086940/header.jpg");
                EkleOyun("Grand Theft Auto V", 550, "https://cdn.akamai.steamstatic.com/steam/apps/271590/header.jpg");
                EkleOyun("Red Dead Redemption 2", 1150, "https://cdn.akamai.steamstatic.com/steam/apps/1174180/header.jpg");
                EkleOyun("The Last of Us Part I", 1299, "https://cdn.akamai.steamstatic.com/steam/apps/1888590/header.jpg");
            }
            else if (s.Contains("dostu"))
            {
                _ = ProfesyonelSeslendir("Cüzdan dostu, fiyat performans canavarı oyunlar burada.");
                EkleOyun("Stardew Valley", 120, "https://cdn.akamai.steamstatic.com/steam/apps/413150/header.jpg");
                EkleOyun("Terraria", 105, "https://cdn.akamai.steamstatic.com/steam/apps/105600/header.jpg");
                EkleOyun("Hades", 235, "https://cdn.akamai.steamstatic.com/steam/apps/1145360/header.jpg");
                EkleOyun("Vampire Survivors", 35, "https://cdn.akamai.steamstatic.com/steam/apps/1794680/header.jpg");
                EkleOyun("Among Us", 50, "https://cdn.akamai.steamstatic.com/steam/apps/945360/header.jpg");
                EkleOyun("Left 4 Dead 2", 105, "https://cdn.akamai.steamstatic.com/steam/apps/550/header.jpg");
            }
            else if (s.Contains("rpg"))
            {
                _ = ProfesyonelSeslendir("Seni yüzlerce saat esir alacak RPG dünyaları listeleniyor.");
                EkleOyun("The Witcher 3: Wild Hunt", 150, "https://cdn.akamai.steamstatic.com/steam/apps/292030/header.jpg");
                EkleOyun("The Elder Scrolls V: Skyrim", 349, "https://cdn.akamai.steamstatic.com/steam/apps/489830/header.jpg");
                EkleOyun("Dark Souls III", 899, "https://cdn.akamai.steamstatic.com/steam/apps/374320/header.jpg");
                EkleOyun("Fallout 4", 179, "https://cdn.akamai.steamstatic.com/steam/apps/377160/header.jpg");
                EkleOyun("Mass Effect Legendary Edition", 599, "https://cdn.akamai.steamstatic.com/steam/apps/1328670/header.jpg");
                EkleOyun("Starfield", 1150, "https://cdn.akamai.steamstatic.com/steam/apps/1716740/header.jpg");
            }
            else if (s.Contains("satanlar"))
            {
                _ = ProfesyonelSeslendir("Mağazalardaki en çok satan güncel listeler getiriliyor.");
                EkleOyun("Portal 2", 105, "https://cdn.akamai.steamstatic.com/steam/apps/620/header.jpg");
                EkleOyun("Rust", 350, "https://cdn.akamai.steamstatic.com/steam/apps/252940/header.jpg");
                EkleOyun("Forza Horizon 5", 950, "https://cdn.akamai.steamstatic.com/steam/apps/1551360/header.jpg");
                EkleOyun("Sea of Thieves", 399, "https://cdn.akamai.steamstatic.com/steam/apps/1172620/header.jpg");
                EkleOyun("God of War", 899, "https://cdn.akamai.steamstatic.com/steam/apps/1593500/header.jpg");
                EkleOyun("Marvel’s Spider-Man Remastered", 1099, "https://cdn.akamai.steamstatic.com/steam/apps/1817070/header.jpg");
            }
            else if (s.Contains("istek listeme"))
            {
                var istekKontrolcu = new GamePriceHub.Kontrolculer.IstekListesiKontrolcusu();
                var favoriOyunlar = istekKontrolcu.Listele(_kullaniciAdi);

                if (favoriOyunlar == null || favoriOyunlar.Count == 0)
                {
                    _ = ProfesyonelSeslendir("Listeniz şu an boş. Size efsane oyunlardan bir seçki hazırladım.");
                    EkleOyun("The Witcher 3: Wild Hunt", 150, "https://cdn.akamai.steamstatic.com/steam/apps/292030/header.jpg");
                    EkleOyun("Grand Theft Auto V", 550, "https://cdn.akamai.steamstatic.com/steam/apps/271590/header.jpg");
                    EkleOyun("Red Dead Redemption 2", 1150, "https://cdn.akamai.steamstatic.com/steam/apps/1174180/header.jpg");
                }
                else
                {
                    _ = ProfesyonelSeslendir("İstek listenizi analiz ettim ve size en uygun olanları seçtim.");
                    int fpsPuan = 0, rpgPuan = 0, sporPuan = 0, korkuPuan = 0;
                    foreach (var oyun in favoriOyunlar)
                    {
                        string ad = oyun.Ad.ToLower();
                        if (ad.Contains("pubg") || ad.Contains("cs") || ad.Contains("valorant") || ad.Contains("cod") || ad.Contains("doom")) fpsPuan++;
                        if (ad.Contains("witcher") || ad.Contains("skyrim") || ad.Contains("elden") || ad.Contains("cyberpunk")) rpgPuan++;
                        if (ad.Contains("fifa") || ad.Contains("fc 24") || ad.Contains("nba")) sporPuan++;
                        if (ad.Contains("resident evil") || ad.Contains("outlast")) korkuPuan++;
                    }

                    if (fpsPuan > 0) EkleOyun("Tom Clancy's Rainbow Six Siege", 230, "https://cdn.akamai.steamstatic.com/steam/apps/359550/header.jpg");
                    if (rpgPuan > 0) EkleOyun("Cyberpunk 2077", 799, "https://cdn.akamai.steamstatic.com/steam/apps/1091500/header.jpg");
                    if (sporPuan > 0) EkleOyun("Rocket League", 0, "https://cdn.akamai.steamstatic.com/steam/apps/252950/header.jpg");
                    if (fpsPuan == 0 && rpgPuan == 0 && sporPuan == 0)
                    {
                        EkleOyun("Stardew Valley", 120, "https://cdn.akamai.steamstatic.com/steam/apps/413150/header.jpg");
                    }
                }
            }
            pnlOyunListesi.ResumeLayout();
        }

        public async void AiKarsilamaYap()
        {
            if (_outputDevice != null) { try { _outputDevice.Stop(); } catch { } }
            pnlOyunListesi.Controls.Clear();

            _ = ProfesyonelSeslendir("Merhaba! Sana oyun önermek için buradayım. İstediğin sorulara tıkla ve sana önerilerimi sunayım.");

            PictureBox pbAngelaGif = new PictureBox();

            pbAngelaGif.Size = new Size(pnlOyunListesi.Width - 40, pnlOyunListesi.Height - 50);
            pbAngelaGif.SizeMode = PictureBoxSizeMode.Zoom;
            pbAngelaGif.Margin = new Padding(0);

            string gifYolu = System.IO.Path.Combine(Application.StartupPath, "Gorseller", "angela.gif");
            pbAngelaGif.ImageLocation = gifYolu;

            pnlOyunListesi.Controls.Add(pbAngelaGif);
            pbAngelaGif.BringToFront();

            await Task.Delay(8000);

            if (pbAngelaGif != null && !pbAngelaGif.IsDisposed)
            {
                pbAngelaGif.Enabled = false;
            }
        }

        private void EkleOyun(string ad, int fiyat, string resimUrl)
        {
            KartEkle(new Oyun { Ad = ad, EnUcuzFiyat = fiyat, ResimURL = resimUrl });
        }

        private void KartEkle(Oyun o)
        {
            Guna2Panel kart = new Guna2Panel { Size = new Size(240, 350), FillColor = Color.FromArgb(30, 30, 45), BorderRadius = 15, Margin = new Padding(12) };
            Guna2PictureBox pic = new Guna2PictureBox { Size = new Size(220, 130), Location = new Point(10, 10), BorderRadius = 10, SizeMode = PictureBoxSizeMode.StretchImage, ImageLocation = o.ResimURL };
            Label lAd = new Label { Text = o.Ad, Size = new Size(220, 50), Location = new Point(10, 150), TextAlign = ContentAlignment.TopCenter, ForeColor = Color.White, Font = new Font("Segoe UI", 11F, FontStyle.Bold) };
            Label lFiyat = new Label { Text = (o.EnUcuzFiyat == 0 ? "ÜCRETSİZ" : o.EnUcuzFiyat + " TL"), Size = new Size(220, 30), Location = new Point(10, 210), TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Cyan, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };
            Guna2Button btn = new Guna2Button { Text = "İncele", Size = new Size(200, 40), Location = new Point(20, 290), BorderRadius = 10, FillColor = Color.FromArgb(50, 50, 70), Cursor = Cursors.Hand };

            // --- GÜNCELLENEN KISIM: GERÇEK API VERİSİ ÇEKİLİYOR ---
            btn.Click += async (s, e) => {
                string fiyatMetni = o.EnUcuzFiyat == 0 ? "tamamen ücretsiz." : $"en ucuz {o.EnUcuzFiyat} Türk Lirası.";
                string konusmaMetni = $"{o.Ad} harika bir seçim! Bu oyun şu an {fiyatMetni} Hemen detaylarını senin için hazırlıyorum, lütfen bekle.";

                _ = ProfesyonelSeslendir(konusmaMetni);

                // Kullanıcıya arama yapıldığını belli etmek için butonu kilitleyelim
                btn.Text = "Yükleniyor...";
                btn.Enabled = false;

                // Oyunun tam verilerini API'den çekiyoruz
                ApiKontrolcusu api = new ApiKontrolcusu();
                Oyun gercekOyun = o; // Varsayılan olarak mevcut maketi tut

                try
                {
                    var apiSonucu = await api.OyunAraAsync(o.Ad);
                    if (apiSonucu != null && apiSonucu.Count > 0)
                    {
                        gercekOyun = apiSonucu[0]; // Bulunan ilk doğru oyunu al
                    }
                    else
                    {
                        // Çökme ihtimaline karşı null olan sözlüğü doldur
                        gercekOyun.MagazaFiyatlari = new Dictionary<string, double>();
                    }
                }
                catch
                {
                    gercekOyun.MagazaFiyatlari = new Dictionary<string, double>();
                }

                btn.Text = "İncele";
                btn.Enabled = true;

                // Gerçek ve dolu oyun objesiyle detay sayfasını aç
                OyunDetayFormu d = new OyunDetayFormu(gercekOyun, _kullaniciAdi);
                this.Hide();
                d.ShowDialog();
                this.Show();

                // Detay formundan dönüldüğünde ses hala çalıyorsa sustur
                if (_outputDevice != null) { try { _outputDevice.Stop(); } catch { } }
            };
            // -------------------------------------------------------------

            kart.Controls.AddRange(new Control[] { pic, lAd, lFiyat, btn });
            pnlOyunListesi.Controls.Add(kart);
        }

        private void SoruButonuEkle(string metin, int yKonumu)
        {
            Guna2Button btn = new Guna2Button { Text = metin, Size = new Size(270, 60), Location = new Point(15, yKonumu), BorderRadius = 12, FillColor = Color.FromArgb(35, 35, 50), ForeColor = Color.White, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Cursor = Cursors.Hand, Animated = true };
            btn.Click += (s, e) => SoruCevapla(btn.Text);
            if (pnlSol != null) { pnlSol.Controls.Add(btn); btn.BringToFront(); }
        }

        private void lblAnaSayfa_Click(object sender, EventArgs e) => this.Close();
        private void lblIstek_Click(object sender, EventArgs e) { /* ... */ }
        private void lblDestek_Click(object sender, EventArgs e) { /* ... */ }
        private void lblUser_Click(object sender, EventArgs e) { /* ... */ }

        private void btnSoru_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button b)
            {
                SoruCevapla(b.Text);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task ProfesyonelSeslendir(string metin)
        {
            try
            {
                if (_outputDevice != null) { _outputDevice.Stop(); _outputDevice.Dispose(); _outputDevice = null; }
                string url = $"https://translate.google.com/translate_tts?ie=UTF-8&q={Uri.EscapeDataString(metin)}&tl=tr&client=tw-ob";
                await Task.Run(() => {
                    try
                    {
                        using (var mf = new MediaFoundationReader(url))
                        {
                            var dev = new WaveOutEvent(); dev.Init(mf); _outputDevice = dev; _outputDevice.Play();
                            while (_outputDevice != null && _outputDevice.PlaybackState == PlaybackState.Playing) Thread.Sleep(100);
                        }
                    }
                    catch { }
                });
            }
            catch { }
        }
    }
}