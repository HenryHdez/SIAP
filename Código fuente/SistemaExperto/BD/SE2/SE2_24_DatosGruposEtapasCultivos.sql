-- Inserta datos Grupos
-- Yaritza Cárdenas
-- 
USE [SEMapa]
GO
set identity_insert  dbo.GrupoCultivo on
insert into dbo.GrupoCultivo(GrupoCultivoId,Nombre)values(1,'Frutales 1');
insert into dbo.GrupoCultivo(GrupoCultivoId,Nombre)values(2,'Frutales 2');
insert into dbo.GrupoCultivo(GrupoCultivoId,Nombre)values(3,'Raíces y Tubérculos   ');
insert into dbo.GrupoCultivo(GrupoCultivoId,Nombre)values(4,'Hortalizas 1');
insert into dbo.GrupoCultivo(GrupoCultivoId,Nombre)values(5,'Hortalizas 2');
insert into dbo.GrupoCultivo(GrupoCultivoId,Nombre)values(6,'Hortalizas 3');
insert into dbo.GrupoCultivo(GrupoCultivoId,Nombre)values(7,'Cereales 1');
insert into dbo.GrupoCultivo(GrupoCultivoId,Nombre)values(8,'Cereales 2');
insert into dbo.GrupoCultivo(GrupoCultivoId,Nombre)values(9,'Industriales 1');
insert into dbo.GrupoCultivo(GrupoCultivoId,Nombre)values(10,'Industriales 2');
insert into dbo.GrupoCultivo(GrupoCultivoId,Nombre)values(11,'Ganadería');
set identity_insert  dbo.GrupoCultivo off
--delete dbo.EtapaGrupo
set identity_insert  dbo.EtapaGrupo on
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(1,1,16,'../Content/imagenes/Etapas/Frutales1-Siembra.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(2,1,1,'../Content/imagenes/Etapas/Frutales1-Transplante.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(3,1,2,'../Content/imagenes/Etapas/Frutales1-Floracion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(4,1,3,'../Content/imagenes/Etapas/Frutales1-Fructificacion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(5,1,4,'../Content/imagenes/Etapas/Frutales1-Recoleccion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(6,1,15,'../Content/imagenes/Etapas/Frutales1-PicosCosecha.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(7,1,12,'../Content/imagenes/Etapas/Frutales1-Vegetativa.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(8,2,16,'../Content/imagenes/Etapas/Frutales2-Siembra.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(9,2,1,'../Content/imagenes/Etapas/Frutales2-Transplante.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(10,2,2,'../Content/imagenes/Etapas/Frutales2-Floracion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(11,2,3,'../Content/imagenes/Etapas/Frutales2-Fructificacion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(12,2,4,'../Content/imagenes/Etapas/Frutales2-Recoleccion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(13,2,12,'../Content/imagenes/Etapas/Frutales2-Vegetativa.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(14,2,13,'../Content/imagenes/Etapas/Frutales2-Maduracion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(15,2,15,'../Content/imagenes/Etapas/Frutales2-PicosCosecha.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(16,3,16,'../Content/imagenes/Etapas/Raices-Siembra.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(17,3,12,'../Content/imagenes/Etapas/Raices-Vegetativa.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(18,3,19,'../Content/imagenes/Etapas/Raices-tuberizacion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(19,3,2,'../Content/imagenes/Etapas/Raices-Floracion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(20,3,13,'../Content/imagenes/Etapas/Raices-Maduracion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(21,3,14,'../Content/imagenes/Etapas/Raices-Bulbificacion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(22,3,4,'../Content/imagenes/Etapas/Raices-Recoleccion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(23,4,12,'../Content/imagenes/Etapas/Hortalizas1-Vegetativa.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(24,4,14,'../Content/imagenes/Etapas/Hortalizas1-Bulbificacion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(25,4,2,'../Content/imagenes/Etapas/Hortalizas1-Floracion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(26,4,4,'../Content/imagenes/Etapas/Hortalizas1-Recoleccion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(27,5,12,'../Content/imagenes/Etapas/Hortalizas2-Vegetativa.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(28,5,1,'../Content/imagenes/Etapas/Hortalizas2-Transplante.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(29,5,2,'../Content/imagenes/Etapas/Hortalizas2-Floracion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(30,5,3,'../Content/imagenes/Etapas/Hortalizas2-Fructificacion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(31,5,4,'../Content/imagenes/Etapas/Hortalizas2-Recoleccion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(32,6,12,'../Content/imagenes/Etapas/Hortalizas3-Vegetativa.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(33,6,1,'../Content/imagenes/Etapas/Hortalizas3-Transplante.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(34,6,2,'../Content/imagenes/Etapas/Hortalizas3-Floracion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(35,6,3,'../Content/imagenes/Etapas/Hortalizas3-Fructificacion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(36,6,4,'../Content/imagenes/Etapas/Hortalizas3-Recoleccion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(37,6,20,'../Content/imagenes/Etapas/Hortalizas3-FructificacionRec.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(38,6,16,'../Content/imagenes/Etapas/Hortalizas3-Siembra.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(39,7,16,'../Content/imagenes/Etapas/Cereales1-Siembra.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(40,7,12,'../Content/imagenes/Etapas/Cereales1-Vegetativa.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(41,7,2,'../Content/imagenes/Etapas/Cereales1-Floracion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(42,7,17,'../Content/imagenes/Etapas/Cereales1-Maduraciondelgrano.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(43,7,4,'../Content/imagenes/Etapas/Cereales1-Recoleccion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(44,7,18,'../Content/imagenes/Etapas/Cereales1-Senescencia.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(45,7,13,'../Content/imagenes/Etapas/Cereales1-Maduracion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(46,8,16,'../Content/imagenes/Etapas/Cereales2-Siembra.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(47,8,12,'../Content/imagenes/Etapas/Cereales2-Vegetativa.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(48,8,2,'../Content/imagenes/Etapas/Cereales2-Floracion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(49,8,17,'../Content/imagenes/Etapas/Cereales2-Maduraciondelgrano.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(50,8,18,'../Content/imagenes/Etapas/Cereales2-Senescencia.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(51,9,12,'../Content/imagenes/Etapas/Industriales1-Vegetativa.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(52,9,13,'../Content/imagenes/Etapas/Industriales1-Maduracion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(53,9,4,'../Content/imagenes/Etapas/Industriales1-Recoleccion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(54,9,16,'../Content/imagenes/Etapas/Industriales1-Siembra.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(55,10,2,'../Content/imagenes/Etapas/Industriales2-Floracion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(56,10,16,'../Content/imagenes/Etapas/Industriales2-Siembra.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(57,10,3,'../Content/imagenes/Etapas/Industriales2-Fructificacion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(58,10,4,'../Content/imagenes/Etapas/Industriales2-Recoleccion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(59,11,5,'../Content/imagenes/Etapas/Ganaderos_ocupacion.png');
insert into dbo.EtapaGrupo(EtapaGrupoId,GrupoCultivoId,CultivoEtapaId,RutaIcono)values(60,11,6,'../Content/imagenes/Etapas/Ganaderos_descanso.png');

set identity_insert  dbo.EtapaGrupo off

--datos de grupo en cultivo:
update SEMapa.dbo.Cultivo set GrupoCultivoId=6 where cultivoId = 1;
update SEMapa.dbo.Cultivo set GrupoCultivoId=6 where cultivoId = 2;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 4;
update SEMapa.dbo.Cultivo set GrupoCultivoId=2 where cultivoId = 5;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 6;
update SEMapa.dbo.Cultivo set GrupoCultivoId=9 where cultivoId = 7;
update SEMapa.dbo.Cultivo set GrupoCultivoId=4 where cultivoId = 8;
update SEMapa.dbo.Cultivo set GrupoCultivoId=3 where cultivoId = 9;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 10;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 11;
update SEMapa.dbo.Cultivo set GrupoCultivoId=2 where cultivoId = 12;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 13;
update SEMapa.dbo.Cultivo set GrupoCultivoId=11 where cultivoId = 14;
update SEMapa.dbo.Cultivo set GrupoCultivoId=5 where cultivoId = 15;
update SEMapa.dbo.Cultivo set GrupoCultivoId=11 where cultivoId = 16;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 17;
update SEMapa.dbo.Cultivo set GrupoCultivoId=10 where cultivoId = 18;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 19;
update SEMapa.dbo.Cultivo set GrupoCultivoId=11 where cultivoId = 20;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 21;
update SEMapa.dbo.Cultivo set GrupoCultivoId=6 where cultivoId = 22;
update SEMapa.dbo.Cultivo set GrupoCultivoId=3 where cultivoId = 23;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 24;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 25;
update SEMapa.dbo.Cultivo set GrupoCultivoId=8 where cultivoId = 26;
update SEMapa.dbo.Cultivo set GrupoCultivoId=3 where cultivoId = 27;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 28;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 29;
update SEMapa.dbo.Cultivo set GrupoCultivoId=2 where cultivoId = 30;
update SEMapa.dbo.Cultivo set GrupoCultivoId=7 where cultivoId = 31;
update SEMapa.dbo.Cultivo set GrupoCultivoId=3 where cultivoId = 32;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 33;
update SEMapa.dbo.Cultivo set GrupoCultivoId=1 where cultivoId = 34;
update SEMapa.dbo.Cultivo set GrupoCultivoId=6 where cultivoId = 35;
