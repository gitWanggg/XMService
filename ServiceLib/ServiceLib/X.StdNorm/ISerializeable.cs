using System;
using System.Collections.Generic;
using System.Text;

namespace X.StdNorm
{
    public interface ISerializeable
    {
        string SerializeObject(object target);

        T DeserializeObject<T>(string tSource);
    }
}
