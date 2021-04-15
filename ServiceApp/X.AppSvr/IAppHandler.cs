using System;
using System.Collections.Generic;
using System.Text;
using X.SDKApp;
namespace X.AppSvr
{
    public interface IAppHandler
    {
        Token Find(int AppID);

        bool Verify(int AppID,  string Source, string Sign);

        
    }
}
