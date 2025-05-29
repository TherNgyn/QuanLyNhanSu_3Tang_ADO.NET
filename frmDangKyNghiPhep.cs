using QuanLyNhanSu_3Tang_ADO.BS_Layer;
using QuanLyNhanSu_3Tang_ADO.DB_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmDangKyNghiPhep : Form
    {
        private string maNhanVien;
        private BLNghiPhep dbNP = new BLNghiPhep();
        private string err;

        public frmDangKyNghiPhep(string maNV)
        {
            InitializeComponent();
            maNhanVien = maNV;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNgayNghi.Text) || string.IsNullOrWhiteSpace(txtLyDo.Text) || cbbMaThang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtNgayNghi.Text, out int ngayNghi))
            {
                MessageBox.Show("Ngày nghỉ phải là số nguyên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result = dbNP.ThemNghiPhep(maNhanVien, cbbMaThang.SelectedValue.ToString(), ngayNghi, txtLyDo.Text, ref err);
            if (result)
            {
                MessageBox.Show("Đăng ký nghỉ phép thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLichSuNghiPhep();
                txtNgayNghi.Clear();
                txtLyDo.Clear();
            }
            else
            {
                MessageBox.Show("Lỗi: " + err);
            }
        }

        private void guna2GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void LoadComboBoxThang()
        {
            string query = "SELECT MaThang, MoTa FROM Thang";
            using (SqlConnection conn = new SqlConnection(DBMain.connectString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbbMaThang.DataSource = dt;
                cbbMaThang.DisplayMember = "MoTa";
                cbbMaThang.ValueMember = "MaThang";
                cbbMaThang.SelectedIndex = -1;
            }
        }

        private void LoadLichSuNghiPhep()
        {
            DataTable dt = dbNP.LayNghiPhep().Tables[0];
            DataView view = new DataView(dt);
            view.RowFilter = $"MaNV = '{maNhanVien}'";

            DataTable filtered = view.ToTable(false, "NgayNghiPhep", "TenThang", "GhiChu");
            dgvNghiPhep.DataSource = filtered;
            dgvNghiPhep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void frmDangKyNghiPhep_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = maNhanVien;
            txtMaNV.Enabled = false;

            LoadComboBoxThang();
            LoadLichSuNghiPhep();
        }
    }
}
