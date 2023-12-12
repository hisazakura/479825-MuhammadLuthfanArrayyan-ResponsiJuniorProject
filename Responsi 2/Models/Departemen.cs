using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responsi_2.Models
{
    public class Departemen
    {
        public int Id { get; }
        public string Nama { get; }

        Departemen(int id, string nama)
        {
            Id = id;
            Nama = nama;
        }

    }
}
