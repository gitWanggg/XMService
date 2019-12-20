using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace AngleX.MQ
{
    public class MQServiceManager
    {
        static readonly int Timer_tick = 10000;
        Dictionary<string, IService> dicServices;
        private Timer timer = null;
        public MQServiceManager()
        {
            dicServices = new Dictionary<string, IService>();
        }
        public IService this[string Key] { get { return dicServices[Key]; } }
        public void AddService(string Key,IService ISer)
        {
            dicServices[Key] = ISer;
            ISer.ConnectionShutdown += ISer_ConnectionShutdown;
        }
        bool IsClose;
        private void ISer_ConnectionShutdown(object sender, RabbitMQ.Client.ShutdownEventArgs e)
        {           
            if (sender != null) {
                IService ISvr = sender as IService;
                PolicyTryConnect(ISvr);
            }
        }
        void PolicyTryConnect(IService ISvr)
        {      
            
            int nSleep = 0;
            bool isError = false;
            do {
                nSleep += 3;
                isError = TryIsError(ISvr);
                if (isError) {
                    nSleep %= 40;
                    System.Threading.Thread.Sleep(nSleep * 1000);
                }
            }
            while (isError);
        }
        bool TryIsError(IService Isvr)
        {
            if (IsClose)
                return false;
            try {
                Isvr.TryReStart();
                return false;
            }
            catch(Exception ex) {
                if (AngleX.AppXGlobal.ILog != null)
                    AngleX.AppXGlobal.ILog.Error(ex);
                return true;
            }
        }

        public void Start()
        {
            timer = new Timer();
            timer.Interval = Timer_tick;
            timer.Elapsed += Timer_Elapsed;
            foreach (string key in dicServices.Keys) {
               
                dicServices[key].Start();
            }
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();

            timer.Start();
        }

        public void Stop()
        {
            IsClose = true;
            foreach (string key in dicServices.Keys) {
                dicServices[key].Stop();
            }
            if (timer != null) {
                timer.Stop();
                timer.Dispose();
            }
        }
    }
}
