using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using X.SDKApp;
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
        public ActionResult<Token> Login(string appid)
        {
            return null;
        }
        
        public ActionResult<Boolean> Verify()
        {
            return false;
        }
        public ActionResult<string> HardDisk(string appid, string name, string format)
        {
            return "";

        }
    }
}