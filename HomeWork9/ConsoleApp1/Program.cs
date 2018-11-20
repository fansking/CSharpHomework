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

namespace ConsoleApp1
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        private List<string> list = new List<string>();
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            crawler.urls.Add(startUrl, false);
            crawler.Crawl(startUrl);
            ParallelLoopResult loopResult = Parallel.ForEach(
            crawler.list, (string url,ParallelLoopState state)=> {
                crawler.Crawl(url);
            }   );
        }
        private void Crawl(string url )
        {
            Console.WriteLine("开始爬行了....");


            //while (true)
            //{
            //    string current = null;
            //    foreach (string url in urls.Keys)
            //    {
            //        if ((bool)urls[url]) continue;
            //        current = url;
            //    }
            //    if (current == null || count > 10) break;
            //    Console.WriteLine("爬行" + current + "页面！");
            //    string html = DownLoad(current);
            //    urls[current] = true;
            //    count++;
            //    Parse(html);
            //}
            //List<string> list = new List<string>();

            //ParallelLoopResult loopResult = Parallel.ForEach(
            //    );
            //string current = null;
            //foreach (string url in urls.Keys)
            //{
            //    if ((bool)urls[url]) continue;
            //    current = url;
            //}
            Console.WriteLine("爬行" + url + "页面！");
            string html = DownLoad(url);
            urls[url] = true;
            count++;
            Parse(html);
            Console.WriteLine("爬行"+ url+"结束");
        }
        public string DownLoad(string url) {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html) {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches) {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"','\'', '#', ' ', '>');

                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) {
                    urls[strRef] = false;
                    if (list.Count <= 10) {
                        list.Add(strRef);
                    }
                    
                }
            }
        }
    }
}
