using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IMCore001.src;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace IMCore001
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

            services.AddScoped<HelloWebSocket>();
            services.TryAddScoped<IWebSocketHandler>(serviceProvider => serviceProvider.GetRequiredService<HelloWebSocket>());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            //app.UseStaticFiles();
            
            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(600),
                ReceiveBufferSize = 4 * 1024
            };
            app.UseWebSockets(webSocketOptions);
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/ws" && context.WebSockets.IsWebSocketRequest) {
                    using (IServiceScope scope = app.ApplicationServices.CreateScope()) {
                        //do something 
                        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        IWebSocketHandler IHandler = scope.ServiceProvider.GetService<IWebSocketHandler>();
                        await IHandler.Hand(context, webSocket);
                    }
                }
                else {
                    //Hand over to the next middleware
                    await next();
                }
            });
            app.UseMvc();
        }
    }
}
