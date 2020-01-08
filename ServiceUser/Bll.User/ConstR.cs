using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.User
{
    static class ConstR
    {
        /// <summary>
        /// 数据库密钥ID
        /// </summary>
        public static readonly int SecretID = 1;
        /// <summary>
        /// 密钥刷新秒数
        /// </summary>
        public static readonly int ReSecretSeconds = 36000;
        /// <summary>
        /// 密钥长度
        /// </summary>
        public static readonly int SecretLength = 50;

        /// <summary>
        /// token过期时间2小时
        /// </summary>
        public static readonly int TokenExp = 7200;
    }
}
