using System;
using System.Collections.Generic;
using System.Text;
using X.StdNorm;
namespace X.SDKApp
{
    public class XCloud
    {
        public ISerializeable ISerial { get; set; }

        Dictionary<string, XService> DicServices;

        internal ApiExpress apiExpress;

        public AppInfo CurrentApp { get; set; }
        public static ApiExpress ApiExpress
        {
            get { return Cloud.apiExpress; }
        }
        public static AppInfo Current
        {
            get { return Cloud.CurrentApp; }
        }
        XService appService;
        /// <summary>
        /// App注册中心服务
        /// </summary>
        public XService AppAuthcenter
        {
            get { return appService; }
        }
        public XCloud(ISerializeable ISerial)
        {
            this.ISerial = ISerial;
            DicServices = new Dictionary<string, XService>();
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string configpath = currentPath + R.ConfigPath;
            Init(configpath);
            apiExpress = new ApiExpress();
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
            this.CurrentApp = config.App;
            appService = new XService(config.Authcenter); //app授权中心
            appService.RefreshHttp(new XHttpClient(config.Authcenter.AppID,config.Authcenter.Origin));//创建连接
            if (config.Dependencies != null) {
                TokenProvider tokenProvider = new TokenProvider(appService); //Token刷新器
                foreach (ServiceInfo serviceInfo in config.Dependencies) {
                    XService xService = new XService(serviceInfo) {
                        TokenProvider = tokenProvider
                    };
                    DicServices[serviceInfo.AppID] = xService;
                }
            }
        }
        public XService FindXService(string AppID)
        {
            return DicServices.ContainsKey(AppID) ? DicServices[AppID] : null;
        }
        public XService this[string AppID] {
            get {
                var x = FindXService(AppID);
                if (x == null)
                    throw new ServiceNotFoundException("not found service "+AppID);
                return x;
            }
        }


        public static XService GetXService(string AppID)
        {
            return Cloud[AppID];
        }

        static XCloud _xCloud;
        public static XCloud Cloud
        {
            get {
                return _xCloud;
            }
        }
        static readonly object objLock = new object();

        /// <summary>
        /// 直接引用依赖
        /// </summary>
        /// <param name="serializeable"></param>
        /// <returns></returns>
        public static XCloud CreateXCloud(ISerializeable serializeable)
        {
            if (_xCloud == null) {
                lock (objLock) {
                    if (_xCloud == null) {
                        if (serializeable == null)
                            throw new CloudConfigException("xCloud init fail, ISerializeable is null ");
                        var x = new XCloud(serializeable);
                        _xCloud = x;
                    }
                }
            }
            return _xCloud;
        }
        /// <summary>
        /// DI容器引用单例
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static object CreateXCloud(IServiceProvider serviceProvider)
        {
            object objIser = serviceProvider.GetService(typeof(ISerializeable));
            ISerializeable serializeable = objIser as ISerializeable;
            return CreateXCloud(serializeable);
        }
    }
}
