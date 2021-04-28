using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw9
{
    public partial class FormCrawl : Form
    {
        private SimpleCrawler crawler = new SimpleCrawler();
        private String url = "";
        public FormCrawl()
        {
            InitializeComponent();
            crawler.ListViewUrlsTrue = listViewTrue;
            crawler.ListViewUrlsFalse = listViewFalse;
            this.listViewTrue.View = View.List;
            this.listViewFalse.View = View.List;

        }

        private void textBoxUrl_TextChanged(object sender, EventArgs e)
        {
            this.url = textBoxUrl.Text;
        }

        private void buttonBeginCrawl_Click(object sender, EventArgs e)
        {
            crawler.ListViewUrlsTrue.Clear();
            crawler.ListViewUrlsFalse.Clear();
            crawler.urls.Clear();

            if (!CheckIsFormat(url))
            {
                MessageBox.Show("URL有误", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            string startUrl = url;
            crawler.urls.Add(startUrl, false);//加入初始页面
            //string startUrl = "http://www.cnblogs.com/dstang2000/";
            //new Thread(crawler.Crawl).Start();
            crawler.Crawl();
        }

        public static bool CheckIsFormat(string strValue)
        {
            if (strValue != null && strValue.Trim() != "")
            {
                string strRegex = @"(http://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(strValue))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
