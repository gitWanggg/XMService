using System;
using System.Collections.Generic;
using System.Text;
using Model.User;
using System.Linq;

namespace Bll.User.AuthCenter.Impl
{
    class AccountPwdAuthImpl : IAuthable
    {
        public AuthResult Auth(AuthRuest AuthQ)
        {
            if (AuthQ == null || string.IsNullOrEmpty(AuthQ.Account))
                throw new AngleX.CustomException("用户名不应为空");
            if (string.IsNullOrEmpty(AuthQ.Evidence))
                throw new AngleX.CustomException("输入密码不应为空");
            string md5Code = AngleX.EncodingHelper.ToMD5(AuthQ.Evidence);

            AuthResult authR = new AuthResult();
            using(UserDBContext db=new UserDBContext()) {
                authR.UserID = db.AuthAccount.Where(T => T.Account == AuthQ.Account)
                    .Where(T => T.PwdMD5 == md5Code)
                    .Select(T => T.ID)
                    .FirstOrDefault();                
            }
            if(string.IsNullOrEmpty(authR.UserID)) {
                authR.Code = 1;
                authR.ErrorMsg = "账户密码错误";
            }
            return authR;
        }

        public bool Bind(AuthRuest AuthQ)
        {
            if (AuthQ == null || string.IsNullOrEmpty(AuthQ.Account))
                throw new AngleX.CustomException("用户名不应为空");
            if (string.IsNullOrEmpty(AuthQ.Evidence))
                throw new AngleX.CustomException("输入密码不应为空");
            if (string.IsNullOrEmpty(AuthQ.UserID))
                throw new AngleX.CustomException("绑定用户不应为空");
            using(UserDBContext db=new UserDBContext()) {
                string existID = db.AuthAccount.Where(T => T.Account == AuthQ.Account).Select(T => T.ID).FirstOrDefault();
                if (!string.IsNullOrEmpty(existID))
                    throw new AngleX.CustomException("该用户名已存在");
                existID = db.AuthAccount.Where(t => t.ID == AuthQ.UserID).Select(t => t.ID).FirstOrDefault();
                if (!string.IsNullOrEmpty(existID))
                    throw new AngleX.CustomException("该用户名已存在");
                AuthAccount account = new AuthAccount();
                account.ID = AuthQ.UserID;
                account.EditTime = DateTime.Now;
                account.InputTime = DateTime.Now;
                account.PwdMD5 = AngleX.EncodingHelper.ToMD5(AuthQ.Evidence);
                account.Account = AuthQ.Account;
                db.AuthAccount.Add(account);
                db.SaveChanges();
            }
            return true;
        }

        public bool IsExist(string Account)
        {
            using (UserDBContext db = new UserDBContext()) {
                string existID = db.AuthAccount.Where(T => T.Account == Account).Select(T => T.ID).FirstOrDefault();
                return  !string.IsNullOrEmpty(existID);
            }
        }

        public bool UnBind(string ID)
        {
            using (UserDBContext db = new UserDBContext()) {
               AuthAccount auth = db.AuthAccount.Find(ID);
                if (auth == null)
                    throw new AngleX.CustomException("无法找到该类型");
                db.Entry<AuthAccount>(auth).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }
    }
}
