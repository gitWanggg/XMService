using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX
{
    public static class AppXGlobal
    {
        public static IHttpExpress IHttp;

        public static ISerializeable ISer;

        public static ILogger ILog;

        public static IServiceProvider IAPP;
       

        public static void Init(IServiceProvider app)
        {
            IAPP = app;
            object iloger = app.GetService(typeof(ILogger));
            if (iloger != null)
                ILog = iloger as ILogger;
            object iSer = app.GetService(typeof(ISerializeable));
            if (iSer != null)
                ISer = iSer as ISerializeable;
            object ihttp = app.GetService(typeof(IHttpExpress));
            if (ihttp!= null)
                IHttp = ihttp as IHttpExpress;
        }
    }
}
