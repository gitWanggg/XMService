using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.User.AuthCenter
{
    /// <summary>
    /// 鉴权接口
    /// </summary>
    public interface IAuthable
    {
        /// <summary>
        /// 鉴权
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        AuthResult Auth(AuthRuest AuthQ);
        /// <summary>
        /// 解除绑定
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        bool UnBind(string ID);
        /// <summary>
        /// 绑定
        /// </summary>
        /// <param name="AuthQ"></param>
        /// <returns></returns>
        bool Bind(AuthRuest AuthQ);
        /// <summary>
        /// 该账户是否已存在
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        bool IsExist(string Account);
    }
}
