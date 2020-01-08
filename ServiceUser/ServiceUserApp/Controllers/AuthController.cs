using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceUserApp.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public void Index(string turl)
        {

        }
        /// <summary>
        /// 校验Jwt合法性,0不是合法的jwt,1校验正确，2已超时
        /// </summary>
        /// <param name="jwt"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<int> Chk(string jwt)
        {
            return 0;
        }
    }
}