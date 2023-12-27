USE [SEMapa]
GO

/****** Object:  Table [dbo].[SITB_Estacion_3]    Script Date: 27/12/2023 10:17:41 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SITB_Estacion_3](
	[Est3_Id] [int] IDENTITY(1,1) NOT NULL,
	[Est_Id] [varchar](50) NULL,
	[Est3_Fecha] [varchar](50) NULL,
	[A0_Solar_radiation_avg] [numeric](10, 2) NULL,
	[A1_Solar_Panel_last] [numeric](10, 2) NULL,
	[A2_Precipitation_sum] [numeric](10, 2) NULL,
	[A3_Wind_speed_avg] [numeric](10, 2) NULL,
	[A3_Wind_speed_max] [numeric](10, 2) NULL,
	[A4_Battery_last] [numeric](10, 2) NULL,
	[A5_HC_Serial_Number_last] [numeric](10, 2) NULL,
	[A6_HC_Air_temperature_avg] [numeric](10, 2) NULL,
	[A6_HC_Air_temperature_max] [numeric](10, 2) NULL,
	[A6_HC_Air_temperature_min] [numeric](10, 2) NULL,
	[A7_HC_Relative_humidity_avg] [numeric](10, 2) NULL,
	[A7_HC_Relative_humidity_max] [numeric](10, 2) NULL,
	[A7_HC_Relative_humidity_min] [numeric](10, 2) NULL,
	[A8_Dew_Point_avg] [numeric](10, 2) NULL,
	[A8_Dew_Point_min] [numeric](10, 2) NULL,
	[A9_Latitude_last] [numeric](10, 2) NULL,
	[A10_Longitude_last] [numeric](10, 2) NULL,
	[A11_Altitude_last] [numeric](10, 2) NULL,
	[A12_Horizontal_dilusion_of_position_last] [numeric](10, 2) NULL,
	[A13_VPD_avg] [numeric](10, 2) NULL,
	[A13_VPD_min] [numeric](10, 2) NULL,
	[A14_Wind_speed_max_max] [numeric](10, 2) NULL,
	[A15_DeltaT_avg] [numeric](10, 2) NULL,
	[A15_DeltaT_max] [numeric](10, 2) NULL,
	[A15_DeltaT_min] [numeric](10, 2) NULL,
	[A16_Sensor_board_battery_last] [numeric](10, 2) NULL,
	[A17_Input_number_last] [numeric](10, 2) NULL,
	[A18_Soil_media_last] [numeric](10, 2) NULL,
	[A19_PI54a__VWC__avg] [numeric](10, 2) NULL,
	[A20_Input_number_last] [numeric](10, 2) NULL,
	[A21_Soil_media_last] [numeric](10, 2) NULL,
	[A22_PI54a__VWC__avg] [numeric](10, 2) NULL,
	[A23_Input_number_last] [numeric](10, 2) NULL,
	[E3_Evapotrans] [numeric](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Est3_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

