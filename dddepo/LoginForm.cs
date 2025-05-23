using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dddepo
{
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT Rol FROM Kullanicilar WHERE KullaniciAdi=@kadi AND Sifre=@sifre", Baglanti.conn);
            cmd.Parameters.AddWithValue("@kadi", txtKullaniciAdi.Text);
            cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);

            Baglanti.conn.Open();
            object rolObj = cmd.ExecuteScalar();
            Baglanti.conn.Close();

            if (rolObj != null)
            {
                string rol = rolObj.ToString();

                // Rol bilgisini MainForm'a gönderiyoruz
                MainForm frm = new MainForm(rol);  // MainForm(rol) yapmalısın!
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
            }
        }
    }
}
