using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Login
{
    static internal class DB_Functions
    {
        static SqlConnection sqlcon = Connection();

        static public SqlConnection Connection()
        {
            try
            {
                string[] info_con = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Connection.txt"));
                sqlcon = new SqlConnection(@"Data Source=" + info_con[0] + ";Initial Catalog=" + info_con[1] + ";Integrated Security=True");
                try
                {
                    sqlcon.Open();
                    sqlcon.Close();
                }
                catch
                {
                    MessageBox.Show("يرجى التاكد من اسم السيرفر و قاعدة البيانات", "ملف الاتصال غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("يرجى التاكد من ان ملف الاتصال موجود في مكانه الصحيح", "ملف الاتصال غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return sqlcon;
        }            
        static public DataTable Load_data(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                sqlcon.Close();
                return dt;
            }
            catch(SqlException e)
            {
                MessageBox.Show("يوجد خطا في تحميل بيانات" + e.Message, "فشل في تحميل البيانات",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
                return null;
            }

        }
        static public void Execute(string query)
        {
            try
            {
            sqlcon.Open();
            SqlCommand command = new SqlCommand(query, sqlcon);
            command.ExecuteNonQuery();
            sqlcon.Close();
            } catch(Exception e) {

                MessageBox.Show("يوجد خطا في اضافة على البيانات" + e.Message, "فشل في اضافة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // Application.Exit();
            }
            
        }
        static public bool Check(string query)
        {
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();
                bool c=reader.Read();
                sqlcon.Close();
                return c;
            }
            catch (Exception e)
            {

                MessageBox.Show("يوجد خطا في اضافة على البيانات" + e.Message, "فشل في اضافة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Application.Exit();
                return false;
            }
        }

     
   





    }
}
