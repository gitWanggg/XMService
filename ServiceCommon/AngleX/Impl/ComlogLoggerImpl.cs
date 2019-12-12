using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.Impl
{
    class ComlogLoggerImpl : ILogger
    {
        static string PathName = "logger";
        static string DebugName = "debugger";
        static string ErrorName = "error";
        static string InfoName = "info";
        string debugPath ;
        string errorPath ;
        string infoPath ;

        public ComlogLoggerImpl()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var directoryPath = System.IO.Path.Combine(path, PathName);
            if (!System.IO.Directory.Exists(directoryPath))
                System.IO.Directory.CreateDirectory(directoryPath);
            debugPath = System.IO.Path.Combine(directoryPath, DebugName);
            errorPath = System.IO.Path.Combine(directoryPath, ErrorName);
            infoPath = System.IO.Path.Combine(directoryPath, InfoName);
        }
        public void Debugger(string log)
        {

            writelinestime(debugPath, log);
        }

      
        public void Error(string log)
        {
            writelinestime(errorPath, log);
        }

        public void Error(Exception ex)
        {
            string log = "\t ex:"+ex.Message+"\r\n"+"\t statck:"+ex.StackTrace;
            Error(log);
        }

        public void Info(string log)
        {
            writetxt(infoPath, log);
        }
        void writetxt(string path,string log)
        {
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            string fname = System.IO.Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + ".txt");
            System.IO.File.AppendAllLines(fname, new string[] {log });
        }
        void writelinestime(string path, string log)
        {
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            string fname = System.IO.Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + ".txt");
            System.IO.File.AppendAllLines(fname, new string[] { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),log });
        }
    }
}
