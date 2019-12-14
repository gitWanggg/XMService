using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class ConsoleLog:Svr.Timer.ILogger
    {
        public void Log(string Message)
        {
            Console.WriteLine(Message);
        }
    }
}
