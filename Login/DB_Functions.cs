using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    static internal class DB_Functions
    {
        static SqliteConnection sqlcon = new SqliteConnection("Data Source=SSA.db");
        static public DataTable loadData(string query)
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

        static public bool checkDate(string query)
        {
            sqlcon.Open();
            SqliteCommand com = sqlcon.CreateCommand();
            com.CommandText = query;
            SqliteDataReader dr = com.ExecuteReader();
            bool check = dr.Read();
            sqlcon.Close();
            return check;
        }


        static public bool Excute(string query)
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
                if (ex.SqliteErrorCode == 19)
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
                string result = dr.GetString(0);
                sqlcon.Close();
                return result;
            }
            catch 
            {
                return string.Empty;
            }
        }
    }
}
