namespace dddepo
{
    partial class KullaniciYonetimForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label lblAdi;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.GroupBox groupBoxKullanici;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.lblAdi = new System.Windows.Forms.Label();
            this.lblSifre = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.groupBoxKullanici = new System.Windows.Forms.GroupBox();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxKullanici.SuspendLayout();
            this.SuspendLayout();

            // === groupBoxKullanici ===
            this.groupBoxKullanici.Controls.Add(this.lblAdi);
            this.groupBoxKullanici.Controls.Add(this.lblSifre);
            this.groupBoxKullanici.Controls.Add(this.lblRol);
            this.groupBoxKullanici.Controls.Add(this.txtKullaniciAdi);
            this.groupBoxKullanici.Controls.Add(this.txtSifre);
            this.groupBoxKullanici.Controls.Add(this.cmbRol);
            this.groupBoxKullanici.Controls.Add(this.btnEkle);
            this.groupBoxKullanici.Controls.Add(this.btnGuncelle);
            this.groupBoxKullanici.Controls.Add(this.btnSil);
            this.groupBoxKullanici.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxKullanici.Location = new System.Drawing.Point(20, 20);
            this.groupBoxKullanici.Name = "groupBoxKullanici";
            this.groupBoxKullanici.Size = new System.Drawing.Size(460, 170);
            this.groupBoxKullanici.TabIndex = 0;
            this.groupBoxKullanici.TabStop = false;
            this.groupBoxKullanici.Text = "Kullanıcı Bilgileri";

            // === lblAdi ===
            this.lblAdi.AutoSize = true;
            this.lblAdi.Location = new System.Drawing.Point(20, 30);
            this.lblAdi.Name = "lblAdi";
            this.lblAdi.Size = new System.Drawing.Size(93, 19);
            this.lblAdi.Text = "Kullanıcı Adı:";

            // === txtKullaniciAdi ===
            this.txtKullaniciAdi.Location = new System.Drawing.Point(120, 27);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(200, 25);

            // === lblSifre ===
            this.lblSifre.AutoSize = true;
            this.lblSifre.Location = new System.Drawing.Point(20, 65);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(39, 19);
            this.lblSifre.Text = "Şifre:";

            // === txtSifre ===
            this.txtSifre.Location = new System.Drawing.Point(120, 62);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(200, 25);
            this.txtSifre.PasswordChar = '*';

            // === lblRol ===
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(20, 100);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(32, 19);
            this.lblRol.Text = "Rol:";

            // === cmbRol ===
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Items.AddRange(new object[] { "Admin", "Personel" });
            this.cmbRol.Location = new System.Drawing.Point(120, 97);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(200, 25);

            // === btnEkle ===
            this.btnEkle.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.ForeColor = System.Drawing.Color.White;
            this.btnEkle.Location = new System.Drawing.Point(340, 27);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(100, 30);
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);

            // === btnGuncelle ===
            this.btnGuncelle.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Location = new System.Drawing.Point(340, 65);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(100, 30);
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            // === btnSil ===
            this.btnSil.BackColor = System.Drawing.Color.IndianRed;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(340, 103);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 30);
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            // === dataGridView1 ===
            this.dataGridView1.Location = new System.Drawing.Point(20, 200);
            this.dataGridView1.Size = new System.Drawing.Size(460, 230);
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);

            // === KullaniciYonetimForm ===
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.groupBoxKullanici);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "KullaniciYonetimForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Yönetimi";
            this.Load += new System.EventHandler(this.KullaniciYonetimForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxKullanici.ResumeLayout(false);
            this.groupBoxKullanici.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
