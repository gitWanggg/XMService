using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using AngleX;
using Bll.User.AuthCenter;
using Bll.User.UserCenter;
namespace Bll.User
{
    public class UserAccountService
    {
        public IAuthFactory IAuthFac { get; set; }

        public IUserApi IUser { get; set; }

        public UserAccountService(IAuthFactory auth,IUserApi userApi)
        {
            this.IAuthFac = auth;
            this.IUser = userApi;
        }
        /// <summary>
        /// 注册账户
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Pwd1"></param>
        /// <param name="Pwd2"></param>
        /// <returns></returns>
        public string RegAccount(string Account,string NickName,string Pwd1,string Pwd2)
        {
            if (string.IsNullOrEmpty(Account))
                throw new CustomException("账户不应为空");
            if (string.IsNullOrEmpty(Pwd1) || string.IsNullOrEmpty(Pwd2))
                throw new CustomException("请输入密码");
            if (Pwd1 != Pwd2)
                throw new CustomException("两次密码不一致");
            if (string.IsNullOrEmpty(NickName))
                throw new CustomException("昵称不应为空");
            IAuthable iAuth = IAuthFac.Create(EnumAuthType.账户密码);
            if (iAuth.IsExist(Account))
                throw new CustomException("已存在该用户名");           
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress)) {
                string uid = IUser.Add(NickName);
                iAuth.Bind(new AuthRuest() { Account=Account, Evidence=Pwd1, UserID=uid });
                scope.Complete();
                return uid;
            }
        }
    }
}
