//using Google.Apis.Admin.Directory.directory_v1;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Login
{
    public partial class Form_signup : Form
    {
        public Form_signup()
        {
            InitializeComponent();
        }
        public static int id, role;
        public static string name, image;
        SqlConnection sqlcon = DB_Functions.Connection();
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

        

        private void Password_state(object sender, EventArgs e)
        {
            Password.PasswordChar =  state.CheckState==CheckState.Checked?'\0':'*';
        }

        private void Clogin(object sender, EventArgs e)
        {
            if (!label_worng_user.Visible)
            {
                sqlcon.Open();
                string query = "SELECT [Name],[Image],[id] FROM [teachers] where [Email]=@user and [Password]=@pass";
                SqlCommand sqlCommand = new SqlCommand(query, sqlcon);
                sqlCommand.Parameters.AddWithValue("@user", Username.Text);
                sqlCommand.Parameters.AddWithValue("@pass", Password.Text);
                SqlDataReader Dr = sqlCommand.ExecuteReader();
                
                if (Dr.Read())
                {
                    id = Dr.GetInt32(2);
                    name = Dr.GetValue(0).ToString();
                    image = Dr.GetValue(1).ToString();
                    sqlcon.Close();
                    Hide();
                    Home2 form = new Home2();
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
            string query = "SELECT [Name] FROM [teachers] where [Email]=@user";
            SqlCommand sqlCommand = new SqlCommand(query, sqlcon);
            sqlCommand.Parameters.AddWithValue("@user",Username.Text);
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

       

    }
}
