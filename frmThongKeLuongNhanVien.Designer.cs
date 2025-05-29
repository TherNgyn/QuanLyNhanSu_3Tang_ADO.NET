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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvLuong = new DataGridView();
            cbbMaThang = new ComboBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            btnXemLuong = new Button();
            MaNV = new DataGridViewTextBoxColumn();
            Ho = new DataGridViewTextBoxColumn();
            Ten = new DataGridViewTextBoxColumn();
            LuongCoBan = new DataGridViewTextBoxColumn();
            LuongChiuThue = new DataGridViewTextBoxColumn();
            Thue = new DataGridViewTextBoxColumn();
            LuongThucLanh = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // dgvLuong
            // 
            dgvLuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLuong.ColumnHeadersHeight = 34;
            dgvLuong.Columns.AddRange(new DataGridViewColumn[] { MaNV, Ho, Ten, LuongCoBan, LuongChiuThue, Thue, LuongThucLanh });
            dgvLuong.Location = new Point(12, 137);
            dgvLuong.Margin = new Padding(3, 2, 3, 2);
            dgvLuong.Name = "dgvLuong";
            dgvLuong.RowHeadersVisible = false;
            dgvLuong.RowHeadersWidth = 120;
            dgvLuong.Size = new Size(1018, 378);
            dgvLuong.TabIndex = 3;
            // 
            // cbbMaThang
            // 
            cbbMaThang.FormattingEnabled = true;
            cbbMaThang.Location = new Point(116, 27);
            cbbMaThang.Margin = new Padding(3, 2, 3, 2);
            cbbMaThang.Name = "cbbMaThang";
            cbbMaThang.Size = new Size(251, 28);
            cbbMaThang.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.salary;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(38, 75);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(72, 57);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.calendar;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(38, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(72, 57);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // btnXemLuong
            // 
            btnXemLuong.BackColor = Color.Navy;
            btnXemLuong.FlatStyle = FlatStyle.Flat;
            btnXemLuong.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnXemLuong.ForeColor = Color.White;
            btnXemLuong.Location = new Point(138, 81);
            btnXemLuong.Name = "btnXemLuong";
            btnXemLuong.Size = new Size(207, 44);
            btnXemLuong.TabIndex = 12;
            btnXemLuong.Text = "Xem lương";
            btnXemLuong.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnXemLuong.UseVisualStyleBackColor = false;
            btnXemLuong.Click += btnXemLuong_Click;
            // 
            // MaNV
            // 
            MaNV.DataPropertyName = "MaNV";
            MaNV.HeaderText = "Mã NV";
            MaNV.MinimumWidth = 8;
            MaNV.Name = "MaNV";
            // 
            // Ho
            // 
            Ho.DataPropertyName = "Ho";
            Ho.HeaderText = "Họ";
            Ho.MinimumWidth = 8;
            Ho.Name = "Ho";
            // 
            // Ten
            // 
            Ten.DataPropertyName = "Ten";
            Ten.HeaderText = "Tên";
            Ten.MinimumWidth = 8;
            Ten.Name = "Ten";
            // 
            // LuongCoBan
            // 
            LuongCoBan.DataPropertyName = "LuongCoBan";
            LuongCoBan.HeaderText = "Lương Cơ Bản";
            LuongCoBan.MinimumWidth = 6;
            LuongCoBan.Name = "LuongCoBan";
            // 
            // LuongChiuThue
            // 
            LuongChiuThue.DataPropertyName = "LuongChiuThue";
            LuongChiuThue.HeaderText = "Lương Chịu Thuế";
            LuongChiuThue.MinimumWidth = 8;
            LuongChiuThue.Name = "LuongChiuThue";
            // 
            // Thue
            // 
            Thue.DataPropertyName = "Thue";
            Thue.HeaderText = "Thuế thu nhập cá nhân";
            Thue.MinimumWidth = 8;
            Thue.Name = "Thue";
            // 
            // LuongThucLanh
            // 
            LuongThucLanh.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            LuongThucLanh.DataPropertyName = "LuongThucLanh";
            LuongThucLanh.HeaderText = "Lương Thực Lãnh";
            LuongThucLanh.MinimumWidth = 8;
            LuongThucLanh.Name = "LuongThucLanh";
            LuongThucLanh.Width = 155;
            // 
            // frmThongKeLuongNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1042, 527);
            Controls.Add(btnXemLuong);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(cbbMaThang);
            Controls.Add(dgvLuong);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmThongKeLuongNhanVien";
            Text = "FormThongKeLuong";
            Load += frmThongKeLuongNhanVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);

        }

        #endregion
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
    }
}