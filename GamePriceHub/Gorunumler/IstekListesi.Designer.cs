namespace GamePriceHub.Gorunumler
{
    partial class IstekListesi
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
            this.pnlUst = new System.Windows.Forms.Panel();
            this.txtArama = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblSupport = new System.Windows.Forms.Label();
            this.lblAI = new System.Windows.Forms.Label();
            this.lblAnaMenu = new System.Windows.Forms.Label();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.picSupport = new System.Windows.Forms.PictureBox();
            this.picAI = new System.Windows.Forms.PictureBox();
            this.picAnaMenu = new System.Windows.Forms.PictureBox();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.picGeri = new System.Windows.Forms.PictureBox();
            this.flpOyunlar = new System.Windows.Forms.FlowLayoutPanel();
            this._oneriListesi = new System.Windows.Forms.ListBox();
            this.pnlUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSupport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnaMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGeri)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUst
            // 
            this.pnlUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.pnlUst.Controls.Add(this.txtArama);
            this.pnlUst.Controls.Add(this.lblUser);
            this.pnlUst.Controls.Add(this.lblSupport);
            this.pnlUst.Controls.Add(this.lblAI);
            this.pnlUst.Controls.Add(this.lblAnaMenu);
            this.pnlUst.Controls.Add(this.picUser);
            this.pnlUst.Controls.Add(this.picSupport);
            this.pnlUst.Controls.Add(this.picAI);
            this.pnlUst.Controls.Add(this.picAnaMenu);
            this.pnlUst.Controls.Add(this.lblBaslik);
            this.pnlUst.Controls.Add(this.picGeri);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(1280, 80);
            this.pnlUst.TabIndex = 0;
            // 
            // txtArama
            // 
            this.txtArama.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.txtArama.BorderRadius = 8;
            this.txtArama.CustomizableEdges = customizableEdges1;
            this.txtArama.DefaultText = "";
            this.txtArama.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.txtArama.FocusedState.BorderColor = System.Drawing.Color.Cyan;
            this.txtArama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtArama.ForeColor = System.Drawing.Color.White;
            this.txtArama.Location = new System.Drawing.Point(320, 20);
            this.txtArama.Name = "txtArama";
            this.txtArama.PlaceholderText = "Tüm oyunlarda canlı arama yapın...";
            this.txtArama.SelectedText = "";
            this.txtArama.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.txtArama.Size = new System.Drawing.Size(350, 40);
            this.txtArama.TabIndex = 10;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUser.ForeColor = System.Drawing.Color.Cyan;
            this.lblUser.Location = new System.Drawing.Point(1185, 50);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(45, 15);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "Misafir";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSupport
            // 
            this.lblSupport.AutoSize = true;
            this.lblSupport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSupport.ForeColor = System.Drawing.Color.LightGray;
            this.lblSupport.Location = new System.Drawing.Point(1105, 50);
            this.lblSupport.Name = "lblSupport";
            this.lblSupport.Size = new System.Drawing.Size(42, 15);
            this.lblSupport.TabIndex = 7;
            this.lblSupport.Text = "Destek";
            this.lblSupport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAI
            // 
            this.lblAI.AutoSize = true;
            this.lblAI.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAI.ForeColor = System.Drawing.Color.LightGray;
            this.lblAI.Location = new System.Drawing.Point(1020, 50);
            this.lblAI.Name = "lblAI";
            this.lblAI.Size = new System.Drawing.Size(66, 15);
            this.lblAI.TabIndex = 6;
            this.lblAI.Text = "Yapay Zeka";
            this.lblAI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnaMenu
            // 
            this.lblAnaMenu.AutoSize = true;
            this.lblAnaMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAnaMenu.ForeColor = System.Drawing.Color.LightGray;
            this.lblAnaMenu.Location = new System.Drawing.Point(935, 50);
            this.lblAnaMenu.Name = "lblAnaMenu";
            this.lblAnaMenu.Size = new System.Drawing.Size(62, 15);
            this.lblAnaMenu.TabIndex = 5;
            this.lblAnaMenu.Text = "Ana Menü";
            this.lblAnaMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picUser
            // 
            this.picUser.BackColor = System.Drawing.Color.Transparent;
            this.picUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUser.Image = global::GamePriceHub.Properties.Resources.icon_user;
            this.picUser.Location = new System.Drawing.Point(1190, 15);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(30, 30);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUser.TabIndex = 4;
            this.picUser.TabStop = false;
            this.picUser.Click += new System.EventHandler(this.picUser_Click);
            // 
            // picSupport
            // 
            this.picSupport.BackColor = System.Drawing.Color.Transparent;
            this.picSupport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSupport.Image = global::GamePriceHub.Properties.Resources.icon_support;
            this.picSupport.Location = new System.Drawing.Point(1110, 15);
            this.picSupport.Name = "picSupport";
            this.picSupport.Size = new System.Drawing.Size(30, 30);
            this.picSupport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSupport.TabIndex = 3;
            this.picSupport.TabStop = false;
            this.picSupport.Click += new System.EventHandler(this.picSupport_Click);
            // 
            // picAI
            // 
            this.picAI.BackColor = System.Drawing.Color.Transparent;
            this.picAI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAI.Image = global::GamePriceHub.Properties.Resources.icon_search;
            this.picAI.Location = new System.Drawing.Point(1035, 15);
            this.picAI.Name = "picAI";
            this.picAI.Size = new System.Drawing.Size(30, 30);
            this.picAI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAI.TabIndex = 2;
            this.picAI.TabStop = false;
            this.picAI.Click += new System.EventHandler(this.picAI_Click);
            // 
            // picAnaMenu
            // 
            this.picAnaMenu.BackColor = System.Drawing.Color.Transparent;
            this.picAnaMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAnaMenu.Image = global::GamePriceHub.Properties.Resources.home2;
            this.picAnaMenu.Location = new System.Drawing.Point(950, 15);
            this.picAnaMenu.Name = "picAnaMenu";
            this.picAnaMenu.Size = new System.Drawing.Size(30, 30);
            this.picAnaMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnaMenu.TabIndex = 1;
            this.picAnaMenu.TabStop = false;
            this.picAnaMenu.Click += new System.EventHandler(this.picAnaMenu_Click);
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.Cyan;
            this.lblBaslik.Location = new System.Drawing.Point(70, 25);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(137, 30);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "İstek Listem";
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
            // flpOyunlar
            // 
            this.flpOyunlar.AutoScroll = true;
            this.flpOyunlar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.flpOyunlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOyunlar.Location = new System.Drawing.Point(0, 80);
            this.flpOyunlar.Name = "flpOyunlar";
            this.flpOyunlar.Padding = new System.Windows.Forms.Padding(20);
            this.flpOyunlar.Size = new System.Drawing.Size(1280, 640);
            this.flpOyunlar.TabIndex = 1;
            // 
            // _oneriListesi
            // 
            this._oneriListesi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this._oneriListesi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._oneriListesi.Cursor = System.Windows.Forms.Cursors.Hand;
            this._oneriListesi.Font = new System.Drawing.Font("Segoe UI", 11F);
            this._oneriListesi.ForeColor = System.Drawing.Color.White;
            this._oneriListesi.IntegralHeight = false;
            this._oneriListesi.Location = new System.Drawing.Point(320, 60);
            this._oneriListesi.Name = "_oneriListesi";
            this._oneriListesi.Size = new System.Drawing.Size(350, 0);
            this._oneriListesi.TabIndex = 11;
            this._oneriListesi.Visible = false;
            this._oneriListesi.SelectedIndexChanged += new System.EventHandler(this.OneriSecildi);
            // 
            // IstekListesi
            // 
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this._oneriListesi);
            this.Controls.Add(this.flpOyunlar);
            this.Controls.Add(this.pnlUst);
            this.Name = "IstekListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GamePriceHub - İstek Listesi";
            this.pnlUst.ResumeLayout(false);
            this.pnlUst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSupport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnaMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGeri)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.FlowLayoutPanel flpOyunlar;
        private System.Windows.Forms.PictureBox picGeri;
        private System.Windows.Forms.Label lblBaslik;
        private Guna.UI2.WinForms.Guna2TextBox txtArama;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblSupport;
        private System.Windows.Forms.Label lblAI;
        private System.Windows.Forms.Label lblAnaMenu;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.PictureBox picSupport;
        private System.Windows.Forms.PictureBox picAI;
        private System.Windows.Forms.PictureBox picAnaMenu;
        private System.Windows.Forms.ListBox _oneriListesi;
    }
}