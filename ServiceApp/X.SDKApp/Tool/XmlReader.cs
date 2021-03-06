using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace X.SDKApp
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
            catch {
                return null;
            }
        }      
    }
}
