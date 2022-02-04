using Microsoft.EntityFrameworkCore;


namespace XIDServiceLocalMySql
{
    public class DBIDBuilderContext : DbContext
    {
        static DbContextOptions<DBIDBuilderContext> defaultOptions;

        public static void InitDefaultOp(DbContextOptions<DBIDBuilderContext> DefOptions)
        {
            defaultOptions = DefOptions;
        }

        public DBIDBuilderContext()
           : base(defaultOptions)
        {
        }

        public DBIDBuilderContext(DbContextOptions<DBIDBuilderContext> options)
           : base(options)
        {
        }


       

        public DbSet<IDSeedName> IDSeedName { get; set; }

      

       
    }
}
