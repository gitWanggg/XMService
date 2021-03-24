using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp.Tool
{
    class IXSignBuilder
    {
        static IXSign xSign;
        public static IXSign Builder()
        {
            return xSign;
        }
        static IXSignBuilder()
        {
            xSign = new XSignMD5();
        }
    }
}
