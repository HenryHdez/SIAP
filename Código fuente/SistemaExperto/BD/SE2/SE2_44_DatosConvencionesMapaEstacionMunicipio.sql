use SEMapa
go
update dbo.Convenciones set ValorLayer = 'dentro' where ConvencionId = 365 and OpcionVisualizacionId = 24
update dbo.Convenciones set ValorLayer = 'encima' where ConvencionId = 366 and OpcionVisualizacionId = 24
update dbo.Convenciones set ValorLayer = 'debajo' where ConvencionId = 367 and OpcionVisualizacionId = 24
insert into dbo.convenciones (NombreIndicador,ValorLayer,Color,OpcionVisualizacionId)values('Sin información','sinppt','grey',24)

update dbo.Convenciones set ValorLayer = 'humedo' where ConvencionId = 368 and OpcionVisualizacionId = 25
update dbo.Convenciones set ValorLayer = 'normal' where ConvencionId = 369 and OpcionVisualizacionId = 25
update dbo.Convenciones set ValorLayer = 'seco' where ConvencionId = 370 and OpcionVisualizacionId = 25

insert into dbo.convenciones (NombreIndicador,ValorLayer,Color,OpcionVisualizacionId)values('Sin información','sinspi','grey',25)