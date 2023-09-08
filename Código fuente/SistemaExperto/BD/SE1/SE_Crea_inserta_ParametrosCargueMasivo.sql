drop table se.[dbo].[ParametrosCargueMasivo];

CREATE TABLE se.[dbo].[ParametrosCargueMasivo] (
    [ParametrosCargueMasivoID] INT            IDENTITY (1, 1) NOT NULL,
    [Identificador]                   NVARCHAR (255) NOT NULL,
    [NombreTablaBD]      NVARCHAR (255) NOT NULL,
	[NombreColumnaExcel] NVARCHAR (255) NOT NULL,
	[NombreColumnaBD]    NVARCHAR (255) NOT NULL,
    [Descripcion]         NVARCHAR (255) NULL,
  
    CONSTRAINT [PK_dbo.ParametrosCargueMasivo] PRIMARY KEY CLUSTERED ([ParametrosCargueMasivoID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UK_ParametrosCargueMasivo]
    ON se.[dbo].[ParametrosCargueMasivo]([Identificador] ASC);

	GO

--insercion parametros codigos:
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_CODIGO_ESTACION_CARGUE','EstacionMensual','CodigoIdeamEstacion','CodigoIdeamEstacion', 'Corresponde al nombre de la columna <<CodigoiDEAMEstacion>> en el excel de cargue masivo de  estaciones mensuales y que posteriormente se usa para colocar el EstacionId en el cargue de la EstacionMensual');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_ANIO_ESTACION_CARGUE','EstacionMensual','Anio','Fecha', 'Corresponde al nombre de la columna <<Anio>>en el excel de cargue masivo de  estaciones mensuales y que posteriormente se usa para colocar la fecha en el cargue de la EstacionMensual');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_MES_ESTACION_CARGUE','EstacionMensual','Mes','Fecha', 'Corresponde al nombre de la columna <<Mes >>en el excel de cargue masivo de  estaciones mensuales y que posteriormente se usa para colocar la fecha en el cargue de la EstacionMensual');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_DIA_ESTACION_CARGUE','EstacionMensual','Dia','Fecha', 'Corresponde al nombre de la columna <<Dia>>en el excel de cargue masivo de  estaciones mensuales y que posteriormente se usa para colocar la fecha en el cargue de la EstacionMensual');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_TMIN_ESTACION_CARGUE','EstacionMensual','Tmin','Tmin', 'Corresponde al nombre de la columna <<Tmin>> en el excel de cargue masivo de  estaciones mensuales.');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_TMAX_ESTACION_CARGUE','EstacionMensual','Tmax','Tmax', 'Corresponde al nombre de la columna <<Tmax>> en el excel de cargue masivo de  estaciones mensuales.');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_PPT_ESTACION_CARGUE','EstacionMensual','Precipitacion','Precipitacion', 'Corresponde al nombre de la columna <<Precipitacion>> en el excel de cargue masivo de  estaciones mensuales.');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_VIENTO_ESTACION_CARGUE','EstacionMensual','Viento','Viento', 'Corresponde al nombre de la columna <<Viento>> en el excel de cargue masivo de  estaciones mensuales.');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_TMINREAL_ESTACION_CARGUE','EstacionMensual','TminReal','TminReal', 'Corresponde al nombre de la columna <<TminReal>> en el excel de cargue masivo de  estaciones mensuales.');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_TMAXREAL_ESTACION_CARGUE','EstacionMensual','TmaxReal','TmaxReal', 'Corresponde al nombre de la columna <<TmaxReal>> en el excel de cargue masivo de  estaciones mensuales.');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_PPTREAL_ESTACION_CARGUE','EstacionMensual','PrecipitacionReal','PrecipitacionReal', 'Corresponde al nombre de la columna <<PrecipitacionReal>> en el excel de cargue masivo de  estaciones mensuales.');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_VIENTOREAL_ESTACION_CARGUE','EstacionMensual','VientoReal','VientoReal', 'Corresponde al nombre de la columna <<VientoReal>> en el excel de cargue masivo de  estaciones mensuales.');
--INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_ETO_ESTACION_CARGUE','EstacionMensual','Eto','Eto', 'Corresponde al nombre de la columna <<Eto>> en el excel de cargue masivo de  estaciones mensuales.');
--INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_ETOREAL_ESTACION_CARGUE','EstacionMensual','EtoReal','EtoReal', 'Corresponde al nombre de la columna <<EtoReal>> en el excel de cargue masivo de  estaciones mensuales.');
--INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_SPI_ESTACION_CARGUE','EstacionMensual','SPI','SPI', 'Corresponde al nombre de la columna <<SPI>> en el excel de cargue masivo de  estaciones mensuales.');
--INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_SPIREAL_ESTACION_CARGUE','EstacionMensual','SPIReal','SPIReal', 'Corresponde al nombre de la columna <<SPIReal>> en el excel de cargue masivo de  estaciones mensuales.');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_PPTDEBAJO_ESTACION_CARGUE','EstacionMensual','pptDebajo','pptDebajo', 'Corresponde al nombre de la columna <<pptDebajo>> en el excel de cargue masivo de  estaciones mensuales.');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_PPTDENTRO_ESTACION_CARGUE','EstacionMensual','pptDentro','pptDentro', 'Corresponde al nombre de la columna <<pptDentro>> en el excel de cargue masivo de  estaciones mensuales.');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_PPTSOBRE_ESTACION_CARGUE','EstacionMensual','pptSobre','pptSobre', 'Corresponde al nombre de la columna <<pptSobre>> en el excel de cargue masivo de  estaciones mensuales.');
INSERT INTO se.[dbo].[ParametrosCargueMasivo]([Identificador],[NombreTablaBD],[NombreColumnaExcel],[NombreColumnaBD],[Descripcion])VALUES('COLUMNA_PROBABILIDADPPT_ESTACION_CARGUE','EstacionMensual','ProbabilidadPpt','ProbabilidadPpt', 'Corresponde al nombre de la columna <<ProbabilidadPpt>> en el excel de cargue masivo de  estaciones mensuales.');
	GO

	