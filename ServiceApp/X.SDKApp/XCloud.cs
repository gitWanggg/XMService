using System;
using System.Collections.Generic;
using System.Text;
using X.StdNorm;
namespace X.SDKApp
{
    public class XCloud
    {
        ISerializeable ISerial;

        Dictionary<string, XService> DicServices;


        XService appService;
        /// <summary>
        /// App注册中心服务
        /// </summary>
        public XService AppAuthcenter
        {
            get { return appService; }
        }
        internal XCloud(ISerializeable ISerial)
        {
            this.ISerial = ISerial;
            DicServices = new Dictionary<string, XService>();            
        }
        internal void Init(string configpath)
        {
            string xmlString = System.IO.File.ReadAllText(configpath, System.Text.Encoding.UTF8);
            XmlReader xmlReader = new XmlReader();
            CloudConfig config = xmlReader.Deserialize<CloudConfig>(xmlString);
            Init(config);
        }
        void Init(CloudConfig config)
        {
            appService = new XService(config.authcenter); //app授权中心
            appService.RefreshHttp(new XHttpClient(config.authcenter.Origin));//创建连接
            if (config.Dependencies != null) {
                TokenProvider tokenProvider = new TokenProvider(appService); //Token刷新器
                foreach (ServiceInfo serviceInfo in config.Dependencies) {
                    XService xService = new XService(serviceInfo) {
                        TokenProvider = tokenProvider
                    };
                    DicServices[serviceInfo.Name] = xService;
                }
            }
        }
        public XService GetXService(string AppID)
        {
            return DicServices.ContainsKey(AppID) ? DicServices[AppID] : null;
        }
    }
}
