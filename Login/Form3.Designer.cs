namespace Login
{
    partial class add_updata
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
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.Done = new System.Windows.Forms.Button();
            this.label_user = new System.Windows.Forms.Label();
            this.textBox_CardNumber = new System.Windows.Forms.TextBox();
            this.comboBoxME = new System.Windows.Forms.ComboBox();
            this.comboBoxGroups = new System.Windows.Forms.ComboBox();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(48, 31);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(185, 20);
            this.textBox_Name.TabIndex = 0;
            this.textBox_Name.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TEname);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_name.Location = new System.Drawing.Point(164, 6);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(67, 22);
            this.label_name.TabIndex = 7;
            this.label_name.Text = " اسم الطالب";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 9.749999F);
            this.label2.Location = new System.Drawing.Point(188, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = " الكروب";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("Dubai", 9.749999F);
            this.label_email.Location = new System.Drawing.Point(165, 166);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(68, 22);
            this.label_email.TabIndex = 9;
            this.label_email.Text = " نوع الدراسة";
            // 
            // Done
            // 
            this.Done.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.Done.Font = new System.Drawing.Font("Dubai", 9.749999F);
            this.Done.ForeColor = System.Drawing.Color.White;
            this.Done.Location = new System.Drawing.Point(77, 293);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(131, 40);
            this.Done.TabIndex = 10;
            this.Done.Text = "الانتهاء";
            this.Done.UseVisualStyleBackColor = false;
            this.Done.Click += new System.EventHandler(this.OK);
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Font = new System.Drawing.Font("Dubai", 9.749999F);
            this.label_user.Location = new System.Drawing.Point(171, 63);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(59, 22);
            this.label_user.TabIndex = 12;
            this.label_user.Text = "رقم بطاقة ";
            // 
            // textBox_CardNumber
            // 
            this.textBox_CardNumber.Location = new System.Drawing.Point(48, 88);
            this.textBox_CardNumber.Name = "textBox_CardNumber";
            this.textBox_CardNumber.Size = new System.Drawing.Size(185, 20);
            this.textBox_CardNumber.TabIndex = 11;
            this.textBox_CardNumber.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TEuser);
            // 
            // comboBoxME
            // 
            this.comboBoxME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxME.FormattingEnabled = true;
            this.comboBoxME.Items.AddRange(new object[] {
            "صباحي",
            "مسائي"});
            this.comboBoxME.Location = new System.Drawing.Point(48, 191);
            this.comboBoxME.Name = "comboBoxME";
            this.comboBoxME.Size = new System.Drawing.Size(185, 21);
            this.comboBoxME.TabIndex = 13;
            this.comboBoxME.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBoxGroups
            // 
            this.comboBoxGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroups.FormattingEnabled = true;
            this.comboBoxGroups.Location = new System.Drawing.Point(48, 246);
            this.comboBoxGroups.Name = "comboBoxGroups";
            this.comboBoxGroups.Size = new System.Drawing.Size(185, 21);
            this.comboBoxGroups.TabIndex = 14;
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(48, 137);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(185, 20);
            this.textBoxNote.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 9.749999F);
            this.label1.Location = new System.Drawing.Point(184, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = " ملاحظة";
            // 
            // add_updata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 358);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNote);
            this.Controls.Add(this.comboBoxGroups);
            this.Controls.Add(this.comboBoxME);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.textBox_CardNumber);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.textBox_Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "add_updata";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.TextBox textBox_CardNumber;
        private System.Windows.Forms.ComboBox comboBoxME;
        private System.Windows.Forms.ComboBox comboBoxGroups;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label label1;
    }
}