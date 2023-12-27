USE [SEMapa]
GO

/****** Object:  Table [dbo].[ZentraVar]    Script Date: 27/12/2023 10:44:55 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ZentraVar](
	[Datetime] [nvarchar](200) NULL,
	[AirTemperature] [nvarchar](200) NULL,
	[AtmosphericPressure] [nvarchar](200) NULL,
	[BatteryPercent] [nvarchar](200) NULL,
	[BatteryVoltage] [nvarchar](200) NULL,
	[GustSpeed] [nvarchar](200) NULL,
	[LightningActivity] [nvarchar](200) NULL,
	[LightningDistance] [nvarchar](200) NULL,
	[LoggerTemperature] [nvarchar](200) NULL,
	[MaxPrecipRate] [nvarchar](200) NULL,
	[Precipitation] [nvarchar](200) NULL,
	[RHSensorTemp] [nvarchar](200) NULL,
	[ReferencePressure] [nvarchar](200) NULL,
	[SolarRadiation] [nvarchar](200) NULL,
	[VPD] [nvarchar](200) NULL,
	[VaporPressure] [nvarchar](200) NULL,
	[WindDirection] [nvarchar](200) NULL,
	[WindSpeed] [nvarchar](200) NULL,
	[XaxisLevel] [nvarchar](200) NULL,
	[YaxisLevel] [nvarchar](200) NULL,
	[SensorOutput] [nvarchar](200) NULL
) ON [PRIMARY]
GO

