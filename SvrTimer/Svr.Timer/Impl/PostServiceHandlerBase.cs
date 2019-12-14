using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer.Impl
{
    abstract class PostServiceHandlerBase:ITimerHandle
    {
        public HandlerConfig HTimerConfig { get; set; }
        protected PostServiceHandlerBase(HandlerConfig tConfig)
        {
            HTimerConfig = tConfig;
        }
        public int nTimerInterval
        {
            get { return HTimerConfig.IntervalMulriple; }
        }

        public void Exe()
        {
            try {
                AddLog();
                execore();
            }
            catch (Exception ex) {
                HandErro(ex);
            }
        }
        void AddLog()
        {

        }
        protected void HandErro(Exception ex)
        {

        }
        protected abstract void execore();
        
    }
}
