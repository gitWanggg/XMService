using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    public class XMD5Encodeing
    {
        MD5Converter converter;

        public XMD5Encodeing()
        {
            converter = new MD5Converter();
        }
        static string key = "Key=";
        public string Encoding(string SourceStr, string Secret)
        {
            string str2 = SourceStr + key + Secret;
            return converter.ToMD5(str2);
        }
    }
}
