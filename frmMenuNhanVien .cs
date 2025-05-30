using Guna.UI2.WinForms;
using QuanLyNhanSu_3Tang_ADO.BS_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
        BLNhanVien blNV = new BLNhanVien();
        private Form currentChildForm;
        public frmMenuNhanVien(String username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void frmMenuNhanVien_Load(object sender, EventArgs e)
        {
            LoadThongTinNhanVien();
            OpenChildForm(new frmChamCong(userName));
        }
        private void LoadThongTinNhanVien()
        {
            try
            {
                DataSet ds = blNV.TimNhanVienTheoMa(userName);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    lblTenNV.Text = dt.Rows[0]["Ten"].ToString();
                    lblChucVu.Text = dt.Rows[0]["TenCV"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin nhân viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenChildForm(Form childForm)
        {

            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;


            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Thêm form con vào panel
            guna2PanelLoad.Controls.Clear();
            guna2PanelLoad.Controls.Add(childForm);
            guna2PanelLoad.Tag = childForm;

            // Hiển thị form con
            childForm.Show();
        }

        private void btnDangKyNghiPhep_Click(object sender, EventArgs e)
        {
            frmDangKyNghiPhep frm = new frmDangKyNghiPhep(userName);
            frm.ShowDialog();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            frmChamCong frmChamCong = new frmChamCong(userName);
            frmChamCong.ShowDialog();
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
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
        }

        private void btnXemLuong_Click(object sender, EventArgs e)
        {
            frmLuongNhanVien frmLuongNhanVien = new frmLuongNhanVien(userName);
            frmLuongNhanVien.ShowDialog();

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

        private void lblChucVu_Click(object sender, EventArgs e)
        {

        }
    }
}
