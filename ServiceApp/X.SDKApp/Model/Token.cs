using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    public class Token
    {
        /// <summary>
        /// 加密串
        /// </summary>
        public string Secret { get; set; }
        /// <summary>
        /// 超时时间
        /// </summary>
        public DateTime TimeOut { get; set; }


        public bool IsTimeOut
        {
            get {
                return DateTime.Now > TimeOut;
            }
        }
        public string ToJoin()
        {
            return Secret+","+TimeOut.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
