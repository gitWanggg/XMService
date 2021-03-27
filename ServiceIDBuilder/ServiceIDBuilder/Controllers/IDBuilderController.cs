using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.SP.IDBuilder;
namespace ServiceIDBuilder.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IDBuilderController : ControllerBase
    {
        IAPIActionIDBuilder apiID;

        public IDBuilderController(IAPIActionIDBuilder apiid)
        {
            apiID = apiid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="format">0,1  0不格式化，1以后格式化几位，只支持yyyyMMdd0000001</param>
        /// <param name="name"></param>
        /// <returns></returns>

        [Route("h/{appid}/{name}/{format}")]
        
        public ActionResult<string> HardDisk(string appid, string name, string format)
        {
            return apiID.Hard(appid, name, format);

        }
        [Route("create")]
        public ActionResult<string> Create(string appid, string name, string format)
        {
            return apiID.Hard(appid, name, format);
        }
        [Route("m/{appid}/{name}/{format}")]
        
        public ActionResult<string> Memory(string appid,  string name, string format)
        {
            return apiID.Memery(appid, name, format);

        }
        /// <summary>
        /// 只有硬盘型的才有回退计数
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="format"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("back/{appid}/{name}")]
       
        public ActionResult<string> back(string appid, string format, string name)
        {
            return appid + format + name;

        }
        

    }
}