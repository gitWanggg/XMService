using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AngleX.MQ.Core
{
    class MQHandlerFactory
    {
        public static IMQHandler Create(string HandlerType)
        {
            string[] typeArray = HandlerType.Split(',');
            Assembly assembly = Assembly.Load(typeArray[1]);
            if (assembly == null)
                throw new AngleX.CustomException("无法找到:" + typeArray[1]);
            Type tH = assembly.GetType(typeArray[0]);
            if (tH == null)
                throw new AngleX.CustomException("无法找到类型" + typeArray[0]);
            object objT = Activator.CreateInstance(tH, new object[] { });
            return objT as IMQHandler;
        }
    }
}
