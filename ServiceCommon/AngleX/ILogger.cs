using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX
{
    public interface ILogger
    {
        void Debugger(string log);        
        void Info(string log);
        void Error(string log);      
        void Error(Exception ex);
    }
}
