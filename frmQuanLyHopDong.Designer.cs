namespace QuanLyNhanSu_3Tang_ADO
{
    partial class frmQuanLyHopDong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpNgayBd = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpNgayKt = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtLuongCoBan = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaNhanVien = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaHopDong = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNgayKT = new System.Windows.Forms.Label();
            this.sd = new System.Windows.Forms.Label();
            this.lblHeSoLuong = new System.Windows.Forms.Label();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtTimKiemMaNV = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.dataGridViewHopDong = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuongCoBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnKTHDHetHan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.guna2GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHopDong)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpNgayBd
            // 
            this.dtpNgayBd.Checked = true;
            this.dtpNgayBd.FillColor = System.Drawing.Color.White;
            this.dtpNgayBd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayBd.ForeColor = System.Drawing.Color.Black;
            this.dtpNgayBd.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgayBd.Location = new System.Drawing.Point(736, 52);
            this.dtpNgayBd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayBd.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayBd.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayBd.Name = "dtpNgayBd";
            this.dtpNgayBd.Size = new System.Drawing.Size(231, 60);
            this.dtpNgayBd.TabIndex = 20;
            this.dtpNgayBd.Value = new System.DateTime(2024, 10, 25, 1, 43, 6, 269);
            // 
            // dtpNgayKt
            // 
            this.dtpNgayKt.Checked = true;
            this.dtpNgayKt.FillColor = System.Drawing.Color.White;
            this.dtpNgayKt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayKt.ForeColor = System.Drawing.Color.Black;
            this.dtpNgayKt.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgayKt.Location = new System.Drawing.Point(736, 137);
            this.dtpNgayKt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayKt.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayKt.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayKt.Name = "dtpNgayKt";
            this.dtpNgayKt.Size = new System.Drawing.Size(231, 60);
            this.dtpNgayKt.TabIndex = 19;
            this.dtpNgayKt.Value = new System.DateTime(2024, 10, 25, 1, 43, 6, 269);
            // 
            // txtLuongCoBan
            // 
            this.txtLuongCoBan.BackColor = System.Drawing.Color.White;
            this.txtLuongCoBan.BorderRadius = 10;
            this.txtLuongCoBan.BorderThickness = 0;
            this.txtLuongCoBan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLuongCoBan.DefaultText = "";
            this.txtLuongCoBan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLuongCoBan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLuongCoBan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLuongCoBan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLuongCoBan.FillColor = System.Drawing.SystemColors.Control;
            this.txtLuongCoBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLuongCoBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLuongCoBan.ForeColor = System.Drawing.Color.Black;
            this.txtLuongCoBan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLuongCoBan.Location = new System.Drawing.Point(178, 236);
            this.txtLuongCoBan.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtLuongCoBan.Name = "txtLuongCoBan";
            this.txtLuongCoBan.PlaceholderText = "";
            this.txtLuongCoBan.SelectedText = "";
            this.txtLuongCoBan.Size = new System.Drawing.Size(338, 46);
            this.txtLuongCoBan.TabIndex = 18;
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.BackColor = System.Drawing.Color.White;
            this.txtMaNhanVien.BorderRadius = 10;
            this.txtMaNhanVien.BorderThickness = 0;
            this.txtMaNhanVien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaNhanVien.DefaultText = "";
            this.txtMaNhanVien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNhanVien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNhanVien.FillColor = System.Drawing.SystemColors.Control;
            this.txtMaNhanVien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaNhanVien.ForeColor = System.Drawing.Color.Black;
            this.txtMaNhanVien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNhanVien.Location = new System.Drawing.Point(178, 150);
            this.txtMaNhanVien.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.PlaceholderText = "";
            this.txtMaNhanVien.SelectedText = "";
            this.txtMaNhanVien.Size = new System.Drawing.Size(338, 47);
            this.txtMaNhanVien.TabIndex = 17;
            // 
            // txtMaHopDong
            // 
            this.txtMaHopDong.BackColor = System.Drawing.Color.White;
            this.txtMaHopDong.BorderRadius = 10;
            this.txtMaHopDong.BorderThickness = 0;
            this.txtMaHopDong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaHopDong.DefaultText = "";
            this.txtMaHopDong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaHopDong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaHopDong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaHopDong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaHopDong.FillColor = System.Drawing.SystemColors.Control;
            this.txtMaHopDong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaHopDong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaHopDong.ForeColor = System.Drawing.Color.Black;
            this.txtMaHopDong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaHopDong.Location = new System.Drawing.Point(178, 63);
            this.txtMaHopDong.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtMaHopDong.Name = "txtMaHopDong";
            this.txtMaHopDong.PlaceholderText = "";
            this.txtMaHopDong.SelectedText = "";
            this.txtMaHopDong.Size = new System.Drawing.Size(338, 49);
            this.txtMaHopDong.TabIndex = 16;
            // 
            // lblNgayKT
            // 
            this.lblNgayKT.AutoSize = true;
            this.lblNgayKT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKT.ForeColor = System.Drawing.Color.Black;
            this.lblNgayKT.Location = new System.Drawing.Point(548, 161);
            this.lblNgayKT.Name = "lblNgayKT";
            this.lblNgayKT.Size = new System.Drawing.Size(141, 23);
            this.lblNgayKT.TabIndex = 5;
            this.lblNgayKT.Text = "Ngày kết thúc: ";
            // 
            // sd
            // 
            this.sd.AutoSize = true;
            this.sd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sd.ForeColor = System.Drawing.Color.Black;
            this.sd.Location = new System.Drawing.Point(548, 78);
            this.sd.Name = "sd";
            this.sd.Size = new System.Drawing.Size(133, 23);
            this.sd.TabIndex = 6;
            this.sd.Text = "Ngày bắt đầu: ";
            // 
            // lblHeSoLuong
            // 
            this.lblHeSoLuong.AutoSize = true;
            this.lblHeSoLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeSoLuong.ForeColor = System.Drawing.Color.Black;
            this.lblHeSoLuong.Location = new System.Drawing.Point(43, 245);
            this.lblHeSoLuong.Name = "lblHeSoLuong";
            this.lblHeSoLuong.Size = new System.Drawing.Size(133, 23);
            this.lblHeSoLuong.TabIndex = 7;
            this.lblHeSoLuong.Text = "Lương cơ bản:";
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.ForeColor = System.Drawing.Color.Black;
            this.lblMaNV.Location = new System.Drawing.Point(42, 161);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(134, 23);
            this.lblMaNV.TabIndex = 8;
            this.lblMaNV.Text = "Mã nhân viên: ";
            // 
            // guna2GroupBox3
            // 
            this.guna2GroupBox3.Controls.Add(this.btnXemChiTiet);
            this.guna2GroupBox3.Controls.Add(this.dtpNgayBd);
            this.guna2GroupBox3.Controls.Add(this.btnKTHDHetHan);
            this.guna2GroupBox3.Controls.Add(this.btnTimKiem);
            this.guna2GroupBox3.Controls.Add(this.dtpNgayKt);
            this.guna2GroupBox3.Controls.Add(this.txtTimKiemMaNV);
            this.guna2GroupBox3.Controls.Add(this.txtLuongCoBan);
            this.guna2GroupBox3.Controls.Add(this.txtMaNhanVien);
            this.guna2GroupBox3.Controls.Add(this.txtMaHopDong);
            this.guna2GroupBox3.Controls.Add(this.lblNgayKT);
            this.guna2GroupBox3.Controls.Add(this.sd);
            this.guna2GroupBox3.Controls.Add(this.lblHeSoLuong);
            this.guna2GroupBox3.Controls.Add(this.lblMaNV);
            this.guna2GroupBox3.Controls.Add(this.lblMaHD);
            this.guna2GroupBox3.CustomBorderColor = System.Drawing.Color.Navy;
            this.guna2GroupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox3.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox3.Location = new System.Drawing.Point(12, 11);
            this.guna2GroupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2GroupBox3.Name = "guna2GroupBox3";
            this.guna2GroupBox3.Size = new System.Drawing.Size(1234, 303);
            this.guna2GroupBox3.TabIndex = 34;
            this.guna2GroupBox3.Text = "THÔNG TIN HỢP ĐỒNG";
            
            // 
            // txtTimKiemMaNV
            // 
            this.txtTimKiemMaNV.BorderRadius = 10;
            this.txtTimKiemMaNV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiemMaNV.DefaultText = "";
            this.txtTimKiemMaNV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiemMaNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiemMaNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemMaNV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemMaNV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemMaNV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiemMaNV.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemMaNV.Location = new System.Drawing.Point(552, 226);
            this.txtTimKiemMaNV.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTimKiemMaNV.Name = "txtTimKiemMaNV";
            this.txtTimKiemMaNV.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTimKiemMaNV.PlaceholderText = "Tìm kiếm theo mã nhân viên";
            this.txtTimKiemMaNV.SelectedText = "";
            this.txtTimKiemMaNV.Size = new System.Drawing.Size(418, 56);
            this.txtTimKiemMaNV.TabIndex = 9;
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHD.ForeColor = System.Drawing.Color.Black;
            this.lblMaHD.Location = new System.Drawing.Point(41, 78);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(131, 23);
            this.lblMaHD.TabIndex = 9;
            this.lblMaHD.Text = "Mã hợp đồng: ";
            // 
            // dataGridViewHopDong
            // 
            this.dataGridViewHopDong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHopDong.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewHopDong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHopDong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.MaNV,
            this.LuongCoBan,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewHopDong.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewHopDong.Location = new System.Drawing.Point(3, 49);
            this.dataGridViewHopDong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewHopDong.Name = "dataGridViewHopDong";
            this.dataGridViewHopDong.ReadOnly = true;
            this.dataGridViewHopDong.RowHeadersVisible = false;
            this.dataGridViewHopDong.RowHeadersWidth = 51;
            this.dataGridViewHopDong.RowTemplate.Height = 24;
            this.dataGridViewHopDong.Size = new System.Drawing.Size(1228, 260);
            this.dataGridViewHopDong.TabIndex = 10;
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "Mã hợp đồng";
            this.MaHD.MinimumWidth = 6;
            this.MaHD.Name = "MaHD";
            this.MaHD.ReadOnly = true;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.ReadOnly = true;
            // 
            // LuongCoBan
            // 
            this.LuongCoBan.DataPropertyName = "LuongCoBan";
            this.LuongCoBan.HeaderText = "Lương cơ bản";
            this.LuongCoBan.MinimumWidth = 6;
            this.LuongCoBan.Name = "LuongCoBan";
            this.LuongCoBan.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NgayBD";
            this.Column4.HeaderText = "Ngày bắt đầu";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NgayKT";
            this.Column5.HeaderText = "Ngày kết thúc";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.dataGridViewHopDong);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.SteelBlue;
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 45, 0, 0);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(12, 329);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1234, 321);
            this.guna2GroupBox1.TabIndex = 35;
            this.guna2GroupBox1.Text = "DANH SÁCH HỢP ĐỒNG";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Navy;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.Black;
            this.btnLamMoi.Location = new System.Drawing.Point(566, 154);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(165, 48);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.BackColor = System.Drawing.Color.Navy;
            this.btnXemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemChiTiet.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnXemChiTiet.Location = new System.Drawing.Point(1014, 135);
            this.btnXemChiTiet.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(191, 62);
            this.btnXemChiTiet.TabIndex = 5;
            this.btnXemChiTiet.Text = "Xem thông tin chi tiết";
            this.btnXemChiTiet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemChiTiet.UseVisualStyleBackColor = false;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Navy;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(215, 20);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(182, 48);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Navy;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(405, 20);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(182, 48);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Navy;
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(25, 20);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(182, 48);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(220)))));
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(220)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(8)))), ((int)(((byte)(23)))));
            this.guna2Button1.Location = new System.Drawing.Point(1314, 36);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(165, 48);
            this.guna2Button1.TabIndex = 8;
            this.guna2Button1.Text = "Thoát";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.btnThoat);
            this.guna2Panel1.Controls.Add(this.btnHuy);
            this.guna2Panel1.Controls.Add(this.btnLuu);
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Controls.Add(this.btnThem);
            this.guna2Panel1.Controls.Add(this.btnXoa);
            this.guna2Panel1.Controls.Add(this.btnSua);
            this.guna2Panel1.Controls.Add(this.btnLamMoi);
            this.guna2Panel1.Location = new System.Drawing.Point(12, 657);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1233, 84);
            this.guna2Panel1.TabIndex = 33;
            // 
            // btnKTHDHetHan
            // 
            this.btnKTHDHetHan.BackColor = System.Drawing.Color.Navy;
            this.btnKTHDHetHan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKTHDHetHan.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnKTHDHetHan.ForeColor = System.Drawing.Color.White;
            this.btnKTHDHetHan.Location = new System.Drawing.Point(1014, 52);
            this.btnKTHDHetHan.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnKTHDHetHan.Name = "btnKTHDHetHan";
            this.btnKTHDHetHan.Size = new System.Drawing.Size(191, 63);
            this.btnKTHDHetHan.TabIndex = 12;
            this.btnKTHDHetHan.Text = "Hợp đồng sắp hết hạn";
            this.btnKTHDHetHan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKTHDHetHan.UseVisualStyleBackColor = false;
            this.btnKTHDHetHan.Click += new System.EventHandler(this.btnKTHDHetHan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Navy;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(994, 20);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(172, 48);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Navy;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(615, 20);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(165, 48);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Navy;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(788, 20);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(182, 48);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.BackgroundImage = global::QuanLyNhanSu_3Tang_ADO.Properties.Resources.search;
            this.btnTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTimKiem.Image = global::QuanLyNhanSu_3Tang_ADO.Properties.Resources.search;
            this.btnTimKiem.Location = new System.Drawing.Point(1014, 226);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 55);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // frmQuanLyHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1258, 749);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2GroupBox3);
            this.Controls.Add(this.guna2GroupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmQuanLyHopDong";
            this.Text = "Quản lý hợp đồng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuanLyHopDong_FormClosing);
            this.Load += new System.EventHandler(this.frmQuanLyHopDong_Load);
            this.guna2GroupBox3.ResumeLayout(false);
            this.guna2GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHopDong)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayBd;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayKt;
        private Guna.UI2.WinForms.Guna2TextBox txtLuongCoBan;
        private Guna.UI2.WinForms.Guna2TextBox txtMaNhanVien;
        private Guna.UI2.WinForms.Guna2TextBox txtMaHopDong;
        private System.Windows.Forms.Label lblNgayKT;
        private System.Windows.Forms.Label sd;
        private System.Windows.Forms.Label lblHeSoLuong;
        private System.Windows.Forms.Label lblMaNV;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox3;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Button btnTimKiem;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiemMaNV;
        private System.Windows.Forms.DataGridView dataGridViewHopDong;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Button btnLamMoi;
        private Button btnXemChiTiet;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Button btnThoat;
        private Button btnHuy;
        private Button btnLuu;
        private DataGridViewTextBoxColumn MaHD;
        private DataGridViewTextBoxColumn MaNV;
        private DataGridViewTextBoxColumn LuongCoBan;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Button btnKTHDHetHan;
    }
}