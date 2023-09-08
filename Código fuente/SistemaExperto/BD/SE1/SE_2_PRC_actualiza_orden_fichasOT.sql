DECLARE @IDFicha INT
DECLARE @ListaOpcionIDAct numeric(18,0)
DECLARE @contadorTotal INT
DECLARE @FichaOpcionId numeric(18,0)
DECLARE @Orden INT

--SET @IDCapaMunicipio = (SELECT top 1 CapaMunicipioId from se.dbo.CapasMunicipios ORDER BY 1 DESC)
SET @contadorTotal = 0


DECLARE cursorListaOpcId CURSOR FOR
SELECT DISTINCT ListaOpcionesId from SE.DBO.FichaOpcion 
--WHERE ListaOpcionesId not IN (1,2)

Open cursorListaOpcId

Fetch Next from cursorListaOpcId INTO @ListaOpcionIDAct
While @@FETCH_STATUS = 0
BEGIN
set @Orden =  1;

DECLARE cursorOT CURSOR FOR
select FichaOpcionId from SE.DBO.FichaOpcion where ListaOpcionesId = @ListaOpcionIDAct order by FichaOpcionId

Open cursorOT

	Fetch Next from cursorOT INTO @FichaOpcionId
	While @@FETCH_STATUS = 0
	BEGIN



		update SE.DBO.FichaOpcion set Orden = @Orden
		where FichaOpcionId = @FichaOpcionId

        
		PRINT 'Registro actualizado para ID FICHA :'+CAST(@FichaOpcionId AS VARCHAR)

		SET @Orden = @Orden+1
		SET @contadorTotal = @contadorTotal+1
        Fetch Next from cursorOT INTO @FichaOpcionId
		
	END
	close cursorOT
	deallocate cursorOT

	 Fetch Next from cursorListaOpcId INTO @ListaOpcionIDAct
	 PRINT '--FIN actualiza para OPCION ID:'+CAST(@ListaOpcionIDAct AS VARCHAR)
END
PRINT '-----TOTAL REGISTROS ACTUALIZADOS:'+ CAST(@contadorTotal AS VARCHAR)
close cursorListaOpcId
deallocate cursorListaOpcId

