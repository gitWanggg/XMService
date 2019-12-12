using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.SP.IDBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceIDBuilder.src
{
    public static class DBOptionsBuilderExtensions
    {
        public static void UseDefaultDBContextOptions(this IConfiguration Configuration)
        {
            string dbString = Configuration.GetConnectionString("db");
            var optionsBuilder = new DbContextOptionsBuilder<DBIDBuilderContext>();
            optionsBuilder.UseSqlServer(dbString);            
            DBIDBuilderContext.defaultOptions = optionsBuilder.Options;
        }
    }
}
