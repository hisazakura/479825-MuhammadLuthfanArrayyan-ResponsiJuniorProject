using Npgsql;
using Responsi_2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;

namespace Responsi_2.Services
{
    public class DataProvider
    {
        private static DataProvider? _instance;
        private NpgsqlConnection? _conn;
        public static DataProvider Instance { get { if (_instance == null) _instance = new DataProvider(); return _instance; } }
        public DataProvider() { }

        public void Connect(string connectionString)
        {
            _conn = new NpgsqlConnection(connectionString);
        }

        public DataTable Fetch(string query)
        {
            if (_conn == null) throw new NullReferenceException("Data Provider must be connected to a database");
            if (_conn.State == ConnectionState.Closed) _conn.Open();

            DataTable dt = new DataTable();
            NpgsqlCommand cmd = new NpgsqlCommand(query, _conn);

            dt.Load(cmd.ExecuteReader());

            _conn.Close();

            return dt;
        }

        public string NamaDepartemen(int id)
        {
            if (_conn == null) throw new NullReferenceException("Data Provider must be connected to a database");
            if (_conn.State == ConnectionState.Closed) _conn.Open();

            DataTable dt = new DataTable();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT nama_dep FROM departemen WHERE id_dep=:_id", _conn);
            cmd.Parameters.AddWithValue("_id", id);

            object? result = cmd.ExecuteScalar();

            _conn.Close();

            if (result == null) return "";

            return (string)result;
        }

        public List<Karyawan> SemuaKaryawan()
        {
            if (_conn == null) throw new NullReferenceException("Data Provider must be connected to a database");
            if (_conn.State == ConnectionState.Closed) _conn.Open();

            List<Karyawan> karyawan = new List<Karyawan>();
            DataTable dt = new DataTable();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM karyawan", _conn);

            dt.Load(cmd.ExecuteReader());

            foreach (DataRow dr in dt.Rows)
            {
                karyawan.Add(Karyawan.From(dr));
            }

            _conn.Close();

            return karyawan;
        }

        public bool TambahKaryawan(string nama, int departemen)
        {
            if (_conn == null) throw new NullReferenceException("Data Provider must be connected to a database");
            if (_conn.State == ConnectionState.Closed) _conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM tambah_karyawan(:_nama, :_dept);", _conn);
            cmd.Parameters.AddWithValue("_nama", nama);
            cmd.Parameters.AddWithValue("_dept", departemen);

            cmd.ExecuteScalar();
            _conn.Close();

            return true;
        }

        public bool TambahKaryawan(string nama, Departemen departemen)
        {
            return TambahKaryawan(nama, departemen.Id);
        }

        public bool UbahKaryawan(int id, string nama, int departemen)
        {
            if (_conn == null) throw new NullReferenceException("Data Provider must be connected to a database");
            if (_conn.State == ConnectionState.Closed) _conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE karyawan SET nama = :_nama, id_dep = :_dept WHERE id_karyawan = :_id", _conn);
            cmd.Parameters.AddWithValue("_id", id);
            cmd.Parameters.AddWithValue("_nama", nama);
            cmd.Parameters.AddWithValue("_dept", departemen);

            cmd.ExecuteScalar();
            _conn.Close();

            return true;
        }
        public bool UbahKaryawan(Karyawan karyawan)
        {
            if (_conn == null) throw new NullReferenceException("Data Provider must be connected to a database");
            if (_conn.State == ConnectionState.Closed) _conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE karyawan SET nama = :_nama, id_dep = :_dept WHERE id_karyawan = :_id", _conn);
            cmd.Parameters.AddWithValue("_id", karyawan.Id);
            cmd.Parameters.AddWithValue("_nama", karyawan.Nama);
            cmd.Parameters.AddWithValue("_dept", karyawan.Departemen);
            cmd.ExecuteScalar();
            _conn.Close();
            return UbahKaryawan(karyawan.Id, karyawan.Nama, CariDepartemenId(karyawan.Departemen));
        }

        public bool HapusKaryawan(int id)
        {
            if (_conn == null) throw new NullReferenceException("Data Provider must be connected to a database");
            if (_conn.State == ConnectionState.Closed) _conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM karyawan WHERE id_karyawan = :_id;", _conn);
            cmd.Parameters.AddWithValue("_id", id);
            cmd.ExecuteScalar();
            _conn.Close();
            return true;
        }

        public int CariDepartemenId(string departemen)
        {
            if (_conn == null) throw new NullReferenceException("Data Provider must be connected to a database");
            if (_conn.State == ConnectionState.Closed) _conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT id_dep FROM departemen WHERE nama_dep = :_dept", _conn);
            cmd.Parameters.AddWithValue("_dept", departemen);
            object? result = cmd.ExecuteScalar();
            _conn.Close();

            if (result == null) return -1;
            return (int)result;
        }

        
    }
}
