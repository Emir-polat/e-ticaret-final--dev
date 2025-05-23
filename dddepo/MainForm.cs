using dddepo;
using System;
using System.Windows.Forms;

namespace dddepo
{
    public partial class MainForm : Form
    {
        private string kullaniciRolu;

        // Constructor artık rol parametresi alıyor
        public MainForm(string rol)
        {
            InitializeComponent();
            kullaniciRolu = rol;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Form başlığını günceller
            this.Text = $"Depo Otomasyon Sistemi - Giriş Yapan: {kullaniciRolu}";

            // Eğer admin değilse, kullanıcı yönetim butonunu gizle
            if (kullaniciRolu != "Admin")
            {
                btnKullaniciYonetim.Visible = false;
            }

            // Eğer personel ise, ürün ekleme butonunu gizle
            if (kullaniciRolu == "Personel")
            {
                btnUrunler.Visible = false; // Personel için ürün ekleme butonunu gizle
            }
        }

        // Ürünler butonuna tıklanması
        private void btnUrunler_Click(object sender, EventArgs e)
        {
            UrunlerForm frm = new UrunlerForm();
            frm.ShowDialog();
        }

        // Siparişler butonuna tıklanması
        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            SiparislerForm frm = new SiparislerForm();
            frm.ShowDialog();
        }

        // Depo doluluk oranlarını gösteren grafik formu
        private void btnDepoDoluluk_Click(object sender, EventArgs e)
        {
            DepoGrafikForm frm = new DepoGrafikForm();
            frm.ShowDialog();
        }

        // Kullanıcı yönetim formunu açma
        private void btnKullaniciYonetim_Click(object sender, EventArgs e)
        {
            KullaniciYonetimForm frm = new KullaniciYonetimForm();
            frm.ShowDialog();
        }

        // Çıkış yapma
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
