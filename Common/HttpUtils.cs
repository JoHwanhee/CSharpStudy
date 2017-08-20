using System;
using System.IO;
using System.Net;
using System.Text;

namespace Common
{
    public static class HttpUtils
    {
        public static string DownloadString(WebResponse result, Encoding encoding = null)
        {
            Stream strReceiveStream = result.GetResponseStream();

            if (strReceiveStream != null)
            {
                StreamReader reqStreamReader = new StreamReader(strReceiveStream, encoding ?? Encoding.UTF8);
                string strResult = reqStreamReader.ReadToEnd();

                strReceiveStream.Close();
                reqStreamReader.Close();

                return strResult;
            }

            return "";
        }

        // todo : set encoding
        public static HttpWebRequest HttpRequest(Uri uri, Cookie cookie = null)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.Method = "GET";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:29.0) Gecko/20100101 Firefox/29.0";
            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,#1#*;q=0.8";
            webRequest.TryAddCookie(cookie);
            return webRequest;
        }
    }
}