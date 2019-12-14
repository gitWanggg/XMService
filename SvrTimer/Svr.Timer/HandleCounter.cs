using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer
{
    public class HandleCounter
    {
        public int CallCount { get; set; }

        public ITimerHandle THandle { get; set; }

        public HandleCounter(ITimerHandle hande)
        {
            this.CallCount = 0;
            this.THandle = hande;
        }

        public void Exe()
        {
            if (THandle == null)
                return;
            CallCount += 1;
            if (CallCount == THandle.nTimerInterval) {
                try {
                    THandle.Exe();
                }
                catch (Exception ex) {
                    //AgileCore.Common2.ComHelp.writeLog(ex);
                }
                CallCount = 0;
            }
        }
    }
}
