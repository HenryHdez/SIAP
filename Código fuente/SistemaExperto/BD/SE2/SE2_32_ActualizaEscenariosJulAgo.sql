--USE sistencial_SEMapa
USE SEMapa
GO
--Cesar 1696 ok
delete dbo.MunicipioEscenario where MunicipioId in(50,51,52)
--La Guajira 725 ok
delete dbo.MunicipioEscenario where MunicipioId in(54,55)
--Tolima 1020 ok
delete dbo.MunicipioEscenario where MunicipioId in(56,57,58)
--Roldanillo 265 ok
delete dbo.MunicipioEscenario where MunicipioId =49
--Landazuri 306 382 ok
delete dbo.MunicipioEscenario where MunicipioId =21
--Piedecuesta 211 334 ok
delete dbo.MunicipioEscenario where MunicipioId =22