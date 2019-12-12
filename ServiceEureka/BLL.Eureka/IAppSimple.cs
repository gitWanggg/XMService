using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Eureka
{
    public interface IAppSimple
    {
        /// <summary>
        /// 获取实例信息
        /// </summary>
        /// <param name="AppID"></param>
        /// <returns></returns>
        AngleX.Eureka.InstanceInfo Find(string AppID);
    }
}
