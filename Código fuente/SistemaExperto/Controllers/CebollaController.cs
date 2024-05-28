using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;
using Rotativa;
using Newtonsoft.Json;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Globalization;

namespace SE.Controllers
{
    public class CebollaController : Controller
    {
        private SEEntities db = new SEEntities();
        private void actualizadb(string Modulousado)
        {
            DateTime fechaActual = DateTime.Now;
            string fechaString1 = fechaActual.ToString("yyyy-MM-dd HH:mm:ss");

            SITB_RegIng Registro = new SITB_RegIng();
            Registro.Fecha = fechaString1;
            Registro.Modulo = "E";
            Registro.Submodulo = "Cebolla";
            try
            {
                db.SITB_RegIng.Add(Registro);  
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
            }
        }
        // GET: Cebolla
        public ActionResult Index()
        {
            actualizadb("Modulo E");
            return View();
        }

        public ActionResult Modelohidrico()
        {
            actualizadb("Seguimiento meteorologico");
            // Lectura de la estación
            var formatoFechaEntrada = "yyyy-MM-dd HH:mm:ss";
            double temp;
            double prec;
            double windDir;
            double windSpeed;
            double lightningDist;
            double solarRad;
            double vaporPress;

            var datosVar = db.ZentraVar.Select(x => new {
                Datetime = x.Datetime,
                AirTemperature = x.AirTemperature,
                Precipitation = x.Precipitation,
                WindDirection = x.WindDirection,
                WindSpeed = x.WindSpeed,
                LightningDistance = x.LightningDistance,
                SolarRadiation = x.SolarRadiation,
                VaporPressure = x.VaporPressure
            }).ToList();


            var culture = CultureInfo.CreateSpecificCulture("en-US");

            var datosConvertidos = datosVar.Select(x => new {
                Fecha = DateTime.ParseExact(x.Datetime.Substring(0, 19), formatoFechaEntrada, null),
                AirTemperature = double.TryParse(x.AirTemperature, NumberStyles.Float, culture, out temp) ? temp : (double?)null,
                Precipitation = double.TryParse(x.Precipitation, NumberStyles.Float, culture, out prec) ? prec : (double?)null,
                WindDirection = double.TryParse(x.WindDirection, NumberStyles.Float, culture, out windDir) ? windDir : (double?)null,
                WindSpeed = double.TryParse(x.WindSpeed, NumberStyles.Float, culture, out windSpeed) ? windSpeed : (double?)null,
                LightningDistance = double.TryParse(x.LightningDistance, NumberStyles.Float, culture, out lightningDist) ? lightningDist : (double?)null,
                SolarRadiation = double.TryParse(x.SolarRadiation, NumberStyles.Float, culture, out solarRad) ? solarRad : (double?)null,
                VaporPressure = double.TryParse(x.VaporPressure, NumberStyles.Float, culture, out vaporPress) ? vaporPress : (double?)null
            }).ToList();

            var datosAgrupados = datosConvertidos
                .GroupBy(x => x.Fecha.Date)
                .Select(g => new {
                    Fecha = g.Key.ToString("yyyy-MM-dd"),
                    TempMin = g.Min(x => x.AirTemperature),
                    TempMax = g.Max(x => x.AirTemperature),
                    TempMedia = g.Average(x => x.AirTemperature),
                    PrecipitacionTotal = g.Sum(x => x.Precipitation),
                    DireccionVientoPromedio = g.Average(x => x.WindDirection),
                    VelocidadVientoPromedio = g.Average(x => x.WindSpeed),
                    DistanciaRayosPromedio = g.Average(x => x.LightningDistance),
                    RadiacionSolarPromedio = g.Average(x => x.SolarRadiation),
                    PresionVaporPromedio = g.Average(x => x.VaporPressure)
                }).ToList();

            datosAgrupados = datosAgrupados
                .OrderBy(x => DateTime.Parse(x.Fecha))
                .ToList();

            var datosET0Brutos = db.ZentraET0
                .Select(x => new {
                    x.Datetime,
                    x.ETo
                })
                .ToList();

            var datosET0 = datosET0Brutos
                .Select(x => {
                    double etoTemp;
                    var etoParsed = double.TryParse(x.ETo, NumberStyles.Float, culture, out etoTemp) ? etoTemp : (double?)null;
                    var fechaParsed = DateTime.ParseExact(x.Datetime.Substring(0, 10), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    return new
                    {
                        Fecha = fechaParsed.ToString("yyyy-MM-dd"),
                        ETo = etoParsed
                    };
                })
                .ToList();

            datosET0 = datosET0
                .OrderBy(x => DateTime.Parse(x.Fecha))
                .ToList();

            var jsonDatosAgrupados = JsonConvert.SerializeObject(datosAgrupados);
            var jsonDatosET0 = JsonConvert.SerializeObject(datosET0);

            ViewBag.jsonest4 = jsonDatosAgrupados;
            ViewBag.jsonDatosET0 = jsonDatosET0;
            return View();
        }
        
        public ActionResult CebollaMapas()
        {
            actualizadb("Mapa ocaña");
            return View();
        }

        public ActionResult AdvertenciCebolla() {
            return View();
        }

        public ActionResult SeguimientoCultivo() {
            actualizadb("Seguimiento del cultivo de cebolla");
            var formatoFechaEntrada = "yyyy-MM-dd HH:mm:ssK";
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            //Variables para realizar el calculo del balance
            var datosVar = db.ZentraVar
                            .Select(x => new { x.Datetime, x.Precipitation })
                            .ToList();

            var datosET0 = db.ZentraET0
                            .Select(x => new { x.Datetime, x.ETo })
                            .ToList();

            var datosConvertidos = new List<DatosMeteorologicos>();

            foreach (var item in datosVar)
            {
                DateTime fechaParseada;
                double precipitacion = 0;
                double valorPrecipitacion;

                if (DateTime.TryParseExact(item.Datetime.Substring(0, 19), formatoFechaEntrada, null, System.Globalization.DateTimeStyles.None, out fechaParseada))
                {
                    if (double.TryParse(item.Precipitation, NumberStyles.Float, culture, out valorPrecipitacion))
                    {
                        precipitacion = valorPrecipitacion;
                    }
                    datosConvertidos.Add(new DatosMeteorologicos
                    {
                        Fecha = fechaParseada,
                        Dia = fechaParseada.Day,
                        Mes = fechaParseada.Month,
                        Año = fechaParseada.Year,
                        Valor = precipitacion 
                    });
                }
            }

            var SumaPreDiario = datosConvertidos
                .GroupBy(p => new { p.Dia, p.Mes, p.Año })
                .Select(g => new {
                    Dia = g.Key.Dia,
                    Mes = g.Key.Mes,
                    Año = g.Key.Año,
                    SumaPre = g.Sum(p => p.Valor)
                }).ToList();

            // Procesar datosET0
            var datosET0Convertidos = new List<DatosMeteorologicosExtendidos>();
            foreach (var item in datosET0)
            {
                DateTime fechaParseada;
                double valorETo;
                if (DateTime.TryParseExact(item.Datetime.Substring(0, 19), formatoFechaEntrada, null, System.Globalization.DateTimeStyles.None, out fechaParseada))
                {
                    if (double.TryParse(item.ETo, NumberStyles.Float, culture, out valorETo))
                    {
                        datosET0Convertidos.Add(new DatosMeteorologicosExtendidos
                        {
                            Fecha = fechaParseada,
                            Dia = fechaParseada.Day,
                            Mes = fechaParseada.Month,
                            Año = fechaParseada.Year,
                            Valor = valorETo
                        });
                    }
                }
            }

            var datosCombinados = (from pre in SumaPreDiario
                                   join et0 in datosET0Convertidos
                                   on new { pre.Dia, pre.Mes, pre.Año } equals new { et0.Dia, et0.Mes, et0.Año }
                                   orderby pre.Año, pre.Mes, pre.Dia 
                                   select new
                                   {
                                       Fecha = new DateTime(pre.Año, pre.Mes, pre.Dia).ToString("yyyy-MM-dd"),
                                       ET0 = et0.Valor,
                                       PromedioPre = pre.SumaPre
                                   }).ToList();
            var jsonResult = JsonConvert.SerializeObject(datosCombinados);
            ViewBag.jsonest5 = jsonResult;
            return View();
        }

        public class DatosMeteorologicos
        {
            public DateTime Fecha { get; set; }
            public int Dia { get; set; }
            public int Mes { get; set; }
            public int Año { get; set; }
            public double Valor { get; set; }
        }
        public class DatosMeteorologicosExtendidos
        {
            public DateTime Fecha { get; set; }
            public int Dia { get; set; }
            public int Mes { get; set; }
            public int Año { get; set; }
            public double Valor { get; set; }
        }
    }
}