USE [SEMapa]
GO

/****** Object:  Table [dbo].[Parametros]    Script Date: 01/09/2016 11:42:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Parametros](
	[ParametrosId] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [int] NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[NombreBD] [nvarchar](255) NULL,
	[Valor] [nvarchar](255) NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
 CONSTRAINT [PK_dbo.Parametros] PRIMARY KEY CLUSTERED 
(
	[ParametrosId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[Parametros]
ADD UNIQUE (Codigo)
GO

ALTER TABLE [dbo].[Parametros]
ADD UNIQUE (NombreBD)
GO