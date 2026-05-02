using System;
using System.Drawing;
using System.Windows.Forms;
using GamePriceHub.Kontrolculer;
using GamePriceHub.Modeller;

namespace GamePriceHub.Gorunumler
{
    public partial class ProfilFormu : Form
    {
        private string _kullaniciAdi;
        private KullaniciKontrolcusu _kullaniciKontrolcu;
        private Kullanici _mevcutKullanici;
        public ProfilFormu(string kullaniciAdi)
        {
            InitializeComponent();
            _kullaniciAdi = kullaniciAdi;
            _kullaniciKontrolcu = new KullaniciKontrolcusu();

            ProfilBilgileriniYukle();
        }

        private void ProfilBilgileriniYukle()
        {
            _mevcutKullanici = _kullaniciKontrolcu.KullaniciBilgileriniGetir(_kullaniciAdi);

            if (_mevcutKullanici != null)
            {
                lblMevcutAdSoyad.Text = "Ad Soyad: " + _mevcutKullanici.AdSoyad;
                lblMevcutKullaniciAdi.Text = "Kullanıcı Adı: " + _mevcutKullanici.KullaniciAdi;
                lblMevcutEposta.Text = "E-Posta: " + _mevcutKullanici.Eposta;
                lblKayitTarihi.Text = "Kayıt Tarihi: " + _mevcutKullanici.KayitTarihi.ToString("dd MMMM yyyy");
                lblRol.Text = "Rol: " + (_mevcutKullanici.RolID == 1 ? "Admin" : "Standart Kullanıcı");

                txtYeniAdSoyad.Text = _mevcutKullanici.AdSoyad;
                txtYeniKullaniciAdi.Text = _mevcutKullanici.KullaniciAdi;
                txtYeniEposta.Text = _mevcutKullanici.Eposta;
                txtYeniSifre.Text = _mevcutKullanici.Sifre;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtYeniAdSoyad.Text) || string.IsNullOrWhiteSpace(txtYeniKullaniciAdi.Text) ||
                string.IsNullOrWhiteSpace(txtYeniEposta.Text) || string.IsNullOrWhiteSpace(txtYeniSifre.Text))
            {
                MessageBox.Show("Alanlar boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool guvenlikGerektirir = false;

            if (_mevcutKullanici.Eposta != txtYeniEposta.Text.Trim() || _mevcutKullanici.Sifre != txtYeniSifre.Text.Trim())
            {
                guvenlikGerektirir = true;
            }

            if (guvenlikGerektirir)
            {
                MailKontrolcusu mailKontrolcusu = new MailKontrolcusu();

                string dogrulamaKodu = mailKontrolcusu.DogrulamaKoduGonder(_mevcutKullanici.Eposta);

                if (dogrulamaKodu == null)
                {
                    MessageBox.Show("Güvenlik kodu e-postanıza gönderilemedi. Lütfen daha sonra tekrar deneyin.", "Mail Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DogrulamaMailSifre dogrulamaEkrani = new DogrulamaMailSifre(_mevcutKullanici.Sifre, dogrulamaKodu);

                if (dogrulamaEkrani.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Doğrulama iptal edildi veya başarısız oldu. Güncelleme yapılmadı.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            bool basarili = _kullaniciKontrolcu.KullaniciGuncelle(
                _mevcutKullanici.ID,
                txtYeniAdSoyad.Text.Trim(),
                txtYeniKullaniciAdi.Text.Trim(),
                txtYeniEposta.Text.Trim(),
                txtYeniSifre.Text.Trim()
            );

            if (basarili)
            {
                MessageBox.Show("Bilgileriniz başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _kullaniciAdi = txtYeniKullaniciAdi.Text.Trim();
                ProfilBilgileriniYukle();
            }
            else
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu. Bu Kullanıcı Adı / E-posta zaten kullanımda olabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYakinda_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel(_kullaniciAdi);
            this.Hide();
            adminPanel.ShowDialog();
            this.Close();
        }

        private void picGeri_Click(object sender, EventArgs e)
        {
            AnaMenu anaMenu = new AnaMenu(_kullaniciAdi);
            this.Hide();
            anaMenu.ShowDialog();
            this.Close();
        }

        private void ProfilFormu_Load(object sender, EventArgs e)
        {
            btnAdmin.Visible = false;

            string baglantiYolu = "Server=localhost;Database=gamepricehub_db;Uid=root;Pwd=;";

            using (MySql.Data.MySqlClient.MySqlConnection baglanti = new MySql.Data.MySqlClient.MySqlConnection(baglantiYolu))
            {
                try
                {
                    baglanti.Open();

                    string sorgu = "SELECT RolID FROM kullanicilar WHERE Eposta = @mailAdresi";

                    MySql.Data.MySqlClient.MySqlCommand komut = new MySql.Data.MySqlClient.MySqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@mailAdresi", GirisFormu.aktifEposta);

                    object sonuc = komut.ExecuteScalar();

                    if (sonuc != null)
                    {
                        int rol = Convert.ToInt32(sonuc);

                        if (rol == 1)
                        {
                            btnAdmin.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
                }
            }
        }


        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Hesabınızdan çıkış yapmak istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                GirisFormu.aktifEposta = "";
                _kullaniciAdi = "";

                this.Hide();

                GirisFormu giris = new GirisFormu();
                giris.ShowDialog();

                this.Close();
            }
        }
    }
}