using System;
using System.Collections.Generic;
using System.Text;
using AngleX.MQ;
using RabbitMQ.Client.Events;

namespace MQDotCoreTest.MQHandler
{
    class SvrCommandHandler : IMQHandler
    {
        public void Hand(BasicDeliverEventArgs DE)
        {
            string txt =DE.RoutingKey+":" + System.Text.Encoding.UTF8.GetString(DE.Body);
            Console.WriteLine(txt);
        }
    }
}
