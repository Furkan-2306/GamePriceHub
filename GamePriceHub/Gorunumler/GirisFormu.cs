using System;
using System.Drawing;
using System.Windows.Forms;
using GamePriceHub.Kontrolculer;

namespace GamePriceHub.Gorunumler
{
    public partial class GirisFormu : Form
    {
        public static string aktifEposta = "";
        private KullaniciKontrolcusu _kontrolcu;

        public GirisFormu()
        {
            InitializeComponent();
            _kontrolcu = new KullaniciKontrolcusu();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            // Giriş yapan kişinin e - postasını hafızaya alıyoruz
            aktifEposta = txtEposta.Text;
            string eposta = txtEposta.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (string.IsNullOrEmpty(eposta) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("E-posta ve şifre boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // MySQL veritabanına gidip kontrol eder ve ismi getirir
            string gercekKullaniciAdi = _kontrolcu.GirisYap(eposta, sifre);

            if (gercekKullaniciAdi != null)
            {
                MessageBox.Show($"Hoş geldin, {gercekKullaniciAdi}! Sisteme yönlendiriliyorsunuz...", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ana Menüye MySQL'den çektiğimiz GERÇEK kullanıcı adını gönderir
                AnaMenu anaMenu = new AnaMenu(gercekKullaniciAdi);
                this.Hide();
                anaMenu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Hatalı e-posta veya şifre.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KayitFormu kayitFormu = new KayitFormu();
            this.Hide();
            kayitFormu.ShowDialog();
            this.Close();
        }

        private void txtSifre_IconRightClick(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = !txtSifre.UseSystemPasswordChar;
        }

        private void GirisFormu_Load(object sender, EventArgs e)
        {

        }
    }
}