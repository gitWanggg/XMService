using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AXTest.App
{
    public class ApiInfo
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlText]
        public string Route { get; set; }


    }
}
