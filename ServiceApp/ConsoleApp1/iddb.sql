USE [X_AppService]
GO
/****** Object:  Table [dbo].[AppSecretLog]    Script Date: 03/02/2021 22:20:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppSecretLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AppID] [int] NOT NULL,
	[Secret] [nvarchar](100) NOT NULL,
	[InputTime] [datetime] NOT NULL,
 CONSTRAINT [PK_AppSecretLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppSecret]    Script Date: 03/02/2021 22:20:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppSecret](
	[ID] [int] NOT NULL,
	[Secret] [nvarchar](100) NOT NULL,
	[SecretPre] [nvarchar](100) NULL,
	[RefreshTime] [datetime] NOT NULL,
	[PreTime] [datetime] NOT NULL,
	[TimeOutTime] [datetime] NOT NULL,
 CONSTRAINT [PK_AppSecret] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppInfo]    Script Date: 03/02/2021 22:20:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppInfo](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AppType] [int] NOT NULL,
 CONSTRAINT [PK_AppInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_AppInfo_AppType]    Script Date: 03/02/2021 22:20:13 ******/
ALTER TABLE [dbo].[AppInfo] ADD  CONSTRAINT [DF_AppInfo_AppType]  DEFAULT ((0)) FOR [AppType]
GO
