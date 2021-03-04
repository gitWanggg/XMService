using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace X.ServiceApp.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult<string> Login(string appid)
        {
            return appid;
        }
        public ActionResult<string> HardDisk(string appid, string name, string format)
        {
            return "";

        }
    }
}