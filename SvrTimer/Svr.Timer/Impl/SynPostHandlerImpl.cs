using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer.Impl
{
    class SynPostHandlerImpl:PostServiceHandlerBase
    {
        public SynPostHandlerImpl(HandlerConfig config)
            : base(config)
        {

        }
        protected override void execore()
        {
            Console.WriteLine("同步执行:" + this.HTimerConfig.Name);
        }
    }
}
