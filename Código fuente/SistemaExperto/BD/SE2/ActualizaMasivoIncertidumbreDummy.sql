  --select * from SEMapa.dbo.Estacion where Nombre like '%Tungu%'--853

  --select distinct YEAR(fECHA) from [SEMapa].[dbo].[EstacionMensual]--12805
  --WHERE YEAR(Fecha)> 2005
  --AND EstacionId = 853

  --SELECT * from [SEMapa].[dbo].[EstacionMensual] WHERE EstacionId = 853



	update [SEMapa].[dbo].estacionMensual set ValorMaximo = (2.95 + Precipitacion)
	where EstacionId = 853
	and YEAR(Fecha)> 2005

		
	update [SEMapa].[dbo].estacionMensual set ValorMinimo = (Precipitacion-0.5)
	where EstacionId = 853
	and YEAR(Fecha)> 2005
	and Precipitacion >0

		update [SEMapa].[dbo].estacionMensual set ValorMinimo = (Precipitacion)
	where EstacionId = 853
	and YEAR(Fecha)> 2005
	and Precipitacion =0

