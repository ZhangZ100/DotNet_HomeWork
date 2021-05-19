using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H8
{
    public partial class Form2 : Form
    {
        OrderService os = new OrderService();
        List<Order> list = new List<Order>();

        Order edit_order = new Order();
        int formid = 0;//用于标记是新建页面还是修改页面

        int id = 6;
        public string cName { set; get; } = "缺省名";
        public string PhoneNumber { set; get; } = "缺省电话";
        public string Address { set; get; } = "缺省地址";
        //goods
        public string gName { set; get; } = "缺省货物名";
        public string gPrice { set; get; } = "0";//单价
        public int gNum { set; get; } = 1;//数量

        public OrderService orderService;


        int index;//用于修改页面中选取项的id
        public Form2(List<Order> list)
        {
            this.list = list;
            orderService = new OrderService();
            InitializeComponent();
        }

        public Form2(Order o, List<Order> list)
        {
            this.edit_order = o;
            index = list.FindIndex(item => item.Equals(edit_order));
            this.list = list;
            formid = 1;
            InitializeComponent();
        }

        private void buttonComplete_Click(object sender, EventArgs e)
        {
            //新建页面
            if (formid == 0) {
                /*id = int.Parse(list.Last().Id);
                id++;*/
                id = 6;
                Order order = new Order("" + id, new Client(
                    "" + cName, "" + PhoneNumber, "" + Address),
                                        new OrderDetails(
                                        new Goods("" + gName, int.Parse(gPrice)), gNum));
                
                /*list.Add(order);*/
                orderService.AddOrder(order);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //Order o = Form1.dataGridView1.SelectedRows[0].DataBoundItem;
                id = int.Parse(edit_order.Id);
                Order order = new Order("" + id, new Client(
                    "" + cName, "" + PhoneNumber, "" + Address),
                                        new OrderDetails(
                                        new Goods("" + gName, int.Parse(gPrice)), gNum));


                list.RemoveRange(index,1);
                //将新的 这段数据 插入到 指定位置
                List<Order> nlist = new List<Order>();
                nlist.Add(order);
                list.InsertRange(index, nlist);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (formid == 1)
            {
                this.Text = "修改订单";
                textBox1.Text = edit_order.Client.Name;
                textBox2.Text = edit_order.Client.PhoneNumber;
                textBox3.Text = edit_order.Client.Address;
                textBox4.Text = ""+ edit_order.Detail.Goods.Name;
                textBox5.Text = ""+edit_order.Detail.Goods.Price;
                numericUpDown1.Value = edit_order.Detail.Number;

            }

        }

        private void goodsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            gNum = (int)numericUpDown1.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cName = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            PhoneNumber = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Address = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            gName = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            gPrice = textBox5.Text;
        }
    }
}
