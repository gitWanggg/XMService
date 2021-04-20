using System;
using System.Collections.Generic;
using System.Text;
using X.SDKApp.Tool;

namespace X.SDKApp
{
    public class MD5AuthSign:IAuthSign
    {
        public IFindSecret FindSecret { get; set; }

        public MD5AuthSign(IFindSecret findSecret)
        {
            this.FindSecret = findSecret;
        }

        public bool Auth(string URL)
        {
            
            string appid = UrlFormater.GetAppID(URL);
            if (string.IsNullOrEmpty(appid))
                return false;
            var secinfo = FindSecret.Find(appid);
            if (secinfo == null)
                return false;
            string signStr = UrlFormater.GetQValu(URL, R.XRegexPatternSign);
            if (string.IsNullOrEmpty(signStr))
                return false;
            try {
                int nA = URL.LastIndexOf('&');
                int nQ = URL.IndexOf('?');
                string query = URL.Substring(nQ + 1, nA - nQ - 1);
                
                var converter = new MD5Converter();
                string sign0 = converter.Encoding(query, secinfo.SecretCurrent);
                if (sign0 == signStr)
                    return true;
                string sign1= converter.Encoding(query, secinfo.SecretPrevious);
                return sign1 == signStr;
            }
            catch {
                return false;
            }
        }
    }
}
