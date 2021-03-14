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
        public XCloud(ISerializeable ISerial)
        {
            this.ISerial = ISerial;
            DicServices = new Dictionary<string, XService>();
        }
        void Init()
        {

        }
        public XService GetXService(string AppID)
        {
            return DicServices.ContainsKey(AppID) ? DicServices[AppID] : null;
        }
    }
}
