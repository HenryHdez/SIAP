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
    public class ConvencionesController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /Convenciones/
        public ActionResult Index()
        {
            var convenciones = db.Convenciones.Include(c => c.OpcionVisualizacion);
            return View(convenciones.ToList());
        }

        // GET: /Convenciones/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convenciones convenciones = db.Convenciones.Find(id);
            if (convenciones == null)
            {
                return HttpNotFound();
            }
            return View(convenciones);
        }

        // GET: /Convenciones/Crear
        public ActionResult Crear()
        {
            ViewBag.OpcionVisualizacionId = new SelectList(db.OpcionesVisualizacion, "OpcionVisualizacionId", "NombreOpcion");
            return View();
        }

        // POST: /Convenciones/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ConvencionId,NombreIndicador,Color,OpcionVisualizacionId")] Convenciones convenciones)
        {
            if (ModelState.IsValid)
            {
                db.Convenciones.Add(convenciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OpcionVisualizacionId = new SelectList(db.OpcionesVisualizacion, "OpcionVisualizacionId", "NombreOpcion", convenciones.OpcionVisualizacionId);
            return View(convenciones);
        }

        // GET: /Convenciones/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convenciones convenciones = db.Convenciones.Find(id);
            if (convenciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.OpcionVisualizacionId = new SelectList(db.OpcionesVisualizacion, "OpcionVisualizacionId", "NombreOpcion", convenciones.OpcionVisualizacionId);
            return View(convenciones);
        }

        // POST: /Convenciones/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ConvencionId,NombreIndicador,Color,OpcionVisualizacionId,ValorLayer")] Convenciones convenciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(convenciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OpcionVisualizacionId = new SelectList(db.OpcionesVisualizacion, "OpcionVisualizacionId", "NombreOpcion", convenciones.OpcionVisualizacionId);
            return View(convenciones);
        }

        // GET: /Convenciones/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convenciones convenciones = db.Convenciones.Find(id);
            if (convenciones == null)
            {
                return HttpNotFound();
            }
            return View(convenciones);
        }

        // POST: /Convenciones/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            Convenciones convenciones = db.Convenciones.Find(id);
            db.Convenciones.Remove(convenciones);
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

            IEnumerable<Convenciones> filteredCompanies = db.Convenciones;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.Convenciones
                         .Where(c =>
                          c.OpcionVisualizacion.Capa.NombreCaracterizacion.Contains(param.sSearch) || c.OpcionVisualizacion.NombreOpcion.Contains(param.sSearch)
                          || c.NombreIndicador.Contains(param.sSearch) 
                                     );

            }
            else
            {
                filteredCompanies = db.Convenciones;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Convenciones, string> orderingFunction = (c => sortColumnIndex == 1 ? c.OpcionVisualizacion.Capa.NombreCaracterizacion :
                                                                sortColumnIndex == 2 ?  c.OpcionVisualizacion.NombreOpcion : c.NombreIndicador);

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
                .Select(c => new { c.ConvencionId, c.OpcionVisualizacion.Capa.NombreCaracterizacion, c.OpcionVisualizacion.NombreOpcion, c.NombreIndicador });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.Convenciones.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}
