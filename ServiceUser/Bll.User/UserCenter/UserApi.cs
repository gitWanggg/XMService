using System;
using System.Collections.Generic;
using System.Text;
using Model.User;
using AngleX.SDK.IDBuilder;

namespace Bll.User.UserCenter
{
   public class UserApi:IUserApi
    {
        public string Add(string NickName)
        {
            using (UserDBContext db = new UserDBContext()) {
                UserInfo uInfo = new UserInfo();
                uInfo.ID = IDManager.Builder.NewID<UserInfo>();
                uInfo.InputTime = DateTime.Now;
                uInfo.NickName = NickName;
                db.UserInfo.Add(uInfo);
                db.SaveChanges();
                return uInfo.ID;
            }
        }

        public UserInfo Find(string UserID)
        {
            if (string.IsNullOrEmpty(UserID))
                return null;
            using (UserDBContext db = new UserDBContext()) {
                return db.UserInfo.Find(UserID);
            }
        }

    }
}
