using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    class SimpleCrawler
    {
        public Hashtable urls = new Hashtable();
        private int count = 0;
        public int max;
        

        //仅爬行指定页面
        public void Crawl2(string URL,Action<string> action)
        {
            string html = DownLoad(URL);
            Parse2(html);   //仅解析网页
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }
                if (current == null | count > max) break;
                action(current);
                DownLoad(current);
                urls[current] = true;
                count++;
            }

        }

        //存放网页源码的字符形式
        private string DownLoad(string url)
        {
            
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
           
        }

        //抓取目标网页的超链接,bing在哈希表中存放false（未下载）
        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
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
                if (urls[strRef] == null) urls[strRef] = false;
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
