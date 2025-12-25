using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class DataShow : UserControl
    {
        public DataShow()
        {
            InitializeComponent();
            
        }

        //Variables
        //readonly SqlConnection sqlcon = DB_Functions.Connection();
        //Method
        void LoadData()
        {
            table_show.Columns.Clear();
            DataTable dt = DB_Functions.loadData("select Name , cardNum,snote , PA ,anote  from studata where Date='"+comboBoxDate.Text+"' and Type =" + (swich1.Visible).ToString());
            table_show.DataSource = dt;
            table_show.Columns["Name"].HeaderText = "اسم الطالب";
            table_show.Columns["cardNum"].HeaderText = "رقم البطاقة";
            table_show.Columns["snote"].HeaderText = "ملاحظة على الطالب";
            table_show.Columns["PA"].HeaderText = "الحضور";
            table_show.Columns["anote"].HeaderText = "ملاحظة على الغياب";
        }

        //Event
        private void comboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DataShow_Load(object sender, EventArgs e)
        {
            comboBoxDate.Items.Clear();
            comboBoxDate.Text = string.Empty;
            DataTable dt = DB_Functions.loadData("SELECT distinct Date from studata where Type =" + (swich1.Visible).ToString());
            foreach(DataRow row in dt.Rows)
            {
                comboBoxDate.Items.Add(row[0].ToString());
            }
            if (comboBoxDate.Items.Count > 0)
                comboBoxDate.SelectedIndex = 0;
            else
            {
                LoadData();
                comboBoxDate.Text = "لا توجد بيانات";
            }
        }

        private void Swich1_Click(object sender, EventArgs e)
        {
            swich2.Visible = !swich2.Visible;
            swich1.Visible = !swich1.Visible;
            DataShow_Load(null, null);
        }

        private void Swich2_Click(object sender, EventArgs e)
        {
            Swich1_Click(sender, e);
        }

        private void pictureBoxExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog std = new SaveFileDialog() { Filter = "Excel|*.xlsx" })
            {
                std.FileName = comboBoxDate.Text;
                if (std.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wk = new XLWorkbook())
                        {
                            wk.Worksheets.Add(DB_Functions.loadData("select Name as 'اسم الطالب', cardNum as 'رقم البطاقة',snote as 'ملاحظة على الطالب', PA as 'الحضور',anote as 'ملاحظة على الغياب' from studata where Date='" + comboBoxDate.Text + "' and Type = 1"), "صباحي");
                            wk.Worksheets.Add(DB_Functions.loadData("select Name as 'اسم الطالب', cardNum as 'رقم البطاقة',snote as 'ملاحظة على الطالب', PA as 'الحضور',anote as 'ملاحظة على الغياب' from studata where Date='" + comboBoxDate.Text + "' and Type = 0"), "مسائي");
                            wk.SaveAs(std.FileName);
                        }
                        MessageBox.Show(".تم تحويل البيانات الى ملف اكسل بنجاح");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            (table_show.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Name] like '" + textBoxSearch.Text + "%'");

        }

        private void PictureBoxDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("هل انت متاكد من مسح سجل؟" , "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DB_Functions.Excute("delete from absences where id in (select id from studata where Date='"+comboBoxDate.Text+"' and Type =" + (swich1.Visible).ToString() + ")");
                DataShow_Load(null,null);
                MessageBox.Show("تم حذف سجل بتاريخ " + comboBoxDate.Text, "مسح السجل بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
