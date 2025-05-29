using QuanLyNhanSu_3Tang_ADO.BS_Layer;
using QuanLyNhanSu_3Tang_ADO.DB_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using Microsoft.Data.SqlClient;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmXemThongBao : Form
    {
        private string maNhanVien;
        private BLThongBao dbThongBao = new BLThongBao();
        DBMain db = new DBMain();

        public frmXemThongBao(string maNV)
        {
            InitializeComponent();
            maNhanVien = maNV;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

        }

        private void btnXemTB_Click(object sender, EventArgs e)
        {
            if (dgvThongBao.CurrentRow != null)
            {
                string tieuDe = dgvThongBao.CurrentRow.Cells[0].Value?.ToString();
                string noiDung = dgvThongBao.CurrentRow.Cells[1].Value?.ToString();
                string ngayGui = dgvThongBao.CurrentRow.Cells[2].Value?.ToString();

                string message = $"Tiêu đề: {tieuDe}\n\nNội dung:\n{noiDung}\n\nNgày nhận: {ngayGui}";
                MessageBox.Show(message, "Chi tiết thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thông báo để xem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LayMaPhongBanVaLoadThongBao(string maNV)
        {
            string maPB = "";
            using (var conn = new SqlConnection(DBMain.connectString))
            {
                string sql = "SELECT MaPB FROM NhanVien WHERE MaNV = @MaNV";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        maPB = result.ToString();
                }
            }

            if (!string.IsNullOrEmpty(maPB))
            {
                string sql = @"SELECT TieuDe AS [Tiêu đề thông báo], NoiDung AS [Nội dung thông báo], 
                               CONVERT(varchar, NgayGui, 103) AS [Ngày nhận]
                               FROM ThongBao WHERE MaPB = @MaPB ORDER BY NgayGui DESC";
                using (var conn = new SqlConnection(DBMain.connectString))
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@MaPB", maPB);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvThongBao.DataSource = dt;
                    dgvThongBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        private void frmXemThongBao_Load(object sender, EventArgs e)
        {
            LayMaPhongBanVaLoadThongBao(maNhanVien);
        }
    }
}
