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
                int? ogrenciNo = GetOgrenciNoByIsim(enteredText);

                if (ogrenciNo.HasValue)
                {
                    txtOgrenciNo.Text = ogrenciNo.Value.ToString();
                    PopulateDersKoduComboBox(ogrenciNo.Value);
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
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int ogrenciNo = int.Parse(txtOgrenciNo.Text);
                string dersKodu = cmbDersKodu.SelectedItem.ToString();
                string sinav = cmbSinav.SelectedItem.ToString();
                int not = int.Parse(txtNot.Text);

                int dersID = GetDersIDByKodu(dersKodu);

                InsertOrUpdateNot(ogrenciNo, dersID, sinav, not);

                MessageBox.Show("Sınav bilgisi kaydedildi.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sınav bilgisi kaydedilirken hata oluştu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error loading student names: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public int GetOgrenciNo(string isim)
        {
            int ogrenciNo = 0;

            try
            {

                var ogrenciNoNullable = GetOgrenciNoByIsim(isim);


                ogrenciNo = ogrenciNoNullable ?? 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğrenci Numarasını alırken hata oluştu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ogrenciNo;
        }
        private void PopulateDersKoduComboBox(int ogrenciNo)
        {
            cmbDersKodu.Items.Clear();

            try
            {
                using (var dbContext = new OkulDBCntxt())
                {
                    var dersKodlari = dbContext.Dersler
                        .Where(d => dbContext.OgrenciAtamalari.Any(oa => oa.ogrenci_no == ogrenciNo && oa.DersID == d.DersID))
                        .Select(d => d.DersKodu)
                        .ToList();

                    foreach (var dersKodu in dersKodlari)
                    {
                        cmbDersKodu.Items.Add(dersKodu);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ders Kodu listesi doldurulurken hata oluştu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void InsertOrUpdateNot(int ogrenciNo, int dersID, string sinav, int not)
        {
            try
            {
                using (var dbContext = new OkulDBCntxt())
                {
                    var notlar = dbContext.Notlar
                        .FirstOrDefault(n => n.ogrenci_no == ogrenciNo && n.ders_id == dersID);

                    if (notlar == null)
                    {
                        notlar = new Notlar
                        {
                            ogrenci_no = ogrenciNo,
                            ders_id = dersID
                        };
                        dbContext.Notlar.Add(notlar);
                    }
                    if (sinav == "Ara Sınav 1")
                    {
                        notlar.ara_sinav1 = not;
                    }
                    else if (sinav == "Ara Sınav 2")
                    {
                        notlar.ara_sinav2 = not;
                    }
                    else if (sinav == "Final")
                    {
                        notlar.final = not;
                    }
                    else
                    {
                        MessageBox.Show("Yanlış sınav tipi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dbContext.SaveChanges();
                    MessageBox.Show("Sınav notu başarıyla eklenmiştir.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sınav notu eklenirken ya da güncellenirken hata oluştu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.InnerException != null)
                {
                    MessageBox.Show("Inner Exception: " + ex.InnerException.Message, "Inner Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public int GetDersIDByDersKodu(string dersKodu)
        {
            using (var dbContext = new OkulDBCntxt())
            {
                var ders = dbContext.Dersler
                    .Where(d => d.DersKodu == dersKodu)
                    .Select(d => d.DersID)
                    .FirstOrDefault();

                return ders;
            }
        }
        private int GetDersIDByKodu(string dersKodu)
        {
            int dersID = 0;
            try
            {
                dersID = GetDersIDByDersKodu(dersKodu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("DersID alırken hata oluştu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dersID;
        }
    }
}
