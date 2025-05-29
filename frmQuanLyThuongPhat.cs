using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhanSu_3Tang_ADO.BS_Layer;
using Guna.UI2.WinForms;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmQuanLyThuongPhat : Form
    {
        BLThuongPhat blTP = new BLThuongPhat();
        BLNhanVien blNV = new BLNhanVien();
        BLThang blThang = new BLThang();

        DataSet dsTP = new DataSet();
        DataSet dsCTTP = new DataSet();
        DataSet dsNV = new DataSet();
        DataSet dsThang = new DataSet();

        DataTable dtTP = new DataTable();
        DataTable dtCTTP = new DataTable();
        DataTable dtNV = new DataTable();
        DataTable dtThang = new DataTable();

        string maNV = "";
        string maTP = "";
        string maThang = "";
        int ngayTP = 0;

        public frmQuanLyThuongPhat()
        {
            InitializeComponent();
        }

        private void load()
        {
            try
            {
               
                dtTP.Clear();
                dtCTTP.Clear();
                dtNV.Clear();
                dtThang.Clear();

                dsTP = blTP.LayThuongPhat();
                dsCTTP = blTP.LayChiTietThuongPhat();
                dsNV = blNV.LayNhanVien();
                dsThang = blThang.LayThang();

                dtTP = dsTP.Tables[0];
                dtCTTP = dsCTTP.Tables[0];
                dtNV = dsNV.Tables[0];
                dtThang = dsThang.Tables[0];

                dataGridViewTP.DataSource = dtTP;
                dataGridViewCTTP.DataSource = dtCTTP;

                cbbMaNV.DataSource = dtNV;
                cbbMaNV.DisplayMember = "MaNV";
                cbbMaNV.ValueMember = "MaNV";

                cbbMaTP.DataSource = dtTP;
                cbbMaTP.DisplayMember = "MaThuongPhat";
                cbbMaTP.ValueMember = "MaThuongPhat";

                cbbMaThang.DataSource = dtThang;
                cbbMaThang.DisplayMember = "MaThang";
                cbbMaThang.ValueMember = "MaThang";

                txtMaTP.ResetText();
                txtTien.ResetText();
                txtLyDo.ResetText();
                txtNgayTP.ResetText();

                cbbLoai.SelectedIndex = 0;

                btnThoat.Enabled = true;
                btnLamMoi.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThemTPNV.Enabled = true;
                btnXoaTPNV.Enabled = true;
                btnSuaTPNV.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table. Lỗi rồi!!!");
            }
        }

        private void FormThuongPhat_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaTP.Text) ||
                    cbbLoai.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtTien.Text) ||
                    string.IsNullOrWhiteSpace(txtLyDo.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int soTien;
                if (!int.TryParse(txtTien.Text, out soTien))
                {
                    MessageBox.Show("Số tiền phải là số!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTien.Focus();
                    return;
                }

                string err = "";
                bool themThanhCong = blTP.ThemThuongPhat(
                    txtMaTP.Text,
                    cbbLoai.Text,
                    soTien,
                    txtLyDo.Text,
                    ref err);

                if (themThanhCong)
                {
                    load();
                    MessageBox.Show("Đã thêm thưởng phạt thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thêm được. Lỗi: " + err, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaTP.Text) ||
                    cbbLoai.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtTien.Text) ||
                    string.IsNullOrWhiteSpace(txtLyDo.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int soTien;
                if (!int.TryParse(txtTien.Text, out soTien))
                {
                    MessageBox.Show("Số tiền phải là số!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTien.Focus();
                    return;
                }

                string err = "";
                bool suaThanhCong = blTP.CapNhatThuongPhat(
                    txtMaTP.Text,
                    cbbLoai.Text,
                    soTien,
                    txtLyDo.Text,
                    ref err);

                if (suaThanhCong)
                {
                    load();
                    MessageBox.Show("Đã cập nhật thưởng phạt thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không cập nhật được. Lỗi: " + err, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaTP.Text))
                {
                    MessageBox.Show("Vui lòng chọn thưởng phạt cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thưởng phạt này?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string err = "";
                    bool xoaThanhCong = blTP.XoaThuongPhat(ref err, txtMaTP.Text);

                    if (xoaThanhCong)
                    {
                        load();
                        MessageBox.Show("Đã xóa thưởng phạt thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được. Lỗi: " + err, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemTPNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbMaNV.SelectedIndex == -1 ||
                    cbbMaTP.SelectedIndex == -1 ||
                    cbbMaThang.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtNgayTP.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int ngayThuongPhat;
                if (!int.TryParse(txtNgayTP.Text, out ngayThuongPhat))
                {
                    MessageBox.Show("Ngày thưởng phạt phải là số!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNgayTP.Focus();
                    return;
                }

                string err = "";
                bool themThanhCong = blTP.ThemChiTietThuongPhat(
                    cbbMaNV.SelectedValue.ToString(),
                    cbbMaTP.SelectedValue.ToString(),
                    cbbMaThang.SelectedValue.ToString(),
                    ngayThuongPhat,
                    ref err);

                if (themThanhCong)
                {
                    load();
                    MessageBox.Show("Đã thêm chi tiết thưởng phạt thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thêm được. Lỗi: " + err, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTPNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (maNV == "" || maTP == "" || maThang == "" || ngayTP == 0)
                {
                    MessageBox.Show("Vui lòng chọn chi tiết thưởng phạt cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết thưởng phạt này?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string err = "";
                    bool xoaThanhCong = blTP.XoaChiTietThuongPhat(maNV, ngayTP, maTP, maThang, ref err);

                    if (xoaThanhCong)
                    {
                        load();
                        MessageBox.Show("Đã xóa chi tiết thưởng phạt thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được. Lỗi: " + err, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaTPNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbMaNV.SelectedIndex == -1 ||
                    cbbMaTP.SelectedIndex == -1 ||
                    cbbMaThang.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtNgayTP.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int ngayThuongPhat;
                if (!int.TryParse(txtNgayTP.Text, out ngayThuongPhat))
                {
                    MessageBox.Show("Ngày thưởng phạt phải là số!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNgayTP.Focus();
                    return;
                }

                string err = "";
                bool suaThanhCong = blTP.CapNhatNgayThangThuongPhat(
                    cbbMaNV.SelectedValue.ToString(),
                    cbbMaTP.SelectedValue.ToString(),
                    cbbMaThang.SelectedValue.ToString(),
                    ngayThuongPhat,
                    ref err);

                if (suaThanhCong)
                {
                    load();
                    MessageBox.Show("Đã cập nhật chi tiết thưởng phạt thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không cập nhật được. Lỗi: " + err, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewTP.Rows[e.RowIndex];

                txtMaTP.Text = row.Cells["Column1"].Value.ToString();
                cbbLoai.Text = row.Cells["Column2"].Value.ToString();
                txtTien.Text = row.Cells["Column3"].Value.ToString();
                txtLyDo.Text = row.Cells["Column4"].Value.ToString();
            }
        }

        private void dataGridViewCTTP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewCTTP.Rows[e.RowIndex];

                maNV = row.Cells["dataGridViewTextBoxColumn1"].Value.ToString();
                maTP = row.Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                maThang = row.Cells["dataGridViewTextBoxColumn3"].Value.ToString();
                ngayTP = int.Parse(row.Cells["dataGridViewTextBoxColumn4"].Value.ToString());

                cbbMaNV.SelectedValue = maNV;
                cbbMaTP.SelectedValue = maTP;
                cbbMaThang.SelectedValue = maThang;
                txtNgayTP.Text = ngayTP.ToString();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaTP.ResetText();
            txtTien.ResetText();
            txtLyDo.ResetText();
            txtNgayTP.ResetText();
            cbbLoai.SelectedIndex = 0;
            maNV = "";
            maTP = "";
            maThang = "";
            ngayTP = 0;
            panelFormCTThuongPhat.Visible = false;
            rbPhat.Checked = false;
            rbThuong.Checked = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnXemThuongHayPhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!rbThuong.Checked && !rbPhat.Checked)
                {
                    MessageBox.Show("Vui lòng chọn loại thưởng hoặc phạt cần lọc!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string loai = rbThuong.Checked ? "Thưởng" : "Phạt";
                string maNV = cbbMaNV.Text.Trim();

                DataSet ds = blTP.LocThuongPhatNhanVien(maNV, loai);
                DataTable dt = ds.Tables[0];
                

                this.panelFormCTThuongPhat.Visible = true;
                frmChiTietThuongPhat formCTThuongPhat = new frmChiTietThuongPhat();
                formCTThuongPhat.TopLevel = false;
                formCTThuongPhat.FormBorderStyle = FormBorderStyle.None;
                formCTThuongPhat.Dock = DockStyle.Fill;
                this.panelFormCTThuongPhat.Controls.Clear();
                this.panelFormCTThuongPhat.Controls.Add(formCTThuongPhat);

                formCTThuongPhat.dataGridView1.DataSource = dt;
                formCTThuongPhat.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbThuongPhat_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}