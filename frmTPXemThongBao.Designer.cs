namespace QuanLyNhanSu_3Tang_ADO
{
    partial class frmTPXemThongBao
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnXemTB = new Button();
            btnLamMoi = new Button();
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            dgvThongBao = new DataGridView();
            guna2Panel1.SuspendLayout();
            guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongBao).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.AliceBlue;
            guna2Panel1.BorderColor = Color.Black;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(btnXemTB);
            guna2Panel1.Controls.Add(btnLamMoi);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Location = new Point(12, 414);
            guna2Panel1.Margin = new Padding(4, 5, 4, 5);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(1001, 57);
            guna2Panel1.TabIndex = 45;
            // 
            // btnXemTB
            // 
            btnXemTB.BackColor = Color.Navy;
            btnXemTB.BackgroundImageLayout = ImageLayout.None;
            btnXemTB.FlatStyle = FlatStyle.Flat;
            btnXemTB.Font = new Font("Cambria", 10.2F, FontStyle.Bold);
            btnXemTB.ForeColor = Color.White;
            btnXemTB.Location = new Point(554, 13);
            btnXemTB.Margin = new Padding(4, 2, 4, 2);
            btnXemTB.Name = "btnXemTB";
            btnXemTB.Size = new Size(296, 30);
            btnXemTB.TabIndex = 8;
            btnXemTB.Text = "Xem";
            btnXemTB.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnXemTB.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Navy;
            btnLamMoi.BackgroundImageLayout = ImageLayout.None;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Cambria", 10.2F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(130, 13);
            btnLamMoi.Margin = new Padding(4, 2, 4, 2);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(296, 30);
            btnLamMoi.TabIndex = 7;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // guna2GroupBox1
            // 
            guna2GroupBox1.Controls.Add(dgvThongBao);
            guna2GroupBox1.CustomBorderColor = Color.GhostWhite;
            guna2GroupBox1.CustomBorderThickness = new Padding(0, 45, 0, 0);
            guna2GroupBox1.CustomizableEdges = customizableEdges3;
            guna2GroupBox1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            guna2GroupBox1.ForeColor = Color.Black;
            guna2GroupBox1.Location = new Point(12, 11);
            guna2GroupBox1.Margin = new Padding(3, 2, 3, 2);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2GroupBox1.Size = new Size(1001, 396);
            guna2GroupBox1.TabIndex = 44;
            guna2GroupBox1.Text = "THÔNG BÁO";
            guna2GroupBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // dgvThongBao
            // 
            dgvThongBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongBao.BackgroundColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvThongBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvThongBao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvThongBao.DefaultCellStyle = dataGridViewCellStyle2;
            dgvThongBao.Location = new Point(3, 49);
            dgvThongBao.Margin = new Padding(3, 4, 3, 4);
            dgvThongBao.Name = "dgvThongBao";
            dgvThongBao.ReadOnly = true;
            dgvThongBao.RowHeadersVisible = false;
            dgvThongBao.RowHeadersWidth = 51;
            dgvThongBao.RowTemplate.Height = 24;
            dgvThongBao.Size = new Size(995, 345);
            dgvThongBao.TabIndex = 10;
            // 
            // frmTPXemThongBao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 482);
            Controls.Add(guna2Panel1);
            Controls.Add(guna2GroupBox1);
            Name = "frmTPXemThongBao";
            Text = "Xem thông báo";
            Load += frmTPXemThongBao_Load;
            guna2Panel1.ResumeLayout(false);
            guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThongBao).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Button btnXemTB;
        private Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private DataGridView dgvThongBao;
    }
}