using System;
using System.Collections.Generic;
using System.Text;
using X.StdNorm;
namespace X.SDKApp
{
    public class XApi
    {
        const string htmlHeader = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        const string jsonHeader = "application/json, text/javascript, */*; q=0.01";
        public ApiInfo ApiInfo { get; set; }



        public string Get()
        {
            return null;
        }
        public string  Get(Dictionary<string, string> QueryString)
        {
            return null;
        }
        public string Get(string Url)
        {
            return null;
        }

        public string Post(string Data)
        {
            return null;
        }
        public T Post<T>(object Data)
        {
            return default(T);
        }
        public byte[] HttpPost(byte[] Data)
        {
            return null;
        }

        public string  BuilderURL(Dictionary<string, string> QueryString)
        {
            return null;
        }
    }
}
