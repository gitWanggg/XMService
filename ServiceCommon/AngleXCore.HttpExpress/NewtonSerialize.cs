using AngleX;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngleXCore.HttpExpress
{
    public class NewtonSerialize : ISerializeable
    {
        public T DeserializeObject<T>(string tSource)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(tSource);
        }

        public string SerializeObject(object target)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(target);
        }
    }
}
