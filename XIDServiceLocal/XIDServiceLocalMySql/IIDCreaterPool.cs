using System;
using System.Collections.Generic;
using System.Text;

namespace XIDServiceLocalMySql
{
    public interface IIDCreaterPool
    {
        IIDCreateable Find(string Name);
    }
}
