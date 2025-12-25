using System;
using System.Management;
using System.Windows.Forms;

namespace Login
{
    public partial class activate : Form
    {
        public activate()
        {
            InitializeComponent();
        }

        private void activate_Load(object sender, EventArgs e)
        {
            // Query to get information about CPUs
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

            // Get the collection of CPUs
            ManagementObjectCollection collection = searcher.Get();

            // Iterate through each CPU
            foreach (ManagementObject obj in collection)
            {
                // Retrieve the serial number of the CPU
                textBox3.Text = obj["ProcessorID"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox4.Text)  ) { MessageBox.Show("يجب ملئ جميع الحقول ");return; }
            DB_Functions.Excute("update activate set userNum='"+ textBox1.Text + "',Name= '"+ textBox2.Text + "',cpuID='"+ textBox3.Text + "',active='"+ textBox4.Text + "'");
            this.Close();
        }
    }
}
