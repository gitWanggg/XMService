using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace X.SDKApp
{
    [XmlRoot("root")]
    public class CloudConfig
    {
        [XmlElement("app")]
        public AppInfo App { get; set; }

        [XmlArrayItem("service")]
        [XmlArray("dependencies")]
        public List<ServiceInfo> Dependencies { get; set; }


        [XmlElement("authcenter")]
        public ServiceInfo authcenter { get; set; }
    }
}
