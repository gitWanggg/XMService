using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQDotNetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AngleX.AppXGlobal.ISer = new AngleX.Serial.NewtonSerialize();

            AngleX.MQ.MQServiceBoot booter = new AngleX.MQ.MQServiceBoot();

            AngleX.MQ.MQServiceManager mqM = booter.Boot();
            mqM.Start();

            string service = "service1";
            string routekey1 = "Anglex.10005.BIZ.Instance.0001";
            string routekey2 = "Anglex.10005.BIZ.Instance.0002";
            string routekey3 = "Anglex.10005.BIZ.Instance.0003";


            for (int i = 0; i < 300; i++) {
                var chanel = mqM[service]["SvrGateway"];
                try {
                    
                    chanel.Publish(i.ToString(), routekey1);
                    chanel.Publish(i.ToString(), routekey2);
                    chanel.Publish(i.ToString(), routekey3);
                    Console.WriteLine("send " + i.ToString());
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);                   
                }
                
                System.Threading.Thread.Sleep(1000);
            }

            mqM.Stop();

            Console.WriteLine("OK");

            Console.ReadLine();
        }
    }
}
