using System;

namespace ConsoleCoretest
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = AngleX.Eureka.AppContext.Current;
            var server = AngleX.Eureka.AppContext.Server;
            Console.WriteLine("Hello World!");
        }
    }
}
