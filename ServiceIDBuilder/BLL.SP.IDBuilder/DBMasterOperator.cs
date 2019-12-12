using System;
using System.Collections.Generic;
using System.Text;
using Model.SP.IDBuilder;
using System.Linq;
namespace BLL.SP.IDBuilder
{
    public class DBMasterOperator
    {
        public static int MasterID
        {
            get {
                return ConstR.MASTERID;
            }
        }

        static object objLock = new object();

        public static int Add(EnumSaveType SaveT, string AppID, string Name)
        {
            lock(objLock) {
                int nSave = (int)SaveT;
               return AddCore(nSave, AppID, Name);
            }
        }
        public static int Find(EnumSaveType SaveT, string AppID, string Name)
        {
            int nT = (int)SaveT;
            using (DBIDBuilderContext db = new DBIDBuilderContext()) {
                return db.IDSeedName.Where(T => T.AppID == AppID).Where(T => T.Name == Name).Where(T => T.DurableTye == nT)
                     .Select(T => T.ID).FirstOrDefault();
            }
        }
        static int AddCore(int SaveT,string AppID,string Name)
        {
            int id = 0;
            using(DBIDBuilderContext db=new DBIDBuilderContext()) {

                id=db.IDSeedName.Where(T => T.AppID == AppID).Where(T => T.Name == Name)
                    .Where(T => T.DurableTye == SaveT).Select(T => T.ID).FirstOrDefault();
                if (id == 0) {
                   IDSeed masterSeed = db.IDSeed.Find(MasterID);
                   if (masterSeed == null)
                        throw new KeyNotFoundException("系统数据丢失或异常，无master key");
                    masterSeed.TotalCount += 1;
                    id = masterSeed.TotalCount;

                    db.Entry<IDSeed>(masterSeed).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    IDSeedName seedName = new IDSeedName();
                    seedName.AppID = AppID;
                    seedName.DurableTye = SaveT;
                    seedName.Name = Name;
                    seedName.ID = id;
                    db.IDSeedName.Add(seedName);

                    IDSeed seed = new IDSeed();
                    seed.DayCount = 0;
                    seed.ID = id;
                    seed.RefreshTime = DateTime.Now;
                    seed.SeedDay = DateTime.Now.Date;
                    seed.TotalCount = 0;
                    db.IDSeed.Add(seed);


                    IDCounter seedCount = new IDCounter();
                    seedCount.ID = id;
                    db.IDCounter.Add(seedCount);

                    db.SaveChanges();
                    
                }
                
           
            }
            return id;
        }
    }
}
