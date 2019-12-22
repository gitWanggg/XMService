using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Framing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.MQ.Core
{
   public class MQChannel
    {
        /// <summary>
        /// 通道标识
        /// </summary>
        public string Key { get; set; }
        public string ExchangeTypeName { get; set; }
        public string ExchangeName { get; set; }
        public string QueueName { get; set; }
        public string RoutekeyName { get; set; }
        public IConnection Connection { get; set; }
        public EventingBasicConsumer Consumer { get; set; }
        public IModel Channel { get; set; }
        /// <summary>
        ///  外部订阅消费者通知委托
        /// </summary>
        public IMQHandler OnReceivedCallback { get; set; }

        public MQChannel(string exchangeType, string exchange, string queue, string routekey)
        {
            this.ExchangeTypeName = exchangeType;
            this.ExchangeName = exchange;
            this.QueueName = queue;
            this.RoutekeyName = routekey;
            prop = new BasicProperties();
            prop.DeliveryMode = 1;
        }
        IBasicProperties prop;
        /// <summary>
        ///  向当前队列发送消息
        /// </summary>
        /// <param name="content"></param>
        public void Publish(string content,string route)
        {
            byte[] body = System.Text.Encoding.UTF8.GetBytes(content); // MQConnection.UTF8.GetBytes(content);           
            if (Channel.IsOpen)
                Channel.BasicPublish(this.ExchangeName, route, false, prop, body);
            else
                Console.WriteLine("close");
        }

        internal void Receive(object sender, BasicDeliverEventArgs e)
        {

            try {
                OnReceivedCallback?.Hand(e);
            }
            catch {

            }
            Channel?.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
        }

        /// <summary>
        ///  设置消息处理完成标志
        /// </summary>
        /// <param name="consumer"></param>
        /// <param name="deliveryTag"></param>
        /// <param name="multiple"></param>
        public void SetBasicAck(EventingBasicConsumer consumer, ulong deliveryTag, bool multiple)
        {
            consumer.Model.BasicAck(deliveryTag, multiple);
        }

        /// <summary>
        ///  关闭消息队列的连接
        /// </summary>
        public void Stop()
        {
            if (Channel != null)
                Channel.Dispose();
        }
    }
}
