using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer
{
    class BootStrap
    {
        JsonTimer jsonTm;

        TimerCollection tc;

        TimerBuilder tBuilder;

        public BootStrap()
        {                       
            tBuilder = new TimerBuilder();
            tc = new TimerCollection();
        }
        public TimerCollection Boot()
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string filePath = currentPath + "res\\" + "timer.json";
            return Boot(filePath);
        }
        public TimerCollection Boot(string timerJsonPath)
        {
            if (!System.IO.File.Exists(timerJsonPath))
                throw new System.IO.FileNotFoundException(timerJsonPath);
            jsonTm = new JsonTimer(timerJsonPath);
            List<JsonTimerItem> listJTimer = jsonTm.Read();
            foreach (JsonTimerItem jtItem in listJTimer) {
                AnXTimer xTimer = new AnXTimer(jtItem);
                foreach (HandlerConfig hConfig in jtItem.Handlers) {
                    ITimerHandle tHandler = null;
                    if (xTimer.IsStrictTimer) {
                        tHandler = new Impl.AsynPostHandlerImpl(hConfig);
                    }
                    else
                        tHandler = new Impl.SynPostHandlerImpl(hConfig);
                    xTimer.AddHandle(hConfig.Name, tHandler);
                }
                tc.Add(xTimer.Name,xTimer);
            }
            jsonTm.OnChange += jsonTm_OnChange;
            return tc;
        }

        void jsonTm_OnChange(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

       
    }
}
