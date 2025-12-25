using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Login
{
    public partial class add_updata : Form
    {
        public add_updata()
        {
            InitializeComponent();
        }

        SqlConnection conn = DB_Functions.Connection();
        bool lol=true;
        
        private void Form3_Load(object sender, EventArgs e)
        {
            if(ControlStudent.id != null)
            {
                DataTable data = DB_Functions.Load_data("SELECT[Name],[cardNum],[Note] FROM [students] where id ="+ ControlStudent.id);
                textBox_Name.Text = data.Rows[0][0].ToString();
                textBox_CardNumber.Text = data.Rows[0][1].ToString();
                textBoxNote.Text = data.Rows[0][2].ToString();
            }
        }
        private void OK(object sender, EventArgs e)
        {
            string cardNum = string.IsNullOrWhiteSpace(textBox_CardNumber.Text) ? "NULL" : textBox_CardNumber.Text;
            if (ControlStudent.id == null)
                DB_Functions.Execute("INSERT INTO [dbo].[students]([Name],[Note],[cardNum],[studyInformationID])VALUES('" + textBox_Name.Text + "','" + textBoxNote.Text + "'," + cardNum + "," + ControlStudent.infoID + "); ");
            else
                DB_Functions.Execute("UPDATE [dbo].[students] SET [Name] = '" + textBox_Name.Text + "', [cardNum] = " + cardNum + ",[Note] = '" + textBoxNote.Text + "' WHERE id=" + ControlStudent.id);
            Close();

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


      

      
    }
}
