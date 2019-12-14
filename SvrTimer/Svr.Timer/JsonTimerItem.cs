using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer
{
    class JsonTimerItem:TimerConfig
    {
        public List<HandlerConfig> Handlers { get; set; }
    }
}
