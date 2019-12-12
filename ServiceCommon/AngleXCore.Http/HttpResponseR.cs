using AngleX;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngleXCore.Http
{
    class HttpResponseR : ICommonRable
    {
        public bool IsSuccess => this.RCode==HttpCodeStatus.Http200;

        public int RCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }

        public HttpResponseR(int rCode)
        {
            this.RCode = rCode;
        }

    }
}
