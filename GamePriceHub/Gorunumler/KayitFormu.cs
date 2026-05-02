using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GamePriceHub.Kontrolculer;

namespace GamePriceHub.Gorunumler
{
    public partial class KayitFormu : Form
    {
        private KullaniciKontrolcusu _kontrolcu;
        private MailKontrolcusu _mailKontrolcusu;

        public KayitFormu()
        {
            InitializeComponent();
            _kontrolcu = new KullaniciKontrolcusu();
            _mailKontrolcusu = new MailKontrolcusu();

            // ÇÖZÜM: Göz ikonlarına tıklanma (Event) olaylarını burada bağlıyoruz
            txtSifre.IconRightClick += txtSifre_IconRightClick;
            txtSifreTekrar.IconRightClick += txtSifreTekrar_IconRightClick;

            // BONUS: İkonların üzerine gelince fare imlecinin el (tıklanabilir) olmasını sağlıyoruz
            txtSifre.IconRightCursor = Cursors.Hand;
            txtSifreTekrar.IconRightCursor = Cursors.Hand;
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            string adSoyad = txtAdSoyad.Text.Trim();
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string eposta = txtEposta.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            string sifreTekrar = txtSifreTekrar.Text.Trim();


            if (string.IsNullOrEmpty(adSoyad) || string.IsNullOrEmpty(kullaniciAdi) ||
                string.IsNullOrEmpty(eposta) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!Regex.IsMatch(eposta, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi giriniz (Örn: kullanici@gmail.com).", "Geçersiz Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (sifre != sifreTekrar)
            {
                MessageBox.Show("Girdiğiniz şifreler eşleşmiyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            bool musait = _kontrolcu.KullaniciMusaitMi(eposta, kullaniciAdi);

            if (musait)
            {

                string uretilenKod = _mailKontrolcusu.DogrulamaKoduGonder(eposta);

                if (uretilenKod != null)
                {
                    MessageBox.Show("Doğrulama kodunuz (OTP) e-posta adresinize gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DogrulamaFormu dogrulamaFormu = new DogrulamaFormu(adSoyad, kullaniciAdi, eposta, sifre, uretilenKod);
                    this.Hide();
                    dogrulamaFormu.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Kayıt başarısız. Bu e-posta veya kullanıcı adı sisteme zaten kayıtlı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblGirisYap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GirisFormu girisFormu = new GirisFormu();
            this.Hide();
            girisFormu.ShowDialog();
            this.Close();
        }

        // Şifreyi Göster/Gizle
        private void txtSifre_IconRightClick(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = !txtSifre.UseSystemPasswordChar;
        }

        // Tekrar Şifresini Göster/Gizle
        private void txtSifreTekrar_IconRightClick(object sender, EventArgs e)
        {
            txtSifreTekrar.UseSystemPasswordChar = !txtSifreTekrar.UseSystemPasswordChar;
        }
    }
}