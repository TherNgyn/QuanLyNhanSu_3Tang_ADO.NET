using System;
using System.Data;
using System.Windows.Forms;
using QuanLyNhanSu_3Tang_ADO.BS_Layer;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmLuongNhanVien : Form
    {
        BLLuong blLuong = new BLLuong();
        string maNV = "";
        private string userRole;
        BLTaiKhoan bLTaiKhoan = new BLTaiKhoan();

        public frmLuongNhanVien(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            txtMaNV.Text = maNV;

            // Định dạng DateTimePicker để chọn tháng/năm
            this.guna2DateTimePicker1.Format = DateTimePickerFormat.Custom;
            guna2DateTimePicker1.CustomFormat = "MM/yyyy";
            this.userRole = bLTaiKhoan.LayRoleName(maNV);
        }

        private void frmLuongNhanVien_Load(object sender, EventArgs e)
        {
            // Khởi tạo giao diện
            ResetFields();

            // Chọn tháng hiện tại
            guna2DateTimePicker1.Value = DateTime.Now;
        }

        private void ResetFields()
        {
            txtLuongCoBan.Text = "0";
            txtBHTN.Text = "0";
            txtBHXH.Text = "0";
            txtBHYT.Text = "0";
            txtPhuCap.Text = "0";
            txtGiamTruGiaCanh.Text = "0";
            txtLuongThucTe.Text = "0";
            txtThucLanh.Text = "0";
            txtSoNgayCongChuan.Text = "0";
            txtSoNgayLamViec.Text = "0";
            txtTongBaoHiem.Text = "0";
            txtThue.Text = "0";
            txtThuongPhat.Text = "0";
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            try
            {

                string maThang = guna2DateTimePicker1.Value.ToString("MMyyyy");
                string err = "";
                DataTable dt = blLuong.TinhLuongTheoThang(maNV, maThang, ref err);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtMaNV.Text = row["MaNV"].ToString();
                    txtLuongCoBan.Text = row["LuongCoBan"].ToString();
                    txtBHYT.Text = row["BH01"].ToString();
                    txtBHXH.Text = row["BH02"].ToString();
                    txtBHTN.Text = row["BH03"].ToString();
                    txtTongBaoHiem.Text = row["TongTienBaoHiem"].ToString();
                    txtPhuCap.Text = row["TongPhuCap"].ToString();
                    txtGiamTruGiaCanh.Text = row["GiamTruGiaCanh"].ToString();
                    txtLuongThucTe.Text = row["LuongChiuThue"].ToString();
                    txtThucLanh.Text = row["LuongThucLanh"].ToString();
                    txtSoNgayCongChuan.Text = row["SoNgayCongChuan"].ToString();
                    txtSoNgayLamViec.Text = row["SoNgayCong"].ToString();
                    txtThue.Text = row["Thue"].ToString();
                    txtThuongPhat.Text = row["TongThuongPhat"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin lương cho tháng này!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính lương: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Chắc chắn thoát?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void frmLuongNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (userRole.Equals("TruongPhong", StringComparison.OrdinalIgnoreCase))
            {
                frmMenuTruongPhong frm = new frmMenuTruongPhong(maNV);
                frm.Show();
            }
            else if (userRole.Equals("NhanVien", StringComparison.OrdinalIgnoreCase))
            {
                frmMenuNhanVien frm = new frmMenuNhanVien(maNV);
                frm.Show();
            }
        }
    }
}