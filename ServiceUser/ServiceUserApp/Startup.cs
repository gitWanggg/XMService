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
            AngleXCore.Extensions.DI.XSerialSerServiceCollectionExtensions.UseISerial(services);
            AngleXCore.Extensions.DI.XHttpServiceCollectionExtensions.UseHttpClient(services);

            services.AddDbContext<UserDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("db")));
            Configuration.UseDefaultDBContextOptions();
            
            services.AddSingleton<SecretManage>();
            services.TryAddSingleton<IRefreshable>(serviceProvider => serviceProvider.GetRequiredService<SecretManage>());
            services.TryAddSingleton<ISecretable>(serviceProvider => serviceProvider.GetRequiredService<SecretManage>());

            services.AddSingleton<JwtImpl>();
            services.TryAddSingleton<IJwtable>(serviceProvider => serviceProvider.GetRequiredService<JwtImpl>());


            services.AddSingleton<Bll.User.AuthCenter.Impl.AuthFactoryImpl>();
            services.TryAddSingleton<Bll.User.AuthCenter.IAuthFactory>(serviceProvider => serviceProvider.GetRequiredService<Bll.User.AuthCenter.Impl.AuthFactoryImpl>());

            services.AddSingleton<Bll.User.UserCenter.UserApi>();
            services.TryAddSingleton<Bll.User.UserCenter.IUserApi>(serviceProvider => serviceProvider.GetRequiredService<Bll.User.UserCenter.UserApi>());

            services.AddTransient<Bll.User.UserAccountService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            AngleX.AppXGlobal.Init(app.ApplicationServices); //初始化应用程序
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
