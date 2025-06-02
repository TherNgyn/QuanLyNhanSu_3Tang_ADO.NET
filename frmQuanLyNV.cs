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

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmQuanLyNV : Form
    {
        DataTable dtNhanVien = null;
        DataTable dtGioiTinh = null;
        DataTable dtPhongBan = null;
        DataTable dtCV;
        bool Them;
        string err;
        BLNhanVien bLNhanVien;
        BLTaiKhoan bLTaiKhoan;
        BLChucVu bLChucVu;
        BLPhongBan bLPhongBan = new BLPhongBan();
        String userName;
        String roleName;

        public frmQuanLyNV(String username)
        {
            this.userName = username;
            bLNhanVien = new BLNhanVien();
            bLTaiKhoan = new BLTaiKhoan();
            bLChucVu = new BLChucVu();
            InitializeComponent();
            this.roleName = bLTaiKhoan.LayRoleName(username);
            LoadData();
        }
        void LoadData()
        {
            txtMaNhanVien.Enabled = false;
            txtHo.Enabled = false;
            txtTen.Enabled = false;
            cmbGioiTinh.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            txtCCCD.Enabled = false;
            cmbTenPB.Enabled = false;
            cmbTenCV.Enabled = false;

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;

            if (roleName.Trim().Equals("TruongPhong", StringComparison.OrdinalIgnoreCase))
            {
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                DataSet ds = bLNhanVien.LayNhanVien1PBCV(userName);
                dtNhanVien = ds.Tables[0];

                dgvNhanVien.DataSource = dtNhanVien;

                dtGioiTinh = new DataTable();
                dtGioiTinh.Clear();
                DataSet ds1 = bLNhanVien.TongNhanVienTheoGioiTinh1PB(userName);
                dtGioiTinh = ds1.Tables[0];

                dgvGioiTinh.DataSource = dtGioiTinh;

                dtPhongBan = new DataTable();
                dtPhongBan.Clear();
                DataSet ds2 = bLNhanVien.TongNhanVienTheoPhongBan1PB(userName);
                dtPhongBan = ds2.Tables[0];

                dgvPhongBan.DataSource = dtPhongBan;
            }
            else
            {
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                DataSet ds = bLNhanVien.LayNhanVienPBCV();
                dtNhanVien = ds.Tables[0];

                dgvNhanVien.DataSource = dtNhanVien;

                dtGioiTinh = new DataTable();
                dtGioiTinh.Clear();
                DataSet ds1 = bLNhanVien.TongNhanVienTheoGioiTinh();
                dtGioiTinh = ds1.Tables[0];

                dgvGioiTinh.DataSource = dtGioiTinh;

                dtPhongBan = new DataTable();
                dtPhongBan.Clear();
                DataSet ds2 = bLNhanVien.TongNhanVienTheoPhongBan();
                dtPhongBan = ds2.Tables[0];

                dgvPhongBan.DataSource = dtPhongBan;
            }


        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel12_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = false;
            txtHo.Enabled = false;
            txtTen.Enabled = false;
            cmbGioiTinh.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            txtCCCD.Enabled = false;
            cmbTenPB.Enabled = false;
            cmbTenCV.Enabled = false;

            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaNhanVien.ResetText();
            txtHo.ResetText();
            txtTen.ResetText();
            cmbGioiTinh.ResetText();
            dtpNgaySinh.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtEmail.ResetText();
            txtCCCD.ResetText();
            cmbTenPB.ResetText();
            cmbTenCV.ResetText();

            txtMaNhanVien.Enabled = true;
            txtHo.Enabled = true;
            txtTen.Enabled = true;
            cmbGioiTinh.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            txtCCCD.Enabled = true;
            cmbTenPB.Enabled = true;
            cmbTenCV.Enabled = true;

            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?  
            if (traloi == DialogResult.OK)
            {
                IsClosingFromBackButton = true;
                if (roleName.Trim().Equals("QuanTriVien", StringComparison.OrdinalIgnoreCase))
                {
                    frmMenuQuanTriVien frmMenuQuanTriVien = new frmMenuQuanTriVien(userName);
                    frmMenuQuanTriVien.Show();
                    this.Close();
                }
                else
                {
                    frmMenuTruongPhong frmTP = new frmMenuTruongPhong(userName);
                    frmTP.Show();
                    this.Close();
                }

            }
        }

        private void guna2HtmlLabel13_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            dtNhanVien = new DataTable();
            dtNhanVien.Clear();
            DataSet ds = new DataSet();
            if (roleName == "TruongPhong")
            {
                ds = bLNhanVien.TimNhanVienTheoMa1PB(txtTimKiem.Text, userName);

            }
            else
            {
                ds = bLNhanVien.TimNhanVienTheoMa(txtTimKiem.Text);

            }
            dtNhanVien = ds.Tables[0];
            dgvNhanVien.DataSource = dtNhanVien;
        }

        private void guna2HtmlLabel14_Click(object sender, EventArgs e)
        {

        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvNhanVien.CurrentCell.RowIndex;

            txtMaNhanVien.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            txtHo.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            txtTen.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString();
            cmbGioiTinh.SelectedItem = dgvNhanVien.Rows[r].Cells[3].Value.ToString().Trim();
            dtpNgaySinh.Value = Convert.ToDateTime(dgvNhanVien.Rows[r].Cells[4].Value);
            txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString();
            txtEmail.Text = dgvNhanVien.Rows[r].Cells[7].Value.ToString();
            txtCCCD.Text = dgvNhanVien.Rows[r].Cells[8].Value.ToString();
            cmbTenPB.SelectedValue = dgvNhanVien.Rows[r].Cells[9].Value.ToString();
            cmbTenCV.SelectedValue = dgvNhanVien.Rows[r].Cells[10].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                string err = "";

                bool themThanhCong = bLNhanVien.ThemNhanVien(
                    txtMaNhanVien.Text,
                    txtHo.Text, txtTen.Text,
                    cmbGioiTinh.SelectedItem.ToString(),
                    dtpNgaySinh.Value.Date,
                    txtDiaChi.Text,
                    txtSDT.Text,
                    txtEmail.Text,
                    txtCCCD.Text,
                    cmbTenPB.SelectedValue.ToString(),
                    cmbTenCV.SelectedValue.ToString(),
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
                //MessageBox.Show(cmbTenCV.SelectedValue.ToString());
                bool suaThanhCong =bLNhanVien.CapNhatNhanVien(txtMaNhanVien.Text,
                    txtHo.Text, txtTen.Text,
                    cmbGioiTinh.SelectedItem.ToString(),
                    dtpNgaySinh.Value.Date,
                    txtDiaChi.Text,
                    txtSDT.Text,
                    txtEmail.Text,
                    txtCCCD.Text,
                    cmbTenPB.SelectedValue.ToString(),
                    cmbTenCV.SelectedValue.ToString(),
                    ref err);
                LoadData();
                if (suaThanhCong)
                {
                    MessageBox.Show("Đã sửa xong!");
                }
                else
                {
                    MessageBox.Show("Không sửa được. Lỗi: " + err);

                }
            }
            // Đóng kết nối 

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;

            txtMaNhanVien.Enabled = false;
            txtHo.Enabled = true;
            txtTen.Enabled = true;
            cmbGioiTinh.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            txtCCCD.Enabled = true;
            cmbTenPB.Enabled = true;
            cmbTenCV.Enabled = true;

            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dgvNhanVien.CurrentCell.RowIndex;

            string MaNV = dgvNhanVien.Rows[r].Cells[0].Value.ToString();

            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp  
            traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?  
            if (traloi == DialogResult.Yes)
            {

                bLNhanVien.XoaNhanVien(ref err, MaNV);

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

        private void frmQuanLyNV_Load(object sender, EventArgs e)
        {
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            this.AutoScroll = true;
            if (roleName == "TruongPhong")
            {
                dtPhongBan = new DataTable();
                dtPhongBan.Clear();
                /*MessageBox.Show("" + userName);*/

                DataSet ds = bLPhongBan.LayPhongBanTheoTrP(userName);
                dtPhongBan = ds.Tables[0];

                cmbTenPB.DataSource = dtPhongBan;
                cmbTenPB.DisplayMember = "TenPB";     // Hiển thị chữ
                cmbTenPB.ValueMember = "MaPB";

                dtCV = new DataTable();
                dtCV.Clear();

                DataSet ds2 = bLChucVu.LayChucVuTheoTrP();
                dtCV = ds2.Tables[0];

                cmbTenCV.DataSource = dtCV;
                cmbTenCV.DisplayMember = "TenCV";
                cmbTenCV.ValueMember = "MaCV";
            }
            else
            {
                dtPhongBan = new DataTable();
                dtPhongBan.Clear();
                DataSet ds = bLPhongBan.LayPhongBan();
                dtPhongBan = ds.Tables[0];

                cmbTenPB.DataSource = dtPhongBan;
                cmbTenPB.DisplayMember = "TenPB";     // Hiển thị chữ
                cmbTenPB.ValueMember = "MaPB";

                dtCV = new DataTable();
                dtCV.Clear();
                DataSet ds2 = bLChucVu.LayChucVu();
                dtCV = ds2.Tables[0];

                cmbTenCV.DataSource = dtCV;
                cmbTenCV.DisplayMember = "TenCV";
                cmbTenCV.ValueMember = "MaCV";
            }

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmQuanLyNV_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {

                if (!IsClosingFromBackButton)
                {
                    if (roleName.Trim().Equals("QuanTriVien", StringComparison.OrdinalIgnoreCase))
                    {
                        frmMenuQuanTriVien frmMenuQuanTriVien = new frmMenuQuanTriVien(userName);
                        frmMenuQuanTriVien.Show();

                    }
                    else if (roleName.Trim().Equals("TruongPhong", StringComparison.OrdinalIgnoreCase))
                    {
                        frmMenuTruongPhong frmTP = new frmMenuTruongPhong(userName);
                        frmTP.Show();

                    }
                }
            }
        }
        private bool IsClosingFromBackButton = false;

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaNhanVien.ResetText();
            txtHo.ResetText();
            txtTen.ResetText();
            cmbGioiTinh.ResetText();
            dtpNgaySinh.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtEmail.ResetText();
            txtCCCD.ResetText();
            cmbTenPB.ResetText();
            cmbTenCV.ResetText();

            txtMaNhanVien.Enabled = true;
            txtHo.Enabled = true;
            txtTen.Enabled = true;
            cmbGioiTinh.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            txtCCCD.Enabled = true;
            cmbTenPB.Enabled = true;
            cmbTenCV.Enabled = true;

            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = false;
            txtHo.Enabled = false;
            txtTen.Enabled = false;
            cmbGioiTinh.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            txtCCCD.Enabled = false;
            cmbTenPB.Enabled = false;
            cmbTenCV.Enabled = false;

            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtNhanVien = new DataTable();
            dtNhanVien.Clear();
            DataSet ds = new DataSet();
            if (roleName == "TruongPhong")
            {
                ds = bLNhanVien.TimNhanVienTheoMa1PB(txtTimKiem.Text, userName);

            }
            else
            {
                ds = bLNhanVien.TimNhanVienTheoMa(txtTimKiem.Text);

            }
            dtNhanVien = ds.Tables[0];
            dgvNhanVien.DataSource = dtNhanVien;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?  
            if (traloi == DialogResult.OK)
            {
                IsClosingFromBackButton = true;
                if (roleName.Trim().Equals("QuanTriVien", StringComparison.OrdinalIgnoreCase))
                {
                    frmMenuQuanTriVien frmMenuQuanTriVien = new frmMenuQuanTriVien(userName);
                    frmMenuQuanTriVien.Show();
                    this.Close();
                }
                else
                {
                    frmMenuTruongPhong frmTP = new frmMenuTruongPhong(userName);
                    frmTP.Show();
                    this.Close();
                }

            }
        }

        private void frmQuanLyNV_Load_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel12_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void txtMaNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
