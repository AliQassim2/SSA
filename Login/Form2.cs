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
using AForge.Video;
using AForge.Video.DirectShow;
using DocumentFormat.OpenXml.Drawing.Charts;
using ZXing;
namespace Login
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private readonly SqlConnection conn = Home2.sqlcon;
        FilterInfoCollection filterInfoCollection;
        public static VideoCaptureDevice device;

        private void Form2_Load(object sender, EventArgs e)
        {
            filterInfoCollection=new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in filterInfoCollection)
            {
                cbocamera.Items.Add(item.Name);
            }
            cbocamera.SelectedIndex = 0;
            start();
        }

        private void start()
        {
            device = new VideoCaptureDevice(filterInfoCollection[cbocamera.SelectedIndex].MonikerString);
            device.NewFrame += VideoCaptureDevice_NewFrame;
            device.Start();
        }

        string test;

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bmp);
            if (result != null)
            {
                if (test != result.Text)
                {
                    
                    txtbarcode.Invoke(new MethodInvoker(delegate ()
                    {
                        conn.Open();
                        string query = "SELECT Student.Id,Student.Name FROM Student where Card_number=" + result.Text;
                        SqlCommand cmd = new SqlCommand(query, conn);
                        SqlDataReader rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
 
                            txtbarcode.Text = rd[1].ToString();
                            SqlCommand com = new SqlCommand("UPDATE [dbo].[Student absences] SET [Is_Present] = 'حاضر' from [SSA].[dbo].[Student],[dbo].[Student absences] where [dbo].[Student absences].Name_student = " + rd[0].ToString(), conn);
                            rd.Close();
                            com.ExecuteNonQuery();
                            Console.Beep(500, 750);
                        }
                        else
                        {
                            txtbarcode.Text = "البطاقة غير معرفة";
                            Console.Beep(1000, 1000);
                        }
                        conn.Close();
                        test= result.Text;
                    }));

                }
            }
                pictureBox1.Image = bmp;

            
        }

     

      

        private void cbocamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            start();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (device != null)
                if (device.IsRunning)
                    device.Stop();
        }

        public static implicit operator Form2(page_show v)
        {
            throw new NotImplementedException();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
