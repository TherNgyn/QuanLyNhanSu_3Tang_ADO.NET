namespace QuanLyNhanSu_3Tang_ADO
{
    partial class frmTrangChu
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
            panel1 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            label3 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pnLoad = new Guna.UI2.WinForms.Guna2Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1232, 80);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift SemiLight SemiConde", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(80, 33);
            label2.Name = "label2";
            label2.Size = new Size(75, 24);
            label2.TabIndex = 2;
            label2.Text = "Nhóm 16";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.management;
            pictureBox1.Location = new Point(30, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox2);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 80);
            panel2.Name = "panel2";
            panel2.Size = new Size(424, 640);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift SemiLight SemiConde", 30F);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(120, 493);
            label3.Name = "label3";
            label3.Size = new Size(168, 60);
            label3.TabIndex = 6;
            label3.Text = "System";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiLight SemiConde", 30F);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(41, 424);
            label1.Name = "label1";
            label1.Size = new Size(356, 60);
            label1.TabIndex = 3;
            label1.Text = "HR Management ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._4332392_18940;
            pictureBox2.Location = new Point(30, 28);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(376, 431);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pnLoad
            // 
            pnLoad.BorderRadius = 20;
            pnLoad.CustomizableEdges = customizableEdges1;
            pnLoad.FillColor = Color.AliceBlue;
            pnLoad.Location = new Point(446, 86);
            pnLoad.Name = "pnLoad";
            pnLoad.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnLoad.Size = new Size(778, 622);
            pnLoad.TabIndex = 3;
            // 
            // frmTrangChu
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(233, 235, 244);
            ClientSize = new Size(1232, 720);
            Controls.Add(pnLoad);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(64, 64, 64);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmTrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += frmTrangChu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton5;
        private Guna.UI2.WinForms.Guna2Panel pnLoad;
        private Label label3;
        private Label label1;
        private PictureBox pictureBox2;
    }
}