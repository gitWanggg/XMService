using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.MQ.Core
{
    static class MQConnectFactory
    {
        public static IConnectionFactory Create(ServiceVMConfig vMConfig)
        {
            ConnectionFactory factory = new ConnectionFactory {
                AutomaticRecoveryEnabled = true,
                UserName = vMConfig.UserName,
                Password = vMConfig.Password,
                HostName = vMConfig.HostName,
                VirtualHost = vMConfig.VMHost,
                Port = vMConfig.Port
            };
            return factory;
        }
    }
}
