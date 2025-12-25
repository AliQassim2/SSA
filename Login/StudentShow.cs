using DocumentFormat.OpenXml.Office.Word;
using ExcelDataReader;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Login
{
    public partial class ControlStudent : UserControl
    {
        public ControlStudent()
        {
            InitializeComponent();
            
        }

        private readonly SqlConnection conn = DB_Functions.Connection();
        DataTableCollection tableCollection;


        public static string infoID , id;




        void loadData()
        {
            Table.DataSource = DB_Functions.Load_data("SELECT [id],[Name],[cardNum],[Note] FROM [students] where [isDelete] = 0 and [studyInformationID]=" + infoID);
            Table.Columns[0].Visible = false;
            Table.Columns[1].HeaderText = "اسم الطالب";
            Table.Columns[2].HeaderText = "رقم البطاقة";
            Table.Columns[3].HeaderText = "ملاحظة";

        }
        private void searchBox_Click(object sender, EventArgs e)
        {
                textBoxSearch.Visible = true;
                textBoxSearch.Focus();
            
        }

        private void picture_add_Click(object sender, EventArgs e)
        {
            id = null;
            add_updata form3 = new add_updata();
            form3.Text = "Add";
            DialogResult r = form3.ShowDialog();
            loadData();
        }

        private void picture_edit_Click(object sender, EventArgs e)
        {
            if (Table.Rows.Count>0) 
            {
                    id = Table.CurrentRow.Cells[0].Value.ToString();
                    add_updata form3 = new add_updata();
                    form3.Text = "Edit";
                    //form3.Icon = new Icon("edit-info_9512693.ico");
                    DialogResult r = form3.ShowDialog();
                    loadData();
            }
            else
            {
                MessageBox.Show("لا يوجد بيانات لجل التعديل عليها");
            }
        }

        private void picture_delete_Click(object sender, EventArgs e)
        {
            if (Table.Rows.Count > 0)
            {
                DialogResult r = MessageBox.Show("هل انت متاكد من مسح الطالب : " + Table.CurrentRow.Cells[1].Value.ToString() + " ؟", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                {
                    DB_Functions.Execute("UPDATE [dbo].[students]SET [isDelete] = 1 WHERE id= " + Table.CurrentRow.Cells[0].Value.ToString());
                    loadData();
                }
            }
            else
                MessageBox.Show("لا يوجد بيانات لجل مسح عليها");
         }

        private void PictureBoxImport_Click(object sender, EventArgs e)
        {
            DialogResult mess = MessageBox.Show("هل تريد حذف السجل السابق ؟","حذف سجل سابق",MessageBoxButtons.YesNo,MessageBoxIcon.Question);        
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
                        NoteIndex = dt.Columns.IndexOf("ملاحظة");
                    if (NameIndex == -1) { MessageBox.Show("! حقل اسم الطالب غير موجود يرجى اضافته الى الاكسل", "حقل اسم الطالب غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    if (CardIndex == -1) { MessageBox.Show("! حقل رقم البطاقة غير موجود يرجى اضافته الى الاكسل", "حقل رقم البطاقة غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                   if (NoteIndex == -1) { MessageBox.Show("! حقل ملاحظة غير موجود يرجى اضافته الى الاكسل", "حقل ملاحظة غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    if (mess == DialogResult.Yes)
                    {
                        DB_Functions.Execute("UPDATE [dbo].[students] SET [isDelete] = 1 where [studyInformationID]=" + infoID);
                        
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string cardNum= string.IsNullOrWhiteSpace(dt.Rows[i][CardIndex].ToString())?"NULL": dt.Rows[i][CardIndex].ToString();
                        if (string.IsNullOrEmpty(dt.Rows[i][NameIndex].ToString())) continue;
                        DB_Functions.Execute("INSERT INTO [dbo].[students]([Name],[Note],[cardNum],[studyInformationID])VALUES('" + dt.Rows[i][NameIndex] + "','" + dt.Rows[i][NoteIndex] + "'," + cardNum + "," + infoID + "); ");
                    }
                }
                catch(SqlException ee)
                {
                    MessageBox.Show("يوجد خطا في الملف يرجى التاكد من ان الملف يتبع القواعد الخاصة بادخال بيانات " + ee.Message, "خطا في الملف المدخل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch { MessageBox.Show("يرجى اغلاق الملف الاكسل"); }

            loadData();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            (Table.DataSource as DataTable).DefaultView.RowFilter = string.Format("[اسم الطالب] like '" + textBoxSearch.Text + "%'");

        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == string.Empty)
            { textBoxSearch.Visible = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Functions.SetComboBox(ref comboBoxStage, DB_Functions.Load_data("SELECT distinct [Sta] FROM [info] "));

        }

        private void comboBoxStage_TextChanged(object sender, EventArgs e)
        {
            Functions.SetComboBox(ref comboBoxType, DB_Functions.Load_data("SELECT distinct [Typ] FROM [info] where Sta = '" + comboBoxStage.Text+"' "));
        }

        private void comboBoxType_TextChanged(object sender, EventArgs e)
        {
            Functions.SetComboBox(ref comboBoxDivsion, DB_Functions.Load_data("SELECT distinct [Div] FROM [info] where Sta = '" + comboBoxStage.Text + "' and [Typ]='" + comboBoxType.Text + "' "));

        }

        private void comboBoxDivsion_TextChanged(object sender, EventArgs e)
        {
            Functions.SetComboBox(ref comboBoxGroup, DB_Functions.Load_data("SELECT distinct [Gro] FROM [info] where Sta = '" + comboBoxStage.Text + "' and [Typ]='" + comboBoxType.Text + "' and Div = '"+comboBoxDivsion.Text+"' "));
        }

        private void ControlStudent_Load(object sender, EventArgs e)
        {
            Functions.SetComboBox(ref comboBoxStage, DB_Functions.Load_data("SELECT distinct [Sta] FROM [info] "));
        }

        private void comboBoxGroup_TextChanged(object sender, EventArgs e)
        {
            DataTable data = DB_Functions.Load_data("SELECT id FROM [info] where Sta = '" + comboBoxStage.Text + "' and [Typ]='" + comboBoxType.Text + "' and Div = '"+comboBoxDivsion.Text+"' and [Gro] ='"+comboBoxGroup.Text+"'");
            infoID = data.Rows[0][0].ToString();
            loadData();
        }
    }
}
