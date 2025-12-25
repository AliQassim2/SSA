using System;
using System.Windows.Forms;

namespace Login
{
    public partial class alarms : Form
    {
        public alarms()
        {
            InitializeComponent();
        }

        private void alarms_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = int.Parse(DB_Functions.getDate("select a1 from Alarms"));
            numericUpDown2.Value = int.Parse(DB_Functions.getDate("select a2 from Alarms "));
            numericUpDown3.Value = int.Parse(DB_Functions.getDate("select a3 from Alarms "));
            numericUpDown4.Value = int.Parse(DB_Functions.getDate("select a4 from Alarms "));
            numericUpDown5.Value = int.Parse(DB_Functions.getDate("select a5 from Alarms "));
        }


        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            numericUpDown2.Minimum = numericUpDown1.Value+1;
        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = numericUpDown2.Value - 1;
            numericUpDown3.Minimum = numericUpDown2.Value+1;
        }

        private void numericUpDown3_ValueChanged_1(object sender, EventArgs e)
        {
            numericUpDown2.Maximum = numericUpDown3.Value - 1;
            numericUpDown4.Minimum = numericUpDown3.Value+1;
        }

        private void numericUpDown4_ValueChanged_1(object sender, EventArgs e)
        {
            numericUpDown3.Maximum = numericUpDown4.Value - 1;
            numericUpDown5.Minimum = numericUpDown4.Value+1;
        }

        private void numericUpDown5_ValueChanged_1(object sender, EventArgs e)
        {
            numericUpDown4.Maximum = numericUpDown5.Value - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_Functions.Excute("update Alarms set a1 ="+numericUpDown1.Value + " , a2 ="+numericUpDown2.Value + ", a3 =" + numericUpDown3.Value + ", a4 =" + numericUpDown4.Value + ", a5 =" + numericUpDown5.Value);
            this.Close();
        }
    }
}
