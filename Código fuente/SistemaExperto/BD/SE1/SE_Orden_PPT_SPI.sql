 UPDATE [sistencial_SE1].[dbo].[OpcionesVisualizacion]
 SET NombreOpcion='PPT (%)', NombreCortoOpcion = 'estaciones-ppt',
 NombreOpcionJScript='cambiarCapa(''estaciones_ppt'')'
 WHERE OpcionVisualizacionId=24

 UPDATE [sistencial_SE1].[dbo].[OpcionesVisualizacion]
 SET NombreOpcion='SPI', NombreCortoOpcion = 'estaciones-spi',
 NombreOpcionJScript='cambiarCapa(''estaciones_spi'')'
 WHERE OpcionVisualizacionId=25