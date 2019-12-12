using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceAspect.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (Request.Host.Host == "localhost") {
                var currentInstance = AngleX.Eureka.AppXContext.Server.Find(AngleX.Eureka.AppXContext.Current.AppID);
                string aa = currentInstance == null ? "NULL" : Newtonsoft.Json.JsonConvert.SerializeObject(currentInstance);
                ViewBag.aa = aa;
            }
            else
                ViewBag.aa = "";
            return View();
        }
    }
}