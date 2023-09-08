--Actualización nombres de ciclos
UPDATE [sistencial_SE1].[dbo].[CultivoCiclo] SET Nombre='Periodo de análisis 1' WHERE nombre='Ciclo de cultivo 1'
UPDATE [sistencial_SE1].[dbo].[CultivoCiclo] SET Nombre='Periodo de análisis 2' WHERE nombre='Ciclo de cultivo 2'

--ETAPAS DE CULTIVO
SET IDENTITY_INSERT [dbo].[CultivoEtapa] ON 
INSERT [sistencial_SE1].[dbo].[CultivoEtapa] (CultivoEtapaId,Nombre,Orden,Clase) VALUES(12,'Vegetativa',2,'escenario-verde')
SET IDENTITY_INSERT [dbo].[CultivoEtapa] OFF
GO

--CICLOS DE CULTIVO
SET IDENTITY_INSERT [dbo].[CultivoCiclo] ON 
--Paipa - Coliflor
INSERT [sistencial_SE1].[dbo].[CultivoCiclo] (CultivoCicloId,Nombre,CultivoId,MunicipioId) VALUES (41,'Periodo de análisis 1',14,24)
INSERT [sistencial_SE1].[dbo].[CultivoCiclo] (CultivoCicloId,Nombre,CultivoId,MunicipioId) VALUES (42,'Periodo de análisis 2',14,24)
--Sora - Ovino Caprino
INSERT [sistencial_SE1].[dbo].[CultivoCiclo] (CultivoCicloId,Nombre,CultivoId,MunicipioId) VALUES (43,'Periodo de análisis 1',15,25)
INSERT [sistencial_SE1].[dbo].[CultivoCiclo] (CultivoCicloId,Nombre,CultivoId,MunicipioId) VALUES (44,'Periodo de análisis 2',15,25)
--Tibasosa - Ganadería Leche
INSERT [sistencial_SE1].[dbo].[CultivoCiclo] (CultivoCicloId,Nombre,CultivoId,MunicipioId) VALUES (45,'Periodo de análisis 1',3,26)
INSERT [sistencial_SE1].[dbo].[CultivoCiclo] (CultivoCicloId,Nombre,CultivoId,MunicipioId) VALUES (46,'Periodo de análisis 2',3,26)
SET IDENTITY_INSERT [dbo].[CultivoCiclo] OFF

--CALENDARIOS
--Paipa - Ciclo 1
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (12,3,41,1)
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (12,3,41,12)
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (12,3,41,4)
--Paipa - Ciclo 2
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (3,3,42,1)
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (3,3,42,12)
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (3,3,42,4)
--Sora - Ciclo 1
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (12,4,43,5)
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (12,4,43,6)
--Sora - Ciclo 2
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (3,4,44,5)
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (3,4,44,6)
--Tibasosa - Ciclo 1
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (12,4,45,5)
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (12,4,45,6)
--Tibasosa - Ciclo 2
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (3,4,46,5)
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (3,4,46,6)
