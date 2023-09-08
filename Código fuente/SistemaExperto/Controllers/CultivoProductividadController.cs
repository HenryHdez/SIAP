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
    public class CultivoProductividadController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: CultivoProductividad
        public ActionResult Index()
        {
            var cultivoProductividad = db.CultivoProductividad.Include(c => c.Cultivo);
            return View(cultivoProductividad.ToList());
        }

        // GET: CultivoProductividad/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoProductividad cultivoProductividad = db.CultivoProductividad.Find(id);
            if (cultivoProductividad == null)
            {
                return HttpNotFound();
            }
            return View(cultivoProductividad);
        }

        // GET: CultivoProductividad/Crear
        public ActionResult Crear()
        {
            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre");
            return View();
        }

        // POST: CultivoProductividad/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "CultivoProductividadId,CultivoId,AMP,ADT,AFA,KyInicial,KyDesarrollo,KyMedio,KyFinal,EtapaInicial,EtapaDesarrollo,EtapaMedio,EtapaFinal")] CultivoProductividad cultivoProductividad)
        {
            if (ModelState.IsValid)
            {
                db.CultivoProductividad.Add(cultivoProductividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre", cultivoProductividad.CultivoId);
            return View(cultivoProductividad);
        }

        // GET: CultivoProductividad/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoProductividad cultivoProductividad = db.CultivoProductividad.Find(id);
            if (cultivoProductividad == null)
            {
                return HttpNotFound();
            }
            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre", cultivoProductividad.CultivoId);
            return View(cultivoProductividad);
        }

        // POST: CultivoProductividad/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "CultivoProductividadId,CultivoId,AMP,ADT,AFA,KyInicial,KyDesarrollo,KyMedio,KyFinal,EtapaInicial,EtapaDesarrollo,EtapaMedio,EtapaFinal")] CultivoProductividad cultivoProductividad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cultivoProductividad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre", cultivoProductividad.CultivoId);
            return View(cultivoProductividad);
        }

        // GET: CultivoProductividad/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoProductividad cultivoProductividad = db.CultivoProductividad.Find(id);
            if (cultivoProductividad == null)
            {
                return HttpNotFound();
            }
            return View(cultivoProductividad);
        }

        // POST: CultivoProductividad/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            CultivoProductividad cultivoProductividad = db.CultivoProductividad.Find(id);
            db.CultivoProductividad.Remove(cultivoProductividad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            IEnumerable<CultivoProductividad> filteredCompanies = db.CultivoProductividad;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.CultivoProductividad
                         .Where(c =>
                          c.Cultivo.Nombre.Contains(param.sSearch) 
                                     );
            }
            else
            {
                filteredCompanies = db.CultivoProductividad;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<CultivoProductividad, string> orderingFunction = (c =>  c.Cultivo.Nombre );

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
                  .Select(c => new { c.CultivoProductividadId, c.Cultivo.Nombre});

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.CultivoProductividad.Count(),
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
