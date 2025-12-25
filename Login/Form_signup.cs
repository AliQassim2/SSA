//using Google.Apis.Admin.Directory.directory_v1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Login
{
    public partial class Form_signup : Form
    {
        public Form_signup()
        {
            InitializeComponent();
        }

        private static readonly string[] info_con = File.ReadAllLines("Connection.txt");
        public static string str_connection = @"Data Source=" + info_con[0] + ";Initial Catalog=" + info_con[1] + ";Integrated Security=True";
        public static readonly SqlConnection sqlcon = new SqlConnection(str_connection);
        public static string table_name = info_con[2];
        public static  int access = 1;

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void click_icon_user(object sender, EventArgs e)
        {
            Username.Focus();
        }

        private void click_icon_pass(object sender, EventArgs e)
        {
            Password.Focus();
            
        }

        private void Forget_pass(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Form1 form= new Form1();
            //form.ShowDialog();

        }

        private void Password_state(object sender, EventArgs e)
        {
            Password.PasswordChar =  state.CheckState==CheckState.Checked?'\0':'*';
        }

        private void Clogin(object sender, EventArgs e)
        {
            if (!label_worng_user.Visible)
            {
                sqlcon.Open();
                string query = "select access_level from "+ table_name +" where username='" + Username.Text + "' and password='" + Password.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlcon);
                SqlDataReader Dr = sqlCommand.ExecuteReader();
                if (Dr.Read())
                {
                    access = (int)Dr.GetValue(0);
                    sqlcon.Close();
                    Hide();
                    ControlUser form = new ControlUser();
                    form.Closed += (s, args) => this.Close();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Password is incorrect!");
                }
                sqlcon.Close();
            }
            else
                MessageBox.Show("Username is incorrect!");

        }



        private void Enter_username(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                Clogin(sender, e);
            }
        }

        private void Enter_password(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                Clogin(sender, e);

            }
            

        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            
            
            sqlcon.Open();
            string query = "select access_level from "+ table_name +" where username='" + Username.Text+"'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlcon);
            SqlDataReader Dr = sqlCommand.ExecuteReader();
            int c = 0;
            while (Dr.Read())
                c++;

            if (c == 1)
            {
                Password.Focus();
                label_worng_user.Visible = false;
            }
            else if (c == 0)
            {
                label_worng_user.Visible = true;
                label_worng_user.Text = "Not Found user!";
            }

            else
            {
                label_worng_user.Visible = true;
                label_worng_user.Text = "The account has a problem!";
            }
            sqlcon.Close();
        }

        //private void Hide_pass(object sender, KeyEventArgs e)
        //{
        //    if (state.CheckState == CheckState.Unchecked)
        //    {
        //        if (e.KeyValue >= 65 && e.KeyValue <= 90)
        //        {
        //            show_password += Password.Text[Password.Text.Count() - 1].ToString();
        //            string emoji = "";
        //            for (int i = 0; i <= show_password.Length; i++)
        //            {
        //                emoji += "🤔";
        //            }
        //            Password.Text = emoji;
        //        }
        //    }
        //}

    }
}
