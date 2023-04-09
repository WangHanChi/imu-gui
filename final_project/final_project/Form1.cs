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
using MathWorks.MATLAB.NET.Arrays; 
using MathWorks.MATLAB.NET.Utility;
using c130;
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
            serialPortArduino.PortName = comboBox_com.Text;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            now = Status.PRE_START;
            Work_Status(now); //依目前狀態並給出相對應的設定
            comboBox_com.Items.AddRange(SerialPort.GetPortNames());
            label_display_status.Text = "尚未連線喔，請按連線按鈕";           
            g = this.panel_drawing.CreateGraphics();
            ALL = new List<Object>();         
            Form.CheckForIllegalCrossThreadCalls = false;
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Plain Text(*.txt)|*.txt|All Files(*.*)|*.*";
            saveFileDialog.Filter = "Plain Text(*.txt)|*.txt|All Files(*.*)|*.*";
            DirectoryInfo ProjectDir = new DirectoryInfo(Application.StartupPath);
            openFileDialog.InitialDirectory = ProjectDir.Parent.Parent.Parent.Parent.FullName;
            CurrentTime =0 ;
        }
        private void button_recom_Click(object sender, EventArgs e) //按下重新連線
        {
            if (now == Status.PRE_START)
            {
                comboBox_com.Items.AddRange(SerialPort.GetPortNames());
                Refresh();
            }

            foreach (var series in chart_osc.Series)
            {
                series.Points.Clear();
            }
            ALL.Clear();
            CurrentTime = 0;
            timercount = 0;
            time = 0;
            num = 0;
            richTextBox.Clear();
        }

        private void button_start_com_Click(object sender, EventArgs e)  
        {
            try
            {
                serialPortArduino.Open();
            }
            catch (Exception ex)
            { 
                now = Status.NO_COM;
                errorcode = Errorcodes.COM_FAL;                
                MessageBox.Show("找不到任何設備!\n請確認序列埠後再試一次\n", "Oh, no, there is a Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label_display_status.Text = "連線失敗";
                Console.WriteLine(ex.ToString());
                return;
            }                   
            label_display_status.Text = "成功連線";
            now = Status.SUSS_COM;
            Work_Status(now);
        }

        private void button_dis_com_Click(object sender, EventArgs e)
        {
            serialPortArduino.Close();
            now = Status.DIS_COM;
            Work_Status(now);
            label_display_status.Text = "斷線中";
        }
        private void button_get_value_Click(object sender, EventArgs e)
        {
            now = Status.GET_VALUE;
            Work_Status(now);
            serialPortArduino.DataReceived += SerialPort1_DataReceived;
            Thread.Sleep(4500); //等待4.5秒 讓Arduino 連線穩定            
            timer1.Start();            
        }
       
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            timercount = 0;
            time = 0;
            CurDisplay = new Display(g);
            string CurLine = serialPortArduino.ReadLine();
            Errorcodes CurErrorCode = Errorcodes.INIT; 
            richTextBox.Text += CurLine;
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
                    
                    if (CurLine.Contains("**")) //代表一個區塊輸出完成
                    {
                        timercount++;
                        time++;
                    }
                    break;
            }
        }
        private void ShowData_Acc(Acc CurrentAcc) //顯示加速度資料
        {
            try
            {        
                label_accx.Text = CurrentAcc.Acc_x.ToString();
                label_accy.Text = CurrentAcc.Acc_y.ToString();
                label_accz.Text = CurrentAcc.Acc_z.ToString();
                chart_osc.Series[0].Points.AddXY(time, CurrentAcc.Acc_x);
                chart_osc.Series[1].Points.AddXY(time, CurrentAcc.Acc_y);
                chart_osc.Series[2].Points.AddXY(time, CurrentAcc.Acc_z);

                Radiobutton_osc();
                chart_osc.ChartAreas[0].AxisX.ScaleView.Scroll(ScrollType.Last);
            }
            catch (Exception e)
            {
                Console.WriteLine("ACC_exception : ", e.Message);  
            }
        }

        private void ShowData_Gy(Gy CurrentGy) //顯示陀螺儀資料
        {
            try
            {
                label_gyx.Text = CurrentGy.Gy_x.ToString();
                label_gyy.Text = CurrentGy.Gy_y.ToString();
                label_gyz.Text = CurrentGy.Gy_z.ToString();
                chart_osc.Series[3].Points.AddXY(time, CurrentGy.Gy_x);
                chart_osc.Series[4].Points.AddXY(time, CurrentGy.Gy_y);
                chart_osc.Series[5].Points.AddXY(time, CurrentGy.Gy_z);
                Radiobutton_osc();


                chart_osc.ChartAreas[0].AxisX.ScaleView.Scroll(ScrollType.Last);
            }
            catch (Exception e)
            {
                Console.WriteLine("GY_exception : ", e.Message);
            }          
        }

        private void ShowData_Temp(Temp CurrentTemp) //顯示溫度資料
        {
            try 
            {                
                label_temp_value.Text = CurrentTemp.Temperature.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("TEMP_exception : ", e.Message);
            }
        }
        private void button_matlab_Click(object sender, EventArgs e) //開啟3D顯示圖
        {
            groupBox_3d.Visible = true;          
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) //不用Arduino 直接讀先前存好的txt
        {
            timercount = 0;
            time = 0;
            {
                CurDisplay = new Display(g);
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                string CurLine;
                Stopwatch sw = new Stopwatch();

                while (sr.Peek() >= 0)
                {
                    CurLine = sr.ReadLine();
                    richTextBox.Text  = richTextBox.Text + CurLine + "\n";
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
                            if (CurLine.Contains("***"))
                            {
                                timercount++;
                            }
                            break;
                    }
                }
                for (int i = 0; i < timercount ; ++i)
                {
                    ALL = CurDisplay.Entity.FindAll(delegate (Object obj) { return obj.GetType() == typeof(Acc); });
                    Object CurrentDisplay1 = ALL[i];
                    Acc CurrentAcc = (Acc)CurrentDisplay1;
                    ShowData_Acc(CurrentAcc);
                    ALL = CurDisplay.Entity.FindAll(delegate (Object obj) { return obj.GetType() == typeof(Gy); });
                    CurrentDisplay1 = ALL[i];
                    Gy CurrentGy = (Gy)CurrentDisplay1;
                    ShowData_Gy(CurrentGy);
                    ALL = CurDisplay.Entity.FindAll(delegate (Object obj) { return obj.GetType() == typeof(Temp); });
                    CurrentDisplay1 = ALL[i];
                    Temp CurrentTemp = (Temp)CurrentDisplay1;
                    ShowData_Temp(CurrentTemp);
                    time++;
                    Thread.Sleep(900);
                }
            }
        }

        public void Radiobutton_osc() //決定要顯示加速度還是陀螺儀
        {           
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            if (serialPortArduino.IsOpen)
            {
                serialPortArduino.Close();
            }
            else if (backgroundWorkerOffline.IsBusy)
            {
                backgroundWorkerOffline.CancelAsync();
                Thread.Sleep(50);
            }
            else if (backgroundWorkerMatlab.IsBusy)
            {
                MessageBox.Show("下次要把3D圖的Radio Button調到No","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                backgroundWorkerMatlab.CancelAsync();
            }
        }

        private void button_drawing_Click(object sender, EventArgs e)
        {
            Refresh();
            panel_drawing.Visible = true;
        }

        private void button_osc_Click(object sender, EventArgs e)
        {
            chart_osc.Visible = true;
            button_osc.Enabled = false;
        }

        private void panel_drawing_Paint(object sender, PaintEventArgs e)
        {
            if (CurDisplay == null) return;

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
        }


        private void timer1_Tick(object sender, EventArgs e)
        {            
            Refresh();
            CurrentTime++;
        }

        private void button_open_file_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                now = Status.OPEN_FILE;
                Work_Status(now);
                if (backgroundWorkerOffline.IsBusy)
                { 
                    backgroundWorkerOffline.CancelAsync();
                }
                backgroundWorkerOffline.RunWorkerAsync();
            }
        }
        private void button_save_file_Click(object sender, EventArgs e) 
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                String Filename = saveFileDialog.FileName;
                String[] str = Filename.Split('.');
                String FileType = str[str.Count() - 1];
                if (serialPortArduino.IsOpen)
                {
                    serialPortArduino.Close();
                }

                if (FileType == "txt")
                {
                    richTextBox.SaveFile(Filename, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void panel_drawing_MouseDown(object sender, MouseEventArgs e) //截圖用
        {            
            DirectoryInfo ProjectDir = new DirectoryInfo(Application.StartupPath);       
            string filepath = ProjectDir.Parent.Parent.Parent.FullName;
            Bitmap bit = new Bitmap(this.Width + 250, this.Height );
            Graphics g = Graphics.FromImage(bit);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.CopyFromScreen(this.Left + 30 , this.Top, 0, 0, new Size(this.Width + 300, this.Height + 300));                                                                                                      
            num = 0;
            if (e.Button == MouseButtons.Left) 
            {
                if (e.X < 50 && e.Y < 30)
                {
                    num += 1;
                    string outputname = Convert.ToString(num) + "_osc.png";
                    bit.Save(filepath  + outputname, System.Drawing.Imaging.ImageFormat.Png);
                }
            } 
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e) //畫matlab 3D圖用
        {
            while (time <= timercount) 
            {
                try
                {
                    c130.Airplane3D picture = new c130.Airplane3D();
                    if (label_gyx.Text != "尚無資料" && label_gyy.Text != "尚無資料" && label_gyz.Text != "尚無資料")
                    {
                        double yaw = Convert.ToDouble(label_gyx.Text);
                        double pitch = Convert.ToDouble(label_gyy.Text);
                        double roll = Convert.ToDouble(label_gyz.Text);
                        picture.c130("yaw", (MWArray)yaw, "pitch", (MWArray)pitch, "roll", (MWArray)roll);
                        Console.WriteLine("Done picture");
                    }                    
                }
                catch (Exception exx)
                {
                    Console.WriteLine("Matlab_exception : ", exx.Message);
                }                                            
            }                        
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_no.Checked)
            {
                backgroundWorkerMatlab.CancelAsync();
            }
            else if (radioButton_yes.Checked)
            {
                if (backgroundWorkerMatlab.IsBusy)
                {
                    backgroundWorkerMatlab.CancelAsync();
                }
                else
                {
                    backgroundWorkerMatlab.RunWorkerAsync();
                }
            }
        }
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            richTextBox.SelectionStart = richTextBox.TextLength;

            richTextBox.ScrollToCaret();
        }
        public void Work_Status(Status now)  //判定工作狀態，並依其做出相對應的設定
        {
            switch (now)
            {
                case Status.NO_COM:
                    break;
                case Status.DIS_COM:
                    button_dis_com.Enabled = false;
                    button_get_value.Enabled = false;
                    button_drawing.Enabled = false;
                    button_osc.Enabled = false;
                    button_matlab.Enabled = false;
                    button_start_com.Enabled = true;
                    break;
                case Status.NOKNOWN_SENSER:
                    break;
                case Status.PRE_START:
                    button_dis_com.Enabled = false;
                    button_drawing.Enabled = false;
                    button_get_value.Enabled = false;
                    button_osc.Enabled = false;
                    button_matlab.Enabled = false;
                    button_drawing.Enabled = false;
                    button_save_file.Enabled = false;
                    richTextBox.Visible = false;
                    radioButton_Acc.Enabled = false;
                    radioButton_Acc.Checked = true;
                    radioButton_Gy.Enabled = false;
                    radioButton_Gy.Checked = false;
                    chart_osc.Visible = false;
                    break;
                case Status.GET_VALUE:
                    richTextBox.Visible = true;
                    button_osc.Enabled = false;
                    timer1.Enabled = true;
                    button_get_value.Enabled = false;
                    button_matlab.Enabled = true;
                    button_drawing.Enabled = true;
                    button_osc.Enabled = true;
                    break;
                case Status.NO_DATA:
                    break;
                case Status.STOP_GET_VALUE:
                    break;
                case Status.SUSS_COM:
                    button_start_com.Enabled = false;
                    button_dis_com.Enabled = true;
                    button_get_value.Enabled = true;
                    radioButton_Acc.Enabled = true;
                    radioButton_Gy.Enabled = true;
                    radioButton_Acc.Checked = true;
                    button_save_file.Enabled = true;
                    break;
                case Status.OPEN_FILE:
                    richTextBox.Visible = true;
                    button_drawing.Enabled = true;
                    button_osc.Enabled = true;
                    button_matlab.Enabled = true;
                    radioButton_Acc.Enabled = true;
                    radioButton_Gy.Enabled = true;
                    button_save_file.Enabled = true;
                    break;

            }
        }
    }
}
