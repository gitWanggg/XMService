using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.User.AuthCenter.Impl
{
    public class AuthFactoryImpl : IAuthFactory
    {

        public IAuthable Create(EnumAuthType enumAuthType)
        {
            return new AccountPwdAuthImpl();
        }
    }
}
