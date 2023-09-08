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
    public class OpcionesVisualizacionController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /OpcionesVisualizacion/
        public ActionResult Index()
        {
            var opcionesvisualizacion = db.OpcionesVisualizacion.Include(o => o.Capa);
            return View(opcionesvisualizacion.ToList());
        }

        // GET: /OpcionesVisualizacion/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpcionesVisualizacion opcionesvisualizacion = db.OpcionesVisualizacion.Find(id);
            if (opcionesvisualizacion == null)
            {
                return HttpNotFound();
            }
            return View(opcionesvisualizacion);
        }

        // GET: /OpcionesVisualizacion/Crear
        public ActionResult Crear()
        {
            ViewBag.CapaId = new SelectList(db.Capas, "CapaId", "NombreCaracterizacion");
            return View();
        }

        // POST: /OpcionesVisualizacion/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "OpcionVisualizacionId,NombreTipoOpcion,NombreOpcion,NombreOpcionJScript,CapaId")] OpcionesVisualizacion opcionesvisualizacion)
        {
            if (ModelState.IsValid)
            {
                db.OpcionesVisualizacion.Add(opcionesvisualizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CapaId = new SelectList(db.Capas, "CapaId", "NombreCaracterizacion", opcionesvisualizacion.CapaId);
            return View(opcionesvisualizacion);
        }

        // GET: /OpcionesVisualizacion/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpcionesVisualizacion opcionesvisualizacion = db.OpcionesVisualizacion.Find(id);
            if (opcionesvisualizacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CapaId = new SelectList(db.Capas, "CapaId", "NombreCaracterizacion", opcionesvisualizacion.CapaId);
            return View(opcionesvisualizacion);
        }

        // POST: /OpcionesVisualizacion/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "OpcionVisualizacionId,NombreTipoOpcion,NombreOpcion,NombreOpcionJScript,CapaId")] OpcionesVisualizacion opcionesvisualizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opcionesvisualizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CapaId = new SelectList(db.Capas, "CapaId", "NombreCaracterizacion", opcionesvisualizacion.CapaId);
            return View(opcionesvisualizacion);
        }

        // GET: /OpcionesVisualizacion/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpcionesVisualizacion opcionesvisualizacion = db.OpcionesVisualizacion.Find(id);
            if (opcionesvisualizacion == null)
            {
                return HttpNotFound();
            }
            return View(opcionesvisualizacion);
        }

        // POST: /OpcionesVisualizacion/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            OpcionesVisualizacion opcionesvisualizacion = db.OpcionesVisualizacion.Find(id);
            db.OpcionesVisualizacion.Remove(opcionesvisualizacion);
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

            IEnumerable<OpcionesVisualizacion> filteredCompanies = db.OpcionesVisualizacion;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.OpcionesVisualizacion
                         .Where(c =>
                          c.Capa.NombreCaracterizacion.Contains(param.sSearch) || c.NombreOpcion.Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.OpcionesVisualizacion;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<OpcionesVisualizacion, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Capa.NombreCaracterizacion :
                                                                 c.NombreOpcion);

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
                .Select(c => new { c.OpcionVisualizacionId, c.Capa.NombreCaracterizacion, c.NombreOpcion });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.OpcionesVisualizacion.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}
