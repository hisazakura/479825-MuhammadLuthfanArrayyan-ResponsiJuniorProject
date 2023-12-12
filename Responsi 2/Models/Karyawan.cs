using Responsi_2.Services;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static Karyawan From(DataRow dataRow)
        {
            string[] expectedFields = { "id_karyawan", "nama", "id_dep" };
            foreach (string field in expectedFields)
            {
                if (!dataRow.Table.Columns.Contains(field)) throw new MissingFieldException($"The field {field} does not exist.");
            }

            string department = DataProvider.Instance.NamaDepartemen((int)dataRow["id_dep"]);

            return new Karyawan((int)dataRow["id_karyawan"], (string)dataRow["nama"], department);
        }
    }
}
