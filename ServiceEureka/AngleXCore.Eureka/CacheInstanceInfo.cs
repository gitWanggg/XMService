using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.Eureka
{
    class CacheInstanceInfo
    {
        static readonly long tsout = 1200000;//20分钟超时
        public long TS { get; set; }

        public InstanceInfo InsInfo { get; set; }

        public bool IsTimeOut
        {
            get {
                return AngleX.CommonHelper.getTimeStamp() - TS >= tsout;
            }
        }
        public CacheInstanceInfo(InstanceInfo insinfo)
        {
            this.InsInfo = insinfo;
            this.TS = AngleX.CommonHelper.getTimeStamp();
        }

    }
}
