﻿using System;
using System.Collections.Generic;
using System.Text;
using X.SDKApp;
namespace X.AppSvr
{
    public class XAppHandler : IAppHandler
    {
        Dictionary<int, PreToken> dicTokens;
        
        readonly object objlock=new object();

        XMD5Encodeing XMD5Encodeing;

        IAuthSign iAuth;
        public XAppHandler(IAuthSign authSign)
        {
            iAuth = authSign;
            dicTokens = new Dictionary<int, PreToken>();
            XMD5Encodeing = new XMD5Encodeing();
        }
        public Token Find(int AppID)
        {
            Token token = dicTokens.ContainsKey(AppID) ? dicTokens[AppID] : null;
            return token == null || token.IsTimeOut ? Refresh(AppID) : token;
        }

        private Token Refresh(int AppID)
        {
            lock (objlock) {
                Token token= dicTokens.ContainsKey(AppID) ? dicTokens[AppID] : null;
                if (token == null || token.IsTimeOut) {
                    DBHandler db = new DBHandler();
                    var dbtoken = db.Find(AppID);
                    if (dbtoken == null || dbtoken.IsTimeOut) {
                        TokenCreater tokenCreater = new TokenCreater();
                        string sec = tokenCreater.Create();
                        if (dbtoken == null) {
                            dbtoken = new PreToken() {
                                ID = AppID,
                                Secret = sec
                            };
                        }
                        dbtoken.SecretPre = dbtoken.Secret;
                        dbtoken.Secret = sec;
                        dbtoken.TimeOut = DateTime.Now.AddSeconds(R.ExpSeconds);
                        db.Refresh(AppID, sec, DateTime.Now, dbtoken.TimeOut);
                    }
                    token = dicTokens[AppID] = dbtoken;
                }                
                return token;
            }            
        }
        public bool Verify(string Url)
        {
           return iAuth.Auth(Url);
        }

        public ISecretInfo Find(string AppID)
        {
            var token= Find(Convert.ToInt32(AppID));
            return token as ISecretInfo;
        }
    }
}
