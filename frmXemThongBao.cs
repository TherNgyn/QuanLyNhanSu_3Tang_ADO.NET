using QuanLyNhanSu_3Tang_ADO.BS_Layer;
using QuanLyNhanSu_3Tang_ADO.DB_Layer;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmXemThongBao : Form
    {
        string userName;          
        bool isTruongPhong;
        BLThongBao dbThongBao = new BLThongBao();
        DBMain db = new DBMain(); 

        public frmXemThongBao(string userName, bool isTruongPhong)
        {
            InitializeComponent();
            this.userName = userName;
            this.isTruongPhong = isTruongPhong;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        { 
            LoadThongBao();
        }

        private void btnXemTB_Click(object sender, EventArgs e)
        {
            if (dgvThongBao.CurrentRow != null)
            {
                string tieuDe = "", noiDung = "", ngayGui = "";

                if (isTruongPhong)
                { 
                    tieuDe = dgvThongBao.CurrentRow.Cells["TieuDe"].Value?.ToString();
                    noiDung = dgvThongBao.CurrentRow.Cells["NoiDung"].Value?.ToString();
                    ngayGui = dgvThongBao.CurrentRow.Cells["NgayGui"].Value?.ToString();
                }
                else
                { 
                    tieuDe = dgvThongBao.CurrentRow.Cells["Tiêu đề thông báo"].Value?.ToString();
                    noiDung = dgvThongBao.CurrentRow.Cells["Nội dung thông báo"].Value?.ToString();
                    ngayGui = dgvThongBao.CurrentRow.Cells["Ngày nhận"].Value?.ToString();
                }

                string message = $"Tiêu đề: {tieuDe}\n\nNội dung:\n{noiDung}\n\nNgày gửi: {ngayGui}";
                MessageBox.Show(message, "Chi tiết thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thông báo để xem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadThongBao()
        {
            DataTable dt = null;
            if (isTruongPhong)
            {
                DataSet ds = dbThongBao.LayThongBao();
                if (ds != null && ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            else
            {
                dt = dbThongBao.LayThongBaoChoNV(userName);
            }

            if (dt != null)
            {
                dgvThongBao.DataSource = dt;
                dgvThongBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (isTruongPhong)
                {
                    // đổi tên header
                    if (dgvThongBao.Columns.Contains("TieuDe"))
                        dgvThongBao.Columns["TieuDe"].HeaderText = "Tiêu đề thông báo";
                    if (dgvThongBao.Columns.Contains("NoiDung"))
                        dgvThongBao.Columns["NoiDung"].HeaderText = "Nội dung thông báo";
                    if (dgvThongBao.Columns.Contains("NgayGui"))
                        dgvThongBao.Columns["NgayGui"].HeaderText = "Ngày nhận";
                    if (dgvThongBao.Columns.Contains("MaPB"))
                        dgvThongBao.Columns["MaPB"].HeaderText = "Mã phòng ban";
                    if (dgvThongBao.Columns.Contains("TenPB"))
                        dgvThongBao.Columns["TenPB"].HeaderText = "Tên phòng ban";
                }
                else
                { 
                    if (dgvThongBao.Columns.Contains("Tiêu đề thông báo"))
                        dgvThongBao.Columns["Tiêu đề thông báo"].HeaderText = "Tiêu đề thông báo";
                    if (dgvThongBao.Columns.Contains("Nội dung thông báo"))
                        dgvThongBao.Columns["Nội dung thông báo"].HeaderText = "Nội dung thông báo";
                    if (dgvThongBao.Columns.Contains("Ngày nhận"))
                        dgvThongBao.Columns["Ngày nhận"].HeaderText = "Ngày nhận";
                }
            }
        }

        private void frmXemThongBao_Load(object sender, EventArgs e)
        {
            LoadThongBao();
        }
    }
}
