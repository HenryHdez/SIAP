DECLARE @IDMunicipio INT
DECLARE @IDCapaMunicipio numeric(18,0)
DECLARE @contadorTotal INT

SET @IDCapaMunicipio = (SELECT top 1 CapaMunicipioId from sistencial_SE1.dbo.CapasMunicipios ORDER BY 1 DESC)
SET @contadorTotal = 0

DECLARE cursorNuevosMun CURSOR FOR
select MunicipioId from sistencial_SE1.dbo.Municipio where MunicipioId not in (select MunicipioId from sistencial_SE1.dbo.CapasMunicipios)


Open cursorNuevosMun

Fetch Next from cursorNuevosMun INTO @IDMunicipio
While @@FETCH_STATUS = 0
BEGIN

set @IDCapaMunicipio =  @IDCapaMunicipio+1;


        SET IDENTITY_INSERT sistencial_SE1.[dbo].CapasMunicipios ON   
		INSERT INTO sistencial_SE1.[dbo].[CapasMunicipios] ([CapaMunicipioId], [CapaId], [MunicipioId], [ExplicacionMapa]) 
		VALUES (@IDCapaMunicipio, 15, @IDMunicipio, '');	
		set @IDCapaMunicipio =  @IDCapaMunicipio+1;
		INSERT INTO sistencial_SE1.[dbo].[CapasMunicipios] ([CapaMunicipioId], [CapaId], [MunicipioId], [ExplicacionMapa]) 
		VALUES (@IDCapaMunicipio, 16, @IDMunicipio, '');
		set @IDCapaMunicipio =  @IDCapaMunicipio+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasMunicipios] ([CapaMunicipioId], [CapaId], [MunicipioId], [ExplicacionMapa]) 
		VALUES (@IDCapaMunicipio, 19, @IDMunicipio, '');
		set @IDCapaMunicipio =  @IDCapaMunicipio+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasMunicipios] ([CapaMunicipioId], [CapaId], [MunicipioId], [ExplicacionMapa]) 
		VALUES (@IDCapaMunicipio, 20, @IDMunicipio, '');
		set @IDCapaMunicipio =  @IDCapaMunicipio+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasMunicipios] ([CapaMunicipioId], [CapaId], [MunicipioId], [ExplicacionMapa]) 
		VALUES (@IDCapaMunicipio, 21, @IDMunicipio, '');
		set @IDCapaMunicipio =  @IDCapaMunicipio+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasMunicipios] ([CapaMunicipioId], [CapaId], [MunicipioId], [ExplicacionMapa]) 
		VALUES (@IDCapaMunicipio, 22, @IDMunicipio, '');		
		SET IDENTITY_INSERT sistencial_SE1.[dbo].CapasMunicipios OFF 
	
		PRINT 'Fin insercion CapaMunicipio para municipioID:'+CAST(@IDMunicipio AS VARCHAR)

		
		SET @contadorTotal = @contadorTotal+1
        Fetch Next from cursorNuevosMun INTO @IDMunicipio
		
END
PRINT '-----TOTAL Municipios Parametrizados:'+ CAST(@contadorTotal AS VARCHAR)
close cursorNuevosMun
deallocate cursorNuevosMun

