using System;
using System.Collections.Generic;
using System.Text;
using Model.User;
namespace Bll.User
{
    public class SecretManage : ISecretable,IRefreshable
    {

        JwtSecret jwtS;
        public string SecretPre
        {
            get {
                if (jwtS == null)
                    loadSecret();
                return jwtS.SecretPre;
            }
        }

        public string SecretCurrent
        {
            get {
                if (jwtS == null)
                    loadSecret();
                return jwtS.SecretCurrent;
            }
        }

        void loadSecret()
        {
            using(UserDBContext db=new UserDBContext()) {
               JwtSecret jDb = db.JwtSecret.Find(ConstR.SecretID);
               if (jDb == null)
                    throw new AngleX.CustomException("jwt配置异常");
                jwtS = jDb;
            }
        }

        void refreshDB()
        {
            using (UserDBContext db = new UserDBContext()) {
                JwtSecret jDb = db.JwtSecret.Find(ConstR.SecretID);
                if (jDb == null)
                    throw new AngleX.CustomException("jwt配置异常");
                jDb.RefreshTime = DateTime.Now;
                jDb.SecretPre = jDb.SecretCurrent;
                jDb.SecretCurrent = UJwtHelper.getRandStringEx(ConstR.SecretLength);
                db.Entry<JwtSecret>(jDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Refresh()
        {
            if(jwtS==null)
                loadSecret();
            TimeSpan tsDiff = DateTime.Now - jwtS.RefreshTime;
            if ((int)tsDiff.TotalSeconds > ConstR.ReSecretSeconds) {
                refreshDB();
                loadSecret();
            }
        }
       
    }
}
