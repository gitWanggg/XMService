using AngleXCore.Sql;
using System;
using System.Collections.Generic;
using System.Text;
using AngleX.Aspect;
namespace AspectBll
{
    public class TablePreConfig
    {
        public int ID { get; set; }

        public string AppID { get; set; }

        public string TableName { get; set; }

        public int InitStatus { get; set; }

        public bool IsInitLog
        {
            get {
                return (InitStatus & EnumInitTableStatus.XLog) == EnumInitTableStatus.XLog;
            }
        }
        public bool IsInitError
        {
            get {
                return (InitStatus & EnumInitTableStatus.XError) == EnumInitTableStatus.XError;
            }
        }
        public bool IsInitMQ
        {
            get {
                return (InitStatus & EnumInitTableStatus.XMQ) == EnumInitTableStatus.XMQ;
            }
        }
        object objLock;

        public TablePreConfig()
        {
            objLock = new object();
        }

        public void InitLog()
        {
            lock (objLock) {
                if (IsInitLog)
                    return;
                string sql = string.Format(SqlTemplate.InitXLog, this.TableName);
                using (var con = SqlHelper.GetConnection(ConfigSetting.ConnectString)) {
                    SqlHelper.ExecuteNonQuery(con, sql);
                    string sqlupdate = string.Format(SqlTemplate.UpdatePreConfigStatus, this.ID, (int)EnumInitTableStatus.XLog);
                    SqlHelper.ExecuteNonQuery(con, sqlupdate);
                }
                InitStatus |= EnumInitTableStatus.XLog;
            }
        }
        public void InitError()
        {
            lock (objLock) {
                if (IsInitError)
                    return;
                string sql = string.Format(SqlTemplate.InitXError, this.TableName);
                using (var con = SqlHelper.GetConnection(ConfigSetting.ConnectString)) {
                    SqlHelper.ExecuteNonQuery(con, sql);
                    string sqlupdate = string.Format(SqlTemplate.UpdatePreConfigStatus, this.ID, (int)EnumInitTableStatus.XError);
                    SqlHelper.ExecuteNonQuery(con, sqlupdate);
                }
                InitStatus |= EnumInitTableStatus.XError;
            }
        }
        public void InitMQ()
        {
            lock (objLock) {
                if (IsInitMQ)
                    return;
                string sql = string.Format(SqlTemplate.InitXMQ, this.TableName);
                using (var con = SqlHelper.GetConnection(ConfigSetting.ConnectString)) {
                    SqlHelper.ExecuteNonQuery(con, sql);
                    string sqlupdate = string.Format(SqlTemplate.UpdatePreConfigStatus, this.ID, (int)EnumInitTableStatus.XMQ);
                    SqlHelper.ExecuteNonQuery(con, sqlupdate);
                }
                InitStatus |= EnumInitTableStatus.XMQ;
            }
        }

        public string AddLog(string CategoryKey,string BizBillID,string Text)
        {
            if (!IsInitLog)
                InitLog();
            string txt = string.IsNullOrEmpty(Text) ? "" : Text.Length > 1024 ? Text.Substring(0, 1024) : Text;
            if (CategoryKey == null)
                CategoryKey = "";
            if (BizBillID == null)
                BizBillID = "";
            Dictionary<string, object> dicPars = new Dictionary<string, object>();
            dicPars.Add(SqlTemplate.RTCateKey, CategoryKey);
            dicPars.Add(SqlTemplate.RTBizID, BizBillID);
            dicPars.Add(SqlTemplate.RTTextContent, txt);
            string sqlInsert = string.Format(SqlTemplate.InsertLog, TableName, MonthCode());
            using (var con = SqlHelper.GetConnection(ConfigSetting.ConnectString)) {
               
                System.Data.DataTable dtIDs = SqlHelper.ExecuteDataset(con, sqlInsert, dicPars);
                return dtIDs.Rows[0][0].ToString();
            }
        }
        int MonthCode()
        {
            return Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
        }
        public string AddError(string CategoryKey, string BizBillID, string ExMsg,string ExStack)
        {
            if (!IsInitError)
                InitError();
            if (CategoryKey == null)
                CategoryKey = "";
            if (BizBillID == null)
                BizBillID = "";
            if (ExMsg == null)
                ExMsg = "";
            if (ExStack == null)
                ExStack = "";
            Dictionary<string, object> dicPars = new Dictionary<string, object>();
            dicPars.Add(SqlTemplate.RTCateKey, CategoryKey);
            dicPars.Add(SqlTemplate.RTBizID, BizBillID);
            dicPars.Add(SqlTemplate.RTMsg, ExMsg);
            dicPars.Add(SqlTemplate.RTStack, ExStack);
            string sqlInsert = string.Format(SqlTemplate.InsertError, TableName, MonthCode());
            using (var con = SqlHelper.GetConnection(ConfigSetting.ConnectString)) {
              
                System.Data.DataTable dtIDs = SqlHelper.ExecuteDataset(con, sqlInsert, dicPars);
                return dtIDs.Rows[0][0].ToString();
            }

        }
        public string PushMQ(string BizBillID,int ModeNum,int MType,string SeekTime)
        {
            if (!IsInitMQ)
                InitMQ();
            Dictionary<string, object> dicPars = new Dictionary<string, object>();
            dicPars.Add(SqlTemplate.RTSeek, SeekTime);
            dicPars.Add(SqlTemplate.RTBizID, BizBillID);
            string sqlInsert = string.Format(SqlTemplate.InsertMQ, TableName, ModeNum, MType);
            using (var con = SqlHelper.GetConnection(ConfigSetting.ConnectString)) {
               
                System.Data.DataTable dtIDs = SqlHelper.ExecuteDataset(con, sqlInsert, dicPars);
                return dtIDs.Rows[0][0].ToString();
            }
        }

        public List<XMQ> PopMQ(int Top,int? MType,int? ModeNum)
        {
            if (Top < 1)
                Top = 1;
            if (Top > 200)
                Top = 200;
            List<XMQ> listM = new List<XMQ>();
            System.Data.DataTable dtRows = null;
            string sqlSelect = string.Format(SqlTemplate.SelectMQ, TableName, Top);
            if (MType != null)
                sqlSelect += string.Format(SqlTemplate.WhereMType, MType.Value);
            if (ModeNum != null)
                sqlSelect += string.Format(SqlTemplate.WhereModel, ModeNum.Value);
            using (var con = SqlHelper.GetConnection(ConfigSetting.ConnectString)) {               
                dtRows = SqlHelper.ExecuteDataset(con, sqlSelect);
            }
            if (dtRows != null && dtRows.Rows.Count > 0) {
                foreach(System.Data.DataRow drItem in dtRows.Rows) {
                    XMQ xm = new XMQ(drItem[TablePreConfigProName.BizBillID].ToString());
                    xm.CanSeekTime = Convert.ToDateTime(drItem[TablePreConfigProName.CanSeekTime]);
                    xm.ID = Convert.ToInt32(drItem[TablePreConfigProName.ID]);
                    xm.ModeNum = Convert.ToInt32(drItem[TablePreConfigProName.ModeNum]);
                    xm.MType = Convert.ToInt32(drItem[TablePreConfigProName.MType]);
                    listM.Add(xm);
                }
            }
            return listM;
        }

        public void Delete(int ID)
        {
            string sqlDel = string.Format(SqlTemplate.RemoveMQ, TableName, ID);
            using (var con = SqlHelper.GetConnection(ConfigSetting.ConnectString)) {                               
                SqlHelper.ExecuteNonQuery(con, sqlDel);
            }
        }


    }
}
