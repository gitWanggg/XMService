﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace X.SDKApp
{
    public class AppInfo
    {
        [XmlAttribute("id")]
        public string AppID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("origin")]
        public string Origin { get; set; }
        
        /// <summary>
        /// 应用类型
        /// </summary>
        [XmlElement("apptype")]
        public int AppType { get; set; }

       
    }
}
