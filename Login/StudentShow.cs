using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Login
{
    public partial class ControlStudent : UserControl
    {
        public ControlStudent()
        {
            InitializeComponent();
         
        }
        static public string ty=null;
       
        public void LoadData()
        {
            dataGridView1.DataSource = DB_Functions.loadData("select id,Name,cardNum,Note from students where Type="+ (swich1.Visible).ToString());
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText="اسم الطالب";
            dataGridView1.Columns["cardNum"].HeaderText = "رقم البطاقة";
            dataGridView1.Columns["Note"].HeaderText = "الملاحظة";
        }
        private void searchBox_Click(object sender, EventArgs e)
        {
                textBoxSearch.Visible = true;
                textBoxSearch.Focus();
        }

        private void picture_add_Click(object sender, EventArgs e)
        {
            ty = (swich1.Visible).ToString();
            add_updata form3 = new add_updata {Text = "Add" , Icon = new Icon("photo/add-user_9512699.ico") };
            form3.ShowDialog();
            LoadData();
        }

        private void picture_edit_Click(object sender, EventArgs e)
        {
            ty = (swich1.Visible).ToString();
            if (dataGridView1.CurrentRow != null)
            {
                add_updata form3 = new add_updata(dataGridView1.CurrentRow.Cells["id"].Value.ToString()) { Text = "Edit", Icon = new Icon("photo/edit-info_9512693.ico") };
                form3.ShowDialog();
                LoadData();
            }
            else
                MessageBox.Show("لا توجد بيانات");
        }

        private void picture_delete_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("هل انت متاكد من مسح الطالب : " + dataGridView1.CurrentRow.Cells["Name"].Value.ToString() + " ؟", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {
                DB_Functions.Excute("delete from students where id = "+ dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            }
            LoadData();
        }

        private void PictureBoxImport_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("هل تريد حذف السجل السابق ؟","مسح السجل السابق",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign );
            
            if (re != DialogResult.Cancel )
            {
                DataTable dt = new DataTable();
                try
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                            {
                                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                                {
                                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                    {
                                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                        {
                                            UseHeaderRow = true
                                        }
                                    });
                                    dt = result.Tables[0];
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("error in import data from excel !");
                            return;
                        }
                    }
                    try
                    {
                        int NameIndex = dt.Columns.IndexOf("اسم الطالب"),
                            CardIndex = dt.Columns.IndexOf("رقم البطاقة"),
                            Note = dt.Columns.IndexOf("الملاحظة");
                        if (NameIndex == -1) { MessageBox.Show("! حقل اسم الطالب غير موجود يرجى اضافته الى الاكسل", "حقل اسم الطالب غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                        if (CardIndex == -1) { MessageBox.Show("! حقل رقم البطاقة غير موجود يرجى اضافته الى الاكسل", "حقل رقم البطاقة غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                        if (Note == -1) { MessageBox.Show("! حقل الملاحظة غير موجود يرجى اضافته الى الاكسل", "حقل الملاحظة غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                        if (re == DialogResult.Yes)
                            DB_Functions.Excute("delete from students where Type =" + (swich1.Visible).ToString());
                        foreach (DataRow row in dt.Rows)
                        {
                            if (string.IsNullOrWhiteSpace(row[NameIndex].ToString())) continue;
                            if (string.IsNullOrWhiteSpace(row[CardIndex].ToString())) continue;
                            DB_Functions.Excute("insert into students (Name,cardNum,Note,Type) values ('" + row[NameIndex].ToString() + "'," + row[CardIndex].ToString() + ",'" + row[Note].ToString() + "'," + (swich1.Visible).ToString() + ") ");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("يوجد خطا في الملف يرجى التاكد من ان الملف يتبع القواعد الخاصة بادخال بيانات ", "خطا في الملف المدخل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch { MessageBox.Show("يرجى اغلاق الملف الاكسل"); }

                LoadData();
            }
        }

       

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name like '" + textBoxSearch.Text + "%'");

        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == string.Empty)
                { textBoxSearch.Visible = false; }
        }

        private void ControlStudent_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void swich1_Click(object sender, EventArgs e)
        {
            swich1.Visible=!swich1.Visible;
            swich2.Visible=!swich2.Visible;
            LoadData();
        }

        private void swich2_Click(object sender, EventArgs e)
        {
            swich1.Visible = !swich1.Visible;
            swich2.Visible = !swich2.Visible;
            LoadData();
        }
    }
}
