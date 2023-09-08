DECLARE @IDem INT
DECLARE @Precipitacion REAL
DECLARE @VMinActual REAL
DECLARE @VminCalculado REAL
DECLARE @VMaxActual REAL
DECLARE @VmaxCalculado REAL
DECLARE @CantidadActualizados INT
DECLARE @CantidadVerificados INT
DECLARE @CantidadAnalisisCero INT

SET @CantidadVerificados = 0;
SET @CantidadActualizados = 0;
SET @CantidadAnalisisCero = 0;

--cursor para buscar los registros 
DECLARE cursorEstacionMensual CURSOR FOR

select EstacionMensualId, Precipitacion,ValorMinimo, ValorMaximo from SEMapa.dbo.EstacionMensual
where ValorMinimo is null 

Open cursorEstacionMensual

Fetch Next from cursorEstacionMensual INTO @IDem, @Precipitacion, @VMinActual, @VMaxActual
While @@FETCH_STATUS = 0

BEGIN

SET @CantidadVerificados = @CantidadVerificados+1;
-- si precipitacion es cero actualiza minimo a cero y maximo a 20
  IF ((@Precipitacion =0))
  BEGIN
   SET @VmaxCalculado =20;
   SET @VminCalculado = 0;
   update SEMapa.dbo.EstacionMensual set ValorMinimo = @VminCalculado , ValorMaximo = @VmaxCalculado
		where EstacionMensualId = @IDem;

	SET @CantidadActualizados = @CantidadActualizados+1;
	SET @CantidadAnalisisCero = @CantidadAnalisisCero+1;
	PRINT 'Actualizado registro estacion mensual con ppt 0:'+CAST(@IDem AS VARCHAR) +  'Vmin actualizado a '+CAST(@VminCalculado AS VARCHAR)+ 'Vmax actualizado a:' + CAST(@VmaxCalculado AS VARCHAR);
   END
   -- si precipitacion es diferente a cero y no null actualiza minimo como ppt-20 y maximo con ppt+20
  ELSE IF((@Precipitacion IS NOT NULL))
  BEGIN
   SET @VminCalculado = @Precipitacion-20;
   SET @VmaxCalculado = @Precipitacion+20;

   --si hay calculo negativo lo deja en 0:
   IF (@VminCalculado < 0) BEGIN SET @VminCalculado = 0;  END
   IF (@VmaxCalculado < 0) BEGIN SET @VmaxCalculado = 0 ; END

   update SEMapa.dbo.EstacionMensual set ValorMinimo = @VminCalculado , ValorMaximo = @VmaxCalculado
		where EstacionMensualId = @IDem;

	SET @CantidadActualizados = @CantidadActualizados+1	
	PRINT 'Actualizado registro estacion mensual con ppt:'+CAST(@Precipitacion AS VARCHAR) +' ID:'+CAST(@IDem AS VARCHAR) +  ' Vmin actualizado a '+CAST(@VminCalculado AS VARCHAR)+ 'Vmax actualizado a:' + CAST(@VmaxCalculado AS VARCHAR);
  END
 
Fetch Next from cursorEstacionMensual INTO  @IDem, @Precipitacion, @VMinActual, @VMaxActual
		
END
PRINT '----TOTAL REGISTROS ESTACION MENSUAL VERIFICADOS:'+CAST(@CantidadVerificados AS VARCHAR)
PRINT '----------TOTAL REGISTROS ESTACION MENSUAL ACTUALIZADOS:'+CAST(@CantidadActualizados AS VARCHAR)
PRINT '--------------TOTAL REGISTROS ACTUALIZADOS CUANDO PPT ESTABA EN CERO:'+CAST(@CantidadAnalisisCero AS VARCHAR)
close cursorEstacionMensual
deallocate cursorEstacionMensual

