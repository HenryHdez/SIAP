USE [SEMapa]
GO

/****** Object:  Table [dbo].[SITB_Estacion]    Script Date: 27/12/2023 10:12:38 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SITB_Estacion](
	[Est_Id] [varchar](50) NOT NULL,
	[Mun_Desc] [varchar](150) NULL,
	[Est_MunId] [varchar](50) NULL,
	[Est_Latitud] [decimal](18, 0) NULL,
	[Est_Longitud] [decimal](18, 0) NULL,
	[Est_Elevacion] [decimal](18, 0) NULL,
	[Est_FechaIns] [varchar](50) NULL,
	[Est_Propietario] [varchar](50) NULL,
	[Est_Geometria] [geometry] NULL,
	[Est_Estado] [int] NULL,
	[Est_UsuarioReg] [varchar](50) NULL,
	[Est_FechaReg] [datetime] NULL,
	[Est_UsuarioMod] [varchar](50) NULL,
	[Est_FechaMod] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

