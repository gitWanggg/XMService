using System;
using System.Collections.Generic;
using System.Text;
using X.SDKApp;
namespace X.AppSvr
{
    class TokenCreater
    {
        /// <summary>
        /// 64位密钥
        /// </summary>
        /// <returns></returns>
        public string Create()
        {
            string source = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff");
            source += Guid.NewGuid().ToString();
            MD5Converter mD5 = new MD5Converter();
            string m1 = mD5.ToMD5(source);
            source += DateTime.Now.ToString("HHmmss.fffff");
            source+= Guid.NewGuid().ToString();
            m1 += mD5.ToMD5(source);
            return m1;
        }
    }
}
