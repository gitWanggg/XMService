using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX
{
    public interface ICommonRable
    {
        bool IsSuccess { get; }

        int RCode { get; set; }

        string ErrorMessage { get; set; }

        object Data { get; set; }
    }
}
