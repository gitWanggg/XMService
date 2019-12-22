using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using AngleX.MQ.Core;
namespace AngleX.MQ
{
    public interface IService
    {

        string Name { get; set; }
        /// <summary>
        ///  开启订阅
        /// </summary>
        void Start();
        /// <summary>
        /// 尝试重启
        /// </summary>
        void TryReStart();
        /// <summary>
        /// 是否运行正常
        /// </summary>
        bool IsRuning { get; }
        /// <summary>
        ///  停止订阅
        /// </summary>
        void Stop();

        void CloseAllChannels();

        event EventHandler<ShutdownEventArgs> ConnectionShutdown;

        /// <summary>
        ///  通道列表
        /// </summary>
        List<MQChannel> Channels { get;}

        /// <summary>
        /// 获取指定通道
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        MQChannel Find(string Key);

        MQChannel this[string Key] { get; }
        /// <summary>
        ///  消息队列中定义的虚拟机
        /// </summary>
        string vHost { get; }

      
    }
}
