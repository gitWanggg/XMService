using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace AngleX
{
    public class HttpHelper
    {
        public static string WebclientGet(string url)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            return wc.DownloadString(url);
        }
        public static byte[] WebclientDownload(string url)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            return wc.DownloadData(url);
        }
        public static string WebclientPostForm(string url, string data)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            //也可以向表头中添加一些其他东西
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            return wc.UploadString(url, data);
        }
        public static string WebclientPostJson(string url, string json)
        {
           
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            //也可以向表头中添加一些其他东西
            wc.Headers.Add("Content-Type", "application/json");
            return wc.UploadString(url, json);
        }
        public static string WebclientPost(string url, Dictionary<string,string> pars)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            //也可以向表头中添加一些其他东西
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            NameValueCollection collArgs = null;
            if (pars != null && pars.Keys.Count > 0) {
                collArgs = new NameValueCollection();
                foreach (string key in pars.Keys) {
                    collArgs.Add(key, pars[key] == null ? null : pars[key].ToString());
                }
            }
            byte[] arrR = wc.UploadValues(url,collArgs);
            return Encoding.UTF8.GetString(arrR);
        }
    }
}
