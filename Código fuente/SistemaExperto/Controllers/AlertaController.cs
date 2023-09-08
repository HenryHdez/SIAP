using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;
using SistemaExperto.Controllers;
using System.Globalization;

namespace SistemaExperto.Controllers
{
    public class AlertaController : Controller
    {
        private SEEntities db = new SEEntities();

        EstacionMensualController estacionMensualController = new EstacionMensualController();

        //Fecha actual del sistema
        DateTime fechaActual = System.DateTime.Today;

        // GET: /Alertas/
        public ActionResult Siembra(int ZonaId = 0)
        {
            ViewBag.ZonaId = ZonaId;
            ViewBag.FechaActual = fechaActual.AddDays(-1).ToString("dd/MM/yyyy");

            Zona zonaCultivo = db.Zona.Find(ZonaId);

            DateTime fechaMinimaSiembra = fechaActual.AddDays(-zonaCultivo.Cultivo.TiempoInicial - zonaCultivo.Cultivo.TiempoMedia - zonaCultivo.Cultivo.TiempoDesarrollo - zonaCultivo.Cultivo.TiempoFinal);

            ViewBag.FechaMinimaSiembra = fechaMinimaSiembra;

            return View(zonaCultivo);
        }

        public ActionResult Presentacion(int ZonaId = 0)
        {
            List<string> condiciones = db.Condicion.Select(c=>c.Nombre).ToList();
            ViewBag.Condiciones = condiciones;

            Zona zona = db.Zona.Find(ZonaId);

            int tipoCultivo = zona.CultivoId;

            //Revisa si el mes ya pasó del día 15, para saber si hace el cálculo con el mes actual o con el siguiente
            if (fechaActual.Day > 15)
            {
                fechaActual = fechaActual.AddMonths(1);
            }
            int mesActual = fechaActual.Month;
            string nombreMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mesActual).ToString();
            ViewBag.Mes = nombreMes;

            IQueryable<ZonaEstacion> estacionesZona = db.ZonaEstacion.Where(e => e.ZonaId == ZonaId);
            EstacionMensual estacionMensual = db.EstacionMensual.Where(pc => pc.EstacionId == estacionesZona.FirstOrDefault().EstacionId).
                Where(pc => pc.Fecha.Year == fechaActual.Year).Where(pc => pc.Fecha.Month == fechaActual.Month).FirstOrDefault();
            double x=0;
            if (estacionMensual != null)
            {
                x = estacionMensual.SPI;
                ViewBag.X = estacionMensual.SPI;                
            }
            else
            {
                ViewBag.X = 0;              
            }

            ViewBag.Municipio = zona.Municipio.Nombre;
            
            //valida si no hay efectos no muestra el boton de efectos:
            int tipoPrediccionId =2;
            if (x >= -0.99 && x <= 0.99)
            {
                tipoPrediccionId = 2;
            }

            else if (x >= 1)
            {
                tipoPrediccionId = 1;
            }
            else if (ViewBag.X <= -1)
            {
                tipoPrediccionId = 3;
            }

                int existeEfecto = (db.Ofertas.Where(p => p.TipoPrediccionId == tipoPrediccionId)).Where(p => p.CultivoId == tipoCultivo).Where(p => p.IndicadorLocal == true).Count();

            if (existeEfecto>0)
            {
                ViewBag.ExisteEfecto = 1;
            }
            else
            {
                ViewBag.ExisteEfecto = 0;
            }


            IEnumerable<ZonaEstacion> estacion = db.ZonaEstacion.Where(z => z.ZonaId == zona.ZonaId);

            foreach (var item in estacion)
            {
                ViewBag.IDEAM = ViewBag.IDEAM + item.Estacion.CodigoIdeam + ",";
                ViewBag.Radios = ViewBag.Radios + item.Estacion.EstacionTipo.Radio.ToString() + ",";

                DateTime hoy = System.DateTime.Today;
                IEnumerable<EstacionMensual> spiZonas = db.EstacionMensual.Where(z => z.Estacion.ZonaEstacion.FirstOrDefault().ZonaEstacionId ==
                                                item.ZonaEstacionId && z.Fecha.Month == hoy.Month && z.Fecha.Year == hoy.Year);
                if (spiZonas.Count() > 0)
                {
                    ViewBag.Palmer = ViewBag.Palmer + spiZonas.FirstOrDefault().SPI.ToString().Replace(',', '.') + "/";
                }
                else
                {
                    ViewBag.Palmer = ViewBag.Palmer + "sin_dato/";
                }
            }

            return View(zona);
        }

        //[HttpPost]
        public ActionResult Resultado(DateTime FechaSiembra, int ZonaId, string RiegoInicial)
        {
            Session["fechaSiembra"] = FechaSiembra.ToString("MM/dd/yyyy");
            Session["riegoInicial"] = RiegoInicial;
            Zona zonaCultivo = db.Zona.Find(ZonaId);

            double riegoInicial = 0;
            if (RiegoInicial == "Si")
            {
                riegoInicial = (zonaCultivo.CC - zonaCultivo.PMP) * 1000;
            }

            ViewBag.Kc = null;

            Cultivo cultivo = db.Cultivo.Find(zonaCultivo.CultivoId);

            int duracionCultivo = cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia + cultivo.TiempoFinal;

            if (FechaSiembra < fechaActual && (fechaActual - FechaSiembra).TotalDays <= duracionCultivo)
            {
                int diasCultivo = (fechaActual - FechaSiembra).Days;
                int diasPrediccion = diasCultivo + 10;
                int diasFaltantes = (FechaSiembra.AddDays(Convert.ToDouble(duracionCultivo)) - fechaActual).Days;
                ViewBag.DiasCultivo = diasCultivo;
                ViewBag.DiasFaltantes = diasFaltantes;

                // Validación de que el tiempo de cultivo no haya pasado el límite
                if (diasFaltantes < 0)
                {
                    ViewBag.MensajeError = "El tiempo de duración del cultivo está fuera del límite";
                }
                else
                {
                    double[] Kc = new double[diasPrediccion];
                    double P = 0;
                    //double[] Kn = new double[diasCultivo];

                    if (diasCultivo <= duracionCultivo)
                    {
                        if (diasCultivo < cultivo.TiempoInicial)
                        {
                            ViewBag.Etapa = "Inicial";
                        }
                        else if (diasCultivo < cultivo.TiempoDesarrollo + cultivo.TiempoInicial)
                        {
                            ViewBag.Etapa = "Desarrollo";
                        }
                        else if (diasCultivo < cultivo.TiempoMedia + cultivo.TiempoDesarrollo + cultivo.TiempoInicial)
                        {
                            ViewBag.Etapa = "Media";
                        }
                        else if (diasCultivo <= duracionCultivo)
                        {
                            ViewBag.Etapa = "Final";
                        }

                        //Etapa inicial
                        if (diasPrediccion < cultivo.TiempoInicial)
                        {
                            for (int i = 0; i < diasPrediccion; i++)
                            {
                                Kc[i] = Math.Round(cultivo.KInicial, 3);
                            }
                        }
                        //Etapa desarrollo
                        else if (diasPrediccion <= (cultivo.TiempoInicial + cultivo.TiempoDesarrollo))
                        {
                            for (int i = 0; i <= cultivo.TiempoInicial; i++)
                            {
                                Kc[i] = Math.Round(cultivo.KInicial, 3);
                            }
                            for (int i = cultivo.TiempoInicial; i < diasPrediccion; i++)
                            {
                                Kc[i] = Math.Round(cultivo.KInicial + (double)((double)(i + 1 - cultivo.TiempoInicial) / cultivo.TiempoDesarrollo) * (cultivo.KMedia - cultivo.KInicial), 3);
                            }
                        }
                        //Etapa media
                        else if (diasPrediccion <= (cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia))
                        {
                            for (int i = 0; i < cultivo.TiempoInicial; i++)
                            {
                                Kc[i] = Math.Round(cultivo.KInicial, 3);
                            }
                            for (int i = cultivo.TiempoInicial; i <= cultivo.TiempoInicial + cultivo.TiempoDesarrollo; i++)
                            {
                                Kc[i] = Math.Round(cultivo.KInicial + (double)((double)(i + 1 - cultivo.TiempoInicial) / cultivo.TiempoDesarrollo) * (cultivo.KMedia - cultivo.KInicial), 3);
                            }
                            for (int i = cultivo.TiempoInicial + cultivo.TiempoDesarrollo; i < diasPrediccion; i++)
                            {
                                Kc[i] = Math.Round(cultivo.KMedia, 3);
                            }
                        }
                        //Etapa final
                        else
                        {
                            for (int i = 0; i <= cultivo.TiempoInicial; i++)
                            {
                                Kc[i] = Math.Round(cultivo.KInicial, 3);
                            }
                            for (int i = cultivo.TiempoInicial; i <= cultivo.TiempoInicial + cultivo.TiempoDesarrollo; i++)
                            {
                                Kc[i] = Math.Round(cultivo.KInicial + (double)((double)(i + 1 - cultivo.TiempoInicial) / cultivo.TiempoDesarrollo) * (cultivo.KMedia - cultivo.KInicial), 3);
                            }
                            for (int i = cultivo.TiempoInicial + cultivo.TiempoDesarrollo; i <= cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia; i++)
                            {
                                Kc[i] = Math.Round(cultivo.KMedia, 3);
                            }
                            for (int i = cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia; i < diasPrediccion; i++)
                            {
                                Kc[i] = Math.Round(cultivo.KMedia + (double)((double)(i + 1 - (cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia)) / cultivo.TiempoFinal) * (cultivo.KFinal - cultivo.KMedia), 3);
                            }

                        }
                        P = cultivo.ACFinal;
                    }

                    // Variable Kc para envío a la vista
                    ViewBag.Kc = Kc;

                    DateTime fechaPrediccion = fechaActual;
                    DateTime fechaMesAnterior = fechaActual.AddMonths(-1);

                    // Valida si falta menos de una semana para enviar la alerta
                    //if (diasFaltantes > 20)
                    //{
                    // Vectores con los 7 días siguientes a la fecha actual, para calcular variables de alerta
                    double precipitacionMes = 0;
                    double[] ETo = new double[diasPrediccion];
                    double[] Kc20 = new double[diasPrediccion];
                    double[] ETc = new double[diasPrediccion];
                    double[] Zr = new double[diasPrediccion];
                    double[] ADT = new double[diasPrediccion];
                    double[] AFA = new double[diasPrediccion];
                    double[] Precipitacion = new double[diasPrediccion];
                    double[] DrInicial = new Double[diasPrediccion];
                    double[] DrFinal = new Double[diasPrediccion];
                    double[] Dp = new Double[diasPrediccion];
                    double[] O = new Double[diasPrediccion];
                    double[] Riego = new Double[diasPrediccion];
                    double[] RO = new Double[diasPrediccion];

                    IQueryable<ZonaEstacion> estacionesZona = db.ZonaEstacion.Where(e => e.ZonaId == ZonaId);
                   
                    // Ajuste para que tome la condición desde la evaluación de la precipitación(igual a modulo local) y no desde la categoria de probabilidad 
                    //dado a que esta ultima mira ppt debajo y otras pero no la ecuación de SPI.

                    //int probabilidadCondicion = db.EstacionMensual.FirstOrDefault().CategoriaProbabilidadId;
                    EstacionMensual estacionMensualProbabilidad = buscarDatosEstacion(fechaPrediccion, estacionesZona.FirstOrDefault().EstacionId);
                    //int probabilidadCondicion = db.EstacionMensual.Where(pc => pc.EstacionId == estacionMensualProbabilidad.EstacionId).Where(pc => pc.Fecha.Year == fechaPrediccion.Year).Where(pc => pc.Fecha.Month == fechaPrediccion.Month).FirstOrDefault().CategoriaProbabilidadId;
                    //ViewBag.ProbabilidadCondicion = db.CategoriaProbabilidad.Find(probabilidadCondicion).Descripcion;
                    int probabilidadCondicion = 4;

                    double x = 0;
                    if (estacionMensualProbabilidad != null)
                    {
                        x = estacionMensualProbabilidad.SPI;
                        if (x >= -0.99 && x <= 0.99)
                        {
                            probabilidadCondicion = 3;
                        }
                        else if (x >= 1) { probabilidadCondicion = 2; }
                        else if (x <= -1)
                        {
                            probabilidadCondicion = 1;
                        }

                    }
                    ViewBag.ProbabilidadCondicion = db.CategoriaProbabilidad.Find(probabilidadCondicion).Descripcion;


                    int diferenciaMeses = (fechaActual - FechaSiembra).Days / 30;

                    List<DateTime> listaMeses = mesesEntreFechas(FechaSiembra, FechaSiembra.AddDays(diasPrediccion));

                    if (listaMeses.Count() == 1)
                    {
                        int dias = listaMeses.FirstOrDefault().Day - FechaSiembra.Day;
                        listaMeses[0] = listaMeses.FirstOrDefault().AddDays(-dias);
                    }

                    double[] vectorPresentacionesMes = new double[listaMeses.Count()];
                    double[] vectorEToMes = new double[listaMeses.Count()];

                    foreach (ZonaEstacion ze in estacionesZona)
                    {

                        EstacionMensual estacionMensual = buscarDatosEstacion(fechaPrediccion, ze.EstacionId);
                        //EstacionMensual estacionMensualAnterior = buscarDatosEstacion(fechaMesAnterior, ze.EstacionId);

                        if (validarExistenciaDatosEstacion(listaMeses, ze.EstacionId))
                        {
                            //si viento, tmin o tmax son nulos: no se calculan datos
                            if ((estacionMensual.Viento != null) && (estacionMensual.Tmin != null) && (estacionMensual.Tmax != null))
                            {
                                //Inclusión de incertidumbre

                                //Consulta de década actual
                                int decadaActual = 2;
                                if(fechaActual.Day>20)
                                {
                                    decadaActual = 3;
                                }
                                else if (fechaActual.Day<=10)
                                {
                                    decadaActual = 1;
                                }

                                //Consulta de los valores del mes anterior
                                EstacionMensual estacionMesAnterior = buscarDatosEstacion(fechaPrediccion.AddMonths(-1), ze.EstacionId);
                                double pptMin = Math.Round(segregarPrecipitacionDecadas(estacionMesAnterior.ValorMinimo, estacionMensual.ValorMinimo, decadaActual, fechaActual), 0);
                                ViewBag.PptMin = Math.Max(0, pptMin);
                                double pptMax = Math.Round(segregarPrecipitacionDecadas(estacionMesAnterior.ValorMaximo, estacionMensual.ValorMaximo, decadaActual, fechaActual), 0);
                                ViewBag.PptMax = Math.Max(0, pptMax);

                                double[][] vectorPrecipitaciones = crearVectorPrecipitaciones(listaMeses, ze.EstacionId);

                                for (int i = 0; i < listaMeses.Count(); i++)
                                {
                                    vectorPresentacionesMes[i] = 0;
                                    for (int j = 0; j < 6; j++)
                                    {
                                        vectorPresentacionesMes[i] = vectorPresentacionesMes[i] + vectorPrecipitaciones[i][j];
                                    }
                                }

                                int contadorDias = 0;
                                int contadorMeses = 0;

                                foreach (DateTime fechaMes in listaMeses)
                                {
                                    EstacionMensual datosEstacionMes = buscarDatosEstacion(fechaMes, ze.EstacionId);
                                    vectorEToMes[contadorMeses] = estacionMensualController.CalcularETo(datosEstacionMes);
                                    int diaInicioMes = fechaMes.Day;
                                    int diaFinMes = DateTime.DaysInMonth(fechaMes.Year, fechaMes.Month);
                                    if (contadorMeses == listaMeses.Count() - 1)
                                    {
                                        diaInicioMes = 1;
                                        diaFinMes = fechaMes.Day - 1;
                                    }

                                    for (int diaMes = diaInicioMes; diaMes <= diaFinMes; diaMes++)
                                    {
                                        // Día a calcular
                                        DateTime diaCalendario2 = FechaSiembra.AddDays(contadorDias);

                                        //EstacionMensual datosEstacionMes = buscarDatosEstacion(fechaMes, ze.EstacionId);

                                        ETo[contadorDias] = ETo[contadorDias] + estacionMensualController.CalcularEToDiario(datosEstacionMes, diaCalendario2) * ze.Porcentaje / 100;

                                        //estacionMensualController.CalcularETo

                                        // Precipitación
                                        switch (diaCalendario2.Day)
                                        {
                                            case 3:
                                                Precipitacion[contadorDias] = vectorPrecipitaciones[contadorMeses][0];
                                                break;
                                            case 8:
                                                Precipitacion[contadorDias] = vectorPrecipitaciones[contadorMeses][1];
                                                break;
                                            case 13:
                                                Precipitacion[contadorDias] = vectorPrecipitaciones[contadorMeses][2];
                                                break;
                                            case 18:
                                                Precipitacion[contadorDias] = vectorPrecipitaciones[contadorMeses][3];
                                                break;
                                            case 23:
                                                Precipitacion[contadorDias] = vectorPrecipitaciones[contadorMeses][4];
                                                break;
                                            case 28:
                                                Precipitacion[contadorDias] = vectorPrecipitaciones[contadorMeses][5];
                                                break;
                                            default:
                                                Precipitacion[contadorDias] = 0;
                                                break;
                                        }

                                        contadorDias++;
                                    }
                                    contadorMeses++;
                                }
                                precipitacionMes = precipitacionMes + estacionMensual.Precipitacion * ze.Porcentaje / 100;
                            }//if validacion datos de entrada para estacion

                            else
                            {
                                ViewBag.MensajeError = "No estan los datos requeridos para calcular Eto";
                                ViewBag.ZonaId = new SelectList(db.Zona, "ZonaId", "Nombre", ZonaId);
                                ViewBag.dH = 0;
                                //return View();
                            }

                        }
                        else
                        {
                            ViewBag.MensajeError = "No existe predicción para uno de los meses del cultivo";
                            ViewBag.ZonaId = new SelectList(db.Zona, "ZonaId", "Nombre", ZonaId);
                            ViewBag.dH = 0;
                            //return View();
                        }

                        double ETcDecada = 0;
                        double PptDecada = 0;


                        for (int j = 0; j < diasPrediccion; j++)
                        {
                            // Día a calcular
                            int diaCalculo = j;
                            DateTime diaCalendario = FechaSiembra.AddDays(diaCalculo);

                            ETc[j] = Math.Round((Kc[diaCalculo] * ETo[j]), 4);


                            // Cálculo profundidad radicular
                            if (diaCalculo < cultivo.JMin)
                            {
                                Zr[j] = cultivo.ZrMin;
                            }
                            else if (diaCalculo > cultivo.JMax)
                            {
                                Zr[j] = cultivo.ZrMax;
                            }
                            else
                            {
                                Zr[j] = Math.Round((cultivo.ZrMin + (cultivo.ZrMax - cultivo.ZrMin) * ((diaCalculo + 1 - cultivo.JMin) / (cultivo.JMax - cultivo.JMin))), 4);
                            }

                            // Cálculo del agua disponible total (ADT)
                            ADT[j] = Math.Round((1000 * (zonaCultivo.CC - zonaCultivo.PMP) * Zr[j]), 4);

                            // Cálculo del agua fácilmente aprovechable (AFA)
                            // Etapa inicial
                            if (diasPrediccion < cultivo.TiempoInicial)
                            {
                                P = cultivo.ACInicial;
                            }
                            // Etapa desarrollo
                            else if (diasPrediccion < cultivo.TiempoInicial + cultivo.TiempoDesarrollo)
                            {
                                P = cultivo.ACMedia;
                            }
                            // Etapa media
                            else if (diasPrediccion < cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia)
                            {
                                P = cultivo.ACMedia;
                            }
                            // Etapa final
                            else if (diasPrediccion < duracionCultivo)
                            {
                                P = cultivo.ACFinal;
                            }

                            AFA[j] = Math.Round((P * ADT[j]), 4);

                            //Escorrentía
                            if (Precipitacion[j] > zonaCultivo.TasaMax)
                            {
                                RO[j] = Precipitacion[j] - zonaCultivo.TasaMax;
                            }
                            else
                            {
                                RO[j] = 0;
                            }

                            //Para el día inicial (día 0)
                            if (j == 0)
                            {
                                Riego[j] = 0;
                                DrInicial[j] = 0;

                                DrFinal[j] = DrInicial[j] - Precipitacion[j] - Riego[j] + ETc[j];

                                //DrFinal[j] = 0;

                                if (DrFinal[j] >= 0)
                                {
                                    Dp[j] = 0;
                                }
                                else
                                {
                                    Dp[j] = (Precipitacion[j] - RO[j]) + Riego[j] - ETc[j] - DrInicial[j];
                                }

                                O[j] = 0;
                            }
                            //Para días diferentes al inicial
                            else
                            {

                                if (DrFinal[j - 1] > AFA[j])
                                {
                                    O[j] = AFA[j];
                                }
                                else
                                {
                                    O[j] = 0;
                                }

                                if (j == diasCultivo - 1)
                                {
                                    Riego[j] = riegoInicial;
                                }
                                else
                                {
                                    Riego[j] = O[j];
                                }

                                //Agotamiento inicial
                                DrInicial[j] = DrFinal[j - 1];

                                if ((DrInicial[j] - (Precipitacion[j] - RO[j]) - Riego[j] + ETc[j]) >= 0)
                                {
                                    Dp[j] = 0;
                                }
                                else
                                {
                                    Dp[j] = (Precipitacion[j] - RO[j]) + Riego[j] - ETc[j] - DrInicial[j];
                                }

                                //Agotamiento final
                                DrFinal[j] = DrInicial[j] - Precipitacion[j] - Riego[j] + ETc[j] + Dp[j];
                            }
                        }//for

                        double PptEfectiva = 0;

                        double EToDecada = 0;
                        double KcFinal = 0;
                        KcFinal = Kc[diasCultivo + 9];

                        //KcDecada = KcDecada + Kc[diaCalculo];
                        for (int k = 0; k < 10; k++)
                        {
                            EToDecada = EToDecada + ETo[diasCultivo + k];
                            ETcDecada = ETcDecada + ETc[diasCultivo + k];
                            PptDecada = PptDecada + Precipitacion[diasCultivo + k];
                        }

                        if (PptDecada <= 250 / 3)
                        {
                            PptEfectiva = PptDecada * (125 - 0.6 * PptDecada) / 125;
                        }
                        else
                        {
                            PptEfectiva = (125 / 3) + 0.1 * PptDecada;
                        }

                        //Multiplicación *10 para pasar a volumen por hectárea
                        double dH = Math.Round(ETcDecada - PptEfectiva, 0);

                        double vH = Math.Round(dH * 10, 0);


                        if (dH < 0) dH = 0;

                        //Variables alerta para envío a la vista
                        //ViewBag.Precipitacion = Precipitacion;
                        ViewBag.Riego = Riego;
                        ViewBag.Ppt = Precipitacion;
                        ViewBag.PptMes = vectorPresentacionesMes;
                        ViewBag.Drinicial = DrInicial;
                        ViewBag.Drfinal = DrFinal;
                        ViewBag.ETo = ETo;
                        ViewBag.EtoMes = vectorEToMes;
                        ViewBag.Kc = Kc;
                        ViewBag.Kc7 = Kc.Skip(diasCultivo).Take(9);
                        ViewBag.ETc = ETc;
                        ViewBag.dH = Math.Round(dH, 0);
                        ViewBag.O = O;
                        ViewBag.RO = RO;
                        ViewBag.ValorMaximoGrafica = Math.Max(vectorPresentacionesMes.Max(), vectorEToMes.Max());
                        ViewBag.vH = vH;
                        ViewBag.MesInicio = FechaSiembra.Month;
                        ViewBag.PPtDecada = Math.Round(PptDecada, 0);
                        ViewBag.UC = Math.Round(EToDecada * KcFinal, 0);

                        //var eventos = new { Title = "10", Date = "02/06/2009" };
                        ViewBag.Eventos = "[";

                        int contador = 0;

                        foreach (double item in Riego)
                        {
                            if (item != 0)
                            {
                                string fecha = FechaSiembra.AddDays(contador).ToString("MM/dd/yyyy");
                                ViewBag.Eventos = ViewBag.Eventos + "{ title: \"Riego\" , start: new Date(\"" + fecha + "\"), description:\"Se recomienda un riego aproximado de " + (Math.Round(item, 0)).ToString() + " mm \"},";
                            }
                            contador++;
                        }

                        ViewBag.FechaInicial = fechaActual.ToString("MM/dd/yyyy");
                        ViewBag.FechaFinal = fechaActual.AddDays(10).ToString("dd/MM/yyyy");

                        string semana = "{start: '" + fechaActual.ToString("yyyy-MM-dd") + "', end: '" + fechaActual.AddDays(10).ToString("yyyy-MM-dd") + "', overlap: false, rendering: 'background', color: '#FCC133'}";

                        ViewBag.Eventos = ViewBag.Eventos + semana + "]";

                    }//foreach estacionzona


                    ViewBag.CultivoEtapa = 1;

                    return View(zonaCultivo);
                }

                ViewBag.dH = 0;
                //double ETo = estacionMensualController.CalcularETo(estacionMensual);

                return View(zonaCultivo);
            }
            else
            {
                ViewBag.MensajeError = "La fecha de siembra del cultivo indica que su ciclo ya finalizó";
            }
            ViewBag.dH = 0;

            ViewBag.ZonaId = new SelectList(db.Zona, "ZonaId", "Nombre", ZonaId);
            //return View("/Alerta/Siembra/ZonaId=" + zonaCultivo.ZonaId);
            return View(zonaCultivo);
        }

        public double[] segregarPrecipitacionMes(double valorMesAnterior, double valorMesActual, DateTime fecha)
        {
            int diasMesAnterior = DateTime.DaysInMonth(fecha.AddMonths(-1).Year, fecha.AddMonths(-1).Month);
            DateTime fechaFinAnterior = new DateTime(fecha.AddMonths(-1).Year, fecha.AddMonths(-1).Month, diasMesAnterior);
            int totalDiasAnterior = fechaFinAnterior.DayOfYear;

            int diasMesActual = DateTime.DaysInMonth(fecha.Year, fecha.Month);
            DateTime fechaFinActual = new DateTime(fecha.Year, fecha.Month, diasMesActual);
            int totalDiasActual = 0;
            if (totalDiasAnterior >= 334)
            {
                totalDiasActual = fechaFinActual.DayOfYear + 365;
            }
            else
            {
                totalDiasActual = fechaFinActual.DayOfYear;
            }

            // Segregación basada en recta: y=mx+b
            double m = (valorMesActual - valorMesAnterior) / (totalDiasActual - totalDiasAnterior);
            double b = valorMesActual - m * totalDiasActual;

            double[] valoresPrecipitacion = new double[6];

            if ((m + b) != 0)
            {
                double[] areas = new double[6];

                double divisorMes = (m * totalDiasActual + b) / (diasMesActual * ((m * totalDiasAnterior + b) + (m * totalDiasActual + b)) / 2);

                for (int i = 5; i >= 0; i--)
                {
                    areas[i] = (5 * i) * (((m * totalDiasAnterior + b) + (m * (totalDiasAnterior + 5 * i) + b)) / 2);
                    if (i == 5)
                    {
                        valoresPrecipitacion[i] = valorMesActual - (areas[i] * divisorMes);
                    }
                    else
                    {
                        valoresPrecipitacion[i] = (areas[i + 1] * divisorMes) - (areas[i] * divisorMes);
                    }
                }
            }
            else
            {
                for (int z = 0; z <= 5; z++)
                {
                    valoresPrecipitacion[z] = 0;
                }

            }

            return valoresPrecipitacion;
        }

        public double segregarPrecipitacionDecadas(double valorMesAnterior, double valorMesActual, int decada, DateTime fecha)
        {
            double pptDecada = 0;

            //Cálculo del número de días del año para el mes anterior
            int diasMesAnterior = DateTime.DaysInMonth(fecha.AddMonths(-1).Year, fecha.AddMonths(-1).Month);
            DateTime fechaFinAnterior = new DateTime(fecha.AddMonths(-1).Year, fecha.AddMonths(-1).Month, diasMesAnterior);
            int totalDiasAnterior = fechaFinAnterior.DayOfYear;

            //Cálculo del número de días del año para el mes actual
            int diasMesActual = DateTime.DaysInMonth(fecha.Year, fecha.Month);
            DateTime fechaFinActual = new DateTime(fecha.Year, fecha.Month, diasMesActual);
            int totalDiasActual = 0;
            //Si el mes anterior es diciembre, se agregan 365 días a la fecha actual para mantener la continuidad de fechas
            if (totalDiasAnterior >= 334)
            {
                totalDiasActual = fechaFinActual.DayOfYear + 365;
            }
            else
            {
                totalDiasActual = fechaFinActual.DayOfYear;
            }

            //Cálculo de parámentros, según la ecuación de la recta y = mx + b
            double m = (valorMesActual - valorMesAnterior) / (totalDiasActual - totalDiasAnterior);
            double b = valorMesActual - m * totalDiasActual;

            double[] valoresPrecipitacion = new double[6];
            if ((m + b) != 0)
            {
                double[] areas = new double[6];
                double divisorMes = (m * totalDiasActual + b) / (diasMesActual * ((m * totalDiasAnterior + b) + (m * totalDiasActual + b)) / 2);
                for (int i = 5; i >= 0; i--)
                {
                    areas[i] = (5 * i) * (((m * totalDiasAnterior + b) + (m * (totalDiasAnterior + 5 * i) + b)) / 2);
                    if (i == 5)
                    {
                        valoresPrecipitacion[i] = valorMesActual - (areas[i] * divisorMes);
                    }
                    else
                    {
                        valoresPrecipitacion[i] = (areas[i + 1] * divisorMes) - (areas[i] * divisorMes);
                    }
                }
            }
            else
            {
                for (int z = 0; z <= 5; z++)
                {
                    valoresPrecipitacion[z] = 0;
                }

            }

            switch (decada)
            {
                case 1:
                    pptDecada = valoresPrecipitacion[0] + valoresPrecipitacion[1];
                    break;
                case 2:
                    pptDecada = valoresPrecipitacion[2] + valoresPrecipitacion[3];
                    break;
                case 3:
                    pptDecada = valoresPrecipitacion[4] + valoresPrecipitacion[5];
                    break;
            };

            return pptDecada;
        }

        /*
         * Crea un arreglo de precipitaciones teniendo en cuenta la lista de meses entregada.
         * Para esto busca los valores reales de los meses anteriores junto con las predicciones
         * del actual y del próximo, si se da el caso.
        */
        public double[][] crearVectorPrecipitaciones(List<DateTime> listaMesesCultivo, int idEstacion)
        {
            int cantidadMeses = listaMesesCultivo.Count();

            double[][] segregacionPrecipitaciones = new double[cantidadMeses][];
            int contadorMeses = 0;

            foreach (DateTime mes in listaMesesCultivo)
            {
                double precipitacionMes = 0;
                if (mes.Year == fechaActual.Year && mes.Month == fechaActual.Month)
                {
                    precipitacionMes = (double)buscarDatosEstacion(mes, idEstacion).Precipitacion;
                }
                else
                {
                    precipitacionMes = (double)buscarDatosEstacion(mes, idEstacion).PrecipitacionReal;
                }
                double precipitacionMesAnterior = (double)buscarDatosEstacion(mes.AddMonths(-1), idEstacion).PrecipitacionReal;

                segregacionPrecipitaciones[contadorMeses] = segregarPrecipitacionMes(precipitacionMesAnterior, precipitacionMes, mes);

                contadorMeses++;
            }

            return segregacionPrecipitaciones;
        }

        /*
         * Crea una lista de variables fecha (DateTime) teniendo en cuenta los valores iniciales y finales
         * entregados. Asigna el día inicial y final según las fechas límites del rango.
         */
        static List<DateTime> mesesEntreFechas(DateTime fechaInicial, DateTime fechaFinal)
        {
            List<DateTime> listaMeses = (Enumerable.Range(0, (fechaFinal.Year - fechaInicial.Year) * 12 + (fechaFinal.Month - fechaInicial.Month + 1))
                             .Select(m => new DateTime(fechaInicial.Year, fechaInicial.Month, 1).AddMonths(m))).ToList();

            listaMeses[0] = fechaInicial;

            if (listaMeses.Count() > 0)
                listaMeses[listaMeses.Count - 1] = fechaFinal;

            return listaMeses;
        }

        /*
         * Busca los datos de la estación de acuerdo a la fecha entregada
         */
        public EstacionMensual buscarDatosEstacion(DateTime fecha, int idEstacion)
        {
            EstacionMensual estacionMensualAnterior = db.EstacionMensual.Where(em => em.EstacionId == idEstacion && em.Fecha.Month == fecha.Month && em.Fecha.Year == fecha.Year).FirstOrDefault();

            return estacionMensualAnterior;
        }

        /*
         * Valida que se tengan datos registrados para la estación en los meses incluidos en la lista
         */
        public bool validarExistenciaDatosEstacion(List<DateTime> listaMeses, int idEstacion)
        {
            bool existenciaDatos = true;

            foreach (DateTime mes in listaMeses)
            {
                EstacionMensual datosEstacion = buscarDatosEstacion(mes, idEstacion);
                if (datosEstacion == null) existenciaDatos = false;
            }

            return existenciaDatos;
        }

    }
}