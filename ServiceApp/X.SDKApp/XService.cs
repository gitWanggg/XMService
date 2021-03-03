using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    public class XService
    {
        IMyHttp http;

        Dictionary<string, ApiInfo> dicApis;
        public ServiceInfo Service { get; set; }

        public XService(ServiceInfo serviceInfo)
        {
            this.Service = serviceInfo;
            http = new MyHttp(Service.Origin);

            dicApis = new Dictionary<string, ApiInfo>();
            foreach (ApiInfo api in this.Service.Apis)
                dicApis.Add(api.Name, api);
        }
        public string ApiGet(string ApiName, string QueryString)
        {
            return null;
        }
        public string ApiGet(string Route)
        {
            return null;
        }

        public static string ApiPost(string ApiName,object JData)
        {
            return null;
        }
    }
}
