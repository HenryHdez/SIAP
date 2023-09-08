using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;

namespace SistemaExperto.Controllers
{
    public class ZonaEstacionController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /ZonaEstacion/
        public ActionResult Index(int? id)
        {
            ViewBag.ZonaSeleccionada = id;
            var zonaestacion = db.ZonaEstacion.Include(z => z.Estacion).Include(z => z.Zona).Where(z => z.ZonaId == id);
            return View(zonaestacion.ToList());
        }

        // GET: /ZonaEstacion/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZonaEstacion zonaestacion = db.ZonaEstacion.Find(id);
            if (zonaestacion == null)
            {
                return HttpNotFound();
            }
            return View(zonaestacion);
        }

        // GET: /ZonaEstacion/Crear
        public ActionResult Crear(int? id)
        {
            //Dictionary<string, string> list = new Dictionary<string, string>();
            //var zonaSeleccionada = new SelectList(list, "Value", "Key", id.ToString());
            ViewBag.ZonaSeleccionada = id;
            ViewBag.EstacionId = new SelectList(db.Estacion.OrderBy(e=>e.Nombre), "EstacionId", "Nombre");
            ViewBag.ZonaId = new SelectList(db.Zona, "ZonaId", "Nombre", id.ToString());
            return View();
        }

        // POST: /ZonaEstacion/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ZonaEstacionId,ZonaId,EstacionId,Porcentaje,CadenaET,CadenaPE,CadenaRO,CadenaPRO,CadenaR,CadenaPR,CadenaL,CadenaPL,CantidadCadenas,CadenaKs,CadenaZs,CadenaX1s,CadenaX2s,CadenaX3s")] ZonaEstacion zonaestacion)
        {
            //Búsqueda de registros adicionales para la misma zona
            var registrosAsociados = from ra in db.ZonaEstacion
                                     where ra.ZonaId == zonaestacion.ZonaId
                                     select ra;

            //Validación de porcentaje no mayor a 100% para todas las estaciones asignadas a la zona elegida
            int sumaPorcentajes = 0;
            bool estacionExistente = false;
            foreach (var item in registrosAsociados)
            {
                sumaPorcentajes = sumaPorcentajes + item.Porcentaje;

                //Validación de que la estación no exista en los registros para la zona seleccionada
                if (item.EstacionId == zonaestacion.EstacionId)
                {
                    estacionExistente = true;
                }
            }

            //Si la estación ya está asignada a la zona SistemaExperto envía mensaje de error
            if (estacionExistente)
            {
                ViewBag.MensajeError = "La estación ya ha sido asignada a la zona elegida";
            }
            //Si es mayor a 100 SistemaExperto envía mensaje de error
            else if (sumaPorcentajes + zonaestacion.Porcentaje > 100)
            {
                ViewBag.MensajeError = "La suma de los porcentajes asociados a la estación es mayor de 100";
            }
            //Si es menor de 100 SistemaExperto almacena en la base de datos
            else
            {
                if (ModelState.IsValid)
                {
                    db.ZonaEstacion.Add(zonaestacion);
                    db.SaveChanges();
                    return RedirectToAction("Index/"+zonaestacion.ZonaId);
                }
            }

            ViewBag.EstacionId = new SelectList(db.Estacion.OrderBy(e => e.Nombre), "EstacionId", "Nombre", zonaestacion.EstacionId);
            ViewBag.ZonaId = new SelectList(db.Zona, "ZonaId", "Nombre", zonaestacion.ZonaId);
            ViewBag.ZonaSeleccionada = zonaestacion.ZonaId;
            return View(zonaestacion);
        }

        // GET: /ZonaEstacion/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZonaEstacion zonaestacion = db.ZonaEstacion.Find(id);
            if (zonaestacion == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.EstacionId = new SelectList(db.Estacion.OrderBy(e => e.Nombre), "EstacionId", "Nombre", zonaestacion.EstacionId);
            ViewBag.ZonaId = new SelectList(db.Zona, "ZonaId", "Nombre", zonaestacion.ZonaId);
            return View(zonaestacion);
        }

        // POST: /ZonaEstacion/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="ZonaEstacionId,ZonaId,EstacionId,Porcentaje")] ZonaEstacion zonaestacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zonaestacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", zonaestacion.EstacionId);
            ViewBag.ZonaId = new SelectList(db.Zona, "ZonaId", "Nombre", zonaestacion.ZonaId);
            return View(zonaestacion);
        }

        // GET: /ZonaEstacion/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZonaEstacion zonaestacion = db.ZonaEstacion.Find(id);
            if (zonaestacion == null)
            {
                return HttpNotFound();
            }
            return View(zonaestacion);
        }

        // POST: /ZonaEstacion/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            ZonaEstacion zonaestacion = db.ZonaEstacion.Find(id);
            db.ZonaEstacion.Remove(zonaestacion);
            db.SaveChanges();
            return RedirectToAction("Index/"+zonaestacion.ZonaId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
