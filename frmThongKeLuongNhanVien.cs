using Guna.UI2.WinForms;
using Microsoft.ReportingServices;
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
    public partial class frmThongKeLuongNhanVien : Form
    {
        BLThang blThang = new BLThang();
        BLLuong blLuong = new BLLuong();
        string mNV;
        private Form parentForm = null; // Thêm biến lưu form cha

        public frmThongKeLuongNhanVien(string maNV)
        {
            InitializeComponent();
            mNV = maNV;
        }

        
        public frmThongKeLuongNhanVien(string maNV, Form parent)
        {
            InitializeComponent();
            mNV = maNV;
            parentForm = parent;
        }

        void LoadData()
        {
            DataSet dsThang = new DataSet();
            DataTable dtThang = new DataTable();
            dsThang = blThang.LayThang();
            dtThang = dsThang.Tables[0];

            cbbMaThang.DataSource = dtThang;
            cbbMaThang.ValueMember = "MaThang";
            cbbMaThang.DisplayMember = "MoTa";
        }

        private void btnXemLuong_Click(object sender, EventArgs e)
        {
            try
            {
                string maThang = cbbMaThang.SelectedValue.ToString().Trim();
                /*MessageBox.Show("" + maThang);*/
                string err = "";
                DataTable dt = blLuong.TinhLuongTheoThangAll(maThang, ref err);
                dgvLuong.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính lương: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmThongKeLuongNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXemReport_Click(object sender, EventArgs e)
        {
           
            frmReport frmRP = new frmReport(mNV, this);
            frmRP.Show();
        }

        private void frmThongKeLuongNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parentForm != null)
            {
               
                parentForm.Show();
            }
            else
            {
            
                frmMenuQuanTriVien frm = new frmMenuQuanTriVien(mNV);
                frm.Show();
            }
        }
    }
}