using System;
using System.Collections.Generic;
using System.Text;

namespace X.StdNorm
{
    /// <summary>
    /// Http代码信息
    /// </summary>
    public sealed class HttpCodeStatus
    {
        /// <summary>
        /// 服务器响应错误
        /// </summary>
        public const int Http500 = 500;
        /// <summary>
        /// 服务器业务主动抛出异常
        /// </summary>
        public const int Http501 = 501;
        /// <summary>
        /// 响应成功
        /// </summary>
        public const int Http200 = 200;
        /// <summary>
        /// 授权错误
        /// </summary>
        public const int Http401 = 401;
    }
}
