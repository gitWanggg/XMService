using System;
using System.Collections.Generic;
using System.Text;
using X.SDKApp;
using X.SDKApp.Tool;
namespace X.AppSvr
{
    public class XAppHandler : IAppHandler
    {
        Dictionary<int, PreToken> dicTokens;
        
        readonly object objlock=new object();
       

        public XAppHandler()
        {
            dicTokens = new Dictionary<int, PreToken>();
        }
        public Token Find(int AppID)
        {
            Token token = dicTokens.ContainsKey(AppID) ? dicTokens[AppID] : null;
            return token == null || token.IsTimeOut ? Refresh(AppID) : token;
        }
        Token Refresh(int AppID)
        {
            lock (objlock) {
                Token token= dicTokens.ContainsKey(AppID) ? dicTokens[AppID] : null;
                if (token != null && !token.IsTimeOut)
                    return token;
                DBHandler db = new DBHandler();
                var dbtoken = db.Find(AppID);
                if (dbtoken == null || dbtoken.IsTimeOut) {
                    TokenCreater tokenCreater = new TokenCreater();
                    string sec = tokenCreater.Create();
                }

            }
            return null;
        }
        public bool Verify(int AppID, string Sign, string Source)
        {
            throw new NotImplementedException();
        }
    }
}
