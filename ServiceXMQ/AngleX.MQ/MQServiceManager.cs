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
        Dictionary<string, ConTry> dicTry;
        private Timer timer = null;
        public MQServiceManager()
        {
            dicServices = new Dictionary<string, IService>();
            dicTry = new Dictionary<string, ConTry>();
        }
        public IService this[string Key] { get { return dicServices[Key]; } }
        public void AddService(string Key,IService ISer)
        {
            dicServices[Key] = ISer;
            dicTry[Key] = new ConTry();
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
            if (ISvr.IsRuning)
                return;
            ConTry cT = dicTry[ISvr.Name];
            if (cT.IsTry)
                return;
            lock (cT) {
                if (ISvr.IsRuning||cT.IsTry)
                    return;
                cT.IsTry = true;
                cT.Count += 1;
                int nSleep = 0;
                bool isError = false;
                ISvr.CloseAllChannels();
                do {
                    cT.TotalCount += 1;
                    nSleep += 3;
                    isError = TryIsError(ISvr);
                    if (isError) {
                        nSleep %= 40;
                        System.Threading.Thread.Sleep(nSleep * 1000);
                    }
                }
                while (isError);
                cT.IsTry = false;
            }


            
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
            
            foreach (string key in dicServices.Keys) {
               
                dicServices[key].Start();
            }
            timer = new Timer();
            timer.Interval = Timer_tick;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            foreach(string key in dicServices.Keys) {
                IService Iser = dicServices[key];
                if (Iser.IsRuning || dicTry[Iser.Name].IsTry)
                    continue;
                System.Threading.ThreadPool.QueueUserWorkItem(TryConnectObj, Iser);
            }
            timer.Start();
        }
        void TryConnectObj(object ObjISer)
        {
            IService Iser = ObjISer as IService;
            PolicyTryConnect(Iser);
        }
        public void Stop()
        {
            IsClose = true;            
            if (timer != null) {
                timer.Stop();
                timer.Dispose();
            }
            foreach (string key in dicServices.Keys) {
                dicServices[key].Stop();
            }
        }
    }
}
