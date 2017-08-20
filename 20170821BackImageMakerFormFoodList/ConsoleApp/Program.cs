using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurHomeGetter;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OurHomeMenuGetter getter = new OurHomeMenuGetter();
            string htmlString = getter.GetOurhomeFoodTableHtmlString();
            string foodTableString = getter.ExtractHtmlStringByXPath(htmlString, @"//div[@class='textShadowBox']");

            Console.WriteLine(foodTableString);
            Console.Read();
        }
    }
}
