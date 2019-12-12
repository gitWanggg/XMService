using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AngleXCore.Http
{
    public class RESTfulExpress
    {

        protected IHttpClientFactory _hcFactory;
        public RESTfulExpress()
        {
            _hcFactory = RESTfulCenter.hcFactory;
        }
        protected RESTfulExpress(IHttpClientFactory hcFactory)
        {
            _hcFactory = hcFactory;
        }
        public Task<HttpResponseMessage> HttpExe(HttpRequestMessage request)
        {
            HttpClient hc = _hcFactory.CreateClient();
            return hc.SendAsync(request);
        }
        public Task<HttpResponseMessage> HttpExe(string url,HttpMethod httpMethod, HttpContent Content)
        {
            var request = new HttpRequestMessage(httpMethod,url);     
            if(Content!=null)
                request.Content = Content;
            return HttpExe(request);                
        }
        public Task<HttpResponseMessage> HttpExe(string url, string Accept, HttpMethod httpMethod, HttpContent Content)
        {
            var request = new HttpRequestMessage(httpMethod, url);
            if (!string.IsNullOrEmpty(Accept))
                request.Headers.Add("Accept", Accept);
            if (Content != null)
                request.Content = Content;
            return HttpExe(request);
        }
       
        public Task<HttpResponseMessage> HttpExe(string url, Dictionary<string, string> keyValueHeaders, HttpMethod httpMethod, HttpContent Content)
        {           
            var request = new HttpRequestMessage(httpMethod, url);
            foreach (string key in keyValueHeaders.Keys)
                request.Headers.Add(key, keyValueHeaders[key]);
            if (Content != null)
                request.Content = Content;
            return HttpExe(request);
        }
        public Task<HttpResponseMessage> HttpExe(string url, string Accept, Dictionary<string, string> keyValueHeaders, HttpMethod httpMethod, HttpContent Content)
        {
            var request = new HttpRequestMessage(httpMethod, url);
            foreach (string key in keyValueHeaders.Keys)
                request.Headers.Add(key, keyValueHeaders[key]);
            if (!string.IsNullOrEmpty(Accept)&&!keyValueHeaders.ContainsKey("Accept"))
                request.Headers.Add("Accept", Accept);
            if (Content != null)
                request.Content = Content;
            return HttpExe(request);
        }
    }
}
