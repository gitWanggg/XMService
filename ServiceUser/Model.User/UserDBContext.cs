using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Model.User
{
    public class UserDBContext : DbContext
    {
        public static DbContextOptions<UserDBContext> defaultOptions;
        public UserDBContext()
           : base(defaultOptions)
        {
        }
        public UserDBContext(DbContextOptions<UserDBContext> options)
           : base(options)
        {
        }


        public DbSet<AuthPwd> AuthPwd { get; set; }

        public DbSet<BizInfo> BizInfo { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<JwtSecret> JwtSecret { get; set; }
    }
}
