using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
namespace AngleX
{
    public static class EncodingHelper
    {
        public static string ToMD5(string inputValue)
        {
            using (var md5 = MD5.Create()) {
                byte[] result = md5.ComputeHash(Encoding.UTF8.GetBytes(inputValue));
                StringBuilder sb = new StringBuilder();
                foreach (byte bItem in result)
                    sb.Append(bItem.ToString("X2"));
                return sb.ToString();
            }
        }
    }
}
