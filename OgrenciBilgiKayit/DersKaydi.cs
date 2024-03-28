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
        public DersKaydi()
        {
            InitializeComponent();
            veriErisimi = new VeriErisimi();
            this.ogrenciNo = ogrenciNo;
            this.ogrenciIsmi = ogrenciIsmi;
            Load += DersKaydi_Load;
        }
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
                MessageBox.Show("İsimler yüklenirken hata oluştu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void TxtOgrenciIsmi_TextChanged(object sender, EventArgs e)
        {
            string secilenOgrenciIsmi = txtOgrenciIsmi.Text;

            try
            {
                var ogrenciNo = GetOgrenciNoByIsim(secilenOgrenciIsmi);

                if (ogrenciNo != 0)
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
                MessageBox.Show("Öğrenci Nosunu alırken hata oluştu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnDersSec_Click(object sender, EventArgs e)
           {
            string ogrenciNoText = txtOgrenciNo.Text;
            string ogrenciIsmi = txtOgrenciIsmi.Text;
            int ogrenciNo;
            if(int.TryParse(ogrenciNoText, out ogrenciNo))
            {
                DersListesi dersListesi = new DersListesi(ogrenciNo, ogrenciIsmi);
                dersListesi.FormClosed += (s, args) => { this.Show(); };
                this.Hide();
                dersListesi.Show();
            }
            else
            {
                MessageBox.Show("Ogrenci No hatalı.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                int dersID = SecilenDersID;

                using (var dbContext = new OkulDBCntxt())
                {
                    dbContext.InsertOgrenciAtama(ogrenciNo, dersID);
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

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
