using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX
{
    public class CustomWarningException:CustomException
    {
        /// <summary>
        /// 警告级别
        /// </summary>
        public int WraningLevel { get; set; }
        public CustomWarningException()
           : base()
        {

        }

        public CustomWarningException(string Msg)
            : base(Msg)
        {

        }
    }
}
