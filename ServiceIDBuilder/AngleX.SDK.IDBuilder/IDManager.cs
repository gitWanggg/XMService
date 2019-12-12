using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.SDK.IDBuilder
{
    public static class IDManager
    {
        static IIDBuilder IDB;

        public static IIDBuilder Builder
        {
            get {
                return IDB;
            }
        }
        static IDManager()
        {
            IDB = new EurekaIDBuilderImpl();
        }
    }
}
