-- Agrega tabla para CultivoDepartamento - Productividad
-- Yaritza Cárdenas
-- 
USE [SEMapa]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON

--Borra la tabla anterior, que ya no se necesita
--DROP TABLE CultivoMunicipio 

CREATE TABLE [dbo].[CultivoDepartamento](
	[CultivoDepartamentoId] [int] IDENTITY(1,1) NOT NULL,
	[DepartamentoId] [int] NOT NULL,	
	[CultivoProductividadId] [int] NOT NULL,
	
 CONSTRAINT [PK_dbo.CultivoDepartamento] PRIMARY KEY CLUSTERED 
(
	[CultivoDepartamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CultivoDepartamento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CultivoDepartamento_dbo.Departamento_DepartamentoId] FOREIGN KEY([DepartamentoId])
REFERENCES [dbo].[Departamento] ([DepartamentoId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CultivoDepartamento] CHECK CONSTRAINT [FK_dbo.CultivoDepartamento_dbo.Departamento_DepartamentoId]
GO

ALTER TABLE [dbo].[CultivoDepartamento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CultivoDepartamento_dbo.CultivoProductividad_CultivoProductividadId] FOREIGN KEY([CultivoProductividadId])
REFERENCES [dbo].[CultivoProductividad] ([CultivoProductividadId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CultivoDepartamento] CHECK CONSTRAINT [FK_dbo.CultivoDepartamento_dbo.CultivoProductividad_CultivoProductividadId]
GO