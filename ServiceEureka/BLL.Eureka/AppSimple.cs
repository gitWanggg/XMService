using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.SP.Eureka;

namespace BLL.Eureka
{
    public class AppSimple : IAppSimple
    {
        DBEurekaContext _db;
        public AppSimple(DBEurekaContext db)
        {
            _db = db;
        }
        public AngleX.Eureka.InstanceInfo Find(string AppID)
        {
            AngleX.Eureka.InstanceInfo insR = new AngleX.Eureka.InstanceInfo();

            var appinfo = _db.AppInfo.Find(AppID);
            if (appinfo == null)
                return null;
            insR.AppID = AppID;
            insR.AppName = appinfo.AppName;
            var insinfo = _db.InstanceInfo.Where(T=>T.AppID==AppID).FirstOrDefault();
            if (insinfo == null)
                return null;
            insR.Host = insinfo.Host;
            insR.ID = insinfo.ID.ToString();
            insR.InstanceName = insinfo.Name;
            insR.Port = insinfo.Port;
            return insR;
        }
    }
}
