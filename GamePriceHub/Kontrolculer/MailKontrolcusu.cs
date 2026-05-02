using System;
using System.Net;
using System.Net.Mail;

namespace GamePriceHub.Kontrolculer
{
    public class MailKontrolcusu
    {

        private readonly string _gonderenEmail = "GMAIL_BURAYA_GELECEK";
        private readonly string _uygulamaSifresi = "GMAIL_SIFRESI_BURAYA_GELECEK";

        // --- MEVCUT SİSTEM (KAYIT DOĞRULAMA - DOKUNULMADI) ---
        public string DogrulamaKoduGonder(string aliciEposta)
        {

            Random rnd = new Random();
            string dogrulamaKodu = rnd.Next(100000, 999999).ToString();

            try
            {
                MailMessage mesaj = new MailMessage();
                mesaj.From = new MailAddress(_gonderenEmail, "GamePriceHub");
                mesaj.To.Add(aliciEposta);
                mesaj.Subject = "Kayıt Doğrulama Kodu (OTP)";
                mesaj.Body = $"GamePriceHub sistemine kayıt işleminizi tamamlamak için doğrulama kodunuz:\n\n{dogrulamaKodu}\n\nBu kodu kimseyle paylaşmayınız.";

                SmtpClient istemci = new SmtpClient("smtp.gmail.com", 587);
                istemci.Credentials = new NetworkCredential(_gonderenEmail, _uygulamaSifresi);
                istemci.EnableSsl = true;

                istemci.Send(mesaj);
                return dogrulamaKodu;
            }
            catch (Exception)
            {

                return null;
            }
        }

        // --- YENİ EKLENEN SİSTEM (DESTEK TALEBİ MAİLİ) ---
        public bool DestekMailiGonder(string gonderenAd, string gonderenEmail, string konu, string mesaj)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                mail.From = new MailAddress(_gonderenEmail, "GamePriceHub Destek Sistemi");
                mail.To.Add(_gonderenEmail); // Mailin alıcısı da sistemin kendisi
                mail.Subject = "YENİ DESTEK TALEBİ: " + konu;

                // Admin için okunması kolay HTML formatında e-posta şablonu
                mail.Body = $@"
                <h3>Yeni Bir Destek Talebi Alındı</h3>
                <p><b>Gönderen:</b> {gonderenAd}</p>
                <p><b>E-Posta:</b> {gonderenEmail}</p>
                <p><b>Konu:</b> {konu}</p>
                <hr>
                <p><b>Mesaj:</b><br>{mesaj}</p>
                <hr>
                <p><small>Bu mail GamePriceHub Sistemi tarafından otomatik oluşturulmuştur.</small></p>";

                mail.IsBodyHtml = true;

                smtp.Credentials = new NetworkCredential(_gonderenEmail, _uygulamaSifresi);
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Destek Maili Hatası: " + ex.Message);
                return false;
            }
        }

        // --- YENİ: ADMİN YANIT MAİLİ ---
        public bool AdminYanitMailiGonder(string aliciEposta, string yanitMesaji)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                mail.From = new MailAddress(_gonderenEmail, "GamePriceHub Destek Ekibi");
                mail.To.Add(aliciEposta);
                mail.Subject = "Destek Talebinize Yanıt (GamePriceHub)";

                mail.Body = $@"
                <div style='font-family: Arial, sans-serif; color: #333;'>
                    <h3 style='color: #0078D7;'>GamePriceHub Destek Ekibi</h3>
                    <p>Merhaba,</p>
                    <p>Destek talebiniz incelenmiş ve ekibimiz tarafından aşağıdaki yanıt verilmiştir:</p>
                    <div style='background-color: #f4f4f4; padding: 15px; border-left: 4px solid #0078D7; margin: 20px 0;'>
                        <p style='margin: 0;'>{yanitMesaji.Replace("\n", "<br>")}</p>
                    </div>
                    <p><small>Bizi tercih ettiğiniz için teşekkür ederiz.</small></p>
                </div>";

                mail.IsBodyHtml = true;
                smtp.Credentials = new NetworkCredential(_gonderenEmail, _uygulamaSifresi);
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Admin Mail Hatası: " + ex.Message);
                return false;
            }
        }
    }
}