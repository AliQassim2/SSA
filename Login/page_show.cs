using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.Word;
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
    public partial class page_show : Form
    {
        public page_show()
        {
            InitializeComponent();
            
        }
        private static readonly string str_connection = @"Data Source=DESKTOP-CGFQ02E\SQLEXPRESS;Initial Catalog=SSA;Integrated Security=True";
        public static readonly SqlConnection sqlcon = new SqlConnection(str_connection);


        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Visible= true;
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            textBoxSearch.Visible = true;
            textBoxSearch.Focus();
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "")
            { textBoxSearch.Visible = false; }
        }

        private void swich1_Click(object sender, EventArgs e)
        {
            swich2.Visible = !swich2.Visible;
            swich1.Visible = !swich1.Visible;
            Date(false);
            table_show.DataSource = Load_data_specific(false);
            
        }

        private void swich2_Click(object sender, EventArgs e)
        {
            swich2.Visible = !swich2.Visible;
            swich1.Visible = !swich1.Visible;
            Date(true);
            table_show.DataSource= Load_data_specific(true);
            
        }
        private void Export(object sender, EventArgs e)
        {
            using (SaveFileDialog std = new SaveFileDialog() { Filter = "Excel|*.xlsx" })
            {
                std.FileName = (swich1.Visible ? "Morning " : "Evening ") + comboBoxDate.Text;
                if (std.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wk = new XLWorkbook())
                        {
                            if (swich1.Visible)
                            {
                                wk.Worksheets.Add(Load_data(
               "SELECT Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',Student.Card_number as 'رقم بطاقة التعريفية',[Student absences].[Is_Present] as 'الحضور',[Student absences].[Note] as 'الملاحظة'" +
               "FROM Student, Stage, [Student absences]" +
               "where  Stage.Id = Student.Stage_id and Stage.M_E='صباحي' and [Student absences].Name_student=Student.Id and [Student absences].Date = '" + comboBoxDate.Text + "';"
               ), "الطلاب الصباحي");
                            }
                            else
                            {
                                wk.Worksheets.Add((table_show.DataSource as DataTable), "الطلاب المسائي");
                            }

                            wk.SaveAs(std.FileName);
                        }
                        MessageBox.Show("Done!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void page_show_Load(object sender, EventArgs e)
        {
            Date();
            table_show.DataSource= Load_data_specific();
            table_show.Columns[0].Visible = false;
        }
        DataTable Load_data(string query)
        {
            DataTable dt = new DataTable();
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            sqlcon.Close();
            return dt;
        }

        void Date(bool Type_student = true)
        {
            comboBoxDate.Items.Clear();
            sqlcon.Open();
            string t=null,query = Type_student?
                "SELECT[Date] FROM [SSA].[dbo].[Student absences],[Student],[Stage] where [Student absences].Name_student=Student.Id and Student.Stage_id= Stage.Id and Stage.M_E='صباحي' GROUP BY [Date]"
                : "SELECT[Date] FROM [SSA].[dbo].[Student absences],[Student],[Stage] where [Student absences].Name_student=Student.Id and Student.Stage_id= Stage.Id and Stage.M_E='مسائي' GROUP BY [Date]";
          
              
            SqlCommand cmd = new SqlCommand(query, sqlcon);   
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBoxDate.Items.Add(rd[0]);
                t = rd[0].ToString();
            }
            rd.Close();
            sqlcon.Close();
            comboBoxDate.Text= t;
            
        }
        DataTable Load_data_specific(bool Type_student = true)
        {
            DataTable data;
            if (Type_student)
            {
                data = Load_data(
               "SELECT Student.Id,Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',Student.Card_number as 'رقم بطاقة التعريفية',[Student absences].[Is_Present] as 'الحضور',[Student absences].[Note] as 'الملاحظة'" +
               "FROM Student, Stage, [Student absences]" +
               "where  Stage.Id = Student.Stage_id and Stage.M_E='صباحي' and [Student absences].Name_student=Student.Id and [Student absences].Date = '" + comboBoxDate.Text+"';"
               );
            }
            else
            {
                data = Load_data(
               "SELECT Student.Id,Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',Student.Card_number as 'رقم بطاقة التعريفية',[Student absences].[Is_Present] as 'الحضور',[Student absences].[Note] as 'الملاحظة'" +
               "FROM Student, Stage, [Student absences]" +
               "where Stage.Id = Student.Stage_id and Stage.M_E='مسائي' and [Student absences].Name_student=Student.Id and [Student absences].Date = '" + comboBoxDate.Text+"';"
               );
            }

           
            return data;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            table_show.DataSource=Load_data_specific();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if(swich1.Visible)
            {
                table_show.DataSource = Load_data(
               "SELECT Student.Id,Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',Student.Card_number as 'رقم بطاقة التعريفية',[Student absences].[Is_Present] as 'الحضور',[Student absences].[Note] as 'الملاحظة'" +
               "FROM Student, Stage, [Student absences]" +
               "where  Stage.Id = Student.Stage_id and Stage.M_E='صباحي' and [Student absences].Name_student=Student.Id and [Student absences].Date = '" + comboBoxDate.Text + "' and Student.Name like '"+textBoxSearch.Text+"%';"
               );
            }
            else
            {
                table_show.DataSource = Load_data(
               "SELECT Student.Id,Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',Student.Card_number as 'رقم بطاقة التعريفية',[Student absences].[Is_Present] as 'الحضور',[Student absences].[Note] as 'الملاحظة'" +
               "FROM Student, Stage, [Student absences]" +
               "where  Stage.Id = Student.Stage_id and Stage.M_E='مسائي' and [Student absences].Name_student=Student.Id and [Student absences].Date = '" + comboBoxDate.Text + "' and Student.Name like '" + textBoxSearch.Text + "%';"
               );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Home2 show = new Home2();
            show.Show();
            show.Closed += (o, ee) => this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
            Home2 show = new Home2();
            show.Show();
            show.Closed += (o, ee) => this.Close();
        }

        private void Extie_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
