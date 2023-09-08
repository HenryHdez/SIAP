update se.dbo.Capas
set IdentificadorCaracterizacion = 'estaciones_municipio'
where capaid = 19
update se.dbo.Capas
set IdentificadorCaracterizacion = 'anomalia'
where capaid = 15
update se.dbo.OpcionesVisualizacion set NombreTipoOpcion = 'Ninguna'
where capaid = 15
and OpcionVisualizacionId = 21
update se.dbo.OpcionesVisualizacion set NombreCortoOpcion = 'aptitud-exceso', NombreOpcionJScript = 'cambiarCapa(''aptitud_agroclimatica_exceso'')'
where capaid = 20
and OpcionVisualizacionId = 26
update se.dbo.OpcionesVisualizacion set NombreCortoOpcion = 'aptitud-normal', NombreOpcionJScript = 'cambiarCapa(''aptitud_agroclimatica_normal'')'
where capaid = 20
and OpcionVisualizacionId = 27

update se.dbo.OpcionesVisualizacion set NombreCortoOpcion = 'aptitud-deficit', NombreOpcionJScript = 'cambiarCapa(''aptitud_agroclimatica_deficit'')'
where capaid = 20
and OpcionVisualizacionId = 28

update se.dbo.Capas
set IdentificadorCaracterizacion = 'aptitud'
where capaid = 20

update se.dbo.Capas
set IdentificadorCaracterizacion = 'escenarios'
where capaid = 21

update se.dbo.OpcionesVisualizacion set NombreCortoOpcion = 'estaciones-ppt', NombreOpcionJScript = 'cambiarCapa(''estaciones_ppt'')'
where capaid = 19
and OpcionVisualizacionId = 25

update se.dbo.OpcionesVisualizacion set NombreCortoOpcion = 'estaciones-spi', NombreOpcionJScript = 'cambiarCapa(''estaciones_spi'')'
where capaid = 19
and OpcionVisualizacionId = 24

update se.dbo.OpcionesVisualizacion set NombreCortoOpcion = 'inundacion-expansion', NombreOpcionJScript = 'cambiarCapa(''expansion'')'
where capaid = 16
and OpcionVisualizacionId = 22

update se.dbo.OpcionesVisualizacion set NombreCortoOpcion = 'inundacion-contraccion', NombreOpcionJScript = 'cambiarCapa(''contraccion'')'
where capaid = 16
and OpcionVisualizacionId = 23