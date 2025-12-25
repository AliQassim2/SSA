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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Login
{
    public partial class add_updata : Form
    {
        public add_updata()
        {
            InitializeComponent();
        }

        SqlConnection conn = Home2.sqlcon;
        string MK=null;
        void Groups()
        {
            SqlCommand com = new SqlCommand("select [Groups] from Stage where   Name='ثالثة' and M_E='"+MK+"'", conn);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
                comboBoxGroups.Items.Add(dr.GetString(0));
            dr.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            if (ControlUser.id != null)
            {
                conn.Open();
                SqlCommand com = new SqlCommand("select Student.Name , Student.Card_number,Stage.M_E from Stage, Student   where Student.Stage_id=Stage.Id and Student.Id=" + ControlUser.id, conn);
                SqlDataReader dr= com.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Name.Text = dr.GetValue(0).ToString();
                    textBox_CardNumber.Text = dr.GetValue(1).ToString();
                    MK = dr.GetValue(2).ToString();
                }
                else
                    MessageBox.Show("Error");
                dr.Close();
                Groups();

                
                conn.Close();
            }
        }


        private bool Check_Card()
        {
            string query = ControlUser.id != null 
                ? "SELECT Card_number from Student where Card_number =" + textBox_CardNumber.Text + " and Id !=" + ControlUser.id 
                : "SELECT Card_number from Student where Card_number =" + textBox_CardNumber.Text ;
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            bool exists = dr.Read();
            conn.Close();
            return exists;
        }
        private void OK(object sender, EventArgs e)
        {
      
            if(string.IsNullOrEmpty(textBox_Name.Text))
            {
                MessageBox.Show("! يجب ادخال اسم الطالب","حقل فارغ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(comboBoxME.Text) || string.IsNullOrEmpty(comboBoxGroups.Text))
            {
                MessageBox.Show("! يجب ادخال نوع الدراسة مع الكروب الطالب", "حقل فارغ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(!(string.IsNullOrEmpty(textBox_CardNumber.Text)))
                if (Check_Card())
                {
                    MessageBox.Show("! رقم البطاقة موجود بالفعل", "رقم بطاقة مكرر", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                conn.Open();
            SqlCommand command = new SqlCommand("SELECT Id FROM [SSA].[dbo].[Stage] where Name='ثالثة' and M_E='" + comboBoxME.Text + "' and Groups='" + comboBoxGroups.Text + "' ", conn);
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            if (ControlUser.id != null)
            {
                SqlCommand cmd= new SqlCommand("Update Student set Name='"+ textBox_Name.Text + "',Card_number="+ textBox_CardNumber.Text + ",Stage_id=@stage where Id=@id", conn);
                cmd.Parameters.AddWithValue("@id", ControlUser.id);

                cmd.Parameters.AddWithValue("@stage", dr.GetValue(0).ToString());
                dr.Close();
                cmd.ExecuteNonQuery();           
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Student]([Name],[Stage_id],[Card_number],[Is_delete],[Note])VALUES('"+ textBox_Name.Text + "',@stage,@card,0,'@note')", conn);
                cmd.Parameters.AddWithValue("@stage", dr.GetValue(0).ToString());
                cmd.Parameters.AddWithValue("@card", textBox_CardNumber.Text);
                cmd.Parameters.AddWithValue("@note", textBoxNote.Text);
                dr.Close();
                cmd.ExecuteNonQuery();
            }
            
            conn.Close();
            this.DialogResult= DialogResult.OK;
            this.Close();

        }

        private void TEname(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                OK(sender, e);
                e.IsInputKey = true;
            }
            if (e.KeyData == Keys.Tab)
            {
                textBox_CardNumber.Focus();
                e.IsInputKey = true;
            }
            
        }

        private void TEuser(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                OK(sender, e);
                e.IsInputKey = true;
            }
            if  (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
            }

        }

        private void TEemail(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                OK(sender, e);
                e.IsInputKey = true;
            }
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }

        private void TEpass(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                OK(sender, e);
                e.IsInputKey = true;
            }
            if (e.KeyData == Keys.Tab)
            {
                textBox_Name.Focus();
                e.IsInputKey = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MK = comboBoxME.Text;
            conn.Open();
            comboBoxGroups.Items.Clear();
            Groups();
            conn.Close();
        }
    }
}
