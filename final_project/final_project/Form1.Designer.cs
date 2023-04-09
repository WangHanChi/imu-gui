using System.Drawing;
using Osc;
using System.Collections.Generic;
using System;
using MathWorks.MATLAB.NET.Arrays; //在MWArray.dll中，最常用的
using MathWorks.MATLAB.NET.Utility;
using c130;

namespace final_project
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Graphics g;
        private Display CurDisplay;
        private List<Object> ALL;
        double CurrentTime;
        double timercount;
        double time;
        int num ;
        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.serialPortArduino = new System.IO.Ports.SerialPort(this.components);
            this.label_serialport = new System.Windows.Forms.Label();
            this.comboBox_com = new System.Windows.Forms.ComboBox();
            this.label_hint1 = new System.Windows.Forms.Label();
            this.button_recom = new System.Windows.Forms.Button();
            this.label_display_status = new System.Windows.Forms.Label();
            this.button_start_com = new System.Windows.Forms.Button();
            this.chart_osc = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox_display = new System.Windows.Forms.GroupBox();
            this.label_temp_value = new System.Windows.Forms.Label();
            this.label_temp = new System.Windows.Forms.Label();
            this.label_gyz = new System.Windows.Forms.Label();
            this.label_Gy_z = new System.Windows.Forms.Label();
            this.label_gyy = new System.Windows.Forms.Label();
            this.label_Gy_y = new System.Windows.Forms.Label();
            this.label_gyx = new System.Windows.Forms.Label();
            this.label_Gy_x = new System.Windows.Forms.Label();
            this.label_gy_all = new System.Windows.Forms.Label();
            this.label_accz = new System.Windows.Forms.Label();
            this.label_Acc_z = new System.Windows.Forms.Label();
            this.label_accy = new System.Windows.Forms.Label();
            this.label_Acc_y = new System.Windows.Forms.Label();
            this.label_accx = new System.Windows.Forms.Label();
            this.label_Acc_x = new System.Windows.Forms.Label();
            this.label_acc_all = new System.Windows.Forms.Label();
            this.panel_drawing = new System.Windows.Forms.Panel();
            this.button_dis_com = new System.Windows.Forms.Button();
            this.button_get_value = new System.Windows.Forms.Button();
            this.button_matlab = new System.Windows.Forms.Button();
            this.button_drawing = new System.Windows.Forms.Button();
            this.button_osc = new System.Windows.Forms.Button();
            this.backgroundWorkerOffline = new System.ComponentModel.BackgroundWorker();
            this.groupBox_check = new System.Windows.Forms.GroupBox();
            this.radioButton_Gy = new System.Windows.Forms.RadioButton();
            this.radioButton_Acc = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_open_file = new System.Windows.Forms.Button();
            this.button_save_file = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.backgroundWorkerMatlab = new System.ComponentModel.BackgroundWorker();
            this.groupBox_3d = new System.Windows.Forms.GroupBox();
            this.radioButton_no = new System.Windows.Forms.RadioButton();
            this.radioButton_yes = new System.Windows.Forms.RadioButton();
            this.groupBox_button = new System.Windows.Forms.GroupBox();
            this.labelrefresh = new System.Windows.Forms.Label();
            this.label_speak = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_osc)).BeginInit();
            this.groupBox_display.SuspendLayout();
            this.groupBox_check.SuspendLayout();
            this.groupBox_3d.SuspendLayout();
            this.groupBox_button.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPortArduino
            // 
            this.serialPortArduino.BaudRate = 115200;
            this.serialPortArduino.DtrEnable = true;
            this.serialPortArduino.RtsEnable = true;
            // 
            // label_serialport
            // 
            this.label_serialport.AutoSize = true;
            this.label_serialport.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_serialport.Location = new System.Drawing.Point(48, 12);
            this.label_serialport.Name = "label_serialport";
            this.label_serialport.Size = new System.Drawing.Size(117, 28);
            this.label_serialport.TabIndex = 0;
            this.label_serialport.Text = "序列埠 : ";
            // 
            // comboBox_com
            // 
            this.comboBox_com.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_com.FormattingEnabled = true;
            this.comboBox_com.Location = new System.Drawing.Point(190, 13);
            this.comboBox_com.Name = "comboBox_com";
            this.comboBox_com.Size = new System.Drawing.Size(121, 31);
            this.comboBox_com.TabIndex = 1;
            this.comboBox_com.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label_hint1
            // 
            this.label_hint1.AutoSize = true;
            this.label_hint1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_hint1.Location = new System.Drawing.Point(49, 53);
            this.label_hint1.Name = "label_hint1";
            this.label_hint1.Size = new System.Drawing.Size(309, 20);
            this.label_hint1.TabIndex = 2;
            this.label_hint1.Text = "若沒找到該序列埠，請按重整按鈕";
            // 
            // button_recom
            // 
            this.button_recom.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_recom.Location = new System.Drawing.Point(381, 73);
            this.button_recom.Name = "button_recom";
            this.button_recom.Size = new System.Drawing.Size(113, 38);
            this.button_recom.TabIndex = 3;
            this.button_recom.Text = "重整";
            this.button_recom.UseVisualStyleBackColor = true;
            this.button_recom.Click += new System.EventHandler(this.button_recom_Click);
            // 
            // label_display_status
            // 
            this.label_display_status.AutoSize = true;
            this.label_display_status.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_display_status.Location = new System.Drawing.Point(48, 124);
            this.label_display_status.Name = "label_display_status";
            this.label_display_status.Size = new System.Drawing.Size(217, 30);
            this.label_display_status.TabIndex = 4;
            this.label_display_status.Text = "顯示連線狀態 : ";
            // 
            // button_start_com
            // 
            this.button_start_com.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_start_com.Location = new System.Drawing.Point(28, 30);
            this.button_start_com.Name = "button_start_com";
            this.button_start_com.Size = new System.Drawing.Size(97, 43);
            this.button_start_com.TabIndex = 5;
            this.button_start_com.Text = "連線";
            this.button_start_com.UseVisualStyleBackColor = true;
            this.button_start_com.Click += new System.EventHandler(this.button_start_com_Click);
            // 
            // chart_osc
            // 
            chartArea1.AxisX.Interval = 5D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.ScaleView.Size = 20D;
            chartArea1.AxisX.Title = "時間(單位 : s)";
            chartArea1.AxisY.Maximum = 5D;
            chartArea1.AxisY.Minimum = -5D;
            chartArea1.AxisY.Title = "加速度(單位:  G)";
            chartArea1.Name = "ChartArea1";
            chartArea2.AxisX.Interval = 5D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.Title = "時間(單位 : s)";
            chartArea2.AxisY.Maximum = 300D;
            chartArea2.AxisY.Minimum = -300D;
            chartArea2.AxisY.Title = "角速度(單位 : degrees/s)";
            chartArea2.Name = "ChartArea2";
            this.chart_osc.ChartAreas.Add(chartArea1);
            this.chart_osc.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend2";
            this.chart_osc.Legends.Add(legend1);
            this.chart_osc.Location = new System.Drawing.Point(30, 530);
            this.chart_osc.Name = "chart_osc";
            series1.BorderWidth = 4;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend2";
            series1.Name = "Acc_x";
            series2.BorderWidth = 4;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend2";
            series2.Name = "Acc_y";
            series3.BorderWidth = 4;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend2";
            series3.Name = "Acc_z";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea2";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend2";
            series4.Name = "Gy_x";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea2";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend2";
            series5.Name = "Gy_y";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea2";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend2";
            series6.Name = "Gy_z";
            this.chart_osc.Series.Add(series1);
            this.chart_osc.Series.Add(series2);
            this.chart_osc.Series.Add(series3);
            this.chart_osc.Series.Add(series4);
            this.chart_osc.Series.Add(series5);
            this.chart_osc.Series.Add(series6);
            this.chart_osc.Size = new System.Drawing.Size(1363, 300);
            this.chart_osc.TabIndex = 11;
            this.chart_osc.Text = "chart1";
            title1.Name = "title_Acc";
            title1.Text = "三軸加速度波形圖";
            title1.Visible = false;
            title2.Name = "title_Gy";
            title2.Text = "三軸陀螺儀波形圖";
            title2.Visible = false;
            this.chart_osc.Titles.Add(title1);
            this.chart_osc.Titles.Add(title2);
            // 
            // groupBox_display
            // 
            this.groupBox_display.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox_display.Controls.Add(this.label_temp_value);
            this.groupBox_display.Controls.Add(this.label_temp);
            this.groupBox_display.Controls.Add(this.label_gyz);
            this.groupBox_display.Controls.Add(this.label_Gy_z);
            this.groupBox_display.Controls.Add(this.label_gyy);
            this.groupBox_display.Controls.Add(this.label_Gy_y);
            this.groupBox_display.Controls.Add(this.label_gyx);
            this.groupBox_display.Controls.Add(this.label_Gy_x);
            this.groupBox_display.Controls.Add(this.label_gy_all);
            this.groupBox_display.Controls.Add(this.label_accz);
            this.groupBox_display.Controls.Add(this.label_Acc_z);
            this.groupBox_display.Controls.Add(this.label_accy);
            this.groupBox_display.Controls.Add(this.label_Acc_y);
            this.groupBox_display.Controls.Add(this.label_accx);
            this.groupBox_display.Controls.Add(this.label_Acc_x);
            this.groupBox_display.Controls.Add(this.label_acc_all);
            this.groupBox_display.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_display.Location = new System.Drawing.Point(571, 12);
            this.groupBox_display.Name = "groupBox_display";
            this.groupBox_display.Size = new System.Drawing.Size(200, 501);
            this.groupBox_display.TabIndex = 12;
            this.groupBox_display.TabStop = false;
            this.groupBox_display.Text = "詳細資料顯示";
            // 
            // label_temp_value
            // 
            this.label_temp_value.AutoSize = true;
            this.label_temp_value.Location = new System.Drawing.Point(27, 442);
            this.label_temp_value.Name = "label_temp_value";
            this.label_temp_value.Size = new System.Drawing.Size(89, 20);
            this.label_temp_value.TabIndex = 20;
            this.label_temp_value.Text = "尚無資料";
            // 
            // label_temp
            // 
            this.label_temp.AutoSize = true;
            this.label_temp.Location = new System.Drawing.Point(27, 393);
            this.label_temp.Name = "label_temp";
            this.label_temp.Size = new System.Drawing.Size(64, 20);
            this.label_temp.TabIndex = 19;
            this.label_temp.Text = "溫度 : ";
            // 
            // label_gyz
            // 
            this.label_gyz.AutoSize = true;
            this.label_gyz.Location = new System.Drawing.Point(101, 359);
            this.label_gyz.Name = "label_gyz";
            this.label_gyz.Size = new System.Drawing.Size(89, 20);
            this.label_gyz.TabIndex = 18;
            this.label_gyz.Text = "尚無資料";
            // 
            // label_Gy_z
            // 
            this.label_Gy_z.AutoSize = true;
            this.label_Gy_z.Location = new System.Drawing.Point(17, 359);
            this.label_Gy_z.Name = "label_Gy_z";
            this.label_Gy_z.Size = new System.Drawing.Size(59, 20);
            this.label_Gy_z.TabIndex = 17;
            this.label_Gy_z.Text = "Gy_z :";
            // 
            // label_gyy
            // 
            this.label_gyy.AutoSize = true;
            this.label_gyy.Location = new System.Drawing.Point(101, 320);
            this.label_gyy.Name = "label_gyy";
            this.label_gyy.Size = new System.Drawing.Size(89, 20);
            this.label_gyy.TabIndex = 16;
            this.label_gyy.Text = "尚無資料";
            // 
            // label_Gy_y
            // 
            this.label_Gy_y.AutoSize = true;
            this.label_Gy_y.Location = new System.Drawing.Point(17, 320);
            this.label_Gy_y.Name = "label_Gy_y";
            this.label_Gy_y.Size = new System.Drawing.Size(65, 20);
            this.label_Gy_y.TabIndex = 15;
            this.label_Gy_y.Text = "Gy_y : ";
            // 
            // label_gyx
            // 
            this.label_gyx.AutoSize = true;
            this.label_gyx.Location = new System.Drawing.Point(101, 272);
            this.label_gyx.Name = "label_gyx";
            this.label_gyx.Size = new System.Drawing.Size(89, 20);
            this.label_gyx.TabIndex = 14;
            this.label_gyx.Text = "尚無資料";
            // 
            // label_Gy_x
            // 
            this.label_Gy_x.AutoSize = true;
            this.label_Gy_x.Location = new System.Drawing.Point(17, 272);
            this.label_Gy_x.Name = "label_Gy_x";
            this.label_Gy_x.Size = new System.Drawing.Size(65, 20);
            this.label_Gy_x.TabIndex = 13;
            this.label_Gy_x.Text = "Gy_x : ";
            // 
            // label_gy_all
            // 
            this.label_gy_all.AutoSize = true;
            this.label_gy_all.Location = new System.Drawing.Point(27, 225);
            this.label_gy_all.Name = "label_gy_all";
            this.label_gy_all.Size = new System.Drawing.Size(104, 20);
            this.label_gy_all.TabIndex = 7;
            this.label_gy_all.Text = "陀螺儀值 : ";
            // 
            // label_accz
            // 
            this.label_accz.AutoSize = true;
            this.label_accz.Location = new System.Drawing.Point(95, 178);
            this.label_accz.Name = "label_accz";
            this.label_accz.Size = new System.Drawing.Size(89, 20);
            this.label_accz.TabIndex = 6;
            this.label_accz.Text = "尚無資料";
            // 
            // label_Acc_z
            // 
            this.label_Acc_z.AutoSize = true;
            this.label_Acc_z.Location = new System.Drawing.Point(17, 178);
            this.label_Acc_z.Name = "label_Acc_z";
            this.label_Acc_z.Size = new System.Drawing.Size(71, 20);
            this.label_Acc_z.TabIndex = 5;
            this.label_Acc_z.Text = "Acc_z : ";
            // 
            // label_accy
            // 
            this.label_accy.AutoSize = true;
            this.label_accy.Location = new System.Drawing.Point(95, 136);
            this.label_accy.Name = "label_accy";
            this.label_accy.Size = new System.Drawing.Size(89, 20);
            this.label_accy.TabIndex = 4;
            this.label_accy.Text = "尚無資料";
            // 
            // label_Acc_y
            // 
            this.label_Acc_y.AutoSize = true;
            this.label_Acc_y.Location = new System.Drawing.Point(17, 136);
            this.label_Acc_y.Name = "label_Acc_y";
            this.label_Acc_y.Size = new System.Drawing.Size(72, 20);
            this.label_Acc_y.TabIndex = 3;
            this.label_Acc_y.Text = "Acc_y : ";
            // 
            // label_accx
            // 
            this.label_accx.AutoSize = true;
            this.label_accx.Location = new System.Drawing.Point(95, 87);
            this.label_accx.Name = "label_accx";
            this.label_accx.Size = new System.Drawing.Size(89, 20);
            this.label_accx.TabIndex = 2;
            this.label_accx.Text = "尚無資料";
            // 
            // label_Acc_x
            // 
            this.label_Acc_x.AutoSize = true;
            this.label_Acc_x.Location = new System.Drawing.Point(17, 87);
            this.label_Acc_x.Name = "label_Acc_x";
            this.label_Acc_x.Size = new System.Drawing.Size(72, 20);
            this.label_Acc_x.TabIndex = 1;
            this.label_Acc_x.Text = "Acc_x : ";
            // 
            // label_acc_all
            // 
            this.label_acc_all.AutoSize = true;
            this.label_acc_all.Location = new System.Drawing.Point(17, 41);
            this.label_acc_all.Name = "label_acc_all";
            this.label_acc_all.Size = new System.Drawing.Size(124, 20);
            this.label_acc_all.TabIndex = 0;
            this.label_acc_all.Text = "三軸加速度 : ";
            // 
            // panel_drawing
            // 
            this.panel_drawing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_drawing.Location = new System.Drawing.Point(806, 12);
            this.panel_drawing.Name = "panel_drawing";
            this.panel_drawing.Size = new System.Drawing.Size(550, 500);
            this.panel_drawing.TabIndex = 13;
            this.panel_drawing.Visible = false;
            this.panel_drawing.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_drawing_Paint);
            this.panel_drawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_drawing_MouseDown);
            // 
            // button_dis_com
            // 
            this.button_dis_com.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_dis_com.Location = new System.Drawing.Point(174, 30);
            this.button_dis_com.Name = "button_dis_com";
            this.button_dis_com.Size = new System.Drawing.Size(97, 43);
            this.button_dis_com.TabIndex = 14;
            this.button_dis_com.Text = "斷線";
            this.button_dis_com.UseVisualStyleBackColor = true;
            this.button_dis_com.Click += new System.EventHandler(this.button_dis_com_Click);
            // 
            // button_get_value
            // 
            this.button_get_value.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_get_value.Location = new System.Drawing.Point(28, 91);
            this.button_get_value.Name = "button_get_value";
            this.button_get_value.Size = new System.Drawing.Size(97, 43);
            this.button_get_value.TabIndex = 15;
            this.button_get_value.Text = "取值";
            this.button_get_value.UseVisualStyleBackColor = true;
            this.button_get_value.Click += new System.EventHandler(this.button_get_value_Click);
            // 
            // button_matlab
            // 
            this.button_matlab.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_matlab.Location = new System.Drawing.Point(174, 91);
            this.button_matlab.Name = "button_matlab";
            this.button_matlab.Size = new System.Drawing.Size(97, 43);
            this.button_matlab.TabIndex = 16;
            this.button_matlab.Text = "3D圖";
            this.button_matlab.UseVisualStyleBackColor = true;
            this.button_matlab.Click += new System.EventHandler(this.button_matlab_Click);
            // 
            // button_drawing
            // 
            this.button_drawing.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_drawing.Location = new System.Drawing.Point(28, 162);
            this.button_drawing.Name = "button_drawing";
            this.button_drawing.Size = new System.Drawing.Size(97, 43);
            this.button_drawing.TabIndex = 17;
            this.button_drawing.Text = "畫圖";
            this.button_drawing.UseVisualStyleBackColor = true;
            this.button_drawing.Click += new System.EventHandler(this.button_drawing_Click);
            // 
            // button_osc
            // 
            this.button_osc.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_osc.Location = new System.Drawing.Point(174, 162);
            this.button_osc.Name = "button_osc";
            this.button_osc.Size = new System.Drawing.Size(97, 43);
            this.button_osc.TabIndex = 18;
            this.button_osc.Text = "示波器";
            this.button_osc.UseVisualStyleBackColor = true;
            this.button_osc.Click += new System.EventHandler(this.button_osc_Click);
            // 
            // backgroundWorkerOffline
            // 
            this.backgroundWorkerOffline.WorkerReportsProgress = true;
            this.backgroundWorkerOffline.WorkerSupportsCancellation = true;
            this.backgroundWorkerOffline.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // groupBox_check
            // 
            this.groupBox_check.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox_check.Controls.Add(this.radioButton_Gy);
            this.groupBox_check.Controls.Add(this.radioButton_Acc);
            this.groupBox_check.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_check.Location = new System.Drawing.Point(268, 412);
            this.groupBox_check.Name = "groupBox_check";
            this.groupBox_check.Size = new System.Drawing.Size(218, 100);
            this.groupBox_check.TabIndex = 21;
            this.groupBox_check.TabStop = false;
            this.groupBox_check.Text = "請選擇Chart想顯示";
            // 
            // radioButton_Gy
            // 
            this.radioButton_Gy.AutoSize = true;
            this.radioButton_Gy.Location = new System.Drawing.Point(17, 61);
            this.radioButton_Gy.Name = "radioButton_Gy";
            this.radioButton_Gy.Size = new System.Drawing.Size(55, 24);
            this.radioButton_Gy.TabIndex = 1;
            this.radioButton_Gy.Text = "Gy";
            this.radioButton_Gy.UseVisualStyleBackColor = true;
            // 
            // radioButton_Acc
            // 
            this.radioButton_Acc.AutoSize = true;
            this.radioButton_Acc.Checked = true;
            this.radioButton_Acc.Location = new System.Drawing.Point(17, 31);
            this.radioButton_Acc.Name = "radioButton_Acc";
            this.radioButton_Acc.Size = new System.Drawing.Size(63, 24);
            this.radioButton_Acc.TabIndex = 0;
            this.radioButton_Acc.TabStop = true;
            this.radioButton_Acc.Text = "Acc";
            this.radioButton_Acc.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_open_file
            // 
            this.button_open_file.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_open_file.Location = new System.Drawing.Point(328, 30);
            this.button_open_file.Name = "button_open_file";
            this.button_open_file.Size = new System.Drawing.Size(97, 43);
            this.button_open_file.TabIndex = 22;
            this.button_open_file.Text = "讀檔";
            this.button_open_file.UseVisualStyleBackColor = true;
            this.button_open_file.Click += new System.EventHandler(this.button_open_file_Click);
            // 
            // button_save_file
            // 
            this.button_save_file.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_save_file.Location = new System.Drawing.Point(328, 91);
            this.button_save_file.Name = "button_save_file";
            this.button_save_file.Size = new System.Drawing.Size(97, 43);
            this.button_save_file.TabIndex = 23;
            this.button_save_file.Text = "存檔";
            this.button_save_file.UseVisualStyleBackColor = true;
            this.button_save_file.Click += new System.EventHandler(this.button_save_file_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(1392, 12);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox.Size = new System.Drawing.Size(498, 500);
            this.richTextBox.TabIndex = 24;
            this.richTextBox.Text = "";
            this.richTextBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            // 
            // backgroundWorkerMatlab
            // 
            this.backgroundWorkerMatlab.WorkerReportsProgress = true;
            this.backgroundWorkerMatlab.WorkerSupportsCancellation = true;
            this.backgroundWorkerMatlab.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // groupBox_3d
            // 
            this.groupBox_3d.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox_3d.Controls.Add(this.radioButton_no);
            this.groupBox_3d.Controls.Add(this.radioButton_yes);
            this.groupBox_3d.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_3d.Location = new System.Drawing.Point(40, 413);
            this.groupBox_3d.Name = "groupBox_3d";
            this.groupBox_3d.Size = new System.Drawing.Size(206, 100);
            this.groupBox_3d.TabIndex = 22;
            this.groupBox_3d.TabStop = false;
            this.groupBox_3d.Text = "是否要3D圖";
            this.groupBox_3d.Visible = false;
            // 
            // radioButton_no
            // 
            this.radioButton_no.AutoSize = true;
            this.radioButton_no.Location = new System.Drawing.Point(17, 61);
            this.radioButton_no.Name = "radioButton_no";
            this.radioButton_no.Size = new System.Drawing.Size(50, 24);
            this.radioButton_no.TabIndex = 1;
            this.radioButton_no.TabStop = true;
            this.radioButton_no.Text = "no";
            this.radioButton_no.UseVisualStyleBackColor = true;
            // 
            // radioButton_yes
            // 
            this.radioButton_yes.AutoSize = true;
            this.radioButton_yes.Location = new System.Drawing.Point(17, 31);
            this.radioButton_yes.Name = "radioButton_yes";
            this.radioButton_yes.Size = new System.Drawing.Size(57, 24);
            this.radioButton_yes.TabIndex = 0;
            this.radioButton_yes.TabStop = true;
            this.radioButton_yes.Text = "yes";
            this.radioButton_yes.UseVisualStyleBackColor = true;
            this.radioButton_yes.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // groupBox_button
            // 
            this.groupBox_button.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox_button.Controls.Add(this.button_start_com);
            this.groupBox_button.Controls.Add(this.button_dis_com);
            this.groupBox_button.Controls.Add(this.button_open_file);
            this.groupBox_button.Controls.Add(this.button_save_file);
            this.groupBox_button.Controls.Add(this.button_osc);
            this.groupBox_button.Controls.Add(this.button_get_value);
            this.groupBox_button.Controls.Add(this.button_drawing);
            this.groupBox_button.Controls.Add(this.button_matlab);
            this.groupBox_button.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_button.Location = new System.Drawing.Point(40, 175);
            this.groupBox_button.Name = "groupBox_button";
            this.groupBox_button.Size = new System.Drawing.Size(446, 232);
            this.groupBox_button.TabIndex = 25;
            this.groupBox_button.TabStop = false;
            this.groupBox_button.Text = "按鈕區";
            // 
            // labelrefresh
            // 
            this.labelrefresh.AutoSize = true;
            this.labelrefresh.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelrefresh.Location = new System.Drawing.Point(49, 83);
            this.labelrefresh.Name = "labelrefresh";
            this.labelrefresh.Size = new System.Drawing.Size(274, 20);
            this.labelrefresh.TabIndex = 28;
            this.labelrefresh.Text = "若需重新載入form1也按下重整";
            // 
            // label_speak
            // 
            this.label_speak.AutoSize = true;
            this.label_speak.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_speak.Location = new System.Drawing.Point(345, 20);
            this.label_speak.Name = "label_speak";
            this.label_speak.Size = new System.Drawing.Size(167, 20);
            this.label_speak.TabIndex = 29;
            this.label_speak.Text = "請縮放到全螢幕!!!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.label_speak);
            this.Controls.Add(this.labelrefresh);
            this.Controls.Add(this.groupBox_button);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.groupBox_3d);
            this.Controls.Add(this.groupBox_check);
            this.Controls.Add(this.panel_drawing);
            this.Controls.Add(this.groupBox_display);
            this.Controls.Add(this.chart_osc);
            this.Controls.Add(this.label_display_status);
            this.Controls.Add(this.button_recom);
            this.Controls.Add(this.label_hint1);
            this.Controls.Add(this.comboBox_com);
            this.Controls.Add(this.label_serialport);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_osc)).EndInit();
            this.groupBox_display.ResumeLayout(false);
            this.groupBox_display.PerformLayout();
            this.groupBox_check.ResumeLayout(false);
            this.groupBox_check.PerformLayout();
            this.groupBox_3d.ResumeLayout(false);
            this.groupBox_3d.PerformLayout();
            this.groupBox_button.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPortArduino;
        private System.Windows.Forms.Label label_serialport;
        private System.Windows.Forms.ComboBox comboBox_com;
        private System.Windows.Forms.Label label_hint1;
        private System.Windows.Forms.Button button_recom;
        private System.Windows.Forms.Label label_display_status;
        private System.Windows.Forms.Button button_start_com;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_osc;
        private System.Windows.Forms.GroupBox groupBox_display;
        private System.Windows.Forms.Label label_temp_value;
        private System.Windows.Forms.Label label_temp;
        private System.Windows.Forms.Label label_gyz;
        private System.Windows.Forms.Label label_Gy_z;
        private System.Windows.Forms.Label label_gyy;
        private System.Windows.Forms.Label label_Gy_y;
        private System.Windows.Forms.Label label_gyx;
        private System.Windows.Forms.Label label_Gy_x;
        private System.Windows.Forms.Label label_gy_all;
        private System.Windows.Forms.Label label_accz;
        private System.Windows.Forms.Label label_Acc_z;
        private System.Windows.Forms.Label label_accy;
        private System.Windows.Forms.Label label_Acc_y;
        private System.Windows.Forms.Label label_accx;
        private System.Windows.Forms.Label label_Acc_x;
        private System.Windows.Forms.Label label_acc_all;
        private System.Windows.Forms.Panel panel_drawing;
        private System.Windows.Forms.Button button_dis_com;
        private System.Windows.Forms.Button button_get_value;
        private System.Windows.Forms.Button button_matlab;
        private System.Windows.Forms.Button button_drawing;
        private System.Windows.Forms.Button button_osc;
        private System.ComponentModel.BackgroundWorker backgroundWorkerOffline;
        private System.Windows.Forms.GroupBox groupBox_check;
        private System.Windows.Forms.RadioButton radioButton_Gy;
        private System.Windows.Forms.RadioButton radioButton_Acc;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_open_file;
        private System.Windows.Forms.Button button_save_file;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMatlab;
        private System.Windows.Forms.GroupBox groupBox_3d;
        private System.Windows.Forms.RadioButton radioButton_no;
        private System.Windows.Forms.RadioButton radioButton_yes;
        private System.Windows.Forms.GroupBox groupBox_button;
        private System.Windows.Forms.Label labelrefresh;
        private System.Windows.Forms.Label label_speak;
    }
}

