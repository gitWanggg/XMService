using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace X.SDKApp.Tool
{
    public static class UrlFormater
    {
        /// <summary>
        /// 获取data数据
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static string GetXData(string Url)
        {
            return GetQValu(Url, R.XRegexPatternData);
        }
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static long GetTS(string Url)
        {
            string strts = GetQValu(Url, R.XRegexPatternTs);
            return string.IsNullOrEmpty(strts) ? 0L : Convert.ToInt64(strts);
        }
        public static string GetAppID(string Url)
        {
            return GetQValu(Url, R.XRegexPatternAppID);
        }
        public static string GetQValu(string Url, string RegStr)
        {
            var match = Regex.Match(Url, RegStr, RegexOptions.IgnoreCase);
            return match != null && match.Length > 2 ? match.Groups[2].Value : null;
        }
    }
}
