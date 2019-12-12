using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.Test
{
    public static  class AppMainStart
    {
        public static IHost Start()
        {
            return Start(null, null);
        }
        public static IHost Start(Action<IServiceCollection> RegRef, Action<IServiceCollection> RegAfer)
        {
            var builder = new HostBuilder()
           .ConfigureServices((hostContext, services) => {

               if (RegRef != null)
                   RegRef(services);
                //注册服务
                AngleXCore.Extensions.DI.XSerialSerServiceCollectionExtensions.UseISerial(services);
               AngleXCore.Extensions.DI.XHttpServiceCollectionExtensions.UseHttpClient(services);
               if (RegAfer != null)
                   RegRef(services);


           }).UseConsoleLifetime();

            var host = builder.Build();


            AngleX.AppXGlobal.Init(host.Services);
            return host;
        }
    }
}
