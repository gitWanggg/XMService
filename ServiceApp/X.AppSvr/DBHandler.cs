using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Model.XApp;

namespace X.AppSvr
{
    class DBHandler
    {
        public PreToken Find(int AppID)
        {
            using(DBXAppContext db=new DBXAppContext()) {
                return db.AppSecret.Where(T => T.ID == AppID)
                    .Select(T => new PreToken() {
                        ID = T.ID,
                        Secret = T.Secret,
                        SecretPre = T.SecretPre,
                        TimeOut = T.TimeOutTime
                    }).FirstOrDefault();
            }
        }
        object objlock;

        public DBHandler()
        {
            objlock = new object();
        }
        public void Refresh(int AppID,string Secret,DateTime RefreshTime,DateTime OutTime)
        {
            lock (objlock) {
                using (DBXAppContext context = new DBXAppContext()) {
                    var app = context.AppSecret.Where(T => T.ID == AppID).FirstOrDefault();
                    if (app == null) {
                        app = new AppSecret() {
                            ID = AppID,
                            RefreshTime = DateTime.Now,
                            SecretPre = Secret
                        };
                        context.Entry<AppSecret>(app).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                    else
                        context.Entry<AppSecret>(app).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    app.PreTime = app.RefreshTime;
                    app.SecretPre = app.Secret;
                    app.RefreshTime = RefreshTime;
                    app.Secret = Secret;
                    app.TimeOutTime = OutTime;

                    AppSecretLog log = new AppSecretLog() {
                        AppID = AppID,
                        Secret = Secret,
                        InputTime = DateTime.Now                         
                    };
                    context.AppSecretLog.Add(log);
                    context.SaveChanges();
                }
            }            
        }
    }
}
