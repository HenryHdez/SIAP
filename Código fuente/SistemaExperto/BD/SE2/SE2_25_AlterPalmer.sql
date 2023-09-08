ALTER TABLE SEMapa.dbo.EstacionMensual ADD ExistePrediccion bit default 0
GO

update SEMapa.dbo.EstacionMensual set ExistePrediccion = 1 
where spi != 0;

update SEMapa.dbo.EstacionMensual set ExistePrediccion = 0 
where spi = 0;