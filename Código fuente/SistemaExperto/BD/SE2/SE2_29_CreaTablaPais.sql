USE [SEMapa]
GO

/****** Object:  Table [dbo].[Pais]    Script Date: 13/11/2016 16:19:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pais](
	[PaisId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo.Pais] PRIMARY KEY CLUSTERED 
(
	[PaisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

