using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhanSu_3Tang_ADO.BS_Layer;
using Guna.UI2.WinForms;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmQuanLyCongvaThang : Form
    {
        BLCong blCong = new BLCong();
        BLThang blThang = new BLThang();

        DataSet dsCong = new DataSet();
        DataSet dsThang = new DataSet();

        DataTable dtCong = new DataTable();
        DataTable dtThang = new DataTable();
        string MaNV;

        public frmQuanLyCongvaThang(string maNV)
        {
            InitializeComponent();
            MaNV = maNV;
        }
        private void load()
        {
            try
            {
                dtCong.Clear();
                dtThang.Clear();

                dsCong = blCong.LayDSChamCong();
                dsThang = blThang.LayThang();

                dtThang = dsThang.Tables[0];
                dtCong = dsCong.Tables[0];

                dataGVThang.DataSource = dtThang;
                dataGVCong.DataSource = dtCong;

                txtMaCC.ResetText();
                txtMaThang.ResetText();
                txtHeSo.ResetText();
                txtMoTa.ResetText();
                txtMoTaCong.ResetText();
                txtSoNgayCong.ResetText();

                btnThoat.Enabled = true;
                dataGVCong_CellClick(null, null);
                dataGVThang_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table. Lỗi rồi!!!");
            }
        }

        private void FormQuanLyThangCong_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnThemThang_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(txtMaThang.Text) ||
                    string.IsNullOrWhiteSpace(txtMoTa.Text) ||
                    string.IsNullOrWhiteSpace(txtHeSo.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    txtMaThang.Focus();
                    return;
                }
                string err = "";
                bool themThanhCong = blThang.ThemThang(
                    this.txtMaThang.Text,
                    txtMoTa.Text,
                    int.Parse(this.txtHeSo.Text),
                    ref err);

                if (themThanhCong)
                {
                    load();
                    MessageBox.Show("Đã thêm xong!");
                }
                else
                {
                    MessageBox.Show("Không thêm được. Lỗi: " + err);
                }

            }
            catch (Exception ex)
            {
                MessageDialog.Show("Lỗi: " + ex);
            }

        }

        private void dataGVThang_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnSuaThang_Click(object sender, EventArgs e)
        {
            try
            {
                string err = "";
                blThang.CapNhatThang(this.txtMaThang.Text,
                    txtMoTa.Text,
                    int.Parse(this.txtHeSo.Text),
                    ref err);
                load();
                MessageBox.Show("Đã sửa xong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemCong_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaCC.Text) ||
                    string.IsNullOrWhiteSpace(txtMoTaCong.Text) ||
                    string.IsNullOrWhiteSpace(txtHeSo.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaCC.Focus();
                    return;
                }

                float heSo;
                if (!float.TryParse(txtHeSo.Text, out heSo))
                {
                    MessageBox.Show("Hệ số phải là số!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHeSo.Focus();
                    return;
                }

                string err = "";
                bool themThanhCong = blCong.ThemCong(
                    txtMaCC.Text,
                    txtMoTaCong.Text,
                    heSo,
                    ref err);

                if (themThanhCong)
                {
                    load();
                    MessageBox.Show("Đã thêm loại chấm công thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtMaCC.Text = "";
                    txtMoTaCong.Text = "";
                    txtHeSo.Text = "";
                    txtMaCC.Focus();
                }
                else
                {
                    MessageBox.Show("Không thêm được. Lỗi: " + err, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaCong_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtMaCC.Text) ||
                    string.IsNullOrWhiteSpace(txtMoTaCong.Text) ||
                    string.IsNullOrWhiteSpace(txtHeSo.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                float heSo;
                if (!float.TryParse(txtHeSo.Text, out heSo))
                {
                    MessageBox.Show("Hệ số phải là số!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHeSo.Focus();
                    return;
                }


                string err = "";
                bool suaThanhCong = blCong.SuaCong(
                    txtMaCC.Text,
                    txtMoTaCong.Text,
                    heSo,
                    ref err);

                if (suaThanhCong)
                {
                    load();
                    MessageBox.Show("Đã cập nhật loại chấm công thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaCC.Text = "";
                    txtMoTaCong.Text = "";
                    txtHeSo.Text = "";
                    txtMaCC.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Không cập nhật được. Lỗi: " + err, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGVCong_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnLamMoiCong_Click(object sender, EventArgs e)
        {
            txtMaCC.Enabled = true;
            txtMaCC.Text = txtMoTaCong.Text = txtHeSo.Text = "";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaThang.Enabled = true;
            txtMaThang.Text = txtMoTa.Text = txtSoNgayCong.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Chắc chắn thoát?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                /*frmMenuQuanTriVien frm = new frmMenuQuanTriVien(MaNV);
                frm.Show();*/
                this.Close();
            }
        }

        private void dataGVThang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaThang.Enabled = false;
            txtMaThang.Text = dataGVThang.CurrentRow.Cells[0].Value.ToString();
            txtMoTa.Text = dataGVThang.CurrentRow.Cells[1].Value.ToString();
            txtSoNgayCong.Text = dataGVThang.CurrentRow.Cells[2].Value.ToString();
        }

        private void dataGVCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCC.Enabled = false;
            txtMaCC.Text = dataGVCong.CurrentRow.Cells[0].Value.ToString();
            txtMoTaCong.Text = dataGVCong.CurrentRow.Cells[1].Value.ToString();
            txtHeSo.Text = dataGVCong.CurrentRow.Cells[2].Value.ToString();
        }

        private void frmQuanLyCongvaThang_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMenuQuanTriVien frm = new frmMenuQuanTriVien(MaNV);
            frm.Show();
        }
    }
}
