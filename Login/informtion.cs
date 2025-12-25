using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Login
{
    public partial class informtion : Form
    {
        public informtion()
        {
            InitializeComponent();
        }

        private void lessones_Load(object sender, EventArgs e)
        {
            
            Functions.SetComboBox(ref comboBox1, DB_Functions.Load_data("SELECT[Name] FROM [stage]"));
            Functions.SetComboBox(ref comboBox2, DB_Functions.Load_data("SELECT[Name] FROM [groups]"));
            Functions.SetComboBox(ref comboBox4, DB_Functions.Load_data("SELECT[Name] FROM [division]"));
            comboBox3.SelectedIndex = 0;
            dataGridView1.DataSource = DB_Functions.Load_data("SELECT [Sta],[Typ],[Div],[Gro] FROM [info]");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_Functions.Execute("INSERT INTO [study_information]([Stage],[Type],[Division],[Group])VALUES((select [id] from [stage] where [Name]='"+comboBox1.SelectedItem.ToString()+"'),"+comboBox3.SelectedIndex.ToString()+",(select [id] from [division] where [Name]='" + comboBox4.SelectedItem.ToString() + "'),(select [id] from [groups] where [Name]='" + comboBox2.SelectedItem.ToString() + "'))");
            dataGridView1.DataSource = DB_Functions.Load_data("SELECT [Sta],[Typ],[Div],[Gro] FROM [info]");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB_Functions.Execute("INSERT INTO [stage]([Name]) values ('"+textBox1.Text+"') ;");
            MessageBox.Show("done");
            Functions.SetComboBox(ref comboBox1, DB_Functions.Load_data("SELECT[Name] FROM [stage]"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB_Functions.Execute("INSERT INTO [division]([Name]) values ('" + textBox2.Text + "') ;");
            MessageBox.Show("done");
            Functions.SetComboBox(ref comboBox4, DB_Functions.Load_data("SELECT[Name] FROM [division]"));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DB_Functions.Execute("INSERT INTO [groups]([Name]) values ('" + textBox3.Text + "') ;");
            MessageBox.Show("done");
            Functions.SetComboBox(ref comboBox2, DB_Functions.Load_data("SELECT[Name] FROM [groups]"));

        }
    }
}
