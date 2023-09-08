--Actualización nombres de cultivos
UPDATE [sistencial_SE1].[dbo].[Cultivo] SET Nombre='Ganadería Leche' WHERE nombre='Pastura'
UPDATE [sistencial_SE1].[dbo].[Cultivo] SET IndicadorMapa='pas' WHERE nombre='Ganadería Leche'


SET IDENTITY_INSERT [dbo].[Cultivo] ON
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(11,'Plátano',20,30,60,20,0.5,0.85,0.65,0.25,0.25,0.4,0.17,0.5,1,50,'/Content/Imagenes/cultivo-tomate_',0,'pla')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(12,'Fresa',20,30,60,20,0.5,0.85,0.65,0.25,0.25,0.4,0.17,0.5,1,50,'/Content/Imagenes/cultivo-tomate_',0,'fre')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(13,'Maracuyá',20,30,60,20,0.5,0.85,0.65,0.25,0.25,0.4,0.17,0.5,1,50,'/Content/Imagenes/cultivo-tomate_',0,'mar')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(14,'Coliflor',20,30,60,20,0.5,0.85,0.65,0.25,0.25,0.4,0.17,0.5,1,50,'/Content/Imagenes/cultivo-tomate_',0,'col')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(15,'Ovino caprino',20,30,60,20,0.5,0.85,0.65,0.25,0.25,0.4,0.17,0.5,1,50,'/Content/Imagenes/cultivo-tomate_',0,'pas')
SET IDENTITY_INSERT [dbo].[Cultivo] OFF
GO

--24/09/2015 ajustando cultivo Ganaderia- REGISTROS ERRONEOS EXISTENTES:
delete  [sistencial_SE1].[dbo].zona 
where CultivoId=3

delete sistencial_SE1.dbo.Cultivo
where CultivoId=3
go

update sistencial_SE1.dbo.Cultivo set Nombre = 'Ganadería de leche', IndicadorMapa ='gan'
where CultivoId = 14
GO

update sistencial_SE1.dbo.Cultivo set Nombre = 'Coliflor', IndicadorMapa ='col'
where CultivoId = 15
GO

update sistencial_SE1.dbo.zona set CultivoId = 15
where MunicipioId=24
GO
--

SET IDENTITY_INSERT [dbo].[Cultivo] ON
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(16,'Ovino Caprino ',20,30,60,20,0.5,0.85,0.65,0.25,0.25,0.4,0.17,0.5,1,50,'/Content/Imagenes/cultivo-tomate_',0,'pas')
SET IDENTITY_INSERT [dbo].[Cultivo] OFF

GO

update sistencial_SE1.dbo.CultivoCiclo
set CultivoId = 16 where MunicipioId = 25
GO

update sistencial_SE1.dbo.CultivoCiclo
set CultivoId = 15 where MunicipioId = 24
GO
--Cultivos 17/10/2015
SET IDENTITY_INSERT [dbo].[Cultivo] ON
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(17,'Aguacate',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'agu')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(18,'Cacao',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'cac')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(19,'Naranja',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'nar')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(20,'Ganadería doble propósito',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'pas')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(21,'Chontaduro',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'cho')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(22,'Berenjena',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'ber')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(23,'Ñame',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'nam')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(24,'Granadilla',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'gra')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(25,'Melón',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'mel')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(26,'Maíz blanco',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'mai')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(27,'Yuca industrial',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'yuc')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(28,'Plátano hartón',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'pla')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(29,'Limón Tahití',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'lim')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(30,'Mora',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'mor')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(31,'Arroz secano mecanizado',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'arr')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(32,'Ñame Espino',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'nam')
INSERT [sistencial_SE1].[dbo].[Cultivo](CultivoId,Nombre, TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,RutaImagen,CultivoTipoId,IndicadorMapa)VALUES(33,'Limón pajarito',0,0,0,0,0,0,0,0,0,0,0,0,0,0,'/Content/Imagenes/cultivo-tomate_',0,'lim')
SET IDENTITY_INSERT [dbo].[Cultivo] OFF

GO