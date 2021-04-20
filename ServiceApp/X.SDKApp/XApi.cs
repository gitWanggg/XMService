using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            this.ApiInfo = apiInfo;            
        }

        public string Get()
        {
           return GetAsync().Result;

        }
        public async Task<string> GetAsync()
        {
            return await GetAsync(ApiInfo.Route);
        }

        public string Get(Dictionary<string,string> QueryString)
        {
            return GetAsync(QueryString).Result;
        }
        public async Task<string> GetAsync(Dictionary<string, string> QueryString)
        {
            string route2 = Format(ApiInfo.Route, QueryString);
            return await GetAsync(route2);
        }

        public string Get(string Url)
        {
            return GetAsync(Url).Result;
        }
        public async Task<string> GetAsync(string Url)
        {
            byte[] array = await XHttpClient.HttpGetAsync(Url,null);
            return Encoding.UTF8.GetString(array);
        }
        static string Format(string TmplString, Dictionary<string, string> DevValues)
        {
            if (string.IsNullOrEmpty(TmplString))
                return "";
            TmplString = TmplString.Replace("\\n", "\n");
            MatchCollection Matchs = Regex.Matches(TmplString, @"\{\s*([\s\S]+?)\}", RegexOptions.IgnoreCase);
            foreach (Match item in Matchs) {
                string key = item.Groups[1].Value.Trim().Trim('\t').Trim(' ');
                string repString = item.Groups[0].Value;
                if (DevValues != null && DevValues.ContainsKey(key))
                    TmplString = TmplString.Replace(repString, System.Web.HttpUtility.UrlEncode(DevValues[key]));

            }
            return TmplString;
        }
        public string Post(string Data)
        {
            byte[] array = XHttpClient.HttpPostAsync(ApiInfo.Route, Data).Result;
            return array==null||array.Length<1?null: Encoding.UTF8.GetString(array);
        }
        public T Post<T>(object Data)
        {
            string jdata = Data.ToString();
            string pstr = Post(jdata);
            if (string.IsNullOrEmpty(pstr))
                return default(T);
            if (XCloud.Cloud.ISerial == null)
                throw new X.StdNorm.CustomException("XCloud Iserial Is Null");
            return XCloud.Cloud.ISerial.DeserializeObject<T>(pstr);
        }
        public byte[] HttpPost(byte[] Data)
        {
            byte[] array = XHttpClient.HttpPostAsync(ApiInfo.Route, Data).Result;
            return array;
        }
        public async Task<byte[]> HttpPostAsync(byte[] Data)
        {
            byte[] array = await XHttpClient.HttpPostAsync(ApiInfo.Route, Data);
            return array;
        }
        public string  BuilderURL(Dictionary<string, string> QueryString)
        {
            string route2 = Format(ApiInfo.Route, QueryString);
            return null;
        }
    }
}
