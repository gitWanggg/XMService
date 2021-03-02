using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.XApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace X.ServiceApp.src
{
    public static class DBOptionsBuilderExtensions
    {
        public static void UseDefaultDBContextOptions(this IConfiguration Configuration)
        {
            string dbString = Configuration.GetConnectionString("db");
            var optionsBuilder = new DbContextOptionsBuilder<DBXAppContext>();
            optionsBuilder.UseSqlServer(dbString);
            DBXAppContext.defaultOptions = optionsBuilder.Options;
        }
    }
}
