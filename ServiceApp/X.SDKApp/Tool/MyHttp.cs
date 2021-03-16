using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace X.SDKApp
{
    //class MyHttp:IMyHttp
    //{
    //    static string htmlHeader = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
    //    static string jsonAccept = "application/json, text/javascript, */*; q=0.01";
    //    static string jsoncontent = "application/json";
    //    public string Host { get; set; }
    //    HttpClient client;
    //    public MyHttp(string host)
    //    {
            
    //        client = new HttpClient();
    //        client.BaseAddress = new Uri(host);
    //        ///client.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
    //    }
        
    //    protected byte[] HandExeR(Task<HttpResponseMessage> task)
    //    {
    //        HttpResponseMessage response = task.Result;
    //        byte[] bR = response.Content.ReadAsByteArrayAsync().Result;
    //        if (response.IsSuccessStatusCode) {
    //            return bR;
    //        }
    //        string error = bR != null && bR.Length > 0 ? System.Text.Encoding.UTF8.GetString(bR) : null;
    //        throw new Exception(error);
    //    }

    //    public string DownLoad(string url)
    //    {
    //        var request = new HttpRequestMessage(HttpMethod.Get, url);            
    //        request.Headers.Add("Accept", jsonAccept);
    //        var t = client.SendAsync(request);
    //        byte[] bR = HandExeR(t);
    //        return Encoding.UTF8.GetString(bR);
    //    }

    //    public string PostForm(string url, Dictionary<string, string> form)
    //    {
    //        MultipartFormDataContent content = new MultipartFormDataContent();
    //        foreach(string key in form.Keys) {
    //            content.Add(new StringContent(form[key]), key);
    //        }
    //        var request = new HttpRequestMessage(HttpMethod.Post, url);            
    //        request.Content = content;
    //        var t = client.SendAsync(request);
    //        byte[] bR = HandExeR(t);
    //        return Encoding.UTF8.GetString(bR);
    //    }

    //    public string PostJosn(string url, string json)
    //    {
    //        HttpContent content = new StringContent(json, Encoding.UTF8, jsoncontent);
    //        var request = new HttpRequestMessage(HttpMethod.Post, url);
    //        request.Content = content;
    //        var t = client.SendAsync(request);
    //        byte[] bR = HandExeR(t);
    //        return Encoding.UTF8.GetString(bR);
    //    }
    //}
}
