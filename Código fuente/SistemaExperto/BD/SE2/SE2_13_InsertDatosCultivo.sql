--actualiza e inserta datos de cultivo de acuerdo a excel 8 - DatosCultivosSueloModuloProductividad.xls
update SEMapa.dbo.Cultivo set TiempoInicial = 30, TiempoMedia = 50,TiempoDesarrollo=60, TiempoFinal =40, KInicial = 0.3, KMedia = 1.2, KFinal = 0.6, ZrMin = 0.15,ZrMax =0.35, JMin=1, JMax = 48 where Nombre = 'Maíz blanco ';
update SEMapa.dbo.Cultivo set TiempoInicial = 30, TiempoMedia = 40,TiempoDesarrollo=40, TiempoFinal =25, KInicial = 0.7, KMedia = 1.15, KFinal = 0.9, ZrMin = 0.17,ZrMax =0.5, JMin=1, JMax = 50 where Nombre = 'Tomate';
update SEMapa.dbo.Cultivo set TiempoInicial = 30, TiempoMedia = 35,TiempoDesarrollo=50, TiempoFinal =30, KInicial = 0.5, KMedia = 1.15, KFinal = 0.75, ZrMin = 0.2,ZrMax =0.55, JMin=1, JMax = 59 where Nombre = 'Papa';
update SEMapa.dbo.Cultivo set TiempoInicial = 120, TiempoMedia = 60,TiempoDesarrollo=180, TiempoFinal =5, KInicial = 1, KMedia = 1.2, KFinal = 1.1, ZrMin = 0.9,ZrMax =0.9, JMin=1, JMax = 1 where Nombre = 'Plátano';
insert into SEMapa.dbo.Cultivo(Nombre,TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia,ACFinal,ZrMin,ZrMax,JMin,JMax,IndicadorMapa)
values('Frijol',20,30,30,10,0.4,1.15,0.55,0,0,0,0.15,0.35,1,50,'');
--
update SEMapa.dbo.CultivoProductividad set KyInicial = 0.4, KyDesarrollo=1.1,KyMedio=0.8,KyFinal=0.4,AMP =0.4 where CultivoProductividadId = 1;
insert into SEMapa.dbo.CultivoProductividad (CultivoId,KyInicial,KyDesarrollo,KyMedio,KyFinal,AMP,EtapaInicial,EtapaMedio,EtapaDesarrollo,EtapaFinal)values((select cultivoId from SEMapa.dbo.Cultivo where nombre = 'Maíz blanco '),0.4, 1.5,0.5,0.2,0.55,0,0,0,0);
insert into SEMapa.dbo.CultivoProductividad (CultivoId,KyInicial,KyDesarrollo,KyMedio,KyFinal,AMP,EtapaInicial,EtapaMedio,EtapaDesarrollo,EtapaFinal)values((select cultivoId from SEMapa.dbo.Cultivo where nombre = 'Papa'),0.6, 0.6,0.7,0.2,0.35,0,0,0,0);
insert into SEMapa.dbo.CultivoProductividad (CultivoId,KyInicial,KyDesarrollo,KyMedio,KyFinal,AMP,EtapaInicial,EtapaMedio,EtapaDesarrollo,EtapaFinal)values((select cultivoId from SEMapa.dbo.Cultivo where nombre = 'Plátano'),1.2, 1.2,1.2,1.2,0.35,0,0,0,0);
insert into SEMapa.dbo.CultivoProductividad (CultivoId,KyInicial,KyDesarrollo,KyMedio,KyFinal,AMP,EtapaInicial,EtapaMedio,EtapaDesarrollo,EtapaFinal)values((select cultivoId from SEMapa.dbo.Cultivo where nombre = 'Frijol'),0.2, 1.1,0.75,0.2,0.45,0,0,0,0);