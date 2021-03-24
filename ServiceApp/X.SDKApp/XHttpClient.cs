using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace X.SDKApp
{
    class XHttpClient
    {
        const string jsoncontent = "application/json";
        public string Host { get; set; }
        HttpClient client;
        public string AppID { get; set; }
        public XHttpClient(string AppID,string host)
        {
            this.AppID = AppID;
            client = new HttpClient();
            client.BaseAddress = new Uri(host);
        }

        public async Task<byte[]> HttpGetAsync(string url, string Accept)
        {
            string URL = SignUrl(url, null);
            var hM = await HttpExe(url, Accept, HttpMethod.Get, null);
            return await hM.Content.ReadAsByteArrayAsync();
        }
        public async Task<byte[]> HttpPostAsync(string url, string Accept, string jsonData)
        {
            string URL = SignUrl(url, jsonData);
            HttpContent hc = new StringContent(jsonData, Encoding.UTF8, jsoncontent);
            var hM = await HttpExe(url, "", HttpMethod.Post, hc);
            return await hM.Content.ReadAsByteArrayAsync();
        }

        public async Task<HttpResponseMessage> HttpExe(string url, string Accept,
            HttpMethod httpMethod, HttpContent Content)
        {
            var request = new HttpRequestMessage(httpMethod, url);
            if (!string.IsNullOrEmpty(Accept))
                request.Headers.Add("Accept", Accept);
            if (Content != null)
                request.Content = Content;
            return await client.SendAsync(request);
        }

        protected virtual string SignUrl(string url, string jsonData) => "";
        
    }
}
