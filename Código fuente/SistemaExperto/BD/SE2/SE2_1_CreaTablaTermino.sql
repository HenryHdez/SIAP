USE [SEMapa]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Termino](
	[TerminoId] [int] IDENTITY(1,1) NOT NULL,
	[NombreTermino] [nvarchar](max) NOT NULL,
	[Codigo] [nvarchar](5) NOT NULL,
	[Comodin] [nvarchar](20) NOT NULL,
	[DefinicionBreve] [nvarchar](max) NULL,
	[DefinicionAmplia] [nvarchar](max) NULL,
	[Fuente] [nvarchar](max) NULL,
	[InformacionApoyo] [nvarchar](max) NULL,
	[Etiquetas] [nvarchar](max) NULL,
	[Orden] [int] NULL,
	[CodigoPadreId] [int] NULL,
 CONSTRAINT [PK_dbo.Termino] PRIMARY KEY CLUSTERED 
(
	[TerminoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Termino]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Termino_dbo.Termino_CodigoPadreId] FOREIGN KEY([CodigoPadreId])
REFERENCES [dbo].[Termino] ([TerminoId])
GO

ALTER TABLE [dbo].[Termino] CHECK CONSTRAINT [FK_dbo.Termino_dbo.Termino_CodigoPadreId]
GO