using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestCoreClient.Controllers
{
    [Route("/{controller}/{action}")]
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return Json("001");
        }
    }
}