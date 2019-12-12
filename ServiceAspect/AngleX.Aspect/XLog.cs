using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.Aspect
{
    public class XLog:XM
    {
        public string CategoryKey { get; set; }

       

        public string TextContent { get; set; }

        public XLog()
        {

        }
        public XLog(string Text)
        {
            this.TextContent = Text;
        }
        public XLog(string CateKey,string Text)
        {
            this.CategoryKey = CateKey;
            this.TextContent = Text;
        }
        public XLog(string CateKey,string BillID, string Text)
        {
            this.CategoryKey = CateKey;
            this.TextContent = Text;
            this.BizBillID = BillID;
        }
    }
}
