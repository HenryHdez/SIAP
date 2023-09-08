-- Agrega nuevas tablas para grupos - Iconos
-- Yaritza Cárdenas
-- 
USE [SEMapa]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON

--drop table [dbo].[Suelo]

--drop table [dbo].[GrupoCultivo]

CREATE TABLE [dbo].[GrupoCultivo](
	[GrupoCultivoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar] (250) NOT NULL,
 CONSTRAINT [PK_dbo.GrupoCultivo] PRIMARY KEY CLUSTERED 
(
	[GrupoCultivoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

CREATE TABLE [dbo].[EtapaGrupo](
	[EtapaGrupoId] [int] IDENTITY(1,1) NOT NULL,
	[GrupoCultivoId] [int] NOT NULL,
	[CultivoEtapaId] [int] NOT NULL,
	[RutaIcono] [varchar] (max) NOT NULL,
 CONSTRAINT [PK_dbo.EtapaGrupo] PRIMARY KEY CLUSTERED 
(
	[EtapaGrupoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[EtapaGrupo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EtapaGrupo_dbo.GrupoCultivo_GrupoCultivoId] FOREIGN KEY([GrupoCultivoId])
REFERENCES [dbo].[GrupoCultivo] ([GrupoCultivoId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EtapaGrupo] CHECK CONSTRAINT [FK_dbo.EtapaGrupo_dbo.GrupoCultivo_GrupoCultivoId]
GO


ALTER TABLE [dbo].[EtapaGrupo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EtapaGrupo_dbo.CultivoEtapa_CultivoEtapaId] FOREIGN KEY([CultivoEtapaId])
REFERENCES [dbo].[CultivoEtapa] ([CultivoEtapaId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EtapaGrupo] CHECK CONSTRAINT [FK_dbo.EtapaGrupo_dbo.CultivoEtapa_CultivoEtapaId]
GO
