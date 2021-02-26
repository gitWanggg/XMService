using System;
using System.Collections.Generic;
using System.Text;

namespace AXTest.App
{
    public class CloudConfigException:Exception
    {
        public CloudConfigException() : base() { }
        public CloudConfigException(string Message) : base(Message) { }
    }
}
