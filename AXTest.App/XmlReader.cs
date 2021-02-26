using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace AXTest.App
{
    class XmlReader
    {
        public T Deserialize<T>(string xmlString) where T:class
        {          
            try {
                using (StringReader sr = new StringReader(xmlString)) {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    T res = (T)xmlSerializer.Deserialize(sr);
                    return res;
                }
            }
            catch(Exception ex) {
                return null;
            }
        }
        public CloudConfig ReadConfig(string ConfigPath)
        {
            string xmlString = System.IO.File.ReadAllText(ConfigPath, System.Text.Encoding.UTF8);
            return Deserialize<CloudConfig>(xmlString);
        }
    }
}
