using System;

namespace dddepo
{
    partial class LoginForm
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
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnGiris = new System.Windows.Forms.Button();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.lblSifre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtKullaniciAdi.Location = new System.Drawing.Point(100, 90);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(300, 34);
            this.txtKullaniciAdi.TabIndex = 0;
            this.txtKullaniciAdi.Text = "Kullanıcı Adı";
            this.txtKullaniciAdi.Enter += new System.EventHandler(this.txtKullaniciAdi_Enter);
            this.txtKullaniciAdi.Leave += new System.EventHandler(this.txtKullaniciAdi_Leave);
            // 
            // txtSifre
            // 
            this.txtSifre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSifre.Location = new System.Drawing.Point(101, 160);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(300, 34);
            this.txtSifre.TabIndex = 1;
            this.txtSifre.Text = "Şifre";
            this.txtSifre.Enter += new System.EventHandler(this.txtSifre_Enter);
            this.txtSifre.Leave += new System.EventHandler(this.txtSifre_Leave);
            // 
            // btnGiris
            // 
            this.btnGiris.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGiris.Location = new System.Drawing.Point(100, 214);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(300, 40);
            this.btnGiris.TabIndex = 2;
            this.btnGiris.Text = "Giriş Yap";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKullaniciAdi.Location = new System.Drawing.Point(96, 63);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(124, 28);
            this.lblKullaniciAdi.TabIndex = 3;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSifre.Location = new System.Drawing.Point(96, 129);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(55, 28);
            this.lblSifre.TabIndex = 4;
            this.lblSifre.Text = "Şifre:";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnGiris;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullaniciAdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Depo Otomasyon Sistemi - Giriş";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.Label lblSifre;

        private void txtKullaniciAdi_Enter(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "Kullanıcı Adı")
            {
                txtKullaniciAdi.Text = "";
                txtKullaniciAdi.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtKullaniciAdi_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
            {
                txtKullaniciAdi.Text = "Kullanıcı Adı";
                txtKullaniciAdi.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Şifre")
            {
                txtSifre.Text = "";
                txtSifre.ForeColor = System.Drawing.Color.Black;
                txtSifre.UseSystemPasswordChar = true;
            }
        }

        private void txtSifre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                txtSifre.Text = "Şifre";
                txtSifre.ForeColor = System.Drawing.Color.Gray;
                txtSifre.UseSystemPasswordChar = false;
            }
        }
    }
}
