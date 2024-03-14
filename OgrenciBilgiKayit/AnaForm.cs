using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciBilgiKayit
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void btnKayit_click(object sender, EventArgs e)
        {
            KayitFormu kayitFormu = new KayitFormu();
            kayitFormu.FormClosed += (s, args) => { this.Show(); };
            this.Hide();
            kayitFormu.Show();
        }

        private void btnSorgulama_click(object sender, EventArgs e)
        {
            SorguFormu sorguFormu = new SorguFormu();
            sorguFormu.FormClosed += (s, args) => { this.Show(); };
            this.Hide();
            sorguFormu.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DersKaydi dersKaydi = new DersKaydi();
            dersKaydi.FormClosed += (s, args) => { this.Show(); };
            this.Hide();
            dersKaydi.Show();
        }

        private void btnSinavSonuclari_Click(object sender, EventArgs e)
        {
            SınavAraForm sinavAraForm = new SınavAraForm();
            sinavAraForm.FormClosed += (s, args) => { this.Show(); };
            this.Hide();
            sinavAraForm.Show();
        }
    }
}
