using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.SP.IDBuilder
{
    public class DBIDBuilderContext:DbContext
    {
        public static DbContextOptions<DBIDBuilderContext> defaultOptions;
        public DBIDBuilderContext()
           : base(defaultOptions)
        {
        }
        public DBIDBuilderContext(DbContextOptions<DBIDBuilderContext> options)
           : base(options)
        {
        }

        
        public DbSet<IDSeed> IDSeed { get; set; }

        public DbSet<IDSeedName> IDSeedName { get; set; }

        public DbSet<IDCounter> IDCounter { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
