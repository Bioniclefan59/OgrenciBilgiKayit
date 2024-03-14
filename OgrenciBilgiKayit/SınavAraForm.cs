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
    public partial class SınavAraForm : Form
    {
        public SınavAraForm()
        {
            InitializeComponent();
        }

        private void btnSinavSonucuKaydi_Click(object sender, EventArgs e)
        {
            SinavSonucuKaydi sinavSonucuKaydi = new SinavSonucuKaydi();
            sinavSonucuKaydi.FormClosed += (s, args) => { this.Show(); };
            this.Hide();
            sinavSonucuKaydi.Show();
        }

        private void btnSinavSonucuSorgu_Click(object sender, EventArgs e)
        {
            SınavSonucuSorgu sınavSonucuSorgu = new SınavSonucuSorgu();
            sınavSonucuSorgu.FormClosed += (s, args) => { this.Show(); };
            this.Hide();
            sınavSonucuSorgu.Show();
        }
    }
}
