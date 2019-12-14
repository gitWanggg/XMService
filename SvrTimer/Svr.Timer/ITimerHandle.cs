using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer
{
    public interface ITimerHandle
    {
        /// <summary>
        /// 时钟倍数
        /// </summary>
        int nTimerInterval { get; }
        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="args"></param>
        void Exe();

    }
}
