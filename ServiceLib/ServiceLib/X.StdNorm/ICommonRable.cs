using System;
using System.Collections.Generic;
using System.Text;

namespace X.StdNorm
{
    public interface ICommonRable
    {
        bool IsSuccess { get; }

        int RCode { get; set; }

        string ErrorMessage { get; set; }

        object Data { get; set; }
    }
}
