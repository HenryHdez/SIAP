--Sistencial - Eduardo González Jaimes
--11/12/2016
--Proyecto SEMapa2
--Cambio de nombres de condiciones de Humedad a Exceso y Seco a Déficit
UPDATE [SEMapa].[dbo].[Condicion] SET Nombre= 'Exceso' WHERE CondicionId = 0
UPDATE [SEMapa].[dbo].[Condicion] SET Nombre= 'Déficit' WHERE CondicionId = 2