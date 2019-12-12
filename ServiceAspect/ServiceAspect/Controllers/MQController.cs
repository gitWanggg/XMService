using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AngleX.Aspect;
using AspectBll;
namespace ServiceAspect.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MQController : ControllerBase
    {
        ITabelConfig ITC;

        public MQController(ITabelConfig ITC)
        {
            this.ITC = ITC;
        }

        public ActionResult<string> Push(XMQ mq)
        {
            
            DateTime dtSeek = mq.CanSeekTime == null ? DateTime.Now : mq.CanSeekTime.Value;
            return ITC.Find(mq.AppID).PushMQ(mq.BizBillID, mq.ModeNum==null?0:mq.ModeNum.Value, mq.MType==null?0:mq.MType.Value, dtSeek.ToString("yyyy-MM-dd HH:mm:ss"));
           
        }

        public ActionResult<List<XMQ>> Seek(XMQ mq)
        {
           return  ITC.Find(mq.AppID).PopMQ(mq.Top, mq.MType, mq.ModeNum);
        }
        [Route("{appid}/{id}")]
        public ActionResult<int> Delete(string appid,string ID)
        {
            ITC.Find(appid).Delete(Convert.ToInt32(ID));
            return 1;
        }
    }
}