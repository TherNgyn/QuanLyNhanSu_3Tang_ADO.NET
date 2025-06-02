namespace QuanLyNhanSu_3Tang_ADO
{
    partial class frmQuanLyThuongPhat
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

    
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dataGridViewTP = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMaTP = new System.Windows.Forms.TextBox();
            this.lblMaTP = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cbbLoai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTien = new System.Windows.Forms.Label();
            this.txtTien = new System.Windows.Forms.TextBox();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnSuaTPNV = new System.Windows.Forms.Button();
            this.btnXoaTPNV = new System.Windows.Forms.Button();
            this.btnThemTPNV = new System.Windows.Forms.Button();
            this.txtNgayTP = new System.Windows.Forms.TextBox();
            this.cbbMaThang = new System.Windows.Forms.ComboBox();
            this.lblMaThang = new System.Windows.Forms.Label();
            this.cbbMaTP = new System.Windows.Forms.ComboBox();
            this.dataGridViewCTTP = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.cbbMaNV = new System.Windows.Forms.ComboBox();
            this.lblNgay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXemThuongHayPhat = new System.Windows.Forms.Button();
            this.rbPhat = new System.Windows.Forms.RadioButton();
            this.rbThuong = new System.Windows.Forms.RadioButton();
            this.panelFormCTThuongPhat = new System.Windows.Forms.Panel();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTP)).BeginInit();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCTTP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Navy;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(375, 598);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(103, 39);
            this.btnSua.TabIndex = 37;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Navy;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(249, 598);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(103, 39);
            this.btnXoa.TabIndex = 38;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Navy;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(123, 598);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(103, 39);
            this.btnThem.TabIndex = 39;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Navy;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(77, 690);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(257, 48);
            this.btnLamMoi.TabIndex = 35;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Navy;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(364, 690);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(257, 48);
            this.btnThoat.TabIndex = 29;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.White;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Navy;
            this.guna2GroupBox1.Controls.Add(this.btnSua);
            this.guna2GroupBox1.Controls.Add(this.dataGridViewTP);
            this.guna2GroupBox1.Controls.Add(this.btnXoa);
            this.guna2GroupBox1.Controls.Add(this.txtMaTP);
            this.guna2GroupBox1.Controls.Add(this.btnThem);
            this.guna2GroupBox1.Controls.Add(this.lblMaTP);
            this.guna2GroupBox1.Controls.Add(this.lblLoai);
            this.guna2GroupBox1.Controls.Add(this.cbbLoai);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Controls.Add(this.lblTien);
            this.guna2GroupBox1.Controls.Add(this.txtTien);
            this.guna2GroupBox1.Controls.Add(this.txtLyDo);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.SteelBlue;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(601, 660);
            this.guna2GroupBox1.TabIndex = 38;
            this.guna2GroupBox1.Text = "THƯỞNG PHẠT";
            // 
            // dataGridViewTP
            // 
            this.dataGridViewTP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewTP.Location = new System.Drawing.Point(31, 232);
            this.dataGridViewTP.Name = "dataGridViewTP";
            this.dataGridViewTP.RowHeadersVisible = false;
            this.dataGridViewTP.RowHeadersWidth = 51;
            this.dataGridViewTP.RowTemplate.Height = 24;
            this.dataGridViewTP.Size = new System.Drawing.Size(540, 347);
            this.dataGridViewTP.TabIndex = 41;
            this.dataGridViewTP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCTTP_CellContentClick);
            this.dataGridViewTP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTP_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaThuongPhat";
            this.Column1.HeaderText = "Mã thưởng phạt";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Loai";
            this.Column2.HeaderText = "Loại";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SoTien";
            this.Column3.HeaderText = "Số Tiền";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "LyDo";
            this.Column4.HeaderText = "Lý do";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // txtMaTP
            // 
            this.txtMaTP.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtMaTP.Location = new System.Drawing.Point(221, 63);
            this.txtMaTP.Name = "txtMaTP";
            this.txtMaTP.Size = new System.Drawing.Size(297, 30);
            this.txtMaTP.TabIndex = 39;
            // 
            // lblMaTP
            // 
            this.lblMaTP.AutoSize = true;
            this.lblMaTP.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblMaTP.Location = new System.Drawing.Point(54, 66);
            this.lblMaTP.Name = "lblMaTP";
            this.lblMaTP.Size = new System.Drawing.Size(144, 22);
            this.lblMaTP.TabIndex = 32;
            this.lblMaTP.Text = "Mã thưởng phạt: ";
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblLoai.Location = new System.Drawing.Point(54, 106);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(57, 22);
            this.lblLoai.TabIndex = 33;
            this.lblLoai.Text = "Loại: ";
            // 
            // cbbLoai
            // 
            this.cbbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLoai.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cbbLoai.FormattingEnabled = true;
            this.cbbLoai.Items.AddRange(new object[] {
            "Thưởng",
            "Phạt"});
            this.cbbLoai.Location = new System.Drawing.Point(221, 103);
            this.cbbLoai.Name = "cbbLoai";
            this.cbbLoai.Size = new System.Drawing.Size(297, 30);
            this.cbbLoai.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label1.Location = new System.Drawing.Point(54, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 22);
            this.label1.TabIndex = 35;
            this.label1.Text = "Lý do:";
            // 
            // lblTien
            // 
            this.lblTien.AutoSize = true;
            this.lblTien.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblTien.Location = new System.Drawing.Point(54, 147);
            this.lblTien.Name = "lblTien";
            this.lblTien.Size = new System.Drawing.Size(51, 22);
            this.lblTien.TabIndex = 34;
            this.lblTien.Text = "Tiền:";
            // 
            // txtTien
            // 
            this.txtTien.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtTien.Location = new System.Drawing.Point(221, 144);
            this.txtTien.Name = "txtTien";
            this.txtTien.Size = new System.Drawing.Size(297, 30);
            this.txtTien.TabIndex = 36;
            // 
            // txtLyDo
            // 
            this.txtLyDo.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtLyDo.Location = new System.Drawing.Point(221, 183);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(297, 30);
            this.txtLyDo.TabIndex = 37;
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BackColor = System.Drawing.Color.White;
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.Navy;
            this.guna2GroupBox2.Controls.Add(this.btnSuaTPNV);
            this.guna2GroupBox2.Controls.Add(this.btnXoaTPNV);
            this.guna2GroupBox2.Controls.Add(this.btnThemTPNV);
            this.guna2GroupBox2.Controls.Add(this.txtNgayTP);
            this.guna2GroupBox2.Controls.Add(this.cbbMaThang);
            this.guna2GroupBox2.Controls.Add(this.lblMaThang);
            this.guna2GroupBox2.Controls.Add(this.cbbMaTP);
            this.guna2GroupBox2.Controls.Add(this.dataGridViewCTTP);
            this.guna2GroupBox2.Controls.Add(this.lblMaNV);
            this.guna2GroupBox2.Controls.Add(this.cbbMaNV);
            this.guna2GroupBox2.Controls.Add(this.lblNgay);
            this.guna2GroupBox2.Controls.Add(this.label2);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.SteelBlue;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox2.Location = new System.Drawing.Point(637, 12);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(609, 660);
            this.guna2GroupBox2.TabIndex = 39;
            this.guna2GroupBox2.Text = " CHI TIẾT THƯỞNG PHẠT";
            // 
            // btnSuaTPNV
            // 
            this.btnSuaTPNV.BackColor = System.Drawing.Color.Navy;
            this.btnSuaTPNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaTPNV.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnSuaTPNV.ForeColor = System.Drawing.Color.Transparent;
            this.btnSuaTPNV.Location = new System.Drawing.Point(414, 598);
            this.btnSuaTPNV.Name = "btnSuaTPNV";
            this.btnSuaTPNV.Size = new System.Drawing.Size(103, 39);
            this.btnSuaTPNV.TabIndex = 58;
            this.btnSuaTPNV.Text = "Sửa";
            this.btnSuaTPNV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuaTPNV.UseVisualStyleBackColor = false;
            this.btnSuaTPNV.Click += new System.EventHandler(this.btnSuaTPNV_Click);
            // 
            // btnXoaTPNV
            // 
            this.btnXoaTPNV.BackColor = System.Drawing.Color.Navy;
            this.btnXoaTPNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTPNV.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnXoaTPNV.ForeColor = System.Drawing.Color.Transparent;
            this.btnXoaTPNV.Location = new System.Drawing.Point(264, 598);
            this.btnXoaTPNV.Name = "btnXoaTPNV";
            this.btnXoaTPNV.Size = new System.Drawing.Size(103, 39);
            this.btnXoaTPNV.TabIndex = 59;
            this.btnXoaTPNV.Text = "Xoá";
            this.btnXoaTPNV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaTPNV.UseVisualStyleBackColor = false;
            this.btnXoaTPNV.Click += new System.EventHandler(this.btnXoaTPNV_Click);
            // 
            // btnThemTPNV
            // 
            this.btnThemTPNV.BackColor = System.Drawing.Color.Navy;
            this.btnThemTPNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTPNV.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnThemTPNV.ForeColor = System.Drawing.Color.Transparent;
            this.btnThemTPNV.Location = new System.Drawing.Point(116, 598);
            this.btnThemTPNV.Name = "btnThemTPNV";
            this.btnThemTPNV.Size = new System.Drawing.Size(103, 39);
            this.btnThemTPNV.TabIndex = 60;
            this.btnThemTPNV.Text = "Thêm";
            this.btnThemTPNV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemTPNV.UseVisualStyleBackColor = false;
            this.btnThemTPNV.Click += new System.EventHandler(this.btnThemTPNV_Click);
            // 
            // txtNgayTP
            // 
            this.txtNgayTP.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtNgayTP.Location = new System.Drawing.Point(278, 183);
            this.txtNgayTP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNgayTP.Name = "txtNgayTP";
            this.txtNgayTP.Size = new System.Drawing.Size(270, 30);
            this.txtNgayTP.TabIndex = 53;
            // 
            // cbbMaThang
            // 
            this.cbbMaThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaThang.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cbbMaThang.FormattingEnabled = true;
            this.cbbMaThang.Location = new System.Drawing.Point(278, 143);
            this.cbbMaThang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbMaThang.Name = "cbbMaThang";
            this.cbbMaThang.Size = new System.Drawing.Size(270, 30);
            this.cbbMaThang.TabIndex = 57;
            // 
            // lblMaThang
            // 
            this.lblMaThang.AutoSize = true;
            this.lblMaThang.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblMaThang.Location = new System.Drawing.Point(74, 153);
            this.lblMaThang.Name = "lblMaThang";
            this.lblMaThang.Size = new System.Drawing.Size(82, 22);
            this.lblMaThang.TabIndex = 56;
            this.lblMaThang.Text = "Mã tháng";
            // 
            // cbbMaTP
            // 
            this.cbbMaTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaTP.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cbbMaTP.FormattingEnabled = true;
            this.cbbMaTP.Location = new System.Drawing.Point(278, 103);
            this.cbbMaTP.Name = "cbbMaTP";
            this.cbbMaTP.Size = new System.Drawing.Size(270, 30);
            this.cbbMaTP.TabIndex = 54;
            // 
            // dataGridViewCTTP
            // 
            this.dataGridViewCTTP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCTTP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCTTP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridViewCTTP.Location = new System.Drawing.Point(38, 232);
            this.dataGridViewCTTP.Name = "dataGridViewCTTP";
            this.dataGridViewCTTP.RowHeadersVisible = false;
            this.dataGridViewCTTP.RowHeadersWidth = 51;
            this.dataGridViewCTTP.RowTemplate.Height = 24;
            this.dataGridViewCTTP.Size = new System.Drawing.Size(553, 347);
            this.dataGridViewCTTP.TabIndex = 52;
            this.dataGridViewCTTP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCTTP_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaNV";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã nhân viên";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MaThuongPhat";
            this.dataGridViewTextBoxColumn2.HeaderText = "Mã thưởng phạt";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MaThang";
            this.dataGridViewTextBoxColumn3.HeaderText = "Mã Tháng";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NgayThuongPhat";
            this.dataGridViewTextBoxColumn4.HeaderText = "Ngày thưởng phạt";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblMaNV.Location = new System.Drawing.Point(74, 66);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(122, 22);
            this.lblMaNV.TabIndex = 46;
            this.lblMaNV.Text = "Mã nhân viên:";
            // 
            // cbbMaNV
            // 
            this.cbbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaNV.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cbbMaNV.FormattingEnabled = true;
            this.cbbMaNV.Location = new System.Drawing.Point(278, 63);
            this.cbbMaNV.Name = "cbbMaNV";
            this.cbbMaNV.Size = new System.Drawing.Size(270, 30);
            this.cbbMaNV.Sorted = true;
            this.cbbMaNV.TabIndex = 47;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNgay.Location = new System.Drawing.Point(74, 189);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(159, 22);
            this.lblNgay.TabIndex = 48;
            this.lblNgay.Text = "Ngày thưởng phạt: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(74, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 22);
            this.label2.TabIndex = 45;
            this.label2.Text = "Mã thưởng phạt:";
            // 
            // btnXemThuongHayPhat
            // 
            this.btnXemThuongHayPhat.BackColor = System.Drawing.Color.Navy;
            this.btnXemThuongHayPhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemThuongHayPhat.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnXemThuongHayPhat.ForeColor = System.Drawing.Color.White;
            this.btnXemThuongHayPhat.Location = new System.Drawing.Point(675, 690);
            this.btnXemThuongHayPhat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXemThuongHayPhat.Name = "btnXemThuongHayPhat";
            this.btnXemThuongHayPhat.Size = new System.Drawing.Size(257, 48);
            this.btnXemThuongHayPhat.TabIndex = 40;
            this.btnXemThuongHayPhat.Text = "Lọc loại thưởng/phạt";
            this.btnXemThuongHayPhat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemThuongHayPhat.UseVisualStyleBackColor = false;
            this.btnXemThuongHayPhat.Click += new System.EventHandler(this.btnXemThuongHayPhat_Click);
            // 
            // rbPhat
            // 
            this.rbPhat.AutoSize = true;
            this.rbPhat.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.rbPhat.Location = new System.Drawing.Point(1094, 703);
            this.rbPhat.Name = "rbPhat";
            this.rbPhat.Size = new System.Drawing.Size(60, 23);
            this.rbPhat.TabIndex = 42;
            this.rbPhat.TabStop = true;
            this.rbPhat.Text = "Phạt";
            this.rbPhat.UseVisualStyleBackColor = true;
            // 
            // rbThuong
            // 
            this.rbThuong.AutoSize = true;
            this.rbThuong.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.rbThuong.Location = new System.Drawing.Point(972, 703);
            this.rbThuong.Name = "rbThuong";
            this.rbThuong.Size = new System.Drawing.Size(81, 23);
            this.rbThuong.TabIndex = 41;
            this.rbThuong.TabStop = true;
            this.rbThuong.Text = "Thưởng";
            this.rbThuong.UseVisualStyleBackColor = true;
            // 
            // panelFormCTThuongPhat
            // 
            this.panelFormCTThuongPhat.AccessibleRole = System.Windows.Forms.AccessibleRole.Column;
            this.panelFormCTThuongPhat.AllowDrop = true;
            this.panelFormCTThuongPhat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFormCTThuongPhat.Location = new System.Drawing.Point(12, 244);
            this.panelFormCTThuongPhat.Name = "panelFormCTThuongPhat";
            this.panelFormCTThuongPhat.Padding = new System.Windows.Forms.Padding(5);
            this.panelFormCTThuongPhat.Size = new System.Drawing.Size(1142, 428);
            this.panelFormCTThuongPhat.TabIndex = 0;
            this.panelFormCTThuongPhat.Visible = false;
            // 
            // frmQuanLyThuongPhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1258, 749);
            this.Controls.Add(this.panelFormCTThuongPhat);
            this.Controls.Add(this.rbPhat);
            this.Controls.Add(this.rbThuong);
            this.Controls.Add(this.btnXemThuongHayPhat);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.guna2GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "frmQuanLyThuongPhat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thưởng/phạt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuanLyThuongPhat_FormClosing);
            this.Load += new System.EventHandler(this.FormThuongPhat_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTP)).EndInit();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCTTP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private DataGridView dataGridViewTP;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private TextBox txtMaTP;
        private Label lblMaTP;
        private Label lblLoai;
        private ComboBox cbbLoai;
        private Label label1;
        private Label lblTien;
        private TextBox txtTien;
        private TextBox txtLyDo;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Button btnSuaTPNV;
        private Button btnXoaTPNV;
        private Button btnThemTPNV;
        private TextBox txtNgayTP;
        private ComboBox cbbMaThang;
        private Label lblMaThang;
        private ComboBox cbbMaTP;
        private DataGridView dataGridViewCTTP;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Label lblMaNV;
        private ComboBox cbbMaNV;
        private Label lblNgay;
        private Label label2;
        private Button btnXemThuongHayPhat;
        private RadioButton rbThuong;
        private RadioButton rbPhat;
        private Panel panelFormCTThuongPhat;
        
    }
}
