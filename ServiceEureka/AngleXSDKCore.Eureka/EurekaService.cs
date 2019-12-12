using System;
using System.Collections.Generic;
using System.Text;
using AngleX;
using AngleX.Eureka;

namespace AngleXSDKCore.Eureka
{
    class EurekaService : IEurekaSerice
    {
        IHttpExpress IHttp;
        public EurekaService(IHttpExpress http)
        {
            this.IHttp = http;
        }
        public InstanceInfo Find(string AppID)
        {
            string url = AppXContext.Server.BuildRequestUrl(AppID);
            return IHttp.DownLoadJson<InstanceInfo>(url);
        }
    }
}
