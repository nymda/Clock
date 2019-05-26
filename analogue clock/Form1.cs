using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace analogue_clock
{
    //basic C# analog clock using the windows drawing library, created by Knedit

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Point center = new Point(50, 50);

        public int seccount = 0;
        public int mincount = 0;
        public int hourcount = 0;
        public int hourcountsmall = 0;

        //co-ordinates for each hand position, called 0-59
        public List<String> coordinates = new List<String> { "50,9", "55,10", "59,10", "63,12", "66,14", "70,16", "73,18", "76,20", "80,23", "82,26", "84,30", "87,33", "88,36", "89,40", "89,45", "89,50", "89,55", "89,59", "87,63", "86,67", "84,71", "82,74", "79,77", "76,80", "73,83", "69,85", "65,87", "62,88", "58,89", "54,89", "50,89", "46,89", "42,89", "38,88", "35,87", "31,85", "27,83", "24,80", "21,77", "18,74", "16,71", "14,67", "13,63", "11,59", "11,55", "11,50", "11,45", "11,40", "12,36", "13,33", "16,30", "18,26", "20,23", "24,20", "27,18", "30,16", "34,14", "37,12", "41,10", "45,10"};
        public List<String> hourcoords = new List<String> { "50,9", "70,16", "84,30", "89,50", "84,71", "69,85", "50,89", "31,85", "16,71", "11,49", "16,30", "30,16"};

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            DrawClockFromTime(DateTime.Now.ToString("h:mm:ss"));
        }

        public void DrawClockFromTime(string time)
        {

            string[] curtime = time.Split(':');
            string currentminute = curtime[1];
            string currenthour = curtime[0];
            seccount = Int32.Parse(curtime[2]);
            mincount = Int32.Parse(curtime[1]);
            hourcount = Int32.Parse(curtime[0]);

            Console.WriteLine(time);

            if (seccount == 59)
            {
                seccount = 0;
                if (mincount == 59)
                {
                    mincount = 0;
                    if (hourcount == 11)
                    {
                        hourcount = 0;
                    }
                    else
                    {
                        hourcount++;
                    }
                }
                else
                {
                    mincount++;
                }
            }
            else
            {
                seccount++;
            }

            Bitmap face = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage(face);
            DrawCircle(g, Pens.Black, 50, 50, 49);
            DrawCircle(g, Pens.Black, 50, 50, 1);


            //draws hour markers
            string[] hour0p = hourcoords[0].Split(',');
            Point point0 = new Point(Int32.Parse(hour0p[0]), Int32.Parse(hour0p[1]));
            g.DrawLine(Pens.Cyan, center, point0);

            string[] hour1p = hourcoords[1].Split(',');
            Point point1 = new Point(Int32.Parse(hour1p[0]), Int32.Parse(hour1p[1]));
            g.DrawLine(Pens.Cyan, center, point1);

            string[] hour2p = hourcoords[2].Split(',');
            Point point2 = new Point(Int32.Parse(hour2p[0]), Int32.Parse(hour2p[1]));
            g.DrawLine(Pens.Cyan, center, point2);

            string[] hour3p = hourcoords[3].Split(',');
            Point point3 = new Point(Int32.Parse(hour3p[0]), Int32.Parse(hour3p[1]));
            g.DrawLine(Pens.Cyan, center, point3);

            string[] hour4p = hourcoords[4].Split(',');
            Point point4 = new Point(Int32.Parse(hour4p[0]), Int32.Parse(hour4p[1]));
            g.DrawLine(Pens.Cyan, center, point4);

            string[] hour5p = hourcoords[5].Split(',');
            Point point5 = new Point(Int32.Parse(hour5p[0]), Int32.Parse(hour5p[1]));
            g.DrawLine(Pens.Cyan, center, point5);

            string[] hour6p = hourcoords[6].Split(',');
            Point point6 = new Point(Int32.Parse(hour6p[0]), Int32.Parse(hour6p[1]));
            g.DrawLine(Pens.Cyan, center, point6);

            string[] hour7p = hourcoords[7].Split(',');
            Point point7 = new Point(Int32.Parse(hour7p[0]), Int32.Parse(hour7p[1]));
            g.DrawLine(Pens.Cyan, center, point7);

            string[] hour8p = hourcoords[8].Split(',');
            Point point8 = new Point(Int32.Parse(hour8p[0]), Int32.Parse(hour8p[1]));
            g.DrawLine(Pens.Cyan, center, point8);

            string[] hour9p = hourcoords[9].Split(',');
            Point point9 = new Point(Int32.Parse(hour9p[0]), Int32.Parse(hour9p[1]));
            g.DrawLine(Pens.Cyan, center, point9);

            string[] hour10p = hourcoords[10].Split(',');
            Point point10 = new Point(Int32.Parse(hour10p[0]), Int32.Parse(hour10p[1]));
            g.DrawLine(Pens.Cyan, center, point10);

            string[] hour11p = hourcoords[11].Split(',');
            Point point11 = new Point(Int32.Parse(hour11p[0]), Int32.Parse(hour11p[1]));
            g.DrawLine(Pens.Cyan, center, point11);

            FillCircle(g, Brushes.WhiteSmoke, 50, 50, 38);

            //seconds
            string[] points = coordinates[seccount].Split(',');
            Point cur = new Point(Int32.Parse(points[0]), Int32.Parse(points[1]));
            g.DrawLine(Pens.Gray, center, cur);

            //minutes
            string[] pointsmin = coordinates[mincount].Split(',');
            Point curmin = new Point(Int32.Parse(pointsmin[0]), Int32.Parse(pointsmin[1]));
            g.DrawLine(Pens.Black, center, curmin);

            //hours
            string[] pointshour = coordinates[(hourcount * 5) + Int32.Parse(currentminute[0].ToString())].Split(',');
            Point curhour = new Point(Int32.Parse(pointshour[0]), Int32.Parse(pointshour[1]));
            g.DrawLine(new Pen(Color.Black, 2), center, curhour);

            pictureBox1.Image = face;
            //pictureBox1.Image.Save("testimage.png");
        }

        public static void DrawCircle(Graphics g, Pen pen, float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,radius + radius, radius + radius);
        }

        public static void FillCircle(Graphics g, Brush brush, float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawClockFromTime(DateTime.Now.ToString("h:mm:ss"));
        }
    }
}
