using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    class JsonSer : X.StdNorm.ISerializeable
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
