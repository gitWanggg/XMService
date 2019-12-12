using AngleX;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AngleXCore.Http
{
    public static class RESTfulCenter
    {
        internal static IHttpClientFactory hcFactory;

        static IServiceCollection ISvrCollection;

        static ServiceProvider app;
        public static HttpClient Create()
        {
            return hcFactory.CreateClient();
        }
        
        static RESTfulCenter()
        {
            Init();
        }
        static void Init()
        {
            ISvrCollection = new ServiceCollection();
            ISvrCollection.AddHttpClient();
            app = ISvrCollection.BuildServiceProvider();
            hcFactory = app.GetService<IHttpClientFactory>();           
        }

        public static IHttpExpress CreateIHttp(ISerializeable Iser)
        {
            IHttpExpress Ittp = new HttpExpress(Iser);
            return Ittp;
        }
    }
}
