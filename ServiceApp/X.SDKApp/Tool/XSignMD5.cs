using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp.Tool
{
    class XSignMD5 : IXSign
    {
        MD5Converter converter;

        public XSignMD5()
        {
            converter = new MD5Converter();
        }        
        string Encoding(string SourceStr, string Secret)
        {
            string str2 = SourceStr + R.Key + Secret;
            return converter.ToMD5(str2);
        }
        public string SignUrl(string Url, string Secret)
        {
            Url += Url.Contains("?") ? R.XTSEqual2 : R.XTSEqual1;
            Url += R.StampNow;
            string source = Url.Substring(Url.IndexOf('?')+1);
            Url+=R.XSignEqual2 + Encoding(source, Secret);
            return Url;
        }

        public string SignUrl(string Url, string PostData, string Secret)
        {
            if (string.IsNullOrEmpty(PostData))
                return SignUrl(Url, Secret);
            Url += Url.Contains("?") ? R.XDataEqual2 : R.XDataEqual1;
            Url += converter.ToMD5(PostData);
            return SignUrl(Url, Secret);
        }
    }
}
