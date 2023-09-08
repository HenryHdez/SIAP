--Selección de base de datos a utilizar
USE [sistencial_SE1]
GO

--Creación de la tabla de tipos de suelo
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conglomerado](
   [ConglomeradoId] [int] IDENTITY(1,1) NOT NULL,
   [DepartamentoId] [int] NOT NULL,
   [CodigoMapa] [int] NOT NULL,
   [Nombre] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Conglomerado] PRIMARY KEY CLUSTERED 
([ConglomeradoId] ASC)
)
GO

ALTER TABLE dbo.Conglomerado  WITH CHECK ADD
CONSTRAINT [FK_dbo.Conglomerado_dbo.Departamento_DepartamentoId] FOREIGN KEY([DepartamentoId])
REFERENCES dbo.Departamento (DepartamentoId)
ON DELETE CASCADE
GO

INSERT [dbo].[Conglomerado] ([DepartamentoId], [CodigoMapa], [Nombre]) VALUES (1,1,N'Conglomerado')
INSERT [dbo].[Conglomerado] ([DepartamentoId], [CodigoMapa], [Nombre]) VALUES (1,2,N'Conglomerado')
INSERT [dbo].[Conglomerado] ([DepartamentoId], [CodigoMapa], [Nombre]) VALUES (1,3,N'Conglomerado')
GO