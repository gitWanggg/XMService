using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.MQ.Core
{
    /// <summary>
    /// 通道管理
    /// </summary>
    class MQChannelManager
    {
        public IConnection MQConn { get; set; }

        public MQChannelManager(IConnection conn)
        {
            this.MQConn = conn;
        }

        /// <summary>
        ///  创建消息通道
        /// </summary>
        /// <param name="cfg"></param>
        public MQChannel CreateReceiveChannel(string exchangeType, string exchange, string queue, string routekey)
        {
            IModel model = this.CreateModel(exchangeType, exchange, queue, routekey);
            //model.BasicQos(0, 1, false);
            EventingBasicConsumer consumer = this.CreateConsumer(model, queue);
            MQChannel channel = new MQChannel(exchangeType, exchange, queue, routekey) {
                Connection = this.MQConn,
                Consumer = consumer
            };
            consumer.Received += channel.Receive;
            channel.Channel = model;
            return channel;
        }

        public MQChannel CreatePublishChannel(string exchange)
        {
            IModel model = this.MQConn.CreateModel();
            model.ExchangeDeclare(exchange, ExchangeType.Topic, false, false, null);
            MQChannel channel = new MQChannel(ExchangeType.Topic, exchange, null, null) {
                Connection = this.MQConn,
                Channel = model
            };
            return channel;
        }

        /// <summary>
        ///  创建一个通道，包含交换机/队列/路由，并建立绑定关系
        /// </summary>
        /// <param name="type">交换机类型</param>
        /// <param name="exchange">交换机名称</param>
        /// <param name="queue">队列名称</param>
        /// <param name="routeKey">路由名称</param>
        /// <returns></returns>
        private IModel CreateModel(string type, string exchange, string queue, string routeKey, IDictionary<string, object> arguments = null)
        {
            type = string.IsNullOrEmpty(type) ? "default" : type;
            IModel model = this.MQConn.CreateModel();
            model.BasicQos(0, 1, false);
            model.QueueDeclare(queue, true, false, false, arguments);
            model.ExchangeDeclare(exchange, ExchangeType.Topic, false, false, null);
            model.QueueBind(queue, exchange, routeKey);
            return model;
        }

        /// <summary>
        ///  接收消息到队列中
        /// </summary>
        /// <param name="model">消息通道</param>
        /// <param name="queue">队列名称</param>
        /// <param name="callback">订阅消息的回调事件</param>
        /// <returns></returns>
        private EventingBasicConsumer CreateConsumer(IModel model, string queue)
        {
            EventingBasicConsumer consumer = new EventingBasicConsumer(model);
            model.BasicConsume(queue, false, consumer);

            return consumer;
        }
    }
}
