using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    public class CloudConfigException: X.StdNorm.CustomException
    {
        public CloudConfigException() : base() { }
        public CloudConfigException(string Message) : base(Message) { }
    }
}
