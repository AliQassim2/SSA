namespace Login
{
    partial class Page_Edite
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.table_edite = new System.Windows.Forms.DataGridView();
            this.labelSave = new System.Windows.Forms.Label();
            this.labelExcel = new System.Windows.Forms.Label();
            this.labelDlete = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.iconSearch = new System.Windows.Forms.PictureBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chick = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.table_edite)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // table_edite
            // 
            this.table_edite.AllowUserToAddRows = false;
            this.table_edite.AllowUserToDeleteRows = false;
            this.table_edite.AllowUserToResizeColumns = false;
            this.table_edite.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.table_edite.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.table_edite.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table_edite.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.table_edite.BackgroundColor = System.Drawing.Color.White;
            this.table_edite.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.table_edite.CausesValidation = false;
            this.table_edite.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.table_edite.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.table_edite.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 5, 2, 2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table_edite.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.table_edite.ColumnHeadersHeight = 40;
            this.table_edite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.table_edite.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.name,
            this.id,
            this.date,
            this.chick});
            this.table_edite.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.table_edite.DefaultCellStyle = dataGridViewCellStyle4;
            this.table_edite.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.table_edite.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.table_edite.Location = new System.Drawing.Point(0, 84);
            this.table_edite.Name = "table_edite";
            this.table_edite.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.table_edite.RowHeadersVisible = false;
            this.table_edite.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.table_edite.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_edite.Size = new System.Drawing.Size(1206, 553);
            this.table_edite.TabIndex = 0;
            this.table_edite.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // labelSave
            // 
            this.labelSave.AutoSize = true;
            this.labelSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSave.Location = new System.Drawing.Point(1152, 60);
            this.labelSave.Name = "labelSave";
            this.labelSave.Size = new System.Drawing.Size(28, 17);
            this.labelSave.TabIndex = 3;
            this.labelSave.Text = "حفظ";
            // 
            // labelExcel
            // 
            this.labelExcel.AutoSize = true;
            this.labelExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExcel.Location = new System.Drawing.Point(920, 59);
            this.labelExcel.Name = "labelExcel";
            this.labelExcel.Size = new System.Drawing.Size(77, 17);
            this.labelExcel.TabIndex = 4;
            this.labelExcel.Text = "استخراج-اكسل";
            // 
            // labelDlete
            // 
            this.labelDlete.AutoSize = true;
            this.labelDlete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDlete.Location = new System.Drawing.Point(1022, 60);
            this.labelDlete.Name = "labelDlete";
            this.labelDlete.Size = new System.Drawing.Size(93, 17);
            this.labelDlete.TabIndex = 6;
            this.labelDlete.Text = "حذف كل التعديلات";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.LightBlue;
            this.panelTop.Controls.Add(this.iconSearch);
            this.panelTop.Controls.Add(this.labelSearch);
            this.panelTop.Controls.Add(this.searchBox);
            this.panelTop.Controls.Add(this.labelDlete);
            this.panelTop.Controls.Add(this.pictureBox3);
            this.panelTop.Controls.Add(this.labelExcel);
            this.panelTop.Controls.Add(this.labelSave);
            this.panelTop.Controls.Add(this.pictureBox2);
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1206, 86);
            this.panelTop.TabIndex = 7;
            // 
            // iconSearch
            // 
            this.iconSearch.BackColor = System.Drawing.SystemColors.Control;
            this.iconSearch.Image = global::Login.Properties.Resources.search_icon_2_614x460__1_;
            this.iconSearch.Location = new System.Drawing.Point(219, 21);
            this.iconSearch.Name = "iconSearch";
            this.iconSearch.Size = new System.Drawing.Size(49, 33);
            this.iconSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconSearch.TabIndex = 9;
            this.iconSearch.TabStop = false;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(274, 23);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(161, 25);
            this.labelSearch.TabIndex = 8;
            this.labelSearch.Text = "البحث من خلال الاسم";
            // 
            // searchBox
            // 
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(12, 21);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(256, 33);
            this.searchBox.TabIndex = 7;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Login.Properties.Resources.delete_589;
            this.pictureBox3.Location = new System.Drawing.Point(1039, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(62, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Login.Properties.Resources.excel1;
            this.pictureBox2.Location = new System.Drawing.Point(925, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(62, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Login.Properties.Resources._4856668;
            this.pictureBox1.Location = new System.Drawing.Point(1145, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // number
            // 
            this.number.HeaderText = "التسلسل";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "الاسم";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // id
            // 
            this.id.HeaderText = "رقم الهوية";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "التاريخ";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // chick
            // 
            this.chick.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.NullValue = false;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chick.DefaultCellStyle = dataGridViewCellStyle3;
            this.chick.HeaderText = "الحظور";
            this.chick.Name = "chick";
            // 
            // Page_Edite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 637);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.table_edite);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Page_Edite";
            this.Text = "Page_Edite";
            this.Load += new System.EventHandler(this.Page_Edite_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table_edite)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView table_edite;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelSave;
        private System.Windows.Forms.Label labelExcel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label labelDlete;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.PictureBox iconSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chick;
    }
}