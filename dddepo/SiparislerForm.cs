using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dddepo
{
    public partial class SiparislerForm : Form
    {
        private SqlConnection baglanti = new SqlConnection(@"Server=.;Database=dddepo;Trusted_Connection=True;");

        public SiparislerForm()
        {
            InitializeComponent();

            // Event atamaları
            this.Load += SiparislerForm_Load;
            btnSiparisEkle.Click += btnSiparisEkle_Click;
            btnSiparisSil.Click += btnSiparisSil_Click;
            btnGuncelle.Click += btnGuncelle_Click;
            dgvSiparisler.SelectionChanged += dgvSiparisler_SelectionChanged;
        }

        private void SiparislerForm_Load(object sender, EventArgs e)
        {
            MagazalariYukle();
            UrunleriYukle();
            SiparisleriListele();
        }

        private void MagazalariYukle()
        {
            var dt = new DataTable();
            using (var da = new SqlDataAdapter("SELECT MagazaID, MagazaAdi FROM Magazalar", baglanti))
            {
                da.Fill(dt);
            }
            cmbMagaza.DataSource = dt;
            cmbMagaza.DisplayMember = "MagazaAdi";
            cmbMagaza.ValueMember = "MagazaID";
            cmbMagaza.SelectedIndex = -1;
        }

        private void UrunleriYukle()
        {
            var dt = new DataTable();
            using (var da = new SqlDataAdapter("SELECT UrunID, UrunAdi FROM Urunler", baglanti))
            {
                da.Fill(dt);
            }
            cmbUrun.DataSource = dt;
            cmbUrun.DisplayMember = "UrunAdi";
            cmbUrun.ValueMember = "UrunID";
            cmbUrun.SelectedIndex = -1;
        }

        private void SiparisleriListele()
        {
            var sql = @"
                SELECT 
                    sd.SiparisDetayID,
                    s.SiparisID,
                    m.MagazaID,
                    m.MagazaAdi,
                    u.UrunID,
                    u.UrunAdi,
                    sd.Adet,
                    sd.BirimFiyat,
                    s.SiparisTarihi
                FROM SiparisDetaylari sd
                INNER JOIN Siparisler s ON sd.SiparisID = s.SiparisID
                INNER JOIN Magazalar m ON s.MagazaID = m.MagazaID
                INNER JOIN Urunler u ON sd.UrunID = u.UrunID
                ORDER BY s.SiparisTarihi DESC";

            var dt = new DataTable();
            using (var da = new SqlDataAdapter(sql, baglanti))
            {
                da.Fill(dt);
            }
            dgvSiparisler.DataSource = dt;

            // Gizlemek istersen:
            dgvSiparisler.Columns["SiparisID"].Visible = false;
            dgvSiparisler.Columns["SiparisDetayID"].Visible = false;
            dgvSiparisler.Columns["MagazaID"].Visible = false;
            dgvSiparisler.Columns["UrunID"].Visible = false;

            dgvSiparisler.Columns["MagazaAdi"].HeaderText = "Mağaza";
            dgvSiparisler.Columns["UrunAdi"].HeaderText = "Ürün";
            dgvSiparisler.Columns["Adet"].HeaderText = "Adet";
            dgvSiparisler.Columns["BirimFiyat"].HeaderText = "Birim Fiyat";
            dgvSiparisler.Columns["SiparisTarihi"].HeaderText = "Tarih";
        }

        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            if (cmbMagaza.SelectedIndex < 0 || cmbUrun.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtAdet.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (!int.TryParse(txtAdet.Text, out int adet) || adet <= 0)
            {
                MessageBox.Show("Adet pozitif bir tam sayı olmalı.");
                return;
            }

            try
            {
                baglanti.Open();

                // 1) Yeni Siparis
                var cmdSip = new SqlCommand(
                    "INSERT INTO Siparisler (MagazaID, SiparisTarihi) OUTPUT INSERTED.SiparisID VALUES (@mid, @t)",
                    baglanti);
                cmdSip.Parameters.AddWithValue("@mid", cmbMagaza.SelectedValue);
                cmdSip.Parameters.AddWithValue("@t", dtpTarih.Value);
                int siparisID = (int)cmdSip.ExecuteScalar();

                // 2) Birim fiyat al
                var cmdF = new SqlCommand("SELECT Fiyat FROM Urunler WHERE UrunID = @uid", baglanti);
                cmdF.Parameters.AddWithValue("@uid", cmbUrun.SelectedValue);
                decimal birimFiyat = (decimal)cmdF.ExecuteScalar();

                // 3) Detay ekle
                var cmdDet = new SqlCommand(
                    "INSERT INTO SiparisDetaylari (SiparisID, UrunID, Adet, BirimFiyat) VALUES (@sid,@uid,@a,@bf)",
                    baglanti);
                cmdDet.Parameters.AddWithValue("@sid", siparisID);
                cmdDet.Parameters.AddWithValue("@uid", cmbUrun.SelectedValue);
                cmdDet.Parameters.AddWithValue("@a", adet);
                cmdDet.Parameters.AddWithValue("@bf", birimFiyat);
                cmdDet.ExecuteNonQuery();

                // 4) Stok güncelle
                var cmdSt = new SqlCommand(
                    "UPDATE Urunler SET Stok = Stok - @a WHERE UrunID = @uid",
                    baglanti);
                cmdSt.Parameters.AddWithValue("@a", adet);
                cmdSt.Parameters.AddWithValue("@uid", cmbUrun.SelectedValue);
                cmdSt.ExecuteNonQuery();

                MessageBox.Show("Sipariş eklendi.");
                txtAdet.Clear();
                SiparisleriListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnSiparisSil_Click(object sender, EventArgs e)
        {
            if (dgvSiparisler.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silinecek siparişi seçin.");
                return;
            }

            int detayID = (int)dgvSiparisler.CurrentRow.Cells["SiparisDetayID"].Value;
            int urunID = (int)dgvSiparisler.CurrentRow.Cells["UrunID"].Value;
            int adet = (int)dgvSiparisler.CurrentRow.Cells["Adet"].Value;

            if (MessageBox.Show("Bu siparişi silmek istediğinize emin misiniz?",
                    "Onay", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                baglanti.Open();

                // Stok iade
                var cmdSt = new SqlCommand(
                    "UPDATE Urunler SET Stok = Stok + @a WHERE UrunID = @uid",
                    baglanti);
                cmdSt.Parameters.AddWithValue("@a", adet);
                cmdSt.Parameters.AddWithValue("@uid", urunID);
                cmdSt.ExecuteNonQuery();

                // Detay sil
                var cmdDel = new SqlCommand(
                    "DELETE FROM SiparisDetaylari WHERE SiparisDetayID = @did",
                    baglanti);
                cmdDel.Parameters.AddWithValue("@did", detayID);
                cmdDel.ExecuteNonQuery();

                MessageBox.Show("Sipariş silindi.");
                SiparisleriListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvSiparisler.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellenecek siparişi seçin.");
                return;
            }

            // Eski veriler
            int detayID = (int)dgvSiparisler.CurrentRow.Cells["SiparisDetayID"].Value;
            int eskiUrun = (int)dgvSiparisler.CurrentRow.Cells["UrunID"].Value;
            int eskiAdet = (int)dgvSiparisler.CurrentRow.Cells["Adet"].Value;
            int eskiMagaza = (int)dgvSiparisler.CurrentRow.Cells["MagazaID"].Value;

            // Yeni
            if (!int.TryParse(txtAdet.Text, out int yeniAdet) || yeniAdet <= 0)
            {
                MessageBox.Show("Geçerli bir adet girin.");
                return;
            }
            int yeniUrun = (int)cmbUrun.SelectedValue;
            int yeniMagaza = (int)cmbMagaza.SelectedValue;

            try
            {
                baglanti.Open();

                // Yeni birim fiyat
                var cmdF = new SqlCommand("SELECT Fiyat FROM Urunler WHERE UrunID = @uid", baglanti);
                cmdF.Parameters.AddWithValue("@uid", yeniUrun);
                decimal yeniBF = (decimal)cmdF.ExecuteScalar();

                // Detayı güncelle
                var cmdUpd = new SqlCommand(
                    "UPDATE SiparisDetaylari SET UrunID=@u, Adet=@a, BirimFiyat=@bf WHERE SiparisDetayID=@did",
                    baglanti);
                cmdUpd.Parameters.AddWithValue("@u", yeniUrun);
                cmdUpd.Parameters.AddWithValue("@a", yeniAdet);
                cmdUpd.Parameters.AddWithValue("@bf", yeniBF);
                cmdUpd.Parameters.AddWithValue("@did", detayID);
                cmdUpd.ExecuteNonQuery();

                // Stok farkı
                // iade eski adetten
                var cmdIade = new SqlCommand(
                    "UPDATE Urunler SET Stok = Stok + @a WHERE UrunID = @uid",
                    baglanti);
                cmdIade.Parameters.AddWithValue("@a", eskiAdet);
                cmdIade.Parameters.AddWithValue("@uid", eskiUrun);
                cmdIade.ExecuteNonQuery();

                // yeni adeti düş
                var cmdDus = new SqlCommand(
                    "UPDATE Urunler SET Stok = Stok - @a WHERE UrunID = @uid",
                    baglanti);
                cmdDus.Parameters.AddWithValue("@a", yeniAdet);
                cmdDus.Parameters.AddWithValue("@uid", yeniUrun);
                cmdDus.ExecuteNonQuery();

                // Mağaza değiştiyse
                if (eskiMagaza != yeniMagaza)
                {
                    var cmdM = new SqlCommand(
                        "UPDATE Siparisler SET MagazaID = @mid WHERE SiparisID = (" +
                        "SELECT SiparisID FROM SiparisDetaylari WHERE SiparisDetayID = @did)",
                        baglanti);
                    cmdM.Parameters.AddWithValue("@mid", yeniMagaza);
                    cmdM.Parameters.AddWithValue("@did", detayID);
                    cmdM.ExecuteNonQuery();
                }

                MessageBox.Show("Sipariş güncellendi.");
                SiparisleriListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void dgvSiparisler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSiparisler.CurrentRow == null) return;

            // Seçimi forma yansıt
            cmbMagaza.SelectedValue = dgvSiparisler.CurrentRow.Cells["MagazaID"].Value;
            cmbUrun.SelectedValue = dgvSiparisler.CurrentRow.Cells["UrunID"].Value;
            txtAdet.Text = dgvSiparisler.CurrentRow.Cells["Adet"].Value.ToString();
            dtpTarih.Value = Convert.ToDateTime(dgvSiparisler.CurrentRow.Cells["SiparisTarihi"].Value);
        }
    }
}
