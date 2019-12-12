using System;
using System.Collections.Generic;
using System.Text;
using Model.SP.IDBuilder;
namespace BLL.SP.IDBuilder
{
    /// <summary>
    /// 数据可持久化
    /// </summary>
    public interface IDBDurable
    {
        
        void Save();
    }
}
