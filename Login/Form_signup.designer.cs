namespace Login
{
    partial class Form_signup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_signup));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_worng_user = new System.Windows.Forms.Label();
            this.state = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.linkLabel_forget = new System.Windows.Forms.LinkLabel();
            this.label_forget = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.label_pass = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.label_user = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.icon_exit = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.main_picture = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_exit)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 504);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label_worng_user);
            this.panel3.Controls.Add(this.state);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.Login);
            this.panel3.Controls.Add(this.pictureBox5);
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.Logo);
            this.panel3.Controls.Add(this.Password);
            this.panel3.Controls.Add(this.label_pass);
            this.panel3.Controls.Add(this.Username);
            this.panel3.Controls.Add(this.label_user);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(468, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(503, 504);
            this.panel3.TabIndex = 1;
            // 
            // label_worng_user
            // 
            this.label_worng_user.AutoSize = true;
            this.label_worng_user.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_worng_user.ForeColor = System.Drawing.Color.Red;
            this.label_worng_user.Location = new System.Drawing.Point(39, 288);
            this.label_worng_user.Name = "label_worng_user";
            this.label_worng_user.Size = new System.Drawing.Size(115, 17);
            this.label_worng_user.TabIndex = 12;
            this.label_worng_user.Text = "Not Found user!";
            this.label_worng_user.Visible = false;
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.state.ForeColor = System.Drawing.Color.DimGray;
            this.state.Location = new System.Drawing.Point(39, 386);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(122, 21);
            this.state.TabIndex = 11;
            this.state.Text = "Show Password";
            this.state.UseVisualStyleBackColor = true;
            this.state.CheckStateChanged += new System.EventHandler(this.Password_state);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.linkLabel_forget);
            this.panel5.Controls.Add(this.label_forget);
            this.panel5.Location = new System.Drawing.Point(244, 384);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(235, 26);
            this.panel5.TabIndex = 11;
            // 
            // linkLabel_forget
            // 
            this.linkLabel_forget.ActiveLinkColor = System.Drawing.Color.RosyBrown;
            this.linkLabel_forget.AutoSize = true;
            this.linkLabel_forget.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_forget.ForeColor = System.Drawing.Color.Firebrick;
            this.linkLabel_forget.LinkColor = System.Drawing.Color.Brown;
            this.linkLabel_forget.Location = new System.Drawing.Point(150, 4);
            this.linkLabel_forget.Name = "linkLabel_forget";
            this.linkLabel_forget.Size = new System.Drawing.Size(73, 18);
            this.linkLabel_forget.TabIndex = 10;
            this.linkLabel_forget.TabStop = true;
            this.linkLabel_forget.Text = "Click here";
            this.linkLabel_forget.VisitedLinkColor = System.Drawing.Color.Red;
            this.linkLabel_forget.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Forget_pass);
            // 
            // label_forget
            // 
            this.label_forget.AutoSize = true;
            this.label_forget.BackColor = System.Drawing.Color.White;
            this.label_forget.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_forget.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_forget.Location = new System.Drawing.Point(-3, 3);
            this.label_forget.Name = "label_forget";
            this.label_forget.Size = new System.Drawing.Size(158, 17);
            this.label_forget.TabIndex = 9;
            this.label_forget.Text = "Forgot your password?";
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(123)))), ((int)(((byte)(238)))));
            this.Login.FlatAppearance.BorderSize = 0;
            this.Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Login.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(61)))), ((int)(((byte)(86)))));
            this.Login.Location = new System.Drawing.Point(37, 418);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(428, 48);
            this.Login.TabIndex = 8;
            this.Login.Text = "LOGIN";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Clogin);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Login.Properties.Resources.lock__1_;
            this.pictureBox5.Location = new System.Drawing.Point(421, 338);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(42, 35);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.click_icon_pass);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Login.Properties.Resources.user;
            this.pictureBox4.Location = new System.Drawing.Point(420, 243);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(43, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.click_icon_user);
            // 
            // Logo
            // 
            this.Logo.Image = global::Login.Properties.Resources.SSa;
            this.Logo.Location = new System.Drawing.Point(113, 53);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(275, 164);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 5;
            this.Logo.TabStop = false;
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(61)))), ((int)(((byte)(86)))));
            this.Password.Location = new System.Drawing.Point(38, 334);
            this.Password.MaxLength = 50;
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(427, 44);
            this.Password.TabIndex = 4;
            this.toolTip1.SetToolTip(this.Password, "Enter your password");
            this.Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_password);
            // 
            // label_pass
            // 
            this.label_pass.AutoSize = true;
            this.label_pass.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_pass.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_pass.Location = new System.Drawing.Point(36, 311);
            this.label_pass.Name = "label_pass";
            this.label_pass.Size = new System.Drawing.Size(88, 18);
            this.label_pass.TabIndex = 3;
            this.label_pass.Text = "password";
            // 
            // Username
            // 
            this.Username.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(61)))), ((int)(((byte)(86)))));
            this.Username.Location = new System.Drawing.Point(38, 241);
            this.Username.MaxLength = 50;
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(427, 44);
            this.Username.TabIndex = 2;
            this.toolTip1.SetToolTip(this.Username, "Enter your Username");
            this.Username.TextChanged += new System.EventHandler(this.Username_TextChanged);
            this.Username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_username);
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_user.ForeColor = System.Drawing.Color.Gray;
            this.label_user.Location = new System.Drawing.Point(36, 220);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(88, 18);
            this.label_user.TabIndex = 1;
            this.label_user.Text = "Username";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.icon_exit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(503, 48);
            this.panel4.TabIndex = 0;
            // 
            // icon_exit
            // 
            this.icon_exit.Image = global::Login.Properties.Resources.logout;
            this.icon_exit.Location = new System.Drawing.Point(461, 5);
            this.icon_exit.Name = "icon_exit";
            this.icon_exit.Size = new System.Drawing.Size(37, 42);
            this.icon_exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_exit.TabIndex = 0;
            this.icon_exit.TabStop = false;
            this.toolTip1.SetToolTip(this.icon_exit, "Exit");
            this.icon_exit.Click += new System.EventHandler(this.Exit);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.main_picture);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 504);
            this.panel2.TabIndex = 0;
            // 
            // main_picture
            // 
            this.main_picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_picture.Image = global::Login.Properties.Resources.Business_Plan_amico;
            this.main_picture.Location = new System.Drawing.Point(0, 0);
            this.main_picture.Name = "main_picture";
            this.main_picture.Size = new System.Drawing.Size(468, 504);
            this.main_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.main_picture.TabIndex = 0;
            this.main_picture.TabStop = false;
            // 
            // Form_signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(996, 530);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_signup";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon_exit)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main_picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox main_picture;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label_pass;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.PictureBox icon_exit;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.LinkLabel linkLabel_forget;
        private System.Windows.Forms.Label label_forget;
        private System.Windows.Forms.CheckBox state;
        private System.Windows.Forms.Label label_worng_user;
    }
}