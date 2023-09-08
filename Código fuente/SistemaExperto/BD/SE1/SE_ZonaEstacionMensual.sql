USE [SE]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE dbo.ZonaEstacionMensual (
    ZonaEstacionMensualId INT IDENTITY (1, 1) NOT NULL,
	ZonaEstacionId INT NOT NULL,
    Mes INT NOT NULL,
    Anho INT NOT NULL,
	ET FLOAT NOT NULL,
	PE FLOAT NOT NULL,
    RO FLOAT NOT NULL,
	PRO FLOAT NOT NULL,
	R FLOAT NOT NULL,
	PR FLOAT NOT NULL,
	L FLOAT NOT NULL,
	PL FLOAT NOT NULL,
    K FLOAT NOT NULL,
	Z FLOAT NOT NULL,
	X1 FLOAT NOT NULL,
	X2 FLOAT NOT NULL,
	X3 FLOAT NOT NULL,
	
    CONSTRAINT [PK_dbo.ZonaEstacionMensual] PRIMARY KEY CLUSTERED (ZonaEstacionMensualId ASC)
);

ALTER TABLE dbo.ZonaEstacionMensual  WITH CHECK ADD
CONSTRAINT [FK_dbo.ZonaEstacionMensual_dbo.ZonaEstacion_ZonaEstacionId] FOREIGN KEY([ZonaEstacionId])
REFERENCES dbo.ZonaEstacion (ZonaEstacionId)
ON DELETE CASCADE
GO

SET IDENTITY_INSERT dbo.ZonaEstacionMensual ON

INSERT INTO dbo.ZonaEstacionMensual(ZonaEstacionMensualId,ZonaEstacionId, Mes, Anho, ET, PE, RO, PRO, R, PR, L, PL, K, Z, X1, X2, X3) VALUES
(1 ,9,1 ,2014,0,0,0,0,0,0,0,0,0     ,0.0794,0.0000,-0.0106,-3.1366),
(2 ,9,2 ,2014,0,0,0,0,0,0,0,0,0     ,0     ,0     , 0     ,-3     ),
(3 ,9,3 ,2014,0,0,0,0,0,0,0,0,0     ,0.0581,0.0000, 0.0000,-3.8085),
(4 ,9,4 ,2014,0,0,0,0,0,0,0,0,0     ,0.0525,0.0000, 0.0000,-4.6250),
(5 ,9,5 ,2014,0,0,0,0,0,0,0,0,0     ,0.0627,0.0381, 0.0000,-4.1105),
(6 ,9,6 ,2014,0,0,0,0,0,0,0,0,0     ,0.0589,0.0000, 0.0000,-4.6573),
(7 ,9,7 ,2014,0,0,0,0,0,0,0,0,0     ,0.0663,0.0000, 0.0000,-5.0199),
(8 ,9,8 ,2014,0,0,0,0,0,0,0,0,0     ,0.0607,0.0000, 0.0000,-5.1804),
(9 ,9,9 ,2014,0,0,0,0,0,0,0,0,0     ,0.0664,0.0000, 0.0000,-5.6088),
(10,9,10,2014,0,0,0,0,0,0,0,0,0     ,0.0562,0.0000, 0.0000,-5.1027),
(11,9,11,2014,0,0,0,0,0,0,0,0,0     ,0.0605,0.0000, 0.0000,-4.9212),
(12,9,12,2014,0,0,0,0,0,0,0,0,0     ,0.0625,0.9074, 0.0000,-3.5069)
SET IDENTITY_INSERT SE.[dbo].ZonaEstacionMensual OFF
GO