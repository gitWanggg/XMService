using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer
{
    public class TimeManagement
    {
        Impl.DefaultTimerLife dLife;

        public TimeManagement(ILogger logger)
        {
            dLife = new Impl.DefaultTimerLife(logger);
        }
        public void AsyncStart(Action _OnSuccess, Action<Exception> _OnFail)
        {
            dLife._OnFail += _OnFail;
            dLife._OnSuccess += _OnSuccess;
            System.Threading.Thread thStart = new System.Threading.Thread(Init);
            thStart.IsBackground = true;
            thStart.Start();
        }

        private void Init(object obj)
        {
            dLife.Start();
        }

        public void Dispose()
        {
            dLife.Dispose();
        }

    }
}
