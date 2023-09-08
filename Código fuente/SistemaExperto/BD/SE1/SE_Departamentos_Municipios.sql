--Departamentos 30/08/2015
SET IDENTITY_INSERT [dbo].[Departamento] ON 
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(5,68, 'Santander')
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(6,15, 'Boyacá')
SET IDENTITY_INSERT [dbo].[Departamento] OFF
GO

--Municipios
SET IDENTITY_INSERT [dbo].[Municipio] ON 
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(21,68385, 'Landázuri',5)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(22,68547, 'Piedecuesta',5)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(23,68689, 'San Vicente de Chucurí',5)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(24,15516, 'Paipa',6)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(25,15762, 'Sora',6)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(26,15806, 'Tibasosa',6)
SET IDENTITY_INSERT [dbo].[Municipio] OFF 
GO

--Departamentos 03/09/2015
SET IDENTITY_INSERT [dbo].[Departamento] ON 
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(7,52, 'Nariño')
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(8,19, 'Cauca')
SET IDENTITY_INSERT [dbo].[Departamento] OFF
GO

--Municipios
SET IDENTITY_INSERT [dbo].[Municipio] ON 
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(27,52110, 'Buesaco',7)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(28,52399, 'La Unión',7)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(29,52885, 'Yacuanquer',7)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(30,19256, 'El Tambo',8)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(31,19450, 'Mercaderes',8)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(32,19532, 'Patía',8)
SET IDENTITY_INSERT [dbo].[Municipio] OFF 
GO

--Departamentos 06/09/2015
SET IDENTITY_INSERT [dbo].[Departamento] ON 
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(9,41, 'Huila')
SET IDENTITY_INSERT [dbo].[Departamento] OFF
GO

--Municipios
SET IDENTITY_INSERT [dbo].[Municipio] ON 
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(33,41020, 'Algeciras',9)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(34,41378, 'La Argentina',9)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(35,41396, 'La Plata',9)
SET IDENTITY_INSERT [dbo].[Municipio] OFF 
GO

--Departamentos 12/09/2015
SET IDENTITY_INSERT [dbo].[Departamento] ON 
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(10,'47', 'Magdalena')
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(11,'23', 'Córdoba')
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(12,'05', 'Antioquia')
SET IDENTITY_INSERT [dbo].[Departamento] OFF
GO

--Municipios
SET IDENTITY_INSERT [dbo].[Municipio] ON 
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(36,'47288', 'Fundación',10)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(37,'47660', 'Sabanas de San Ángel',10)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(38,'47980', 'Zona bananera',10)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(39,'23068', 'Ayapel',11)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(40,'23417', 'Lorica',11)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(41,'23686', 'San Pelayo',11)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(42,'05234', 'Dabeiba',12)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(43,'05364', 'Jardín',12)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(44,'05659', 'San Juan de Urabá',12)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(45,'05674', 'San Vicente Ferrer',12)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(46,'05761', 'Sopetrán',12)
SET IDENTITY_INSERT [dbo].[Municipio] OFF 
GO

--Departamentos 13/09/2015
SET IDENTITY_INSERT [dbo].[Departamento] ON 
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(13,'76', 'Valle del Cauca')
SET IDENTITY_INSERT [dbo].[Departamento] OFF
GO

--Municipios
SET IDENTITY_INSERT [dbo].[Municipio] ON 
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(47,'76036', 'Andalucía',13)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(48,'76306', 'Ginebra',13)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(49,'76622', 'Roldanillo',13)
SET IDENTITY_INSERT [dbo].[Municipio] OFF 
GO

--Departamentos 23/09/2015
SET IDENTITY_INSERT [dbo].[Departamento] ON 
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(14,'20', 'Cesar')
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(15,'44', 'La Guajira')
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(16,'73', 'Tolima')
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(17,'70', 'Sucre')
SET IDENTITY_INSERT [dbo].[Departamento] OFF
GO

--Departamentos Municipios 17/10/2015
SET IDENTITY_INSERT [dbo].[Departamento] ON 
INSERT [sistencial_SE1].[dbo].[Departamento](DepartamentoId,CodigoDane, Nombre) VALUES(18,'', 'Chocó')
SET IDENTITY_INSERT [dbo].[Departamento] OFF
GO
SET IDENTITY_INSERT [dbo].[Municipio] ON 
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(50,'20228', 'Curumaní',14)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(51,'20175', 'Chimichagua',14)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(52,'20001', 'Valledupar',14)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(53,'44090', 'Dibulla',15)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(54,'44847', 'Uribia',15)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(55,'44279', 'Fonseca',15)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(56,'73483', 'Natagaima',16)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(57,'73283', 'Fresno',16)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(58,'73067', 'Ataco',16)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(59,'70400', 'La Unión',17)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(60,'70429', 'Majagual',17)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(61,'70823', 'Tolú Viejo',17)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(62,'27006', 'Acandí',18)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(63,'27615', 'Riosucio',18)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(64,'27787', 'Tadó',18)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(65,'27150', 'El Carmen del Darién',18)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(66,'27800', 'Unguía',18)
SET IDENTITY_INSERT [dbo].[Municipio] OFF 
GO

SET IDENTITY_INSERT [dbo].[Municipio] ON 
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(67,'52378', 'La Cruz',7)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(68,'52687', 'San Lorenzo',7)
INSERT [sistencial_SE1].[dbo].[Municipio](MunicipioId,CodigoDane,Nombre,DepartamentoId) VALUES(69,'52694', 'San Pedro de Cartago',7)
SET IDENTITY_INSERT [dbo].[Municipio] OFF 
GO


