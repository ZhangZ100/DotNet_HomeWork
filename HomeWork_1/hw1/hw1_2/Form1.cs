using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw1_2
{
    //partial表示同一个类放在不同的文件中
    public partial class Form1 : Form
    {

        static double num1;
        static double num2;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string n1 = textBox1.Text;
            num1 = InputNum(n1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string n2 = textBox2.Text;
            num2 = InputNum(n2);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static double InputNum(string str)
        {
            while (true)
            {
                string num = str;
                if (IsNumber(num))
                {
                    double nu = double.Parse(num);
                    return nu;
                }
                else Console.WriteLine("输入不合法,请重新输入：");
            }
        }

        //判断该字符串是否是数字
        static bool IsNumber(string str)
        {
            try
            {
                double temp = double.Parse(str);
                return true;
            }
            catch { return false; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
