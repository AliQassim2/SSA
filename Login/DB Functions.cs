using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Login
{
    static public class DB_Functions
    {
        static SqliteConnection sqlcon = new SqliteConnection("Data Source=SSA.db");


        static public DataTable Load_data(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                sqlcon.Open();
                SqliteCommand cmd = sqlcon.CreateCommand();
                cmd.CommandText = query;
                SqliteDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                sqlcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
                return null;
            }

        }

        static public bool CheckDate(string Date, string type)
        {
            sqlcon.Open();
            SqliteCommand com = sqlcon.CreateCommand();
            com.CommandText = "select * from absences INNER JOIN students on students.id = absences.stuID  where absences.Date='" + Date + "' and students.[Type]=" + type;
            SqliteDataReader dr = com.ExecuteReader();
            bool check = dr.Read();
            sqlcon.Close();
            return check;
        }


        static public bool excute(string query)
        {
            try
            {
                sqlcon.Open();
                SqliteCommand com = sqlcon.CreateCommand();
                com.CommandText = query;
                com.ExecuteNonQuery();
                sqlcon.Close();
                return true;
            }
            catch (SqliteException ex)
            {
                if(ex.SqliteErrorCode == 19) 
                {
                    MessageBox.Show("الادخال موجود سابقا يرجى تغيره ");
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                return false;
            }
            

        }
        static public string getDate(string query)
        {
            try
            {
                sqlcon.Open();
                SqliteCommand cmd = sqlcon.CreateCommand();
                cmd.CommandText = query;
                SqliteDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string result=dr.GetString(0);
                sqlcon.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
                return null;
            }
        }
    }
}
