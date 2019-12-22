using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.MQ
{
    class ConTry
    {
        public bool IsTry { get; set; }
        /// <summary>
        /// 合计重试次数
        /// </summary>
        public int  TotalCount { get; set; }
        /// <summary>
        /// 重试序号
        /// </summary>
        public int Count { get; set; }
    }
}
