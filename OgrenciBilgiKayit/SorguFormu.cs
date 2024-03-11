using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciBilgiKayit
{
    public partial class SorguFormu : Form
    {
        private VeriErisimi veriErisimi;
        public SorguFormu()
        {
            InitializeComponent();
            veriErisimi = new VeriErisimi();
            Load += FormuDoldur;
        }
        private void FormuDoldur(object sender, EventArgs e)
        {
            DataTable bolumlerTablo = veriErisimi.BolumleriAl();
            foreach (DataRow row in bolumlerTablo.Rows)
            {
                cmbBolumler.Items.Add(row["BolumAdi"]);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSorgula_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = veriErisimi.GetConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.SorgulaOgrenci", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        
                        command.Parameters.AddWithValue("@OgrenciNo", string.IsNullOrWhiteSpace(txtOgrenciNo.Text) ? (object)DBNull.Value : txtOgrenciNo.Text.Trim());
                        command.Parameters.AddWithValue("@Bolum", string.IsNullOrWhiteSpace(cmbBolumler.Text) ? (object)DBNull.Value : cmbBolumler.Text.Trim());
                        command.Parameters.AddWithValue("@KayitTarihi", dtpKayitTarihi.Value);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvSonuclar.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
