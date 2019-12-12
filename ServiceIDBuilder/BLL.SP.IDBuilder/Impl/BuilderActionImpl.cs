using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.SP.IDBuilder.Impl
{
    public class BuilderActionImpl : IAPIActionIDBuilder
    {
        public void Back(string AppID, string Name)
        {
            
        }
        
        public string Hard(string AppID, string Name, string Format)
        {
            AppBuilderContainer appC = GlobalBuilderContainer.FindHard(AppID);
            IIDCreateable creater =  appC.Find(Name);
            return creater.NewID(Format);
        }

        public string Memery(string AppID, string Name, string Format)
        {
            AppBuilderContainer appC = GlobalBuilderContainer.FindMemery(AppID);
            IIDCreateable creater = appC.Find(Name);
            return creater.NewID(Format);
        }
    }
}
