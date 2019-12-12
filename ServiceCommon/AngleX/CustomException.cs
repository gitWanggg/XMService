using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX
{
    public class CustomException:Exception 
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
