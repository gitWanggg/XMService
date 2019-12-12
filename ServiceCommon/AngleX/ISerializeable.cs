using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX
{
    public interface ISerializeable
    {
        string SerializeObject(object target);

        T DeserializeObject<T>(string tSource);
        
    }
}
