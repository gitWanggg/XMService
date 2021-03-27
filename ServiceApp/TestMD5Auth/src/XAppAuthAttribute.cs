using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMD5Auth.src
{
    public class XAppAuthAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {                        
            filterContext.Result = new HttpStatusCodeResult(X.StdNorm.HttpCodeStatus.Http401, "未授权，签名验证错误"); ;            
        }
    }
}