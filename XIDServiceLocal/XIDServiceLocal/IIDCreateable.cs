using System;
using System.Collections.Generic;
using System.Text;

namespace XIDServiceLocal
{
    public interface IIDCreateable
    {
        string NewID(string format);
    }
}
