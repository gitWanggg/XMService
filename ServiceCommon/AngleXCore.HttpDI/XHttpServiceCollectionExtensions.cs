using AngleXCore.HttpDI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngleXCore.Extensions.DI
{
    public static class XHttpServiceCollectionExtensions
    {
        public static IServiceCollection UseHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<HttpExpressDI>();
            services.TryAddSingleton<AngleX.IHttpExpress>(serviceProvider => serviceProvider.GetRequiredService<HttpExpressDI>());
            return services;
        }
    }
}
