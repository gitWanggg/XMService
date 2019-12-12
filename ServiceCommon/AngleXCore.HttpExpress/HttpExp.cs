using AngleX;
using AngleXCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngleXCore.HttpExpress
{
    public static class HttpExp
    {
        public static ISerializeable ISer = new NewtonSerialize();


        public static IHttpExpress CreateHttpExpress()
        {
            return AngleXCore.Http.RESTfulCenter.CreateIHttp(ISer);
        }
    }
}
