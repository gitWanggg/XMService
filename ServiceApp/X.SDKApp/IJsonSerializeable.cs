using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{
    public interface IJsonSerializeable
    {
        string SerializeObject(object target);

        T DeserializeObject<T>(string tSource);
    }
}
