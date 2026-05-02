namespace GamePriceHub.Gorunumler
{
    partial class OyunDetayFormu
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
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.btnKapat = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblBilgiBaslik = new System.Windows.Forms.Label();
            this.pnlLine1 = new System.Windows.Forms.Panel();
            this.lblAd = new System.Windows.Forms.Label();
            this.lblDevTitle = new System.Windows.Forms.Label();
            this.lblDevData = new System.Windows.Forms.Label();
            this.lblDateTitle = new System.Windows.Forms.Label();
            this.lblDateData = new System.Windows.Forms.Label();
            this.pnlScores = new System.Windows.Forms.Panel();
            this.pnlMeta = new System.Windows.Forms.Panel();
            this.lblMetaPuan = new System.Windows.Forms.Label();
            this.lblMetaTitle = new System.Windows.Forms.Label();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.lblUserPuan = new System.Windows.Forms.Label();
            this.lblUserTitle = new System.Windows.Forms.Label();
            this.pnlPrice = new System.Windows.Forms.Panel();
            this.lblFiyatBaslik = new System.Windows.Forms.Label();
            this.pnlLine2 = new System.Windows.Forms.Panel();
            this.flpFiyatlar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlReview = new System.Windows.Forms.Panel();
            this.lblYorumlarBaslik = new System.Windows.Forms.Label();
            this.pnlLine3 = new System.Windows.Forms.Panel();
            this.flpYorumlar = new System.Windows.Forms.FlowLayoutPanel();

            // --- YENİ YORUM YAPMA ALANI ---
            this.pnlYorumYaz = new System.Windows.Forms.Panel();
            this.txtYeniYorum = new System.Windows.Forms.TextBox();
            this.cmbPuanDurumu = new System.Windows.Forms.ComboBox();
            this.btnYorumGonder = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.pbBanner.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlScores.SuspendLayout();
            this.pnlMeta.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.pnlPrice.SuspendLayout();
            this.pnlReview.SuspendLayout();
            this.pnlYorumYaz.SuspendLayout();
            this.SuspendLayout();

            // ... (pbBanner, pnlInfo, pnlPrice ayarları aynı)
            this.pbBanner.BackColor = System.Drawing.Color.Black;
            this.pbBanner.Controls.Add(this.btnKapat);
            this.pbBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbBanner.Location = new System.Drawing.Point(0, 0);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(1280, 280);
            this.pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Location = new System.Drawing.Point(1235, 10);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(40, 40);
            this.btnKapat.Text = "X";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);

            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(41)))));
            this.pnlInfo.Controls.Add(this.lblBilgiBaslik);
            this.pnlInfo.Controls.Add(this.pnlLine1);
            this.pnlInfo.Controls.Add(this.lblAd);
            this.pnlInfo.Controls.Add(this.lblDevTitle);
            this.pnlInfo.Controls.Add(this.lblDevData);
            this.pnlInfo.Controls.Add(this.lblDateTitle);
            this.pnlInfo.Controls.Add(this.lblDateData);
            this.pnlInfo.Controls.Add(this.pnlScores);
            this.pnlInfo.Location = new System.Drawing.Point(40, 300);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(360, 380);

            this.lblBilgiBaslik.AutoSize = true;
            this.lblBilgiBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBilgiBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(141)))), ((int)(((byte)(152)))));
            this.lblBilgiBaslik.Location = new System.Drawing.Point(20, 20);
            this.lblBilgiBaslik.Name = "lblBilgiBaslik";
            this.lblBilgiBaslik.Text = "GAME INFORMATION";

            this.pnlLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.pnlLine1.Location = new System.Drawing.Point(20, 45);
            this.pnlLine1.Size = new System.Drawing.Size(320, 2);

            this.lblAd.AutoSize = true;
            this.lblAd.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAd.ForeColor = System.Drawing.Color.White;
            this.lblAd.Location = new System.Drawing.Point(20, 65);
            this.lblAd.MaximumSize = new System.Drawing.Size(320, 0);

            this.lblDevTitle.AutoSize = true;
            this.lblDevTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDevTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(141)))), ((int)(((byte)(152)))));
            this.lblDevTitle.Location = new System.Drawing.Point(20, 130);
            this.lblDevTitle.Text = "Developer:";

            this.lblDevData.AutoSize = true;
            this.lblDevData.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDevData.ForeColor = System.Drawing.Color.White;
            this.lblDevData.Location = new System.Drawing.Point(120, 130);

            this.lblDateTitle.AutoSize = true;
            this.lblDateTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDateTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(141)))), ((int)(((byte)(152)))));
            this.lblDateTitle.Location = new System.Drawing.Point(20, 160);
            this.lblDateTitle.Text = "Release Date:";

            this.lblDateData.AutoSize = true;
            this.lblDateData.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateData.ForeColor = System.Drawing.Color.White;
            this.lblDateData.Location = new System.Drawing.Point(120, 160);

            this.pnlScores.BackColor = System.Drawing.Color.Transparent;
            this.pnlScores.Controls.Add(this.pnlMeta);
            this.pnlScores.Controls.Add(this.lblMetaTitle);
            this.pnlScores.Controls.Add(this.pnlUser);
            this.pnlScores.Controls.Add(this.lblUserTitle);
            this.pnlScores.Location = new System.Drawing.Point(20, 240);
            this.pnlScores.Size = new System.Drawing.Size(320, 110);

            this.pnlMeta.Controls.Add(this.lblMetaPuan);
            this.pnlMeta.Location = new System.Drawing.Point(30, 0);
            this.pnlMeta.Size = new System.Drawing.Size(80, 80);
            this.pnlMeta.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMeta_Paint);

            this.lblMetaPuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaPuan.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblMetaPuan.ForeColor = System.Drawing.Color.White;
            this.lblMetaPuan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblMetaTitle.AutoSize = true;
            this.lblMetaTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMetaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(141)))), ((int)(((byte)(152)))));
            this.lblMetaTitle.Location = new System.Drawing.Point(35, 90);
            this.lblMetaTitle.Text = "Metacritic";

            this.pnlUser.Controls.Add(this.lblUserPuan);
            this.pnlUser.Location = new System.Drawing.Point(190, 0);
            this.pnlUser.Size = new System.Drawing.Size(80, 80);
            this.pnlUser.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlUser_Paint);

            this.lblUserPuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserPuan.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblUserPuan.ForeColor = System.Drawing.Color.White;
            this.lblUserPuan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblUserTitle.AutoSize = true;
            this.lblUserTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(141)))), ((int)(((byte)(152)))));
            this.lblUserTitle.Location = new System.Drawing.Point(190, 90);
            this.lblUserTitle.Text = "User Rating";

            this.pnlPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(41)))));
            this.pnlPrice.Controls.Add(this.lblFiyatBaslik);
            this.pnlPrice.Controls.Add(this.pnlLine2);
            this.pnlPrice.Controls.Add(this.flpFiyatlar);
            this.pnlPrice.Location = new System.Drawing.Point(440, 300);
            this.pnlPrice.Size = new System.Drawing.Size(380, 380);

            this.lblFiyatBaslik.AutoSize = true;
            this.lblFiyatBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFiyatBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(141)))), ((int)(((byte)(152)))));
            this.lblFiyatBaslik.Location = new System.Drawing.Point(20, 20);
            this.lblFiyatBaslik.Text = "PRICE COMPARISON";

            this.pnlLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.pnlLine2.Location = new System.Drawing.Point(20, 45);
            this.pnlLine2.Size = new System.Drawing.Size(340, 2);

            this.flpFiyatlar.AutoScroll = true;
            this.flpFiyatlar.BackColor = System.Drawing.Color.Transparent;
            this.flpFiyatlar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpFiyatlar.Location = new System.Drawing.Point(20, 65);
            this.flpFiyatlar.Size = new System.Drawing.Size(340, 300);
            this.flpFiyatlar.WrapContents = false;

            // ================= REVIEWS PANELİ VE YORUM YAPMA ALANI =================
            this.pnlReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(41)))));
            this.pnlReview.Controls.Add(this.lblYorumlarBaslik);
            this.pnlReview.Controls.Add(this.pnlLine3);
            this.pnlReview.Controls.Add(this.flpYorumlar);
            this.pnlReview.Controls.Add(this.pnlYorumYaz); // Yorum ekleme panelini Review'in içine ekle
            this.pnlReview.Location = new System.Drawing.Point(860, 300);
            this.pnlReview.Size = new System.Drawing.Size(380, 380);

            this.lblYorumlarBaslik.AutoSize = true;
            this.lblYorumlarBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblYorumlarBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(141)))), ((int)(((byte)(152)))));
            this.lblYorumlarBaslik.Location = new System.Drawing.Point(20, 20);
            this.lblYorumlarBaslik.Text = "USER REVIEWS";

            this.pnlLine3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.pnlLine3.Location = new System.Drawing.Point(20, 45);
            this.pnlLine3.Size = new System.Drawing.Size(340, 2);

            // Kaydırma alanını biraz küçültüyoruz ki aşağıya yorum kutusu sığsın
            this.flpYorumlar.AutoScroll = true;
            this.flpYorumlar.BackColor = System.Drawing.Color.Transparent;
            this.flpYorumlar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpYorumlar.Location = new System.Drawing.Point(10, 55);
            this.flpYorumlar.Size = new System.Drawing.Size(360, 230);
            this.flpYorumlar.WrapContents = false;

            // --- YORUM YAPMA ALANI TASARIMI ---
            this.pnlYorumYaz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(35)))));
            this.pnlYorumYaz.Controls.Add(this.txtYeniYorum);
            this.pnlYorumYaz.Controls.Add(this.cmbPuanDurumu);
            this.pnlYorumYaz.Controls.Add(this.btnYorumGonder);
            this.pnlYorumYaz.Location = new System.Drawing.Point(10, 290);
            this.pnlYorumYaz.Size = new System.Drawing.Size(360, 80);

            this.txtYeniYorum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.txtYeniYorum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYeniYorum.ForeColor = System.Drawing.Color.White;
            this.txtYeniYorum.Location = new System.Drawing.Point(10, 10);
            this.txtYeniYorum.Multiline = true;
            this.txtYeniYorum.Size = new System.Drawing.Size(240, 60);
            this.txtYeniYorum.Font = new System.Drawing.Font("Segoe UI", 9F);
            // Hint metni gibi durması için
            this.txtYeniYorum.Text = "Yorumunuzu buraya yazın...";

            this.cmbPuanDurumu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.cmbPuanDurumu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuanDurumu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPuanDurumu.ForeColor = System.Drawing.Color.White;
            this.cmbPuanDurumu.FormattingEnabled = true;
            this.cmbPuanDurumu.Items.AddRange(new object[] { "👍 Olumlu", "😐 Nötr", "👎 Olumsuz" });
            this.cmbPuanDurumu.Location = new System.Drawing.Point(260, 10);
            this.cmbPuanDurumu.Size = new System.Drawing.Size(90, 23);

            this.btnYorumGonder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnYorumGonder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYorumGonder.FlatAppearance.BorderSize = 0;
            this.btnYorumGonder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYorumGonder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnYorumGonder.ForeColor = System.Drawing.Color.White;
            this.btnYorumGonder.Location = new System.Drawing.Point(260, 40);
            this.btnYorumGonder.Size = new System.Drawing.Size(90, 30);
            this.btnYorumGonder.Text = "Gönder";
            this.btnYorumGonder.UseVisualStyleBackColor = false;
            this.btnYorumGonder.Click += new System.EventHandler(this.btnYorumGonder_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(20)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlReview);
            this.Controls.Add(this.pnlPrice);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pbBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OyunDetayFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Details";
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.pbBanner.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlScores.ResumeLayout(false);
            this.pnlScores.PerformLayout();
            this.pnlMeta.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.pnlPrice.ResumeLayout(false);
            this.pnlPrice.PerformLayout();
            this.pnlReview.ResumeLayout(false);
            this.pnlReview.PerformLayout();
            this.pnlYorumYaz.ResumeLayout(false);
            this.pnlYorumYaz.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.Button btnKapat;

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblBilgiBaslik;
        private System.Windows.Forms.Panel pnlLine1;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label lblDevTitle;
        private System.Windows.Forms.Label lblDevData;
        private System.Windows.Forms.Label lblDateTitle;
        private System.Windows.Forms.Label lblDateData;
        private System.Windows.Forms.Panel pnlScores;
        private System.Windows.Forms.Panel pnlMeta;
        private System.Windows.Forms.Label lblMetaPuan;
        private System.Windows.Forms.Label lblMetaTitle;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label lblUserPuan;
        private System.Windows.Forms.Label lblUserTitle;

        private System.Windows.Forms.Panel pnlPrice;
        private System.Windows.Forms.Label lblFiyatBaslik;
        private System.Windows.Forms.Panel pnlLine2;
        private System.Windows.Forms.FlowLayoutPanel flpFiyatlar;

        private System.Windows.Forms.Panel pnlReview;
        private System.Windows.Forms.Label lblYorumlarBaslik;
        private System.Windows.Forms.Panel pnlLine3;
        private System.Windows.Forms.FlowLayoutPanel flpYorumlar;

        // YENİ YORUM YAPMA EKLENTİLERİ
        private System.Windows.Forms.Panel pnlYorumYaz;
        private System.Windows.Forms.TextBox txtYeniYorum;
        private System.Windows.Forms.ComboBox cmbPuanDurumu;
        private System.Windows.Forms.Button btnYorumGonder;
    }
}