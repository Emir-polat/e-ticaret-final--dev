namespace dddepo
{
    partial class MainForm
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
            this.btnUrunler = new System.Windows.Forms.Button();
            this.btnSiparisler = new System.Windows.Forms.Button();
            this.btnDepoDoluluk = new System.Windows.Forms.Button();
            this.btnKullaniciYonetim = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUrunler
            // 
            this.btnUrunler.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUrunler.Location = new System.Drawing.Point(100, 100);
            this.btnUrunler.Name = "btnUrunler";
            this.btnUrunler.Size = new System.Drawing.Size(200, 50);
            this.btnUrunler.TabIndex = 0;
            this.btnUrunler.Text = "Ürünler";
            this.btnUrunler.UseVisualStyleBackColor = true;
            this.btnUrunler.Click += new System.EventHandler(this.btnUrunler_Click);
            // 
            // btnSiparisler
            // 
            this.btnSiparisler.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSiparisler.Location = new System.Drawing.Point(100, 160);
            this.btnSiparisler.Name = "btnSiparisler";
            this.btnSiparisler.Size = new System.Drawing.Size(200, 50);
            this.btnSiparisler.TabIndex = 1;
            this.btnSiparisler.Text = "Siparişler";
            this.btnSiparisler.UseVisualStyleBackColor = true;
            this.btnSiparisler.Click += new System.EventHandler(this.btnSiparisler_Click);
            // 
            // btnDepoDoluluk
            // 
            this.btnDepoDoluluk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDepoDoluluk.Location = new System.Drawing.Point(100, 220);
            this.btnDepoDoluluk.Name = "btnDepoDoluluk";
            this.btnDepoDoluluk.Size = new System.Drawing.Size(200, 50);
            this.btnDepoDoluluk.TabIndex = 2;
            this.btnDepoDoluluk.Text = "Depo Doluluk";
            this.btnDepoDoluluk.UseVisualStyleBackColor = true;
            this.btnDepoDoluluk.Click += new System.EventHandler(this.btnDepoDoluluk_Click);
            // 
            // btnKullaniciYonetim
            // 
            this.btnKullaniciYonetim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnKullaniciYonetim.Location = new System.Drawing.Point(100, 280);
            this.btnKullaniciYonetim.Name = "btnKullaniciYonetim";
            this.btnKullaniciYonetim.Size = new System.Drawing.Size(200, 50);
            this.btnKullaniciYonetim.TabIndex = 3;
            this.btnKullaniciYonetim.Text = "Kullanıcı Yönetimi";
            this.btnKullaniciYonetim.UseVisualStyleBackColor = true;
            this.btnKullaniciYonetim.Click += new System.EventHandler(this.btnKullaniciYonetim_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCikis.Location = new System.Drawing.Point(100, 340);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(200, 50);
            this.btnCikis.TabIndex = 4;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(95, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 30);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Depo Otomasyon";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnKullaniciYonetim);
            this.Controls.Add(this.btnDepoDoluluk);
            this.Controls.Add(this.btnSiparisler);
            this.Controls.Add(this.btnUrunler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Menü";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnUrunler;
        private System.Windows.Forms.Button btnSiparisler;
        private System.Windows.Forms.Button btnDepoDoluluk;
        private System.Windows.Forms.Button btnKullaniciYonetim;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Label lblTitle;
    }
}
