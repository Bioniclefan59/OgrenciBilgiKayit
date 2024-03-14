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

namespace OgrenciBilgiKayit
{
    public partial class DersListesi : Form
    {
        private string ogrenciIsmi;
        private int ogrenciNo;
        private VeriErisimi veriErisimi;
        public DersListesi(int ogrenciNo, string ogrenciIsmi)
        {
            InitializeComponent();
            this.ogrenciIsmi = ogrenciIsmi;
            this.ogrenciNo = ogrenciNo;
            veriErisimi = new VeriErisimi();
            Load += DersListesi_Load;
        }
        private int GetSelectedDersID(string dersKodu)
        {
            int dersID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(veriErisimi.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetDersIDByDersKodu", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@DersKodu", dersKodu);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            dersID = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting DersID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dersID;
        }
        private void DersListesi_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(veriErisimi.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("OgrenciNodanDersAl", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@OgrenciNo", ogrenciNo);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable derslerTablo = new DataTable();
                            adapter.Fill(derslerTablo);

                            dgvDersListesi.DataSource = derslerTablo;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading lectures: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDersListesi.SelectedRows.Count > 0)
                {
                    string secilenDersKodu = dgvDersListesi.SelectedRows[0].Cells["DersKodu"].Value.ToString();
                    string secilenDersAdi = dgvDersListesi.SelectedRows[0].Cells["DersAdi"].Value.ToString();
                    string secilenDers = $"{secilenDersKodu} - {secilenDersAdi}";

                    int dersID = GetSelectedDersID(secilenDersKodu);
                    DersKaydi dersKaydiForm = Application.OpenForms.OfType<DersKaydi>().FirstOrDefault() ?? new DersKaydi(dersID);

                    dersKaydiForm.SecilenDersiEkle(secilenDers);
                    dersKaydiForm.OgrenciNo = ogrenciNo;
                    dersKaydiForm.OgrenciIsmi = ogrenciIsmi;
                    dersKaydiForm.SecilenDersID = dersID;
                    dersKaydiForm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lütfen kaydedilecek ders seçin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ders seçerken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
