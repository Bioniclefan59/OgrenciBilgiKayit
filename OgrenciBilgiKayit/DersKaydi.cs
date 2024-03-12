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
    public partial class DersKaydi : Form
    {
        public int SecilenDersID { get; set; }
        public int OgrenciNo { get; set; }
        public string OgrenciIsmi { get; set; }
        private VeriErisimi veriErisimi;
        private AutoCompleteStringCollection autoCompleteCollection;
        public int ogrenciNo;
        public string ogrenciIsmi;
        private readonly int selectedDersID;
        public DersKaydi(int selectedDersID)
        {
            InitializeComponent();
            this.selectedDersID = selectedDersID;
            veriErisimi = new VeriErisimi();
            Load += DersKaydi_Load;
        }

        private void DersKaydi_Load(object sender, EventArgs e)
        {
            autoCompleteCollection = new AutoCompleteStringCollection();
            OgrenciIsmiYukle();
            txtOgrenciIsmi.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtOgrenciIsmi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtOgrenciIsmi.AutoCompleteCustomSource = autoCompleteCollection;
            txtOgrenciNo.Text = OgrenciNo.ToString();
            txtOgrenciIsmi.Text = OgrenciIsmi;
        }

        private void OgrenciIsmiYukle()
        {
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
        }
        private void TxtOgrenciIsmi_TextChanged(object sender, EventArgs e)
        {
            string secilenOgrenciIsmi = txtOgrenciIsmi.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(veriErisimi.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetOgrenciNoByIsim", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Isim", secilenOgrenciIsmi);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ogrenciNo = Convert.ToInt32(reader["OgrenciNo"]);
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
           private void btnDersSec_Click(object sender, EventArgs e)
           {
               DersListesi dersListesi = new DersListesi(ogrenciNo, ogrenciIsmi);
               dersListesi.FormClosed += (s, args) => { this.Show(); };
               this.Hide();
               dersListesi.Show();
           }
        public void SecilenDersiEkle(string secilenDers)
        {
            txtSecilenDers.Text = secilenDers;
        }

        private void btnDersKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int ogrenciNo = Convert.ToInt32(txtOgrenciNo.Text); 
                int dersID = selectedDersID; 

                using (SqlConnection connection = new SqlConnection(veriErisimi.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InsertOgrenciAtama", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@OgrenciNo", ogrenciNo);
                        command.Parameters.AddWithValue("@DersID", dersID);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Atama başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Atama kaydı sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string OgrenciNoText
        {
            get { return txtOgrenciNo.Text; }
            set { txtOgrenciNo.Text = value; }
        }
        public string OgrenciIsmiText
        {
            get { return txtOgrenciIsmi.Text; }
            set { txtOgrenciIsmi.Text = value; }
        }
        private void txtOgrenciIsmi_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtOgrenciNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
