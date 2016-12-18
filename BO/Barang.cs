using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Barang
    {
        public string KodeBarang { get; set; }
        public int IdJenisMotor { get; set; }
        public int KategoriId { get; set; }
        public string Nama { get; set; }
        public int Stok { get; set; }
        public int HargaBeli { get; set; }
        public int HargaJual { get; set; }
        public DateTime TanggalBeli { get; set; }
    }
}
