using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace _170716
{
    class Program
    {
        static void Main()
        {

            string test = "test";

            
            int page = 1;

            var url = $"view-source:http://search.daum.net/search?w=tot&DA=YZR&t__nil_searchbox=btn&sug=&sugo=&q=%EB%B6%80%EC%82%B0%ED%81%AC%EB%A0%88%EC%9D%B8";
            var web = new HtmlWeb();
            var doc = web.Load(url);  

            //var pNode = doc.DocumentNode.SelectNodes("//a");
            var pNode = doc.DocumentNode.SelectNodes("//span[@class=\"ico_local ico_num1\"]");

            foreach (var node in pNode.Nodes())
            {
                Console.WriteLine(node.InnerText);
            }

            /*HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            String strHtml = reader.ReadToEnd();
            Console.WriteLine(strHtml);*/
            Console.ReadLine();
        }

        private static String GetHtmlString(String url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            String strHtml = reader.ReadToEnd();
            //strHtml = Regex.Replace(strHtml, @"<(.|\n)*?>", String.Empty);
            strHtml = Regex.Replace(strHtml, @"<(.|\n)*?>", String.Empty);
            strHtml = strHtml.Replace(" ", "").Replace("\t", "").Replace("//-->", "");
            String[] str = strHtml.Split(new Char[] { '\n' });
            strHtml = null;
            foreach (String s in str)
            {
                if (s.Trim() != "")
                    strHtml += s + ":";
            }
            reader.Close();
            response.Close();
            return strHtml;
        }
    }
}
