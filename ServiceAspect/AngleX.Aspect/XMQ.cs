using System;
using System.Collections.Generic;
using System.Text;

namespace AngleX.Aspect
{
    public class XMQ:XM
    {
        public int ID { get; set; }
        public int? ModeNum { get; set; }

        public int? MType { get; set; }

        public DateTime? CanSeekTime { get; set; }

        public int Top { get; set; }

        public XMQ()
        {

        }
        public XMQ(string BillID)
        {
            this.BizBillID = BillID;
        }
        public XMQ(string BillID,DateTime SeekTime)
            :this(BillID)
        {
            this.CanSeekTime = SeekTime;
        }
        public XMQ(string BillID,int MType, DateTime SeekTime)
           : this(BillID,SeekTime)
        {
            this.MType = MType;
        }
        public XMQ(string BillID,int MType)
            :this(BillID)
        {
            this.MType = MType;
        }
        public XMQ(string BillID, int MType,int ModeNum)
            : this(BillID,MType)
        {
            this.ModeNum = ModeNum;

        }
        
        public XMQ(string BillID,int MType,int ModeNum,DateTime SeekTime)
            :this(BillID,MType,ModeNum)
        {
            this.CanSeekTime = SeekTime;
        }
    }
}
