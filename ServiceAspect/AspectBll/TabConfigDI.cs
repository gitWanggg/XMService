using System;
using System.Collections.Generic;
using System.Text;
using AngleXCore.Sql;
namespace AspectBll
{
    public class TabConfigDI:ITabelConfig
    {
        Dictionary<string, TablePreConfig> DB;

        public TabConfigDI()
        {
            DB = new Dictionary<string, TablePreConfig>();
            objLock = new object();
        }
        object objLock;
        public TablePreConfig Find(string AppID)
        {
            if (!DB.ContainsKey(AppID)) {
                lock (objLock) {
                    if (!DB.ContainsKey(AppID)) {
                        TablePreConfig preConfig = findSQLDB(AppID);
                        if (preConfig == null)
                            preConfig = InsertSQLDB(AppID);
                        DB[AppID] = preConfig;
                    }
                }
            }           
            return DB[AppID];
        }
        TablePreConfig findSQLDB(string AppID)
        {
            System.Data.DataTable dtPreConfig = null;
            using (var con = SqlHelper.GetConnection(ConfigSetting.ConnectString)) {
                Dictionary<string, object> dicPars = new Dictionary<string, object>();
                dicPars.Add(SqlTemplate.RTAppid, AppID);
                dtPreConfig = SqlHelper.ExecuteDataset(con,SqlTemplate.SelectTableName, dicPars);               
            }
            if (dtPreConfig == null || dtPreConfig.Rows.Count < 1)
                return null;
            TablePreConfig tPre = new TablePreConfig();
            tPre.AppID = AppID;
            tPre.ID = Convert.ToInt32(dtPreConfig.Rows[0][TablePreConfigProName.ID]);
            tPre.InitStatus = Convert.ToInt32(dtPreConfig.Rows[0][TablePreConfigProName.InitStatus]);
            tPre.TableName = dtPreConfig.Rows[0][TablePreConfigProName.TableName].ToString();
            return tPre;
        }
        TablePreConfig InsertSQLDB(string AppID)
        {
            AngleX.Eureka.InstanceInfo insInfo = AngleX.Eureka.AppXContext.Server.Find(AppID);
            if (insInfo == null)
                throw new AngleX.CustomException("无法找到AppID为"+AppID+"的信息");
            int nID = 0;
            using (var con = SqlHelper.GetConnection(ConfigSetting.ConnectString)) {
                string sqlInsert = string.Format(SqlTemplate.InsertPreConfig, AppID, insInfo.AppName);
              
                System.Data.DataTable dtID = SqlHelper.ExecuteDataset(con,sqlInsert);
                nID = Convert.ToInt32(dtID.Rows[0][0]);
            }
            TablePreConfig tPre = new TablePreConfig();
            tPre.AppID = AppID;
            tPre.ID = nID;
            tPre.TableName = insInfo.AppName;
            return tPre;
        }


    }


}
