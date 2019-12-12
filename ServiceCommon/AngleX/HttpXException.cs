using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX
{
    public class HttpXException : CustomException
    {
        public ICommonRable ICommonR { get; set; }
        public HttpXException()
           : base()
        {

        }

        public HttpXException(string Msg)
            : base(Msg)
        {

        }
    }
}
