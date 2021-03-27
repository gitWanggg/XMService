using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace X.SDKApp
{
    public class ApiInfo
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlText]
        public string Route { get; set; }


    }
}
