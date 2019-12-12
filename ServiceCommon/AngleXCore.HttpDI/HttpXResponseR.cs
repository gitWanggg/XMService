using AngleX;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngleXCore.HttpDI
{
    class HttpXResponseR : ICommonRable
    {
        public bool IsSuccess => this.RCode == HttpCodeStatus.Http200;

        public int RCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }

        public HttpXResponseR(int rCode)
        {
            this.RCode = rCode;
        }
    }
}
