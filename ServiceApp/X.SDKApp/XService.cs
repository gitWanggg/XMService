using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    public class XService
    {
        Dictionary<string, XApi> dicXApis;
        XHttpClient XHttp { get; set; }        
        public ServiceInfo ServiceInfo { get; set; }
        public XService(ServiceInfo serviceInfo)
        {
            this.ServiceInfo = serviceInfo;
            dicXApis = new Dictionary<string, XApi>();
            if (ServiceInfo != null && ServiceInfo.Apis != null) {
                foreach (ApiInfo apiinfo in ServiceInfo.Apis) {
                    XApi api = new XApi(apiinfo);
                    dicXApis[apiinfo.Name] = api;
                }
            }
        }
      
        internal void RefreshHttp(XHttpClient xClient)
        {
            XHttp = xClient;
            foreach(string key in dicXApis.Keys) {
                dicXApis[key].XHttpClient = xClient;
            }
        }
        
        readonly object objlock = new object();

        internal TokenProvider TokenProvider { get; set; }

        public XApi GetApi(string ApiName)
        {
            if (dicXApis.ContainsKey(ApiName)) {
                if (XHttp == null) {
                    lock (objlock) {
                        if (XHttp == null) {
                           var xClient = new XSDKHttpClient(ServiceInfo.Origin, ServiceInfo.Authorize, this.TokenProvider);
                           RefreshHttp(xClient);
                        }
                    }
                }
                return dicXApis[ApiName];
            }
            return null;
        }
    }
}
