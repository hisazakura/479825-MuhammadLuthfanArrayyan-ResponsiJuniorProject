using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responsi_2.Models
{
    public class Karyawan
    {
        public int Id { get; }
        public string Nama { get; }
        public string Departemen { get; }

        public Karyawan(int id, string nama, string departemen)
        {
            Id = id;
            Nama = nama;
            Departemen = departemen;
        }
    }
}
