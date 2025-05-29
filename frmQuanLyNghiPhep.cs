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
    public partial class frmQuanLyNghiPhep : Form
    {
        DataTable dtNP = null;
        bool Them;
        string err;
        BLNghiPhep dbNP = new BLNghiPhep();
        private DataTable dtThang;


        public frmQuanLyNghiPhep()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                dtNP = dbNP.LayNghiPhep().Tables[0];
                dgvNghiPhep.AutoGenerateColumns = false;
                dgvNghiPhep.DataSource = dtNP;
                dgvNghiPhep.AutoResizeColumns();

                txtMaNV.ResetText();
                cbbMaThang.SelectedIndex = -1;
                txtNgayNghi.ResetText();
                txtLyDo.ResetText();
                txtTimKiemMaNV.ResetText();

                txtMaNV.Enabled = false;
                txtNgayNghi.Enabled = false;
                txtLyDo.Enabled = false;
                cbbMaThang.Enabled = false;

                txtTimKiemMaNV.Enabled = true;
                btnTimKiem.Enabled = true;

                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThoat.Enabled = true;

                dgvNghiPhep_CellContentClick(null, null);
                LoadComboBoxThang();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu nghỉ phép. Lỗi rồi!");
            }
        }

        void LoadComboBoxThang()
        {
            string query = "SELECT MaThang, MoTa FROM Thang";
            using (SqlConnection conn = new SqlConnection(DBMain.connectString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                dtThang = new DataTable();
                da.Fill(dtThang);
                cbbMaThang.DataSource = dtThang;
                cbbMaThang.DisplayMember = "MoTa";
                cbbMaThang.ValueMember = "MaThang";
            }
        }



        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvNghiPhep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvNghiPhep.CurrentCell.RowIndex;

            // Gán mã NV
            txtMaNV.Text = dgvNghiPhep.Rows[r].Cells[0].Value?.ToString() ?? "";

            // Gán ngày nghỉ
            txtNgayNghi.Text = dgvNghiPhep.Rows[r].Cells[1].Value?.ToString() ?? "";

            // Lấy mô tả tháng (TenThang)
            string tenThang = dgvNghiPhep.Rows[r].Cells[2].Value?.ToString() ?? "";

            // Tìm mã tháng tương ứng từ ComboBox
            if (!string.IsNullOrEmpty(tenThang))
            {
                foreach (DataRowView item in cbbMaThang.Items)
                {
                    if (item["MoTa"].ToString() == tenThang)
                    {
                        cbbMaThang.SelectedValue = item["MaThang"];
                        break;
                    }
                }
            }
            else
            {
                cbbMaThang.SelectedIndex = -1;
            }

            // Gán lý do
            txtLyDo.Text = dgvNghiPhep.Rows[r].Cells[3].Value?.ToString() ?? "";


        }

        private void frmQuanLyNghiPhep_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxThang();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaNV.Enabled = true;
            cbbMaThang.Enabled = true;

            txtMaNV.Clear();
            cbbMaThang.SelectedIndex = -1;
            txtNgayNghi.Clear();
            txtLyDo.Clear();

            txtMaNV.Enabled = true;
            txtNgayNghi.Enabled = true;
            txtLyDo.Enabled = true;
            cbbMaThang.Enabled = true;

            txtTimKiemMaNV.Enabled = false;
            btnTimKiem.Enabled = false;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            txtMaNV.Enabled = false;
            cbbMaThang.Enabled = false;

            txtMaNV.Enabled = true;
            txtNgayNghi.Enabled = true;
            txtLyDo.Enabled = true;

            txtTimKiemMaNV.Enabled = false;
            btnTimKiem.Enabled = false;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dgvNghiPhep.CurrentCell.RowIndex;
            string maNV = dgvNghiPhep.Rows[r].Cells[0].Value?.ToString() ?? "";
            string maThang = cbbMaThang.SelectedValue?.ToString() ?? ""; // Lấy MaThang từ combobox

            DialogResult traloi = MessageBox.Show("Chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (traloi == DialogResult.Yes)
            {
                if (dbNP.XoaNghiPhep(maNV, maThang, ref err))
                {
                    LoadData();
                    MessageBox.Show("Đã xóa!");
                }
                else
                {
                    MessageBox.Show("Lỗi: " + err);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                cbbMaThang.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtNgayNghi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            int ngayNghi;
            if (!int.TryParse(txtNgayNghi.Text, out ngayNghi))
            {
                MessageBox.Show("Ngày nghỉ phải là số nguyên!");
                return;
            }

            string maThang = cbbMaThang.SelectedValue.ToString();

            bool result = Them ?
                dbNP.ThemNghiPhep(txtMaNV.Text, maThang, ngayNghi, txtLyDo.Text, ref err) :
                dbNP.CapNhatNghiPhep(txtMaNV.Text, maThang, ngayNghi, txtLyDo.Text, ref err);

            if (result)
            {
                LoadData();
                MessageBox.Show("Lưu thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi: " + err);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNV.ResetText();
            txtNgayNghi.ResetText();
            txtTimKiemMaNV.ResetText();
            txtLyDo.ResetText();

            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtNgayNghi.Clear();
            txtLyDo.Clear();
            txtTimKiemMaNV.Clear();
            cbbMaThang.SelectedIndex = -1; 

            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            DialogResult traloi = MessageBox.Show("Chắc chắn thoát?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maNV = this.txtTimKiemMaNV.Text.Trim();
            DataRow[] rows = dtNP.Select($"MaNV = '{maNV}'");
            if (rows.Length > 0)
            {
                DataTable result = dtNP.Clone();
                foreach (var row in rows)
                    result.ImportRow(row);
                dgvNghiPhep.DataSource = result;
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã nhân viên này!");
                dgvNghiPhep.DataSource = dtNP;
            }
        }
    }
}
