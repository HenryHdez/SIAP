-- Agrega nueva columna y nueva foranea para cultivo (grupos - Iconos)
-- Yaritza Cárdenas
-- 
USE [SEMapa]
GO

ALTER TABLE dbo.Cultivo
ADD [GrupoCultivoId] int NULL

ALTER TABLE [dbo].[Cultivo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cultivo_dbo.GrupoCultivo_GrupoCultivoId] FOREIGN KEY([GrupoCultivoId])
REFERENCES [dbo].[GrupoCultivo] ([GrupoCultivoId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Cultivo] CHECK CONSTRAINT [FK_dbo.Cultivo_dbo.GrupoCultivo_GrupoCultivoId]
GO
