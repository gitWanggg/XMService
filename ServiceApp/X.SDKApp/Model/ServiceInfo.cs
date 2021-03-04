using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace X.SDKApp
{

   
    public class ServiceInfo:AppInfo
    {
        [XmlArrayItem("api")]
        [XmlArray("apiGroups")]
        public List<ApiInfo> Apis { get; set; }

        /// <summary>
        /// 鉴权类型
        /// </summary>
        [XmlElement("authorize")]
        public string Authorize { get; set; }
    }
}
