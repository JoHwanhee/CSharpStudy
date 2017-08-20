using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _20170723
{
    class Program
    {
        static void Main(string[] args)
        {
               GetYoutubeComments();
        }

        private static void GetYoutubeComments()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Url = "https://www.youtube.com/watch?v=OwJPPaEyqhI";
                driver.Manage().Window.Maximize(); //브라우져 최대 확대
                
                IWebElement element = driver.FindElement(By.Id("watch-discussion"));


                // scrolll down so that comments start to load
                //driver.("window.scrollBy(0,500)", "");

                Thread.Sleep(8000);
                

                var commentElements = element.FindElements(By.XPath("//iframe"));



                foreach (var hiddenElem in commentElements)
                {
                    try
                    {
                        if (hiddenElem.GetAttribute("id") != null && hiddenElem.GetAttribute("id").StartsWith("I0_"))
                        {
                            // switch to iframe which contains comments
                            driver.SwitchTo().Frame(hiddenElem);
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Cannot find the u_0_23");
                    }
                 
                }

                var comments= driver.FindElements(By.XPath("//div[@class='Ct']"));
                foreach (var e in comments)
                {
                    Console.WriteLine(e.Text);
                }
                driver.Close();
            }
        }
    }
}
