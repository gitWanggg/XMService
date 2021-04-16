using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    public class MD5Converter
    {
        public string ToMD5(string SourceString)
        {

            return ToMD5(Encoding.UTF8.GetBytes(SourceString));


        }
        public string ToMD5(byte[] array)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var bs = md5.ComputeHash(array);
            StringBuilder signMD5 = new StringBuilder();
            foreach (byte b in bs) {
                signMD5.Append(b.ToString("x2"));
            }
            return signMD5.ToString().ToUpper();
        }

        public string Encoding(string SourceStr, string Secret)
        {
            string str2 = SourceStr + R.Key + Secret;
            return ToMD5(str2);
        }
    }
}
