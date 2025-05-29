using Microsoft.Data.SqlClient;
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
    public partial class frmQuanLyHopDong : Form
    {
        DataTable dtHopDong = null;
        bool Them;
        string err;
        BLHopDong dbHopDong = new BLHopDong();
        public frmQuanLyHopDong()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dtHopDong = new DataTable();
                dtHopDong.Clear();


                DataSet ds = dbHopDong.LayHopDong();
                dtHopDong = ds.Tables[0];

                dataGridViewHopDong.DataSource = dtHopDong;
                dataGridViewHopDong.AutoResizeColumns();


                txtMaNhanVien.ResetText();
                txtLuongCoBan.ResetText();
                txtMaHopDong.ResetText();
                txtTimKiemMaNV.ResetText();

                btnHuy.Enabled = false;
                btnLuu.Enabled = false;

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                btnThoat.Enabled = true;
                dataGridViewHopDong_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table. Lỗi rồi!!!");
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            frmChiTietHopDong ct = new frmChiTietHopDong(this.txtMaNhanVien.Text);
            ct.ShowDialog();
        }

        private void frmQuanLyHopDong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?  
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them  
            Them = true;
            // Xóa trống các đối tượng trong Panel  
            txtMaNhanVien.ResetText();
            txtLuongCoBan.ResetText();
            txtMaHopDong.ResetText();
            txtTimKiemMaNV.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel  
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.guna2Panel1.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát  
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;

            this.txtMaHopDong.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa  
            Them = false;

            // Cho thao tác trên các nút Lưu / Hủy / Panel  
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.guna2Panel1.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát  
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;

            this.txtMaHopDong.Enabled = false;
            this.txtMaNhanVien.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh  
                // Lấy thứ tự record hiện hành  
                int r = dataGridViewHopDong.CurrentCell.RowIndex;

                string MaHD = dataGridViewHopDong.Rows[r].Cells[0].Value.ToString();

                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp  
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?  
                if (traloi == DialogResult.Yes)
                {

                    dbHopDong.XoaHopDong(ref err, MaHD);

                    // Cập nhật lại DataGridView  
                    LoadData();
                    // Thông báo  
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    // Thông báo  
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel  
            txtMaNhanVien.ResetText();
            txtLuongCoBan.ResetText();
            txtMaHopDong.ResetText();
            txtTimKiemMaNV.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát  
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel  
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.guna2Panel1.Enabled = false;
            dataGridViewHopDong_CellClick(null, null);

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                if (string.IsNullOrWhiteSpace(txtMaHopDong.Text) ||
                    string.IsNullOrWhiteSpace(txtMaNhanVien.Text) ||
                    string.IsNullOrWhiteSpace(txtLuongCoBan.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    txtMaHopDong.Focus();
                    return;
                }
                string err = "";
                bool themThanhCong = dbHopDong.ThemHopDonng(
                    this.txtMaHopDong.Text,
                    txtMaNhanVien.Text,
                    int.Parse(txtLuongCoBan.Text),
                    dtpNgayBd.Value,
                    dtpNgayKt.Value,
                    ref err);

                if (themThanhCong)
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
                dbHopDong.CapNhatHopDong(this.txtMaHopDong.Text, txtMaNhanVien.Text, int.Parse(txtLuongCoBan.Text), dtpNgayBd.Value, dtpNgayKt.Value, ref err);
                LoadData();
                MessageBox.Show("Đã sửa xong!");
            }
            // Đóng kết nối 
        }

        private void dataGridViewHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewHopDong.CurrentCell == null || dataGridViewHopDong.CurrentRow == null)
                return;

            int r = dataGridViewHopDong.CurrentCell.RowIndex;
            var cellNgayBD = dataGridViewHopDong.Rows[r].Cells[3].Value;
            var cellNgayKT = dataGridViewHopDong.Rows[r].Cells[4].Value;

            if (r >= 0 && r < dataGridViewHopDong.Rows.Count)
            {

                this.txtMaHopDong.Text = dataGridViewHopDong.Rows[r].Cells[0].Value?.ToString() ?? "";
                this.txtMaNhanVien.Text = dataGridViewHopDong.Rows[r].Cells[1].Value?.ToString() ?? "";
                this.txtLuongCoBan.Text = dataGridViewHopDong.Rows[r].Cells[2].Value?.ToString() ?? "";
                this.dtpNgayBd.Value = cellNgayBD != null && cellNgayBD != DBNull.Value
                    ? Convert.ToDateTime(cellNgayBD)
                    : new DateTime(2022, 1, 1);

                this.dtpNgayKt.Value = cellNgayKT != null && cellNgayKT != DBNull.Value
                    ? Convert.ToDateTime(cellNgayKT)
                    : DateTime.Today;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maNV = this.txtTimKiemMaNV.Text.Trim();
            DataSet ds = dbHopDong.TimKiemHopDong(maNV);

            if (ds != null && ds.Tables.Count > 0)
            {
                dataGridViewHopDong.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp.");
            }
        }

        private void txtTimKiemMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKTHDHetHan_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = dbHopDong.LayHopDongSapHetHan();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dtHopDong = ds.Tables[0];
                    
                    dataGridViewHopDong.DataSource = dtHopDong;
                    MessageBox.Show("Có " + dtHopDong.Rows.Count + " hợp đồng sắp hết hạn.");
                    
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hợp đồng sắp hết hạn.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
