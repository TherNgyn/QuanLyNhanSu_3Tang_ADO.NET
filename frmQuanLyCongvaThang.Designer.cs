namespace QuanLyNhanSu_3Tang_ADO
{
    partial class frmQuanLyCongvaThang
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            btnLamMoi = new Button();
            dataGVThang = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            btnSuaThang = new Button();
            txtMoTa = new TextBox();
            txtMaThang = new TextBox();
            lblSoNgayCong = new Label();
            btnThemThang = new Button();
            lblMoTa = new Label();
            txtSoNgayCong = new TextBox();
            lblMaThang = new Label();
            guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            btnLamMoiCong = new Button();
            dataGVCong = new DataGridView();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            btnSuaCong = new Button();
            txtMoTaCong = new TextBox();
            btnThemCong = new Button();
            txtMaCC = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtHeSo = new TextBox();
            label3 = new Label();
            btnThoat = new Button();
            guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGVThang).BeginInit();
            guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGVCong).BeginInit();
            SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            guna2GroupBox1.BackColor = Color.White;
            guna2GroupBox1.BorderColor = Color.SteelBlue;
            guna2GroupBox1.Controls.Add(btnLamMoi);
            guna2GroupBox1.Controls.Add(dataGVThang);
            guna2GroupBox1.Controls.Add(btnSuaThang);
            guna2GroupBox1.Controls.Add(txtMoTa);
            guna2GroupBox1.Controls.Add(txtMaThang);
            guna2GroupBox1.Controls.Add(lblSoNgayCong);
            guna2GroupBox1.Controls.Add(btnThemThang);
            guna2GroupBox1.Controls.Add(lblMoTa);
            guna2GroupBox1.Controls.Add(txtSoNgayCong);
            guna2GroupBox1.Controls.Add(lblMaThang);
            guna2GroupBox1.CustomBorderColor = Color.SteelBlue;
            guna2GroupBox1.CustomizableEdges = customizableEdges1;
            guna2GroupBox1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            guna2GroupBox1.ForeColor = Color.Black;
            guna2GroupBox1.Location = new Point(12, 12);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2GroupBox1.Size = new Size(1023, 312);
            guna2GroupBox1.TabIndex = 23;
            guna2GroupBox1.Text = "QUẢN LÝ THÁNG ";
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.LavenderBlush;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLamMoi.ImageAlign = ContentAlignment.MiddleRight;
            btnLamMoi.Location = new Point(286, 243);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(112, 34);
            btnLamMoi.TabIndex = 20;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dataGVThang
            // 
            dataGVThang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGVThang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVThang.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dataGVThang.Location = new Point(417, 43);
            dataGVThang.Name = "dataGVThang";
            dataGVThang.ReadOnly = true;
            dataGVThang.RowHeadersVisible = false;
            dataGVThang.RowHeadersWidth = 51;
            dataGVThang.RowTemplate.Height = 24;
            dataGVThang.Size = new Size(584, 234);
            dataGVThang.TabIndex = 19;
            dataGVThang.CellClick += dataGVThang_CellClick;
            dataGVThang.DoubleClick += dataGVThang_DoubleClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "MaThang";
            dataGridViewTextBoxColumn1.HeaderText = "Mã tháng";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "MoTa";
            dataGridViewTextBoxColumn2.HeaderText = "Mô tả";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "SoNgayCongChuan";
            dataGridViewTextBoxColumn3.HeaderText = "Số ngày công";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // btnSuaThang
            // 
            btnSuaThang.BackColor = Color.LavenderBlush;
            btnSuaThang.FlatStyle = FlatStyle.Flat;
            btnSuaThang.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSuaThang.ImageAlign = ContentAlignment.MiddleRight;
            btnSuaThang.Location = new Point(152, 243);
            btnSuaThang.Name = "btnSuaThang";
            btnSuaThang.Size = new Size(112, 34);
            btnSuaThang.TabIndex = 17;
            btnSuaThang.Text = "Sửa";
            btnSuaThang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSuaThang.UseVisualStyleBackColor = false;
            btnSuaThang.Click += btnSuaThang_Click;
            // 
            // txtMoTa
            // 
            txtMoTa.BorderStyle = BorderStyle.FixedSingle;
            txtMoTa.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMoTa.Location = new Point(196, 97);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(202, 30);
            txtMoTa.TabIndex = 18;
            // 
            // txtMaThang
            // 
            txtMaThang.BorderStyle = BorderStyle.FixedSingle;
            txtMaThang.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaThang.Location = new Point(196, 43);
            txtMaThang.Name = "txtMaThang";
            txtMaThang.Size = new Size(202, 30);
            txtMaThang.TabIndex = 16;
            // 
            // lblSoNgayCong
            // 
            lblSoNgayCong.AutoSize = true;
            lblSoNgayCong.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSoNgayCong.Location = new Point(33, 159);
            lblSoNgayCong.Name = "lblSoNgayCong";
            lblSoNgayCong.Size = new Size(175, 22);
            lblSoNgayCong.TabIndex = 11;
            lblSoNgayCong.Text = "Số ngày công chuẩn: ";
            // 
            // btnThemThang
            // 
            btnThemThang.BackColor = Color.LavenderBlush;
            btnThemThang.FlatStyle = FlatStyle.Flat;
            btnThemThang.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThemThang.ImageAlign = ContentAlignment.MiddleRight;
            btnThemThang.Location = new Point(26, 243);
            btnThemThang.Name = "btnThemThang";
            btnThemThang.Size = new Size(112, 34);
            btnThemThang.TabIndex = 15;
            btnThemThang.Text = "Thêm";
            btnThemThang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThemThang.UseVisualStyleBackColor = false;
            btnThemThang.Click += btnThemThang_Click;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoTa.Location = new Point(33, 105);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(67, 22);
            lblMoTa.TabIndex = 12;
            lblMoTa.Text = "Mô tả: ";
            // 
            // txtSoNgayCong
            // 
            txtSoNgayCong.BorderStyle = BorderStyle.FixedSingle;
            txtSoNgayCong.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoNgayCong.Location = new Point(239, 157);
            txtSoNgayCong.Name = "txtSoNgayCong";
            txtSoNgayCong.Size = new Size(159, 30);
            txtSoNgayCong.TabIndex = 14;
            // 
            // lblMaThang
            // 
            lblMaThang.AutoSize = true;
            lblMaThang.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaThang.Location = new Point(33, 51);
            lblMaThang.Name = "lblMaThang";
            lblMaThang.Size = new Size(93, 22);
            lblMaThang.TabIndex = 13;
            lblMaThang.Text = "Mã tháng: ";
            // 
            // guna2GroupBox2
            // 
            guna2GroupBox2.BackColor = Color.White;
            guna2GroupBox2.BorderColor = Color.Navy;
            guna2GroupBox2.Controls.Add(btnLamMoiCong);
            guna2GroupBox2.Controls.Add(dataGVCong);
            guna2GroupBox2.Controls.Add(btnSuaCong);
            guna2GroupBox2.Controls.Add(txtMoTaCong);
            guna2GroupBox2.Controls.Add(btnThemCong);
            guna2GroupBox2.Controls.Add(txtMaCC);
            guna2GroupBox2.Controls.Add(label1);
            guna2GroupBox2.Controls.Add(label2);
            guna2GroupBox2.Controls.Add(txtHeSo);
            guna2GroupBox2.Controls.Add(label3);
            guna2GroupBox2.CustomBorderColor = Color.SteelBlue;
            guna2GroupBox2.CustomizableEdges = customizableEdges3;
            guna2GroupBox2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            guna2GroupBox2.ForeColor = Color.Black;
            guna2GroupBox2.Location = new Point(12, 330);
            guna2GroupBox2.Name = "guna2GroupBox2";
            guna2GroupBox2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2GroupBox2.Size = new Size(1023, 295);
            guna2GroupBox2.TabIndex = 24;
            guna2GroupBox2.Text = "QUẢN LÝ CÔNG";
            // 
            // btnLamMoiCong
            // 
            btnLamMoiCong.BackColor = Color.LavenderBlush;
            btnLamMoiCong.FlatStyle = FlatStyle.Flat;
            btnLamMoiCong.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLamMoiCong.ImageAlign = ContentAlignment.MiddleRight;
            btnLamMoiCong.Location = new Point(286, 241);
            btnLamMoiCong.Name = "btnLamMoiCong";
            btnLamMoiCong.Size = new Size(112, 34);
            btnLamMoiCong.TabIndex = 21;
            btnLamMoiCong.Text = "Làm mới";
            btnLamMoiCong.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLamMoiCong.UseVisualStyleBackColor = false;
            btnLamMoiCong.Click += btnLamMoiCong_Click;
            // 
            // dataGVCong
            // 
            dataGVCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGVCong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVCong.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dataGVCong.Location = new Point(417, 65);
            dataGVCong.Name = "dataGVCong";
            dataGVCong.ReadOnly = true;
            dataGVCong.RowHeadersVisible = false;
            dataGVCong.RowHeadersWidth = 51;
            dataGVCong.RowTemplate.Height = 24;
            dataGVCong.Size = new Size(590, 210);
            dataGVCong.TabIndex = 19;
            dataGVCong.CellClick += dataGVCong_CellClick;
            dataGVCong.DoubleClick += dataGVCong_DoubleClick;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "MaCC";
            dataGridViewTextBoxColumn4.HeaderText = "Mã chấm công";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "MoTa";
            dataGridViewTextBoxColumn5.HeaderText = "Mô tả";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "HeSo";
            dataGridViewTextBoxColumn6.HeaderText = "Hệ số";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // btnSuaCong
            // 
            btnSuaCong.BackColor = Color.LavenderBlush;
            btnSuaCong.FlatStyle = FlatStyle.Flat;
            btnSuaCong.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSuaCong.ImageAlign = ContentAlignment.MiddleRight;
            btnSuaCong.Location = new Point(152, 241);
            btnSuaCong.Name = "btnSuaCong";
            btnSuaCong.Size = new Size(112, 34);
            btnSuaCong.TabIndex = 22;
            btnSuaCong.Text = "Sửa";
            btnSuaCong.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSuaCong.UseVisualStyleBackColor = false;
            btnSuaCong.Click += btnSuaCong_Click;
            // 
            // txtMoTaCong
            // 
            txtMoTaCong.BorderStyle = BorderStyle.FixedSingle;
            txtMoTaCong.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMoTaCong.Location = new Point(196, 120);
            txtMoTaCong.Name = "txtMoTaCong";
            txtMoTaCong.Size = new Size(198, 30);
            txtMoTaCong.TabIndex = 18;
            // 
            // btnThemCong
            // 
            btnThemCong.BackColor = Color.LavenderBlush;
            btnThemCong.FlatStyle = FlatStyle.Flat;
            btnThemCong.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThemCong.ImageAlign = ContentAlignment.MiddleRight;
            btnThemCong.Location = new Point(26, 241);
            btnThemCong.Name = "btnThemCong";
            btnThemCong.Size = new Size(112, 34);
            btnThemCong.TabIndex = 20;
            btnThemCong.Text = "Thêm";
            btnThemCong.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThemCong.UseVisualStyleBackColor = false;
            btnThemCong.Click += btnThemCong_Click;
            // 
            // txtMaCC
            // 
            txtMaCC.BorderStyle = BorderStyle.FixedSingle;
            txtMaCC.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaCC.Location = new Point(196, 66);
            txtMaCC.Name = "txtMaCC";
            txtMaCC.Size = new Size(198, 30);
            txtMaCC.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 182);
            label1.Name = "label1";
            label1.Size = new Size(62, 22);
            label1.TabIndex = 13;
            label1.Text = "Hệ số:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(33, 128);
            label2.Name = "label2";
            label2.Size = new Size(67, 22);
            label2.TabIndex = 14;
            label2.Text = "Mô tả: ";
            // 
            // txtHeSo
            // 
            txtHeSo.BorderStyle = BorderStyle.FixedSingle;
            txtHeSo.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHeSo.Location = new Point(239, 180);
            txtHeSo.Name = "txtHeSo";
            txtHeSo.Size = new Size(155, 30);
            txtHeSo.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(33, 74);
            label3.Name = "label3";
            label3.Size = new Size(135, 22);
            label3.TabIndex = 15;
            label3.Text = "Mã chấm công: ";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.LavenderBlush;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.ImageAlign = ContentAlignment.MiddleRight;
            btnThoat.Location = new Point(923, 631);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(112, 34);
            btnThoat.TabIndex = 23;
            btnThoat.Text = "Thoát";
            btnThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // frmQuanLyCongvaThang
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1060, 670);
            Controls.Add(btnThoat);
            Controls.Add(guna2GroupBox2);
            Controls.Add(guna2GroupBox1);
            Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "frmQuanLyCongvaThang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormQuanLyCong";
            Load += FormQuanLyThangCong_Load;
            guna2GroupBox1.ResumeLayout(false);
            guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGVThang).EndInit();
            guna2GroupBox2.ResumeLayout(false);
            guna2GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGVCong).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dataGVThang;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnSuaThang;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtMaThang;
        private System.Windows.Forms.Label lblSoNgayCong;
        private System.Windows.Forms.Button btnThemThang;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtSoNgayCong;
        private System.Windows.Forms.Label lblMaThang;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.Windows.Forms.Button btnLamMoiCong;
        private System.Windows.Forms.DataGridView dataGVCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnSuaCong;
        private System.Windows.Forms.TextBox txtMoTaCong;
        private System.Windows.Forms.Button btnThemCong;
        private System.Windows.Forms.TextBox txtMaCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeSo;
        private System.Windows.Forms.Label label3;
        private Button btnThoat;
    }
}