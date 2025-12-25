using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Home : Form
    {
        
        public Home()
        {
            InitializeComponent();
            
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            panel5.BackColor = Color.White;
            panel4.BackColor = Color.MediumBlue;
            panel6.BackColor = Color.MediumBlue;
            panel7.BackColor = Color.MediumBlue;

            label2.ForeColor = Color.Black;
            label1.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;

            
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            panel5.BackColor = Color.MediumBlue;
            panel4.BackColor = Color.White;
            panel6.BackColor = Color.MediumBlue;
            panel7.BackColor = Color.MediumBlue;
            label2.ForeColor = Color.White;
            label1.ForeColor = Color.Black;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            panel5.BackColor = Color.MediumBlue;
            panel4.BackColor = Color.MediumBlue;
            panel6.BackColor = Color.White;
            panel7.BackColor = Color.MediumBlue;
            label2.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.White;
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            panel5.BackColor = Color.MediumBlue;
            panel4.BackColor = Color.MediumBlue;
            panel6.BackColor = Color.MediumBlue;
            panel7.BackColor = Color.White;
            label2.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.Black;
            
        }


        private void icon_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = !pictureBox3.Visible;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = !pictureBox3.Visible;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
