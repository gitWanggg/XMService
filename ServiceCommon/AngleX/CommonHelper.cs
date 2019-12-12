using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX
{
    public static class CommonHelper
    {
        private static DateTime dt1970;
        static ILogger _logger;
        public static ILogger Logger
        {
            get {
                return _logger;
            }
        }
        static CommonHelper()
        {
            _logger = new Impl.ComlogLoggerImpl();
            dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        }
        /// 获取当前时间戳
        /// </summary>
        /// <returns></returns>
        public static long getTimeStamp()
        {
            //TimeSpan ts = DateTime.UtcNow - dt1970; //交管平台的Linux服务器时间可能和WinServer有几秒的误差
            //return Convert.ToInt64(ts.TotalMilliseconds);
            return getTimeStamp(DateTime.Now);
        }
        public static long getTimeStamp(DateTime dtArgs)
        {
            TimeSpan ts = dtArgs.ToUniversalTime() - dt1970; //交管平台的Linux服务器时间可能和WinServer有几秒的误差
            return Convert.ToInt64(ts.TotalMilliseconds);
        }
        public static long getTimeStampSecond()
        {
            //TimeSpan ts = DateTime.UtcNow - dt1970; //交管平台的Linux服务器时间可能和WinServer有几秒的误差
            //return Convert.ToInt64(ts.TotalMilliseconds);
            return getTimeStampSecond(DateTime.Now);
        }
        public static long getTimeStampSecond(DateTime dtArgs)
        {
            TimeSpan ts = dtArgs.ToUniversalTime() - dt1970; //交管平台的Linux服务器时间可能和WinServer有几秒的误差
            return Convert.ToInt64(ts.TotalSeconds);
        }
    }
}
