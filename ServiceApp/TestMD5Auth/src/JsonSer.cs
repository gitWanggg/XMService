using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMD5Auth.src
{
    public class JsonSer : X.StdNorm.ISerializeable
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