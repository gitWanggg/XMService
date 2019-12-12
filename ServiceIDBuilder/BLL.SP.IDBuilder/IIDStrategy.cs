using System;
using System.Collections.Generic;
using System.Text;
using Model.SP.IDBuilder;
namespace BLL.SP.IDBuilder
{
    interface IIDStrategy:IDBDurable
    {
        IDSeed Init(int ID);


    }
}
