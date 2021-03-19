using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using X.StdNorm;
namespace X.SDKApp
{
    public class XApi
    {
        const string htmlHeader = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        const string jsonHeader = "application/json, text/javascript, */*; q=0.01";
        public ApiInfo ApiInfo { get; set; }

        internal XHttpClient XHttpClient { get; set; }

        internal XApi(ApiInfo apiInfo)
        {
            this.ApiInfo = ApiInfo;            
        }

        public string Get()
        {
            return Get(ApiInfo.Route);
        }
        public string  Get(Dictionary<string, string> QueryString)
        {
            string route2 = Format(ApiInfo.Route, QueryString);
            return Get(route2);
        }
        public string Get(string Url)
        {
            return null;
        }
        static string Format(string TmplString, Dictionary<string, string> DevValues)
        {
            if (string.IsNullOrEmpty(TmplString))
                return "";
            TmplString = TmplString.Replace("\\n", "\n");
            MatchCollection Matchs = Regex.Matches(TmplString, @"\{\{\s*=([\s\S]+?)\}\}", RegexOptions.IgnoreCase);
            foreach (Match item in Matchs) {
                string key = item.Groups[1].Value.Trim().Trim('\t').Trim(' ');
                string repString = item.Groups[0].Value;
                if (DevValues != null && DevValues.ContainsKey(key))
                    TmplString = TmplString.Replace(repString, DevValues[key]);

            }
            return TmplString;
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
            string route2 = Format(ApiInfo.Route, QueryString);
            return null;
        }
    }
}
