using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login
{
    public partial class add_updata : Form
    {
        private string Id=null;
        public add_updata(string id=null)
        {
            InitializeComponent();
            Id = id;
            if(id != null )
            {
                DataTable data = DB_Functions.loadData("select Name,cardNum,Note from students where id ="+id);
                if (data != null )
                {
                    textBox_Name.Text = data.Rows[0][0].ToString();
                    textBox_CardNumber.Text= data.Rows[0][1].ToString();
                    textBoxNote.Text= data.Rows[0][2].ToString();
                }
            }
        }

        
        
        private void OK(object sender, EventArgs e)
        {
            bool check;
            if (string.IsNullOrEmpty(textBox_Name.Text)) 
            {
                MessageBox.Show("يجب ملى حقل الاسم ");
                return;
            }
            if (string.IsNullOrEmpty(textBox_CardNumber.Text))
            {
                MessageBox.Show("يجب ملى حقل رقم البطاقة ");
                return;
            }
            if(Id == null)
                check=DB_Functions.Excute("insert into students (Name,cardNum,Note,Type) values ('"+textBox_Name.Text+"',"+textBox_CardNumber.Text+",'"+textBoxNote.Text+"',"+ ControlStudent.ty + ")");
            else
                check=DB_Functions.Excute("update students set Name = '"+textBox_Name.Text+"' , cardNum = "+ textBox_CardNumber.Text + " , Note='"+textBoxNote.Text+"' where id = "+Id);
            if (check)
            {
                MessageBox.Show("Done");
                this.Close();
            }            
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

    }
}
