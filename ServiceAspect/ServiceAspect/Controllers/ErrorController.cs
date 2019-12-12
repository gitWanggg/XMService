using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleX.Aspect;
using AspectBll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceAspect.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        ITabelConfig ITC;

        public ErrorController(ITabelConfig ITC)
        {
            this.ITC = ITC;
        }

        public ActionResult<string> Add(XError xerror)
        {
            return ITC.Find(xerror.AppID).AddError(xerror.CategoryKey,xerror.BizBillID,xerror.ExMessage,xerror.ExStack);
        }
    }
}