using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] Items =
            {
                "Линейная",
                "Квадтратическая",
                "Кубическая",
                "Раицональная",
                "Логарифмическая"
            };
            comboBox1.Items.AddRange(Items);
            comboBox1.SelectedIndex = 0;
        }

        private void Linean_func(Graphics g)
        {
            int x1 = 0, x2 = 1;
            int y1 = 3 * x1 + 0;
            int y2 = 3 * x2 + 0;
            g.DrawLine(new Pen(Color.Red, 2.0f), x1 * 60, y1 * (-60), x2 * 60, y2 * (-60));
            g.DrawLine(new Pen(Color.Red, 2.0f), x1 * -60, y1 * (60), x2 * -60, y2 * (60));
        }

        public void Quadrant_func(Graphics g)
        {
            Pen pen = new Pen(Color.Green, 2.0f);

            Point[] points =
            {
                new Point(-100, -200),
                new Point(0, 0),
                new Point(100, -200)
            };
            g.DrawCurve(pen, points);
            pen.Dispose();
        }

        public void Cubic_func(Graphics g)
        {
            Pen pen = new Pen(Color.Blue, 2.0f);
            double a = 1, b = 0, c = 0, d = 0;
            List<PointF> points = new List<PointF>();
            for (double x = -20; x <= 20; x += 0.1)
            {
                double y = a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d;
                points.Add(new PointF((float)x * 20, (float)y * (-20)));
            }
            g.DrawLines(pen, points.ToArray());
            pen.Dispose();
        }

        public void Rational_func(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2.0f);
            double a = 1, b = -2, c = 1, d = 1, e = 2;
            for (int x = 0; x <= 200; x++)
            {
                double y = (a * x * x + b * x + c) / (d * x + e);
                int yPixel = 0 - (int)y;
                g.FillRectangle(Brushes.YellowGreen, x, yPixel, 2, 2);
            }
            pen.Dispose();
        }

        public void Loga(Graphics g)
        {
            Pen pen = new Pen(Color.LightBlue, 2.0f);
            double a = 2;
            List<PointF> points = new List<PointF>();
            for (double x = 0.1; x <= 20; x += 0.1)
            {
                double y = Math.Log(x, a);
                points.Add(new PointF((float)x * 20, (float)y * (-20)));
            }
            g.DrawLines(pen, points.ToArray());
            pen.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Point[] lineY = { new Point(10, -190), new Point(0, -200), new Point(-10, -190) };
            Point[] lineX = { new Point(190, 10), new Point(200, 0), new Point(190, -10) };
            Pen pen = new Pen(Color.Black, 2.0f);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Matrix x = new Matrix(1, 0, 0, -1, 0, 0);
            g.TranslateTransform(260, 260, MatrixOrder.Append);
            g.DrawString("Y", Font, Brushes.Black, new Point(-20, -210));
            g.DrawString("X", Font, Brushes.Black, new Point(200, -20));
            g.DrawLine(pen, -200, 0, 200, 0);
            g.DrawLine(pen, 0, -200, 0, 200);
            g.DrawLines(pen, lineX);
            g.DrawLines(pen, lineY);
            int X = -200;
            for (; X < 200; X += 20)
                g.DrawLine(pen, X, -5, X, 5);
            int Y = -180;
            for (; Y < 200; Y += 20)
                g.DrawLine(pen, -5, Y, 5, Y);
            if (comboBox1.SelectedItem.ToString() == "Линейная")
                Linean_func(g);
            if (comboBox1.SelectedItem.ToString() == "Квадтратическая")
                Quadrant_func(g);
            if (comboBox1.SelectedItem.ToString() == "Кубическая")
                Cubic_func(g);
            if (comboBox1.SelectedItem.ToString() == "Раицональная")
                Rational_func(g);
            if (comboBox1.SelectedItem.ToString() == "Логарифмическая")
                Loga(g);
            pen.Dispose();
            g.Dispose();
        }
    }
}
