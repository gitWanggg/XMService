using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.Eureka
{
    public class ServerInfo:AppInfo
    {
        Dictionary<string, InstanceInfo> DicCache;
        object objLock;
        public ServerInfo()
        {
            DicCache = new Dictionary<string, InstanceInfo>();
            objLock = new object();
        }
        public string Service { get; set; }
        public InstanceInfo this[string AppID]
        {
            get {
                return Find(AppID);
            }
        }
        public string BuildRequestUrl(string AppID)
        {
            return Service + AppID;
        }
        public InstanceInfo Find(string AppID)
        {
            if (!DicCache.ContainsKey(AppID)) { //目前不考虑负载和超时缓存
                lock (objLock) {
                    if (!DicCache.ContainsKey(AppID)) {
                        InstanceInfo insInfo = FindHttp(AppID);                        
                        DicCache[AppID] = insInfo;
                    }
                }
            }
            return DicCache[AppID];
        }
        InstanceInfo FindHttp(string AppID)
        {
            string url = AppXContext.Server.BuildRequestUrl(AppID);
            return AngleX.AppXGlobal.IHttp.DownLoadJson<InstanceInfo>(url);
        }
    }
}
