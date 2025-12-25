using System;
using System.Windows.Forms;

namespace Login
{
    public partial class teachers : Form
    {
        public teachers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_Functions.Execute("insert into [teachers]([Name],[Email],[Password],[Role],[Image]) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "'," + comboBox1.SelectedIndex.ToString() + ",'a')");
            teachers_Load(null,null);
        }

        private void teachers_Load(object sender, EventArgs e)
        {
            textBox1.Text =textBox2.Text=textBox3.Text=string.Empty;
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource=DB_Functions.Load_data("SELECT [Name],[Email],[Password],[Role],[Image]  FROM [teachers]");
        }
    }
}
