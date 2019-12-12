using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AngleX.Eureka;
namespace ConsoleTestDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //var builder = new HostBuilder()
            //.ConfigureServices((hostContext, services) => {

            //    //注册服务
            //    AngleXCore.Extensions.DI.XSerialSerServiceCollectionExtensions.UseISerial(services);
            //    AngleXCore.Extensions.DI.XHttpServiceCollectionExtensions.UseHttpClient(services);



            //}).UseConsoleLifetime();

            //var host = builder.Build();


            //AngleX.AppXGlobal.Init(host.Services);
            //使用app
            AngleX.Test.AppMainStart.Start(null, null); 


            AngleX.AppXGlobal.IHttp.DownLoad("https://www.baidu.com/");


            string url1 = AppXContext.Server[APPIDR.IDBUILDER]["XIDBuilder.Test"];

            Console.WriteLine(url1);

            string url2 = AppXContext.Server[APPIDR.IDBUILDER]["XIDBuilder.t2"];

            Console.WriteLine(url2);




            Console.ReadLine();
        }
    }

    
}
