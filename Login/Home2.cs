//using Google.Apis.Admin.Directory.directory_v1;
using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ZXing;

namespace Login
{
    public partial class Home2 : Form
    {
        public Point mouseLocation;
        public Home2()
        {
            InitializeComponent();
        }
        string ahmed = "DESKTOP-CGFQ02E\\SQLEXPRESS";

        Size Wide = new Size(1635, 854);
        Size Slim = new Size(1333, 854);
        private static readonly string str_connection = @"Data Source=DESKTOP-CGFQ02E\SQLEXPRESS;Initial Catalog=SSA;Integrated Security=True";
        public static readonly SqlConnection sqlcon = new SqlConnection(str_connection);
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice device;
        private string test;
        private bool check(bool Type_student = true) 
        {
            bool c=true;
            string query = Type_student ? "SELECT[Date] FROM [SSA].[dbo].[Student absences],[Student],[Stage] where [Student absences].Name_student=Student.Id and Student.Stage_id= Stage.Id and Stage.M_E='صباحي' GROUP BY [Date]"
                : "SELECT[Date] FROM [SSA].[dbo].[Student absences],[Student],[Stage] where [Student absences].Name_student=Student.Id and Student.Stage_id= Stage.Id and Stage.M_E='مسائي' GROUP BY [Date]";
            sqlcon.Open();
            SqlCommand cmd=new SqlCommand(query,sqlcon);            
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                if (reader[0].ToString().Substring(0, 9) == DateTime.Now.ToString("dd-MM-yyyy").ToString().Substring(0, 9))
                {
                    c = false;
                    break;
                }
            sqlcon.Close();
            return c;
        }



        DataTable Load_data(string query)
        {
            DataTable dt = new DataTable();
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            sqlcon.Close();
            return dt;
        }


        DataTable Load_data_specific(bool Type_student = true)
        {
            DataTable data;
            if (Type_student)
            {
                data = Load_data(
               "SELECT Student.Id,Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',Student.Card_number as 'رقم بطاقة التعريفية'" +
               "FROM Student, Stage " +
               "where  Stage.Id = Student.Stage_id and Stage.M_E='صباحي' ;"
               );
            }
            else
            {
                data = Load_data(
               "SELECT Student.Id,Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',Student.Card_number as 'رقم بطاقة التعريفية'" +
               "FROM Student, Stage " +
               "where Stage.Id = Student.Stage_id and Student.[Is_delete]=0 and Stage.M_E='مسائي';"
               );
            }

            for (int i = 1; i < data.Columns.Count; i++)
                data.Columns[i].ReadOnly = true;
            data.Columns.Add("حضور", typeof(bool));
            data.Columns.Add("ملاحظة", typeof(string));
            return data;
        }

        private void Home2_Load(object sender, EventArgs e)
        {
               

            this.Size = Slim;
            if (check()) {
                table_edite.DataSource = Load_data_specific();
                table_edite.Columns[0].Visible = false;
                table_edite.Visible = true;
                label4.Visible = false;
            }
            else
            {
                table_edite.Visible = false;
                label4.Visible = true;
            }
            
            dateTimePicker1.Value = DateTime.Now;

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            Environment.Exit(0);
        }

      

        private void swich1_Click(object sender, EventArgs e)
        {
            swich2.Visible = !swich2.Visible;
            swich1.Visible = !swich1.Visible;
            if (check(false))
            {
                table_edite.DataSource = Load_data_specific(false);
                table_edite.Columns[0].Visible = false;
                table_edite.Visible = true;
                label4.Visible = false;
            }
            else
            {
                table_edite.Visible = false;
                label4.Visible = true;
            }
        }

        private void swich2_Click(object sender, EventArgs e)
        {
            swich2.Visible = !swich2.Visible;
            swich1.Visible = !swich1.Visible;
            table_edite.DataSource = Load_data_specific();
            if (check())
            {
                table_edite.DataSource = Load_data_specific();
                table_edite.Columns[0].Visible = false;
                table_edite.Visible = true;
                label4.Visible = false;
            }
            else
            {
                table_edite.Visible = false;
                label4.Visible = true;
            }
        }

        

        

        /*private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable data = Load_data(
                "SELECT Student.Name as 'اسم الطالب', Stage.Name as 'مرحلة',Stage.M_E as 'نوع الدراسة',Student.Card_number as 'رقم بطاقة التعريفية',[Student absences].Date as 'تاريخ' " +
                "FROM[SSA].[dbo].[Student absences], Student, Stage " +
                "where Student.Id = [Student absences].Name_student and Stage.Id = Student.Stage_id and Student.Name like '"+ textBoxSearch.Text + "%' and Student.[Is_delete]=0;"
                );
            data.Columns.Add("حضور", typeof(bool));
            data.Columns.Add("ملاحظة", typeof(string));
            table_edite.DataSource = data;
        }*/

      
        

        private void panel3_MouseDown_1(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel3_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousepos = System.Windows.Forms.Control.MousePosition;
                mousepos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousepos;
            }
        }



        private void start()
        {
            device = new VideoCaptureDevice(filterInfoCollection[cbocamera.SelectedIndex].MonikerString);
            device.NewFrame += VideoCaptureDevice_NewFrame;
            device.Start();
        }
        private string Check(string card_number)
        {
            for (int i = 0; i < table_edite.Rows.Count; i++)
            {
                if (table_edite.Rows[i].Cells[4].Value.ToString() == card_number)
                {
                    table_edite.Rows[i].Cells[5].Value = CheckState.Checked;
                    Console.Beep(500, 750);
                    return table_edite.Rows[i].Cells[1].Value.ToString();
                }
            }
            Console.Beep(1000, 1000);
            return "البطاقة غير معرفة";
        }
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
                        txtbarcode.Text = Check(result.Text);
                        test = result.Text;

                    }));

                }
            }
            pictureBox_show.Image = bmp;
        }
        private void cameraOn_Click(object sender, EventArgs e)
        {
            this.Size = Slim;
            cameraOff.Visible = !cameraOff.Visible;
            if (device != null)
                if (device.IsRunning)
                    device.Stop();
        }

        private void cameraOff_Click_1(object sender, EventArgs e)
        {
            this.Size = Wide;
            cameraOff.Visible = !cameraOff.Visible;
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cbocamera.Items.Clear();
            foreach (FilterInfo item in filterInfoCollection)
            {
                cbocamera.Items.Add(item.Name);
            }
            cbocamera.SelectedIndex = 0;
            start();
        }

        private void iconSave_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            for (int i = 0; i < table_edite.Rows.Count; i++)
            {
                string state = table_edite.Rows[i].Cells[5].Value.ToString() == "True" ? "حاضر" : "غائب";
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Student absences]([Name_student],[Date],[Note],[Is_Present])VALUES(" + (table_edite.Rows[i].Cells[0].Value).ToString() + ",'" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + table_edite.Rows[i].Cells[6].Value + "'," +
                    "'" + state + "');", sqlcon);
                cmd.ExecuteNonQuery();
            }
            sqlcon.Close();
            MessageBox.Show("Done");
            table_edite.Visible = false;
            label4.Visible = true;


        }

        private void iconDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < table_edite.Rows.Count; i++)
            {
                table_edite.Rows[i].Cells[5].Value = CheckState.Unchecked;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Hide();
            page_show show = new page_show();
            show.Show();
            show.Closed += (o, ee) => this.Close();
        }

        private void acount_Click(object sender, EventArgs e)
        {
            Hide();
            ControlUser user = new ControlUser();
            user.Show();
            user.Closed += (o, ee) => this.Close();
        }

        private void comboBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
