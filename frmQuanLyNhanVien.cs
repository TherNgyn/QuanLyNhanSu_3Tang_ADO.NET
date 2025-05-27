using System.Data;
using System.Windows.Forms;

using Microsoft.Data.SqlClient;
using Microsoft.Data;
using QuanLyNhanSu_3Tang_ADO.BS_Layer;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmQuanLyNhanVien : Form
    {
        DataTable dtNhanVien = null;
        bool Them;
        string err;
        BLNhanVien dbNV = new BLNhanVien();
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

           
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
           
            try
            {
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();

                DataSet ds = dbNV.LayNhanVien();
                dtNhanVien = ds.Tables[0];

                dataGridViewNhanVien.DataSource = dtNhanVien;
                //
                

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
