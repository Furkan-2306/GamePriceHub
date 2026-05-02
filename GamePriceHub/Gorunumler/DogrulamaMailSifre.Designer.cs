namespace GamePriceHub.Gorunumler
{
    partial class DogrulamaMailSifre
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.txtEskiSifre = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDogrulamaKodu = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnDogrula = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.Cyan;
            this.lblBaslik.Location = new System.Drawing.Point(30, 25);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(243, 30);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Güvenlik Doğrulaması";
            // 
            // lblAciklama
            // 
            this.lblAciklama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAciklama.ForeColor = System.Drawing.Color.LightGray;
            this.lblAciklama.Location = new System.Drawing.Point(34, 65);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(320, 45);
            this.lblAciklama.TabIndex = 1;
            this.lblAciklama.Text = "Mevcut e-posta adresinize bir kod gönderdik. Lütfen mevcut şifrenizle birlikte aşağıya girin.";
            // 
            // txtEskiSifre
            // 
            this.txtEskiSifre.BorderColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.txtEskiSifre.BorderRadius = 8;
            this.txtEskiSifre.CustomizableEdges = customizableEdges1;
            this.txtEskiSifre.FillColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.txtEskiSifre.ForeColor = System.Drawing.Color.White;
            this.txtEskiSifre.Location = new System.Drawing.Point(34, 120);
            this.txtEskiSifre.Name = "txtEskiSifre";
            this.txtEskiSifre.PlaceholderText = "Mevcut (Eski) Şifreniz";
            this.txtEskiSifre.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.txtEskiSifre.Size = new System.Drawing.Size(320, 40);
            this.txtEskiSifre.TabIndex = 2;
            this.txtEskiSifre.UseSystemPasswordChar = true;
            // 
            // txtDogrulamaKodu
            // 
            this.txtDogrulamaKodu.BorderColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.txtDogrulamaKodu.BorderRadius = 8;
            this.txtDogrulamaKodu.CustomizableEdges = customizableEdges3;
            this.txtDogrulamaKodu.FillColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.txtDogrulamaKodu.ForeColor = System.Drawing.Color.White;
            this.txtDogrulamaKodu.Location = new System.Drawing.Point(34, 175);
            this.txtDogrulamaKodu.Name = "txtDogrulamaKodu";
            this.txtDogrulamaKodu.PlaceholderText = "E-Postaya Gelen 6 Haneli Kod";
            this.txtDogrulamaKodu.ShadowDecoration.CustomizableEdges = customizableEdges4;
            this.txtDogrulamaKodu.Size = new System.Drawing.Size(320, 40);
            this.txtDogrulamaKodu.TabIndex = 3;
            // 
            // btnDogrula
            // 
            this.btnDogrula.BackColor = System.Drawing.Color.Cyan;
            this.btnDogrula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDogrula.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDogrula.ForeColor = System.Drawing.Color.Black;
            this.btnDogrula.Location = new System.Drawing.Point(204, 235);
            this.btnDogrula.Name = "btnDogrula";
            this.btnDogrula.Size = new System.Drawing.Size(150, 40);
            this.btnDogrula.TabIndex = 4;
            this.btnDogrula.Text = "Doğrula";
            this.btnDogrula.UseVisualStyleBackColor = false;
            this.btnDogrula.Click += new System.EventHandler(this.btnDogrula_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(34, 235);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(150, 40);
            this.btnIptal.TabIndex = 5;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // DogrulamaMailSifre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(20, 20, 30);
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnDogrula);
            this.Controls.Add(this.txtDogrulamaKodu);
            this.Controls.Add(this.txtEskiSifre);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.lblBaslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DogrulamaMailSifre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Güvenlik Onayı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblAciklama;
        private Guna.UI2.WinForms.Guna2TextBox txtEskiSifre;
        private Guna.UI2.WinForms.Guna2TextBox txtDogrulamaKodu;
        private System.Windows.Forms.Button btnDogrula;
        private System.Windows.Forms.Button btnIptal;
    }
}