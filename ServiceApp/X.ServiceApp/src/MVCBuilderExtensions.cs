using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace X.ServiceApp.src
{
    public static class MVCBuilderExtensions
    {
        public static void UseMVCOptions(this IServiceCollection services)
        {
            //services.AddSingleton<ApiExceptionHandler>();            
            services.AddMvc((options) => {
                options.Filters.Add(typeof(ApiExceptionHandler));
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}
