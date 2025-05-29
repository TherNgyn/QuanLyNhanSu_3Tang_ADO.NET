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
    public partial class frmCapNhatMatKhau : Form
    {
        String userName;
        BLTaiKhoan bLTaiKhoan;
        string err;

        public frmCapNhatMatKhau(String username)
        {
            InitializeComponent();
            userName = username;
            bLTaiKhoan = new BLTaiKhoan();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?  
            if (traloi == DialogResult.OK)
            {
                frmMenuNhanVien frmMenuNhanVien = new frmMenuNhanVien(userName);
                frmMenuNhanVien.Show();
                this.Hide();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == txtXacNhanMatKhau.Text)
            {
                bLTaiKhoan.CapNhatMatKhau(userName, txtXacNhanMatKhau.Text, ref err);
                MessageBox.Show("Đã cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Mật Khẩu và Xác Nhận Mật Khẩu không giống nhau. Vui lòng nhập lại");
            }
        }

        private void frmCapNhatMatKhau_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = userName;
            txtTaiKhoan.Enabled = false;
        }
    }
}
