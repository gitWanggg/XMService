using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.MQ
{
    class AppQueueConfig
    {
        /// <summary>
        /// 生产者
        /// </summary>
        public List<MQExchage> Producers { get; set; }
        /// <summary>
        /// 消费者
        /// </summary>
        public List<MQQueue> Consumers { get; set; }
    }
}
