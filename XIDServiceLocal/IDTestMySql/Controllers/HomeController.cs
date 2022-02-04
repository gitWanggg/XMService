using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XIDServiceLocal;

namespace IDTestMySql.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        IIDCreaterPool idpool;

        public HomeController(IIDCreaterPool pool)
        {
            this.idpool = pool;
        }
        public IActionResult Index()
        {
            var idcreater = idpool.Find(this.GetType().Name);
            string ids = "";
            for (int i = 0; i < 500; i++) {
                string j = idcreater.NewID("6");
                ids += "<h2>" + j + "</h2>";
            }
            ViewBag.ids = ids;
            return View();
        }


    }
}
