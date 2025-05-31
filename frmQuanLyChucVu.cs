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
    public partial class frmQuanLyChucVu : Form
    {
        DataTable dtChucVu = null;
        BLChucVu dbCV = new BLChucVu();
        bool Them;
        string err;
        string MaNV;
        public frmQuanLyChucVu(string maNV)
        {
            InitializeComponent();
            MaNV = maNV;
        }

        void LoadData()
        {
            try
            {
                dtChucVu = dbCV.LayChucVu().Tables[0];
                dgvChucVu.DataSource = dtChucVu;
                dgvChucVu.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvChucVu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                txtMaCV.ResetText();
                txtTenCV.ResetText();

                txtMaCV.Enabled = false;
                txtTenCV.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;


                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThoat.Enabled = true;

                dgvChucVu_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu chức vụ.");
            }
        }




        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaCV.ResetText();
            txtTenCV.ResetText();
            txtMaCV.Enabled = true;
            txtTenCV.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;

            txtMaCV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtTenCV.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;

            txtMaCV.Enabled = false;
            txtTenCV.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (traloi == DialogResult.Yes)
            {
                bool result = dbCV.XoaChucVu(txtMaCV.Text, ref err);
                if (result)
                {
                    LoadData();
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    MessageBox.Show("Không xóa được. Lỗi: " + err);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                bool result = dbCV.ThemChucVu(txtMaCV.Text, txtTenCV.Text, ref err);
                if (result)
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
                bool result = dbCV.CapNhatChucVu(txtMaCV.Text, txtTenCV.Text, ref err);
                if (result)
                {
                    LoadData();
                    MessageBox.Show("Đã cập nhật xong!");
                }
                else
                {
                    MessageBox.Show("Không sửa được. Lỗi: " + err);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaCV.ResetText();
            txtTenCV.ResetText();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtTenCV.Enabled = false;
            txtMaCV.Enabled = false;

            dgvChucVu_CellClick(null, null);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaCV.Clear();
            txtTenCV.Clear();

            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Chắc chắn thoát?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                /*frmMenuQuanTriVien frm = new frmMenuQuanTriVien(MaNV);
                frm.ShowDialog();*/
                this.Close();
            }
        }


        private void frmQuanLyChucVu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvChucVu.CurrentCell.RowIndex;
            txtMaCV.Text = dgvChucVu.Rows[r].Cells[0].Value.ToString();
            txtTenCV.Text = dgvChucVu.Rows[r].Cells[1].Value.ToString();
        }

        private void frmQuanLyChucVu_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMenuQuanTriVien frm = new frmMenuQuanTriVien(MaNV);
            frm.Show();
        }
    }
}
