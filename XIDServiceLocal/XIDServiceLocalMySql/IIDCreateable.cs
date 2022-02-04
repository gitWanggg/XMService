using System;
using System.Collections.Generic;
using System.Text;

namespace XIDServiceLocalMySql
{
    public interface IIDCreateable
    {
        string NewID(string format);
    }
}
