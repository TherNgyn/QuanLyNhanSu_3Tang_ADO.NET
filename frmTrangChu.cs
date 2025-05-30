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
    public partial class frmTrangChu : Form
    {
        private Form currentChildForm;
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            OpenChildForm(new frmDangNhap());
            
        }
        private void OpenChildForm(Form childForm)
        {
          
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

           
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(childForm);
            pnLoad.Tag = childForm;

            childForm.Show();
        }
    }
}
