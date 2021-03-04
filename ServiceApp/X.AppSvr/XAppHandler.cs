using System;
using System.Collections.Generic;
using System.Text;
using X.SDKApp;

namespace X.AppSvr
{
    public class XAppHandler : IAppHandler
    {
        public Token Find(int AppID)
        {
            throw new NotImplementedException();
        }

        public bool Verify(int AppID, string Sign, string Source)
        {
            throw new NotImplementedException();
        }
    }
}
