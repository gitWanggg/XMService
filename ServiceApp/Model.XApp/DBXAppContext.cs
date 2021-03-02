using Microsoft.EntityFrameworkCore;

namespace Model.XApp
{
    public class DBXAppContext : DbContext
    {
        public static DbContextOptions<DBXAppContext> defaultOptions;
        public DBXAppContext()
           : base(defaultOptions)
        {
        }
        public DBXAppContext(DbContextOptions<DBXAppContext> options)
           : base(options)
        {
        }


        public DbSet<AppInfo> AppInfo { get; set; }

        public DbSet<AppSecret> AppSecret { get; set; }

        public DbSet<AppSecretLog> AppSecretLog { get; set; }
    }
}
