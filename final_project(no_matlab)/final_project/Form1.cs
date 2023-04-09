using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using Osc;
using System.IO;
using System.Threading;
using System.Drawing.Drawing2D;

namespace final_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Status now = Status.PRE_START;
        Errorcodes errorcode = Errorcodes.NO_COM;
        
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox_com.Text;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 115200;    //這個之後要再調整
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.DataBits = 8;
            comboBox_com.Items.AddRange(SerialPort.GetPortNames());
            label_display_status.Text = "尚未連線喔，請按連線按鈕";
            button_dis_com.Enabled = false;
            button_drawing.Enabled = false;
            button_get_value.Enabled = false;
            //button_osc.Enabled = false;
            button_stop_get_value.Enabled=false;
            g = this.panel_drawing.CreateGraphics();
            ALL = new List<Object>();
            //radioButton_Acc.Enabled = false;
            //radioButton_Acc.Checked = false;
            //radioButton_Gy.Enabled = false;
            //radioButton_Gy.Checked = false;
            Form.CheckForIllegalCrossThreadCalls = false;
            chart_osc.Visible = false;
        
            
            //示波器的部分
            
            //設定ChartArea
            /*此部分可以在屬性列表那裏做修改，就不用這麼多程式碼了
            ChartArea DisplayArea_Acc = new ChartArea("Display_Acc");
            DisplayArea_Acc.AxisX.Minimum = 0;
            DisplayArea_Acc.AxisX.ScaleView.Size = 20;
            DisplayArea_Acc.AxisX.Interval = 5;
            DisplayArea_Acc.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            DisplayArea_Acc.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            DisplayArea_Acc.AxisX.ScrollBar.Enabled = true;
            DisplayArea_Acc.AxisX.ScrollBar.IsPositionedInside = true;
            chart_osc.ChartAreas[0] = DisplayArea_Acc;
            
            ChartArea DisplayAre_Gy = new ChartArea("Display_Gy");
            DisplayAre_Gy.AxisX.Minimum = 0;
            DisplayAre_Gy.AxisX.ScaleView.Size = 20;
            DisplayAre_Gy.AxisX.Interval = 5;
            DisplayAre_Gy.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            DisplayAre_Gy.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            DisplayAre_Gy.AxisX.ScrollBar.Enabled = true;
            DisplayAre_Gy.AxisX.ScrollBar.IsPositionedInside = true;
            chart_osc.ChartAreas[1] = DisplayAre_Gy;
            */
            //設定圖表的title

            //存檔讀檔

            //rtf讀黨有問題，先拿掉
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Plain Text(*.txt)|*.txt|All Files(*.*)|*.*";
            saveFileDialog.Filter = "Plain Text(*.txt)|*.txt|All Files(*.*)|*.*";
            DirectoryInfo ProjectDir = new DirectoryInfo(Application.StartupPath);
            openFileDialog.InitialDirectory = ProjectDir.Parent.Parent.Parent.FullName;
            
        }

       

        private void label_acc_all_Click(object sender, EventArgs e)
        {

        }

        private void button_recom_Click(object sender, EventArgs e)
        {
            if (now == Status.PRE_START)
            {
                comboBox_com.Items.AddRange(SerialPort.GetPortNames());
                Refresh();
            }
        }

        private void button_start_com_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            { 
                now = Status.NO_COM;
                errorcode = Errorcodes.COM_FAL;
                
                MessageBox.Show("找不到任何設備!\n請確認序列埠後再試一次\n", "Oh, no, there is a Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label_display_status.Text = "連線失敗";
                return;
            }
            
            
            label_display_status.Text = "成功連線";
            button_start_com.Enabled = false;
            button_dis_com.Enabled = true;
            //button_drawing.Enabled = true;
            button_get_value.Enabled = true;
            button_osc.Enabled = true;
            button_recom.Enabled = false;
            radioButton_Acc.Enabled = true;
            radioButton_Gy.Enabled = true;
            radioButton_Acc.Checked = true;
        }

        private void button_dis_com_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            button_dis_com.Enabled=false;
            button_get_value.Enabled=false;
            //button_drawing.Enabled=false;
            button_osc.Enabled=false;
            button_stop_get_value.Enabled=false;
            button_start_com.Enabled = true;
            label_display_status.Text = "斷線中";
        }

        private void button_get_value_Click(object sender, EventArgs e)
        {
            serialPort1.DtrEnable = true;   //不確定需不需要
            serialPort1.RtsEnable = true;   //不確定需不需要
                                            //https://www.cnblogs.com/luguangguang/p/8257165.html

            button_osc.Enabled = false;
            timer1.Enabled = true;
            serialPort1.DataReceived += SerialPort1_DataReceived;
            Thread.Sleep(4500);
            button_get_value.Enabled = false;
            button_stop_get_value.Enabled = true;
            button_drawing.Enabled = true;
            button_osc.Enabled = true;
            timer1.Start();
            
        }
        double timercount = 0;
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Console.WriteLine(CurrentTime);
            
            CurDisplay = new Display(g);
            string CurLine = serialPort1.ReadLine();
            Errorcodes CurErrorCode = Errorcodes.INIT; 
            richTextBox1.Text += CurLine;
            if (CurLine != null)
            {
                CurErrorCode = CurDisplay.SaveData(CurLine);
            }
            else 
            {
                MessageBox.Show("No DATA", "CHECK!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CurErrorCode = Errorcodes.NO_COM;
            }

            switch (CurErrorCode)
            {
                case Errorcodes.NONE:
                    ALL = CurDisplay.Entity.FindAll(delegate (Object obj) { return obj.GetType() == typeof(Acc); });
                    
                    
                    foreach (Object CurrentDisplay in ALL)
                    {
                        Acc CurrentAcc = (Acc)CurrentDisplay;
                        ShowData_Acc(CurrentAcc);                    
                    }
                    

                    ALL = CurDisplay.Entity.FindAll(delegate (Object obj) { return obj.GetType() == typeof(Gy); });
                    
    
                    foreach (Object CurrentDisplay in ALL)
                    {
                        Gy CurrentGy = (Gy)CurrentDisplay;
                        ShowData_Gy(CurrentGy);
                    }
                    
                    ALL = CurDisplay.Entity.FindAll(delegate (Object obj) { return obj.GetType() == typeof(Temp); });

                    foreach (Object CurrentDisplay in ALL)
                    {
                        Temp CurrentTemp = (Temp)CurrentDisplay;
                        ShowData_Temp(CurrentTemp);
                    }
                    
                    if (CurLine.Contains("**"))
                    {
                        timercount++;
                    }
                    Console.WriteLine("timercount : " + timercount);
                    break;
            }

        }
        private void ShowData_Acc(Acc CurrentAcc)
        {
            label_accx.Text = CurrentAcc.Acc_x.ToString();
            label_accy.Text = CurrentAcc.Acc_y.ToString();
            label_accz.Text = CurrentAcc.Acc_z.ToString();

            Console.WriteLine("Acc : " + CurrentAcc.Data_count);
            chart_osc.Series[0].Points.AddXY(timercount, CurrentAcc.Acc_x);
            chart_osc.Series[1].Points.AddXY(timercount, CurrentAcc.Acc_y);
            chart_osc.Series[2].Points.AddXY(timercount, CurrentAcc.Acc_z);
            Radiobutton_osc();
            chart_osc.ChartAreas[0].AxisX.ScaleView.Scroll(ScrollType.Last);
        }

        private void ShowData_Gy(Gy CurrentGy)
        {
            label_gyx.Text = CurrentGy.Gy_x.ToString();
            label_gyy.Text = CurrentGy.Gy_y.ToString();
            label_gyz.Text = CurrentGy.Gy_z.ToString();

            Console.WriteLine("Gy : " + CurrentGy.Data_count);
            chart_osc.Series[3].Points.AddXY(timercount, CurrentGy.Gy_x);
            chart_osc.Series[4].Points.AddXY(timercount, CurrentGy.Gy_y);
            chart_osc.Series[5].Points.AddXY(timercount, CurrentGy.Gy_z);
            Radiobutton_osc();


            chart_osc.ChartAreas[0].AxisX.ScaleView.Scroll(ScrollType.Last);
        }

        private void ShowData_Temp(Temp CurrentTemp)
        {
            label_temp_value.Text = CurrentTemp.Temperature.ToString();
            Console.WriteLine("Temp : " + CurrentTemp.Temp_count);
        }
        private void button_stop_get_value_Click(object sender, EventArgs e)
        {
            now = Status.STOP_GET_VALUE;
            button_stop_get_value.Enabled = false;
            button_get_value.Enabled = true;
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            double timercount = 0;

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CurDisplay = new Display(g);
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                string CurLine;
                Stopwatch sw = new Stopwatch();

                while (sr.Peek() >= 0)
                {
                    CurLine = sr.ReadLine();
                    Console.WriteLine("timercount : " + timercount);
                    Console.WriteLine(DateTime.Now.TimeOfDay + CurLine);
                    Errorcodes CurErrorCode = Errorcodes.INIT;
                    if (CurLine != null)
                    {
                        CurErrorCode = CurDisplay.SaveData(CurLine);
                    }
                    else
                    {
                        MessageBox.Show("No DATA", "CHECK!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CurErrorCode = Errorcodes.NO_COM;
                    }

                    switch (CurErrorCode)
                    {
                        case Errorcodes.NONE:
                            if (CurLine == "********************************************")
                            {
                                timercount++;
                            }
                            break;
                    }

                }
                Console.WriteLine(timercount);

                for (int i = 0; i < timercount ; ++i)
                {
                    ALL = CurDisplay.Entity.FindAll(delegate (Object obj) { return obj.GetType() == typeof(Acc); });
                    //radioButton_Acc.Checked = true; 
                    Object CurrentDisplay1 = ALL[i];
                    Acc CurrentAcc = (Acc)CurrentDisplay1;
                    ShowData_Acc(CurrentAcc);
                    //***********
                    ALL = CurDisplay.Entity.FindAll(delegate (Object obj) { return obj.GetType() == typeof(Gy); });
                    //radioButton_Gy.Checked = true;
                    CurrentDisplay1 = ALL[i];
                    Gy CurrentGy = (Gy)CurrentDisplay1;
                    ShowData_Gy(CurrentGy);
                    //**********
                    ALL = CurDisplay.Entity.FindAll(delegate (Object obj) { return obj.GetType() == typeof(Temp); });
                    CurrentDisplay1 = ALL[i];
                    Temp CurrentTemp = (Temp)CurrentDisplay1;
                    ShowData_Temp(CurrentTemp);
                    
                    Thread.Sleep(900);
                }
            }
        }

        public void Radiobutton_osc()
        {
            /*
            //可以直接設定在圖表裡面，就不用寫這麼多出來了
            chart_osc.ChartAreas[0].AxisX.Title = "時間(單位 : s)";
            chart_osc.ChartAreas[0].AxisY.Title = "加速度(單位 : G)";
            chart_osc.Series[0].Name = "Acc_x";
            chart_osc.Series[1].Name = "Acc_y";
            chart_osc.Series[2].Name = "Acc_z";

            chart_osc.ChartAreas[0].AxisY.Maximum = 5;
            chart_osc.ChartAreas[0].AxisY.Minimum = -5;
            //*****************
            chart_osc.ChartAreas[1].AxisX.Title = "時間(單位 : s)";
            chart_osc.ChartAreas[1].AxisY.Title = "角速度(單位 : degrees/s)";
            chart_osc.Series[3].Name = "Gy_x";
            chart_osc.Series[4].Name = "Gy_y";
            chart_osc.Series[5].Name = "Gy_z";

            chart_osc.ChartAreas[1].AxisY.Maximum = 300;
            chart_osc.ChartAreas[1].AxisY.Minimum = -300;

            */
            if (radioButton_Acc.Checked == true)
            {
                chart_osc.Titles[0].Visible = true;
                chart_osc.Titles[1].Visible = false;
                chart_osc.ChartAreas[0].Visible = true;
                chart_osc.ChartAreas[1].Visible = false;

            }
            else if (radioButton_Gy.Checked == true)
            {
                chart_osc.Titles[0].Visible = false;
                chart_osc.Titles[1].Visible = true;
                chart_osc.ChartAreas[0].Visible = false;
                chart_osc.ChartAreas[1].Visible = true;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void button_drawing_Click(object sender, EventArgs e)
        {
            Console.WriteLine("ALL.count : " + ALL.Count);
            Refresh();
        }

        private void button_osc_Click(object sender, EventArgs e)
        {
            chart_osc.Visible = true;
            button_osc.Enabled = false;
        }

        private void panel_drawing_Paint(object sender, PaintEventArgs e)
        {
            if (CurDisplay == null) return;
            //Console.WriteLine("here" + CurrentTime);

            int foo = 1;
            //畫坐標軸區
            if (radioButton_Acc.Checked)
            {
                foo = 1;
            }
            else if (radioButton_Gy.Checked)
            {
                foo = 2;
            }

            Data Currentwork = new Data();
            Currentwork.DrawAxis(label_accx.Text, label_accy.Text, label_accz.Text, g, foo); 
            Acc CurrentAcc = new Acc();
            CurrentAcc.DrawAxis(label_accx.Text, label_accy.Text, label_accz.Text, g, foo);
            Gy CurrentGy = new Gy();
            CurrentGy.DrawAxis(label_gyx.Text, label_gyy.Text, label_gyz.Text, g, foo);

            

            

            //Pen penX = new Pen(Color.Red, 4);
            //Pen penY = new Pen(Color.Green, 4);
            //Pen penZ = new Pen(Color.Blue, 4);
            //g.DrawLine(penX, 10, (float)(panel_drawing.Size.Height / 2 - (panel_drawing.Size.Width / 2) * Math.Sin(5 * Math.PI / 180)), (panel_drawing.Size.Width - 10), (float)(panel_drawing.Size.Height / 2 + (panel_drawing.Size.Width / 2) * Math.Sin(5 * Math.PI / 180)));
            //g.DrawLine(penY, (float)(panel_drawing.Size.Width / 2 + (panel_drawing.Size.Height / 2) * Math.Sin(35 * Math.PI / 180)), 10, (float)(panel_drawing.Size.Width / 2 - (panel_drawing.Size.Height / 2) * Math.Sin(35 * Math.PI / 180)), (panel_drawing.Size.Height - 10));
            //g.DrawLine(penZ, (panel_drawing.Size.Width / 2), 50, (panel_drawing.Size.Width / 2), panel_drawing.Size.Height -50);

            /*
            SolidBrush solidBrush1 = new SolidBrush(Color.Red);
            SolidBrush solidBrush2 = new SolidBrush(Color.Green);
            SolidBrush solidBrush3 = new SolidBrush(Color.Blue);
            Font Drawfont = new Font("Arial", 18);
            g.DrawString("X", Drawfont, solidBrush1, (panel_drawing.Size.Width - 30), (float)(panel_drawing.Size.Height / 2 + (panel_drawing.Size.Width / 2) * Math.Sin(5 * Math.PI / 180) - 30));
            g.DrawString("Y", Drawfont, solidBrush2, (float)(panel_drawing.Size.Width / 2 - (panel_drawing.Size.Height / 2) * Math.Sin(35 * Math.PI / 180) + 30), (panel_drawing.Size.Height - 30));
            g.DrawString("Z", Drawfont, solidBrush3, (panel_drawing.Size.Width / 2 + 20), 50);

            


            //X
            g.DrawArc(pen, (panel_drawing.Size.Width - 120), (float)(panel_drawing.Size.Height / 2 + (panel_drawing.Size.Width / 2) * Math.Sin(5 * Math.PI / 180) - 45), 60, 70, 90, 280);
            g.DrawString(label_gyx.Text, Drawfont, solidBrush1, (panel_drawing.Size.Width - 120), (float)(panel_drawing.Size.Height / 2 + (panel_drawing.Size.Width / 2) * Math.Sin(5 * Math.PI / 180) - 75));
            //Y
            g.DrawArc(pen, (float)(panel_drawing.Size.Width / 2 - (panel_drawing.Size.Height / 2) * Math.Sin(35 * Math.PI / 180)), (panel_drawing.Size.Height - 90), 60, 60, 80, -280);
            g.DrawString(label_gyy.Text, Drawfont, solidBrush2, (float)(panel_drawing.Size.Width / 2 - (panel_drawing.Size.Height / 2) * Math.Sin(35 * Math.PI / 180) - 70), (panel_drawing.Size.Height - 90));
            //Z
            g.DrawArc(pen, (panel_drawing.Size.Width / 2  - 43), 70, 80, 60, -70, 260);
            g.DrawString(label_gyz.Text, Drawfont, solidBrush3, (panel_drawing.Size.Width / 2 - 90), 50);
            
            
            
          */
            //ALL = CurDisplay.Entity.FindAll(delegate (Object obj) { return obj.GetType() == typeof(Gy); });

            //Object CurDis = ALL[CurrentTime];


            /*

            ALL = CurDisplay.Entity.FindAll(delegate (Object obj) { return obj.GetType() == typeof(Acc); });
            //Object CurDis = ALL[CurrentTime];
            foreach (Object Currententity in ALL)
            {
                Acc hank = (Acc)Currententity;
                Console.WriteLine("ACC : ");
                Console.WriteLine(CurrentTime);
                Console.WriteLine(hank.Acc_x);
                Console.WriteLine(hank.Acc_y);
                Console.WriteLine(hank.Acc_z);
            }

            */

        }

        double hand = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            CurrentTime++;
            //Console.WriteLine(CurrentTime.ToString());
            if (hand == 20)
            { 
                //Console.WriteLine(CurrentTime.ToString());
                hand = 0;
            }
            hand++;
            
            Refresh();
            
        }

        private void button_open_file_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                backgroundWorker1.RunWorkerAsync();
            }

        }

        private void button_save_file_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                String Filename = saveFileDialog.FileName;
                String[] str = Filename.Split('.');
                String FileType = str[str.Count() - 1];
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }

                if (FileType == "rtf")
                {
                    richTextBox1.SaveFile(Filename, RichTextBoxStreamType.RichText);
                }
                else if (FileType == "txt")
                {
                    richTextBox1.SaveFile(Filename, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            CurrentTime++;
            
        }

        private void panel_drawing_MouseDown(object sender, MouseEventArgs e)
        {


            
            DirectoryInfo ProjectDir = new DirectoryInfo(Application.StartupPath);
            openFileDialog.InitialDirectory = ProjectDir.Parent.Parent.Parent.FullName;
            //string filepath = Application.StartupPath;
            string filepath = ProjectDir.Parent.Parent.FullName;

            Bitmap bit = new Bitmap(this.Width + 250, this.Height );//實例化一個和窗體一樣大的bitmap
            Graphics g = Graphics.FromImage(bit);
            g.CompositingQuality = CompositingQuality.HighQuality;//質量設爲最高
            g.CopyFromScreen(this.Left + 30 , this.Top, 0, 0, new Size(this.Width + 300, this.Height + 300));//保存整個窗體爲圖片
                                                                                                             //g.CopyFromScreen(panel遊戲區 .PointToScreen(Point.Empty), Point.Empty, panel遊戲區.Size);//只保存某個控件（這裏是panel遊戲區）
            
            if (e.Button == MouseButtons.Left) 
            {
                if (e.X < 50 && e.Y < 30)
                {
                    num += 1;
                    string outputname = Convert.ToString(num) + "_osc.png";
                    bit.Save(filepath  + outputname, System.Drawing.Imaging.ImageFormat.Png);//默認保存格式爲PNG，保存成jpg格式質量不是很好
                    
                }
            }
            
        }
    }
}
