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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dataGridViewChamCong = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            Thang = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            HeSo = new DataGridViewTextBoxColumn();
            fontDialog1 = new FontDialog();
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            btnChamCong = new Button();
            txtMaNV = new TextBox();
            lblMaNV = new Label();
            guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChamCong).BeginInit();
            guna2GroupBox1.SuspendLayout();
            guna2GroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewChamCong
            // 
            dataGridViewChamCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewChamCong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewChamCong.Columns.AddRange(new DataGridViewColumn[] { Column2, Thang, Column3, HeSo });
            dataGridViewChamCong.Location = new Point(6, 43);
            dataGridViewChamCong.Name = "dataGridViewChamCong";
            dataGridViewChamCong.ReadOnly = true;
            dataGridViewChamCong.RowHeadersVisible = false;
            dataGridViewChamCong.RowHeadersWidth = 51;
            dataGridViewChamCong.RowTemplate.Height = 24;
            dataGridViewChamCong.Size = new Size(868, 451);
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
            guna2GroupBox1.Controls.Add(btnChamCong);
            guna2GroupBox1.Controls.Add(txtMaNV);
            guna2GroupBox1.Controls.Add(lblMaNV);
            guna2GroupBox1.CustomBorderColor = Color.SteelBlue;
            guna2GroupBox1.CustomizableEdges = customizableEdges5;
            guna2GroupBox1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            guna2GroupBox1.ForeColor = Color.Black;
            guna2GroupBox1.Location = new Point(25, 22);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2GroupBox1.Size = new Size(877, 243);
            guna2GroupBox1.TabIndex = 10;
            guna2GroupBox1.Text = "THÔNG TIN CHẤM CÔNG";
            // 
            // btnChamCong
            // 
            btnChamCong.BackColor = Color.Navy;
            btnChamCong.FlatStyle = FlatStyle.Flat;
            btnChamCong.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnChamCong.ForeColor = Color.White;
            btnChamCong.Location = new Point(320, 173);
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
            txtMaNV.Location = new Point(281, 95);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(310, 30);
            txtMaNV.TabIndex = 12;
            // 
            // lblMaNV
            // 
            lblMaNV.AutoSize = true;
            lblMaNV.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblMaNV.Location = new Point(148, 99);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(127, 22);
            lblMaNV.TabIndex = 10;
            lblMaNV.Text = "Mã nhân viên: ";
            // 
            // guna2GroupBox2
            // 
            guna2GroupBox2.Controls.Add(dataGridViewChamCong);
            guna2GroupBox2.CustomBorderColor = Color.SteelBlue;
            guna2GroupBox2.CustomizableEdges = customizableEdges7;
            guna2GroupBox2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            guna2GroupBox2.ForeColor = Color.Black;
            guna2GroupBox2.Location = new Point(25, 296);
            guna2GroupBox2.Name = "guna2GroupBox2";
            guna2GroupBox2.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2GroupBox2.Size = new Size(877, 497);
            guna2GroupBox2.TabIndex = 11;
            guna2GroupBox2.Text = "DANH SÁCH CHẤM CÔNG";
            // 
            // frmChamCong
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(929, 805);
            Controls.Add(guna2GroupBox2);
            Controls.Add(guna2GroupBox1);
            Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "frmChamCong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormChamCong";
            Load += frmChamCong_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewChamCong).EndInit();
            guna2GroupBox1.ResumeLayout(false);
            guna2GroupBox1.PerformLayout();
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
    }
}