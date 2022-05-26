USE [master]
GO
/****** Object:  Database [dbFredyDevtest]    Script Date: 26/05/2022 18:21:23 ******/
CREATE DATABASE [dbFredyDevtest]
GO
USE [dbFredyDevtest]
GO
/****** Object:  Table [dbo].[tbTest]    Script Date: 26/05/2022 18:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbTest](
	[id] [bigint] NOT NULL,
	[name] [nvarchar](50) NULL,
	[phone] [nvarchar](30) NULL,
 CONSTRAINT [PK_tbTest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)) ON [PRIMARY]
GO
USE [master]
GO
