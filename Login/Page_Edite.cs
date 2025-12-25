using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Page_Edite : Form
    {
        public Page_Edite()
        {
            InitializeComponent();
        }

        private void Page_Edite_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                table_edite.Rows.Add(i, "احمد", "2354", "2024");
            }
            
        }
        

        private void table1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }
    }
}
