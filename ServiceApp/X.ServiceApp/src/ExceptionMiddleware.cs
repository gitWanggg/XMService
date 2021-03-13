using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace X.ServiceApp.src
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;
        private IHostingEnvironment environment;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostingEnvironment environment)
        {
            this.next = next;
            this.logger = logger;
            this.environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            try {
                await next.Invoke(context);                
            }
            catch (Exception e) {
                await HandleException(context, e);
            }
        }

        private async Task HandleException(HttpContext context, Exception e)
        {
            int ncode = e!=null && e is StdNorm.CustomException ?
                StdNorm.HttpCodeStatus.Http501 : StdNorm.HttpCodeStatus.Http500;
            context.Response.StatusCode = ncode;
            context.Response.ContentType = "text/plain; charset=utf-8";            
            await context.Response.WriteAsync(e==null?"":e.Message);
        }
    }
}
