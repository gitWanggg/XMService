using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace X.SDKApp.Tool
{
    public class XHttpClient
    {
        public async Task<byte[]> HttpDownLoadAsync(string Url)
        {
            return null;
        }
        public async Task<string> HttpGetAsync(string Url)
        {
            return null;
        }

        public async Task<T> HttpPostAsync<T>(string Url,object Model)
        {
            return default(T);
        }
        public async Task<string> HttpPostAsync(string Url,object Model)
        {
            return "";
        }
            
    }
}
