using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using ZXing;

namespace Login
{
    public partial class Home2 : Form
    {
        public Home2()
        {
            InitializeComponent();
            panel1.Width = SizeW1;
        }

        //Variables
        int SizeW1 = 166;
        int SizeW2 = 200;
        int SizeW3 = 250;
        int SizeW4 = 300;
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice device;
        public Point mouseLocation;
        private string test = string.Empty;
        private bool isexist = false;
        //Method
        string ComputeSHA256Hash(string input)
        {
            // Convert the input string to a byte array
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Create a SHA256 hash object
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the input bytes
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Convert the hash bytes to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Convert each byte to its hexadecimal representation
                }

                return sb.ToString().Substring(0,20); // Return the hash string
            }
        }
        void active()
        {
            DataTable dt = DB_Functions.loadData("select * from activate");
            if (ComputeSHA256Hash(dt.Rows[0][0].ToString()+ dt.Rows[0][1].ToString() + dt.Rows[0][2].ToString() +"SSA") == dt.Rows[0][3].ToString())
            {
                panelSetting.Visible = true;
                panelShowPage.Visible = true;
                panelControlPage.Visible = true;
                kryptonPanel1.Visible = false;
                nameTecher.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                panelSetting.Visible=false;
                panelShowPage.Visible=false;
                panelControlPage.Visible=false;
                kryptonPanel1.Visible = true;
            }
        }
        void Load_data_specific()
        {
            DataTable data=null;
            table_edite.Columns.Clear();
            if (DB_Functions.checkDate("select * from absences INNER JOIN students on students.id = absences.stuID  where absences.Date='" + dateTimePicker1.Text + "' and students.[Type]=" + ty()))
            {
                isexist = true;

                data = DB_Functions.loadData("select stuID as id,Name,cardNum,anote as Note from studata where Date='" + dateTimePicker1.Text+"' and Type="+ ty());
                data.Columns.Add("PA" ,typeof(bool));
                for(int i = 0; i < data.Rows.Count; i++)
                {
                    data.Rows[i]["PA"] =DB_Functions.loadData("select PA from absences where Date='" + dateTimePicker1.Text+"' and stuID=" + data.Rows[i][0]).Rows[0][0];
                }
                table_edite.DataSource = data;


            }
            else
            {
                isexist = false;
                data = DB_Functions.loadData("select id,[Name],cardNum from students where [Type]=" + ty());
                for (int i = 1; i < data.Columns.Count; i++)
                    data.Columns[i].ReadOnly = true;
                table_edite.DataSource = data;
            }
            //set  columns
            table_edite.Columns[0].Visible = false;
            table_edite.Columns[1].HeaderText = "اسم الطالب";
            table_edite.Columns[2].HeaderText = "رقم البطاقة";
            if (!table_edite.Columns.Contains("PA")) 
            { 

                //set absence
                DataGridViewCheckBoxColumn pa = new DataGridViewCheckBoxColumn
                {
                    Name = "PA",
                    HeaderText = "الحضور",
                    Width = 50,
                    ValueType = typeof(bool)
                };
                table_edite.Columns.Add(pa);
                foreach (DataGridViewRow row in table_edite.Rows)
                    row.Cells["PA"].Value = false;
                //set Note
                DataGridViewTextBoxColumn note = new DataGridViewTextBoxColumn
                {
                    Name = "Note",
                    HeaderText = "ملاحظة",
                    Width = 100
                };
                table_edite.Columns.Add(note);
            }
            else
            {
                table_edite.Columns["PA"].HeaderText = "الحضور";
                table_edite.Columns["PA"].DisplayIndex = 3;
                table_edite.Columns["Note"].HeaderText = "ملاحظة";
                table_edite.Columns["Note"].DisplayIndex = 4;

            }
            table_edite.Columns[0].ReadOnly= table_edite.Columns[1].ReadOnly = table_edite.Columns[2].ReadOnly =  true;
            WindowState = FormWindowState.Maximized;

        }

        void checkout()
        {
            if (che.Text != "0")
            {
                if (MessageBox.Show("هل تريد حفظ السجل ؟", "تنبيه حفظ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    iconSave_Click(null, null);
                }
            }
        }
        private void start()
        {
            device = new VideoCaptureDevice(filterInfoCollection[cbocamera.SelectedIndex].MonikerString);
            device.NewFrame += VideoCaptureDevice_NewFrame;
            device.Start();
        }
        private string Check(string card_number, bool beep = true)
        {
            for (int i = 0; i < table_edite.Rows.Count; i++)
            {
                if (table_edite.Rows[i].Cells["cardNum"].Value.ToString() == card_number)
                {
                    label15.Visible = true;
                    table_edite.Rows[i].Cells["PA"].Value = true;
                    if (beep) Console.Beep(500, 750);
                    return table_edite.Rows[i].Cells["Name"].Value.ToString();
                }
            }
            if (beep) Console.Beep(1000, 1000);
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

                    label15.Invoke(new MethodInvoker(delegate ()
                    {
                        label15.Text = Check(result.Text);
                        test = result.Text;
                        Count();
                    }));

                }
            }
            pictureBox_show.Image = bmp;
        }

        string ty()
        {
            string result = swich1.Visible ? "1" : "0";
            return result;
        }

        void Count()
        {
            if (table_edite.Columns.Contains("PA"))
            {
                int check = 0, uncheck = 0;
                for (int i = 0; i < table_edite.RowCount; i++)
                {
                    if (table_edite.Rows[i].Cells["PA"].Value != null && table_edite.Rows[i].Cells["PA"].Value.ToString() == "True")
                        check++;
                    else
                        uncheck++;
                }
                che.Text = check.ToString();
                unche.Text = uncheck.ToString();
            }
        }
    

        string barcode;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            char c = (char)keyData;

            if (char.IsNumber(c))
            {
                barcode += c;

                if (c == (char)Keys.Return)
                {
                    label15.Text = Check(barcode, false);
                    barcode = "";
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        //Event
        private void Home2_Load(object sender, EventArgs e)
        {
            active();
            label10_Click(null, null);
            dateTimePicker1.Text=DateTime.Now.ToString();
            
        }



        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



        private void swich1_Click(object sender, EventArgs e)
        {
            checkout();
            swich2.Visible = !swich2.Visible;
            swich1.Visible = !swich1.Visible;
            Load_data_specific();
            Count();
        }

        private void swich2_Click(object sender, EventArgs e)
        {
            checkout();
            swich2.Visible = !swich2.Visible;
            swich1.Visible = !swich1.Visible;
            Load_data_specific();
            Count();
        }



        private void panel3_MouseDown_1(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel3_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousepos = MousePosition;
                mousepos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousepos;
            }
        }




        private void cameraOn_Click(object sender, EventArgs e)
        {
            // panel4.Visible = false;
            for (int i = 0; i < 13; i++)
            {

                panel4.Size = new Size(panel4.Width - 16, panel4.Height);
            }

            pictureBox1.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            cbocamera.Visible = false;
            pictureBox_show.Visible = false;
            //label15.Visible = false;
            cameraOff.Visible = true;
            if (device != null)
                if (device.IsRunning)
                    device.Stop();
        }

        private void cameraOff_Click_1(object sender, EventArgs e)
        {
            //panel4.Visible = true;
            for (int i = 0; i < 13; i++)
            {

                panel4.Size = new Size(panel4.Width + 16, panel4.Height);
            }

            pictureBox1.Visible = true;
            label1.Visible = true;
            label3.Visible = true;
            cbocamera.Visible = true;
            pictureBox_show.Visible = true;
            label15.Visible = true;

            cameraOff.Visible = false;
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
            table_edite.CurrentCell = null;
            if (isexist)
                foreach (DataGridViewRow row in table_edite.Rows)
                    DB_Functions.Excute("UPDATE absences SET PA=" + row.Cells["PA"].Value + " , Note='" + row.Cells["Note"].Value +"' WHERE stuID=" + row.Cells["id"].Value + " and Date='"+dateTimePicker1.Text+"'");
            else
                foreach(DataGridViewRow row in table_edite.Rows)
                    DB_Functions.Excute("insert into absences(stuID,PA,Note,Date) values (" + row.Cells["id"].Value + "," + row.Cells["PA"].Value + ",'" + row.Cells["Note"].Value +"','"+dateTimePicker1.Text+"')");
            MessageBox.Show("لقد سجلت حضور الطلاب");
            Load_data_specific();
        }

        private void iconDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < table_edite.Rows.Count; i++)
            {
                table_edite.Rows[i].Cells["PA"].Value = false;
            }
            Count();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panelShowPage.StateCommon.Color1 = Color.FromArgb(66, 73, 118);
            panleHomePage.StateCommon.Color1 = Color.Transparent;
            panelControlPage.StateCommon.Color1 = Color.Transparent;
            panelSetting.StateCommon.Color1 = Color.Transparent;

            panel8.Visible = false;
            panel5.Size = new Size(908, 44);
            dataShow1.BringToFront();
            table_edite.Visible = false;
            panel2.Visible = false;
            controlStudent1.Visible = false;
            dataShow1.Visible = true;
            student_reports1.Visible = false;
        }

        private void acount_Click(object sender, EventArgs e)
        {
            panleHomePage.StateCommon.Color1 = Color.Transparent;
            panelControlPage.StateCommon.Color1 = Color.FromArgb(66, 73, 118);
            panelShowPage.StateCommon.Color1 = Color.Transparent;
            panelSetting.StateCommon.Color1 = Color.Transparent;

            panel8.Visible = false;
            panel5.Size = new Size(908, 44);
            table_edite.Visible = false;
            panel2.Visible = false;
            //controlStudent1 = new ControlStudent();
            controlStudent1.Visible = true;
            dataShow1.Visible = false;
            student_reports1.Visible = false;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            table_edite.CurrentCell = null;
            DataTable dt = (DataTable)table_edite.DataSource;
            dt.DefaultView.RowFilter = string.Format("[Name] like '" + textBoxSearch.Text + "%'");
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            textBoxSearch.Visible = true;
            textBoxSearch.Focus();
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            textBoxSearch.Visible = !string.IsNullOrEmpty(textBoxSearch.Text);

        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Load_data_specific();
        }




       

        private void file_Click(object sender, EventArgs e)
        {
            panleHomePage.StateCommon.Color1 = Color.FromArgb(66, 73, 118);
            panelControlPage.StateCommon.Color1 = Color.Transparent;
            panelShowPage.StateCommon.Color1 = Color.Transparent;
            panelSetting.StateCommon.Color1 = Color.Transparent;

            panel8.Visible = true;
            panel5.Size = new Size(908, 133);
            dataShow1.Visible = false;
            controlStudent1.Visible = false;
            table_edite.Visible = true;
            panel2.Visible = true;
            student_reports1.Visible = false;

        }
        bool menu_E = true;
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (menu_E)
            {
                for (int i = 0; i < 7; i++)
                {
                    panel1.Size = new Size(panel1.Width - 16, panel1.Height);
                    PanelOpenStage.Size = new Size(PanelOpenStage.Width - 16, PanelOpenStage.Height);
                }

                nameTecher.Visible = false;
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    panel1.Size = new Size(panel1.Width + 16, panel1.Height);
                    PanelOpenStage.Size = new Size(PanelOpenStage.Width + 16, PanelOpenStage.Height);
                }

                nameTecher.Visible = true;
            }
            menu_E = !menu_E;
        }

        private void cbocamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            start();
        }
        bool minmize = false;
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            if (!minmize)
            {
                WindowState = FormWindowState.Normal;
                this.Size = new Size(1280, 720);
                minmize = true;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                minmize = false;
            }

        }

      

        private void Home2_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkout();
        }



        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {

        }

      

        private void iconfile_Click(object sender, EventArgs e)
        {
            panleHomePage.StateCommon.Color1 = Color.FromArgb(66, 73, 118);
            panelControlPage.StateCommon.Color1 = Color.Transparent;
            panelShowPage.StateCommon.Color1 = Color.Transparent;
            panelSetting.StateCommon.Color1 = Color.Transparent;

            panel8.Visible = true;
            panel5.Size = new Size(908, 133);
            dataShow1.Visible = false;
            controlStudent1.Visible = false;
            table_edite.Visible = true;
            panel2.Visible = true;
            student_reports1.Visible = false;
        }

 

        private void PanelOpenStage_Click(object sender, EventArgs e)
        {
            if (PanelListSize.Height != 47)
            {
                for (int i = 0; i < 78; i++)
                    PanelListSize.Height = PanelListSize.Height - 2;
            }
            else
            {




                for (int i = 0; i < 78; i++)
                    PanelListSize.Height = PanelListSize.Height + 2;
            }
        }

        private void labelStage_Click(object sender, EventArgs e)
        {
            if (PanelListSize.Height == 200)
            {
                for (int i = 0; i < 156; i++)
                {
                    PanelListSize.Height = PanelListSize.Height - 1;
                }
            }else if(PanelListSize.Height == 240)
            {
                for (int i = 0; i < 187; i++)
                {
                    PanelListSize.Height = PanelListSize.Height - 1;
                }
            }else if(PanelListSize.Height == 280)
            {
                for (int i = 0; i < 215; i++)
                {
                    PanelListSize.Height = PanelListSize.Height - 1;
                }
            }else if(PanelListSize.Height == 44)
            {
                for (int i = 0; i < 156; i++)
                {
                    PanelListSize.Height = PanelListSize.Height + 1;
                }
            }else if(PanelListSize.Height == 53)
            {
                for (int i = 0; i < 187; i++)
                {
                    PanelListSize.Height = PanelListSize.Height + 1;
                }
            }else if(PanelListSize.Height == 65)
            {
                for (int i = 0; i < 215; i++)
                {
                    PanelListSize.Height = PanelListSize.Height + 1;
                }
            }

        }




        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panelShowPage.StateCommon.Color1 = Color.FromArgb(66, 73, 118);
            panleHomePage.StateCommon.Color1 = Color.Transparent;
            panelControlPage.StateCommon.Color1 = Color.Transparent;
            panelSetting.StateCommon.Color1 = Color.Transparent;

            panel8.Visible = false;
            panel5.Size = new Size(908, 44);
            dataShow1.BringToFront();
            table_edite.Visible = false;
            panel2.Visible = false;
            controlStudent1.Visible = false;
            dataShow1.Visible = true;
            student_reports1.Visible = false;
        }

        private void iconAcount_Click(object sender, EventArgs e)
        {
            panleHomePage.StateCommon.Color1 = Color.Transparent;
            panelControlPage.StateCommon.Color1 = Color.FromArgb(66, 73, 118);
            panelShowPage.StateCommon.Color1 = Color.Transparent;
            panelSetting.StateCommon.Color1 = Color.Transparent;

            panel8.Visible = false;
            panel5.Size = new Size(908, 44);
            table_edite.Visible = false;
            panel2.Visible = false;
            //controlStudent1 = new ControlStudent();
            controlStudent1.Visible = true;
            dataShow1.Visible = false;
            student_reports1.Visible = false;
        }




        private void label15_TextChanged_1(object sender, EventArgs e)
        {
            IsDone.Visible = true;
            if (label15.Text == "البطاقة غير معرفة")
            {
                IsDone.BackColor = Color.Red;
                IsDone.Text = "لم يتم التسجيل";
            }
            else
            {
                IsDone.BackColor = Color.Green;
                IsDone.Text = "تم التسجيل بنجاح";
            }
        }

        //تحديد الحجم
        private void control_size(int MpanelW, int panelStage, int pHW, int pHH, dynamic fnt, int p12W, int pSW, int pCPW, int icoM, int image, int imagew,int HomeW,int HomeH)
        {
            panel1.Width = MpanelW;
            flowLayoutPanel1.Width = MpanelW;
            PanelListSize.Width = MpanelW;
            PanelListSize.Height = panelStage;
            PanelOpenStage.Width = MpanelW;


            panleHomePage.Width = pHW;
            panleHomePage.Height = pHH;

            panelControlPage.Width = pHW;
            panelControlPage.Height = pHH;

            panelShowPage.Width = pHW;
            panelShowPage.Height = pHH;

            panelSetting.Width = pHW;
            panelSetting.Height = pHH;

            
            PanelOpenStage.Height = pHH;

            panelSize1.Width = pHW;
            panelSize1.Height = pHH;

            panelSize2.Width = pHW;
            panelSize2.Height = pHH;

            panelSize3.Width = pHW;
            panelSize3.Height = pHH;

            

            file.Font = new Font(file.Font.FontFamily, fnt);
            labelShow.Font = new Font(labelShow.Font.FontFamily, fnt);
            acount.Font = new Font(acount.Font.FontFamily, fnt);
            setting.Font = new Font(setting.Font.FontFamily, fnt);

            panelShowPage.Width = pSW;
            panelControlPage.Width = pCPW;

            iconMainScreen.Height = icoM;
            iconShow.Height = icoM;
            iconAcount.Height = icoM;
            iconSizeScreen.Height = icoM;
            iconSetting.Height = icoM;

            imageAccount.Height = image;
            imageAccount.Width = imagew;
            nameTecher.Font = new Font(nameTecher.Font.FontFamily, fnt);

            Size1.Font = new Font(Size1.Font.FontFamily, fnt);
            Size2.Font = new Font(Size2.Font.FontFamily, fnt);
            Size3.Font = new Font(Size3.Font.FontFamily, fnt);
            labelStage.Font = new Font(labelStage.Font.FontFamily, fnt);

            this.Width = HomeW;
            this.Height =HomeH;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            control_size(SizeW1, 200, 153, 44, 12.75F, 115, 153, 153, 36, 72, 163,1280,720);
        }

        private void label11_Click(object sender, EventArgs e)
        {


            control_size(SizeW2, 240, 180, 53, 15.75F, 140, 185, 185, 44, 80, 200,1320,800);
        }

        private void label12_Click(object sender, EventArgs e)
        {


            control_size(SizeW3, 280, 230, 65, 18.75F, 150, 230, 230, 50, 90, 250,1400,850);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            

        }

        private void setting_Click(object sender, EventArgs e)
        {
            panleHomePage.StateCommon.Color1 = Color.Transparent;
            panelControlPage.StateCommon.Color1 = Color.Transparent;
            panelShowPage.StateCommon.Color1 = Color.Transparent;
            panelSetting.StateCommon.Color1 = Color.FromArgb(66, 73, 118);

            panel8.Visible = false;
            dataShow1.Visible = false;
            controlStudent1.Visible = false;
            table_edite.Visible = false;
            panel2.Visible = false;
            panel5.Size = new Size(908, 44);

            student_reports1.BringToFront();
            student_reports1.Visible = true;

        }

        private void table_edite_KeyUp(object sender, KeyEventArgs e)
        {
            Count();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState= FormWindowState.Minimized;
        }

        private void table_edite_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (table_edite.Columns.Contains("PA"))
            {
                for (int i =0; i < table_edite.RowCount; i++) 
                {
                    if (table_edite.Rows[i].Cells["PA"].Value == null )
                        {
                            table_edite.Rows[e.RowIndex].Cells["PA"].Value = false;
                        }
                }
                
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            activate form = new activate();
            form.ShowDialog();
            active();
        }


        private void table_edite_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            Count();
        }

        private void dateTimePicker1_Enter_1(object sender, EventArgs e)
        {
            checkout();
        }

        private void student_reports1_Load(object sender, EventArgs e)
        {

        }

        private void iconSetting_Click(object sender, EventArgs e)
        {
            panleHomePage.StateCommon.Color1 = Color.Transparent;
            panelControlPage.StateCommon.Color1 = Color.Transparent;
            panelShowPage.StateCommon.Color1 = Color.Transparent;
            panelSetting.StateCommon.Color1 = Color.FromArgb(66, 73, 118);

            panel8.Visible = false;
            dataShow1.Visible = false;
            controlStudent1.Visible = false;
            table_edite.Visible = false;
            panel2.Visible = false;
            panel5.Size = new Size(908, 44);

            student_reports1.BringToFront();
            student_reports1.Visible = true;
        }
    }
}
