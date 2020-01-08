using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.User;
namespace ServiceUserApp.src
{
    public static class DBOptionsBuilderExtensions
    {
        public static void UseDefaultDBContextOptions(this IConfiguration Configuration)
        {
            string dbString = Configuration.GetConnectionString("db");
            var optionsBuilder = new DbContextOptionsBuilder<UserDBContext>();
            optionsBuilder.UseSqlServer(dbString);
            UserDBContext.defaultOptions = optionsBuilder.Options;
        }
    }
}
