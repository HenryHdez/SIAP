--Sistencial - Eduardo González Jaimes
--11/12/2016
--Proyecto SEMapa2
--Relaciones entre cultivos y departamentos para el módulo de Productividad

--Se elimina el registro para coliflor de CultivoProductividad y CultivoDepartamento
DELETE FROM [SEMapa].[dbo].[CultivoDepartamento]
WHERE CultivoProductividadId=2
GO
DELETE FROM [SEMapa].[dbo].[CultivoProductividad]
WHERE CultivoProductividadId=2
GO

--Tomate: Antioquia, Boyacá y Cundinamarca
INSERT INTO [SEMapa].[dbo].[CultivoDepartamento] (CultivoProductividadId, DepartamentoId, RutaMapa) VALUES
(1,4,'/Content/imagenes/Productividad/d1_c6.png'),
(1,6,'/Content/imagenes/Productividad/d1_c6.png'),
(1,12,'/Content/imagenes/Productividad/d1_c6.png')

--Maíz: Córdoba, Tolima, Cauca, Valle del Cauca y Nariño 
INSERT INTO [SEMapa].[dbo].[CultivoDepartamento] (CultivoProductividadId, DepartamentoId, RutaMapa) VALUES
(3,7,'/Content/imagenes/Productividad/d1_c6.png'),
(3,8,'/Content/imagenes/Productividad/d1_c6.png'),
(3,11,'/Content/imagenes/Productividad/d1_c6.png'),
(3,13,'/Content/imagenes/Productividad/d1_c6.png'),
(3,16,'/Content/imagenes/Productividad/d1_c6.png')

--Papa : Cundinamarca, Boyacá y Nariño 
INSERT INTO [SEMapa].[dbo].[CultivoDepartamento] (CultivoProductividadId, DepartamentoId, RutaMapa) VALUES
(4,4,'/Content/imagenes/Productividad/d1_c6.png'),
(4,7,'/Content/imagenes/Productividad/d1_c6.png'),
(4,8,'/Content/imagenes/Productividad/d1_c6.png')

--Plátano: Antioquia, Huila, Tolima, Valle del Cauca y Santander 
INSERT INTO [SEMapa].[dbo].[CultivoDepartamento] (CultivoProductividadId, DepartamentoId, RutaMapa) VALUES
(5,5,'/Content/imagenes/Productividad/d1_c6.png'),
(5,9,'/Content/imagenes/Productividad/d1_c6.png'),
(5,12,'/Content/imagenes/Productividad/d1_c6.png'),
(5,13,'/Content/imagenes/Productividad/d1_c6.png'),
(5,16,'/Content/imagenes/Productividad/d1_c6.png')

--Frijol:Córdoba, Cundinamarca, Tolima, Cauca y Nariño
INSERT INTO [SEMapa].[dbo].[CultivoDepartamento] (CultivoProductividadId, DepartamentoId, RutaMapa) VALUES
(6,4,'/Content/imagenes/Productividad/d1_c6.png'),
(6,7,'/Content/imagenes/Productividad/d1_c6.png'),
(6,8,'/Content/imagenes/Productividad/d1_c6.png'),
(6,11,'/Content/imagenes/Productividad/d1_c6.png'),
(6,16,'/Content/imagenes/Productividad/d1_c6.png')