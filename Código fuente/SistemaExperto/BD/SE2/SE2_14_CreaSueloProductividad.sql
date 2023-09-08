-- Agrega nueva tabla para SueloProductividad - Productividad
-- Yaritza Cárdenas
-- 
USE [SEMapa]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON

--drop table [dbo].[Suelo]

--drop table [dbo].[SueloProductividad]

CREATE TABLE [dbo].[SueloProductividad](
	[SueloProductividadId] [int] IDENTITY(1,1) NOT NULL,
	[CC] [float] NOT NULL,
	[CCMenor] [float] NOT NULL,
	[CCMayor] [float] NOT NULL,
	[PMP] [float] NOT NULL,
	[PMPMenor] [float] NOT NULL,
	[PMPMayor] [float] NOT NULL,
	[Da] [float] NOT NULL,
	[DaMenor] [float] NOT NULL,
	[DaMayor] [float] NOT NULL,
	[TipoSueloId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SueloProductividad] PRIMARY KEY CLUSTERED 
(
	[SueloProductividadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[SueloProductividad]  WITH CHECK ADD CONSTRAINT [FK_dbo.SueloProductividad_dbo.TipoSuelo_TipoSueloId] FOREIGN KEY([TipoSueloId])
REFERENCES [dbo].[TipoSuelo] ([TipoSueloId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SueloProductividad] CHECK CONSTRAINT [FK_dbo.SueloProductividad_dbo.TipoSuelo_TipoSueloId]
GO

