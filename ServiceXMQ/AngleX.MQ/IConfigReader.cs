using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.MQ
{
    public interface IConfigReader
    {
        List<ServiceDomain> Read();
    }
}
