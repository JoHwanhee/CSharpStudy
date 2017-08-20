using System.Net;

namespace Common
{
    public static class ExtensionHttpWebRequest
    {
        public static bool TryAddCookie(this WebRequest webRequest, Cookie cookie)
        {
            if (cookie == null)
            {
                return false;
            }

            HttpWebRequest httpRequest = webRequest as HttpWebRequest;


            if (httpRequest == null)
            {
                return false;
            }

            if (httpRequest.CookieContainer == null)
            {
                httpRequest.CookieContainer = new CookieContainer();
            }

            httpRequest.CookieContainer.Add(cookie);
            return true;
        }
    }
}