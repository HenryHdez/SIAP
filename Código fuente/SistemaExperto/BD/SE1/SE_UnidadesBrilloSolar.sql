--14/10/2015
--Modificación de unidades para las convenciones en brillo solar
UPDATE [sistencial_SE1].[dbo].[Convenciones]
SET NombreIndicador = REPLACE(NombreIndicador,' horas', ' mm/horas')
WHERE OpcionVisualizacionId = 8
GO