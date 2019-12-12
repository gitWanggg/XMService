using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.SP.Eureka
{
    public class DBEurekaContext:DbContext
    {

        public DBEurekaContext(DbContextOptions<DBEurekaContext> options)
           : base(options)
        {
        }


        public DbSet<AppInfo> AppInfo { get; set; }

        public DbSet<InstanceInfo> InstanceInfo { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{            
        //    base.OnModelCreating(modelBuilder);
        //}
        
    }
}
