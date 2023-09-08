--use sistencial_SEMapa
use SEMapa
go
alter table dbo.[CultivoDepartamento] add RutaMapa varchar(max) null
GO

update dbo.[CultivoDepartamento] set RutaMapa = '../Content/imagenes/Productividad/d6_c15.png'
where CultivoProductividadId = 2


update dbo.[CultivoDepartamento] set RutaMapa = '../Content/imagenes/Productividad/d1_c1.png'
where CultivoProductividadId = 1