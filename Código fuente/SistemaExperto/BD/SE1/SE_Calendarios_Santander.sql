--Etapas de cultivo
-- CultivoEtapaId	Nombre	Orden
-- 1	Transplante	1
-- 2	Floración	2
-- 3	Fructificación	3
-- 4	Recolección	4
-- 5	Periodo de ocupación	5
-- 6	Periodo de descanso	6
-- 7	Inicial	0
-- 8	Desarrollo	0
-- 9	Medio	0
-- 10	Final	0
-- 11	Sin etapa	0
-- 12	Vegetativa	2
-- 13	Maduración	3
-- 14	Picos de cosecha	5

--ETAPAS DE CULTIVO
SET IDENTITY_INSERT [sistencial_SE1].[dbo].[CultivoEtapa] ON
INSERT [sistencial_SE1].[dbo].[CultivoEtapa] (CultivoEtapaId,Nombre,Orden,Clase)
VALUES (14,'Picos de cosecha',5,'escenario-naranja')
SET IDENTITY_INSERT [sistencial_SE1].[dbo].[CultivoEtapa] OFF
GO

--CICLOS DE CULTIVO
SET IDENTITY_INSERT [dbo].[CultivoCiclo] ON 
--Landázuri - Aguacate
INSERT [sistencial_SE1].[dbo].[CultivoCiclo] (CultivoCicloId,Nombre,CultivoId,MunicipioId) VALUES (47,'Periodo de análisis 1',16,21)
INSERT [sistencial_SE1].[dbo].[CultivoCiclo] (CultivoCicloId,Nombre,CultivoId,MunicipioId) VALUES (48,'Periodo de análisis 2',16,21)
--San Vicente - Cacao
INSERT [sistencial_SE1].[dbo].[CultivoCiclo] (CultivoCicloId,Nombre,CultivoId,MunicipioId) VALUES (49,'Periodo de análisis 1',17,23)
INSERT [sistencial_SE1].[dbo].[CultivoCiclo] (CultivoCicloId,Nombre,CultivoId,MunicipioId) VALUES (50,'Periodo de análisis 2',17,23)
--Piedecuesta - Mora
INSERT [sistencial_SE1].[dbo].[CultivoCiclo] (CultivoCicloId,Nombre,CultivoId,MunicipioId) VALUES (51,'Periodo de análisis 1',18,22)
INSERT [sistencial_SE1].[dbo].[CultivoCiclo] (CultivoCicloId,Nombre,CultivoId,MunicipioId) VALUES (52,'Periodo de análisis 2',18,22)
SET IDENTITY_INSERT [dbo].[CultivoCiclo] OFF


--CALENDARIOS
--Landázuri - Aguacate - Ciclo 1
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (9 ,2 ,47,2 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (11,5 ,47,3 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (3 ,1 ,47,4 )
--Landázuri - Aguacate - Ciclo 2
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (3 ,2 ,48,2 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (5 ,3 ,48,3 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (8 ,2 ,48,4 )
--San Vicente - Cacao - Ciclo 1
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (5 ,2 ,49,2 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (7 ,6 ,49,3 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (12,1 ,49,4 )
--San Vicente - Cacao - Ciclo 2
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (9 ,2 ,50,2 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (11,4 ,50,3 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (2 ,1 ,50,4 )
--Piedecuesta - Mora - Ciclo 1
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (3 ,4 ,51,2 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (4 ,4 ,51,3 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (6 ,3 ,51,13)
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (6 ,3 ,51,4 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (7 ,3 ,51,14)
--Piedecuesta - Mora - Ciclo 2
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (8 ,4 ,52,2 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (9 ,4 ,52,3 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (10,3 ,52,13)
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (10,3 ,52,4 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (1 ,2 ,52,14)
GO