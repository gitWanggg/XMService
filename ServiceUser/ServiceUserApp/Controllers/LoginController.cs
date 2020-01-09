using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleX.SDK.User;
using Bll.User;
using Microsoft.AspNetCore.Mvc;

namespace ServiceUserApp.Controllers
{
    [Route("[controller]/[action]")]
    public class LoginController : Controller
    {
        IJwtable Ijwt;

        public LoginController(IJwtable iJwt)
        {
            this.Ijwt = iJwt;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Verify(string Account,string Password)
        {
            if (Account == "1" && Password == "1") {
                AuthUser auser = new AuthUser();
                auser.ID = AngleX.CommonHelper.getTimeStamp().ToString();
                auser.NickName = "张三";
                string token = Ijwt.Encoding(auser);
                HttpContext.Response.Cookies.Append(AngleX.SDK.User.AuthR.JwtTokenKey, token);
                return Json(token);
            }
            else {
                HttpContext.Response.StatusCode = 460;// AngleX.HttpCodeStatus.Http501;
                return Json("账户密码错误");
            }
        }
    }
}