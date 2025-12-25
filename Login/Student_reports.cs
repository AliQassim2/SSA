using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Login
{
    public partial class Student_reports : UserControl
    {
        public Student_reports()
        {
            InitializeComponent();
        }


        string alarms(string cell)
        {
            if(int.TryParse(cell, out _)) 
            { 
            int c1 = int.Parse(cell),
            a0 = int.Parse(DB_Functions.getDate("select a1 from Alarms")),
            a1 = int.Parse(DB_Functions.getDate("select a2 from Alarms")),
            a2 = int.Parse(DB_Functions.getDate("select a3 from Alarms")),
            a3 = int.Parse(DB_Functions.getDate("select a4 from Alarms")),
            a4 = int.Parse(DB_Functions.getDate("select a5 from Alarms"));
            if (c1 >= a4)
                return "فصل";
            else if (c1 >= a3)
                return "انذار نهائي";
            else if (c1 >= a2)
                return "انذار ثاني";
            else if (c1 >= a1)
                return "انذار اول";
            else if (c1 >= a0)
                return "تنبيه";
            }
            return string.Empty;
        }

        private void swich2_Click(object sender, EventArgs e)
        {
            swich1.Visible = !swich1.Visible;
            swich2.Visible = !swich2.Visible;
            Student_reports_Load(null,null);
        }

        private void swich1_Click(object sender, EventArgs e)
        {
            swich1.Visible = !swich1.Visible;
            swich2.Visible = !swich2.Visible;
            Student_reports_Load(null, null);

        }

        private void Student_reports_Load(object sender, EventArgs e)
        {
            Table.Columns.Clear();
            DataTable dt;
            dt = DB_Functions.loadData("select DISTINCT stuID as id,Name from studata where Type =" + (swich1.Visible).ToString());
            dt.Columns.Add("result");
            dt.Columns.Add("state");
            foreach (DataRow dr in DB_Functions.loadData("select DISTINCT Date from studata where Type =" + (swich1.Visible).ToString()).Rows)
            {
                dt.Columns.Add( dr[0].ToString());
            }
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 4; j < dt.Columns.Count; j++)
                    dt.Rows[i][j] = DB_Functions.getDate("select PA from studata where Date = '"+ dt.Columns[j].ColumnName + "' and stuID ="+ dt.Rows[i]["id"]);

                dt.Rows[i]["result"]=DB_Functions.getDate("SELECT count(absences.PA) from absences where  PA = 0 and stuID="+ dt.Rows[i]["id"]);
                dt.Rows[i]["state"] = alarms(dt.Rows[i]["result"].ToString());
            }
            Table.DataSource= dt;
            Table.Columns["id"].Visible = false;
            for (int i = 0;i<Table.ColumnCount;i++)
                Table.Columns[i].ReadOnly = true;
            Table.Columns["Name"].HeaderText="اسم الطالب";
            Table.Columns["result"].HeaderText = "مجموع الغياب";
            Table.Columns["state"].HeaderText = "الحالة";

        }



        

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            (Table.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Name] like '" + textBoxSearch.Text + "%'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alarms form = new alarms();
            form.ShowDialog();
            Student_reports_Load(null, null);
        }

        private void pictureBoxExport_Click(object sender, EventArgs e)
        {
            string m = swich1.Visible ? "صباحي" : "مسائي";
            DataTable dt = (Table.DataSource as DataTable);
            dt.PrimaryKey = null;
            dt.Columns.Remove("id");
            dt.Columns["Name"].ColumnName = "اسم الطالب";
            dt.Columns["result"].ColumnName = "مجموع الغياب";
            dt.Columns["state"].ColumnName = "الحالة";

            using (SaveFileDialog std = new SaveFileDialog() { Filter = "Excel|*.xlsx" })
            {
                std.FileName = "تقرير  "+m;
                if (std.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wk = new XLWorkbook())
                        {
                            wk.Worksheets.Add(dt, "التقرير");
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
    }
}
