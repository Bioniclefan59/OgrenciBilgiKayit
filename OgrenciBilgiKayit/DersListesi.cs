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
        private int GetSelectedDersID()
        {
            if (dgvDersListesi.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDersListesi.SelectedRows[0];
                int dersID = Convert.ToInt32(selectedRow.Cells["DersID"].Value);
                return dersID;
            }
            return 0;
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
                    int selectedDersID = GetSelectedDersID();
                    string secilenDersKodu = dgvDersListesi.SelectedRows[0].Cells["DersKodu"].Value.ToString();
                    string secilenDersAdi = dgvDersListesi.SelectedRows[0].Cells["DersAdi"].Value.ToString();
                    string secilenDers = $"{secilenDersKodu} - {secilenDersAdi}";

                    DersKaydi dersKaydiForm = Application.OpenForms.OfType<DersKaydi>().FirstOrDefault() ?? new DersKaydi(selectedDersID);

                    dersKaydiForm.SecilenDersiEkle(secilenDers);
                    dersKaydiForm.OgrenciNo = ogrenciNo;
                    dersKaydiForm.OgrenciIsmi = ogrenciIsmi;
                    dersKaydiForm.SecilenDersID = selectedDersID;
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
