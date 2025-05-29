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

        bool Them;
        string err;
        BLNhanVien bLNhanVien;
        String userName;
        public frmQuanLyNV(String username)
        {
            userName = username;
            bLNhanVien = new BLNhanVien();
            InitializeComponent();
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
            txtTenPB.Enabled = false;
            txtTenCV.Enabled = false;

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;

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
            txtTenPB.Enabled = false;
            txtTenCV.Enabled = false;

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
            txtTenPB.ResetText();
            txtTenCV.ResetText();

            txtMaNhanVien.Enabled = true;
            txtHo.Enabled = true;
            txtTen.Enabled = true;
            cmbGioiTinh.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            txtCCCD.Enabled = true;
            txtTenPB.Enabled = true;
            txtTenCV.Enabled = true;

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
                frmMenuQuanTriVien frmMenuQuanTriVien = new frmMenuQuanTriVien(userName);
                frmMenuQuanTriVien.Show();
                this.Hide();
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
            DataSet ds = bLNhanVien.TimNhanVienTheoMa(txtTimKiem.Text);
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
            txtTenPB.Text = dgvNhanVien.Rows[r].Cells[9].Value.ToString();
            txtTenCV.Text = dgvNhanVien.Rows[r].Cells[10].Value.ToString();
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
                bLNhanVien.CapNhatNhanVien(txtMaNhanVien.Text,
                    txtHo.Text, txtTen.Text,
                    cmbGioiTinh.SelectedItem.ToString(),
                    dtpNgaySinh.Value.Date,
                    txtDiaChi.Text,
                    txtSDT.Text,
                    txtEmail.Text,
                    txtCCCD.Text, ref err);
                LoadData();
                MessageBox.Show("Đã sửa xong!");
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
            txtTenPB.Enabled = true;
            txtTenCV.Enabled = true;

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

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
