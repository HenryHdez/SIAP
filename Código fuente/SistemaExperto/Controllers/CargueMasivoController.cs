using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Drawing;
using System.Text;
using System.IO;
using SistemaExperto.Models;

namespace SistemaExperto.Controllers
{
    public class CargueMasivoController : Controller
    {
        private SistemaExperto.Controllers.ArchivoController archivo = new ArchivoController();

        private SistemaExperto.Controllers.EstacionMensualController estacionMensualC = new EstacionMensualController();

        private SEEntities db = new SEEntities();
        //
        // GET: /CargueMasivo/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LeeRutaExcel()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LeeRutaExcel(HttpPostedFileBase excelAdjunto)
        {
            string ruta = "";
            if (ModelState.IsValid)
            {
                ruta = archivo.GuardarArchivoExcel(excelAdjunto);

                TempData["TempRuta"] = ruta;

                //temporal para mostrar el icono de OK paso 1( si se usa TempRuta se pierde el valor de la ruta requerido en cargue)
                TempData["IndicaOK"] = "OK";

                return RedirectToAction("Index");
            }
            return View(ruta);

        }
        public class ResultadoCargueBD
        {
            public string Variable { get; set; }
            public int Resultado { get; set; }
            public string Mensaje { get; set; }
        }
        public class ListaEncabezadoExcel
        {
            public int PosicionColumna { get; set; }
            public string NombreColumna { get; set; }

        }

        public ActionResult RegistroMasivo()
        {
            //se lee variable temporal con la ruta del archivo Excel a cargar en BD(el que està en el servidor)
            string sArchivo = TempData["TempRuta"] as string;


            List<ResultadoCargueBD> listaResultados = new List<ResultadoCargueBD>();
            if (sArchivo != null)
            {

                string paramColumnaCodigoDaneEstacion, paramColumnaAnio, paramColumnaMes, paramColumnaDia, paramColumnaTMin,
                    paramColumnaTMax, paramColumnaPrecipitacion, paramColumnaViento, paramColumnaTMinReal, paramColumnaTMaxReal, paramColumnaPrecipitacionReal,
                    paramColumnaVientoReal,
                    //paramColumnaEto, paramColumnaEtoReal, paramColumnaSPI, paramColumnaSPIReal, 
                    paramColumnaPptDebajo,
                    paramColumnaPptDentro, paramColumnaPptSobre, paramColumnaProbabilidadPpt, paramColumnaValorMin, paramColumnaValorMax;

                paramColumnaCodigoDaneEstacion = paramColumnaAnio = paramColumnaMes = paramColumnaDia = paramColumnaTMin =
                    paramColumnaTMax = paramColumnaPrecipitacion = paramColumnaViento = paramColumnaTMinReal = paramColumnaTMaxReal = paramColumnaPrecipitacionReal =
                    paramColumnaVientoReal =
                    //paramColumnaEto= paramColumnaEtoReal= paramColumnaSPI= paramColumnaSPIReal= 
                    paramColumnaPptDebajo = paramColumnaPptDentro = paramColumnaPptSobre = paramColumnaProbabilidadPpt = paramColumnaValorMin = paramColumnaValorMax = "";

                //buscando parametros del excel en la BD (a partir de identificador del parametro se consulta el dato del nombre de la columna en excel que està 
                //parametrizada en la tabla de parametrosCargueAnalisis consultaParametroNombreColumnaExcel ):

                paramColumnaCodigoDaneEstacion = consultaParametroNombreColumnaExcel("COLUMNA_CODIGO_ESTACION_CARGUE");
                paramColumnaAnio = consultaParametroNombreColumnaExcel("COLUMNA_ANIO_ESTACION_CARGUE");
                paramColumnaMes = consultaParametroNombreColumnaExcel("COLUMNA_MES_ESTACION_CARGUE");
                paramColumnaDia = consultaParametroNombreColumnaExcel("COLUMNA_DIA_ESTACION_CARGUE");
                paramColumnaTMin = consultaParametroNombreColumnaExcel("COLUMNA_TMIN_ESTACION_CARGUE");
                paramColumnaTMax = consultaParametroNombreColumnaExcel("COLUMNA_TMAX_ESTACION_CARGUE");
                paramColumnaPrecipitacion = consultaParametroNombreColumnaExcel("COLUMNA_PPT_ESTACION_CARGUE");
                paramColumnaViento = consultaParametroNombreColumnaExcel("COLUMNA_VIENTO_ESTACION_CARGUE");
                paramColumnaTMinReal = consultaParametroNombreColumnaExcel("COLUMNA_TMINREAL_ESTACION_CARGUE");
                paramColumnaTMaxReal = consultaParametroNombreColumnaExcel("COLUMNA_TMAXREAL_ESTACION_CARGUE");
                paramColumnaPrecipitacionReal = consultaParametroNombreColumnaExcel("COLUMNA_PPTREAL_ESTACION_CARGUE");
                paramColumnaVientoReal = consultaParametroNombreColumnaExcel("COLUMNA_VIENTOREAL_ESTACION_CARGUE");
                //paramColumnaEto = consultaParametroNombreColumnaExcel("COLUMNA_ETO_ESTACION_CARGUE");
                //paramColumnaEtoReal = consultaParametroNombreColumnaExcel("COLUMNA_ETOREAL_ESTACION_CARGUE");
                //paramColumnaSPI = consultaParametroNombreColumnaExcel("COLUMNA_SPI_ESTACION_CARGUE");
                //paramColumnaSPIReal = consultaParametroNombreColumnaExcel("COLUMNA_SPIREAL_ESTACION_CARGUE");
                paramColumnaPptDebajo = consultaParametroNombreColumnaExcel("COLUMNA_PPTDEBAJO_ESTACION_CARGUE");
                paramColumnaPptDentro = consultaParametroNombreColumnaExcel("COLUMNA_PPTDENTRO_ESTACION_CARGUE");
                paramColumnaPptSobre = consultaParametroNombreColumnaExcel("COLUMNA_PPTSOBRE_ESTACION_CARGUE");
                paramColumnaProbabilidadPpt = consultaParametroNombreColumnaExcel("COLUMNA_PROBABILIDADPPT_ESTACION_CARGUE");
                paramColumnaValorMin = consultaParametroNombreColumnaExcel("COLUMNA_VALORMIN_INCERTID_ESTACION_CARGUE");
                paramColumnaValorMax = consultaParametroNombreColumnaExcel("COLUMNA_VALORMAX_INCERTID_ESTACION_CARGUE");

                List<ListaExcel> listadatosexcel = new List<ListaExcel>();

                ExcelPackage package = new ExcelPackage();

                using (var stream = System.IO.File.OpenRead(sArchivo))
                {
                    package.Load(stream);
                }

                ExcelWorkbook exlWbook = package.Workbook;

                if (exlWbook != null)
                {
                    if (exlWbook.Worksheets.Count > 0)
                    {
                        ExcelWorksheet exlWsheet = exlWbook.Worksheets.First();

                        int columnaInicial = exlWsheet.Dimension.Start.Column;
                        int columnaFinal = exlWsheet.Dimension.End.Column;
                        int filaInicial = exlWsheet.Dimension.Start.Row;
                        int filaFinal = exlWsheet.Dimension.End.Row;

                        ExcelRange exlRange = exlWsheet.Cells[filaInicial, columnaInicial, filaFinal, columnaFinal];

                        //leyendo row de encabezado:
                        List<ListaEncabezadoExcel> encabezadoExcel = new List<ListaEncabezadoExcel>();
                        for (int j = 1; j <= (columnaFinal); j++)
                        {
                            encabezadoExcel.Add(new ListaEncabezadoExcel
                            {
                                PosicionColumna = j,
                                NombreColumna = (exlWsheet.Cells[1, j] as ExcelRange).Value.ToString().Trim()
                            });
                        }

                        //leyendo cuerpo Excel:
                        //for (int i = 2; i <= (columnaFinal); i++)
                        for (int i = 2; i <= (filaFinal); i++)
                        {
                            int posRes = i - 2;
                            listadatosexcel.Add(new ListaExcel());

                            for (int j = 0; j < encabezadoExcel.Count(); j++)
                            {
                                int posicion = encabezadoExcel[j].PosicionColumna;


                                if (encabezadoExcel[j].NombreColumna == paramColumnaCodigoDaneEstacion)
                                {
                                    if ((exlWsheet.Cells[i, posicion] as ExcelRange).Value != null)
                                    {

                                        listadatosexcel[posRes].CodigoIdeamEstacion = (double)((exlWsheet.Cells[i, posicion] as ExcelRange).Value);
                                    }
                                    else
                                    {
                                        asignaResultado(listaResultados, "Todas", 0, "Se encontró en excel registro con codigo Nulo");
                                        break;
                                    }
                                }

                                //cargando la clase de datos del Excel(listadatosexcel) con la informacion del excel siempre Y cuando seencuentre en el encabezado la columna del analisis
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaAnio) { listadatosexcel[posRes].Anio = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaMes) { listadatosexcel[posRes].Mes = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaDia) { listadatosexcel[posRes].Dia = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaTMin) { listadatosexcel[posRes].Tmin = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaTMax) { listadatosexcel[posRes].Tmax = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaPrecipitacion) { listadatosexcel[posRes].Precipitacion = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaViento) { listadatosexcel[posRes].Viento = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaTMinReal) { listadatosexcel[posRes].TminReal = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaTMaxReal) { listadatosexcel[posRes].TmaxReal = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaPrecipitacionReal) { listadatosexcel[posRes].PrecipitacionReal = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaVientoReal) { listadatosexcel[posRes].VientoReal = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaPptDentro) { listadatosexcel[posRes].pptDentro = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaPptSobre) { listadatosexcel[posRes].pptSobre = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaPptDebajo) { listadatosexcel[posRes].pptDebajo = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaProbabilidadPpt) { listadatosexcel[posRes].ProbabilidadPpt = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaValorMin) { listadatosexcel[posRes].ValorMin = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                else if (encabezadoExcel[j].NombreColumna == paramColumnaValorMax) { listadatosexcel[posRes].ValorMax = (double)(exlWsheet.Cells[i, posicion] as ExcelRange).Value; }
                                //int yyy = 0;
                            }
                        }

                        List<ListaExcel> listadatoscargados = new List<ListaExcel>();
                        listadatoscargados = listadatosexcel;

                        //Indicadores de cantidad de registros insertados (para informe de resultados):
                        int resultadoAlmacenaBD;

                        resultadoAlmacenaBD = 0;

                        //Ciclo para almacenar datos del excel en la BD y asignar resultados para visualizar
                        for (int a = 0; a < listadatoscargados.Count; a++)
                        {
                            EstacionMensual estacionMensual = new EstacionMensual();
                            int codigoIdeamEstacionExcel = (int)listadatoscargados[a].CodigoIdeamEstacion;
                            string cod = Convert.ToString(codigoIdeamEstacionExcel).Trim();
                            var consultaEstacionId = from s in db.Estacion
                                                     where (s.CodigoIdeam == cod)
                                                     select s.EstacionId;

                            //Si no existe la estación, se reporta inconsistencia
                            if (consultaEstacionId.Count() == 1)
                            {
                                int estacionID = consultaEstacionId.FirstOrDefault();

                                //calculando el dato de fecha:
                                int anio = (int)listadatoscargados[a].Anio;
                                int mes = (int)listadatoscargados[a].Mes;
                                int dia = (int)listadatoscargados[a].Dia;

                                DateTime fecha = new DateTime(anio, mes, dia);

                                int categoriaId = 4;
                                //string nombreCategoria = "";


                                //calculacategoriaprobabilidad a partir de la precipitacion tal y como se hace en el excel de calculo de valores alfa, beta, p,q ...
                                if (listadatoscargados[a].Precipitacion > 3)
                                {
                                    //nombreCategoria = "Muy Humedo";
                                    categoriaId = 2;

                                }
                                else if (listadatoscargados[a].Precipitacion > 1)
                                {
                                    //nombreCategoria = "Humedo";
                                    categoriaId = 2;

                                }
                                else if (listadatoscargados[a].Precipitacion > -1)
                                {
                                    //nombreCategoria = "Normal";
                                    categoriaId = 3;

                                }
                                else if (listadatoscargados[a].Precipitacion > -3)
                                {
                                    //nombreCategoria = "seco";
                                    categoriaId = 1;
                                }

                                else
                                {
                                    //nombreCategoria = "Muy seco";
                                    categoriaId = 1;
                                }

                                //Si la columna de cargue existe en el excel se llama al respectivo metodo para guardar el dato de estacionmensual: 
                                if ((encabezadoExcel.SingleOrDefault(r => r.NombreColumna == paramColumnaCodigoDaneEstacion)) != null)
                                {
                                    //inicio datos calculados
                                    int diasMes = System.DateTime.DaysInMonth(anio, mes);
                                    double totalETo = 0;
                                    double totalEToReal = 0;

                                    EstacionMensual datosEstacion = new EstacionMensual();
                                    datosEstacion.EstacionId = estacionID;
                                    datosEstacion.Viento = (float)listadatoscargados[a].Viento;
                                    datosEstacion.Tmax = (float)listadatoscargados[a].Tmax;
                                    datosEstacion.Tmin = (float)listadatoscargados[a].Tmin;

                                    datosEstacion.VientoReal = (float)listadatoscargados[a].VientoReal;
                                    datosEstacion.TmaxReal = (float)listadatoscargados[a].TmaxReal;
                                    datosEstacion.TminReal = (float)listadatoscargados[a].TminReal;
                                    datosEstacion.Fecha = fecha;
                                    datosEstacion.Precipitacion = (float)listadatoscargados[a].Precipitacion;
                                    datosEstacion.PrecipitacionReal = (float)listadatoscargados[a].PrecipitacionReal;
                                    datosEstacion.ValorMaximo = (float)listadatoscargados[a].ValorMax;
                                    datosEstacion.ValorMinimo = (float)listadatoscargados[a].ValorMin;

                                    //Si viento, tmin o tmax son nulos: no se calcula Eto
                                    if ((datosEstacion.Viento != null) && (datosEstacion.Tmin != null) && (datosEstacion.Tmax != null))
                                    {
                                        for (int diaA = 0; diaA < diasMes; diaA++)
                                        {
                                            DateTime fechaSig = new DateTime(anio, mes, diaA + 1);
                                            totalETo = totalETo + estacionMensualC.CalcularEToDiario(datosEstacion, fechaSig);

                                        }
                                        datosEstacion.ETo = totalETo;
                                    }

                                    //Si no hay dato de vientoReal, tminReal o tmaxReal, no se calcula EtoReal
                                    if ((datosEstacion.VientoReal != null) && (datosEstacion.TminReal != null) && (datosEstacion.TmaxReal != null))
                                    {

                                        for (int diaA = 0; diaA < diasMes; diaA++)
                                        {
                                            DateTime fechaSig = new DateTime(anio, mes, diaA + 1);

                                            totalEToReal = totalEToReal + estacionMensualC.CalcularEToDiarioReal(datosEstacion, fechaSig);
                                        }
                                        datosEstacion.EToReal = totalEToReal;
                                    }

                                    //DateTime fecha1 = new DateTime(anio, mes, 1);
                                    //fecha1 = fecha1.AddMonths(1);

                                    int indicadorRecalculo = estacionMensualC.RecalcularEstacionValor(12, fecha.Year, datosEstacion.EstacionId, (double)datosEstacion.PrecipitacionReal);

                                    //EstacionMensual estacionMensual2 = db.EstacionMensual.Where(em => em.Fecha.Year == fecha.Year && em.Fecha.Month == fecha.Month && em.EstacionId == estacionID).FirstOrDefault();

                                    //if (ModelState.IsValid)
                                    //{
                                    //    db.Entry(estacionMensual2).State = EntityState.Modified;
                                    //    estacionMensual2.SPIReal = datosEstacion.SPIReal;
                                    //    db.SaveChanges();
                                    //    //return RedirectToAction("Index");
                                    //}

                                    datosEstacion.SPI = estacionMensualC.CalcularSPI(datosEstacion);

                                    //#CambioPalmerSPI 
                                    if (datosEstacion.SPI != 0) { datosEstacion.ExistePrediccion = true; }
                                    else { datosEstacion.ExistePrediccion = false; }

                                    datosEstacion.SPIReal = 0;

                                    resultadoAlmacenaBD = guardaEstacionMensual(estacionID, fecha, (float)listadatoscargados[a].Tmin, (float)listadatoscargados[a].Tmax,
                                        (float)listadatoscargados[a].Precipitacion, (float)listadatoscargados[a].Viento, (float)listadatoscargados[a].TminReal, (float)listadatoscargados[a].TmaxReal,
                                        (float)listadatoscargados[a].PrecipitacionReal, (float)listadatoscargados[a].VientoReal, (float)datosEstacion.ETo,
                                        (float)datosEstacion.EToReal, (float)datosEstacion.SPI, (float)datosEstacion.SPIReal,
                                        (float)listadatoscargados[a].pptDebajo, (float)listadatoscargados[a].pptDentro, (float)listadatoscargados[a].pptSobre,
                                        (float)listadatoscargados[a].ProbabilidadPpt, categoriaId, (float)listadatoscargados[a].ValorMin, (float)listadatoscargados[a].ValorMax);

                                    //Si no hay precipitación real, no se calcula SPIReal
                                    //if (datosEstacion.PrecipitacionReal != null)
                                    //{
                                    //    datosEstacion.SPIReal = estacionMensualC.CalcularSPIReal(datosEstacion);
                                    //}

                                    EstacionMensual estacionMensual1 = db.EstacionMensual.Where(em => em.Fecha.Year == fecha.Year && em.Fecha.Month == fecha.Month && em.EstacionId == estacionID).FirstOrDefault();

                                    if (ModelState.IsValid)
                                    {
                                        db.Entry(estacionMensual1).State = EntityState.Modified;
                                        estacionMensual1.SPIReal = 0;
                                        db.SaveChanges();
                                        //return RedirectToAction("Index");
                                    }

                                    EstacionMensual estacionMensual2 = db.EstacionMensual.Where(em => em.Fecha.Year == fecha.Year && em.Fecha.Month == fecha.Month && em.EstacionId == estacionID).FirstOrDefault();

                                    indicadorRecalculo = estacionMensualC.RecalcularEstacionValor(12, fecha.Year, estacionMensual2.EstacionId, (double)estacionMensual2.PrecipitacionReal);

                                    if (datosEstacion.PrecipitacionReal != null)
                                    {
                                        datosEstacion.SPIReal = estacionMensualC.CalcularSPIReal(estacionMensual1);
                                    }

                                    if (ModelState.IsValid)
                                    {
                                        db.Entry(estacionMensual2).State = EntityState.Modified;
                                        estacionMensual2.SPIReal = datosEstacion.SPIReal;
                                        db.SaveChanges();
                                        //return RedirectToAction("Index");
                                    }

                                }
                                asignaResultado(listaResultados, "Estacion " + listadatoscargados[a].CodigoIdeamEstacion, resultadoAlmacenaBD, "registro almacenado en BD para año:" + anio + " mes:" + mes + " dia:" + dia);

                            }
                            else
                            {

                                asignaResultado(listaResultados, "Todas", 0, "No se encontró en la Base de datos el codigo ideam de la estacion solicitada en excel:" + listadatoscargados[a].CodigoIdeamEstacion);
                            }


                        }//for

                        ViewBag.data = listaResultados;

                    } //if sArchivo es null
                    //}//using excelpackage
                }//if count>0
            }//if book!=null
            else
            {
                asignaResultado(listaResultados, "Todos", 0, "Error en Paso 1 del cargue masivo");
                ViewBag.data = listaResultados;

                ViewBag.Errores = "No se ha leido correctamente el excel, por favor intente nuevamente realizar el Paso 1";
            }
            return View();
        }

        public class ListaExcel
        {
            public double CodigoIdeamEstacion { get; set; }
            public double Anio { get; set; }
            public double Mes { get; set; }
            public double Dia { get; set; }
            public double Tmin { get; set; }
            public double Tmax { get; set; }
            public double Precipitacion { get; set; }

            public double Viento { get; set; }
            public double TminReal { get; set; }
            public double TmaxReal { get; set; }
            public double PrecipitacionReal { get; set; }
            public double VientoReal { get; set; }
            public double Eto { get; set; }
            public double EtoReal { get; set; }
            public double SPI { get; set; }
            public double SPIReal { get; set; }
            public double pptDebajo { get; set; }
            public double pptDentro { get; set; }
            public double pptSobre { get; set; }
            public double ProbabilidadPpt { get; set; }
            public double ValorMin { get; set; }
            public double ValorMax { get; set; }

        }

        /*Metodo que permite consultar a partir de un identificador el nombre de la columna del excel parametrizada*/
        public string consultaParametroNombreColumnaExcel(string identificador)
        {
            ParametrosCargueMasivo ParametrosBD = new ParametrosCargueMasivo();
            string nombreParametroColumna = "";
            var parametros = from s in db.ParametrosCargueMasivo
                             where (s.Identificador == identificador)
                             select s.NombreColumnaExcel;
            if (parametros.Count() == 1)
            {

                nombreParametroColumna = parametros.FirstOrDefault().Trim();

            }

            return nombreParametroColumna;
        }

        public void asignaResultado(List<ResultadoCargueBD> lista, string variable, int resultado, string mensaje)
        {

            lista.Add(new ResultadoCargueBD
            {
                Variable = variable,
                Resultado = resultado,
                Mensaje = mensaje
            });
        }


        /*En este metodo, a partir de los datos de entrada se crea nueva clase referente  y se asignan los valores
         a insertar, luego se va actualizando el indicador de total de datos de anàlisis insertados (variable retorno) que posrteriormente es leido 
        en la vista  (en el informe de resultados de cargue).*/
        public int guardaEstacionMensual(int EstacionId, DateTime Fecha, float ValorTmin, float ValorTmax, float ValorPrecipitacion, float ValorViento, float ValorTminReal,
            float ValorTmaxReal, float ValorPrecipitacionReal, float ValorVientoReal,
            float ValorEto, float ValorEtoReal, float ValorSPI, float ValorSPIReal, float ValorpptDebajo,
            float ValorpptDentro, float ValorpptSobre, float ValorProbabilidadPpt, int categoriaId, float ValorMin, float ValorMax)
        {
            int resultadoAnalisis = 0;

            IEnumerable<EstacionMensual> registrosExistentes = db.EstacionMensual.Where(r => r.EstacionId == EstacionId).Where(r => r.Fecha == Fecha);


            if (registrosExistentes.Count() == 0)
            {
                try
                {
                    EstacionMensual registro = new EstacionMensual();
                    registro.EstacionId = EstacionId;
                    registro.Fecha = Fecha;
                    registro.Tmin = ValorTmin;
                    registro.Tmax = ValorTmax;
                    registro.Precipitacion = ValorPrecipitacion;
                    registro.Viento = ValorViento;
                    registro.TminReal = ValorTminReal;
                    registro.TmaxReal = ValorTmaxReal;
                    registro.PrecipitacionReal = ValorPrecipitacionReal;
                    registro.VientoReal = ValorVientoReal;
                    registro.ETo = ValorEto;
                    registro.EToReal = ValorEtoReal;

                    registro.SPI = ValorSPI;
                    registro.SPIReal = ValorSPIReal;
                    registro.pptDebajo = ValorpptDebajo;
                    registro.pptDentro = ValorpptDentro;
                    registro.pptSobre = ValorpptSobre;
                    registro.ProbabilidadPpt = ValorProbabilidadPpt;
                    registro.CategoriaProbabilidadId = categoriaId;
                    registro.ValorMaximo = ValorMax;
                    registro.ValorMinimo = ValorMin;
                    db.EstacionMensual.Add(registro);
                    db.SaveChanges();
                    resultadoAnalisis = resultadoAnalisis + 1;

                    return resultadoAnalisis;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    System.Console.WriteLine(e.Message);
                    ViewBag.Errores = string.Join("; ", e.Errors);
                    return 0;
                }
            }

            return 0;
        }

    }
}