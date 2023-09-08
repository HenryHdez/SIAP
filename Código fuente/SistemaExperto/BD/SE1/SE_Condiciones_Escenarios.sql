USE [SE]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Tabla de condiciones
CREATE TABLE dbo.Condicion (
    CondicionId INT IDENTITY (1, 1) NOT NULL,
    Nombre NVARCHAR(max) NULL,
	Descripcion NVARCHAR(max) NULL
	
    CONSTRAINT [PK_dbo.Condicion] PRIMARY KEY CLUSTERED (CondicionId ASC)
);
GO

--Tabla de escenarios
CREATE TABLE dbo.MunicipioEscenario (
    MunicipioEscenarioId INT IDENTITY (1, 1) NOT NULL,
	MunicipioId INT NOT NULL,
	CondicionId INT NOT NULL,
	Mes INT NOT NULL,
    Codigo NVARCHAR(2) NULL,
    Descripcion NVARCHAR(max) NULL
	
    CONSTRAINT [PK_dbo.MunicipioEscenario] PRIMARY KEY CLUSTERED (MunicipioEscenarioId ASC)
);

ALTER TABLE dbo.MunicipioEscenario  WITH CHECK ADD
CONSTRAINT [FK_dbo.MunicipioEscenario_dbo.Municipio_MunicipioId] FOREIGN KEY([MunicipioId])
REFERENCES dbo.Municipio (MunicipioId)
ON DELETE CASCADE
GO

ALTER TABLE dbo.MunicipioEscenario  WITH CHECK ADD
CONSTRAINT [FK_dbo.MunicipioEscenario_dbo.Condicion_CondicionId] FOREIGN KEY([CondicionId])
REFERENCES dbo.Condicion (CondicionId)
ON DELETE CASCADE
GO

--Condiciones (húmedo, normal y seco)
SET IDENTITY_INSERT dbo.Condicion ON
INSERT INTO dbo.Condicion
(CondicionId,Nombre,Descripcion)
VALUES
(0, 'Húmedo', ''),
(1, 'Normal', ''),
(2, 'Seco', '')
SET IDENTITY_INSERT dbo.Condicion OFF
GO

SET IDENTITY_INSERT dbo.MunicipioEscenario ON
INSERT INTO dbo.MunicipioEscenario
(MunicipioEscenarioId,MunicipioId,CondicionId,Mes,Codigo,Descripcion)
VALUES
--Escenarios para Repelón
--Octubre normal
(1  ,1,1,10,'CL','Suelos con aptitud óptima  y probabilidad media (40 -60%) que presente condiciones de humedad adecuada para el cultivo de tomate'),
(2  ,1,1,10,'CM','Suelos con aptitud óptima y probabilidad baja (40 -60%) que presente condiciones de humedad adecuada para el cultivo de tomate'),
(3  ,1,1,10,'CX','No apto para el cultivo de tomate (Isla)'),
(4  ,1,1,10,'CY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(5  ,1,1,10,'CZ','No apto para el cultivo de tomate (Zona Urbana)'),
(6  ,1,1,10,'DL','Suelo con aptitud óptima y probabilidad alta (60-80%) que presente condiciones de humedad adecuada para el cultivo de tomate'),
(7  ,1,1,10,'DM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(8  ,1,1,10,'DQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(9  ,1,1,10,'DX','No apto para el cultivo de tomate (Isla)'),
(10 ,1,1,10,'DY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(11 ,1,1,10,'DZ','No apto para el cultivo de tomate (Zona Urbana)'),
(12 ,1,1,10,'DW','Área sin información'),
(13 ,1,1,10,'EL','Suelos con aptitud óptima y probabilidad muy alta (80 - 100%) que presente condiciones de humedad adecuada para el cultivo de tomate'),
(14 ,1,1,10,'EQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
--Noviembre normal
(15 ,1,1,11,'CL','Suelos con aptitud óptima  y probabilidad media (40 -60%) que presente condiciones de humedad adecuada para el cultivo de tomate'),
(16 ,1,1,11,'CM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(17 ,1,1,11,'CQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(18 ,1,1,11,'CX','No apto para el cultivo de tomate (Isla)'),
(19 ,1,1,11,'CY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(20 ,1,1,11,'CZ','No apto para el cultivo de tomate (Zona Urbana)'),
(21 ,1,1,11,'CW','Área sin información'),
(22 ,1,1,11,'DL','Suelo con aptitud óptima y probabilidad alta (60-80%) que presente condiciones de humedad adecuada para el cultivo de tomate'),
(23 ,1,1,11,'DQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(24 ,1,1,11,'DY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
--Diciembre normal
(25 ,1,1,12,'CL','Suelos con aptitud óptima  y probabilidad media (40 -60%) que presente condiciones de humedad adecuada para el cultivo de tomate'),
(26 ,1,1,12,'CM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(27 ,1,1,12,'CQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(28 ,1,1,12,'CX','No apto para el cultivo de tomate (Isla)'),
(29 ,1,1,12,'CY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(30 ,1,1,12,'CZ','No apto para el cultivo de tomate (Zona Urbana)'),
(31 ,1,1,12,'CW','Área sin información'),
(32 ,1,1,12,'DL','Suelo con aptitud óptima y probabilidad alta (60-80%) que presente condiciones de humedad adecuada para el cultivo de tomate'),
--Enero normal
(33 ,1,1, 1,'CL','Suelos con aptitud óptima  y probabilidad media (40 -60%) que presente condiciones de humedad adecuada para el cultivo de tomate'),
(34 ,1,1, 1,'CQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(35 ,1,1, 1,'CX','No apto para el cultivo de tomate (Isla)'),
(36 ,1,1, 1,'CY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(37 ,1,1, 1,'CZ','No apto para el cultivo de tomate (Zona Urbana)'),
(38 ,1,1, 1,'CW','Área sin información'),
(39 ,1,1, 1,'DL','Suelo con aptitud óptima y probabilidad alta (60-80%) que presente condiciones de humedad adecuada para el cultivo de tomate'),
(40 ,1,1, 1,'DM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(41 ,1,1, 1,'DQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(42 ,1,1, 1,'DX','No apto para el cultivo de tomate (Isla)'),
(43 ,1,1, 1,'DY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(44 ,1,1, 1,'DZ','No apto para el cultivo de tomate (Zona Urbana)'),
(45 ,1,1, 1,'DW','Área sin información'),
--Febrero normal
(46 ,1,1, 2,'CL','uelos con aptitud óptima  y probabilidad media (40 -60%) que presente condiciones de humedad adecuada para el cultivo de tomate'),
(47 ,1,1, 2,'CY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(48 ,1,1, 2,'DL','Suelo con aptitud óptima y probabilidad alta (60-80%) que presente condiciones de humedad adecuada para el cultivo de tomate'),
(49 ,1,1, 2,'DM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(50 ,1,1, 2,'DQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(51 ,1,1, 2,'DX','No apto para el cultivo de tomate (Isla)'),
(52 ,1,1, 2,'DY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(53 ,1,1, 2,'DZ','No apto para el cultivo de tomate (Zona Urbana)'),
(54 ,1,1, 2,'DW','Área sin información'),
--Octubre húmedo
(55 ,1,0,10,'AL','Suelos con aptitud óptima y probabilidad muy baja (0 -20%) que presente excesos de humedad para el cultivo de tomate'),
(56 ,1,0,10,'AQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(57 ,1,0,10,'BL','Suelos con aptitud óptima y probabilidad baja (20 -40%) que presente excesos de humedad para el cultivo de tomate'),
(58 ,1,0,10,'BM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(59 ,1,0,10,'BQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(60 ,1,0,10,'BX','No apto para el cultivo de tomate (Isla)'),
(61 ,1,0,10,'BY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(62 ,1,0,10,'BZ','No apto para el cultivo de tomate (Zona Urbana)'),
(63 ,1,0,10,'BW','Área sin información'),
(64 ,1,0,10,'CL','Suelos con aptitud óptima y probabilidad media (40 -60%) que presente excesos de humedad para el cultivo de tomate'),
(65 ,1,0,10,'CM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(66 ,1,0,10,'CQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(67 ,1,0,10,'CX','No apto para el cultivo de tomate (Isla)'),
(68 ,1,0,10,'CY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(69 ,1,0,10,'CZ','No apto para el cultivo de tomate (Zona Urbana)'),
(70 ,1,0,10,'CW','Área sin información'),
(71 ,1,0,10,'DL','Suelos con aptitud óptima y probabilidad alta (60 -80%) que presente excesos de humedad para el cultivo de tomate'),
--Noviembre húmedo
(72 ,1,0,11,'BL','Suelos con aptitud óptima y probabilidad muy baja (0 -20%) que presente excesos de humedad para el cultivo de tomate'),
(73 ,1,0,11,'BQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(74 ,1,0,11,'BY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(75 ,1,0,11,'CL','Suelos con aptitud óptima y probabilidad media (40 -60%) que presente excesos de humedad para el cultivo de tomate'),
(76 ,1,0,11,'CM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(77 ,1,0,11,'CQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(78 ,1,0,11,'CX','No apto para el cultivo de tomate (Isla)'),
(79 ,1,0,11,'CY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(80 ,1,0,11,'CZ','No apto para el cultivo de tomate (Zona Urbana)'),
(81 ,1,0,11,'CW','Área sin información'),
(82 ,1,0,11,'DL','Suelos con aptitud óptima y probabilidad alta (60 -80%) que presente excesos de humedad para el cultivo de tomate'),
--Diciembre húmedo
(83 ,1,0,12,'CL','Suelos con aptitud óptima y probabilidad media (40 -60%) que presente excesos de humedad para el cultivo de tomate'),
(84 ,1,0,12,'DL','Suelos con aptitud óptima y probabilidad alta (60 -80%) que presente excesos de humedad para el cultivo de tomate'),
(85 ,1,0,12,'DM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(86 ,1,0,12,'DQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(87 ,1,0,12,'DX','No apto para el cultivo de tomate (Isla)'),
(88 ,1,0,12,'DY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(89 ,1,0,12,'DZ','No apto para el cultivo de tomate (Zona Urbana)'),
(90 ,1,0,12,'DW','Área sin información'),
(91 ,1,0,12,'EL','Suelos con aptitud óptima y probabilidad muy alta (80 -100%) que presente excesos de humedad para el cultivo de tomate'),
--Enero húmedo
(92 ,1,0, 1,'CL','Suelos con aptitud óptima y probabilidad media (40 -60%) que presente excesos de humedad para el cultivo de tomate'),
(93 ,1,0, 1,'CQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(94 ,1,0, 1,'CX','No apto para el cultivo de tomate (Isla)'),
(95 ,1,0, 1,'CZ','No apto para el cultivo de tomate (Zona Urbana)'),
(96 ,1,0, 1,'CW','Área sin información'),
(97 ,1,0, 1,'DL','Suelos con aptitud óptima y probabilidad alta (60 -80%) que presente excesos de humedad para el cultivo de tomate'),
(98 ,1,0, 1,'DM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(99 ,1,0, 1,'DQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(100,1,0, 1,'DX','No apto para el cultivo de tomate (Isla)'),
(101,1,0, 1,'DY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(102,1,0, 1,'DZ','No apto para el cultivo de tomate (Zona Urbana)'),
(103,1,0, 1,'DW','Área sin información'),
--Febrero húmedo
(104,1,0, 2,'BL','Suelos con aptitud óptima y probabilidad baja (20 -40%) que presente excesos de humedad para el cultivo de tomate'),
(105,1,0, 2,'BQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(106,1,0, 2,'BY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(107,1,0, 2,'BZ','No apto para el cultivo de tomate (Zona Urbana)'),
(108,1,0, 2,'CL','Suelos con aptitud óptima y probabilidad media (40 -60%) que presente excesos de humedad para el cultivo de tomate'),
(109,1,0, 2,'CM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(110,1,0, 2,'CQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(111,1,0, 2,'CX','No apto para el cultivo de tomate (Isla)'),
(112,1,0, 2,'CY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(113,1,0, 2,'CZ','No apto para el cultivo de tomate (Zona Urbana)'),
(114,1,0, 2,'CW','Área sin información'),
(115,1,0, 2,'DL','Suelos con aptitud óptima y probabilidad alta (60 -80%) que presente excesos de humedad para el cultivo de tomate'),
(116,1,0, 2,'DM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(117,1,0, 2,'DQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(118,1,0, 2,'DX','No apto para el cultivo de tomate (Isla)'),
(119,1,0, 2,'DY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
--Octubre seco
(120,1,2,10,'BL','Suelos con aptitud óptima y probabilidad baja (20 -40%) que presente deficiencias de humedad para el cultivo de tomate'),
(121,1,2,10,'BM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(122,1,2,10,'BQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(123,1,2,10,'BX','No apto para el cultivo de tomate (Isla)'),
(124,1,2,10,'BY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(125,1,2,10,'BZ','No apto para el cultivo de tomate (Zona Urbana)'),
(126,1,2,10,'BW','Área sin información'),
(127,1,2,10,'CL','Suelos con aptitud óptima y probabilidad media (40 -60%) que presente deficiencias de humedad para el cultivo de tomate'),
(128,1,2,10,'CM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(129,1,2,10,'CQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(130,1,2,10,'CX','No apto para el cultivo de tomate (Isla)'),
(131,1,2,10,'CY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(132,1,2,10,'CZ','No apto para el cultivo de tomate (Zona Urbana)'),
(133,1,2,10,'CW','Área sin información'),
--Noviembre seco
(134,1,2,11,'CL','Suelos con aptitud óptima y probabilidad media (40 -60%) que presente deficiencias de humedad para el cultivo de tomate'),
(135,1,2,11,'CM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(136,1,2,11,'CQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(137,1,2,11,'CX','No apto para el cultivo de tomate (Isla)'),
(138,1,2,11,'CY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(139,1,2,11,'CZ','No apto para el cultivo de tomate (Zona Urbana)'),
(140,1,2,11,'CW','Área sin información'),
(141,1,2,11,'DL','Suelos con aptitud óptima y probabilidad alta (60 -80%) que presente deficiencias de humedad para el cultivo de tomate'),
(142,1,2,11,'DM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(143,1,2,11,'DQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(144,1,2,11,'DX','No apto para el cultivo de tomate (Isla)'),
(145,1,2,11,'DY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
--Diciembre seco
(146,1,2,12,'BL','Suelos con aptitud óptima y probabilidad baja (20 -40%) que presente deficiencias de humedad para el cultivo de tomate'),
(147,1,2,12,'BQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(148,1,2,12,'BY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(149,1,2,12,'CL','Suelos con aptitud óptima y probabilidad media (40 -60%) que presente deficiencias de humedad para el cultivo de tomate'),
(150,1,2,12,'CM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(151,1,2,12,'CQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(152,1,2,12,'CX','No apto para el cultivo de tomate (Isla)'),
(153,1,2,12,'CY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(154,1,2,12,'CZ','No apto para el cultivo de tomate (Zona Urbana)'),
(155,1,2,12,'CW','Área sin información'),
--Enero seco
(156,1,2, 1,'BL','Suelos con aptitud óptima y probabilidad baja (20 -40%) que presente deficiencias de humedad para el cultivo de tomate'),
(157,1,2, 1,'BM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(158,1,2, 1,'BQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(159,1,2, 1,'BX','No apto para el cultivo de tomate (Isla)'),
(160,1,2, 1,'BY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(161,1,2, 1,'CL','Suelos con aptitud óptima y probabilidad media (40 -60%) que presente deficiencias de humedad para el cultivo de tomate'),
(162,1,2, 1,'CM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(163,1,2, 1,'CQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(164,1,2, 1,'CX','No apto para el cultivo de tomate (Isla)'),
(165,1,2, 1,'CY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(166,1,2, 1,'CZ','No apto para el cultivo de tomate (Zona Urbana)'),
(167,1,2, 1,'CW','Área sin información'),
(168,1,2, 1,'DL','Suelos con aptitud óptima y probabilidad alta (60 -80%) que presente deficiencias de humedad para el cultivo de tomate'),
--Febrero seco
(169,1,2, 2,'BL','Suelos con aptitud óptima y probabilidad baja (20 -40%) que presente deficiencias de humedad para el cultivo de tomate'),
(170,1,2, 2,'BM','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(171,1,2, 2,'BQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(172,1,2, 2,'BX','No apto para el cultivo de tomate (Isla)'),
(173,1,2, 2,'BY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(174,1,2, 2,'BZ','No apto para el cultivo de tomate (Zona Urbana)'),
(175,1,2, 2,'BW','Área sin información'),
(176,1,2, 2,'CL','Suelos con aptitud óptima y probabilidad media (40 -60%) que presente deficiencias de humedad para el cultivo de tomate'),
(177,1,2, 2,'CQ','Suelos no aptos para el cultivo de tomate por presentar profundidad efectiva muy superficial'),
(178,1,2, 2,'CY','No apto para el cultivo de tomate (Cuerpos y corrientes de agua)'),
(179,1,2, 2,'CZ','No apto para el cultivo de tomate (Zona Urbana)'),
(180,1,2, 2,'CW','Área sin información'),

--Escenarios para Suán
--Octubre normal
(181,2,1,10,'DL','Suelos con aptitud óptima o con leves restricciones y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(182,2,1,10,'DM','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(183,2,1,10,'DN','Suelos condicionados a prácticas de manejo de drenaje y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(184,2,1,10,'DO','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(185,2,1,10,'DP','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(186,2,1,10,'DY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(187,2,1,10,'DZ','No apto para el cultivo de ají topito (Zona Urbana)'),
--Noviembre normal
(188,2,1,11,'CL','Suelos óptimos o con leves restricciones y probabilidad media (40 - 60%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(189,2,1,11,'CM','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad media (40 - 60%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(190,2,1,11,'CN','Suelos condicionados a prácticas de manejo del drenaje y probabilidad media (40 - 60%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(191,2,1,11,'CY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(192,2,1,11,'DL','Suelos óptimos o con leves restricciones y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(193,2,1,11,'DM','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(194,2,1,11,'DN','Suelos condicionados a prácticas de manejo de drenaje y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(195,2,1,11,'DO','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(196,2,1,11,'DP','Suelos condicionado a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(197,2,1,11,'DY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(198,2,1,11,'DZ','No apto para el cultivo de ají topito (Zona Urbana)'),
--Diciembre normal
(199,2,1,12,'DL','Suelos óptimos o con leves restricciones y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(200,2,1,12,'DM','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(201,2,1,12,'DN','Suelos condicionados a prácticas de manejo del drenaje y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(202,2,1,12,'DO','Suelos condicionado a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(203,2,1,12,'DP','Suelos condicionado a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(204,2,1,12,'DY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(205,2,1,12,'DZ','No apto para el cultivo de ají topito (Zona Urbana)'),
--Enero normal
(206,2,1,1 ,'DL','Suelos óptimos o con leves restricciones y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(207,2,1,1 ,'DM','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(208,2,1,1 ,'DN','Suelos condicionados a prácticas de manejo del drenaje y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(209,2,1,1 ,'DO','Suelos condicionado a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(210,2,1,1 ,'DP','Suelos condicionado a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(211,2,1,1 ,'DY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(212,2,1,1 ,'DZ','No apto para el cultivo de ají topito (Zona Urbana)'),
--Febrero normal
(213,2,1,2 ,'DL','Suelos óptimos o con leves restricciones y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(214,2,1,2 ,'DM','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(215,2,1,2 ,'DN','Suelos condicionados a prácticas de manejo del drenaje y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(216,2,1,2 ,'DO','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(217,2,1,2 ,'DP','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad alta (60 - 80%) de condiciones de humedad adecuada para el cultivo de ají topito'),
(218,2,1,2 ,'DY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(219,2,1,2 ,'DZ','No apto para el cultivo de ají topito (Zona Urbana)'),
--Octubre húmedo
(220,2,0,10,'AM','Suelos condicionado a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad muy baja (20 - 40%) de exceso de humedad para el cultivo de ají topito'),
(221,2,0,10,'BL','Suelos óptimos o con leves restricciones y probabilidad baja (20 - 40%) de exceso de humedad para el cultivo de ají topito'),
(222,2,0,10,'BM','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad baja (20 - 40%) de exceso de humedad para el cultivo de ají topito'),
(223,2,0,10,'BN','Suelos condicionado a prácticas de manejo del drenaje y probabilidad baja (20 - 40%) de exceso de humedad para el cultivo de ají topito'),
(224,2,0,10,'BO','Suelos condicionado a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad baja (20 - 40%) de exceso de humedad para el cultivo de ají topito'),
(225,2,0,10,'BP','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad baja (20 - 40%) de exceso de humedad para el cultivo de ají topito'),
(226,2,0,10,'BY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(227,2,0,10,'BZ','No apto para el cultivo de ají topito (Zona Urbana)'),
(228,2,0,10,'CL','Suelos óptimos o con leves restricciones y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(229,2,0,10,'CM','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(230,2,0,10,'CN','Suelos condicionado a prácticas de manejo del drenaje y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(231,2,0,10,'CY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
--Noviembre húmedo
(232,2,0,11,'CL','Suelos óptimos o con leves restricciones y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(233,2,0,11,'CM','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(234,2,0,11,'CN','Suelos condicionados a prácticas de manejo del drenaje y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(235,2,0,11,'CO','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(236,2,0,11,'CP','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(237,2,0,11,'CY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(238,2,0,11,'CZ','No apto para el cultivo de ají topito (Zona Urbana)'),
--Diciembre húmedo
(239,2,0,12,'BL','Suelos óptimos o con leves restricciones y probabilidad baja (20 - 40%) de exceso de humedad para el cultivo de ají topito'),
(240,2,0,12,'BM','Este suelo presenta una probabilidad baja (20 - 40%) de exceso de humedad para el cultivo de ají topito'),
(241,2,0,12,'BN','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad baja (20 - 40%) de exceso de humedad para el cultivo de ají topito'),
(242,2,0,12,'BO','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad baja (20 - 40%) de exceso de humedad para el cultivo de ají topito'),
(243,2,0,12,'BY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(244,2,0,12,'CL','Suelos óptimos o con leves restricciones y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(245,2,0,12,'CM','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(246,2,0,12,'CN','Suelos condicionados a prácticas de manejo del drenaje y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(247,2,0,12,'CO','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(248,2,0,12,'CP','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(249,2,0,12,'CY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(250,2,0,12,'CZ','No apto para el cultivo de ají topito (Zona Urbana)'),
--Enero húmedo
(251,2,0,1 ,'CL','Suelos óptimos o con leves restricciones y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(252,2,0,1 ,'CM','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(253,2,0,1 ,'CN','Suelos condicionados a prácticas de manejo del drenaje y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(254,2,0,1 ,'CO','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(255,2,0,1 ,'CP','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(256,2,0,1 ,'CY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(257,2,0,1 ,'CZ','No apto para el cultivo de ají topito (Zona Urbana)'),
--Febrero húmedo
(258,2,0,2 ,'CL','Suelos óptimos o con leves restricciones y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(259,2,0,2 ,'CM','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(260,2,0,2 ,'CN','Suelos condicionados a prácticas de manejo del drenaje y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(261,2,0,2 ,'CO','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(262,2,0,2 ,'CP','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad media (40 - 60%) de exceso de humedad para el cultivo de ají topito'),
(263,2,0,2 ,'CY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(264,2,0,2 ,'CZ','No apto para el cultivo de ají topito (Zona Urbana)'),
--Octubre seco
(265,2,0,10,'BL','Suelos óptimos o con leves restricciones y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(266,2,0,10,'BM','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(267,2,0,10,'BN','Suelos condicionados a prácticas de manejo del drenaje y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(268,2,0,10,'BO','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(269,2,0,10,'BP','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(270,2,0,10,'BY','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad media (40 - 60%) de déficit de humedad para el cultivo de ají topito'),
(271,2,0,10,'BZ','Suelos condicionados a prácticas de manejo del drenaje y probabilidad media (40 - 60%) de déficit de humedad para el cultivo de ají topito'),
(272,2,0,10,'CL','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad media (40 - 60%) de déficit de humedad para el cultivo de ají topito'),
(273,2,0,10,'CM','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad media (40 - 60%) de déficit de humedad para el cultivo de ají topito'),
(274,2,0,10,'CN','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(275,2,0,10,'CY','No apto para el cultivo de ají topito (Zona Urbana)'),
--Noviembre seco
(276,2,0,11,'BL','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(277,2,0,11,'BM','Suelos condicionados a prácticas de manejo del drenaje y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(278,2,0,11,'BN','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(279,2,0,11,'BO','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(280,2,0,11,'BP','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(281,2,0,11,'BY','No apto para el cultivo de ají topito (Zona Urbana)'),
(282,2,0,11,'BZ','Suelos óptimos o con leves restricciones y probabilidad media (40 - 60%) de déficit de humedad para el cultivo de ají topito'),
(283,2,0,11,'CL','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad media (40 - 60%) de déficit de humedad para el cultivo de ají topito'),
(284,2,0,11,'CM','Suelos condicionados a prácticas de manejo del drenaje y probabilidad media (40 - 60%) de déficit de humedad para el cultivo de ají topito'),
(285,2,0,11,'CN','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad media (40 - 60%) de déficit de humedad para el cultivo de ají topito'),
(286,2,0,11,'CY','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
--Diciembre seco
(287,2,0,12,'BP','Suelos óptimos o con leves restricciones y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(288,2,0,12,'BY','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(289,2,0,12,'BZ','Suelos condicionados a prácticas de manejo del drenaje y una probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(290,2,0,12,'CL','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(291,2,0,12,'CM','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(292,2,0,12,'CN','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(293,2,0,12,'CY','No apto para el cultivo de ají topito (Zona Urbana)'),
--Enero seco
(294,2,0,1 ,'BP','Suelos óptimos o con leves restricciones y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(295,2,0,1 ,'BY','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(296,2,0,1 ,'BZ','Suelos condicionados a prácticas de manejo del drenaje y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(297,2,0,1 ,'CL','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(298,2,0,1 ,'CM','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(299,2,0,1 ,'CN','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(300,2,0,1 ,'CY','No apto para el cultivo de ají topito (Zona Urbana)'),
--Febrero seco
(301,2,0,2 ,'BP','Suelos óptimos o con leves restricciones y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(302,2,0,2 ,'BY','Suelos condicionados a prácticas de manejo de drenaje, profundidad efectiva y textura, y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(303,2,0,2 ,'BZ','Suelos condicionados a prácticas de manejo del drenaje y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(304,2,0,2 ,'CL','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(305,2,0,2 ,'CM','Suelos condicionados a prácticas de manejo de drenaje y profundidad efectiva muy superficial, y una probabilidad baja (20 - 40%) de déficit de humedad para el cultivo de ají topito'),
(306,2,0,2 ,'CN','No apto para el cultivo de ají topito (Cuerpos y corrientes de agua)'),
(307,2,0,2 ,'CY','No apto para el cultivo de ají topito (Zona Urbana)')

SET IDENTITY_INSERT dbo.MunicipioEscenario OFF
GO