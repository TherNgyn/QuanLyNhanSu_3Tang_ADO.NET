using QuanLyNhanSu_3Tang_ADO.BS_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmQuanLyPhongBan : Form
    {
        DataTable dtMaNV;
        DataTable dtPhongBan;
        DataTable dtSoLuong;
        BLPhongBan bLPhongBan;
        BLNhanVien bLNhanVien;
        BLTaiKhoan bLTaiKhoan;
        String userName;
        bool Them;
        string err;
        String roleName = null;

        public frmQuanLyPhongBan(string userName)
        {
            InitializeComponent();
            bLPhongBan = new BLPhongBan();
            bLNhanVien = new BLNhanVien();
            bLTaiKhoan = new BLTaiKhoan();
            this.userName = userName;
            roleName = bLTaiKhoan.LayRoleName(userName);
            LoadData();

        }

        void LoadData()
        {
            txtMaPB.Enabled = false;
            txtTenPB.Enabled = false;
            txtSDT.Enabled = false;
            cmbMaTrP.Enabled = false;
            txtHo.Enabled = false;
            txtTen.Enabled = false;

            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            if (roleName == "TruongPhong")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                dtPhongBan = new DataTable();
                dtPhongBan.Clear();
                DataSet ds = bLPhongBan.LayPhongBanTheoTrP(userName);
                dtPhongBan = ds.Tables[0];

                dgvPhongBan.DataSource = dtPhongBan;

                dtSoLuong = new DataTable();
                dtSoLuong.Clear();
                DataSet ds2 = bLPhongBan.TongSoLuongNhanVienCua1PhongBan(userName);
                dtSoLuong = ds2.Tables[0];

                dgvSoLuong.DataSource = dtSoLuong;
            }
            else
            {
                dtPhongBan = new DataTable();
                dtPhongBan.Clear();
                DataSet ds = bLPhongBan.LayPhongBan();
                dtPhongBan = ds.Tables[0];

                dgvPhongBan.DataSource = dtPhongBan;

                dtSoLuong = new DataTable();
                dtSoLuong.Clear();
                DataSet ds2 = bLPhongBan.TongSoLuongNhanVienTheoPhongBan();
                dtSoLuong = ds2.Tables[0];

                dgvSoLuong.DataSource = dtSoLuong;
            }

        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvPhongBan.CurrentCell.RowIndex;
            String MaTrP = dgvPhongBan.Rows[r].Cells[3].Value.ToString();
            txtMaPB.Text = dgvPhongBan.Rows[r].Cells[0].Value.ToString(); ;
            txtTenPB.Text = dgvPhongBan.Rows[r].Cells[1].Value.ToString();
            txtSDT.Text = dgvPhongBan.Rows[r].Cells[2].Value.ToString();
            cmbMaTrP.SelectedValue = dgvPhongBan.Rows[r].Cells[3].Value.ToString();
            txtHo.Text = dgvPhongBan.Rows[r].Cells[4].Value.ToString();
            txtTen.Text = dgvPhongBan.Rows[r].Cells[5].Value.ToString();

            dtSoLuong.Clear();
            DataSet ds2 = bLPhongBan.TongSoLuongNhanVienCua1PhongBan(MaTrP);
            dtSoLuong = ds2.Tables[0];

            dgvSoLuong.DataSource = dtSoLuong;
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaPB.ResetText();
            txtTenPB.ResetText();
            txtSDT.ResetText();
            cmbMaTrP.ResetText();
            txtHo.ResetText();
            txtTen.ResetText();

            txtMaPB.Enabled = true;
            txtTenPB.Enabled = true;
            txtSDT.Enabled = true;
            cmbMaTrP.Enabled = true;
            txtHo.Enabled = false;
            txtTen.Enabled = false;

            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            txtMaPB.Enabled = false;
            txtTenPB.Enabled = false;
            txtSDT.Enabled = false;
            cmbMaTrP.Enabled = false;
            txtHo.Enabled = false;
            txtTen.Enabled = false;

            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            if (roleName == "TruongPhong")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Them = false;
            txtMaPB.Enabled = false;
            txtTenPB.Enabled = true;
            txtSDT.Enabled = true;
            cmbMaTrP.Enabled = true;
            txtHo.Enabled = true;
            txtTen.Enabled = true;

            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void frmQuanLyPhongBan_Load(object sender, EventArgs e)
        {

            this.AutoScroll = true;
            dtMaNV = new DataTable();
            dtMaNV.Clear();
            if (roleName == "TruongPhong")
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("MaNV");

                dt.Rows.Add(userName); // gán cả mã và tên bằng userName

                cmbMaTrP.DataSource = dt;
                cmbMaTrP.DisplayMember = "MaNV";
                cmbMaTrP.ValueMember = "MaNV";
            }
            else
            {
                DataSet ds2 = bLNhanVien.LayTatCaMaNhanVien();
                dtMaNV = ds2.Tables[0];

                cmbMaTrP.DataSource = dtMaNV;
                cmbMaTrP.DisplayMember = "MaNV";
                cmbMaTrP.ValueMember = "MaNV";
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dgvPhongBan.CurrentCell.RowIndex;

            string MaPB = dgvPhongBan.Rows[r].Cells[0].Value.ToString();

            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp  
            traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?  
            if (traloi == DialogResult.Yes)
            {

                bLPhongBan.XoaPhongBan(ref err, MaPB);

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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                string err = "";
                bool themThanhCong = bLPhongBan.ThemPhongBan(
                    txtMaPB.Text,
                    txtTenPB.Text,
                    txtSDT.Text,
                    cmbMaTrP.SelectedValue.ToString(),
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
                bLPhongBan.CapNhatPhongBan(
                    txtMaPB.Text,
                    txtTenPB.Text,
                    txtSDT.Text,
                    cmbMaTrP.SelectedValue.ToString(),
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
                this.Close();

            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmQuanLyPhongBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (roleName == "TruongPhong")
            {
                frmMenuTruongPhong frmMenuTruongPhong = new frmMenuTruongPhong(userName);
                frmMenuTruongPhong.Show();
                this.Hide();
            }
            else
            {
                frmMenuQuanTriVien frmMenuQuanTriVien = new frmMenuQuanTriVien(userName);
                frmMenuQuanTriVien.Show();
                this.Hide();
            }
        }
    }
}
