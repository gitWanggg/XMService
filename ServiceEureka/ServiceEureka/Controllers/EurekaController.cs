using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Eureka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.SP.Eureka;
namespace ServiceEureka.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EurekaController : ControllerBase
    {
        IAppSimple iapp;
        public EurekaController(IAppSimple iapp)
        {
            this.iapp = iapp;
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult<AngleX.Eureka.InstanceInfo> App(string ID)
        {
            return iapp.Find(ID);
        }
       
    }
}