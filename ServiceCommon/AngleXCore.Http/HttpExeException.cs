using AngleX;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngleXCore.Http
{
    public class HttpExeException:CustomException
    {
        public ICommonRable ICommonR { get; set; }
        public HttpExeException()
           : base()
        {

        }

        public HttpExeException(string Msg)
            : base(Msg)
        {

        }
    }
}
