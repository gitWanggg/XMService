using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using X.StdNorm;
namespace X.ServiceApp.src
{
    public class ApiExceptionHandler : IExceptionFilter
    {
        public int nCode;

        public ApiExceptionHandler()
        {
            nCode += 1;
        }
        public void OnException(ExceptionContext context)
        {
            int n2 = nCode;
            if (context.Exception != null) {               
                int ncode = context.Exception is CustomException ? HttpCodeStatus.Http501 :HttpCodeStatus.Http500;              
                context.Result = new ContentResult() {
                    Content =context.Exception.Message,
                    StatusCode =ncode
                };
            }
        }
    }
}
