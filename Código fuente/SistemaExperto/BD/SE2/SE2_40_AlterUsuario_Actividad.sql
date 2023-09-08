USE [SEMapa]
--use sistencial_SEMapa
GO

SET ANSI_NULLS ON
GO
ALTER TABLE [dbo].Usuario ADD ActividadId int null 
go

Update [dbo].Usuario set ActividadId = 6;
go

ALTER TABLE [dbo].Usuario ALTER COLUMN ActividadId int not null;
go

--ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [DF__Usuario__Activid__00750D23]
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [DF__Usuario__Activid__76EBA2E9]
GO


ALTER TABLE [dbo].Usuario drop COLUMN Actividad;
---

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Usuario_dbo.Actividad_ActividadId] FOREIGN KEY([ActividadId])
REFERENCES [dbo].[Actividad] ([ActividadId])
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_dbo.Usuario_dbo.Actividad_ActividadId]
GO

