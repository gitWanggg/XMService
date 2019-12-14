using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer.Impl
{
    class DefaultTimerLife:ITimerlifeable
    {

        TimerCollection TimerDI;

        public ILogger Logger { get; set; }
        public DefaultTimerLife(ILogger logger)
        {
            this.Logger = logger;           
        }

        public void Start()
        {
            TimerDI = new TimerCollection(); //创建容器
            try {
                BootStrap boot = new BootStrap();
                TimerDI = boot.Boot();
                foreach (string key in TimerDI.Timers.Keys) {
                    TimerDI.Timers[key].Start();
                }
                if (_OnSuccess != null)
                    _OnSuccess();
            }
            catch (Exception ex) {
                Dispose();
                if (_OnFail != null)
                    _OnFail(ex);
                else
                    throw ex;
            }
        }
        public Action _OnSuccess;

        public  Action<Exception> _OnFail;
        public void Dispose()
        {
            if(TimerDI!=null)
                TimerDI.Dispose();
            
        }
    }
}
