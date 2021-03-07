using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using X.AppSvr;
namespace X.ServiceApp.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AppController : Controller
    {
        IAppHandler appHandler;

        public AppController(IAppHandler iHandler)
        {
            appHandler = iHandler;
        }
        

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult<string> Find(int AppID)
        {
            var token = appHandler.Find(AppID);
            return token.ToJoin();
        }
        
        public ActionResult<bool> Verify(int AppID, string Source, string Sign)
        {
            return appHandler.Verify(AppID,Source,Sign);
        }
       
    }
}