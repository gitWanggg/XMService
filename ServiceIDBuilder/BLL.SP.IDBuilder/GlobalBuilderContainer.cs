using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.SP.IDBuilder
{
    public static class GlobalBuilderContainer
    {
        static Dictionary<string, AppBuilderContainer>  HardDisk;

        static Dictionary<string, AppBuilderContainer>  Memery;

        static object objLockHard;

        static object objLockMemery;
        static GlobalBuilderContainer()
        {
            HardDisk = new Dictionary<string, AppBuilderContainer>();
            Memery = new Dictionary<string, AppBuilderContainer>();
            objLockHard = new object();
            objLockMemery = new object();
        }
        
        public static AppBuilderContainer FindHard(string AppID)
        {
            if (HardDisk.ContainsKey(AppID))
                return HardDisk[AppID];
            lock (objLockHard) {
                if (!HardDisk.ContainsKey(AppID)) {
                    HardDisk[AppID] = new AppBuilderContainer(AppID,EnumSaveType.HardDisk);
                }
                return HardDisk[AppID];
            }
        }

        public static string[] MemeryAllKeys()
        {
            int nLen = Memery.Keys.Count;
            if (nLen < 1)
                return null;
            string[] keys = new string[nLen];
            Memery.Keys.CopyTo(keys, 0);
            return keys;
        }
        public static string[] HardAllKeys()
        {
            int nLen = HardDisk.Keys.Count;
            if (nLen < 1)
                return null;
            string[] keys = new string[nLen];
            HardDisk.Keys.CopyTo(keys, 0);
            return keys;
        }
        public static AppBuilderContainer FindMemery(string AppID)
        {
            if (Memery.ContainsKey(AppID))
                return Memery[AppID];
            lock (objLockMemery) {
                if (!Memery.ContainsKey(AppID)) {
                    Memery[AppID] = new AppBuilderContainer(AppID,EnumSaveType.Memery);
                }
                return Memery[AppID];
            }
        }
    }
}
