using OgrenciBilgiKayit.OkulDBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciBilgiKayit
{
    public partial class SorguFormu : Form
    {
        private VeriErisimi veriErisimi;
        public SorguFormu()
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

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSorgula_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new OkulDBCntxt())
                {
                    var query = dbContext.Ogrenciler.AsQueryable();

                    if (!string.IsNullOrWhiteSpace(txtOgrenciNo.Text))
                    {
                        int ogrenciNo = int.Parse(txtOgrenciNo.Text);
                        query = query.Where(o => o.ogrenci_no == ogrenciNo);
                    }

                    if (!string.IsNullOrWhiteSpace(cmbBolumler.Text))
                    {
                        string bolum = cmbBolumler.Text.Trim();
                        query = query.Where(o => o.bolum == bolum);
                    }

                    DateTime selectedDate = dtpKayitTarihi.Value.Date;
                    query = query.Where(o => DbFunctions.TruncateTime(o.kayit_tarihi) == selectedDate);
                    var results = query.ToList();

                    dgvSonuclar.DataSource = results;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
