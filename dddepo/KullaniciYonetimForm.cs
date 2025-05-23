using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dddepo
{
    public partial class KullaniciYonetimForm : Form
    {
        public KullaniciYonetimForm()
        {
            InitializeComponent();
        }

        private void KullaniciYonetimForm_Load(object sender, EventArgs e)
        {
            KullanicilariListele();
        }

        private void KullanicilariListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT KullaniciID, KullaniciAdi, Rol FROM Kullanicilar", Baglanti.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Kullanicilar (KullaniciAdi, Sifre, Rol) VALUES (@adi, @sifre, @rol)", Baglanti.conn);
            cmd.Parameters.AddWithValue("@adi", txtKullaniciAdi.Text);
            cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
            cmd.Parameters.AddWithValue("@rol", cmbRol.SelectedItem.ToString());

            Baglanti.conn.Open();
            cmd.ExecuteNonQuery();
            Baglanti.conn.Close();

            MessageBox.Show("Kullanıcı eklendi.");
            KullanicilariListele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KullaniciID"].Value);

                SqlCommand cmd = new SqlCommand("UPDATE Kullanicilar SET KullaniciAdi=@adi, Sifre=@sifre, Rol=@rol WHERE KullaniciID=@id", Baglanti.conn);
                cmd.Parameters.AddWithValue("@adi", txtKullaniciAdi.Text);
                cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
                cmd.Parameters.AddWithValue("@rol", cmbRol.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@id", id);

                Baglanti.conn.Open();
                cmd.ExecuteNonQuery();
                Baglanti.conn.Close();

                MessageBox.Show("Kullanıcı güncellendi.");
                KullanicilariListele();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KullaniciID"].Value);

                SqlCommand cmd = new SqlCommand("DELETE FROM Kullanicilar WHERE KullaniciID=@id", Baglanti.conn);
                cmd.Parameters.AddWithValue("@id", id);

                Baglanti.conn.Open();
                cmd.ExecuteNonQuery();
                Baglanti.conn.Close();

                MessageBox.Show("Kullanıcı silindi.");
                KullanicilariListele();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtKullaniciAdi.Text = dataGridView1.CurrentRow.Cells["KullaniciAdi"].Value.ToString();
                cmbRol.SelectedItem = dataGridView1.CurrentRow.Cells["Rol"].Value.ToString();
                txtSifre.Text = ""; // Şifreyi güvenlik nedeniyle göstermiyoruz
            }
        }
    }
}
