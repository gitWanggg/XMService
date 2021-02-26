using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AXTest.App
{
    [XmlRoot("root")]
    public class CloudConfig
    {
        [XmlElement("app")]
        public AppInfo App { get; set; }

        [XmlArrayItem("service")]
        [XmlArray("dependencies")]
        public List<ServiceInfo> Dependencies { get; set; }


    }
}
