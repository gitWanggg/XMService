using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleX.MQ
{
    public interface IMQHandler
    {
        void Hand(BasicDeliverEventArgs DE);
    }
}
