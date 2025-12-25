using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Login
{
    public partial class ControlUser : Form 
    {
        public ControlUser()
        {
            InitializeComponent();
        }

        public static string id = null;
        private SqlConnection conn = Home2.sqlcon;

        private DataTable LoadUserTable(bool TypeStudent=true)
        {
            conn.Open();
            DataTable dataTable = new DataTable();
            string query = comboBoxM_E.Text=="صباحي"?
                "SELECT Student.Id,Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',[Stage].[Groups] as 'الكروب',Student.Card_number as 'رقم بطاقة التعريفية' , [Student].[Note] as ملاحظة FROM Student, Stage where  Stage.Id = Student.Stage_id and Stage.M_E='صباحي' and [Student].[Is_delete]=0 and [Stage].[Groups]='" + comboBoxGroup.Text+"';"
                : "SELECT Student.Id,Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',[Stage].[Groups] as 'الكروب',Student.Card_number as 'رقم بطاقة التعريفية' , [Student].[Note] as ملاحظة FROM Student, Stage where  Stage.Id = Student.Stage_id and Stage.M_E='مسائي' and [Student].[Is_delete]=0 and [Stage].[Groups]='" + comboBoxGroup.Text+"';"
;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

        private void get_info()
        {
            comboBoxGroup.Items.Clear();
            conn.Open();
            string t=null,query = "Select Stage.[Groups] from Stage where Stage.Name='ثالثة' and Stage.M_E='"+comboBoxM_E.Text+"' group by Stage.[Groups]";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBoxGroup.Items.Add(reader.GetString(0));
                t = reader.GetString(0);
            }
            
            reader.Close();
            conn.Close ();
            comboBoxGroup.Text = t;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = LoadUserTable();
            get_info();
            dataGridView1.Columns[0].Visible = false;

            

        }



        private void search(object sender, EventArgs e)
        {
            conn.Open();
            DataTable dataTable = new DataTable();
            string query = comboBoxM_E.Text == "صباحي" ?
                "SELECT Student.Id, Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',[Stage].[Groups] as 'الكروب',Student.Card_number as 'رقم بطاقة التعريفية' , [Student].[Note] as ملاحظة FROM Student,Stage where  Stage.Id = Student.Stage_id and Stage.M_E='صباحي' and [Student].[Is_delete]=0 and [Stage].[Groups]='" + comboBoxGroup.Text+"' and [Student].Name like '%"+textBox_search.Text+"%'; ; "
                : "SELECT Student.Id,Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',[Stage].[Groups] as 'الكروب',Student.Card_number as 'رقم بطاقة التعريفية' , [Student].[Note] as ملاحظة FROM Student, Stage where  Stage.Id = Student.Stage_id and Stage.M_E='مسائي' and [Student].[Is_delete]=0 and [Stage].[Groups]='" + comboBoxGroup.Text + "' and [Student].Name  LIKE '%" + textBox_search.Text + "%';";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }




       

        private void Updata(object sender, EventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            add_updata form3 = new add_updata();
            form3.Text = "Edit";
            //form3.Icon=new Icon("icon/edit-info_9512693.ico");
            DialogResult r= form3.ShowDialog(); 
            if (r == DialogResult.OK)
            {
                dataGridView1.DataSource = LoadUserTable();
            }


        }

        private void Add(object sender, EventArgs e)
        {
            id = null;
            add_updata form3 = new add_updata();
            form3.Text = "Add"; 
            //form3.Icon = new Icon("icon/add-user_9512699.ico");
            DialogResult r = form3.ShowDialog();
            if(r == DialogResult.OK)
            {
                dataGridView1.DataSource = LoadUserTable();
            }

        }

        private void Delete(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("هل انت متاكد من مسح الطالب : "+ dataGridView1.CurrentRow.Cells[1].Value.ToString() + " ؟", "Delete Account" , MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {

                conn.Open();
                string query = "UPDATE [dbo].[Student] SET [Is_delete] = 1 where [Student].Id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                dataGridView1.DataSource = LoadUserTable();
                
            }
        }

        private void click_logout(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Home2 f = new Home2();
            f.Closed += (s, a) => this.Close();
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxM_E_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_info();
            dataGridView1.DataSource= LoadUserTable();
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadUserTable();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home2 f = new Home2();
            f.Closed += (s, a) => this.Close();
            f.Show();
        }

        private void Extie_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            DataTable dataTable = new DataTable();
            string query = comboBoxM_E.Text == "صباحي" ?
                "SELECT Student.Id, Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',[Stage].[Groups] as 'الكروب',Student.Card_number as 'رقم بطاقة التعريفية' , [Student].[Note] as ملاحظة FROM Student,Stage where  Stage.Id = Student.Stage_id and Stage.M_E='صباحي' and [Student].[Is_delete]=0 and [Stage].[Groups]='" + comboBoxGroup.Text + "' and [Student].Name like '%" + textBox_search.Text + "%'; ; "
                : "SELECT Student.Id,Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',[Stage].[Groups] as 'الكروب',Student.Card_number as 'رقم بطاقة التعريفية' , [Student].[Note] as ملاحظة FROM Student, Stage where  Stage.Id = Student.Stage_id and Stage.M_E='مسائي' and [Student].[Is_delete]=0 and [Stage].[Groups]='" + comboBoxGroup.Text + "' and [Student].Name  LIKE '%" + textBox_search.Text + "%';";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
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
    }
}
