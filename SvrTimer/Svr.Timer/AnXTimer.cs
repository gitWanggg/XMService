using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer
{
    class AnXTimer:IDisposable
    {
        public string Name { get; set; }
        /// <summary>
        /// 严格计时
        /// </summary>
        public bool IsStrictTimer { get; set; }

        public int IntervalSeconds { get; set; }
        public System.Timers.Timer timer { get; set; }

        Dictionary<string, HandleCounter> dicHandle = new Dictionary<string, HandleCounter>();

        object ObjLock = new object();
        public AnXTimer(string Name)
        {
            this.Name = Name;
            Init();
        }
        public AnXTimer(bool IsStrict, string Name, int IntervalSeconds)
        {
            this.IsStrictTimer = IsStrict;
            this.Name = Name;
            this.IntervalSeconds = 60;
            Init();
        }
        public AnXTimer(TimerConfig tConfig)
        {
            this.Name = tConfig.Name;
            this.IsStrictTimer = tConfig.Strict == 1;
            this.IntervalSeconds = tConfig.IntervalSeconds;
            Init();
        }
        private void Init()
        {
            timer = new System.Timers.Timer();
            timer.Interval = this.IntervalSeconds * 1000;
            timer.Elapsed += timer_Elapsed;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            try {
                if (dicHandle != null && dicHandle.Count > 0) {
                    lock (ObjLock) {
                        foreach (string key in dicHandle.Keys) {
                            dicHandle[key].Exe();
                        }
                    }
                }
            }
            catch (Exception ex) {
                addLog(EnumAction.异常, ex.Message);
            }
            timer.Start();
        }
        public void AddHandle(string Key,ITimerHandle handle)
        {
            if (dicHandle.ContainsKey(Key))
                return;
            lock (ObjLock) {
                HandleCounter hc = new HandleCounter(handle);
                dicHandle[Key] = hc;
                addLog(EnumAction.添加, Key);
            }
        }
        public void RemoveHandle(string Key)
        {
            
            lock (ObjLock) {
                if(dicHandle.ContainsKey(Key))
                    dicHandle.Remove(Key);
                addLog(EnumAction.移除, Key);
            }
        }

        public  bool Constains(string Key)
        {
            return dicHandle.ContainsKey(Key);
        }
        public void Start()
        {

            addLog(EnumAction.启动, null);
            if (timer != null)
                timer.Start();
        }        
        public void Stop()
        {
            addLog(EnumAction.停止, null);
            if (timer != null)
                timer.Stop();
        }

        void addLog(EnumAction action, string Key)
        {

        }

        public void Dispose()
        {
            Stop();
            if (timer != null) {               
                timer.Dispose();
                addLog(EnumAction.释放, null);
            }
        }
    }
}
