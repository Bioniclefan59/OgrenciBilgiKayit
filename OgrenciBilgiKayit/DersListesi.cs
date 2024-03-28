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
    public partial class DersListesi : Form
    {
        private string ogrenciIsmi;
        private int ogrenciNo;
        private VeriErisimi veriErisimi;
        public DersListesi(int ogrenciNo, string ogrenciIsmi)
        {
            InitializeComponent();
            this.ogrenciIsmi = ogrenciIsmi;
            this.ogrenciNo = ogrenciNo;
            veriErisimi = new VeriErisimi();
            Load += DersListesi_Load;
        }
        private int GetSelectedDersID(string dersKodu)
        {
            int dersID = 0;
            try
            {
                using (var dbContext = new OkulDBCntxt())
                {
                    var ders = dbContext.Dersler.FirstOrDefault(d => d.DersKodu == dersKodu);
                    if (ders != null)
                    {
                        dersID = ders.DersID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DersID alınırken hata oluştu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dersID;
        }
        private void DersListesi_Load(object sender, EventArgs e)
        {
            try
            {
                DersKaydi dersKaydi = new DersKaydi();
                string ogrenciNoText = this.ogrenciNo.ToString();
                MessageBox.Show("Ogrenci No Text: " + ogrenciNoText);
                if (int.TryParse(ogrenciNoText, out int ogrenciNo))
                {
                    using (var dbContext = new OkulDBCntxt())
                    {

                        var bolumAdi = dbContext.Ogrenciler
                            .Where(o => o.ogrenci_no == ogrenciNo)
                            .Select(o => o.bolum)
                            .FirstOrDefault();

                        var bolumID = dbContext.Bolumler
                            .Where(o => o.BolumAdi == bolumAdi)
                            .Select(o => o.BolumID)
                            .FirstOrDefault();

                        var dersler = dbContext.Dersler
                            .Where(d => d.BolumID == bolumID)
                            .Select(d => new { d.DersKodu, d.DersAdi })
                            .ToList();

                        DataTable derslerTablo = new DataTable();
                        derslerTablo.Columns.Add("DersKodu", typeof(string));
                        derslerTablo.Columns.Add("DersAdi", typeof(string));

                        foreach (var ders in dersler)
                        {
                            derslerTablo.Rows.Add(ders.DersKodu, ders.DersAdi);
                        }

                        dgvDersListesi.DataSource = derslerTablo;
                    }
                }
                else
                {
                    MessageBox.Show("Ogrenci No hatalı.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dersleri yüklerken hata oluştu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDersListesi.SelectedRows.Count > 0)
                {
                    string secilenDersKodu = dgvDersListesi.SelectedRows[0].Cells["DersKodu"].Value.ToString();
                    string secilenDersAdi = dgvDersListesi.SelectedRows[0].Cells["DersAdi"].Value.ToString();
                    string secilenDers = $"{secilenDersKodu} - {secilenDersAdi}";

                    int dersID = GetSelectedDersID(secilenDersKodu);
                    DersKaydi dersKaydiForm = Application.OpenForms.OfType<DersKaydi>().FirstOrDefault() ?? new DersKaydi(dersID);

                    dersKaydiForm.SecilenDersiEkle(secilenDers);
                    dersKaydiForm.OgrenciNo = ogrenciNo;
                    dersKaydiForm.OgrenciIsmi = ogrenciIsmi;
                    dersKaydiForm.SecilenDersID = dersID;
                    dersKaydiForm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lütfen kaydedilecek ders seçin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ders seçerken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
