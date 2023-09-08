-- actualiza ruta de practica de manejo si encuentra Practicas cambia por Planes
UPDATE [SEMapa].[dbo].[CultivoMunicipio] SET RutaPracticaManejo = REPLACE(CAST(RutaPracticaManejo AS varchar(MAX))
                                               ,'Adjuntos/Practicas/', 'Adjuntos/Planes/')
FROM [SEMapa].[dbo].[CultivoMunicipio]
WHERE CHARINDEX('Adjuntos/Practicas/',CAST(RutaPracticaManejo as varchar(MAX)))>0
go
