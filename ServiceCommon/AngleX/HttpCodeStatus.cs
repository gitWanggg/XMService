using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX
{
    public class HttpCodeStatus
    {
        /// <summary>
        /// 服务器响应错误
        /// </summary>
        public readonly static int Http500 = 500;
        /// <summary>
        /// 服务器业务主动抛出异常
        /// </summary>
        public readonly static int Http501 = 501;
        /// <summary>
        /// 响应成功
        /// </summary>
        public readonly static int Http200 = 200;
        /// <summary>
        /// 授权错误尚未登录授权
        /// </summary>
        public readonly static int Http401 = 401;
        /// <summary>
        /// 没有权限访问该内容
        /// </summary>
        public readonly static int Http403 = 403;
    }
}
