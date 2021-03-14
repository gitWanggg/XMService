using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp.Tool
{
    interface IXSign
    {
        /// <summary>
        /// 签名URL
        /// </summary>
        /// <param name="Url">原始</param>
        /// <param name="Secret">加秘钥</param>
        /// <returns>返回添加签名后的URL</returns>
        string SignUrl(string Url, string Secret);
        /// <summary>
        /// 签名URL
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="PostData"></param>
        /// <param name="Secret"></param>
        /// <returns></returns>
        string SignUrl(string Url, string PostData, string Secret);
    }
}
