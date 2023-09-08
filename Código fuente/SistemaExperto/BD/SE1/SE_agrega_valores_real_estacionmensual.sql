USE [SE]
GO

ALTER TABLE [dbo].[EstacionMensual]
ADD TminReal float NOT NULL default 0
GO

ALTER TABLE [dbo].[EstacionMensual]
ADD TmaxReal float NOT NULL default 0
GO

ALTER TABLE [dbo].[EstacionMensual]
ADD PrecipitacionReal float NOT NULL default 0
GO

ALTER TABLE [dbo].[EstacionMensual]
ADD VientoReal float NOT NULL default 0
GO

ALTER TABLE [dbo].[EstacionMensual]
ADD EToReal float NOT NULL default 0
GO