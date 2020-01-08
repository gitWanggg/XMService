using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.SDK.User
{
    public class TokenModel
    {
        /// <summary>
        /// 创建时间戳
        /// </summary>
        public long create { get; set; }
        /// <summary>
        /// 过期时间戳
        /// </summary>
        public long exp { get; set; }
        /// <summary>
        /// 有效载荷
        /// </summary>
        public AuthUser load { get; set; }
    }
}
