namespace dddepo
{
    partial class SiparislerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbMagaza = new System.Windows.Forms.ComboBox();
            this.cmbUrun = new System.Windows.Forms.ComboBox();
            this.txtAdet = new System.Windows.Forms.TextBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.btnSiparisEkle = new System.Windows.Forms.Button();
            this.dgvSiparisler = new System.Windows.Forms.DataGridView();
            this.btnSiparisSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisler)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMagaza
            // 
            this.cmbMagaza.FormattingEnabled = true;
            this.cmbMagaza.Location = new System.Drawing.Point(75, 235);
            this.cmbMagaza.Name = "cmbMagaza";
            this.cmbMagaza.Size = new System.Drawing.Size(121, 24);
            this.cmbMagaza.TabIndex = 0;
            // 
            // cmbUrun
            // 
            this.cmbUrun.FormattingEnabled = true;
            this.cmbUrun.Location = new System.Drawing.Point(247, 235);
            this.cmbUrun.Name = "cmbUrun";
            this.cmbUrun.Size = new System.Drawing.Size(121, 24);
            this.cmbUrun.TabIndex = 1;
            // 
            // txtAdet
            // 
            this.txtAdet.Location = new System.Drawing.Point(409, 235);
            this.txtAdet.Name = "txtAdet";
            this.txtAdet.Size = new System.Drawing.Size(123, 22);
            this.txtAdet.TabIndex = 2;
            // 
            // dtpTarih
            // 
            this.dtpTarih.Location = new System.Drawing.Point(599, 230);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(109, 22);
            this.dtpTarih.TabIndex = 3;
            // 
            // btnSiparisEkle
            // 
            this.btnSiparisEkle.Location = new System.Drawing.Point(75, 333);
            this.btnSiparisEkle.Name = "btnSiparisEkle";
            this.btnSiparisEkle.Size = new System.Drawing.Size(147, 82);
            this.btnSiparisEkle.TabIndex = 4;
            this.btnSiparisEkle.Text = "Ürün Ekle ";
            this.btnSiparisEkle.UseVisualStyleBackColor = true;
            this.btnSiparisEkle.Click += new System.EventHandler(this.btnSiparisEkle_Click);
            // 
            // dgvSiparisler
            // 
            this.dgvSiparisler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSiparisler.Location = new System.Drawing.Point(12, 12);
            this.dgvSiparisler.Name = "dgvSiparisler";
            this.dgvSiparisler.RowHeadersWidth = 51;
            this.dgvSiparisler.RowTemplate.Height = 24;
            this.dgvSiparisler.Size = new System.Drawing.Size(776, 176);
            this.dgvSiparisler.TabIndex = 5;
            // 
            // btnSiparisSil
            // 
            this.btnSiparisSil.Location = new System.Drawing.Point(280, 333);
            this.btnSiparisSil.Name = "btnSiparisSil";
            this.btnSiparisSil.Size = new System.Drawing.Size(150, 82);
            this.btnSiparisSil.TabIndex = 6;
            this.btnSiparisSil.Text = "Ürün Sil";
            this.btnSiparisSil.UseVisualStyleBackColor = true;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(501, 333);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(150, 82);
            this.btnGuncelle.TabIndex = 7;
            this.btnGuncelle.Text = "Ürün Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "şube";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "ürün";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "adet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(596, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "sipariş tarihi";
            // 
            // SiparislerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSiparisSil);
            this.Controls.Add(this.dgvSiparisler);
            this.Controls.Add(this.btnSiparisEkle);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.txtAdet);
            this.Controls.Add(this.cmbUrun);
            this.Controls.Add(this.cmbMagaza);
            this.Name = "SiparislerForm";
            this.Text = "SiparislerForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMagaza;
        private System.Windows.Forms.ComboBox cmbUrun;
        private System.Windows.Forms.TextBox txtAdet;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Button btnSiparisEkle;
        private System.Windows.Forms.DataGridView dgvSiparisler;
        private System.Windows.Forms.Button btnSiparisSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}