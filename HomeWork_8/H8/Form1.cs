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
    public partial class Form1 : Form
    {
        OrderService os = new OrderService();
        List<Order> list = new List<Order>();


        public Form1(List<Order> rlist) {
            this.list = rlist;
            OrderbindingSource.DataSource = list;
        }
        public Form1()
        {
            InitializeComponent();
            //模拟添加5个订单
            for (int i = 1; i <= 5; i++)
            {
                Order order = new Order(""  + i, new Client("张" + i, i + "", i + ""),
                                        new OrderDetails(
                                            new Goods("货物" + i, 5), 10 - i));

                list.Add(order); //添加订单   
            }
            os.OrderList = list;
            OrderbindingSource.DataSource = os.OrderList;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            new Form2(list).ShowDialog();
            this.OrderbindingSource.ResetBindings(false);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].DataBoundItem is Order norder)
            {  
                new Form2(norder,list).ShowDialog();
                this.OrderbindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("请先选择订单");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //删除
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].DataBoundItem is Order norder)
            {
                int index = index = list.FindIndex(item => item.Equals(norder));
                list.RemoveRange(index, 1);
                this.OrderbindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("请先选择订单");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.Filter = "Json 文件 (*.json)|*.json|所有文件|*.*";
            sfd.InitialDirectory = Environment.CurrentDirectory;
            sfd.DefaultExt = ".json";
            sfd.OverwritePrompt = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    os.Export(sfd.FileName);
                    MessageBox.Show("导出成功");
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("导出失败");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.AddExtension = true;
            ofd.Filter = "Json 文件 (*.json)|*.json|所有文件|*.*";
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.DefaultExt = ".json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<Order> nlist = os.Import(ofd.FileName).OrderList;
                    list.InsertRange(list.Count, nlist);
                    this.OrderbindingSource.DataSource = os.OrderList;
                    this.OrderbindingSource.ResetBindings(false);
                    MessageBox.Show("导入成功");
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("导入失败");
                }
            }
        }
    }
}
