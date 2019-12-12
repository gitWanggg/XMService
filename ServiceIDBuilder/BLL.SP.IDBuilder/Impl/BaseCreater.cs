using Model.SP.IDBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.SP.IDBuilder.Impl
{
    public abstract class BaseCreater : IIDCreateable
    {
        static string fFlagNull = "0";
        static string fFlagTotal = "total";

        static string[] fArray = new string[]{"","0", "00", "000", "0000", "00000", "000000", "0000000", "00000000" };
        public int ID { get; set; }
        /// <summary>
        /// 数据最新时间
        /// </summary>
        public long TimeStampNewest { get; set; }
        protected BaseCreater(int ID)
        {
            this.ID = ID;
        }
        protected void SettingYesDay(DBIDBuilderContext context,int ID,int Count)
        {
           IDCounter ic = context.IDCounter.Find(ID);
            if (ic == null)
                return;
            ic.Count7 = ic.Count6;
            ic.Count6 = ic.Count5;
            ic.Count5 = ic.Count4;
            ic.Count4 = ic.Count3;
            ic.Count3 = ic.Count2;
            ic.Count2 = ic.Count1;
            ic.Count1 = Count;
            context.Entry<IDCounter>(ic).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        protected abstract int Next();

        protected abstract int NextTotal();

        object objLock = new object();
        public string NewID(string format)
        {
            lock (objLock) {
                if (format == fFlagTotal)
                    return NextTotal().ToString();
                int id = Next();
                if (format == fFlagNull || format == null)
                    return id.ToString();
                else {

                    try {
                        int nIndex = Convert.ToInt32(format);
                        return id.ToString(fArray[nIndex]);
                    }
                    catch {
                        return id.ToString();
                    }
                }
            }
            
        }
    }
}
