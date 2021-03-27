using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.SDKApp;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = a + 4;
            Console.WriteLine(b);
            JsonSer jsonSer = new JsonSer();
            XCloud.CreateXCloud(jsonSer);

            var service = XCloud.GetXService("10002");
            var api = service["接口1"];
            string r = api.Get();
            Console.WriteLine(r);

            Console.ReadLine();

        }
       
       
    }
}
