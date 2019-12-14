using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer
{
    class JsonTimer
    {
        public string JsonPath { get; set; }

        public JsonTimer(string jsonPath)
        {
            this.JsonPath = jsonPath;
        }

        public void StartListening()
        {

        }
        public event EventHandler OnChange;


        public List<JsonTimerItem> Read()
        {
            if (!System.IO.File.Exists(JsonPath))
                return null;
            string jsonStr = System.IO.File.ReadAllText(JsonPath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<JsonTimerItem>>(jsonStr);
        }
    }
}
