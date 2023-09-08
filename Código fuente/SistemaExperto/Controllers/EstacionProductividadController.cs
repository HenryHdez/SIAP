using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;
using SistemaExperto.Controllers;

namespace SE.Controllers
{
    public class EstacionProductividadController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: EstacionProductividad
        public ActionResult Index()
        {
            var estacionProductividad = db.EstacionProductividad.Include(e => e.Estacion);
            return View(estacionProductividad.ToList());
        }

        // GET: EstacionProductividad/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionProductividad estacionProductividad = db.EstacionProductividad.Find(id);
            if (estacionProductividad == null)
            {
                return HttpNotFound();
            }
            return View(estacionProductividad);
        }

        // GET: EstacionProductividad/Crear
        public ActionResult Crear()
        {
            ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre");
            return View();
        }

        // POST: EstacionProductividad/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "EstacionProductividadId,EstacionId,Fecha,Precipitacion,Tmin,Tmax,AnioTipo")] EstacionProductividad estacionProductividad)
        {
            if (ModelState.IsValid)
            {
                db.EstacionProductividad.Add(estacionProductividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", estacionProductividad.EstacionId);
            return View(estacionProductividad);
        }

        // GET: EstacionProductividad/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionProductividad estacionProductividad = db.EstacionProductividad.Find(id);
            if (estacionProductividad == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", estacionProductividad.EstacionId);
            return View(estacionProductividad);
        }

        // POST: EstacionProductividad/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "EstacionProductividadId,EstacionId,Fecha,Precipitacion,Tmin,Tmax,AnioTipo")] EstacionProductividad estacionProductividad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estacionProductividad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", estacionProductividad.EstacionId);
            return View(estacionProductividad);
        }

        // GET: EstacionProductividad/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionProductividad estacionProductividad = db.EstacionProductividad.Find(id);
            if (estacionProductividad == null)
            {
                return HttpNotFound();
            }
            return View(estacionProductividad);
        }

        // POST: EstacionProductividad/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            EstacionProductividad estacionProductividad = db.EstacionProductividad.Find(id);
            db.EstacionProductividad.Remove(estacionProductividad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<EstacionProductividad> filteredCompanies = db.EstacionProductividad;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.EstacionProductividad
                         .Where(c =>
                          c.Estacion.Nombre.Contains(param.sSearch) || c.Fecha.Year.ToString().Contains(param.sSearch) ||
                          c.Fecha.Month.ToString().Contains(param.sSearch)|| c.Fecha.Day.ToString().Contains(param.sSearch) ||
                          c.Precipitacion.ToString().Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.EstacionProductividad;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<EstacionProductividad, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Estacion.Nombre :
                                                                    sortColumnIndex == 2 ? Convert.ToString(c.Fecha.Year) :
                                                                    sortColumnIndex == 3 ? Convert.ToString(c.Fecha.Month) :
                                                                    sortColumnIndex == 4 ? Convert.ToString(c.Fecha.Day) :
                                                                 Convert.ToString(c.Precipitacion));

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredCompanies = filteredCompanies.OrderBy(orderingFunction);
            else
                filteredCompanies = filteredCompanies.OrderByDescending(orderingFunction);
            // fin para orden
            var displayedCompanies = filteredCompanies
                        .Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);


            var result = displayedCompanies
                  .Select(c => new { c.EstacionProductividadId, c.Estacion.Nombre, c.Fecha.Date.Year, c.Fecha.Date.Month, c.Fecha.Date.Day, c.Precipitacion });

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.EstacionProductividad.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
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
