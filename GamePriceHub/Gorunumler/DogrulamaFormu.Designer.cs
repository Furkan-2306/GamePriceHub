namespace GamePriceHub.Gorunumler
{
    partial class DogrulamaFormu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlKutu = new Guna.UI2.WinForms.Guna2Panel();
            lblEpostaBilgi = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lblTekrarGonder = new LinkLabel();
            btnDogrula = new Guna.UI2.WinForms.Guna2Button();
            txtKod = new Guna.UI2.WinForms.Guna2TextBox();
            pnlKutu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlKutu
            // 
            pnlKutu.BackColor = Color.Transparent;
            pnlKutu.BorderRadius = 20;
            pnlKutu.Controls.Add(lblEpostaBilgi);
            pnlKutu.Controls.Add(label1);
            pnlKutu.Controls.Add(pictureBox1);
            pnlKutu.Controls.Add(lblTekrarGonder);
            pnlKutu.Controls.Add(btnDogrula);
            pnlKutu.Controls.Add(txtKod);
            pnlKutu.CustomizableEdges = customizableEdges5;
            pnlKutu.FillColor = Color.FromArgb(180, 25, 25, 35);
            pnlKutu.Location = new Point(326, 90);
            pnlKutu.Name = "pnlKutu";
            pnlKutu.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlKutu.Size = new Size(350, 380);
            pnlKutu.TabIndex = 0;
            // 
            // lblEpostaBilgi
            // 
            lblEpostaBilgi.AutoSize = true;
            lblEpostaBilgi.ForeColor = Color.LightGray;
            lblEpostaBilgi.Location = new Point(50, 170);
            lblEpostaBilgi.Name = "lblEpostaBilgi";
            lblEpostaBilgi.Size = new Size(250, 15);
            lblEpostaBilgi.TabIndex = 9;
            lblEpostaBilgi.Text = "Kod şu adrese gönderildi: address@email.com";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(84, 113);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(191, 42);
            label1.TabIndex = 8;
            label1.Text = "E-postanıza gönderilen \r\n6 haneli kodu girin.\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo3;
            pictureBox1.Location = new Point(37, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(280, 95);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // lblTekrarGonder
            // 
            lblTekrarGonder.ActiveLinkColor = Color.Cyan;
            lblTekrarGonder.AutoSize = true;
            lblTekrarGonder.LinkColor = Color.LightGray;
            lblTekrarGonder.Location = new Point(134, 329);
            lblTekrarGonder.Name = "lblTekrarGonder";
            lblTekrarGonder.Size = new Size(81, 15);
            lblTekrarGonder.TabIndex = 6;
            lblTekrarGonder.TabStop = true;
            lblTekrarGonder.Text = "Tekrar Gönder";
            lblTekrarGonder.LinkClicked += lblTekrarGonder_LinkClicked;
            // 
            // btnDogrula
            // 
            btnDogrula.BorderColor = Color.LimeGreen;
            btnDogrula.BorderRadius = 8;
            btnDogrula.BorderThickness = 2;
            btnDogrula.CustomizableEdges = customizableEdges1;
            btnDogrula.FillColor = Color.Transparent;
            btnDogrula.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDogrula.ForeColor = Color.LimeGreen;
            btnDogrula.Location = new Point(50, 265);
            btnDogrula.Name = "btnDogrula";
            btnDogrula.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnDogrula.Size = new Size(250, 45);
            btnDogrula.TabIndex = 5;
            btnDogrula.Text = "Doğrula";
            btnDogrula.Click += btnDogrula_Click;
            // 
            // txtKod
            // 
            txtKod.BorderColor = Color.FromArgb(45, 45, 65);
            txtKod.BorderRadius = 8;
            txtKod.CustomizableEdges = customizableEdges3;
            txtKod.DefaultText = "";
            txtKod.FillColor = Color.FromArgb(30, 30, 45);
            txtKod.FocusedState.BorderColor = Color.LimeGreen;
            txtKod.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            txtKod.ForeColor = Color.White;
            txtKod.Location = new Point(75, 200);
            txtKod.MaxLength = 6;
            txtKod.Name = "txtKod";
            txtKod.PlaceholderText = "000000";
            txtKod.SelectedText = "";
            txtKod.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtKod.Size = new Size(200, 45);
            txtKod.TabIndex = 1;
            txtKod.TextAlign = HorizontalAlignment.Center;
            // 
            // DogrulamaFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 20);
            ClientSize = new Size(984, 561);
            Controls.Add(pnlKutu);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "DogrulamaFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GamePriceHub - Doğrulama";
            pnlKutu.ResumeLayout(false);
            pnlKutu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlKutu;
        private Guna.UI2.WinForms.Guna2TextBox txtKod;
        private Guna.UI2.WinForms.Guna2Button btnDogrula;
        private System.Windows.Forms.LinkLabel lblTekrarGonder;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEpostaBilgi;
    }
}