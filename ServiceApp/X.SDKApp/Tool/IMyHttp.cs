using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    interface IMyHttp
    {
        string DownLoad(string url);

        string PostForm(string url,Dictionary<string, string> form);

        string PostJosn(string url, string json);



    }
}
