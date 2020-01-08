using System;
using System.Collections.Generic;
using System.Text;
using Model.User;
namespace Bll.User
{
    public interface ISecretable
    {
        string SecretPre { get;}

        string SecretCurrent { get;}
    }
}
