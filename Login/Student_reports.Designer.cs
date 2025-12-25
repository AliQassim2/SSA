namespace Login
{
    partial class Student_reports
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.searchBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.swich2 = new System.Windows.Forms.PictureBox();
            this.labelExcel = new System.Windows.Forms.Label();
            this.swich1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxExport = new System.Windows.Forms.PictureBox();
            this.Table = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.swich2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swich1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonPanel2);
            this.kryptonPanel1.Controls.Add(this.panel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(900, 92);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel1.TabIndex = 21;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.button1);
            this.kryptonPanel2.Controls.Add(this.textBoxSearch);
            this.kryptonPanel2.Controls.Add(this.searchBox);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(499, 86);
            this.kryptonPanel2.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel2.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(380, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 33);
            this.button1.TabIndex = 28;
            this.button1.Text = "التعديل على الانذار";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearch.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(54, 33);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(250, 26);
            this.textBoxSearch.TabIndex = 18;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.Color.Transparent;
            this.searchBox.Image = global::Login.Properties.Resources.textBox_search;
            this.searchBox.Location = new System.Drawing.Point(3, 7);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(347, 74);
            this.searchBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchBox.TabIndex = 17;
            this.searchBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.swich2);
            this.panel1.Controls.Add(this.labelExcel);
            this.panel1.Controls.Add(this.swich1);
            this.panel1.Controls.Add(this.pictureBoxExport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(499, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 92);
            this.panel1.TabIndex = 35;
            // 
            // swich2
            // 
            this.swich2.Image = global::Login.Properties.Resources.مسائي;
            this.swich2.Location = new System.Drawing.Point(83, 7);
            this.swich2.Name = "swich2";
            this.swich2.Size = new System.Drawing.Size(159, 63);
            this.swich2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.swich2.TabIndex = 25;
            this.swich2.TabStop = false;
            this.swich2.Visible = false;
            this.swich2.Click += new System.EventHandler(this.swich2_Click);
            // 
            // labelExcel
            // 
            this.labelExcel.AutoSize = true;
            this.labelExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExcel.Location = new System.Drawing.Point(313, 62);
            this.labelExcel.Name = "labelExcel";
            this.labelExcel.Size = new System.Drawing.Size(77, 17);
            this.labelExcel.TabIndex = 24;
            this.labelExcel.Text = "استخراج-اكسل";
            // 
            // swich1
            // 
            this.swich1.Image = global::Login.Properties.Resources.صباحي;
            this.swich1.Location = new System.Drawing.Point(83, 8);
            this.swich1.Name = "swich1";
            this.swich1.Size = new System.Drawing.Size(159, 63);
            this.swich1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.swich1.TabIndex = 26;
            this.swich1.TabStop = false;
            this.swich1.Click += new System.EventHandler(this.swich1_Click);
            // 
            // pictureBoxExport
            // 
            this.pictureBoxExport.Image = global::Login.Properties.Resources.image_2024_02_11_12_28_061;
            this.pictureBoxExport.Location = new System.Drawing.Point(316, 19);
            this.pictureBoxExport.Name = "pictureBoxExport";
            this.pictureBoxExport.Size = new System.Drawing.Size(62, 40);
            this.pictureBoxExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxExport.TabIndex = 23;
            this.pictureBoxExport.TabStop = false;
            this.pictureBoxExport.Click += new System.EventHandler(this.pictureBoxExport_Click);
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToDeleteRows = false;
            this.Table.AllowUserToResizeColumns = false;
            this.Table.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 15F);
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Table.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Table.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 15F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Table.DefaultCellStyle = dataGridViewCellStyle3;
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.Table.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Table.Location = new System.Drawing.Point(0, 92);
            this.Table.Name = "Table";
            this.Table.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Table.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 15F);
            this.Table.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Table.Size = new System.Drawing.Size(900, 584);
            this.Table.TabIndex = 22;
            // 
            // Student_reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Table);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "Student_reports";
            this.Size = new System.Drawing.Size(900, 676);
            this.Load += new System.EventHandler(this.Student_reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.swich2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swich1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox swich2;
        private System.Windows.Forms.PictureBox swich1;
        private System.Windows.Forms.DataGridView Table;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.PictureBox searchBox;
        private System.Windows.Forms.Label labelExcel;
        private System.Windows.Forms.PictureBox pictureBoxExport;
        private System.Windows.Forms.Button button1;
    }
}
