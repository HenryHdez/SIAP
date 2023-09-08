using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SE.Controllers
{
    public class AdministracionController : Controller
    {
        //
        // GET: /Administracion/
        public ActionResult Index()
        {
            return View();
        }
        // GET: /Administracion/Parametros
        public ActionResult Parametros()
        {
            return View();
        }

        public ActionResult Glosario()
        {
            return View();
        }

        public ActionResult Mapa()
        {
            return View();
        }

        public ActionResult Productividad()
        {
            return View();
        }
    }
}