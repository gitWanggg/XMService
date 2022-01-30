using System;
using System.Collections.Generic;
using System.Text;

namespace XIDServiceLocal
{
    public interface IIDCreaterPool
    {
        IIDCreateable Find(string Name);
    }
}
