using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    public class ServiceNotFoundException : Exception
    {
        public ServiceNotFoundException() : base() { }
        public ServiceNotFoundException(string Message) : base(Message) { }
    }
}
