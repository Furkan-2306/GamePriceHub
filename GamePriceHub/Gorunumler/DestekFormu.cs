using System;
using System.Windows.Forms;
using GamePriceHub.Kontrolculer;
using GamePriceHub.Modeller;

namespace GamePriceHub.Gorunumler
{
    public partial class DestekFormu : Form
    {
        private string _kullaniciAdi;

        public DestekFormu(string kullaniciAdi)
        {
            InitializeComponent();
            _kullaniciAdi = kullaniciAdi;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (_kullaniciAdi == "Misafir")
            {
                MessageBox.Show("Destek talebi oluşturmak için lütfen üye girişi yapın.", "Giriş Gerekli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtKonu.Text) || string.IsNullOrWhiteSpace(txtMesaj.Text))
            {
                MessageBox.Show("Lütfen konu ve mesaj alanlarını boş bırakmayın.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Kullanıcının Bilgilerini Bul (AdSoyad ve E-Posta lazım)
            KullaniciKontrolcusu kk = new KullaniciKontrolcusu();
            Kullanici aktifKullanici = kk.KullaniciBilgileriniGetir(_kullaniciAdi);

            if (aktifKullanici != null)
            {
                // 2. Talebi Veritabanına Kaydet (Admin panelinden okunabilmesi için)
                DestekKontrolcusu dk = new DestekKontrolcusu();
                bool dbBasarili = dk.TalepOlustur(aktifKullanici.ID, txtKonu.Text.Trim(), txtMesaj.Text.Trim());

                // 3. E-Posta Olarak Gönder (Sisteme mail düşmesi için)
                MailKontrolcusu mk = new MailKontrolcusu();
                bool mailBasarili = mk.DestekMailiGonder(
                    aktifKullanici.AdSoyad,
                    aktifKullanici.Eposta,
                    txtKonu.Text.Trim(),
                    txtMesaj.Text.Trim()
                );

                // 4. Sonuçları Kullanıcıya Bildir
                if (dbBasarili && mailBasarili)
                {
                    MessageBox.Show("Talebiniz hem sisteme kaydedildi hem de bize mail olarak iletildi.\nEn kısa sürede dönüş yapılacaktır.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (dbBasarili)
                {
                    MessageBox.Show("Talebiniz sisteme kaydedildi ancak e-posta gönderilirken bir iletişim hatası oluştu. Yöneticilerimiz panel üzerinden talebinizi görecektir.", "Kısmi Başarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Talebiniz kaydedilirken bir sorun oluştu. Lütfen bağlantınızı kontrol edip tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}