using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using X.SDKApp.Tool;
namespace X.SDKApp
{
    class XSDKHttpClient:XHttpClient
    {       
        
        /// <summary>
        /// 加密方式
        /// </summary>
        public string Authorize { get; set; }
       
        public XSDKHttpClient(string AppID,string host,string Authorize,TokenProvider provider)
            :base(AppID,host)
        {
            this.Authorize = Authorize;
            this.TokenProvider = provider;
        }

        public TokenProvider TokenProvider { get; set; }

        protected override string SignUrl(string url, string jsonData)
        {
            if (Authorize == R.MD5) {
                var xsign = IXSignBuilder.Builder();
                xsign.SignUrl(url, jsonData, TokenProvider[this.AppID].Secret);
            }
            return base.SignUrl(url, jsonData);
        }


    }
}
