namespace QuanLyNhanSu_3Tang_ADO
{
    partial class frmDangNhap
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblUsername = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            btnExit = new Guna.UI2.WinForms.Guna2Button();
            lblMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.ActiveCaptionText;
            lblTitle.Location = new Point(242, 35);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(250, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đăng Nhập";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // lblUsername
            // 
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Location = new Point(71, 149);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(105, 22);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Tên đăng nhập:";
            lblUsername.Click += lblUsername_Click;
            // 
            // lblPassword
            // 
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Location = new Point(71, 238);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(67, 22);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            lblPassword.Click += guna2HtmlLabel2_Click;
            // 
            // txtUsername
            // 
            txtUsername.CustomizableEdges = customizableEdges1;
            txtUsername.DefaultText = "";
            txtUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsername.Location = new Point(225, 138);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtUsername.Size = new Size(286, 33);
            txtUsername.TabIndex = 0;
            txtUsername.TextChanged += guna2TextBox1_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.CustomizableEdges = customizableEdges3;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Location = new Point(225, 227);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPassword.Size = new Size(286, 33);
            txtPassword.TabIndex = 1;
            txtPassword.TextChanged += guna2TextBox2_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.CustomizableEdges = customizableEdges5;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.Font = new Font("Segoe UI", 9F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(193, 336);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogin.Size = new Size(128, 40);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Đăng nhập";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.CustomizableEdges = customizableEdges7;
            btnExit.DisabledState.BorderColor = Color.DarkGray;
            btnExit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExit.Font = new Font("Segoe UI", 9F);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(396, 336);
            btnExit.Name = "btnExit";
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnExit.Size = new Size(128, 40);
            btnExit.TabIndex = 3;
            btnExit.Text = "Thoát";
            btnExit.Click += btnExit_Click;
            // 
            // lblMessage
            // 
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Location = new Point(200, 284);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(3, 2);
            lblMessage.TabIndex = 4;
            lblMessage.Text = null;
            lblMessage.Click += guna2HtmlLabel1_Click;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(684, 450);
            Controls.Add(lblMessage);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDangNhap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUsername;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMessage;
    }
}