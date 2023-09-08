--Modificación capas
UPDATE [sistencial_SE1].[dbo].[Capas]
SET NombreCaracterizacion = 'Escenarios agroclimáticos', IdentificadorCaracterizacion='escenarios'
WHERE CapaId=20

UPDATE [sistencial_SE1].[dbo].[Capas]
SET NombreCaracterizacion = 'Aptitud agroclimática', IdentificadorCaracterizacion='aptitud'
WHERE CapaId=21
GO
--Modificación relaciones en CapasMunicipios
UPDATE [sistencial_SE1].[dbo].[CapasMunicipios]
SET CapaId=1
WHERE CapaId=20
GO

UPDATE [sistencial_SE1].[dbo].[CapasMunicipios]
SET CapaId=20
WHERE CapaId=21
GO

UPDATE [sistencial_SE1].[dbo].[CapasMunicipios]
SET CapaId=21
WHERE CapaId=1
GO

--Modificación relaciones en opciones de visualización
UPDATE [sistencial_SE1].[dbo].[OpcionesVisualizacion]
SET CapaId=13
WHERE CapaId=20
GO

UPDATE [sistencial_SE1].[dbo].[OpcionesVisualizacion]
SET CapaId=20
WHERE CapaId=21
GO

UPDATE [sistencial_SE1].[dbo].[OpcionesVisualizacion]
SET CapaId=21
WHERE CapaId=13

GO