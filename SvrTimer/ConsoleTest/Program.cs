using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static Svr.Timer.TimeManagement timer;
        static void Main(string[] args)
        {
            timer = new Svr.Timer.TimeManagement(null);
            timer.AsyncStart(OnSuccess, OnFail);

            Console.ReadLine();

            
            Console.WriteLine("停止中...");
            timer.Dispose();
            System.Threading.Thread.Sleep(5000);

        }
        static void OnSuccess()
        {
            Console.WriteLine("启动成功");
        }
        static void OnFail(Exception ex)
        {
            Console.WriteLine("启动失败:"+ex.Message);
        }
    }
}
