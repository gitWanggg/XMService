using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.SP.IDBuilder
{
    public interface IIDCreateable
    {
        string NewID(string format);
    }
}
