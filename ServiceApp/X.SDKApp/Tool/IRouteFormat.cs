using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp.Tool
{
    interface IRouteFormat
    {
        /// <summary>
        /// 路由格式化
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="QueryString"></param>
        /// <returns></returns>
        string Foramt(string Route, Dictionary<string, string> QueryString);
    }
}
