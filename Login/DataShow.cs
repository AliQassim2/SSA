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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Login
{
    public partial class DataShow : UserControl
    {
        public DataShow()
        {
            InitializeComponent();
        }

        //Variables
        readonly SqlConnection sqlcon = DB_Functions.Connection();
        //Method
        void Date()
        {
            
        }

        //Event
        

        private void DataShow_Load(object sender, EventArgs e)
        {
            comboBoxDate.Items.Clear();
            DataTable data = DB_Functions.Load_data("SELECT DISTINCT  [Date] from SA where teacherID=" + Form_signup.id);
            foreach (DataRow row in data.Rows)
            {
                comboBoxDate.Items.Add(DateTime.Parse(row[0].ToString()));
            }
            if (comboBoxDate.Items.Count > 0) comboBoxDate.Text = comboBoxDate.Items[comboBoxDate.Items.Count - 1].ToString();
            else comboBoxDate_TextChanged(null, EventArgs.Empty);
        }

        


        private void pictureBoxExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog std = new SaveFileDialog() { Filter = "Excel|*.xlsx" })
            {
                std.FileName = "Stage "+comboBoxStage.Text+" Date is " + comboBoxDate.Text;
                if (std.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wk = new XLWorkbook())
                        {
                            wk.Worksheets.Add((table_show.DataSource as DataTable), "sheet");
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
            (table_show.DataSource as DataTable).DefaultView.RowFilter = string.Format("[name] like '" + textBoxSearch.Text + "%'");
        }

        private void PictureBoxDelete_Click(object sender, EventArgs e)
        {
          
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBoxDate_TextChanged(object sender, EventArgs e)
        {
            Functions.SetComboBox(ref comboBoxStage, DB_Functions.Load_data("SELECT DISTINCT Sta FROM SA where [teacherID] = " + Form_signup.id 
                + " and [Date]='" + comboBoxDate.Text + "' "));

        }
        private void comboBoxStage_TextChanged(object sender, EventArgs e)
        {
            
            Functions.SetComboBox(ref comboBoxType, DB_Functions.Load_data("SELECT DISTINCT [Typ] FROM SA where [teacherID] = " + Form_signup.id + "  and [Date]='" + comboBoxDate.Text + "' and [Sta]= '" + comboBoxStage.Text + "'"));

        }

        private void comboBoxType_TextChanged(object sender, EventArgs e)
        {
            Functions.SetComboBox(ref comboBoxDivision, DB_Functions.Load_data("SELECT DISTINCT [Div] FROM SA where [teacherID] = " + Form_signup.id + "and [Date]='" + comboBoxDate.Text + "'  and [Sta]= '" + comboBoxStage.Text + "' and [Typ]='" + comboBoxType.Text + "'"));

        }

       

        private void comboBoxDivision_TextChanged(object sender, EventArgs e)
        {
            Functions.SetComboBox(ref comboBoxGroup,
                DB_Functions.Load_data("SELECT DISTINCT [gro] FROM SA where [teacherID] = " + Form_signup.id + "and [Date]='" + comboBoxDate.Text + "'  and [Sta]= '" + comboBoxStage.Text + "' and [Typ]='" + comboBoxType.Text + "' and  [Div] = '"+comboBoxDivision.Text+ "'"));

        }

        private void comboBoxGroup_TextChanged(object sender, EventArgs e)
        {
            Functions.SetComboBox(ref comboBoxSubject, DB_Functions.Load_data("SELECT DISTINCT [Les] FROM SA where [teacherID] = " + Form_signup.id + " and [Date]='" + comboBoxDate.Text + "'  and " +
                " [Sta]= '" + comboBoxStage.Text + "' and [Typ]='" + comboBoxType.Text + "' and  [Div] = '" + comboBoxDivision.Text + "' and [Gro] = '" + comboBoxGroup.Text + "'; "));

        }

        private void table_show_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            searchBox.Visible = true;
        }

        private void comboBoxSubject_TextChanged(object sender, EventArgs e)
        {
            table_show.DataSource =
                DB_Functions.Load_data("SELECT [Name],[PA],[notS],[notA] FROM SA  where [teacherID] = " + Form_signup.id + "and [Date]='" + comboBoxDate.Text + "'  " +
                "and [Sta]= '" + comboBoxStage.Text + "' and [Typ]='" + comboBoxType.Text + "' and  [Div] = '" + comboBoxDivision.Text + "' and [Gro] = '" + comboBoxGroup.Text + "' and [Les] = '"+comboBoxSubject.Text+"'; ");
            table_show.Columns[0].HeaderText = "اسم الطالب";
            table_show.Columns[1].HeaderText = "الحضورة";
            table_show.Columns[2].HeaderText = "ملاحظة على الطالب";
            table_show.Columns[3].HeaderText = "ملاحظة على الغياب";
        }
     
    }
}
