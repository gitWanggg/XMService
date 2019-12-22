using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.MQ
{
 
    class MQConfigRead : IConfigReader
    {
        static string configpath = "config\\mqconfig.json";
        public List<ServiceDomain> Read()
        {
            if (AngleX.AppXGlobal.ISer == null)
                throw new AngleX.CustomException("AngleX 尚未初始化");
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string filePath = currentPath + configpath;

            if (!System.IO.File.Exists(filePath))
                throw new System.IO.FileNotFoundException("无法找到文件:" + filePath);
            string jsonConfig = System.IO.File.ReadAllText(configpath);
            try {
                List<ServiceDomain> list = AngleX.AppXGlobal.ISer.DeserializeObject<List<ServiceDomain>>(jsonConfig);
                return list;
            }
            catch {
                throw new AngleX.CustomException("MQConfig反序列化失败");
            }
            
        }
    }
}
