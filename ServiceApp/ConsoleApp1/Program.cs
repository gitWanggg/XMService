using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            test1();
            Console.ReadLine();

        }
        static void test1()
        {
            string aa = "jlsfjsl?oosfsjd";
            Console.WriteLine(aa.Substring(aa.IndexOf('?')+1));
            Console.ReadLine();

        }
        static string Format(string route,Dictionary<string,string> querstring)
        {
            if (string.IsNullOrEmpty(route) || querstring == null || querstring.Keys.Count < 1)
                return route;

            foreach(string key in querstring.Keys) {
                
            }
            return null;
        }
    }
}
