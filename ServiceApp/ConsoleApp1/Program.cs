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
            System.Net.WebClient client = new System.Net.WebClient();
            string url = "http://localhost:2431/api/home/Upload";
            string file = "F:\\temp\\111.jpg";
            byte[] buffer = client.UploadFile(url, file);

            string r = System.Text.Encoding.UTF8.GetString(buffer);

            Console.WriteLine(r);
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
