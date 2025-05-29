using QuanLyNhanSu_3Tang_ADO.BS_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        String userName;
        BLNhanVien bLNhanVien = new BLNhanVien();
        BLTaiKhoan bLTaiKhoan = new BLTaiKhoan();
        DataTable dtTaiKhoan = new DataTable();
        DataTable dtTenLoai = new DataTable();
        DataTable dtMaNV = new DataTable();
        bool Them;
        string err;

        public frmQuanLyTaiKhoan(string userName)
        {
            InitializeComponent();
            this.userName = userName;
        }
        void LoadData()
        {
            cmbTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = false;
            txtMaLoai.Enabled = false;
            txtHo.Enabled = false;
            txtTen.Enabled = false;
            cmbTenLoai.Enabled = false;

            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            dtTaiKhoan = new DataTable();
            dtTaiKhoan.Clear();
            DataSet ds = bLTaiKhoan.LayThongTinTaiKhoan();
            dtTaiKhoan = ds.Tables[0];

            dgvTaiKhoan.DataSource = dtTaiKhoan;
        }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
            dtTenLoai = new DataTable();
            dtTenLoai.Clear();
            DataSet ds = bLTaiKhoan.LayTenLoaiTaiKhoan();
            dtTenLoai = ds.Tables[0];

            cmbTenLoai.DataSource = dtTenLoai;
            cmbTenLoai.DisplayMember = "Ten";     // Hiển thị chữ
            cmbTenLoai.ValueMember = "MaLoai";

            dtMaNV = new DataTable();
            dtMaNV.Clear();
            DataSet ds2 = bLNhanVien.LayTatCaMaNhanVien();
            dtMaNV = ds2.Tables[0];

            cmbTenDangNhap.DataSource = dtMaNV;
            cmbTenDangNhap.DisplayMember = "MaNV";
            cmbTenDangNhap.ValueMember = "MaNV";
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvTaiKhoan.CurrentCell.RowIndex;
            cmbTenDangNhap.SelectedValue = dgvTaiKhoan.Rows[r].Cells[0].Value.ToString();
            txtMatKhau.Text = dgvTaiKhoan.Rows[r].Cells[1].Value.ToString();
            txtMaLoai.Text = dgvTaiKhoan.Rows[r].Cells[2].Value.ToString();
            txtHo.Text = dgvTaiKhoan.Rows[r].Cells[3].Value.ToString();
            txtTen.Text = dgvTaiKhoan.Rows[r].Cells[4].Value.ToString();
            cmbTenLoai.SelectedValue = dgvTaiKhoan.Rows[r].Cells[2].Value.ToString();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            cmbTenDangNhap.ResetText();
            txtMatKhau.ResetText();
            txtMaLoai.ResetText();
            txtHo.ResetText();
            txtTen.ResetText();
            cmbTenLoai.ResetText();

            cmbTenDangNhap.Enabled = true;
            txtMatKhau.Enabled = true;
            txtMaLoai.Enabled = true;
            txtHo.Enabled = true;
            txtTen.Enabled = true;
            cmbTenLoai.Enabled = true;

            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmbTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = true;
            txtMaLoai.Enabled = true;
            txtHo.Enabled = true;
            txtTen.Enabled = true;
            cmbTenLoai.Enabled = true;

            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cmbTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = false;
            txtMaLoai.Enabled = false;
            txtHo.Enabled = false;
            txtTen.Enabled = false;
            cmbTenLoai.Enabled = false;

            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                string err = "";
                bool themThanhCong = bLTaiKhoan.ThemTaiKhoan(
                    cmbTenDangNhap.SelectedItem.ToString(),
                    txtMatKhau.Text,
                    cmbTenLoai.SelectedValue.ToString(),
                    ref err);
                if (themThanhCong)
                {
                    LoadData();
                    MessageBox.Show("Đã thêm xong!");
                }
                else
                {
                    MessageBox.Show("Không thêm được. Lỗi: " + err);
                }
            }
            else
            {
                bLTaiKhoan.CapNhatTaiKhoan(
                    cmbTenDangNhap.SelectedItem.ToString(),
                    txtMatKhau.Text,
                    cmbTenLoai.SelectedValue.ToString(),
                    ref err);
                LoadData();
                MessageBox.Show("Đã sửa xong!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?  
            if (traloi == DialogResult.OK)
            {
                frmMenuQuanTriVien frmMenuQuanTriVien = new frmMenuQuanTriVien(userName);
                frmMenuQuanTriVien.Show();
                this.Hide();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dgvTaiKhoan.CurrentCell.RowIndex;

            string TenDangNhap = dgvTaiKhoan.Rows[r].Cells[0].Value.ToString();

            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp  
            traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?  
            if (traloi == DialogResult.Yes)
            {

                bLTaiKhoan.XoaTaiKhoan(ref err, TenDangNhap);

                // Cập nhật lại DataGridView  
                LoadData();
                // Thông báo  
                MessageBox.Show("Đã xóa xong!");
            }
            else
            {
                // Thông báo  
                MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
            }
        }

        private void cmbTenLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaLoai.Text = cmbTenLoai.SelectedValue.ToString();
        }
    }
}
