using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.Eureka
{
    public class XRESTfulConfig
    {
        static readonly string fileConfig = "config\\XRESTfulConfig.ini";
        Dictionary<string, string> DicValues;

        public XRESTfulConfig()
        {
           
            init();
        }

        void init()
        {
            ReadINI r = new ReadINI();
            DicValues = r.Read(fileConfig);
        }
        public string Read(string Key)
        {
            if (DicValues.ContainsKey(Key))
                return DicValues[Key];
            else
                return null;
        }
        public string this[string key]
        {
            get {
                return Read(key);
            }
        }
    }
}
