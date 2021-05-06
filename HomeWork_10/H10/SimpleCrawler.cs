using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


namespace H10
{
    class SimpleCrawler
    {
        public Hashtable urls = new Hashtable();
        private int count = 0;
        private Stopwatch stw = new Stopwatch();


        static void Main(string[] args)
        {

            string startUrl = "http://www.cnblogs.com/dstang2000/";

            // string startUrl = "http://www.frontendjs.com/";
            // if (args.Length >= 1) startUrl = args[0];
            /*Thread t1 = new Thread(myCrawler.Crawl);
            Thread t2 = new Thread(myCrawler.Crawl);
            Thread t3 = new Thread(myCrawler.Crawl);
            t1.Name = "线程 1 ";
            t2.Name = "线程 2 ";
            t3.Name = "线程 3 ";

            t1.Start();
            t2.Start();
            t3.Start();*/

            SimpleCrawler myCrawler = new SimpleCrawler();
            myCrawler.urls.Add(startUrl, false);//加入初始页面

            Stopwatch stw = new Stopwatch();
            stw.Start();
            Parallel.Invoke(new Action[] { () =>  myCrawler.Crawl("任务1 "), () => myCrawler.Crawl("任务2 "), () => myCrawler.Crawl("任务3 ") });
            stw.Stop();
            long para = stw.ElapsedMilliseconds;
            Console.WriteLine("并行用时 " + stw.ElapsedMilliseconds + " ms.");




            SimpleCrawler normalCrawler1 = new SimpleCrawler();
            SimpleCrawler normalCrawler2 = new SimpleCrawler();
            SimpleCrawler normalCrawler3 = new SimpleCrawler();
            normalCrawler1.urls.Add(startUrl, false);//加入初始页面
            normalCrawler2.urls.Add(startUrl, false);//加入初始页面
            normalCrawler3.urls.Add(startUrl, false);//加入初始页面


            stw.Restart();
            normalCrawler1.Crawl("普通线程1 ");
            normalCrawler2.Crawl("普通线程2 ");
            normalCrawler3.Crawl("普通线程3 ");
            stw.Stop();
            Console.WriteLine();
            Console.WriteLine("普通线程用时 " + stw.ElapsedMilliseconds + " ms.");
            Console.WriteLine("并行用时 " + para + " ms.");

            /*    Thread t1 = new Thread(()=>myCrawler.Crawl("线程"));
                t1.Name = "线程 1 ";
                t1.Start();*/



        }

        public void Crawl(string name)
        {
            Console.WriteLine();
            Console.WriteLine(name+": \t");
            Console.Write(name+Thread.CurrentThread.Name+"开始爬行了\n");
           
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }
                if (current == null || count > 20) break;
            Console.Write(name + Thread.CurrentThread.Name + "爬行 " +current+ " 页面\n");

                string html = DownLoad(current); // 下载
                urls[current] = true;//爬行过的 ，置value为true
                count++;
                Parse(html, current);//解析,并加入新的链接

                Console.Write(name + "爬行"+current+"结束\n");

            }
            Console.Write(name + Thread.CurrentThread.Name + "爬行最终结束......\n");
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
                Console.WriteLine(ex.Message);
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
                if (!strRef.StartsWith("h"))
                {
                    string temp = strRef;
                    Uri baseUri = new Uri(current);
                    Uri absoluteUri = new Uri(baseUri, strRef);
                    //将第二个参数中的相对地址转换为绝对地址。
                    strRef = "" + absoluteUri;
                    Console.WriteLine("把 " + temp + " 转为 " + strRef);
                }
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }


    }
}


