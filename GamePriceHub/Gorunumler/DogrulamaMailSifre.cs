using System;
using System.Windows.Forms;

namespace GamePriceHub.Gorunumler
{
    public partial class DogrulamaMailSifre : Form
    {
        private string _gercekEskiSifre;
        private string _gonderilenKod;

        public DogrulamaMailSifre(string gercekEskiSifre, string gonderilenKod)
        {
            InitializeComponent();
            _gercekEskiSifre = gercekEskiSifre;
            _gonderilenKod = gonderilenKod;
        }

        private void btnDogrula_Click(object sender, EventArgs e)
        {
            if (txtEskiSifre.Text.Trim() != _gercekEskiSifre)
            {
                MessageBox.Show("Eski şifrenizi yanlış girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtDogrulamaKodu.Text.Trim() != _gonderilenKod)
            {
                MessageBox.Show("Doğrulama kodu hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}