using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    public interface ISecretInfo
    {
        string SecretCurrent { get; }

        string SecretPrevious { get; }
    }
}
