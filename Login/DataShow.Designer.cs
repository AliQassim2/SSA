namespace Login
{
    partial class DataShow
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.comboBoxDate = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.searchBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.swich2 = new System.Windows.Forms.PictureBox();
            this.swich1 = new System.Windows.Forms.PictureBox();
            this.PictureBoxDelete = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelExcel = new System.Windows.Forms.Label();
            this.pictureBoxExport = new System.Windows.Forms.PictureBox();
            this.table_show = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.swich2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swich1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_show)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.comboBoxDate);
            this.kryptonPanel1.Controls.Add(this.textBoxSearch);
            this.kryptonPanel1.Controls.Add(this.searchBox);
            this.kryptonPanel1.Controls.Add(this.panel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(900, 86);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel1.TabIndex = 20;
            // 
            // comboBoxDate
            // 
            this.comboBoxDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDate.FormattingEnabled = true;
            this.comboBoxDate.Location = new System.Drawing.Point(353, 7);
            this.comboBoxDate.Name = "comboBoxDate";
            this.comboBoxDate.Size = new System.Drawing.Size(140, 24);
            this.comboBoxDate.TabIndex = 21;
            this.comboBoxDate.Text = "05-02-2024";
            this.comboBoxDate.SelectedIndexChanged += new System.EventHandler(this.comboBoxDate_SelectedIndexChanged);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearch.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(54, 21);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(250, 26);
            this.textBoxSearch.TabIndex = 18;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.Color.Transparent;
            this.searchBox.Image = global::Login.Properties.Resources.textBox_search;
            this.searchBox.Location = new System.Drawing.Point(0, -4);
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
            this.panel1.Controls.Add(this.swich1);
            this.panel1.Controls.Add(this.PictureBoxDelete);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelExcel);
            this.panel1.Controls.Add(this.pictureBoxExport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(499, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 86);
            this.panel1.TabIndex = 35;
            // 
            // swich2
            // 
            this.swich2.Image = global::Login.Properties.Resources.مسائي;
            this.swich2.Location = new System.Drawing.Point(31, 7);
            this.swich2.Name = "swich2";
            this.swich2.Size = new System.Drawing.Size(159, 63);
            this.swich2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.swich2.TabIndex = 25;
            this.swich2.TabStop = false;
            this.swich2.Visible = false;
            this.swich2.Click += new System.EventHandler(this.Swich2_Click);
            // 
            // swich1
            // 
            this.swich1.Image = global::Login.Properties.Resources.صباحي;
            this.swich1.Location = new System.Drawing.Point(31, 8);
            this.swich1.Name = "swich1";
            this.swich1.Size = new System.Drawing.Size(159, 63);
            this.swich1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.swich1.TabIndex = 26;
            this.swich1.TabStop = false;
            this.swich1.Click += new System.EventHandler(this.Swich1_Click);
            // 
            // PictureBoxDelete
            // 
            this.PictureBoxDelete.Image = global::Login.Properties.Resources.image_2024_02_11_12_22_54;
            this.PictureBoxDelete.Location = new System.Drawing.Point(348, 8);
            this.PictureBoxDelete.Name = "PictureBoxDelete";
            this.PictureBoxDelete.Size = new System.Drawing.Size(40, 39);
            this.PictureBoxDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxDelete.TabIndex = 33;
            this.PictureBoxDelete.TabStop = false;
            this.PictureBoxDelete.Click += new System.EventHandler(this.PictureBoxDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(342, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 36);
            this.label2.TabIndex = 34;
            this.label2.Text = "حذف";
            // 
            // labelExcel
            // 
            this.labelExcel.AutoSize = true;
            this.labelExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExcel.Location = new System.Drawing.Point(240, 50);
            this.labelExcel.Name = "labelExcel";
            this.labelExcel.Size = new System.Drawing.Size(77, 17);
            this.labelExcel.TabIndex = 24;
            this.labelExcel.Text = "استخراج-اكسل";
            // 
            // pictureBoxExport
            // 
            this.pictureBoxExport.Image = global::Login.Properties.Resources.image_2024_02_11_12_28_061;
            this.pictureBoxExport.Location = new System.Drawing.Point(243, 7);
            this.pictureBoxExport.Name = "pictureBoxExport";
            this.pictureBoxExport.Size = new System.Drawing.Size(62, 40);
            this.pictureBoxExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxExport.TabIndex = 23;
            this.pictureBoxExport.TabStop = false;
            this.pictureBoxExport.Click += new System.EventHandler(this.pictureBoxExport_Click);
            // 
            // table_show
            // 
            this.table_show.AllowUserToAddRows = false;
            this.table_show.AllowUserToDeleteRows = false;
            this.table_show.AllowUserToResizeColumns = false;
            this.table_show.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.table_show.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.table_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table_show.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.table_show.BackgroundColor = System.Drawing.Color.White;
            this.table_show.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.table_show.CausesValidation = false;
            this.table_show.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 5, 2, 2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table_show.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.table_show.ColumnHeadersHeight = 40;
            this.table_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.table_show.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.table_show.DefaultCellStyle = dataGridViewCellStyle3;
            this.table_show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_show.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.table_show.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.table_show.Location = new System.Drawing.Point(0, 86);
            this.table_show.Name = "table_show";
            this.table_show.ReadOnly = true;
            this.table_show.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.table_show.RowHeadersVisible = false;
            this.table_show.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.table_show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_show.Size = new System.Drawing.Size(900, 590);
            this.table_show.TabIndex = 21;
            // 
            // DataShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table_show);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "DataShow";
            this.Size = new System.Drawing.Size(900, 676);
            this.Load += new System.EventHandler(this.DataShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.swich2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swich1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_show)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.PictureBox swich1;
        private System.Windows.Forms.PictureBox swich2;
        private System.Windows.Forms.Label labelExcel;
        private System.Windows.Forms.ComboBox comboBoxDate;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.PictureBox pictureBoxExport;
        private System.Windows.Forms.PictureBox searchBox;
        private System.Windows.Forms.DataGridView table_show;
        private System.Windows.Forms.PictureBox PictureBoxDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}
