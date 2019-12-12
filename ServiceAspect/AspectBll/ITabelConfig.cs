using System;
using System.Collections.Generic;
using System.Text;

namespace AspectBll
{
    public interface ITabelConfig
    {
        TablePreConfig Find(string AppID);
    }
}
