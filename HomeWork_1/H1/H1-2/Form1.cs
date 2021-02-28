using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H1_2
{
    public partial class Form1 : Form
    {
        static double num1;
        static double num2;
        static string symbol;
        public Form1()
        {
            InitializeComponent();
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
                else { }
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (symbol == "+") { MessageBox.Show("答案是：" + (num1 + num2)); }
            if (symbol == "-") { MessageBox.Show("答案是：" + (num1 - num2)); }
            if (symbol == "*") { MessageBox.Show("答案是：" + (num1 * num2)); }
            if (symbol == "/" && num2 != 0) { MessageBox.Show("答案是：" + (num1 / num2)); }
            if (symbol == "%") { MessageBox.Show("答案是：" + (num1 % num2)); }
            else { MessageBox.Show("There are something wrong!", "ERROR"); }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            symbol = comboBox1.Text;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string n1 = textBox1.Text;
            num1 = InputNum(n1);
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            string n2 = textBox2.Text;
            num2 = InputNum(n2);
        }
    }
}
