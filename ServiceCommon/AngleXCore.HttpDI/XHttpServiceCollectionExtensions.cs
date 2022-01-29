using AngleX;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AngleXCore.HttpDI
{
    public static class XHttpServiceCollectionExtensions
    {
        public static IServiceCollection UseHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<HttpExpressDI>();
            services.TryAddSingleton<IHttpExpress>(serviceProvider => serviceProvider.GetRequiredService<HttpExpressDI>());
            return services;
        }
    }
}
