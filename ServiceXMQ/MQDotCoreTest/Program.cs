using System;

namespace MQDotCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AngleX.AppXGlobal.ISer = new AngleX.Serial.NewtonSerialize();


            AngleX.MQ.MQServiceBoot booter = new AngleX.MQ.MQServiceBoot();

            AngleX.MQ.MQServiceManager mqM = booter.Boot();
            mqM.Start();



            Console.WriteLine("Hello World!");
        }
    }
}
