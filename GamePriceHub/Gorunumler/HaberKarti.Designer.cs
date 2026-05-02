namespace GamePriceHub.Gorunumler
{
    partial class HaberKarti
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.pnlArkaPlan = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTarih = new System.Windows.Forms.Label();
            this.lblOzet = new System.Windows.Forms.Label();
            this.lblKategori = new System.Windows.Forms.Label();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.picKapak = new System.Windows.Forms.PictureBox();
            this.pnlArkaPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKapak)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlArkaPlan
            // 
            this.pnlArkaPlan.BackColor = System.Drawing.Color.Transparent;
            this.pnlArkaPlan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.pnlArkaPlan.BorderRadius = 12;
            this.pnlArkaPlan.BorderThickness = 1;
            this.pnlArkaPlan.Controls.Add(this.lblTarih);
            this.pnlArkaPlan.Controls.Add(this.lblOzet);
            this.pnlArkaPlan.Controls.Add(this.lblKategori);
            this.pnlArkaPlan.Controls.Add(this.lblBaslik);
            this.pnlArkaPlan.Controls.Add(this.picKapak);
            this.pnlArkaPlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlArkaPlan.CustomizableEdges = customizableEdges1;
            this.pnlArkaPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlArkaPlan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.pnlArkaPlan.Location = new System.Drawing.Point(0, 0);
            this.pnlArkaPlan.Name = "pnlArkaPlan";
            this.pnlArkaPlan.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.pnlArkaPlan.Size = new System.Drawing.Size(290, 160); // GENİŞLİK 290'A DÜŞÜRÜLDÜ (4 KART SIĞMASI İÇİN)
            this.pnlArkaPlan.TabIndex = 0;
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblTarih.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTarih.Location = new System.Drawing.Point(110, 135);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(61, 13);
            this.lblTarih.TabIndex = 4;
            this.lblTarih.Text = "01.01.2024";
            // 
            // lblOzet
            // 
            this.lblOzet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOzet.ForeColor = System.Drawing.Color.LightGray;
            this.lblOzet.Location = new System.Drawing.Point(110, 65);
            this.lblOzet.Name = "lblOzet";
            this.lblOzet.Size = new System.Drawing.Size(170, 65); // GENİŞLİĞE GÖRE DARALTILDI
            this.lblOzet.TabIndex = 3;
            this.lblOzet.Text = "Bu alana haberin 1-2 satırlık kısa bir özeti gelecek...";
            // 
            // lblKategori
            // 
            this.lblKategori.AutoSize = true;
            this.lblKategori.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblKategori.ForeColor = System.Drawing.Color.Cyan;
            this.lblKategori.Location = new System.Drawing.Point(110, 10);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new System.Drawing.Size(61, 13);
            this.lblKategori.TabIndex = 2;
            this.lblKategori.Text = "KATEGORİ";
            // 
            // lblBaslik
            // 
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(110, 25);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(170, 40); // GENİŞLİĞE GÖRE DARALTILDI
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "Haberin Uzun ve Dikkat Çekici Başlığı Buraya";
            // 
            // picKapak
            // 
            this.picKapak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.picKapak.Location = new System.Drawing.Point(0, 0);
            this.picKapak.Name = "picKapak";
            this.picKapak.Size = new System.Drawing.Size(100, 160); // RESİM GENİŞLİĞİ DARALTILDI
            this.picKapak.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picKapak.TabIndex = 0;
            this.picKapak.TabStop = false;
            // 
            // HaberKarti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlArkaPlan);
            this.Name = "HaberKarti";
            this.Size = new System.Drawing.Size(290, 160); // YENİ BOYUT
            this.pnlArkaPlan.ResumeLayout(false);
            this.pnlArkaPlan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKapak)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlArkaPlan;
        private System.Windows.Forms.PictureBox picKapak;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.Label lblOzet;
        private System.Windows.Forms.Label lblTarih;
    }
}