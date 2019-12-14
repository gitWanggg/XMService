using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer.Impl
{
    class AsynPostHandlerImpl:PostServiceHandlerBase
    {
        public AsynPostHandlerImpl(HandlerConfig config)
            : base(config)
        {

        }
        protected override void execore()
        {
            Console.WriteLine("异步执行:" + this.HTimerConfig.Name);
        }
    }
}
