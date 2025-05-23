using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace dddepo
{
    public partial class DepoGrafikForm : Form
    {
        ToolTip toolTip = new ToolTip();

        public DepoGrafikForm()
        {
            InitializeComponent();
        }

        private void DepoGrafikForm_Load(object sender, EventArgs e)
        {
            // Renk efsanesi (legend)
            Label legend = new Label
            {
                Text = "🔴 <%30   🟡 %30-%70   🟢 >%70 dolu   ⚫ Kapasite Tanımsız",
                ForeColor = Color.Black,
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                Location = new Point(10, 5)
            };
            this.Controls.Add(legend);

            // Yenile butonu
            Button btnYenile = new Button
            {
                Text = "Yenile",
                Location = new Point(500, 5),
                Width = 100,
                Height = 30
            };
            btnYenile.Click += BtnYenile_Click;
            this.Controls.Add(btnYenile);

            YukleDepoDoluluklari();
        }

        private void BtnYenile_Click(object sender, EventArgs e)
        {
            YukleDepoDoluluklari();
        }

        void YukleDepoDoluluklari()
        {
            flowLayoutPanel1.Controls.Clear();

            SqlCommand cmd = new SqlCommand("SELECT DepoID, DepoAdi, Kapasite FROM Depolar", Baglanti.conn);
            Baglanti.conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<(int DepoID, string DepoAdi, int Kapasite)> depolar = new List<(int, string, int)>();

            while (dr.Read())
            {
                depolar.Add((
                    Convert.ToInt32(dr["DepoID"]),
                    dr["DepoAdi"].ToString(),
                    Convert.ToInt32(dr["Kapasite"])
                ));
            }

            dr.Close();

            foreach (var depo in depolar)
            {
                int toplamStok = GetToplamStok(depo.DepoID);
                int dolulukOrani = depo.Kapasite == 0 ? 0 : (int)((toplamStok / (double)depo.Kapasite) * 100);

                Panel depoPanel = new Panel();
                depoPanel.Width = flowLayoutPanel1.ClientSize.Width - 30;
                depoPanel.Height = 80;
                depoPanel.Margin = new Padding(10);
                depoPanel.BorderStyle = BorderStyle.FixedSingle;
                depoPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

                Label lblAdi = new Label();
                lblAdi.Text = depo.DepoAdi;
                lblAdi.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblAdi.Location = new Point(10, 10);
                lblAdi.AutoSize = true;

                Panel progressPanel = new Panel();
                progressPanel.Location = new Point(10, 35);
                progressPanel.Size = new Size(300, 20);
                progressPanel.BackColor = Color.LightGray;

                Panel doluPanel = new Panel();
                doluPanel.Height = 20;
                doluPanel.Width = (int)(3 * dolulukOrani); // %100 = 300px

                // Renk belirleme
                if (depo.Kapasite == 0)
                {
                    doluPanel.BackColor = Color.DimGray;
                }
                else
                {
                    doluPanel.BackColor = dolulukOrani < 30 ? Color.Red :
                                          dolulukOrani < 70 ? Color.Goldenrod :
                                          Color.Green;
                }

                // ToolTip
                string tooltipText = depo.Kapasite == 0
                    ? $"Kapasite: Tanımsız\nToplam Stok: {toplamStok}\nDoluluk: -"
                    : $"Kapasite: {depo.Kapasite}\nToplam Stok: {toplamStok}\nDoluluk: %{dolulukOrani}";

                toolTip.SetToolTip(doluPanel, tooltipText);
                toolTip.SetToolTip(progressPanel, tooltipText);

                progressPanel.Controls.Add(doluPanel);

                Label lblOran = new Label();
                lblOran.Text = depo.Kapasite == 0 ? "-" : $"%{dolulukOrani}";
                lblOran.Location = new Point(320, 35);
                lblOran.AutoSize = true;

                depoPanel.Controls.Add(lblAdi);
                depoPanel.Controls.Add(progressPanel);
                depoPanel.Controls.Add(lblOran);

                flowLayoutPanel1.Controls.Add(depoPanel);
            }

            Baglanti.conn.Close();
        }

        int GetToplamStok(int depoID)
        {
            SqlCommand cmd = new SqlCommand("SELECT SUM(Stok) FROM Urunler WHERE DepoID = @id", Baglanti.conn);
            cmd.Parameters.AddWithValue("@id", depoID);
            object result = cmd.ExecuteScalar();
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }
    }
}
