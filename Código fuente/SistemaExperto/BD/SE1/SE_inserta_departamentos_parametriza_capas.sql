DECLARE @IDDepartamento INT
DECLARE @IDCapaDepartamento numeric(18,0)
DECLARE @contadorTotal INT

SET @IDCapaDepartamento = (SELECT top 1 CapaDepartamentoId from sistencial_SE1.dbo.CapasDepartamentos ORDER BY 1 DESC)
SET @contadorTotal = 0

DECLARE cursorNuevosDep CURSOR FOR
select DepartamentoId from sistencial_SE1.dbo.Departamento where DepartamentoId not in (select DepartamentoId from sistencial_SE1.dbo.CapasDepartamentos)


Open cursorNuevosDep

Fetch Next from cursorNuevosDep INTO @IDDepartamento
While @@FETCH_STATUS = 0
BEGIN

set @IDCapaDepartamento =  @IDCapaDepartamento+1;


        SET IDENTITY_INSERT sistencial_SE1.[dbo].CapasDepartamentos ON   
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 1, @IDDepartamento, '');	
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 2, @IDDepartamento, '');
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 3, @IDDepartamento, '');
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 4, @IDDepartamento, '');
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 5, @IDDepartamento, '');
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 6, @IDDepartamento, '');	
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 7, @IDDepartamento, '');
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 8, @IDDepartamento, '');	
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 9, @IDDepartamento, '');
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 10, @IDDepartamento, '');
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 11, @IDDepartamento, '');
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 12, @IDDepartamento, '');
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 13, @IDDepartamento, '');
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 14, @IDDepartamento, '');
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 17, @IDDepartamento, '');
		set @IDCapaDepartamento =  @IDCapaDepartamento+1;	
		INSERT INTO sistencial_SE1.[dbo].[CapasDepartamentos] ([CapaDepartamentoId], [CapaId], [DepartamentoId], [ExplicacionMapa]) 
		VALUES (@IDCapaDepartamento, 18, @IDDepartamento, '');
		SET IDENTITY_INSERT sistencial_SE1.[dbo].CapasDepartamentos OFF 
	
		PRINT 'Fin insercion CapaDepartamento para DepartamentoID:'+CAST(@IDDepartamento AS VARCHAR)

		
		SET @contadorTotal = @contadorTotal+1
        Fetch Next from cursorNuevosDep INTO @IDDepartamento
		
END
PRINT '-----TOTAL Departamentos Parametrizados:'+ CAST(@contadorTotal AS VARCHAR)
close cursorNuevosDep
deallocate cursorNuevosDep

