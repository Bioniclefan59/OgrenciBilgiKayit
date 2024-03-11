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
        private VeriErisimi veriErisimi;
        public KayitFormu()
        {
            InitializeComponent();
            veriErisimi = new VeriErisimi();
            Load += FormuDoldur;
        }

        private void FormuDoldur(object sender, EventArgs e)
        {
            DataTable bolumlerTablo = veriErisimi.BolumleriAl();
            foreach (DataRow row in bolumlerTablo.Rows)
            {
                cmbBolumler.Items.Add(row["BolumAdi"]);
            }
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


            veriErisimi.OgrenciEkle(ogrenciNo, ad, soyad, bolum, sinif, dogumTarihi, cinsiyet);
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
