USE [SEMapa]
GO

/****** Object:  Table [dbo].[SITB_RegEst]    Script Date: 27/12/2023 10:08:17 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SITB_RegEst](
	[Fecha] [datetime] NULL,
	[Estado_Est_1] [varchar](max) NULL,
	[Estado_Est_2] [varchar](max) NULL,
	[Estado_Est_3] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

