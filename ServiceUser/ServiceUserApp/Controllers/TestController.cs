using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bll.User;
using AngleX.SDK.User;
namespace ServiceUserApp.Controllers
{
    [Route("[controller]/[action]")]
    public class TestController : Controller
    {
        IJwtable Ijwt;

        public TestController(IJwtable iJwt)
        {
            this.Ijwt = iJwt;
        }
        public IActionResult Index()
        {
            AuthUser auser = new AuthUser();
            auser.ID = AngleX.CommonHelper.getTimeStamp().ToString();
            auser.NickName = "张三";
            ViewBag.b64 = Ijwt.Encoding(auser);
            System.Threading.Thread.Sleep(20000);
            TokenModel tm = Ijwt.Decoding(ViewBag.b64);

            ViewBag.json = Newtonsoft.Json.JsonConvert.SerializeObject(tm);
            return View();
        }
    }
}