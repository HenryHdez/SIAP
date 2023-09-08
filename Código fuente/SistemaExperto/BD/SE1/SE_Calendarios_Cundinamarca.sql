--ETAPAS DE CULTIVO
SET IDENTITY_INSERT [sistencial_SE1].[dbo].[CultivoEtapa] ON
INSERT [sistencial_SE1].[dbo].[CultivoEtapa] (CultivoEtapaId,Nombre,Orden,Clase)
VALUES (13,'Maduración',3,'escenario-naranja')
SET IDENTITY_INSERT [sistencial_SE1].[dbo].[CultivoEtapa] OFF
GO

--CALENDARIOS
--Anapoima - Mango Tommy - Ciclo 1
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (3 ,3 ,33,3 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (6 ,3 ,33,4 )
--Anapoima - Mango Tommy - Ciclo 2
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (6 ,1 ,34,3 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (7 ,2 ,34,4 )
--Ubaté - Ciclo 1
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (3 ,4 ,35,5 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (3 ,4 ,35,6 )
--Ubaté - Ciclo 2
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (6 ,4 ,36,5 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (6 ,4 ,36,6 )
--Útica - Ciclo 1
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (6 ,4 ,37,12 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (7 ,2 ,37,13 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (8 ,1 ,37,4 )
--Útica - Ciclo 2
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (9 ,3 ,38,12 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (11,2 ,38,13 )
INSERT [sistencial_SE1].[dbo].[CultivoTipoEtapa] (MesInicio,Duracion,CultivoCicloId,CultivoEtapaId) VALUES (12,1 ,38,4  )
GO