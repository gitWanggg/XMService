using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    public interface IFindSecret
    {
        ISecretInfo Find(string AppID);
    }
}
