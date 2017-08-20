using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Common;
using HtmlAgilityPack;

namespace OurHomeGetter
{
    public class OurHomeMenuGetter
    {
        public string ExtractHtmlStringByXPath(string myHtml, string xpath)
        {
            StringBuilder htmlStringBuilder = null;
            try
            {
                HtmlDocument mydoc = new HtmlDocument();
                mydoc.LoadHtml(myHtml);
                HtmlNodeCollection nodeCol = mydoc.DocumentNode.SelectNodes(xpath);

                htmlStringBuilder = new StringBuilder();

                if (nodeCol == null)
                {
                    // todo log
                    return "";
                }

                foreach (HtmlNode node in nodeCol)
                {
                    htmlStringBuilder.Append(node.OuterHtml);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "error";
            }
            return htmlStringBuilder.ToString();
        }

        public string GetOurhomeFoodTableHtmlString()
        {
            var uri = new Uri("http://appmobile.ourhome.co.kr/front/menu/weeklyMenuSelectList.do?mi=R030010&busiplcd=FA0NS");
            var cookie = new Cookie("user_id", "jHuYo3gvgvj7sY1KNasAVQ==", "/", uri.Host);
            var webRequest = HttpUtils.HttpRequest(uri, cookie);
            string myHtml = HttpUtils.DownloadString(webRequest.GetResponse());
            return myHtml;
        }
    }
}