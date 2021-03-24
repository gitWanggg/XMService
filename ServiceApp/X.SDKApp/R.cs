using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    class R
    {
        public const string MD5 = "MD5";

        public const string ConfigPath = "config\\cloud.config";

        public const string ConfigFormatError = "cloud.config配置异常格式化错误，请检查配置";

        public const string NotFount = "无法找到文件:";

        public const string Token = "Token";

        public const string Verify = "Verify";

        public const string XSign = "x_sign";
        public const string XSignEqual = "x_sign=";
        public const string XSignEqual2 = "&x_sign=";
        public const string Key = "key=";
        public const string XTSEqual1 = "?x_ts=";
        public const string XTSEqual2 = "&x_ts=";
        public const string XData = "x_data";
        public const string XDataEqual = "x_data=";
        public const string XDataEqual1 = "?x_data=";
        public const string XDataEqual2 = "&x_data=";
        public readonly static DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static long StampNow
        {
            get {
                return Convert.ToInt64((DateTime.UtcNow - dt1970).TotalMilliseconds);
            }
        }
    }
}
