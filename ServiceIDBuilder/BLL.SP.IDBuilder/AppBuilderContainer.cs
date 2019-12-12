using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.SP.IDBuilder
{
    public class AppBuilderContainer
    {
        public string AppID { get; set; }

        public EnumSaveType ST { get; set; }

        public Dictionary<string, Impl.BaseCreater> DicCreater;

        public AppBuilderContainer(string AppID,EnumSaveType st)
        {
            ST = st;
            this.AppID = AppID;
            DicCreater = new Dictionary<string, Impl.BaseCreater>();
        }
        object objLock = new object();
        IIDCreateable Add(string Name)
        {
            lock (objLock) {
                if (!DicCreater.ContainsKey(Name)) {
                    int seedID = DBMasterOperator.Find(ST, AppID, Name);
                    if (seedID == 0)
                        seedID = DBMasterOperator.Add(ST, AppID, Name);
                    Impl.BaseCreater bc = null;
                    if (ST == EnumSaveType.HardDisk)
                        bc = new Impl.HardDiskCreater(seedID);
                    else
                        bc = new Impl.MemeryCreater(seedID);
                    DicCreater[Name] = bc;
                    return bc;
                }
                return DicCreater[Name];
            }
        }
        public IIDCreateable Find(string Name)
        {
            if (DicCreater.ContainsKey(Name))
                return DicCreater[Name];
            return Add(Name);
        }

    }
}
