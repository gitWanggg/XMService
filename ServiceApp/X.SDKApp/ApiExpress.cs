using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    public class ApiExpress
    {
        public string NewID<T>() where T:class
        {
            return NewID<T>(6);
        }
        public string NewID<T>(int NumLength)
        {
            string fname = typeof(T).FullName;
            var service = XCloud.GetXService(R.appidbuilder);
            var api = service[R.apiidcreate2];
            string url = string.Format(api.ApiInfo.Route, XCloud.Current.AppID,
                System.Web.HttpUtility.UrlEncode(fname), NumLength);
            return api.Get(url);
        }

       
       
       
    }
}
