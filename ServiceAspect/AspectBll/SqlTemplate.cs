using System;
using System.Collections.Generic;
using System.Text;

namespace AspectBll
{
    public static class SqlTemplate
    {        
        #region 表
        public static readonly string InitXError = @"IF NOT  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[XError_{0}]') AND type in (N'U'))
                                                        CREATE TABLE [dbo].[XError_{0}](
	                                                        [ID] [int] IDENTITY(1,1) NOT NULL,
	                                                        [MonthCode] [int] NOT NULL DEFAULT 0,
	                                                        [InpuTime] [datetime] NOT NULL,
	                                                        [CategoryKey] [nvarchar](50) NULL,
	                                                        [BizBillID] [nvarchar](50) NULL,
	                                                        [ExMessage] [nvarchar](max) NULL,
	                                                        [ExStack] [nvarchar](max) NULL,
                                                         CONSTRAINT [PK_XError_{0}] PRIMARY KEY CLUSTERED 
                                                        (
	                                                        [ID] ASC
                                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                                                        ) ON [PRIMARY]";

        public static readonly string InitXLog = @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[XLog_{0}]') AND type in (N'U'))
                                                    CREATE TABLE [dbo].[XLog_{0}](
	                                                    [ID] [int] IDENTITY(1,1) NOT NULL,
	                                                    [MonthCod] [int] NOT NULL DEFAULT 0,
	                                                    [InputTime] [datetime] NOT NULL,
	                                                    [CategoryKey] [nvarchar](50) NULL,
	                                                    [BizBillID] [nvarchar](50) NULL,
	                                                    [TextContent] [nvarchar](1024) NULL,
                                                     CONSTRAINT [PK_XLog_{0}] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [ID] ASC
                                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]
                                                    ";

        public static readonly string InitXMQ = @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[XMQ_{0}]') AND type in (N'U'))
                                                    CREATE TABLE [dbo].[XMQ_{0}](
	                                                    [ID] [int] IDENTITY(1,1) NOT NULL,
	                                                    [BizBillID] [nvarchar](50) NOT NULL,
	                                                    [InputTime] [datetime] NOT NULL,
	                                                    [ModeNum] [int] NOT NULL,
	                                                    [MType] [int] NOT NULL,
	                                                    [CanSeekTime] [datetime] NOT NULL,
                                                     CONSTRAINT [PK_XMQ_{0}] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [ID] ASC
                                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]";
        #endregion


        #region cmd
        public static readonly string InsertPreConfig = "INSERT INTO TablePreConfig([AppID],[TableName],InitStatus) output inserted.id  values('{0}','{1}',0)";

        public static readonly string UpdatePreConfigStatus = "update TablePreConfig SET InitStatus|={1} WHERE ID={0}";

        public static readonly string SelectTableName = "select TOP 1 [ID],[TableName],[InitStatus] FROM TablePreConfig WHERE AppID=@Appid";

        public static readonly string InsertLog = "INSERT INTO [XLog_{0}]( [MonthCod],[InputTime],[CategoryKey],[BizBillID],[TextContent]) output inserted.id VALUES ({1},GETDATE(),@CateKey,@BizID,@TextContent)";

        public static readonly string InsertError = "INSERT INTO XError_{0}([MonthCode],[InpuTime],[CategoryKey],[BizBillID],[ExMessage],[ExStack]) output inserted.id VALUES ({1},GETDATE(),@CateKey,@BizID,@Msg,@Stack)";

        public static readonly string InsertMQ = "INSERT INTO XMQ_{0}([BizBillID],[InputTime],[ModeNum],[MType],[CanSeekTime]) output inserted.id VALUES (@BizID,GETDATE(),{1},{2},@seek)";

        public static readonly string SelectMQ = "SELECT TOP {1} [ID],[BizBillID],[InputTime],[ModeNum],[MType],[CanSeekTime] FROM [XMQ_{0}] WHERE CanSeekTime<=GETDATE() ";

        public static readonly string WhereMType = " AND MType={0} ";
        public static readonly string WhereModel = "  AND ModeNum={0} ";
        public static readonly string RemoveMQ = "DELETE FROM XMQ_{0} WHERE ID={1}";
        #endregion

        #region @Name
        public static readonly string RTAppid = "@Appid";
        public static readonly string RTCateKey = "@CateKey";
        public static readonly string RTBizID = "@BizID";
        public static readonly string RTTextContent = "@TextContent";       
        public static readonly string RTMsg = "@Msg";
        public static readonly string RTStack = "@Stack";
        public static readonly string RTSeek = "@seek";
        public static readonly string RTMType = "@MType";
        public static readonly string RTMode = "@Mode";
        public static readonly string RTid = "@id";
        #endregion
    }
}

