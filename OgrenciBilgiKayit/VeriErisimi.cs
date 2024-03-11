using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace OgrenciBilgiKayit
{
    public class VeriErisimi
    {
        public void OgrenciEkle(int ogrenciNo, string ad, string soyad, string bolum, int sinif, DateTime dogumTarihi, string cinsiyet)
{
    try
    {
        using (SqlConnection connection = new SqlConnection(GetConnectionString()))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("dbo.OgrenciEkle", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OgrenciNo", ogrenciNo);
                command.Parameters.AddWithValue("@Ad", ad);
                command.Parameters.AddWithValue("@Soyad", soyad);
                command.Parameters.AddWithValue("@Bolum", bolum);
                command.Parameters.AddWithValue("@Sinif", sinif);
                command.Parameters.AddWithValue("@DogumTarihi", dogumTarihi);
                command.Parameters.AddWithValue("@Cinsiyet", cinsiyet);

                command.ExecuteNonQuery();
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

        }
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["cnt"].ConnectionString;
        }
        public DataTable BolumleriAl()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT BolumAdi FROM Bolumler", connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }
    }
}
