using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleX.SDK.User;
using Bll.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceUserApp.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IJwtable Ijwt;

        UserAccountService AccoutSvr;

        public AccountController(IJwtable iJwt,UserAccountService userService)
        {
            this.Ijwt = iJwt;
            this.AccoutSvr = userService;
        }
        /// <summary>
        /// 验证账户密码正确性
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<string> Verify(string Account, string Password)
        {
            if (Account == "1" && Password == "1") {
                AuthUser auser = new AuthUser();
                auser.ID = AngleX.CommonHelper.getTimeStamp().ToString();
                auser.NickName = "张三";
                string token = Ijwt.Encoding(auser);
                HttpContext.Response.Cookies.Append(AngleX.SDK.User.AuthR.JwtTokenKey, token);
                return token;
            }
            else {
                HttpContext.Response.StatusCode = AngleX.HttpCodeStatus.Http501;
                return "账户密码错误";
            }
        }

        /// <summary>
        /// 注册信息
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Password1"></param>
        /// <param name="Password2"></param>
        /// <returns></returns>
        [HttpPost]
        
        public ActionResult<string> Reg([FromForm]string account, [FromForm]string nickName, [FromForm]string password1, [FromForm]string password2)
        {
            try {
                return AccoutSvr.RegAccount(account, nickName, password1, password2);
            }
            catch(Exception ex) {
                HttpContext.Response.StatusCode = AngleX.HttpCodeStatus.Http501;
                return ex.Message;
            }
            
        }        
    }
}