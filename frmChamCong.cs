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
    public partial class frmChamCong : Form
    {
        BLChamCong blCC = new BLChamCong();
        DataSet dsCC = new DataSet();

        public frmChamCong()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dsCC = blCC.LayDSChamCong(this.txtMaNV.Text);
                DataTable dtDSCC = new DataTable();
                dtDSCC = dsCC.Tables[0];
                dataGridViewChamCong.DataSource = dtDSCC;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {

        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
