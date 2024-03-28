using OgrenciBilgiKayit.Entity_Classes;
using OgrenciBilgiKayit.OkulDBContext;
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
    public partial class KayitFormu : Form
    {
        private readonly OkulDBCntxt dbContext;
        private VeriErisimi veriErisimi;
        private int ogrenciNo;

        public int OgrenciNo
        {
            get { return ogrenciNo; }
            set { ogrenciNo = value; }
        }
        public KayitFormu()
        {
            InitializeComponent();
            veriErisimi = new VeriErisimi();
            dbContext = new OkulDBCntxt();
            Load += FormuDoldur;
        }
        private void FormuDoldur(object sender, EventArgs e)
        {
            var bolumlerList = dbContext.Bolumler.Select(b => b.BolumAdi).ToList();
            cmbBolumler.DataSource = bolumlerList;
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            int ogrenciNo = Convert.ToInt32(txtOgrenciNo.Text);
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string bolum = cmbBolumler.Text;
            int sinif = Convert.ToInt32(txtSinif.Text);
            DateTime dogumTarihi = dateTimePicker1.Value;
            string cinsiyet = cmbCinsiyet.Text;


            using (var dbContext = new OkulDBCntxt())
            {
                var existingOgrenci = dbContext.Ogrenciler.FirstOrDefault(o => o.ogrenci_no == ogrenciNo);
                if (existingOgrenci != null)
                {
                    MessageBox.Show("Bu numarada bir öğrenci mevcut.");
                    return;
                }

                var newOgrenci = new Ogrenciler
                {
                    ogrenci_no = ogrenciNo,
                    ad = ad,
                    soyad = soyad,
                    bolum = bolum,
                    sinif = sinif,
                    dogum_tarihi = dogumTarihi,
                    cinsiyet = cinsiyet,
                    kayit_tarihi = DateTime.Now 
                };

                dbContext.Ogrenciler.Add(newOgrenci);
                dbContext.SaveChanges();
            }

            MessageBox.Show("Öğrenci bilgileri başarıyla eklendi.");

            SecenekleriTemizle();
        }
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SecenekleriTemizle()
        {
            txtOgrenciNo.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            cmbBolumler.SelectedIndex = -1;
            txtSinif.Clear();
            cmbCinsiyet.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
