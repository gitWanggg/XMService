using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AngleX.Eureka
{
    public static class AppXContext
    {
        static readonly string fileInstance = "config\\XEurekaApp.ini";
        static readonly string fileServer = "config\\XEurekaServer.ini";
        static InstanceInfo _insInfo;

        static ServerInfo _serverinfo;

        static XRESTfulConfig _config;
        public static ServerInfo Server
        {
            get {
                if (_serverinfo == null)
                    InitServer();
                return _serverinfo;
            }
        }
        public static InstanceInfo Current
        {
            get 
            {
                if (_insInfo == null)
                    InitApp();
                return _insInfo;
            }
        }
        static object objLock3 = new object();
        public static XRESTfulConfig Config
        {
            get {
                if (_config == null) {
                    lock (objLock3) {
                        if (_config == null)
                            _config = new XRESTfulConfig();
                    }
                }
                return _config;
            }
        }
        static object objLock1 = new object();

        static object objLock2 = new object();
        static T InitT<T>(string file) where T:AppInfo,new()
        {
            T insEntity = new T();
            ReadINI r = new ReadINI();
            Dictionary<string, string> dicConfig = r.Read(file);
            Type type = typeof(T);

            System.Reflection.PropertyInfo[] proinfo = type.GetProperties(System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.Public
                );
            foreach (System.Reflection.PropertyInfo pItem in proinfo) {
                if (!dicConfig.ContainsKey(pItem.Name))
                    continue;
                object dynmicValue = System.ComponentModel.TypeDescriptor.GetConverter(pItem.PropertyType).ConvertFromString(dicConfig[pItem.Name]);//创建对象
                pItem.SetValue(insEntity, dynmicValue);
            }
            return insEntity;
        }
        
        static void InitApp()
        {
            lock (objLock1) {
                if (_insInfo == null) {
                    _insInfo = InitT<InstanceInfo>(fileInstance);
                }
            }
        }
        static void InitServer()
        {
            lock (objLock2) {
                if (_serverinfo == null) {
                    _serverinfo = InitT<ServerInfo>(fileServer);
                }
            }
        }
        private static void SetPropertyValue(object obj, string propertyName, string sValue)
        {
            PropertyInfo p = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (p != null) {
                object dynmicValue;

                if (p.PropertyType.IsArray)//数组类型,单独处理
                {
                    p.SetValue(obj, sValue, null);
                }
                else {
                    //根据属性类型动态转换属性的值
                    if (String.IsNullOrEmpty(sValue.ToString()))//空值
                        dynmicValue = p.PropertyType.IsValueType ? Activator.CreateInstance(p.PropertyType) : null;//值类型
                    else
                        dynmicValue = System.ComponentModel.TypeDescriptor.GetConverter(p.PropertyType).ConvertFromString(sValue.ToString());//创建对象

                    //调用属性的SetValue方法赋值
                    p.SetValue(obj, dynmicValue, null);
                }
            }
        }
    }
}
