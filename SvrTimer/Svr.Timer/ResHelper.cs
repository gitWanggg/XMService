using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svr.Timer
{
    class ResHelper
    {
        public static string FindRes(string name)
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string filePath = currentPath + "res\\" + name;
            return filePath;
        }
    }
}
