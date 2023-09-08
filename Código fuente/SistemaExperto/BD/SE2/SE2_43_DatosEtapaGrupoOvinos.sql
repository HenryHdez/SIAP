USE SEMapa
--use sistencial_SEMapa
GO
SET IDENTITY_INSERT dbo.GrupoCultivo ON
INSERT INTO DBO.GrupoCultivo(GrupoCultivoId,Nombre)VALUES(12,'Ganadería 2')
SET IDENTITY_INSERT dbo.GrupoCultivo OFF
go

update dbo.Cultivo set GrupoCultivoId=12 where CultivoId = 16;
go

INSERT INTO dbo.EtapaGrupo(GrupoCultivoId,CultivoEtapaId,RutaIcono)values(12,5,'../Content/imagenes/Etapas/Ganaderos2_ocupacion.png');
INSERT INTO dbo.EtapaGrupo(GrupoCultivoId,CultivoEtapaId,RutaIcono)values(12,6,'../Content/imagenes/Etapas/Ganaderos2_descanso.png');
go