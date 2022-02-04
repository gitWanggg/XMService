using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using XIDServiceLocal;
using Microsoft.Extensions.DependencyInjection.Extensions;
namespace XIDServLocalMySqlExtensions
{
    public static class IDServiceExtensions
    {
        public static void UseIDServiceLocalMySql(this IServiceCollection services, IConfiguration Configuration)
        {
            string dbString = Configuration.GetConnectionString("DBIDService");
            var optionsBuilder = new DbContextOptionsBuilder<DBIDBuilderContext>();
            optionsBuilder.UseMySql(dbString);
            DBIDBuilderContext.InitDefaultOp(optionsBuilder.Options);
            services.AddSingleton<IDCreaterPool>();
            services.TryAddSingleton<IIDCreaterPool>(serviceProvider => serviceProvider.GetRequiredService<IDCreaterPool>());

        }
    }
}
