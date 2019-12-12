using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.Eureka
{
    public interface IEurekaSerice
    {
        InstanceInfo Find(string AppID);
    }
}
