using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceUserApp.src;
using Model.User;
using Microsoft.EntityFrameworkCore;
using Bll.User;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ServiceUserApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<UserDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("db")));
            Configuration.UseDefaultDBContextOptions();
            
            services.AddSingleton<SecretManage>();
            services.TryAddSingleton<IRefreshable>(serviceProvider => serviceProvider.GetRequiredService<SecretManage>());
            services.TryAddSingleton<ISecretable>(serviceProvider => serviceProvider.GetRequiredService<SecretManage>());

            services.AddSingleton<JwtImpl>();
            services.TryAddSingleton<IJwtable>(serviceProvider => serviceProvider.GetRequiredService<JwtImpl>());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
