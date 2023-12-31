-- Agrega tabla para estaciones productividad (antes cultivocoeficientesdiario)
-- Yaritza Cárdenas
-- 
USE [SEMapa]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
/*solo va para desarrollo el drop dado a cambio de nombre de tabla en desarrollo*/
--DROP TABLE CultivoCoeficientesDIario
--GO


CREATE TABLE [dbo].[EstacionProductividad](
	[EstacionProductividadId] [int] IDENTITY(1,1) NOT NULL,
	[EstacionId] [int] NOT NULL,	
	[Fecha] [datetime] NOT NULL,
	[Precipitacion] [float] NOT NULL,
	[TMax] [float] NOT NULL,
	[TMin] [float] NOT NULL,	
	[AnioTipo] nvarchar(max) NULL,
	
 CONSTRAINT [PK_dbo.EstacionProductividad] PRIMARY KEY CLUSTERED 
(
	[EstacionProductividadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[EstacionProductividad]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EstacionProductividad_dbo.Estacion_EstacionId] FOREIGN KEY([EstacionId])
REFERENCES [dbo].[Estacion] ([EstacionId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EstacionProductividad] CHECK CONSTRAINT [FK_dbo.EstacionProductividad_dbo.Estacion_EstacionId]
GO