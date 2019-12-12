using Model.SP.IDBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.SP.IDBuilder.Impl
{
    public class SqlServerDBDurableImpl : IDBDurable
    {

        public IDSeed Seed { get; set; }


        public SqlServerDBDurableImpl(IDSeed seed)
        {
            this.Seed = seed;
        }

        public void Save()
        {
            using(DBIDBuilderContext db=new DBIDBuilderContext())
            {
                IDSeed seedDB = db.IDSeed.Find(this.Seed.ID);
                seedDB.DayCount = this.Seed.DayCount;
                seedDB.RefreshTime = DateTime.Now;
                seedDB.SeedDay = this.Seed.SeedDay;
                seedDB.TotalCount = this.Seed.TotalCount;
                db.Entry<IDSeed>(seedDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }


        }
    }
}
