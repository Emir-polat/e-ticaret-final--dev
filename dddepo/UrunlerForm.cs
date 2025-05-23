using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dddepo
{
    public partial class UrunlerForm : Form
    {
        public UrunlerForm()
        {
            InitializeComponent();
        }

        private void OpenConnection()
        {
            if (Baglanti.conn.State == ConnectionState.Closed)
                Baglanti.conn.Open();
        }

        private void CloseConnection()
        {
            if (Baglanti.conn.State == ConnectionState.Open)
                Baglanti.conn.Close();
        }

        private void UrunleriListele()
        {
            try
            {
                OpenConnection();
                string query = @"SELECT u.UrunID, u.UrunAdi, u.Stok, u.Fiyat, d.DepoAdi, u.DepoID 
                                 FROM Urunler u 
                                 LEFT JOIN Depolar d ON u.DepoID = d.DepoID";
                SqlDataAdapter da = new SqlDataAdapter(query, Baglanti.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri listeleme hatası: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        private void DepolariYukle()
        {
            try
            {
                OpenConnection();
                string query = "SELECT DepoID, DepoAdi FROM Depolar";
                SqlDataAdapter da = new SqlDataAdapter(query, Baglanti.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbDepo.DataSource = dt;
                cmbDepo.DisplayMember = "DepoAdi";
                cmbDepo.ValueMember = "DepoID";
                cmbDepo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Depoları yükleme hatası: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO Urunler (UrunAdi, Stok, Fiyat, DepoID) VALUES (@adi, @stok, @fiyat, @depoID)";
                SqlCommand cmd = new SqlCommand(query, Baglanti.conn);
                cmd.Parameters.AddWithValue("@adi", txtUrunAdi.Text);
                cmd.Parameters.AddWithValue("@stok", int.Parse(txtStok.Text));
                cmd.Parameters.AddWithValue("@fiyat", decimal.Parse(txtFiyat.Text));
                cmd.Parameters.AddWithValue("@depoID", cmbDepo.SelectedValue);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün başarıyla eklendi.");
                UrunleriListele();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme hatası: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int urunID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UrunID"].Value);
                try
                {
                    OpenConnection();
                    string query = "DELETE FROM Urunler WHERE UrunID = @id";
                    SqlCommand cmd = new SqlCommand(query, Baglanti.conn);
                    cmd.Parameters.AddWithValue("@id", urunID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ürün başarıyla silindi.");
                    UrunleriListele();
                    Temizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme hatası: " + ex.Message);
                }
                finally
                {
                    CloseConnection();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int urunID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UrunID"].Value);
                try
                {
                    OpenConnection();
                    string query = @"UPDATE Urunler 
                                     SET UrunAdi = @adi, Stok = @stok, Fiyat = @fiyat, DepoID = @depoID 
                                     WHERE UrunID = @id";
                    SqlCommand cmd = new SqlCommand(query, Baglanti.conn);
                    cmd.Parameters.AddWithValue("@adi", txtUrunAdi.Text);
                    cmd.Parameters.AddWithValue("@stok", int.Parse(txtStok.Text));
                    cmd.Parameters.AddWithValue("@fiyat", decimal.Parse(txtFiyat.Text));
                    cmd.Parameters.AddWithValue("@depoID", cmbDepo.SelectedValue);
                    cmd.Parameters.AddWithValue("@id", urunID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ürün başarıyla güncellendi.");
                    UrunleriListele();
                    Temizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme hatası: " + ex.Message);
                }
                finally
                {
                    CloseConnection();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtUrunAdi.Text = row.Cells["UrunAdi"].Value.ToString();
                txtStok.Text = row.Cells["Stok"].Value.ToString();
                txtFiyat.Text = row.Cells["Fiyat"].Value.ToString();
                cmbDepo.SelectedValue = row.Cells["DepoID"].Value;
            }
        }

        void Temizle()
        {
            txtUrunAdi.Clear();
            txtStok.Clear();
            txtFiyat.Clear();
            cmbDepo.SelectedIndex = -1;
        }

        private void UrunlerForm_Load(object sender, EventArgs e)
        {
            DepolariYukle();
            UrunleriListele();
        }
    }
}
