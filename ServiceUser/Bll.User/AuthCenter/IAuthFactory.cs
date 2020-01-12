using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.User.AuthCenter
{
    public interface IAuthFactory
    {
        IAuthable Create(EnumAuthType enumAuthType);        
    }
}
