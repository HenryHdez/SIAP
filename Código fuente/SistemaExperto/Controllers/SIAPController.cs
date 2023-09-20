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

namespace SistemaExperto.Controllers
{
    public class SIAPController : Controller
    {
        private SEEntities db = new SEEntities();
        private void actualizadb(string Modulousado) {
            DateTime fechaActual = DateTime.Now;
            string fechaString1 = fechaActual.ToString("yyyy-MM-dd HH:mm:ss");

            SITB_RegIng Registro = new SITB_RegIng();
            Registro.Fecha = fechaString1;
            Registro.Modulo = "D";
            Registro.Submodulo = Modulousado;
            try
            {
                db.SITB_RegIng.Add(Registro);  // Esta es la línea que faltaba
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
            }
        }
        // GET: SIAP
        public ActionResult Index()
        {
            actualizadb("Base");
            return View();
        }
        public ActionResult Balancehidri() {
            actualizadb("Modelos");

            //Balance hidrico
            var Fechas_Est1 = db.SITB_Estacion_1.Select(p => p.Est1_Fecha).ToList();
            var Evapo_Est1 = db.SITB_Estacion_1.Select(p => p.E3_Evapotrans).ToList();
            var Preci_Est1 = db.SITB_Estacion_1.Select(p => p.A2_Precipitation_sum).ToList();

            var Fechas_Est2 = db.SITB_Estacion_2.Select(p => p.Est2_Fecha).ToList();
            var Evapo_Est2 = db.SITB_Estacion_2.Select(p => p.E3_Evapotrans).ToList();
            var Preci_Est2 = db.SITB_Estacion_2.Select(p => p.A2_Precipitation_sum).ToList();

            var Fechas_Est3 = db.SITB_Estacion_3.Select(p => p.Est3_Fecha).ToList();
            var Evapo_Est3 = db.SITB_Estacion_3.Select(p => p.E3_Evapotrans).ToList();
            var Preci_Est3 = db.SITB_Estacion_3.Select(p => p.A2_Precipitation_sum).ToList();

            var jsonest1 = new
            {
                Fecha1 = Fechas_Est1,
                Evapo1 = Evapo_Est1,
                Preci1 = Preci_Est1,
                Fecha2 = Fechas_Est2,
                Evapo2 = Evapo_Est2,
                Preci2 = Preci_Est2,
                Fecha3 = Fechas_Est3,
                Evapo3 = Evapo_Est3,
                Preci3 = Preci_Est3
            };

            ViewBag.jsonest1 = JsonConvert.SerializeObject(jsonest1);

            return View();
        }
        public ActionResult Car_pres() {
            actualizadb("Caracterizacion climatica");
            return View();
        }
        public ActionResult Mod_pres()
        {
            actualizadb("Caracterizacion climatica");
            return View();
        }
        public ActionResult Var_pres()
        {
            actualizadb("Caracterizacion climatica");
            return View();
        }
        public ActionResult brillo()
        {
            actualizadb("Caracterizacion climatica");
            return View();
        }
        public ActionResult Evotrans()
        {
            actualizadb("Caracterizacion climatica");
            return View();
        }
        public ActionResult Humedadrel()
        {
            actualizadb("Caracterizacion climatica");
            return View();
        }
        public ActionResult Precipita()
        {
            actualizadb("Caracterizacion climatica");
            return View();
        }
        public ActionResult Tempmax()
        {
            actualizadb("Caracterizacion climatica");
            return View();
        }
        public ActionResult Tempmed()
        {
            actualizadb("Caracterizacion climatica");
            return View();
        }
        public ActionResult Tempmin()
        {
            actualizadb("Caracterizacion climatica");
            return View();
        }
        public ActionResult Ninonina()
        {
            actualizadb("Variabilidad climatica");
            return View();
        }

        public ActionResult Carbono()
        {
            actualizadb("Modelos");
            return View();
        }
        public ActionResult GDA()
        {
            actualizadb("Variables bioclimaticas");
            //GDA
            var Fechas_Est1 = db.SITB_Estacion_1.Select(p => p.Est1_Fecha).ToList();
            var Tempo_Est1 = db.SITB_Estacion_1.Select(p => p.A6_HC_Air_temperature_avg).ToList();

            var Fechas_Est2 = db.SITB_Estacion_2.Select(p => p.Est2_Fecha).ToList();
            var Tempo_Est2 = db.SITB_Estacion_2.Select(p => p.A6_HC_Air_temperature_avg).ToList();

            var Fechas_Est3 = db.SITB_Estacion_3.Select(p => p.Est3_Fecha).ToList();
            var Tempo_Est3 = db.SITB_Estacion_3.Select(p => p.A6_HC_Air_temperature_avg).ToList();

            
            var jsonest2 = new
            {
                Fecha1 = Fechas_Est1,
                TempPr1 = Tempo_Est1,
                Fecha2 = Fechas_Est2,
                TempPr2 = Tempo_Est2,
                Fecha3 = Fechas_Est3,
                TempPr3 = Tempo_Est3
            };

            ViewBag.jsonest2 = JsonConvert.SerializeObject(jsonest2);
            Console.WriteLine(Fechas_Est1);
            Console.WriteLine(Tempo_Est1);
            Console.WriteLine(Fechas_Est2);
            Console.WriteLine(Fechas_Est3);
            Console.WriteLine(Tempo_Est3);
            return View();
        }
        public ActionResult ISNH()
        {
            actualizadb("Variables bioclimaticas");
            //Balance hidrico
            var Fechas_Est1 = db.SITB_Estacion_1.Select(p => p.Est1_Fecha).ToList();
            var Evapo_Est1 = db.SITB_Estacion_1.Select(p => p.E3_Evapotrans).ToList();
            var Preci_Est1 = db.SITB_Estacion_1.Select(p => p.A2_Precipitation_sum).ToList();

            var Fechas_Est2 = db.SITB_Estacion_2.Select(p => p.Est2_Fecha).ToList();
            var Evapo_Est2 = db.SITB_Estacion_2.Select(p => p.E3_Evapotrans).ToList();
            var Preci_Est2 = db.SITB_Estacion_2.Select(p => p.A2_Precipitation_sum).ToList();

            var Fechas_Est3 = db.SITB_Estacion_3.Select(p => p.Est3_Fecha).ToList();
            var Evapo_Est3 = db.SITB_Estacion_3.Select(p => p.E3_Evapotrans).ToList();
            var Preci_Est3 = db.SITB_Estacion_3.Select(p => p.A2_Precipitation_sum).ToList();

            var jsonest3 = new
            {
                Fecha1 = Fechas_Est1,
                Evapo1 = Evapo_Est1,
                Preci1 = Preci_Est1,
                Fecha2 = Fechas_Est2,
                Evapo2 = Evapo_Est2,
                Preci2 = Preci_Est2,
                Fecha3 = Fechas_Est3,
                Evapo3 = Evapo_Est3,
                Preci3 = Preci_Est3
            };

            ViewBag.jsonest3 = JsonConvert.SerializeObject(jsonest3);

            return View();
        }
        public ActionResult mapa()
        {
            return View();
        }
    }
}