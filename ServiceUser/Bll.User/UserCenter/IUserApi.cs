using Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.User.UserCenter
{
    public interface IUserApi
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        UserInfo Find(string UserID);
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="NickName"></param>
        /// <returns></returns>
        string Add(string NickName);
    }
}
