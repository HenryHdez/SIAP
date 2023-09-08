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
    public class EstacionConstantesController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /EstacionConstantes/
        public ActionResult Index()
        {
            //var estacionconstantes = db.EstacionConstantes.Include(e => e.EstacionTipoConstante).Include(e => e.EstacionValores);
            var estacionconstantes = db.EstacionConstantes.Include(e => e.EstacionValores);
            return View(estacionconstantes.ToList());
        }

        // GET: /EstacionConstantes/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionConstantes estacionconstantes = db.EstacionConstantes.Find(id);
            if (estacionconstantes == null)
            {
                return HttpNotFound();
            }
            return View(estacionconstantes);
        }

        // GET: /EstacionConstantes/Crear
        public ActionResult Crear(int? id)
        {
            //Búsqueda de la estación correspondiente para asignar datos
            Estacion estacion = db.Estacion.Find(id);
            if (estacion != null)
            {
                //SistemaExperto envía la variable con el valor seleccionado de la estación
                ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", estacion.EstacionId);
            }
            else
            {
                ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre");
            }

           // ViewBag.EstacionTipoConstanteId = new SelectList(db.EstacionTipoConstante, "EstacionTipoConstanteId", "Nombre");
            ViewBag.EstacionValoresId = new SelectList(db.EstacionValores, "EstacionValoresId", "EstacionValoresId");
            return View();
        }

        // POST: /EstacionConstantes/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "EstacionConstantesId,EstacionId,EstacionValoresId")] EstacionConstantes estacionconstantes)
        {
            if (ModelState.IsValid)
            {
                db.EstacionConstantes.Add(estacionconstantes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.EstacionTipoConstanteId = new SelectList(db.EstacionTipoConstante, "EstacionTipoConstanteId", "Nombre", estacionconstantes.EstacionTipoConstanteId);
            ViewBag.EstacionValoresId = new SelectList(db.EstacionValores, "EstacionValoresId", "EstacionValoresId", estacionconstantes.EstacionValoresId);
            return View(estacionconstantes);
        }

        // GET: /EstacionConstantes/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionConstantes estacionconstantes = db.EstacionConstantes.Find(id);
            if (estacionconstantes == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", estacionconstantes.EstacionId);
           // ViewBag.EstacionTipoConstanteId = new SelectList(db.EstacionTipoConstante, "EstacionTipoConstanteId", "Nombre", estacionconstantes.EstacionTipoConstanteId);
            ViewBag.EstacionValoresId = new SelectList(db.EstacionValores, "EstacionValoresId", "EstacionValoresId", estacionconstantes.EstacionValoresId);
            return View(estacionconstantes);
        }

        // POST: /EstacionConstantes/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "EstacionConstantesId,EstacionId,EstacionValoresId")] EstacionConstantes estacionconstantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estacionconstantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.EstacionTipoConstanteId = new SelectList(db.EstacionTipoConstante, "EstacionTipoConstanteId", "Nombre", estacionconstantes.EstacionTipoConstanteId);
            ViewBag.EstacionValoresId = new SelectList(db.EstacionValores, "EstacionValoresId", "EstacionValoresId", estacionconstantes.EstacionValoresId);
            return View(estacionconstantes);
        }

        // GET: /EstacionConstantes/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionConstantes estacionconstantes = db.EstacionConstantes.Find(id);
            if (estacionconstantes == null)
            {
                return HttpNotFound();
            }
            return View(estacionconstantes);
        }

        // POST: /EstacionConstantes/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            EstacionConstantes estacionconstantes = db.EstacionConstantes.Find(id);
            db.EstacionConstantes.Remove(estacionconstantes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<EstacionConstantes> filteredCompanies = db.EstacionConstantes;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.EstacionConstantes
                         .Where(c =>
                          c.Estacion.Nombre.Contains(param.sSearch) 
                                     );

            }
            else
            {
                filteredCompanies = db.EstacionConstantes;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<EstacionConstantes, string> orderingFunction = (c => c.Estacion.Nombre);

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
                .Select(c => new { c.EstacionConstantesId, c.EstacionValoresId, c.Estacion.Nombre});
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.EstacionConstantes.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}
