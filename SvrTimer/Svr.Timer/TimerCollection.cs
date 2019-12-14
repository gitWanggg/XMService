using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer
{
    class TimerCollection
    {
        public Dictionary<string, AnXTimer> Timers { get; set; }

        public TimerCollection()
        {
            Timers = new Dictionary<string, AnXTimer>();
        }
        object objlock = new object();
        public void Add(string Key, AnXTimer timer)
        {
            lock (objlock) {
                if (Timers.ContainsKey(Key)&&Timers[Key]!=null)
                    Timers[Key].Dispose();
                Timers[Key] = timer;
            }
        }
        public void Remove(string Key)
        {
            lock (objlock) {
                if (Timers.ContainsKey(Key) && Timers[Key] != null) {
                    Timers[Key].Dispose();
                    Timers.Remove(Key);
                }                
            }
        }

        
        public void Dispose()
        {
            foreach (string Key in Timers.Keys) {
                Timers[Key].Dispose();
            }
        }
    }
}
