using System;
using System.Collections.Generic;
using AngleX.Aspect;
namespace AspectTest
{
    class Program
    {
        static string appid = "10003";
        static void Main(string[] args)
        {
            
            AngleX.Test.AppMainStart.Start(null, null);


            // AngleX.AppXGlobal.IHttp.DownLoad("https://www.baidu.com/");


            //testmqSeek();
            testlog();
            testerror();
            testmqpush();
            Console.WriteLine("按任意键退出!");
            Console.ReadLine();
        }

        static void testlog()
        {
            string urlLog = "http://localhost:3737/api/log/add";
            XLog log = new XLog();
            log.AppID = appid;
            //log.BizBillID = "JJ001";
            //log.CategoryKey = "tabl0";
            log.TextContent = "ok000log0002''''---'''";

            try {
                string logID = AngleX.AppXGlobal.IHttp.PostData<string>(urlLog, log);
                Console.WriteLine("logID=" + logID);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void testerror()
        {
            string urlLog = "http://localhost:3737/api/error/add";
            XError err = new XError();
            err.AppID = appid;
            //err.BizBillID = "002";
            //err.CategoryKey = "c001";
            err.ExMessage = "文件00急急急";
           // err.ExStack = "jjj/jjjl.llljsjfsljflsjf";

            try {
                string logID = AngleX.AppXGlobal.IHttp.PostData<string>(urlLog, err);
                Console.WriteLine("errID=" + logID);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void testmqpush()
        {
            string urlLog = "http://localhost:3737/api/mq/push";
            XMQ q1 = new XMQ("from0002");
            q1.AppID = appid;
            q1.BizBillID = "003";
            q1.CanSeekTime = DateTime.Now;
            q1.ModeNum = 0;
            q1.MType = 0;


            XMQ q2 = new XMQ("form003");
            q2.AppID = appid;
            q2.CanSeekTime = DateTime.Now.AddMinutes(20);


            XMQ q3 = new XMQ("form000004");
            q3.AppID = appid;
            q3.ModeNum = 3;
            q3.MType = 2;
            


            try {
                string logID1 = AngleX.AppXGlobal.IHttp.PostData<string>(urlLog, q1);
                Console.WriteLine("q1=" + logID1);

                string logID2 = AngleX.AppXGlobal.IHttp.PostData<string>(urlLog, q2);
                Console.WriteLine("q2=" + logID2);

                string logID3 = AngleX.AppXGlobal.IHttp.PostData<string>(urlLog, q3);
                Console.WriteLine("q3=" + logID3);



            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }

        static void testmqSeek()
        {
            string urlLog = "http://localhost:3737/api/mq/Seek";
            XMQ mq1 = new XMQ();
            mq1.AppID = appid;
            mq1.Top = 5;
            mq1.MType = 0;
            List<XMQ> list = AngleX.AppXGlobal.IHttp.PostData<List<XMQ>>(urlLog, mq1);
            Console.WriteLine("list rows " + list.Count);
            foreach (XMQ q in list) {
                Console.WriteLine(q.ID);
                string urlDelete = string.Format("http://localhost:3737/api/mq/Delete/{0}/{1}", appid, q.ID);
                int nRows = AngleX.AppXGlobal.IHttp.PostData<int>(urlDelete, null);
                Console.WriteLine("delete r={0}", nRows);
            }
            
        }
    }
}
