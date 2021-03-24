using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    class TokenProvider
    {
        Dictionary<string, Token> dicTokens;



        public XService AppAuthService { get; set; }

        public TokenProvider(XService AuthService)
        {
            this.AppAuthService = AuthService;
            dicTokens = new Dictionary<string, Token>();
        }
        public Token this[string AppID]
        {
            get {
                if (dicTokens.ContainsKey(AppID)) {
                    var token = dicTokens[AppID];
                    if (!token.IsTimeOut)
                        return token;
                }
                return Refresh(AppID);
            }
        }

        public Token Refresh(string AppID)
        {
            string stoken = AppAuthService[R.Token].Get();            
            return dicTokens[AppID] = Token.CastToken(stoken);
        }
    }
}
