using System;
using System.Collections.Generic;
using System.Text;
using X.SDKApp;
namespace X.AppSvr
{
    public interface IAppHandler:IFindSecret
    {
        Token Find(int AppID);

        bool Verify(string Url);

        
    }
}
