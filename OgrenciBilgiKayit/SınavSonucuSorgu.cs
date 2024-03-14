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
    public partial class SınavSonucuSorgu : Form
    {
        private AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
        private VeriErisimi veriErisimi;
        public int ogrenciNo;
        public SınavSonucuSorgu()
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

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            try
            {
                int ogrenciNo = int.Parse(txtOgrenciNo.Text);

                DataTable table = GetLectureGradesForStudent(ogrenciNo);

                dgvSinavSonuclari.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error querying lecture grades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DataTable GetLectureGradesForStudent(int ogrenciNo)
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(veriErisimi.GetConnectionString()))
                {
                    connection.Open();

                    string query = "SELECT * FROM Notlar WHERE Ogrenci_no = @OgrenciNo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OgrenciNo", ogrenciNo);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }
    }
}
