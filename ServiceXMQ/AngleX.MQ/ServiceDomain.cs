using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.MQ
{
   public class ServiceDomain
    {
        public string Name { get; set; }
        /// <summary>
        /// 队列信息
        /// </summary>
        public AppQueueConfig QueueConfig { get; set; }

        /// <summary>
        /// 连接主机信息
        /// </summary>
        public ServiceVMConfig VMConfig { get; set; }
    }
}
