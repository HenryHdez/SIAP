--Selección de base de datos a utilizar
USE [sistencial_SE1]
GO

--Creación de la tabla de tipos de suelo
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoSuelo](
	[TipoSueloId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TipoSuelo] PRIMARY KEY CLUSTERED 
([TipoSueloId] ASC)
)
GO

INSERT [dbo].[TipoSuelo] ([Nombre], [Descripcion]) VALUES (N'Arcilloso','')
INSERT [dbo].[TipoSuelo] ([Nombre], [Descripcion]) VALUES (N'Arcilloso arenoso','')
INSERT [dbo].[TipoSuelo] ([Nombre], [Descripcion]) VALUES (N'Arcilloso limoso','')
INSERT [dbo].[TipoSuelo] ([Nombre], [Descripcion]) VALUES (N'Franco arcilloso arenoso','')
INSERT [dbo].[TipoSuelo] ([Nombre], [Descripcion]) VALUES (N'Franco arcilloso','')
INSERT [dbo].[TipoSuelo] ([Nombre], [Descripcion]) VALUES (N'Franco arcilloso limoso','')
INSERT [dbo].[TipoSuelo] ([Nombre], [Descripcion]) VALUES (N'Limo','')
INSERT [dbo].[TipoSuelo] ([Nombre], [Descripcion]) VALUES (N'Franco limoso','')
INSERT [dbo].[TipoSuelo] ([Nombre], [Descripcion]) VALUES (N'Franco','')
INSERT [dbo].[TipoSuelo] ([Nombre], [Descripcion]) VALUES (N'Franco arenoso','')
INSERT [dbo].[TipoSuelo] ([Nombre], [Descripcion]) VALUES (N'Areno francoso','')
INSERT [dbo].[TipoSuelo] ([Nombre], [Descripcion]) VALUES (N'Arenoso','')
GO

--Se agrega columna a la tabla de Zonas con nueva variable TipoSuelo
ALTER TABLE dbo.Zona
ADD TipoSueloId INT NOT NULL DEFAULT 5
GO

ALTER TABLE dbo.Zona  WITH CHECK ADD
CONSTRAINT [FK_dbo.Zona_dbo.TipoSuelo_TipoSueloId] FOREIGN KEY([TipoSueloId])
REFERENCES dbo.TipoSuelo (TipoSueloId)
ON DELETE CASCADE
GO
