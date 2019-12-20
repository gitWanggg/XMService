using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleX.MQ
{
    public class MQQueue:MQExchage
    {
        public string Queue { get; set; }

        public string RouteKey { get; set; }
        public string HandlerType { get; set; }
    }
}
