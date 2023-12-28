USE [SEMapa]
GO

/****** Object:  Table [dbo].[SITB_RegEst]    Script Date: 27/12/2023 10:08:19 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SITB_RegEst](
	[Fecha] [datetime] NULL,
	[SIAP01] [varchar](max) NULL,
	[SIAP02] [varchar](max) NULL,
	[SIAP03] [varchar](max) NULL,
	[ZentraVar] [varchar](max) NULL,
	[ZentraET0] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO