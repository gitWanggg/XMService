using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer
{
    public class HandlerConfig
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 定时器时钟倍数
        /// </summary>
        public int IntervalMulriple { get; set; }
        /// <summary>
        /// 服务接口
        /// </summary>
        public string ServiceAPI { get; set; }
        /// <summary>
        /// 投递参数
        /// </summary>
        public string PostParams { get; set; }
        /// <summary>
        /// 是否启用，0不启用，1启用
        /// </summary>
        public int Effectivity { get; set; }
    }
}
