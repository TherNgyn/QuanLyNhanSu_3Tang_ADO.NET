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
    public partial class frmDangNhap : Form
    {
        BLTaiKhoan bLTaiKhoan;
        public frmDangNhap()
        {
            InitializeComponent();
            bLTaiKhoan = new BLTaiKhoan();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string roleName = string.Empty;

            string authResult = bLTaiKhoan.AuthenticateUser(username, password, out roleName);

            if (authResult == "SUCCESS")
            {
                MessageBox.Show($"Đăng nhập thành công! Chào mừng {roleName}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (roleName == "NhanVien")
                {
                    frmMenuNhanVien menuNhanVien = new frmMenuNhanVien(username.ToUpper());
                    menuNhanVien.Show();
                    this.Hide();
                }
                else if (roleName == "QuanTriVien")
                {
                    frmMenuQuanTriVien menuQuanTriVien = new frmMenuQuanTriVien(username.ToUpper());
                    menuQuanTriVien.Show();
                    this.Hide();
                }
                else
                {
                    frmMenuTruongPhong menuTruongPhong = new frmMenuTruongPhong(username.ToUpper());
                    menuTruongPhong.Show();
                    this.Hide();
                }
            }
            else
            {
                //lblMessage.Text = authResult;
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show(authResult);
            }
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?  
            if (traloi == DialogResult.OK)
            {
                CloseAllForms();
                Application.Exit();
            }
        }
        private void CloseAllForms()
        {

            List<Form> openForms = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                openForms.Add(form);
            }


            foreach (Form form in openForms)
            {

                if (form != this && !form.IsDisposed)
                {
                    form.Close();
                }
            }
        }

        private void pnLoad_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
