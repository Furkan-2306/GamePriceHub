using System;
using System.Windows.Forms;
using GamePriceHub.Kontrolculer;

namespace GamePriceHub.Gorunumler
{
    public partial class DogrulamaFormu : Form
    {
        private MailKontrolcusu _mailKontrolcusu;
        private KullaniciKontrolcusu _kullaniciKontrolcusu;

        private string _adSoyad;
        private string _kullaniciAdi;
        private string _eposta;
        private string _sifre;
        private string _gonderilenKod;

        
        public DogrulamaFormu(string adSoyad, string kullaniciAdi, string eposta, string sifre, string ilkKod)
        {
            InitializeComponent();
            _mailKontrolcusu = new MailKontrolcusu();
            _kullaniciKontrolcusu = new KullaniciKontrolcusu();

            _adSoyad = adSoyad;
            _kullaniciAdi = kullaniciAdi;
            _eposta = eposta;
            _sifre = sifre;
            _gonderilenKod = ilkKod; 

            lblEpostaBilgi.Text = $"Code sent to: {_eposta}";
        }

        
        private void KodGonderTetikle()
        {
            string yeniKod = _mailKontrolcusu.DogrulamaKoduGonder(_eposta);

            if (yeniKod == null)
            {
                MessageBox.Show("Doğrulama maili tekrar gönderilirken hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _gonderilenKod = yeniKod; 
                MessageBox.Show("Yeni doğrulama kodunuz e-posta adresinize gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDogrula_Click(object sender, EventArgs e)
        {
            string girilenKod = txtKod.Text.Trim();

            if (string.IsNullOrEmpty(girilenKod) || girilenKod.Length != 6)
            {
                MessageBox.Show("Lütfen 6 haneli doğrulama kodunu eksiksiz girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (girilenKod == _gonderilenKod)
            {
                bool kayitBasarili = _kullaniciKontrolcusu.KullaniciyiKaydet(_adSoyad, _kullaniciAdi, _eposta, _sifre);

                if (kayitBasarili)
                {
                    MessageBox.Show("E-posta adresiniz başarıyla doğrulandı ve kaydınız tamamlandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GirisFormu giris = new GirisFormu();
                    this.Hide();
                    giris.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kayıt sırasında veritabanı hatası oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Girdiğiniz doğrulama kodu hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTekrarGonder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KodGonderTetikle();
        }
    }
}