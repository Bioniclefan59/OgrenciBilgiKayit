using OgrenciBilgiKayit.Entity_Classes;
using OgrenciBilgiKayit.OkulDBContext;
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
        public int? GetOgrenciNoByIsim(string isim)
        {
            using (var dbContext = new OkulDBCntxt())
            {
                var ogrenciNo = dbContext.Ogrenciler
                    .Where(o => (o.ad + " " + o.soyad) == isim)
                    .Select(o => o.ogrenci_no)
                    .FirstOrDefault();

                return ogrenciNo;
            }
        }
        private void TxtOgrenciIsmi_TextChanged(object sender, EventArgs e)
        {
            string enteredText = txtOgrenciIsmi.Text;

            try
            {
                var ogrenciNo = GetOgrenciNoByIsim(enteredText);

                if (ogrenciNo.HasValue)
                {
                    txtOgrenciNo.Text = ogrenciNo.Value.ToString();
                }
                else
                {
                    txtOgrenciNo.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğrenci numarası alınırken hata oluştu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<string> OgrenciIsmiAl()
        {
            using (var dbContext = new OkulDBCntxt())
            {
                var fullNameList = dbContext.Ogrenciler
                    .Select(o => o.ad + " " + o.soyad)
                    .ToList();

                return fullNameList;
            }
        }
        private void OgrenciIsmiYukle()
        {
            try
            {
                var fullNameList = OgrenciIsmiAl();

                foreach (var fullName in fullNameList)
                {
                    autoCompleteCollection.Add(fullName);
                }

                txtOgrenciIsmi.TextChanged += TxtOgrenciIsmi_TextChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğrenci isimleri yüklenirken hata oluştu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int GetOgrenciNo(string isim)
        {
            int ogrenciNo = 0;

            try
            {
                var ogrenciNoNullable = GetOgrenciNoByIsim(isim);

                if (ogrenciNoNullable.HasValue)
                {
                    ogrenciNo = ogrenciNoNullable.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğrenci numarasını alırken sorun oluştu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Sınav notlarını alırken sorun oluştu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DataTable GetLectureGradesForStudent(int ogrenciNo)
        {
            DataTable table = new DataTable();

            try
            {
                using (var dbContext = new OkulDBCntxt())
                {
                    var grades = dbContext.Notlar
                        .Where(n => n.ogrenci_no == ogrenciNo)
                        .ToList();

                    if (grades.Count > 0)
                    {
                        var properties = typeof(Notlar).GetProperties();
                        foreach (var property in properties)
                        {
                            table.Columns.Add(property.Name, property.PropertyType);
                        }

                        foreach (var grade in grades)
                        {
                            DataRow row = table.NewRow();
                            foreach (var property in properties)
                            {
                                row[property.Name] = property.GetValue(grade);
                            }
                            table.Rows.Add(row);
                        }
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
