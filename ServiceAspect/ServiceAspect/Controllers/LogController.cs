using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectBll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AngleX.Aspect;
namespace ServiceAspect.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        ITabelConfig ITC;

        public LogController(ITabelConfig ITC)
        {
            this.ITC = ITC;
        }

        public ActionResult<string> Add(XLog log)
        {
            return ITC.Find(log.AppID).AddLog(log.CategoryKey,log.BizBillID,log.TextContent);
        }

    }
}