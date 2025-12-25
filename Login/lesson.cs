using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace Login
{
    public partial class lesson : Form
    {

        public lesson()
        {
            InitializeComponent();
        }

        string infoid;
        void Set(bool Stage = false,bool Type = false, bool Division = false, bool Groups = false)
        {
            if (Stage) Functions.SetComboBox(ref comboBoxStage, DB_Functions.Load_data("select distinct [Sta] from [info] ;"));
            if(Type) Functions.SetComboBox(ref comboBoxType, DB_Functions.Load_data("select distinct [Typ] from [info] where [Sta]='" + comboBoxStage.Text + "'"));
            if (Division) Functions.SetComboBox(ref comboBoxDivision, DB_Functions.Load_data("select distinct [Div] from [info] where [Sta]='" + comboBoxStage.Text + "'" + " and [Typ]='" + comboBoxType.Text + "'" ));
            if (Groups) Functions.SetComboBox(ref comboBoxGroups, DB_Functions.Load_data("select distinct [Gro] from [info] where [Sta]='" + comboBoxStage.Text + "'" + " and [Typ]='" + comboBoxType.Text + "'" + " and [Div]='" + comboBoxDivision.Text + "'" ));
        }
        private void lesson_Load(object sender, EventArgs e)
        {
            Functions.SetComboBox(ref comboBox1, DB_Functions.Load_data("SELECT Name from teachers"));
            Set(Stage: true);
            dataGridView1.DataSource = DB_Functions.Load_data("SELECT [Les]as 'اسم المادة'  ,[Tea] as 'التدريسي',[Sta] as 'المرحلة'    ,[Typ]as 'نوع الدراسة'    ,[Div]as 'الشعبة'    ,[Gro]as 'الكروب' FROM [IS]");
        }

        private void comboBoxStage_TextChanged(object sender, EventArgs e)
        {
            Set(Type: true);
        }

        private void comboBoxType_TextChanged(object sender, EventArgs e)
        {
            Set(Division: true);
        }
        private void comboBoxDivision_TextChanged(object sender, EventArgs e)
        {
            Set(Groups: true);
        }

        private void comboBoxGroups_TextChanged(object sender, EventArgs e)
        {
            infoid = DB_Functions.Load_data("select [id] from [info] where [Sta]='" + comboBoxStage.Text + "'" + " and [Typ]='" + comboBoxType.Text + "'" + " and [Div]='" + comboBoxDivision.Text + "' and [Gro]='"+comboBoxGroups.Text+"';").Rows[0][0].ToString();
        }

       
    }
}
