using QuanLyNhanSu_3Tang_ADO.BS_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmChiTietHopDong : Form
    {
        BLHopDong blHD = new BLHopDong();
        string MaNV = "";
        DataTable dt = new DataTable();
        public frmChiTietHopDong(string MaNV)
        {
            InitializeComponent();
            this.MaNV = MaNV;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmChiTietHopDong_Load(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                dt.Clear();

                DataSet ds = blHD.XemChiTietHopDong(MaNV);
                dt = ds.Tables[0];

                txtMaNV.Text = MaNV;
                txtMaHD.Text = dt.Rows[0]["MaHD"].ToString();
                dateTimePickerNgayBD.Value = Convert.ToDateTime(dt.Rows[0]["NgayBatDauHopDong"]);
                dateTimePickerNgayKT.Value = Convert.ToDateTime(dt.Rows[0]["NgayKetThucHopDong"]);
                txtChucVu.Text = dt.Rows[0]["TenChucVu"].ToString();
                txtLuongCoBan.Text = dt.Rows[0]["LuongCoBan"].ToString();
                txtPhongBan.Text = dt.Rows[0]["TenPhongBan"].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi"+ex);
            }
        }
    }
}
