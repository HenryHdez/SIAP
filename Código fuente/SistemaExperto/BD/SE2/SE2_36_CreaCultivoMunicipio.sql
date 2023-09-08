USE [SEMapa]
--USE [sistencial_SEMapa]
GO

SET ANSI_NULLS ON
GO
--drop table [dbo].[CultivoMunicipio]
go

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CultivoMunicipio](
	[CultivoMunicipioId] [int] IDENTITY(1,1) NOT NULL,
	[CultivoId] [int] NOT NULL,
	[MunicipioId] [int] NOT NULL,
	[RutaPracticaManejo] nvarchar (max) NULL,
 CONSTRAINT [PK_dbo.CultivoMunicipio] PRIMARY KEY CLUSTERED 
(
	[CultivoMunicipioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[CultivoMunicipio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CultivoMunicipio_dbo.Cultivo_CultivoId] FOREIGN KEY([CultivoId])
REFERENCES [dbo].[Cultivo] ([CultivoId])
GO

ALTER TABLE [dbo].[CultivoMunicipio] CHECK CONSTRAINT [FK_dbo.CultivoMunicipio_dbo.Cultivo_CultivoId]
GO

ALTER TABLE [dbo].[CultivoMunicipio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CultivoMunicipio_dbo.Municipio_MunicipioId] FOREIGN KEY([MunicipioId])
REFERENCES [dbo].[Municipio] ([MunicipioId])
GO

ALTER TABLE [dbo].[CultivoMunicipio] CHECK CONSTRAINT [FK_dbo.CultivoMunicipio_dbo.Municipio_MunicipioId]
GO