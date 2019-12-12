using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.Aspect
{
    public class XError:XM
    {
        public string CategoryKey { get; set; }        
        public string ExMessage { get; set; }

        public string ExStack { get; set; }

        public XError()
        {

        }
        public XError(string Msg)
        {
            ExMessage = Msg;
        }
        public XError(string CateKey,string Msg)
        {
            this.CategoryKey = CateKey;
            this.ExMessage = Msg;
        }
        public XError(Exception ex)
        {
            ExMessage = ex.Message;
            ExStack = ex.StackTrace;
        }
        public XError(string CateKey,Exception ex)
            :this(ex)
        {
            this.CategoryKey = CateKey;

        }
        public XError(string CateKey,string BillID,string Msg)
        {
            this.CategoryKey = CateKey;
            this.BizBillID = BillID;
            this.ExMessage = Msg;
        }
        public XError(string CateKey, string BillID,Exception ex)
            :this(ex)
        {
            this.CategoryKey = CateKey;
            this.BizBillID = BillID;            
        }
    }
}
