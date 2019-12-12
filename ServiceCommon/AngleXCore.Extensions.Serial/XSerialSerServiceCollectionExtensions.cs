using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AngleXCore.Extensions.Serial;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AngleXCore.Extensions.DI
{
    public static class XSerialSerServiceCollectionExtensions
    {
        public static IServiceCollection UseISerial(this IServiceCollection services)
        {
            services.AddSingleton<NewtonSerialize>();
            services.TryAddSingleton<AngleX.ISerializeable>(serviceProvider => serviceProvider.GetRequiredService<NewtonSerialize>());
            return services;
        }
    }
}
