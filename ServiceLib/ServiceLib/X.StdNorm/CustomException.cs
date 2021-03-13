using System;
using System.Collections.Generic;
using System.Text;

namespace X.StdNorm
{
    /// <summary>
    /// 自定义异常
    /// </summary>
    public class CustomException : Exception
    {
        public CustomException()
           : base()
        {

        }

        public CustomException(string Msg)
            : base(Msg)
        {

        }
    }
}
