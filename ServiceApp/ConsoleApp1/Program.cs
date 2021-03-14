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
            
            Console.ReadLine();

        }
        static void test1()
        {
            string a = "a";
            string b = "b";
            string c = "c";
            string d = "d";
            string route1 = "/a/b?a={a}&b={b}&c={c}";
            string route2 = "/appid/{a}/{b}/{c}";

            Dictionary<string, string> QueryString = new Dictionary<string, string>();
            QueryString[a] = "A";
            QueryString[c] = "&?.~!@#$%^&*{}[](<>\\//)_+=";
            QueryString[b] = "张三";
            QueryString[d] = "{a}";

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
