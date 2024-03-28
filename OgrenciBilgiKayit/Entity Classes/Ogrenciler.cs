using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiKayit.Entity_Classes
{
    public class Ogrenciler
    {
        [Key]
        public int ogrenci_no { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string bolum { get; set; }
        public int sinif { get; set; }
        public DateTime dogum_tarihi { get; set; }
        public string cinsiyet { get; set; }
        public DateTime kayit_tarihi { get; set; }

        public virtual ICollection<Dersler> Dersler { get; set; }
        public virtual ICollection<Notlar> Notlar { get; set; }
        public virtual ICollection<OgrenciAtamalari> OgrenciAtamalari { get; set; }
    }
}
