using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace XIDServiceLocalMySql
{
    class HardDiskCreater:IIDCreateable
    {
       
        public int ID { get; set; }
     
        public HardDiskCreater(int ID)
        {
            this.ID = ID;
        }
       
        int Next()
        {
            int nid = 0;
            using (DBIDBuilderContext context = new DBIDBuilderContext()) {
                IDSeedName idS = context.IDSeedName.Where(T => T.ID == ID).FirstOrDefault();
                if (idS.SeedDay.ToString("yyMMdd") != DateTime.Now.ToString("yyMMdd")) {
                    idS.SeedDay = DateTime.Now.Date;
                    idS.RefreshTime = DateTime.Now;                   
                    idS.DayCount = 0;
                }
                idS.DayCount += 1;
                idS.TotalCount += 1;
                nid = idS.DayCount;
                context.Entry<IDSeedName>(idS).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            return nid;
        }

        int NextTotal()
        {
            int nid = 0;
            using (DBIDBuilderContext context = new DBIDBuilderContext()) {
                IDSeedName idS = context.IDSeedName.Where(T => T.ID == ID).FirstOrDefault();
                idS.TotalCount += 1;
                nid = idS.TotalCount;
                context.Entry<IDSeedName>(idS).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            return nid;
        }

        object objLock = new object();
        public string NewID(string format)
        {
            int id = 0;
            lock (objLock) {
                id = format == ConstR.fFlagTotal ? NextTotal() : Next();
            }
            try {
                int nIndex = Convert.ToInt32(format);
                return DateTime.Now.ToString("yyyyMMdd") + id.ToString(ConstR.fArray[nIndex]);
            }
            catch {
                return id.ToString();
            }            
        }
    }
}
