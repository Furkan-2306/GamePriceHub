namespace GamePriceHub.Gorunumler
{
    partial class HaberDetayFormu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlUst = new Panel();
            lblSayfaBasligi = new Label();
            picGeri = new PictureBox();
            pnlIcerik = new Panel();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            pnlUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGeri).BeginInit();
            pnlIcerik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // pnlUst
            // 
            pnlUst.BackColor = Color.FromArgb(20, 20, 30);
            pnlUst.Controls.Add(lblSayfaBasligi);
            pnlUst.Controls.Add(picGeri);
            pnlUst.Dock = DockStyle.Top;
            pnlUst.Location = new Point(0, 0);
            pnlUst.Name = "pnlUst";
            pnlUst.Size = new Size(1280, 80);
            pnlUst.TabIndex = 1;
            // 
            // lblSayfaBasligi
            // 
            lblSayfaBasligi.AutoSize = true;
            lblSayfaBasligi.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSayfaBasligi.ForeColor = Color.Cyan;
            lblSayfaBasligi.Location = new Point(70, 25);
            lblSayfaBasligi.Name = "lblSayfaBasligi";
            lblSayfaBasligi.Size = new Size(150, 30);
            lblSayfaBasligi.TabIndex = 1;
            lblSayfaBasligi.Text = "Haber Detayı";
            // 
            // picGeri
            // 
            picGeri.BackColor = Color.Transparent;
            picGeri.Cursor = Cursors.Hand;
            picGeri.Image = Properties.Resources.back;
            picGeri.Location = new Point(20, 25);
            picGeri.Name = "picGeri";
            picGeri.Size = new Size(30, 30);
            picGeri.SizeMode = PictureBoxSizeMode.Zoom;
            picGeri.TabIndex = 0;
            picGeri.TabStop = false;
            picGeri.Click += picGeri_Click;
            // 
            // pnlIcerik
            // 
            pnlIcerik.AutoScroll = true;
            pnlIcerik.Controls.Add(webView21);
            pnlIcerik.Dock = DockStyle.Fill;
            pnlIcerik.Location = new Point(0, 80);
            pnlIcerik.Name = "pnlIcerik";
            pnlIcerik.Padding = new Padding(50);
            pnlIcerik.Size = new Size(1280, 640);
            pnlIcerik.TabIndex = 2;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(0, 0);
            webView21.Name = "webView21";
            webView21.Size = new Size(1280, 640);
            webView21.TabIndex = 4;
            webView21.ZoomFactor = 1D;
            // 
            // HaberDetayFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 20);
            ClientSize = new Size(1280, 720);
            Controls.Add(pnlIcerik);
            Controls.Add(pnlUst);
            Name = "HaberDetayFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GamePriceHub - Haber Detayı";
            pnlUst.ResumeLayout(false);
            pnlUst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picGeri).EndInit();
            pnlIcerik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.Label lblSayfaBasligi;
        private System.Windows.Forms.PictureBox picGeri;
        private System.Windows.Forms.Panel pnlIcerik;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}