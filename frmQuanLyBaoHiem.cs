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
using System; 
using System.Windows.Forms;
using Microsoft.Data.SqlClient; 
using QuanLyNhanSu_3Tang_ADO.DB_Layer;
using Guna.UI2.WinForms;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmQuanLyBaoHiem : Form
    {
        DataTable dtBH = null;
        bool Them;
        string err;
        BLBaoHiem dbBH = new BLBaoHiem();

        public frmQuanLyBaoHiem()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                dtBH = dbBH.LayBaoHiem().Tables[0];
                dgvBaoHiem.AutoGenerateColumns = false;
                dgvBaoHiem.DataSource = dtBH;
                dgvBaoHiem.AutoResizeColumns();

                txtMaBH.ResetText();
                txtMaNV.ResetText();
     

                txtMaNV.ResetText();
                txtMaBH.ResetText();
                
                dtpNgayBD.Value = DateTime.Today;
                dtpNgayKT.Value = DateTime.Today;
                txtTimKiemMaBH.ResetText();

                txtMaBH.Enabled = false;
                txtMaNV.Enabled = false;
                cbbLoaiBH.Enabled = false;
                dtpNgayKT.Enabled = false;
                dtpNgayBD.Enabled = false;

                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
                guna2Panel1.Enabled = true;

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThoat.Enabled = true;
                txtTimKiemMaBH.Enabled = true;
                btnTimKiem.Enabled = true;

                dgvBaoHiem_CellContentClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu bảo hiểm. Lỗi rồi!");
            }
        }

        private void LoadLoaiBaoHiem()
        {
            DataTable dt = dbBH.LayLoaiBaoHiem();
            cbbLoaiBH.DataSource = dt;
            cbbLoaiBH.DisplayMember = "TenBH";
            cbbLoaiBH.ValueMember = "MaLoai";
        }





        private void guna2GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLyBaoHiem_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadLoaiBaoHiem();
        }

        private void dgvBaoHiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBaoHiem.CurrentCell == null || dgvBaoHiem.CurrentRow == null)
                return;

            int r = dgvBaoHiem.CurrentCell.RowIndex;
            var cellNgayBD = dgvBaoHiem.Rows[r].Cells[4].Value;
            var cellNgayKT = dgvBaoHiem.Rows[r].Cells[5].Value;

            txtMaNV.Text = dgvBaoHiem.Rows[r].Cells[0].Value?.ToString() ?? "";
            txtMaBH.Text = dgvBaoHiem.Rows[r].Cells[1].Value?.ToString() ?? "";
            cbbLoaiBH.Text = dgvBaoHiem.Rows[r].Cells[3].Value?.ToString() ?? "";

            dtpNgayBD.Value = cellNgayBD != null && cellNgayBD != DBNull.Value ? Convert.ToDateTime(cellNgayBD) : DateTime.Today;
            dtpNgayKT.Value = cellNgayKT != null && cellNgayKT != DBNull.Value ? Convert.ToDateTime(cellNgayKT) : DateTime.Today;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaNV.ResetText();
            txtMaBH.ResetText();
            dtpNgayBD.Value = DateTime.Today;
            dtpNgayKT.Value = DateTime.Today;
            txtTimKiemMaBH.ResetText();
            guna2GroupBox3.Enabled = true;
            txtMaNV.Enabled = true;
            txtMaBH.Enabled = true;
            cbbLoaiBH.Enabled = true;
            dtpNgayBD.Enabled = true;
            dtpNgayKT.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            guna2Panel1.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTimKiem.Enabled = false;
            txtTimKiemMaBH.Enabled=false;
            btnThoat.Enabled = false;

            txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            guna2GroupBox3.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            guna2Panel1.Enabled = true;
            dgvBaoHiem_CellContentClick(null, null); 
            txtMaNV.Enabled = true; 
            cbbLoaiBH.Enabled = true;
            dtpNgayBD.Enabled = true;
            dtpNgayKT.Enabled = true;


            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled=false;
            btnTimKiem.Enabled = false;
            txtTimKiemMaBH.Enabled = false;


            txtMaNV.Focus();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvBaoHiem.CurrentCell.RowIndex;
                string maBH = dgvBaoHiem.Rows[r].Cells[1].Value.ToString();

                DialogResult traloi = MessageBox.Show("Chắc xóa không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == DialogResult.Yes)
                {
                    dbBH.XoaBaoHiem(maBH, ref err);
                    LoadData();
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    MessageBox.Show("Không thực hiện việc xóa!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                if (string.IsNullOrWhiteSpace(txtMaBH.Text) || string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    txtMaBH.Focus();
                    return;
                }

                bool success = dbBH.ThemBaoHiem(txtMaNV.Text, txtMaBH.Text, cbbLoaiBH.SelectedValue.ToString(), dtpNgayBD.Value, dtpNgayKT.Value, ref err);
                if (success)
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
                bool success = dbBH.CapNhatBaoHiem(
                 txtMaNV.Text,
                 txtMaBH.Text,
                 cbbLoaiBH.SelectedValue.ToString(),
                 dtpNgayBD.Value,
                 dtpNgayKT.Value,
                 ref err
                );

                if (success)
                {
                    LoadData();
                    MessageBox.Show("Đã sửa xong!");
                }
                else
                {
                    MessageBox.Show("Không sửa được. Lỗi: " + err);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNV.ResetText();
            txtMaBH.ResetText();
            dtpNgayBD.Value = DateTime.Today;
            dtpNgayKT.Value = DateTime.Today;
            txtTimKiemMaBH.ResetText();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            dgvBaoHiem_CellContentClick(null, null);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtMaBH.Clear();
            txtTimKiemMaBH.Clear();
            cbbLoaiBH.SelectedIndex = -1;
            dtpNgayBD.Value = DateTime.Today;
            dtpNgayKT.Value = DateTime.Today;

            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Chắc chắn thoát?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maBH = this.txtTimKiemMaBH.Text.Trim();
            DataRow[] rows = dtBH.Select($"MaBH = '{maBH}'");
            if (rows.Length > 0)
            {
                DataTable result = dtBH.Clone();
                foreach (var row in rows)
                    result.ImportRow(row);
                dgvBaoHiem.DataSource = result;
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã bảo hiểm này!");
                dgvBaoHiem.DataSource = dtBH;
            }
        }
    }
}
