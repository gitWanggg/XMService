using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer
{
    class TimerBuilder
    {
        public AnXTimer BuildTimer(JsonTimerItem timerItem)
        {
            AnXTimer xT = new AnXTimer(timerItem.Name);
            bool isStrict = timerItem.Strict==1;
            foreach (HandlerConfig hc in timerItem.Handlers) {
                ITimerHandle iT = BuildHandler(isStrict, hc);
                xT.AddHandle(hc.Name, iT);
            }
            return xT;
        }
        public ITimerHandle BuildHandler(bool isStrict, HandlerConfig hConfig)
        {
            ITimerHandle iT = null;
            if (isStrict)
                iT = new Impl.AsynPostHandlerImpl(hConfig);
            else
                iT = new Impl.SynPostHandlerImpl(hConfig);
            return iT;
        }
    }
}
