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
    public partial class frmQuanLyThongBao : Form
    {
        DataTable dtThongBao = null;
        BLThongBao dbTB = new BLThongBao();
        bool Them;
        string err;

        public frmQuanLyThongBao()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            dtThongBao = dbTB.LayThongBao().Tables[0];
            dgvThongBao.DataSource = dtThongBao;
            if (dgvThongBao.Columns.Contains("Id"))
                dgvThongBao.Columns["Id"].Visible = true;
            dgvThongBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Load combo box phòng ban
            cbbPhongBan.DataSource = dbTB.LayDanhSachPhongBan();
            cbbPhongBan.DisplayMember = "TenPB";
            cbbPhongBan.ValueMember = "MaPB";
            cbbPhongBan.SelectedIndex = -1;

            // Reset
            txtTieuDe.Clear();
            txtNoiDung.Clear();
            dtpNgayGui.Value = DateTime.Now; 

            txtNoiDung.Enabled = false;
            txtTieuDe.Enabled = false;
            dtpNgayGui.Enabled = false;
            cbbPhongBan.Enabled = false;

            btnThem.Enabled = true;
            btnThoat.Enabled = true;
            btnSua.Enabled = true;
            btnLamMoi.Enabled = true;
            btnXoa.Enabled = true;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }



        private void frmQuanLyThongBao_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            txtTieuDe.Clear();
            txtNoiDung.Clear();
            cbbPhongBan.SelectedIndex = -1;
            dtpNgayGui.Value = DateTime.Now;

            txtNoiDung.Enabled = true;
            txtTieuDe.Enabled = true;
            dtpNgayGui.Enabled = true;
            cbbPhongBan.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnThoat.Enabled = false;

            txtTieuDe.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;


            txtNoiDung.Enabled = true;
            txtTieuDe.Enabled = true;
            dtpNgayGui.Enabled = true;
            cbbPhongBan.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnThoat.Enabled = false;

            txtTieuDe.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThongBao.CurrentRow != null && int.TryParse(dgvThongBao.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                DialogResult result = MessageBox.Show("Chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (dbTB.XoaThongBao(id, ref err))
                    {
                        LoadData();
                        MessageBox.Show("Đã xóa thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được. Lỗi: " + err);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                bool result = dbTB.ThemThongBao(
                    txtTieuDe.Text,
                    txtNoiDung.Text,
                    cbbPhongBan.SelectedValue.ToString(),
                    dtpNgayGui.Value,
                    ref err);
                if (result)
                {
                    LoadData();
                    MessageBox.Show("Đã thêm thành công!");
                }
                else
                {
                    MessageBox.Show("Không thêm được. Lỗi: " + err);
                }
            }
            else
            {
                if (dgvThongBao.CurrentRow != null && int.TryParse(dgvThongBao.CurrentRow.Cells[0].Value.ToString(), out int id))
                {
                    bool result = dbTB.CapNhatThongBao(
                        id,
                        txtTieuDe.Text,
                        txtNoiDung.Text,
                        cbbPhongBan.SelectedValue.ToString(),
                        dtpNgayGui.Value,
                        ref err);
                    if (result)
                    {
                        LoadData();
                        MessageBox.Show("Đã cập nhật thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không cập nhật được. Lỗi: " + err);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTieuDe.ResetText();
            txtNoiDung.ResetText();
            cbbPhongBan.SelectedIndex = -1;
            dtpNgayGui.Value = DateTime.Now;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTieuDe.Enabled = false;
            txtNoiDung.Enabled = false;
            cbbPhongBan.Enabled = false;
            dtpNgayGui.Enabled = false;

            dgvThongBao_CellContentClick(null, null);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTieuDe.ResetText();
            txtNoiDung.ResetText();
            cbbPhongBan.SelectedIndex = -1;
            dtpNgayGui.Value = DateTime.Now;

            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Chắc chắn thoát?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK) this.Close();
        }

        private void dgvThongBao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtTieuDe.Text = dgvThongBao.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                txtNoiDung.Text = dgvThongBao.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                cbbPhongBan.SelectedValue = dgvThongBao.Rows[e.RowIndex].Cells[4].Value?.ToString() ?? "";
                dtpNgayGui.Value = Convert.ToDateTime(dgvThongBao.Rows[e.RowIndex].Cells[3].Value);
            }
        }
    }
}
