namespace GamePriceHub.Gorunumler
{
    partial class HaberlerFormu
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.pnlUst = new System.Windows.Forms.Panel();
            this.txtHaberAra = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.picGeri = new System.Windows.Forms.PictureBox();
            this.flpHaberler = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGeri)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUst
            // 
            this.pnlUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.pnlUst.Controls.Add(this.txtHaberAra);
            this.pnlUst.Controls.Add(this.lblBaslik);
            this.pnlUst.Controls.Add(this.picGeri);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(1280, 80);
            this.pnlUst.TabIndex = 0;
            // 
            // txtHaberAra
            // 
            this.txtHaberAra.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.txtHaberAra.BorderRadius = 8;
            this.txtHaberAra.CustomizableEdges = customizableEdges1;
            this.txtHaberAra.DefaultText = "";
            this.txtHaberAra.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.txtHaberAra.FocusedState.BorderColor = System.Drawing.Color.Cyan;
            this.txtHaberAra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHaberAra.ForeColor = System.Drawing.Color.White;
            this.txtHaberAra.Location = new System.Drawing.Point(440, 20);
            this.txtHaberAra.Name = "txtHaberAra";
            this.txtHaberAra.PlaceholderText = "Haberlerde veya rehberlerde ara...";
            this.txtHaberAra.SelectedText = "";
            this.txtHaberAra.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.txtHaberAra.Size = new System.Drawing.Size(400, 40);
            this.txtHaberAra.TabIndex = 2;
            this.txtHaberAra.TextChanged += new System.EventHandler(this.txtHaberAra_TextChanged);
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.Cyan;
            this.lblBaslik.Location = new System.Drawing.Point(70, 25);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(217, 30);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "Haberler & Rehberler";
            // 
            // picGeri
            // 
            this.picGeri.BackColor = System.Drawing.Color.Transparent;
            this.picGeri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picGeri.Image = global::GamePriceHub.Properties.Resources.back;
            this.picGeri.Location = new System.Drawing.Point(20, 25);
            this.picGeri.Name = "picGeri";
            this.picGeri.Size = new System.Drawing.Size(30, 30);
            this.picGeri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGeri.TabIndex = 0;
            this.picGeri.TabStop = false;
            this.picGeri.Click += new System.EventHandler(this.picGeri_Click);
            // 
            // flpHaberler
            // 
            this.flpHaberler.AutoScroll = true;
            this.flpHaberler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.flpHaberler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpHaberler.Location = new System.Drawing.Point(0, 80);
            this.flpHaberler.Name = "flpHaberler";
            this.flpHaberler.Padding = new System.Windows.Forms.Padding(30);
            this.flpHaberler.Size = new System.Drawing.Size(1280, 640);
            this.flpHaberler.TabIndex = 1;
            // 
            // HaberlerFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.flpHaberler);
            this.Controls.Add(this.pnlUst);
            this.Name = "HaberlerFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GamePriceHub - Haberler";
            this.Load += new System.EventHandler(this.HaberlerFormu_Load);
            this.pnlUst.ResumeLayout(false);
            this.pnlUst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGeri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.PictureBox picGeri;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.FlowLayoutPanel flpHaberler;
        private Guna.UI2.WinForms.Guna2TextBox txtHaberAra;
    }
}