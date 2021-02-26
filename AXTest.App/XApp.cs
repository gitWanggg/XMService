using System;
using System.Collections.Generic;
using System.Text;

namespace AXTest.App
{
    public static class XApp
    {
        static CloudConfig config;
        static string error = "";
        static string configpath = "config\\cloud.config";
        public static CloudConfig Config {
            get
            {
                if (config == null)
                    throw new CloudConfigException(error);
                return config;
            }          
        }

        static XApp()
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string filePath = currentPath + configpath;
            if (!System.IO.File.Exists(filePath))
                error = "无法找到文件:" + filePath;
            else {
                XmlReader reader = new XmlReader();
                CloudConfig cloud = reader.ReadConfig(filePath);
                if (cloud == null)
                    error = "cloud.config配置异常格式化错误，请检查配置";
                else
                    config = cloud;
            }
        }
    }
}
