using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GamePriceHub.Kontrolculer;
using GamePriceHub.Modeller;

namespace GamePriceHub.Gorunumler
{
    public partial class AdminPanel : Form
    {
        private string _aktifKullaniciAdi;
        private KullaniciKontrolcusu _kullaniciKontrolcu;
        private List<Kullanici> _kullanicilar;

        // Hafızada tutulacak seçili kullanıcı bilgileri (Yanıt atabilmek için)
        private string _seciliKullaniciEposta = "";
        private string _seciliKullaniciAd = "";

        public AdminPanel(string kullaniciAdi)
        {
            InitializeComponent();
            _aktifKullaniciAdi = kullaniciAdi;
            _kullaniciKontrolcu = new KullaniciKontrolcusu();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        private void VerileriYukle()
        {
            dgvTickets.Rows.Clear();
            _kullanicilar = _kullaniciKontrolcu.TumKullanicilariGetir();

            if (_kullanicilar == null) return;

            int banliSayisi = 0;
            int normalKullaniciSayisi = 0;

            foreach (var k in _kullanicilar)
            {
                if (k.RolID == 1) continue;

                string durum = k.IsBanned ? "⛔ Banlı" : "✅ Aktif";
                string islemText = k.IsBanned ? "Engeli Kaldır" : "Banla";

                if (k.IsBanned) banliSayisi++;
                normalKullaniciSayisi++;

                int rowIndex = dgvTickets.Rows.Add(k.ID, k.KullaniciAdi, k.Eposta, durum, islemText);

                DataGridViewButtonCell btnCell = (DataGridViewButtonCell)dgvTickets.Rows[rowIndex].Cells["btnIslem"];
                btnCell.Style.BackColor = k.IsBanned ? Color.LimeGreen : Color.Crimson;
                btnCell.Style.ForeColor = Color.White;
            }

            lblTotalUsersValue.Text = normalKullaniciSayisi.ToString();
            lblActiveTicketsValue.Text = banliSayisi.ToString();
        }

        // --- TABLO İÇİ TIKLAMALAR ---
        private void dgvTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int kullaniciId = Convert.ToInt32(dgvTickets.Rows[e.RowIndex].Cells["colID"].Value);
            string kullaniciAdi = dgvTickets.Rows[e.RowIndex].Cells["colKullaniciAdi"].Value.ToString();
            string eposta = dgvTickets.Rows[e.RowIndex].Cells["colEposta"].Value.ToString();

            // 1. İŞLEM (Banla) BUTONUNA TIKLANDIYSA
            if (e.ColumnIndex == dgvTickets.Columns["btnIslem"].Index)
            {
                string mevcutDurum = dgvTickets.Rows[e.RowIndex].Cells["colDurum"].Value.ToString();
                bool islemBasarili = false;

                if (mevcutDurum.Contains("Banlı"))
                {
                    DialogResult onay = MessageBox.Show($"{kullaniciAdi} kullanıcısının engelini kaldırmak istiyor musunuz?", "Engeli Kaldır", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (onay == DialogResult.Yes) islemBasarili = _kullaniciKontrolcu.KullaniciEngelKaldir(kullaniciId);
                }
                else
                {
                    DialogResult onay = MessageBox.Show($"{kullaniciAdi} kullanıcısını banlamak istiyor musunuz?", "Banla", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (onay == DialogResult.Yes) islemBasarili = _kullaniciKontrolcu.KullaniciyiBanla(kullaniciId);
                }

                if (islemBasarili) VerileriYukle();
            }
            // 2. KULLANICI SATIRINA TIKLANDIYSA (Mesajları Getir)
            else
            {
                // Bilgileri hafızaya al (Mail gönderirken lazım olacak)
                _seciliKullaniciEposta = eposta;
                _seciliKullaniciAd = kullaniciAdi;

                DestekTalepleriniYukle(kullaniciId, kullaniciAdi);

                // Cevap kutusunu temizleyip hazırla
                txtMailBody.Clear();
                txtMailBody.PlaceholderText = $"@{kullaniciAdi} kullanıcısına iletilecek yanıtı buraya yazın...";
            }
        }

        // --- DESTEK TALEPLERİNİ OKUMA (ÜST KUTUYA YAZDIRIR) ---
        private void DestekTalepleriniYukle(int kullaniciId, string kullaniciAdi)
        {
            DestekKontrolcusu dk = new DestekKontrolcusu();
            var talepler = dk.KullaniciTalepleriniGetir(kullaniciId);

            txtTicketHistory.Clear();

            if (talepler == null || talepler.Count == 0)
            {
                txtTicketHistory.Text = $"=== @{kullaniciAdi} ===\r\nBu kullanıcının henüz bir destek talebi bulunmuyor.";
                return;
            }

            txtTicketHistory.AppendText($"=== @{kullaniciAdi} DESTEK GEÇMİŞİ ({talepler.Count}) ===\r\n\r\n");

            foreach (var talep in talepler)
            {
                txtTicketHistory.AppendText($"------------------------------------\r\n");
                txtTicketHistory.AppendText($"Tarih: {talep.Tarih}\r\n");
                txtTicketHistory.AppendText($"Konu: {talep.Konu.ToUpper()}\r\n");
                txtTicketHistory.AppendText($"Mesaj:\r\n{talep.Mesaj}\r\n\r\n");
            }

            txtTicketHistory.SelectionStart = 0;
            txtTicketHistory.ScrollToCaret();
        }

        // --- ADMİN YANIT GÖNDERME ---
        private void btnSendMail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_seciliKullaniciEposta))
            {
                MessageBox.Show("Lütfen önce listeden yanıt vermek istediğiniz bir kullanıcıyı seçin.", "Kullanıcı Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMailBody.Text))
            {
                MessageBox.Show("Lütfen gönderilecek yanıt metnini boş bırakmayın.", "Boş Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MailKontrolcusu mk = new MailKontrolcusu();
            bool basarili = mk.AdminYanitMailiGonder(_seciliKullaniciEposta, txtMailBody.Text.Trim());

            if (basarili)
            {
                MessageBox.Show($"{_seciliKullaniciAd} adlı kullanıcıya yanıtınız mail olarak başarıyla iletildi.", "Yanıt Gönderildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMailBody.Clear();
            }
            else
            {
                MessageBox.Show("Yanıt e-postası gönderilirken bir hata oluştu. Lütfen bağlantınızı kontrol edin.", "Gönderim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- NAVİGASYON ---
        private void picGeri_Click(object sender, EventArgs e)
        {
            AnaMenu anaMenu = new AnaMenu(_aktifKullaniciAdi);
            this.Hide();
            anaMenu.ShowDialog();
            this.Close();
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            ProfilFormu profil = new ProfilFormu(_aktifKullaniciAdi);
            this.Hide();
            profil.ShowDialog();
            this.Close();
        }

        private void btnKutuphane_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kütüphane bölümü yapım aşamasındadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            VerileriYukle();
        }
    }
}