using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestDemo
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

    class ReadINI
    {
        //static string inipath = "config\\XEureka.ini";
        public Dictionary<string, string> Read(string inipath)
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string filePath = currentPath + inipath;

            if (!System.IO.File.Exists(filePath))
                throw new System.IO.FileNotFoundException("无法找到文件:" + filePath);
            string[] vArray = System.IO.File.ReadAllLines(filePath);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (string citem in vArray) {
                if (string.IsNullOrEmpty(citem))
                    continue;
                string strItem = citem.Trim();
                int nIndexE = strItem.IndexOf('=');
                if (nIndexE < 1)
                    continue;
                string text = nIndexE < strItem.Length - 1 ? strItem.Substring(nIndexE + 1).Trim() : "";
                string key = strItem.Substring(0, nIndexE).Trim();
                dic.Add(key, text);
            }
            return dic;
        }
    }
}
