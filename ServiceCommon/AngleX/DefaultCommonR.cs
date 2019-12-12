using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX
{
    public class DefaultCommonR : ICommonRable
    {
        public bool IsSuccess{get=> RCode == 0; }

        public int RCode { get; set; }
        public string ErrorMessage { get ; set ; }
        public object Data { get; set; }
    }
}
