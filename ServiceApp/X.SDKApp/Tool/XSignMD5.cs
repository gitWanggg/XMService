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
            //Url.Substring()
            return null;
        }

        public string SignUrl(string Url, string PostData, string Secret)
        {
            throw new NotImplementedException();
        }
    }
}
