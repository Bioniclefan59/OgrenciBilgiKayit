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
    public partial class SinavSonucuKaydi : Form
    {
        private AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
        private VeriErisimi veriErisimi;
        public int ogrenciNo;
        public SinavSonucuKaydi()
        {
            InitializeComponent();
            veriErisimi = new VeriErisimi();
            Load += SinavSonucuKaydi_Load;
        }
        private void SinavSonucuKaydi_Load(object sender, EventArgs e)
        {
            autoCompleteCollection = new AutoCompleteStringCollection();
            OgrenciIsmiYukle();
            txtOgrenciIsmi.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtOgrenciIsmi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtOgrenciIsmi.AutoCompleteCustomSource = autoCompleteCollection;
            cmbSinav.Items.AddRange(new string[] { "Ara Sınav 1", "Ara Sınav 2", "Final" });
        }
        private void TxtOgrenciIsmi_TextChanged(object sender, EventArgs e)
        {
            string enteredText = txtOgrenciIsmi.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(veriErisimi.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetOgrenciNoByIsim", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Isim", enteredText);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int ogrenciNo = Convert.ToInt32(reader["OgrenciNo"]);
                                txtOgrenciNo.Text = ogrenciNo.ToString();
                                PopulateDersKoduComboBox(ogrenciNo);
                            }
                            else
                            {
                                txtOgrenciNo.Text = string.Empty;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting student number: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int ogrenciNo = int.Parse(txtOgrenciNo.Text);
                string dersKodu = cmbDersKodu.SelectedItem.ToString();
                string sinav = cmbSinav.SelectedItem.ToString();
                int not = int.Parse(txtNot.Text);

                int dersID = GetDersIDByKodu(dersKodu);

                InsertNot(ogrenciNo, dersID, sinav, not);

                MessageBox.Show("Exam data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while saving exam data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OgrenciIsmiYukle()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(veriErisimi.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("OgrenciIsmiAl", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string fullName = reader["FullName"].ToString();
                                autoCompleteCollection.Add(fullName);
                            }
                        }
                    }
                }
                txtOgrenciIsmi.TextChanged += TxtOgrenciIsmi_TextChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student names: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int GetOgrenciNo(string isim)
        {
            int ogrenciNo = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(veriErisimi.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand("GetOgrenciNoByIsim", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Isim", isim);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            ogrenciNo = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting student number: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ogrenciNo;
        }
        private void PopulateDersKoduComboBox(int ogrenciNo)
        {
            cmbDersKodu.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(veriErisimi.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT DersKodu FROM Dersler WHERE DersID IN (SELECT DersID FROM OgrenciAtamalari WHERE Ogrenci_no = @OgrenciNo)", connection))
                    {
                        command.Parameters.AddWithValue("@OgrenciNo", ogrenciNo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string dersKodu = reader["DersKodu"].ToString();
                                cmbDersKodu.Items.Add(dersKodu);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error populating lecture code combo box: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void InsertNot(int ogrenciNo, int dersID, string sinav, int not)
        {
            try
            {
                MessageBox.Show("Sinav: " + sinav);

                using (SqlConnection connection = new SqlConnection(veriErisimi.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InsertOrUpdateNot", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OgrenciNo", ogrenciNo);
                        command.Parameters.AddWithValue("@DersID", dersID);
                        command.Parameters.AddWithValue("@Sinav", sinav);
                        command.Parameters.AddWithValue("@Not", not);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting or updating grade: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetDersIDByKodu(string dersKodu)
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
                        if (result != null && result != DBNull.Value)
                        {
                            dersID = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while getting DersID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dersID;
        }
    }
}
