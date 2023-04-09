using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Drawing.Drawing2D;

namespace Osc
{
    public enum Status 
    {
        NO_COM = 0,             //沒有連線
        DIS_COM = 1,            //連線失敗
        NOKNOWN_SENSER = 2,     //未知的感測器
        PRE_START = 3,          //尚未連線
        GET_VALUE = 4,          //取值中
        NO_DATA = 5,            //無資料
        STOP_GET_VALUE = 6,     //斷線
        SUSS_COM = 7,           //成功連線
        OPEN_FILE = 8,          //讀檔
    }

    public enum Errorcodes
    { 
        NO_COM = 0, //沒有連線(讀不到com)
        COＭ_SUSS = 1, //成功連線
        COM_FAL = 2,  //連線失敗
        INIT = 3, //初始化
        NONE = 4, 
    }

    public enum Section
    { 
        ACC = 0, //加速度
        GY = 1, //陀螺儀
        TEMP = 2, //溫度
        INIT = 3  //初始化
    }

    public class Data
    {
        public double Data_count;
        public Graphics g;
        public Point Panel_Center;
        public Point X_Axis_Start;
        public Point X_Axis_End;
        public Point X_Label;
        public Point X_Value;
        public Point Y_Axis_Start;
        public Point Y_Axis_End;
        public Point Y_Label;
        public Point Y_Value;
        public Point Z_Axis_start;
        public Point Z_Axis_end;
        public Point Z_Label;
        public Point Z_Value;

        public Data()
        {
            
            Panel_Center = new Point(200, 200);
            X_Axis_Start = new Point(0, 160);
            X_Axis_End = new Point(400, 240);
            X_Label = new Point(320, 260);
            X_Value = new Point(320, 285);
            Y_Axis_Start = new Point(300, 0);
            Y_Axis_End = new Point(100, 400);
            Y_Label = new Point(60, 300);
            Y_Value = new Point(60, 325);
            Z_Axis_start = new Point(200, 0);
            Z_Axis_end = new Point(200, 400);
            Z_Label = new Point(110, 40);
            Z_Value = new Point(110, 65);
        }
        virtual public void DrawAxis( string x, string y,  string z, Graphics g, int foo) 
        {
            //劃出基本坐標軸
            SolidBrush solidBrush1 = new SolidBrush(Color.Red);
            SolidBrush solidBrush2 = new SolidBrush(Color.Green);
            SolidBrush solidBrush3 = new SolidBrush(Color.Blue);
            SolidBrush solidBrush4 = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.Black, 3);
            Font Drawfont = new Font("Arial", 14);
            if (foo == 1)
            {
                g.DrawLine(pen, Panel_Center, X_Axis_Start);
                g.DrawLine(pen, Panel_Center, X_Axis_End);
                g.DrawLine(pen, Panel_Center, Y_Axis_Start);
                g.DrawLine(pen, Panel_Center, Y_Axis_End);
                g.DrawLine(pen, Panel_Center, Z_Axis_start);
                g.DrawLine(pen, Panel_Center, Z_Axis_end);

                g.DrawString("X_Axis", Drawfont, solidBrush1, X_Label.X, X_Label.Y);
                g.DrawString("Y_Axis", Drawfont, solidBrush2, Y_Label.X, Y_Label.Y);
                g.DrawString("Z_Axis", Drawfont, solidBrush3, Z_Label.X, Z_Label.Y);
                g.FillEllipse(solidBrush4, Panel_Center.X - 20, Panel_Center.Y - 20, 35, 35);
            }
            else if (foo == 2)
            {
                Pen pen_x = new Pen(Color.Red, 2);
                Pen pen_y = new Pen(Color.Green, 2);
                Pen pen_z = new Pen(Color.Blue, 2);
                g.DrawEllipse(pen, 80, 175, 240, 50);
                g.DrawEllipse(pen, 80, 50, 240, 300);
                g.DrawEllipse(pen, 175, 50, 50, 300);

                g.DrawLine(pen_x, 70, 200, 330, 200);
                g.DrawLine(pen_y, 300, 100, 100, 300);
                g.DrawLine(pen_z, 200, 50, 200, 350);

                g.DrawString("X_Axis", Drawfont, solidBrush1, X_Label.X - 90, X_Label.Y - 30);
                g.DrawString("Y_Axis", Drawfont, solidBrush2, Y_Label.X - 20, Y_Label.Y);
                g.DrawString("Z_Axis", Drawfont, solidBrush3, Z_Label.X, Z_Label.Y + 80);
                
                
            }
            g.FillRectangle(solidBrush3, 0, 0, 50, 30);
            g.DrawString("截圖", Drawfont, solidBrush1, 10, 40);
        }
    }

    public class Acc : Data
    {
        public double Acc_x;
        public double Acc_y;
        public double Acc_z;

        public Acc() { }

        public Acc(double acc_x, double acc_y, double acc_z)
        { 
            this.Acc_x = acc_x;
            this.Acc_y = acc_y;
            this.Acc_z = acc_z;
            
        }

        public override void DrawAxis(string x, string y, string z, Graphics g, int foo)
        {
            Pen penX = new Pen(Color.Red, 8);
            Pen penY = new Pen(Color.Green, 8);
            Pen penZ = new Pen(Color.Blue, 8);
            SolidBrush solidBrush1 = new SolidBrush(Color.Red);
            SolidBrush solidBrush2 = new SolidBrush(Color.Green);
            SolidBrush solidBrush3 = new SolidBrush(Color.Blue);
            Font Drawfont = new Font("Arial", 14);
            Pen pen = new Pen(Color.Black, 3);
            if (foo != 1) return;
            if (x != "尚無資料" && y != "尚無資料" && z != "尚無資料")
            {
                double length_x = (Convert.ToDouble(x) / 5) * 204  * 4;
                double length_y = (Convert.ToDouble(y) / 5) * 240  * 4;
                double length_z = (Convert.ToDouble(z) / 5) * 200  * 3 ;

                Point Acc_x = new Point((int)(length_x * Math.Cos(11.3 * Math.PI /180)), (int)(length_x * Math.Sin(11.3 * Math.PI / 180)));
                Point Acc_y = new Point( - (int)(length_y * Math.Sin(26.57 * Math.PI / 180)),  (int)(length_y * Math.Cos(26.57 * Math.PI / 180)));
                Point Acc_z = new Point((0), (int)(- length_z));

                g.DrawLine(penX, Panel_Center.X, Panel_Center.Y, Panel_Center.X + Acc_x.X, Panel_Center.Y + Acc_x.Y);
                g.DrawLine(penY, Panel_Center.X, Panel_Center.Y, Panel_Center.X + Acc_y.X, Panel_Center.Y + Acc_y.Y);
                g.DrawLine(penZ, Panel_Center.X, Panel_Center.Y, Panel_Center.X + Acc_z.X, Panel_Center.Y + Acc_z.Y);
                g.DrawString(x, Drawfont, solidBrush1, X_Value.X, X_Value.Y);
                g.DrawString(y, Drawfont, solidBrush2, Y_Value.X, Y_Value.Y);
                g.DrawString(z, Drawfont, solidBrush3, Z_Value.X, Z_Value.Y);
            }

        }
    }

    public class Gy : Data
    { 
        public double Gy_x;
        public double Gy_y;
        public double Gy_z;

        public Gy()
        { 
        
        }
        public Gy(double gy_x, double gy_y, double gy_z, Graphics gIn)
        { 
            this.Gy_x = gy_x;
            this.Gy_y = gy_y;
            this.Gy_z = gy_z;
            this.g = gIn;
            
        }

        public override void DrawAxis(string x, string y, string z, Graphics g, int foo)
        {
            Pen penX = new Pen(Color.Red, 8);
            Pen penY = new Pen(Color.Green, 8);
            Pen penZ = new Pen(Color.Blue, 8);
            SolidBrush solidBrush1 = new SolidBrush(Color.Red);
            SolidBrush solidBrush2 = new SolidBrush(Color.Green);
            SolidBrush solidBrush3 = new SolidBrush(Color.Blue);
            Font Drawfont = new Font("Arial", 14);
            Pen pen = new Pen(Color.Black, 3);
            if (foo != 2) return;
            if (x != "尚無資料" && y != "尚無資料" && z != "尚無資料")
            {
                double angle_x = Convert.ToDouble(x) ;
                double angle_y = Convert.ToDouble(y) ;
                double angle_z = Convert.ToDouble(z);

                g.DrawArc(penX, 80, 175, 240, 50, 0, (int)angle_x );
                g.DrawArc(penY, 80, 50, 240, 300, 0, (int)angle_y );
                g.DrawArc(penZ, 175, 50, 50, 300, 0, (int)angle_z );
                g.DrawString(x, Drawfont, solidBrush1, X_Value.X - 90, X_Value.Y - 30);
                g.DrawString(y, Drawfont, solidBrush2, Y_Value.X - 20, Y_Value.Y);
                g.DrawString(z, Drawfont, solidBrush3, Z_Value.X, Z_Value.Y + 80);
            }
        }
    }

    public class Temp : Data
    {
        public double Temperature;
        public double Temp_count;
        public Temp(double temp)
        { 
            this.Temperature = temp;
        }

    }

    public class Display
    {
        private Graphics g;
        public List<object> Entity = new List<object>();

        public Display(Graphics gIn)
        { 
            g = gIn;
        }

        public Errorcodes SaveData(string line) 
        {
            String[] Piecewise;
            String[] Piecewise_count;
            
            double Count;
            Section section = Section.INIT;

            if (line.ToUpper().Contains("ACCELERATION"))
            {
                section = Section.ACC;
                
            }
            else if (line.ToUpper().Contains("GYROSCOPE"))
            {
                section = Section.GY;
                
            }
            else if (line.ToUpper().Contains("TEMPERATURE"))
            {
                section = Section.TEMP;
                
            }
            
            switch (section)
            {
                case Section.ACC:
                    if (line.ToUpper().Contains("X,Y,Z"))
                    {
                        Piecewise = line.Trim().Split(':');
                        Piecewise_count = Piecewise[0].Trim().Split(')');
                        Count = Convert.ToDouble(Piecewise_count[0]);
                        Piecewise = Piecewise[1].Trim().Split(' ');
                        Entity.Add(new Acc( Convert.ToDouble(Piecewise[0]), Convert.ToDouble(Piecewise[1]), Convert.ToDouble(Piecewise[2]) ) );
                        
                    }
                    break;
                case Section.GY:
                    if (line.Contains("degrees/s"))
                    {
                        Piecewise = line.Trim().Split(':');
                        Piecewise_count = Piecewise[0].Trim().Split(')');
                        Count = Convert.ToDouble(Piecewise_count[0]);
                        Piecewise = Piecewise[1].Trim().Split(' ');
                        Entity.Add( new Gy( Convert.ToDouble(Piecewise[0]), Convert.ToDouble(Piecewise[1]), Convert.ToDouble(Piecewise[2]), g));
                        
                    }
                    break;
                case Section.TEMP:
                    if (line.ToUpper().Contains("HERE"))
                    {
                        Piecewise = line.Trim().Split(':');
                        Piecewise_count = Piecewise[0].Trim().Split(')');
                        Count = Convert.ToDouble(Piecewise_count[0]);
                        Entity.Add( new Temp( Convert.ToDouble(Piecewise[1])) );
                        
                    }
                    break;
            }
            return Errorcodes.NONE;
        }       
    }
}
