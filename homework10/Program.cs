using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace homework10
{
    public delegate void fun(string url);
    class SimpleCrawler
    {
        private Hashtable urls = new Hashtable();
        private Hashtable urls2 = new Hashtable();

        private int count = 0;
        static void Main(string[] args)
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);
            myCrawler.Crawl();


            Stopwatch sw = new Stopwatch();

            sw.Start();

            int i = 1;
            foreach(string item in myCrawler.urls.Keys)
            {
                
                Task.Run (()=>myCrawler.Crawl3(item));
                i++;
                Console.WriteLine($"task:{i}启动！");
            }

            
            sw.Stop();
            Console.WriteLine($"\t持续时长：{sw.ElapsedMilliseconds}");
            //new Thread(myCrawler.Crawl).Start();
            Console.ReadKey();
        }

        private  void Crawl()
        {
            Console.WriteLine("开始爬行了.... ");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > 10) break;
                Console.WriteLine("爬行" + current + "页面!");
                string html = DownLoad(current);
                urls[current] = true;
                count++;
                Parse(html);//解析所有
                Console.WriteLine("爬行结束");

            }
        }

        //仅爬行指定页面

        private void Crawl3(string URL)
        {
            Console.WriteLine("3开始爬行！");
            string html = DownLoad(URL);
            Parse2(html);   //仅解析网页
            while (true)
            {
                string current = null;
                foreach (string url in urls2.Keys)
                {
                    if ((bool)urls2[url]) continue;
                    current = url;
                }
                if (current == null | count > 100) break;
                Console.WriteLine("爬行" + current + "页面!");
                DownLoad(current);
                urls2[current] = true;
                count++;
                Console.WriteLine("爬行3结束!");
            }
        }

        //存放网页源码的字符形式
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

        //抓取目标网页的超链接,bing在哈希表中存放false（未下载）
        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+(\.html)+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                strRef = Absolute(strRef);
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
                
            }
        }

        private void Parse2(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+(\.html)+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                    .Trim('"', '\"', '#', '>');
                strRef = Absolute(strRef);
                if (strRef.Length == 0) continue;
                if (urls2[strRef] == null) urls2[strRef] = false;
            }

        }

        //转为绝对地址
        private string Absolute(string strRef)
        {
            Uri uri = new Uri("https://www.cnblogs.com");
            Uri uri1 = new Uri(uri, strRef);
            return uri1.ToString();
        }
    }
}
