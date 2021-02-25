using System;

namespace IDTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AngleX.Test.AppMainStart.Start(null, null);

            for (int i = 0; i < 8; i++) {
                System.Threading.Thread th = new System.Threading.Thread(exe);
                th.Start();
            }
            Console.WriteLine("ok");
            Console.ReadLine();
        }

        static void exe()
        {
            for (int i = 0; i < 4000; i++) {
                Class1 c2 = new Class1();
                c2.ID = AngleX.SDK.IDBuilder.IDManager.Builder.NewID<Class2>(5);
                c2.Name = "002";
                Console.WriteLine(c2.ID);
            }
            Console.WriteLine("ok");
        }
    }
}
