using AForge.Video;
using AForge.Video.DirectShow;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.ExtendedProperties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ZXing;

namespace Login
{
    public partial class Home2 : Form
    {
        public Home2()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        //Variables
        Size Slim = new Size(1074, 720);
        static public SqlConnection sqlcon =DB_Functions.Connection();
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice device;
        public Point mouseLocation;
        string  test, infoid;
        bool isedit;

        //Method
        void Load_data_specific()
        {
            
            DataTable data;
            data = DB_Functions.Load_data("SELECT [studentID] ,[Name],[cardNum],[notS],[PA],[notA] FROM SA  where [teacherID] = " + Form_signup.id 
                + "and [Date]='" + dateTimePicker1.Value + "'  " +"and infID = "+infoid);
            if (data.Rows.Count > 0)
            {
                isedit = true;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    data.Rows[i]["PA"] = data.Rows[i][4].ToString() == "حاضر";
                    data.Rows[i]["notA"] = data.Rows[i][5];
                }
            }
            else
            {
                isedit=false;
                data = DB_Functions.Load_data("select [id]  as studentID,[Name],[cardNum],[Note] as 'notS' from [students] where  [studyInformationID] = " + infoid);
                if (data != null)
                {
                    for (int i = 1; i < data.Columns.Count; i++)
                        data.Columns[i].ReadOnly = true;
                    data.Columns.Add("PA", typeof(bool));
                    data.Columns.Add("notA", typeof(string));
                }
            }
            table_edite.DataSource= data;
            table_edite.Columns["studentID"].Visible = false;
            table_edite.Columns["Name"].Width = 400;
            table_edite.Columns["Name"].HeaderText = "اسم الطالب";
            table_edite.Columns["cardNum"].HeaderText = "رقم البطاقة";
            table_edite.Columns["notS"].HeaderText = "الملومات الاضافية";
            if (table_edite.Columns.Contains("PA") == true)
            { 
                table_edite.Columns["PA"].HeaderText = "الغياب";
                table_edite.Columns["notA"].HeaderText = "ملاحظة";
            }
            for (int i = 2; i < table_edite.ColumnCount - 1; i++)
            {
                table_edite.Columns[i].Width = 200;
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
                if (table_edite.Rows[i].Cells[2].Value.ToString() == card_number)
                {
                    table_edite.Rows[i].Cells[4].Value = CheckState.Checked;
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
                        Count();
                    }));

                }
            }
            pictureBox_show.Image = bmp;
        }

      

        void Count()
        {
            int check = 0, uncheck = 0;
            for (int i = 0; i < table_edite.RowCount; i++)
            {
                if (table_edite.Rows[i].Cells[4].Value.ToString() == "True")
                    check++;
                else
                    uncheck++;
            }
            che.Text = check.ToString();
            unche.Text = uncheck.ToString();
        }
        bool CheckLeave()
        {
            if (che.Text != "0") 
            { 
                DialogResult dr=MessageBox.Show("هل تريد حفظ سجل الغياب الذي سجلته للتو","حفظ سجل الغياب",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    iconSave_Click(null,EventArgs.Empty); 
                    return true;
                }
                else if(dr == DialogResult.No)
                {
                    return true;
                }
                return false;
            }
            return true;
        }


       

        void set(bool Stage = false, bool Type = false, bool Division = false, bool Groups = false, bool Subjects = false)
        {
            if (Stage) Functions.SetComboBox(ref comboBoxStage, DB_Functions.Load_data("select [Sta] from [IS] where [teacherID]=" + Form_signup.id + " group by [Sta];"));
            if (Type) Functions.SetComboBox(ref comboBoxType, DB_Functions.Load_data("select [Typ] from [IS] where [teacherID]=" + Form_signup.id + " and [Sta]='" + comboBoxStage.Text + "' group by [Typ];"));
            if (Division) Functions.SetComboBox(ref comboBoxDivision, DB_Functions.Load_data("select [Div] from [IS] where [teacherID]= " + Form_signup.id + " and [Sta]='" + comboBoxStage.Text + "'" + " and [Typ]='" + comboBoxType.Text + "'"  + "  group by [Div];"));
            if (Groups) Functions.SetComboBox(ref comboBoxGroups, DB_Functions.Load_data("select [Gro] from [IS] where [teacherID]= " + Form_signup.id + " and [Sta]='" + comboBoxStage.Text + "'" + " and [Typ]='" + comboBoxType.Text + "'"  + " and [Div]='" + comboBoxDivision.Text + "'" + "  group by [Gro];"));
            if (Subjects) Functions.SetComboBox(ref comboBoxSubjects, DB_Functions.Load_data("select distinct [Les] from [IS] where [teacherID]=" + Form_signup.id + " and [Sta]='" + comboBoxStage.Text + "';"));
        }

        //Event
        private void Home2_Load(object sender, EventArgs e)
        {
            set(true);
            this.Size = Slim;
            Load_data_specific();
           
            dateTimePicker1.Value = DateTime.Now;
            Count();
            
 

            nameTecher.Text=Form_signup.name;
            try
            {
                imageAccount.Image = Image.FromFile(Form_signup.image);
            }
            catch
            {
                imageAccount.Image = Image.FromFile("C:\\Users\\Ali\\Desktop\\picture\\icon\\lock_891397.png");
            }





        }



        private void pictureBox9_Click(object sender, EventArgs e)
        {
                Environment.Exit(0);
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
            panel4.Visible = false;
            for (int i = 0; i < 26; i++)
            {
                
                this.Size = new Size(Size.Width - 8, Size.Height);
            }

            pictureBox1.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            cbocamera.Visible = false;
            pictureBox_show.Visible = false;
            label5.Visible = false;
            txtbarcode.Visible = false;
            cameraOff.Visible = true;
            if (device != null)
                if (device.IsRunning)
                    device.Stop();
        }

        private void cameraOff_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 26; i++)
            {
                
                this.Size=new Size(Size.Width+8, Size.Height);
            }
            panel4.Visible = true;
            pictureBox1.Visible = true;
            label1.Visible = true;
            label3.Visible = true;
            cbocamera.Visible = true;
            pictureBox_show.Visible = true;
            label5.Visible = true;
            txtbarcode.Visible = true;

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


            DataTable date2 = DB_Functions.Load_data("if not exists (select * from dates where [Date]='"+dateTimePicker1.Value+"')" +
                                                "begin INSERT INTO [dbo].[dates]([Date])output INSERTED.id VALUES('"+dateTimePicker1.Value + "'); end " +
                                                "else begin select [id] from dates where [Date]='"+dateTimePicker1.Value + "'; end");
            if (isedit)
            {
                foreach (DataGridViewRow data in table_edite.Rows)
                {
                    string ab = data.Cells[4].Value.ToString() == "True" ? "1" : "0"
                        , q = "UPDATE [absences] SET [PA] = "+ab+",[Note] =' "+ data.Cells[5].Value.ToString() + "' WHERE [studentID]= "+ data.Cells[0].Value;
                    DB_Functions.Execute(q);
                }
            }
            else
            {
                foreach (DataGridViewRow data in table_edite.Rows)
                {
                    string ab = data.Cells[4].Value.ToString() == "True" ? "1" : "0"
                        , type = comboBoxType.Text == "صباحي" ? "0" : "1"
                        , q = "INSERT INTO [dbo].[absences]([studentID],[dateID],[lessonID],[PA],Note)" +
                        "VALUES(" + data.Cells[0].Value + "," + date2.Rows[0][0].ToString() +
                        ",(select [id] from [lessons] where [Name]='" + comboBoxSubjects.Text + "' and [infID]='" + infoid + "' and [teacherID]="+Form_signup.id+")," + ab + ",'" + data.Cells[5].Value + "')";
                    DB_Functions.Execute(q);
                }
            }
            MessageBox.Show("تم اضافة الحضورة","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Load_data_specific();
        }

        private void iconDelete_Click(object sender, EventArgs e)
        {
            CheckLeave();
            for (int i = 0; i < table_edite.Rows.Count; i++)
            {
                table_edite.Rows[i].Cells[4].Value = CheckState.Unchecked;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panelShowPage.StateCommon.Color1 = Color.FromArgb(66, 73, 118);
            panleHomePage.StateCommon.Color1 = Color.Transparent;
            panelControlPage.StateCommon.Color1 = Color.Transparent;
            panel8.Visible = false;
            panel5.Size = new Size(908, 44);
            dataShow1.BringToFront();
            table_edite.Visible = false;
            panel2.Visible = false;
            controlStudent1.Visible = false;
            dataShow1.Visible = true;
            Functions.SetComboBox(ref comboBoxStage, DB_Functions.Load_data("SELECT distinct [Sta] FROM [info] "));
        }

        private void acount_Click(object sender, EventArgs e)
        {
            panleHomePage.StateCommon.Color1 = Color.Transparent;
            panelControlPage.StateCommon.Color1 = Color.FromArgb(66, 73, 118);
            panelShowPage.StateCommon.Color1 = Color.Transparent;
            panel8.Visible = false;
            panel5.Size = new Size(908, 44);
            table_edite.Visible = false;
            panel2.Visible = false;
            controlStudent1.Visible = true;
            dataShow1.Visible = false;
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
            Count();
            
        }
        
 




       

        private void file_Click(object sender, EventArgs e)
        {
            panleHomePage.StateCommon.Color1 = Color.FromArgb(66, 73, 118);
            panelControlPage.StateCommon.Color1 = Color.Transparent;
            panelShowPage.StateCommon.Color1 = Color.Transparent;
            panel8.Visible = true;
            panel5.Size = new Size(908, 133);
            dataShow1.Visible = false;
            controlStudent1.Visible = false;
            table_edite.Visible = true;
            panel2.Visible = true;
            

        }
        bool menu_E= true;
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (menu_E)
            {
                for (int i = 0; i < 14; i++)
                    panel1.Size = new Size(panel1.Width - 8, panel1.Height);
            }
            else
            {
                for(int i = 0; i < 14;i++)
                    panel1.Size = new Size(panel1.Width+8,panel1.Height);
            }
            menu_E = !menu_E;
        }

        private void cbocamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            start();
        }
        bool minmize=false;
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
                minmize=false;
            }
            
        }

        private void table_edite_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Count(); 
        }

        private void Home2_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckLeave();
        }

       

      

    

     

        

        

        private void PanelOpenStage_Click(object sender, EventArgs e)
        {
            if (PanelListStage.Height != 47)
            {
                for (int i = 0; i <78; i++)
                PanelListStage.Height = PanelListStage.Height-2;
            }
            else
            {
                if (PanelListSupject.Height != 47)
                    for (int i = 0; i < 80; i++)
                        PanelListSupject.Height = PanelListSupject.Height - 1;
                


                for (int i = 0; i < 78; i++)
                    PanelListStage.Height = PanelListStage.Height + 2;
            }
        }

        private void labelStage_Click(object sender, EventArgs e)
        {
            if (PanelListStage.Height != 47)
            {
                for (int i = 0; i < 78; i++)
                    PanelListStage.Height = PanelListStage.Height - 2;
            }
            else
            {
                if (PanelListSupject.Height != 47)
                    for (int i = 0; i < 80; i++)
                        PanelListSupject.Height = PanelListSupject.Height - 1;
                

                for (int i = 0; i < 78; i++)
                    PanelListStage.Height = PanelListStage.Height + 2;
            }

        }

        private void PanelOpenSupject_Click(object sender, EventArgs e)
        {
            if(PanelListSupject.Height==47)
            {
                if (PanelListStage.Height != 47)
                {
                    for (int i = 0; i < 78; i++)
                        PanelListStage.Height = PanelListStage.Height - 2;
                }

                for (int i = 0;i<80;i++)
                PanelListSupject.Height = PanelListSupject.Height+1;
            }
            else
            {
                for (int i = 0; i < 80; i++)
                    PanelListSupject.Height = PanelListSupject.Height - 1;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (PanelListSupject.Height == 47)
            {
                if (PanelListStage.Height != 47)
                {
                    for (int i = 0; i < 78; i++)
                        PanelListStage.Height = PanelListStage.Height - 2;
                }

                for (int i = 0; i < 80; i++)
                    PanelListSupject.Height = PanelListSupject.Height + 1;
            }
            else
            {
                for (int i = 0; i < 80; i++)
                    PanelListSupject.Height = PanelListSupject.Height - 1;
            }
        }

        

    

        

        private void LogOut_Click(object sender, EventArgs e)
        {
            Form_signup form = new Form_signup();
            Hide();
            form.FormClosed += (f,d) => this.Close();
            form.Show();
        }

        

        private void table_edite_KeyUp(object sender, KeyEventArgs e)
        {
            Count();
        }

        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Load_data_specific();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState= FormWindowState.Minimized;
        }




        private void comboBoxStage_TextChanged_1(object sender, EventArgs e)
        {
            set(Type: true,Subjects:true);

        }
        private void comboBoxType_TextChanged_1(object sender, EventArgs e)
        {
            set(Division: true);
        }
        private void comboBoxDivision_TextChanged_1(object sender, EventArgs e)
        {
            set(Groups: true);
            

        }

       

        private void comboBoxGroups_TextChanged(object sender, EventArgs e)
        {
            DataTable data = DB_Functions.Load_data("SELECT id FROM [info] where Sta='" + comboBoxStage.Text + "'" + " and [Typ]='" + comboBoxType.Text + "'"  + " and [Div]='" + comboBoxDivision.Text + "'" + " and [Gro]='" + comboBoxGroups.Text + "'" );
            if (data.Rows.Count >0) infoid = data.Rows[0][0].ToString();
             Load_data_specific();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
           informtion form = new informtion();
            form.FormClosed += (c, a) => this.Show();
            form.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Hide();
            teachers form = new teachers();
            form.FormClosed += (c, a) => this.Show();
            form.Show();
        }
    }
}
