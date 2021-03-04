using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    public class CloudConfigException:Exception
    {
        public CloudConfigException() : base() { }
        public CloudConfigException(string Message) : base(Message) { }
    }
}
