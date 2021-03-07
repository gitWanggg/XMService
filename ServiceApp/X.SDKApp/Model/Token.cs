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

        public static Token CastToken(string SecAndTime)
        {
            try {
                string[] arr = SecAndTime.Split(',');
                Token token = new Token() {
                    Secret = arr[0],
                    TimeOut = Convert.ToDateTime(arr[1])
                };
                return token;
            }
            catch {
                return null;
            }
        }
        
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
