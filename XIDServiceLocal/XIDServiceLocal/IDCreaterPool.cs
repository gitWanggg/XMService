using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XIDServiceLocal
{
    public class IDCreaterPool : IIDCreaterPool
    {
        Dictionary<string, IIDCreateable> DicCreater;

        public IDCreaterPool()
        {
            this.DicCreater = new Dictionary<string, IIDCreateable>();
        }
        object objLock = new object();
        public IIDCreateable Find(string Name)
        {
            if (DicCreater.ContainsKey(Name))
                return DicCreater[Name];
            return Add(Name);
        }
        IIDCreateable Add(string Name)
        {
            lock (objLock) {
                if (!DicCreater.ContainsKey(Name)) {                    
                    int seedID = FindSeed(Name);
                    if (seedID == 0)
                        seedID = AddSeed(Name);
                    IIDCreateable bc = new HardDiskCreater(seedID);
                    DicCreater[Name] = bc;
                    return bc;
                }
                return DicCreater[Name];
            }
        }
        int FindSeed(string Name)
        {
            using (DBIDBuilderContext db = new DBIDBuilderContext()) {
                return db.IDSeedName.Where(T => T.Name == Name).Select(T => T.ID).FirstOrDefault();
            }
        }
        int AddSeed(string Name)
        {
            int id = 0;
            using (DBIDBuilderContext db = new DBIDBuilderContext()) {

                IDSeedName Seed = new IDSeedName() {
                    Name = Name,
                    RefreshTime = DateTime.Now,
                    SeedDay = DateTime.Now.Date                     
                };
                db.IDSeedName.Add(Seed);
                db.SaveChanges();
                id = Seed.ID;
            }
            return id;
        }
    }
}
