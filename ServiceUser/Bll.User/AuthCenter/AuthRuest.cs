using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.User.AuthCenter
{
    /// <summary>
    /// 鉴权请求
    /// </summary>
    public class AuthRuest
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 鉴权账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 鉴权凭证
        /// </summary>
        public string Evidence { get; set; }
    }
}
