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
        // GET: Cebolla
        public ActionResult Index()
        {
            actualizadb("Modulo E");
            return View();
        }

        public ActionResult Modelohidrico()
        {
            return View();
        }

    }
}