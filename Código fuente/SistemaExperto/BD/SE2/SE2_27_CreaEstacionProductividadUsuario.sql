-- Agrega tabla para estaciones productividad para cargue de usuarios
-- Yaritza Cárdenas
-- 
USE [SEMapa]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
--drop table EstacionProductividadUsuario

CREATE TABLE [dbo].[EstacionProductividadUsuario](
	[EstacionProductividadUsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,	
	[FechaSistema] [datetime] NOT NULL,
	[FechaProductividad] [datetime] NOT NULL,
	[Precipitacion] [float] NOT NULL,
	[TMax] [float] NOT NULL,
	[TMin] [float] NOT NULL,	
	
 CONSTRAINT [PK_dbo.EstacionProductividadUsuario] PRIMARY KEY CLUSTERED 
(
	[EstacionProductividadUsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO
