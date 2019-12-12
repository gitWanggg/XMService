using System;
using System.Collections.Generic;
using System.Text;
using AngleX;
using AngleX.Eureka;
namespace AngleX.SDK.IDBuilder
{
    class EurekaIDBuilderImpl : IIDBuilder
    {
        Dictionary<string, string> dicUrlCache;

        object objLock;
        public EurekaIDBuilderImpl()
        {
            dicUrlCache = new Dictionary<string, string>();
            objLock = new object();
        }
        public string NewID<T>() where T : class
        {
            string format = "6";
            return NewID<T>(format);
        }

        public string NewID<T>(string Format) where T : class
        {
            Type t = typeof(T);
            string fullname = t.FullName;
            if (!dicUrlCache.ContainsKey(fullname)) {
                lock (objLock) {
                    if (!dicUrlCache.ContainsKey(fullname)) {
                        string url = buildurl(fullname, Format);
                        dicUrlCache[fullname] = url;
                    }
                }
            }
            return AngleX.AppXGlobal.IHttp.DownLoadJson(dicUrlCache[fullname]);
        }
        string buildurl(string fullName,string format)
        {
            string path = string.Format("IDBuilder/h/{0}/{1}/{2}", AngleX.Eureka.AppXContext.Current.AppID,fullName,format);
            string url = AngleX.Eureka.AppXContext.Server[AppR.AppIDIDBuilder].FindServiceURI(path);
            return url;
        }
    }
}
