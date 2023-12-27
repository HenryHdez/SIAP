USE [SEMapa]
GO

/****** Object:  Table [dbo].[SITB_RegIng]    Script Date: 27/12/2023 10:08:34 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SITB_RegIng](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[Modulo] [text] NULL,
	[Submodulo] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

