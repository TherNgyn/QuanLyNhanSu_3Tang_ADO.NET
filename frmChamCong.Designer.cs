namespace QuanLyNhanSu_3Tang_ADO
{
    partial class frmChamCong
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
            dataGridViewChamCong = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            Thang = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            HeSo = new DataGridViewTextBoxColumn();
            fontDialog1 = new FontDialog();
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            cbbLoaiChamCong = new ComboBox();
            btnChamCong = new Button();
            txtMaNV = new TextBox();
            lblMaNV = new Label();
            guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChamCong).BeginInit();
            guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2GroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewChamCong
            // 
            dataGridViewChamCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewChamCong.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewChamCong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewChamCong.Columns.AddRange(new DataGridViewColumn[] { Column2, Thang, Column3, HeSo });
            dataGridViewChamCong.Location = new Point(6, 43);
            dataGridViewChamCong.Name = "dataGridViewChamCong";
            dataGridViewChamCong.ReadOnly = true;
            dataGridViewChamCong.RowHeadersVisible = false;
            dataGridViewChamCong.RowHeadersWidth = 51;
            dataGridViewChamCong.RowTemplate.Height = 24;
            dataGridViewChamCong.Size = new Size(772, 189);
            dataGridViewChamCong.TabIndex = 4;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "NgayChamCong";
            Column2.HeaderText = "Ngày chấm công";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Thang
            // 
            Thang.DataPropertyName = "Thang";
            Thang.HeaderText = "Tháng";
            Thang.MinimumWidth = 8;
            Thang.Name = "Thang";
            Thang.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "MoTa";
            Column3.HeaderText = "Mô tả";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // HeSo
            // 
            HeSo.DataPropertyName = "HeSo";
            HeSo.HeaderText = "Hệ số";
            HeSo.MinimumWidth = 8;
            HeSo.Name = "HeSo";
            HeSo.ReadOnly = true;
            // 
            // guna2GroupBox1
            // 
            guna2GroupBox1.Controls.Add(pictureBox1);
            guna2GroupBox1.Controls.Add(label1);
            guna2GroupBox1.Controls.Add(cbbLoaiChamCong);
            guna2GroupBox1.Controls.Add(btnChamCong);
            guna2GroupBox1.Controls.Add(txtMaNV);
            guna2GroupBox1.Controls.Add(lblMaNV);
            guna2GroupBox1.CustomBorderColor = Color.SteelBlue;
            guna2GroupBox1.CustomizableEdges = customizableEdges1;
            guna2GroupBox1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            guna2GroupBox1.ForeColor = Color.Black;
            guna2GroupBox1.Location = new Point(12, 12);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2GroupBox1.Size = new Size(781, 173);
            guna2GroupBox1.TabIndex = 10;
            guna2GroupBox1.Text = "THÔNG TIN CHẤM CÔNG";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.back_in_time;
            pictureBox1.Location = new Point(429, 61);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 63);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(21, 117);
            label1.Name = "label1";
            label1.Size = new Size(140, 22);
            label1.TabIndex = 14;
            label1.Text = "Loại chấm công:";
            // 
            // cbbLoaiChamCong
            // 
            cbbLoaiChamCong.FormattingEnabled = true;
            cbbLoaiChamCong.Location = new Point(167, 113);
            cbbLoaiChamCong.Name = "cbbLoaiChamCong";
            cbbLoaiChamCong.Size = new Size(204, 31);
            cbbLoaiChamCong.TabIndex = 13;
            // 
            // btnChamCong
            // 
            btnChamCong.BackColor = Color.Navy;
            btnChamCong.FlatStyle = FlatStyle.Flat;
            btnChamCong.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnChamCong.ForeColor = Color.White;
            btnChamCong.Location = new Point(506, 70);
            btnChamCong.Name = "btnChamCong";
            btnChamCong.Size = new Size(237, 44);
            btnChamCong.TabIndex = 11;
            btnChamCong.Text = "Chấm công";
            btnChamCong.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnChamCong.UseVisualStyleBackColor = false;
            btnChamCong.Click += btnChamCong_Click;
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(167, 57);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(204, 30);
            txtMaNV.TabIndex = 12;
            // 
            // lblMaNV
            // 
            lblMaNV.AutoSize = true;
            lblMaNV.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblMaNV.Location = new Point(21, 61);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(127, 22);
            lblMaNV.TabIndex = 10;
            lblMaNV.Text = "Mã nhân viên: ";
            // 
            // guna2GroupBox2
            // 
            guna2GroupBox2.Controls.Add(dataGridViewChamCong);
            guna2GroupBox2.CustomBorderColor = Color.SteelBlue;
            guna2GroupBox2.CustomizableEdges = customizableEdges3;
            guna2GroupBox2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            guna2GroupBox2.ForeColor = Color.Black;
            guna2GroupBox2.Location = new Point(12, 191);
            guna2GroupBox2.Name = "guna2GroupBox2";
            guna2GroupBox2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2GroupBox2.Size = new Size(781, 387);
            guna2GroupBox2.TabIndex = 11;
            guna2GroupBox2.Text = "DANH SÁCH CHẤM CÔNG";
            // 
            // frmChamCong
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(805, 590);
            Controls.Add(guna2GroupBox2);
            Controls.Add(guna2GroupBox1);
            Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "frmChamCong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormChamCong";
            FormClosing += frmChamCong_FormClosing;
            Load += frmChamCong_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewChamCong).EndInit();
            guna2GroupBox1.ResumeLayout(false);
            guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2GroupBox2.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewChamCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeSo;
        private System.Windows.Forms.FontDialog fontDialog1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Button btnChamCong;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblMaNV;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Label label1;
        private ComboBox cbbLoaiChamCong;
        private PictureBox pictureBox1;
    }
}