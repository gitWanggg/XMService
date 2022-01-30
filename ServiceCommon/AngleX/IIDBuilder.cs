using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX
{
    public interface IIDBuilder
    {
        string NewID<T>() where T : class;

        string NewID<T>(string Format) where T : class;

        string NewID<T>(int Format) where T : class;
    }
}
