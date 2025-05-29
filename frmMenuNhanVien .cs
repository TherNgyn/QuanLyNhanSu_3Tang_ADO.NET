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
    public partial class frmMenuNhanVien : Form
    {
        String userName;
        public frmMenuNhanVien(String username)
        {
            InitializeComponent();
            userName = username;
        }

        private void frmMenuNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void btnDangKyNghiPhep_Click(object sender, EventArgs e)
        {
            frmDangKyNghiPhep frm = new frmDangKyNghiPhep(userName);
            frm.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở Form Chấm Công cho nhân viên.");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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

        private void btnXemLuong_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở Form Xem Lương cho nhân viên.");
        }

        private void btnDoiMatKhauNhanVien_Click(object sender, EventArgs e)
        {
            frmCapNhatMatKhau frmCapNhatMatKhau = new frmCapNhatMatKhau(userName);
            frmCapNhatMatKhau.Show();
            this.Hide();
        }

        private void btnXemThongBao_Click(object sender, EventArgs e)
        {
            frmXemThongBao frm = new frmXemThongBao(userName); 
            frm.ShowDialog();
        }
    }
}
