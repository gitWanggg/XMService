using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.SP.IDBuilder
{
    public interface IAPIActionIDBuilder
    {

        string Memery(string AppID, string Name, string Format);

        string Hard(string AppID, string Name, string Format);

        void Back(string AppID, string Name);
    }
}
