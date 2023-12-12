using Npgsql;
using Responsi_2.Models;
using Responsi_2.Services;
using System.Data;
using System.Diagnostics;

namespace Responsi_2
{
    public partial class MainForm : Form
    {
        private NpgsqlConnection? _conn;
        DataTable? dt;
        List<Karyawan> karyawanList;
        public MainForm()
        {
            InitializeComponent();
            DataProvider.Instance.Connect("Host=localhost;Port=5432;Username=postgres;Password=informatika;Database=hrdb");
            ListDepartemen.Items.Add("HR");
            ListDepartemen.Items.Add("Engineer");
            ListDepartemen.Items.Add("Developer");
            ListDepartemen.Items.Add("Product Manager");
            ListDepartemen.Items.Add("Finance");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            karyawanList = DataProvider.Instance.SemuaKaryawan();
            dt = UbahListMenjadiTabel(karyawanList);

            DataViewer.DataSource = dt;
        }

        private DataTable UbahListMenjadiTabel(List<Karyawan> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("nama");
            dt.Columns.Add("departemen");
            foreach (Karyawan karyawan in list)
            {
                dt.Rows.Add(karyawan.Id, karyawan.Nama, karyawan.Departemen);
            }

            return dt;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (NamaKaryawan.Text == "") { MessageBox.Show("Nama Karyawan tidak boleh kosong"); return; }
            if (ListDepartemen.SelectedIndex == -1) { MessageBox.Show("Mohon pilih departemen"); return; }
            DataProvider.Instance.TambahKaryawan(NamaKaryawan.Text, ListDepartemen.SelectedIndex);
            LoadData();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (NamaKaryawan.Text == "") { MessageBox.Show("Nama Karyawan tidak boleh kosong"); return; }
            if (ListDepartemen.SelectedIndex == -1) { MessageBox.Show("Mohon pilih departemen"); return; }
            if (DataViewer.SelectedCells.Count == 0) { MessageBox.Show("Mohon pilih karyawan"); return; }

            DataGridViewRow row = DataViewer.SelectedCells[0].OwningRow;
            DataProvider.Instance.UbahKaryawan(
                int.Parse(row.Cells[0].Value.ToString()),
                NamaKaryawan.Text,
                ListDepartemen.SelectedIndex
            );
            LoadData();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DataViewer.SelectedCells.Count == 0) { MessageBox.Show("Mohon pilih karyawan"); return; }
            DataGridViewRow row = DataViewer.SelectedCells[0].OwningRow;
            DataProvider.Instance.HapusKaryawan(int.Parse(row.Cells[0].Value.ToString()));
            LoadData();
        }

        private void DataViewer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DataViewer.SelectedCells[0].OwningRow;
            NamaKaryawan.Text = row.Cells[1].Value.ToString();
            for (int i = 0; i < ListDepartemen.Items.Count; i++)
            {
                if (ListDepartemen.Items[i].ToString() == row.Cells[2].Value.ToString()) { ListDepartemen.SelectedIndex = i; return; }
            }
               
        }
    }
}