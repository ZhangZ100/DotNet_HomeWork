using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw9
{
    class SimpleCrawler
    {
        public Hashtable urls = new Hashtable();
        private int count = 0;
        public ListView ListViewUrlsTrue;
        public ListView ListViewUrlsFalse;

        /*  static void Main(string[] args)
          {
              SimpleCrawler myCrawler = new SimpleCrawler();
              string startUrl = "http://www.cnblogs.com/dstang2000/";
              // string startUrl = "http://www.frontendjs.com/";

              // if (args.Length >= 1) startUrl = args[0];
              myCrawler.urls.Add(startUrl, false);//加入初始页面
              new Thread(myCrawler.Crawl).Start();

          }*/

        public void Crawl()
        {

            ListViewUrlsTrue.Items.Add("开始爬行了.... ");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }
                if (current == null || count > 20) break;
                ListViewUrlsTrue.Items.Add("爬行" + current + "页面!");
                string html = DownLoad(current); // 下载
                urls[current] = true;//爬行过的 ，置value为true
                count++;
                Parse(html,current);//解析,并加入新的链接
                ListViewUrlsTrue.Items.Add("爬行结束");

            }
            ListViewUrlsTrue.Items.Add("_______最终爬行结束__________");
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                ListViewUrlsFalse.Items.Add(url+"——"+ex.Message);
                return "";
            }
        }

        private void Parse(string html, string current)
        {
            //string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            string strRef = @"(href|HREF)[]*=[]*[""']([^""'#>]+)[.](html|htm|jsp|aspx)[""']";

            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;

                //把相对地址转换为完整地址
                if (!strRef.StartsWith("h")) {
                    string temp = strRef;
                    Uri baseUri = new Uri(current);
                    Uri absoluteUri = new Uri(baseUri, strRef);
                    //将第二个参数中的相对地址转换为绝对地址。
                    strRef = ""+absoluteUri;
                    ListViewUrlsTrue.Items.Add("把相对地址 "+temp+" 转换为完整地址 "+strRef);
                }
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }


    }
}

