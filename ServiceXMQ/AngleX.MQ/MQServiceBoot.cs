using System;
using System.Collections.Generic;
using System.Text;
using AngleX.MQ.Core;
namespace AngleX.MQ
{
    public class MQServiceBoot
    {
        public MQServiceManager Boot()
        {
            MQConfigRead Reader = new MQConfigRead();
            List<ServiceDomain> listDomains = Reader.Read();
            MQServiceManager mqM = new MQServiceManager();
            List<string> listNames = new List<string>();
            foreach(ServiceDomain dItem in listDomains) {
                if (string.IsNullOrEmpty(dItem.Name))
                    throw new CustomException("MQ服务名称不应为空");
                if (listNames.Contains(dItem.Name))
                    throw new CustomException("已存在键: "+dItem.Name);
                IService Iser = new XMQService(dItem.Name, dItem);
                mqM.AddService(dItem.Name, Iser);
            }
            return mqM;
        }
    }
}
