-- Agrega tabla para productividasd
-- Yaritza Cárdenas
-- 
USE [SEMapa]
GO

SET ANSI_NULLS ON
GO
--DROP TABLE [CultivoProductividad]
--GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CultivoProductividad](
	[CultivoProductividadId] [int] IDENTITY(1,1) NOT NULL,
	[CultivoId] [int] NOT NULL,
	[AMP] [float] NOT NULL,
	[ADT] [float] NOT NULL,
	[AFA] [float] NOT NULL,
	[KyInicial] [float] NOT NULL,
	[KyDesarrollo] [float] NOT NULL,
	[KyMedio] [float] NOT NULL,
	[KyFinal] [float] NOT NULL,
	[EtapaInicial] [int]  NULL,
	[EtapaDesarrollo] [int]  NULL,
	[EtapaMedio] [int]  NULL,
	[EtapaFinal] [int]  NULL,
	[InicialCC] [float] NULL,	
	[IndicaCalculaKCFormula] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CultivoProductividad] PRIMARY KEY CLUSTERED 
(
	[CultivoProductividadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CultivoProductividad]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CultivoProductividad_dbo.Cultivo_CultivoId] FOREIGN KEY([CultivoId])
REFERENCES [dbo].[Cultivo] ([CultivoId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CultivoProductividad] CHECK CONSTRAINT [FK_dbo.CultivoProductividad_dbo.Cultivo_CultivoId]
GO