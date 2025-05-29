using Guna.UI2.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmChamCong : Form
    {
        BLCong blCC = new BLCong();
        DataSet dsCC = new DataSet();
        string MaNV = "";
        public frmChamCong(string username)
        {
            InitializeComponent();
            this.MaNV = username;
            
        }
        void LoadData()
        {
            try
            {
                dsCC = blCC.LayDSChamCongByNV(MaNV);
                DataTable dtDSCC = new DataTable();
                dtDSCC = dsCC.Tables[0];
                dataGridViewChamCong.DataSource = dtDSCC;
                   
                DataSet dsLoaiCong = new DataSet();
                dsLoaiCong = blCC.LayDSChamCong();
                DataTable dtCong = new DataTable();
                dtCong = dsLoaiCong.Tables[0];
                cbbLoaiChamCong.DataSource = dtCong;
                cbbLoaiChamCong.DisplayMember = "MoTa";
                cbbLoaiChamCong.ValueMember = "MaCC";
                this.txtMaNV.Text = MaNV;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbLoaiChamCong.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn loại chấm công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maCC = cbbLoaiChamCong.SelectedValue.ToString();
                string err = "";

                if (blCC.ChamCong(this.txtMaNV.Text, maCC, ref err))
                {
                    MessageBox.Show("Chấm công thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Lỗi chấm công: " + err, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            LoadData();
            
        }
    }
}
