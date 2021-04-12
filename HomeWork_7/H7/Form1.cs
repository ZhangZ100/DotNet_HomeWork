using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static int r = 0;
        public static int g = 0;
        public static int b = 0;
        public double len = 100;//初始长度
        public static int n = 10;//递归深度


        private Graphics graphics;
        public static double th1 = 30 * Math.PI / 180;//右分支角度
        public static double th2 = 20 * Math.PI / 180;
        public static double per1 = 0.6;
        public static double per2 = 0.7;

        void drawCayleyTree(int n,double x0,double y0,double len,double th) {
            //n递归深度 len主干长度
            if (n == 0) return;
            double x1 = x0 + len * Math.Cos(th);
            double y1 = y0 + len * Math.Sin(th);

            drawLine(x0, y0, x1, y1);//画一条线

            drawCayleyTree(n - 1, x1, y1, per1 * len, th + th1);//右边递归
            drawCayleyTree(n - 1, x1, y1, per2 * len, th - th2);

        }

        void drawLine(double x0, double y0, double x1, double y1) {
            Pen color = new Pen(Color.FromArgb(r, g, b));//自定义RGB
            graphics.DrawLine(color, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = panel1.CreateGraphics();
            graphics.Clear(Color.White);
            drawCayleyTree(n, 350, 350, len, -Math.PI / 2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            r = (int)this.numericUpDown1.Value;
            button1_Click( sender,  e);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            g = (int)this.numericUpDown2.Value;
            button1_Click(sender, e);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            b = (int)this.numericUpDown3.Value;
            button1_Click(sender, e);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            n = (int)this.numericUpDown6.Value;
            button1_Click(sender, e);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            per1 = (double)this.numericUpDown4.Value;
            button1_Click(sender, e);
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            th1 = (int)this.numericUpDown10.Value * Math.PI/180;
            button1_Click(sender, e);
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            per2 = (double)numericUpDown8.Value;
            button1_Click(sender, e);
        }

        private void numericUpDown9_ValueChanged_1(object sender, EventArgs e)
        {
            th2 = (int)this.numericUpDown9.Value * Math.PI / 180;
            button1_Click(sender, e);
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            len = (double)this.numericUpDown7.Value ;
            button1_Click(sender, e);
        }
    }
}
