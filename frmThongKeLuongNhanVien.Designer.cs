namespace QuanLyNhanSu_3Tang_ADO
{
    partial class frmThongKeLuongNhanVien
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

      
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuongCoBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuongChiuThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuongThucLanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbbMaThang = new System.Windows.Forms.ComboBox();
            this.btnXemLuong = new System.Windows.Forms.Button();
            this.btnXemReport = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLuong
            // 
            this.dgvLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLuong.ColumnHeadersHeight = 34;
            this.dgvLuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNV,
            this.Ho,
            this.Ten,
            this.LuongCoBan,
            this.LuongChiuThue,
            this.Thue,
            this.LuongThucLanh});
            this.dgvLuong.Location = new System.Drawing.Point(12, 133);
            this.dgvLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.RowHeadersVisible = false;
            this.dgvLuong.RowHeadersWidth = 120;
            this.dgvLuong.Size = new System.Drawing.Size(1234, 605);
            this.dgvLuong.TabIndex = 3;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã NV";
            this.MaNV.MinimumWidth = 8;
            this.MaNV.Name = "MaNV";
            // 
            // Ho
            // 
            this.Ho.DataPropertyName = "Ho";
            this.Ho.HeaderText = "Họ";
            this.Ho.MinimumWidth = 8;
            this.Ho.Name = "Ho";
            // 
            // Ten
            // 
            this.Ten.DataPropertyName = "Ten";
            this.Ten.HeaderText = "Tên";
            this.Ten.MinimumWidth = 8;
            this.Ten.Name = "Ten";
            // 
            // LuongCoBan
            // 
            this.LuongCoBan.DataPropertyName = "LuongCoBan";
            this.LuongCoBan.HeaderText = "Lương Cơ Bản";
            this.LuongCoBan.MinimumWidth = 6;
            this.LuongCoBan.Name = "LuongCoBan";
            // 
            // LuongChiuThue
            // 
            this.LuongChiuThue.DataPropertyName = "LuongChiuThue";
            this.LuongChiuThue.HeaderText = "Lương Chịu Thuế";
            this.LuongChiuThue.MinimumWidth = 8;
            this.LuongChiuThue.Name = "LuongChiuThue";
            // 
            // Thue
            // 
            this.Thue.DataPropertyName = "Thue";
            this.Thue.HeaderText = "Thuế thu nhập cá nhân";
            this.Thue.MinimumWidth = 8;
            this.Thue.Name = "Thue";
            // 
            // LuongThucLanh
            // 
            this.LuongThucLanh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LuongThucLanh.DataPropertyName = "LuongThucLanh";
            this.LuongThucLanh.HeaderText = "Lương Thực Lãnh";
            this.LuongThucLanh.MinimumWidth = 8;
            this.LuongThucLanh.Name = "LuongThucLanh";
            this.LuongThucLanh.Width = 155;
            // 
            // cbbMaThang
            // 
            this.cbbMaThang.FormattingEnabled = true;
            this.cbbMaThang.Location = new System.Drawing.Point(109, 45);
            this.cbbMaThang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbMaThang.Name = "cbbMaThang";
            this.cbbMaThang.Size = new System.Drawing.Size(216, 24);
            this.cbbMaThang.TabIndex = 9;
            // 
            // btnXemLuong
            // 
            this.btnXemLuong.BackColor = System.Drawing.Color.Navy;
            this.btnXemLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXemLuong.ForeColor = System.Drawing.Color.White;
            this.btnXemLuong.Location = new System.Drawing.Point(355, 31);
            this.btnXemLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXemLuong.Name = "btnXemLuong";
            this.btnXemLuong.Size = new System.Drawing.Size(207, 49);
            this.btnXemLuong.TabIndex = 12;
            this.btnXemLuong.Text = "Xem lương";
            this.btnXemLuong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemLuong.UseVisualStyleBackColor = false;
            this.btnXemLuong.Click += new System.EventHandler(this.btnXemLuong_Click);
            // 
            // btnXemReport
            // 
            this.btnXemReport.BackColor = System.Drawing.Color.Navy;
            this.btnXemReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemReport.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXemReport.ForeColor = System.Drawing.Color.White;
            this.btnXemReport.Location = new System.Drawing.Point(1039, 31);
            this.btnXemReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXemReport.Name = "btnXemReport";
            this.btnXemReport.Size = new System.Drawing.Size(207, 69);
            this.btnXemReport.TabIndex = 13;
            this.btnXemReport.Text = "Xem báo cáo lương theo hợp đồng";
            this.btnXemReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemReport.UseVisualStyleBackColor = false;
            this.btnXemReport.Click += new System.EventHandler(this.btnXemReport_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::QuanLyNhanSu_3Tang_ADO.Properties.Resources.calendar;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(22, 27);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(72, 60);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QuanLyNhanSu_3Tang_ADO.Properties.Resources.salary;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(951, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 69);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // frmThongKeLuongNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1258, 749);
            this.Controls.Add(this.btnXemReport);
            this.Controls.Add(this.btnXemLuong);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbbMaThang);
            this.Controls.Add(this.dgvLuong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimizeBox = false;
            this.Name = "frmThongKeLuongNhanVien";
            this.Text = "Thống kê lương nhân viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmThongKeLuongNhanVien_FormClosing);
            this.Load += new System.EventHandler(this.frmThongKeLuongNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        private ComboBox cbbMaThang;
        private DataGridView dgvLuong;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnXemLuong;
        private DataGridViewTextBoxColumn MaNV;
        private DataGridViewTextBoxColumn Ho;
        private DataGridViewTextBoxColumn Ten;
        private DataGridViewTextBoxColumn LuongCoBan;
        private DataGridViewTextBoxColumn LuongChiuThue;
        private DataGridViewTextBoxColumn Thue;
        private DataGridViewTextBoxColumn LuongThucLanh;

        private Button btnXemReport;
    }
}