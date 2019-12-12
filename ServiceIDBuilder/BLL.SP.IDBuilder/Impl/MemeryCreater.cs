using System;
using System.Collections.Generic;
using System.Text;
using Model.SP.IDBuilder;
namespace BLL.SP.IDBuilder.Impl
{
    class MemeryCreater : BaseCreater,IDBDurable
    {
        int nQueueCount = 0;//待入队数量
       
        public IDSeed Seed { get; set; }
       
        public MemeryCreater(int ID)
            :base(ID)
        {
            initseed();
        }
        void initseed()
        {
            using (DBIDBuilderContext context = new DBIDBuilderContext()) {
                IDSeed idS = context.IDSeed.Find(this.ID);
                Seed = new IDSeed();
                Seed.DayCount = idS.DayCount;
                Seed.ID = this.ID;
                Seed.TotalCount = idS.TotalCount;
                Seed.SeedDay = idS.SeedDay;

            }
            ///初始化增量
        }
        protected override int Next()
        {
            if (Seed.SeedDay.ToString("yyMMdd") != DateTime.Now.ToString("yyMMdd")) {
                Save();
                using (DBIDBuilderContext db = new DBIDBuilderContext()) {
                    IDSeed seedDB = db.IDSeed.Find(this.Seed.ID);                    
                    Seed.RefreshTime = seedDB.RefreshTime = DateTime.Now;
                    Seed.SeedDay = seedDB.SeedDay = DateTime.Now.Date;
                    base.SettingYesDay(db, this.ID, seedDB.DayCount);
                    Seed.DayCount = seedDB.DayCount = 0;
                    db.Entry<IDSeed>(seedDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                nQueueCount = 0;
            }
            Seed.DayCount += 1;
            Seed.TotalCount += 1;
            nQueueCount += 1;
            return Seed.DayCount;
        }

        public void Save()
        {
            if (nQueueCount == 0)
                return;//
            int nAdd = nQueueCount;
            using (DBIDBuilderContext db = new DBIDBuilderContext()) {
                IDSeed seedDB = db.IDSeed.Find(this.Seed.ID);
                seedDB.DayCount += nAdd;
                db.Entry<IDSeed>(seedDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            nQueueCount -= nAdd;
            
        }

        protected override int NextTotal()
        {
            throw new NotImplementedException("该对象不支持Total属性");
        }
    }
}
