using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer
{
    public class TimerConfig
    {
        public string Name { get; set; }
        /// <summary>
        /// 严格计时 0不严格，1严格
        /// </summary>
        public int Strict { get; set; }
       
        /// <summary>
        /// 定时器秒数，默认为1分钟即60
        /// </summary>
        public  int IntervalSeconds{get;set;}

    }
}
