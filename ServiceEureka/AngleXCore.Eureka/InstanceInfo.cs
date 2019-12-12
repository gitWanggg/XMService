using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.Eureka
{
    public class InstanceInfo:AppInfo
    {
        public string ID { get; set; }      
        public string InstanceName { get; set; }

        public int Port { get; set; }

        public string Host { get; set; }

        string domian;
        public string BuildDomain()
        {
            if (domian == null) {
                if (Port == 80)
                    domian = Host;
                else
                    domian = Host + ":" + Port;
            }
            return domian;
        }


        public string this[string ConfigKey]
        {
            get {
                string path = AppXContext.Config[ConfigKey];
                return FindServiceURI(path);
            }
        }

        /// <summary>
        /// 获取服务绝对地址
        /// </summary>
        /// <param name="Path">相对地址</param>
        /// <returns></returns>
        public string FindServiceURI(string Path)
        {
            if (string.IsNullOrWhiteSpace(Path))
                throw new ArgumentNullException("Path is null");
            string path = Path.Trim()[0] == '/' ? Path.Trim() : "/" + Path.Trim();
            string urlHead = string.Format("http://{0}{1}", BuildDomain(), path);
            return urlHead;
        }
    }
}
