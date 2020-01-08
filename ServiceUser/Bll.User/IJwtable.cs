using System;
using System.Collections.Generic;
using System.Text;
using AngleX.SDK.User;
namespace Bll.User
{
    public interface IJwtable
    {
        string Encoding(AuthUser authUser);

        TokenModel Decoding(string base64Token);
    }
}
