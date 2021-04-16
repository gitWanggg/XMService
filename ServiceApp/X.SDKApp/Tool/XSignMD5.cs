using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp.Tool
{
    class XSignMD5 : IXSign
    {
       

        public string AppID { get; set; }
        public XSignMD5(string appid)
        {
            this.AppID = appid;           
        }        
       
        public string SignUrl(string Url, string Secret)
        {
            return SignUrl(Url, "", Secret);
        }

        public string SignUrl(string Url,string PostData, string Secret)
        {
            Url += Url.IndexOf('?')>-1 ? "&" : "?";
            string query = string.Format("x_appid={0}&x_ts={1}",
                this.AppID, R.StampNow);
            var converter = new MD5Converter();
            if (!string.IsNullOrEmpty(PostData)) {
                query += R.XDataEqual2;
                query+= converter.ToMD5(PostData);
            }
            Url += query;
            string scode = Url.Substring(Url.IndexOf('?') + 1);           
            Url+= R.XSignEqual2 + converter.Encoding(scode, Secret);
            return Url;
        }
    }
}
