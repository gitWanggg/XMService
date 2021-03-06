﻿using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace AngleX.MQ.Core
{
    class XMQService : IService
    {
        public string Name { get; set; }
        public ServiceDomain ServiceConfig { get; set; }

        protected IConnection Connection;

        IConnectionFactory IConFactory;
        bool IsStart;
        public XMQService(string Name,ServiceDomain ServiceD)
        {
            this.ServiceConfig = ServiceD;
            this.Name = Name;
        }
        public bool IsRuning { get { return Connection != null && Connection.IsOpen; } }


        Dictionary<string, MQChannel> dicChannel;

        List<MQChannel> listChannel;
        public event EventHandler<ShutdownEventArgs> ConnectionShutdown;

        public List<MQChannel> Channels
        {
            get {
                return listChannel;
            }
        }

        public string vHost {
            get {
                    if (ServiceConfig == null || ServiceConfig.VMConfig == null)
                        return null;
                    else
                        return ServiceConfig.VMConfig.VMHost;
               }
        }

        public MQChannel this[string Key] => Find(Key);

        public MQChannel Find(string Key)
        {
            return dicChannel[Key];
        }

        public void Start()
        {
            if (IsStart)
                return;
            IConFactory = MQConnectFactory.Create(this.ServiceConfig.VMConfig); //创建连接工程
            dicChannel = new Dictionary<string, MQChannel>();
            listChannel = new List<MQChannel>();
            //init();
            initConnect();
            initChannel();
            IsStart = true;
        }
       
        void initConnect()
        {
            Connection = IConFactory.CreateConnection();
            Connection.ConnectionShutdown += Connection_ConnectionShutdown;
        }
        private void Connection_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            if (IsStart && ConnectionShutdown != null)
                ConnectionShutdown(this, e);
        }

        void initChannel()
        {
            MQChannelManager chManager = new MQChannelManager(this.Connection);
            if (this.ServiceConfig.QueueConfig.Consumers != null && this.ServiceConfig.QueueConfig.Consumers.Count > 0) {
                foreach(MQQueue item in this.ServiceConfig.QueueConfig.Consumers) {
                    MQChannel mCh = chManager.CreateReceiveChannel(ExchangeType.Topic, item.ExchangeName, item.Queue, item.RouteKey);
                    dicChannel[item.Key] = mCh;
                    mCh.OnReceivedCallback = MQHandlerFactory.Create(item.HandlerType); //设置处理类
                }
            }
            if (this.ServiceConfig.QueueConfig.Producers != null && this.ServiceConfig.QueueConfig.Producers.Count > 0) {
                foreach (MQExchage item in this.ServiceConfig.QueueConfig.Producers) {
                    MQChannel mCh = chManager.CreatePublishChannel(item.ExchangeName);
                    dicChannel[item.Key] = mCh;
                    //mCh.OnReceivedCallback = MQHandlerFactory.Create(item.HandlerType); //设置处理类
                }
            }
        }
       
        public void Stop()
        {
            IsStart = false;
            if (dicChannel != null) {
                foreach (string key in dicChannel.Keys)
                    dicChannel[key].Stop();
                dicChannel.Clear();
                dicChannel = null;
            }            
            if(listChannel!=null) {
                listChannel.Clear();
                listChannel = null;
            }
            if (Connection != null) {
                Connection.Close();
                Connection.Dispose();
                Connection = null;
            }
            IConFactory = null;           
        }

        public void TryReStart()
        {
            if (IsStart) {
                if (Connection != null)
                    Connection.Dispose();
                initConnect();
                initChannel();                      
            }
            else
                Start();
        }

        public void CloseAllChannels()
        {
            foreach (string key in dicChannel.Keys)
                dicChannel[key].Channel.Dispose();
        }
    }
}
