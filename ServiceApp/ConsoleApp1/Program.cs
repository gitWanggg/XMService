﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using X.SDKApp;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "x_ts";
            string url = "http://www.ss.com/ss/ff?a=2&c=3&j=2&x_ts=3joosjfsAA";
            //string regx = "(^|&)" + a + "=([^&]*)(&|$)";
            string regx2 = "(^|&)x_ts=([^&]*)(&|$)";
            var match = Regex.Match(url, regx2, RegexOptions.IgnoreCase);
            if (match != null && match.Length > 2)
                Console.WriteLine(match.Groups[2].Value);
            else
                Console.WriteLine("null");
          
            Console.ReadLine();

        }
       static void TestIDBuilder()
        {
            JsonSer jsonSer = new JsonSer();
            XCloud.CreateXCloud(jsonSer);

            var service = XCloud.GetXService("10002");
            var api = service["idcreate"];
            Dictionary<string, string> dicAA = new Dictionary<string, string>();
            dicAA["appid"] = XCloud.Current.AppID;
            dicAA["name"] = typeof(Program).FullName;
            dicAA["format"] = "6";
            string r = api.Get(dicAA);
            Console.WriteLine(r);

        }
        static void exe1()
        {
            for (int i = 0; i < 2000; i++) {
                string id = XCloud.ApiExpress.NewID<Class1>(8);
                Console.WriteLine("class1"+id);
                System.Threading.Thread.Sleep(100);
            }
        }
        static void exe2()
        {
            for (int i = 0; i < 2000; i++) {
                string id = XCloud.ApiExpress.NewID<Program>(8);
                Console.WriteLine("class2" + id);
                System.Threading.Thread.Sleep(200);
            }
        }
        static void exe3()
        {
            for (int i = 0; i < 2000; i++) {
                string id = XCloud.ApiExpress.NewID<Class2>(8);
                Console.WriteLine("class3" + id);
                System.Threading.Thread.Sleep(300);
            }
        }
        static void exe4()
        {
            for (int i = 0; i < 2000; i++) {
                string id = XCloud.ApiExpress.NewID<Class3>(8);
                Console.WriteLine("class4" + id);
                System.Threading.Thread.Sleep(300);
            }
        }
        static void exe5()
        {
            for (int i = 0; i < 2000; i++) {
                string id = XCloud.ApiExpress.NewID<Class4>(8);
                Console.WriteLine("class5" + id);
                System.Threading.Thread.Sleep(300);
            }
        }
        static void exe6()
        {
            for (int i = 0; i < 2000; i++) {
                string id = XCloud.ApiExpress.NewID<Class5>(8);
                Console.WriteLine("class6" + id);
                System.Threading.Thread.Sleep(300);
            }
        }
        static void exe7()
        {
            for (int i = 0; i < 2000; i++) {
                string id = XCloud.ApiExpress.NewID<Class6>(8);
                Console.WriteLine("class7" + id);
                System.Threading.Thread.Sleep(300);
            }
        }
    }
}
