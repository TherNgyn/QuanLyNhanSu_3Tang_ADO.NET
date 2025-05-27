using System.Data;
using System.Windows.Forms;
using static QuanLyNhanSu_3Tang_ADO.Connection;
using Microsoft.Data.SqlClient;
using Microsoft.Data;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmQuanLyNhanVien : Form
    {
        void LoadData()
        {
            // Xóa trống các đối tượng trong Panel  
            txtTen.ResetText();
            txtMaNhanVien.ResetText();
            txtHoVaTenLot.ResetText();
            txtSDT.ResetText();
            txtEmail.ResetText();
            txtCCCD.ResetText();
            txtDiaChi.ResetText();
            txtHopDong.ResetText();
            txtThamNien.ResetText();
            txtTimKiemMaNV.ResetText();

            // Không cho thao tác trên các nút Lưu / Hủy  s
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát  
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
           
            try
            {
                //Load dữ liệu từ bảng Nhân viên lên DataGridView
                string data = "Select * from NhanVien";
                dataGridViewNhanVien.DataSource = Connection.LoadDataTable(data);

                //Load dữ liệu lên combobox Phòng ban
                string phongban = "select MaPB, TenPB from PhongBan"; // Chọn cột MaPB và TenPB
                cbbPhongBan.DataSource = Connection.LoadDataTable(phongban);
                cbbPhongBan.ValueMember = "MaPB"; // Chọn MaPB làm giá trị
                cbbPhongBan.DisplayMember = "TenPB"; // Hiển thị TenPB trong ComboBox

                //Load dữ liệu lên combobox Chức vụ
                string chucvu = "select MaCV, TenCV from ChucVu"; // Chọn cột MaPB và TenPB
                cbbChucVu.DataSource = Connection.LoadDataTable(chucvu);
                cbbChucVu.ValueMember = "MaCV";
                cbbChucVu.DisplayMember = "TenCV";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table NhanVien. Lỗi rồi!!!");
            }
        }
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
