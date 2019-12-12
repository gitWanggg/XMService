using System;
using System.Collections.Generic;
using System.Text;
using Model.SP.IDBuilder;
namespace BLL.SP.IDBuilder.Impl
{
    class HardDiskCreater : BaseCreater
    {
       
        public HardDiskCreater(int id)
            :base(id)
        {
            
        }

        protected override int Next()
        {
            int nid = 0;
            using (DBIDBuilderContext context = new DBIDBuilderContext()) {
                IDSeed idS = context.IDSeed.Find(this.ID);
                if (idS.SeedDay.ToString("yyMMdd") != DateTime.Now.ToString("yyMMdd")) {
                    idS.SeedDay = DateTime.Now.Date;                    
                    idS.RefreshTime = DateTime.Now;
                    base.SettingYesDay(context, this.ID, idS.DayCount);
                    idS.DayCount = 0;
                }
                idS.DayCount += 1;
                idS.TotalCount += 1;
                nid = idS.DayCount;
                context.Entry<IDSeed>(idS).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            return nid;
        }

        protected override int NextTotal()
        {
            int nid = 0;
            using (DBIDBuilderContext context = new DBIDBuilderContext()) {
                IDSeed idS = context.IDSeed.Find(this.ID);
                
                idS.TotalCount += 1;
                nid = idS.TotalCount;
                context.Entry<IDSeed>(idS).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            return nid;
        }
    }
}
