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
    public partial class frmMenuQuanTriVien : Form
    {
        String userName;
        BLNhanVien bLNhanVien;
        DataSet ds;
        string err;
        public frmMenuQuanTriVien(String username)
        {
            InitializeComponent();
            userName = username;
        }

        private void frmMenuQuanTriVien_Load(object sender, EventArgs e)
        {
            bLNhanVien = new BLNhanVien();
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
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
            txtSoDT.Enabled = false;
            txtEmail.Enabled = false;
            txtCCCD.Enabled = false;

            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            ds = bLNhanVien.LayNhanVienTheoMa(userName);
            DataTable dt = ds.Tables[0];
            DataRow dataRow = dt.Rows[0];
            txtMaNhanVien.Text = dataRow["MaNV"].ToString();
            txtHo.Text = dataRow["Ho"].ToString();
            txtTen.Text = dataRow["Ten"].ToString();
            cmbGioiTinh.SelectedItem = dataRow["GioiTinh"].ToString();
            DateTime ngaySinhValue = Convert.ToDateTime(dataRow["NgaySinh"]);
            dtpNgaySinh.Value = ngaySinhValue;
            txtDiaChi.Text = dataRow["DiaChi"].ToString();
            txtSoDT.Text = dataRow["SDT"].ToString();
            txtEmail.Text = dataRow["Email"].ToString();
            txtCCCD.Text = dataRow["CCCD"].ToString();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoan frmQuanLyTaiKhoan = new frmQuanLyTaiKhoan(userName);
            frmQuanLyTaiKhoan.Show();
            this.Hide();
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            err = "";
            DateTime ngaySinh = dtpNgaySinh.Value.Date;
            bLNhanVien.CapNhatNhanVien(txtMaNhanVien.Text, txtHo.Text, txtTen.Text, cmbGioiTinh.SelectedItem.ToString(), ngaySinh,
                txtDiaChi.Text, txtSoDT.Text, txtEmail.Text, txtCCCD.Text, ref err);
            LoadData();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            txtHo.ResetText();
            txtTen.ResetText();
            cmbGioiTinh.ResetText();
            dtpNgaySinh.ResetText();
            txtDiaChi.ResetText();
            txtSoDT.ResetText();
            txtEmail.ResetText();
            txtCCCD.ResetText();

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnSua.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtHo.Enabled = true;
            txtTen.Enabled = true;
            cmbGioiTinh.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSoDT.Enabled = true;
            txtEmail.Enabled = true;
            txtCCCD.Enabled = true;

            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            this.txtHo.Focus();
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?  
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            frmQuanLyNV frmQuanLyNV = new frmQuanLyNV(userName);
            frmQuanLyNV.Show();
          
        }

        private void btnQuanLyPhongBan_Click(object sender, EventArgs e)
        {
            frmQuanLyPhongBan frmQuanLyPhongBan = new frmQuanLyPhongBan(userName);
            frmQuanLyPhongBan.Show();
            
        }

        private void btnThongKeLuong_Click(object sender, EventArgs e)
        {
            frmThongKeLuongNhanVien frmTK = new frmThongKeLuongNhanVien();
            frmTK.Show();
            
        }
    }
}
