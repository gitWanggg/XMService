using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    class R
    {
        public static readonly string MD5 = "MD5";

        public static readonly string ConfigPath = "config\\cloud.config";

        public static readonly string ConfigFormatError = "cloud.config配置异常格式化错误，请检查配置";

        public static readonly string NotFount = "无法找到文件:";

        /// <summary>
        /// 过期时间24小时
        /// </summary>
        static readonly int ExpSeconds = 24 * 3600;
        /// <summary>
        /// 网络延迟上限
        /// </summary>
        static readonly int NetDelay = 10;
    }
}
