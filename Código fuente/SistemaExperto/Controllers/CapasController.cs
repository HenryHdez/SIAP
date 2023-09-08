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
    public class CapasController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /Capas/
        public ActionResult Index()
        {
            return View(db.Capas.ToList());
        }

        // GET: /Capas/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capas capas = db.Capas.Find(id);
            if (capas == null)
            {
                return HttpNotFound();
            }
            return View(capas);
        }

        // GET: /Capas/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: /Capas/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "CapaId,NombreCaracterizacion,IdentificadorCaracterizacion,Concepto,RutaImagen")] Capas capas)
        {
            if (ModelState.IsValid)
            {
                db.Capas.Add(capas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(capas);
        }

        // GET: /Capas/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capas capas = db.Capas.Find(id);
            if (capas == null)
            {
                return HttpNotFound();
            }
            return View(capas);
        }

        // POST: /Capas/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "CapaId,NombreCaracterizacion,IdentificadorCaracterizacion,Concepto,RutaImagen")] Capas capas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(capas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(capas);
        }

        // GET: /Capas/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capas capas = db.Capas.Find(id);
            if (capas == null)
            {
                return HttpNotFound();
            }
            return View(capas);
        }

        // POST: /Capas/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            Capas capas = db.Capas.Find(id);
            db.Capas.Remove(capas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
           // int EstacionId = int.Parse(Request.QueryString["EstacionId"]);

            IEnumerable<Capas> filteredCompanies = db.Capas;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.Capas
                         .Where(c =>
                          c.NombreCaracterizacion.Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.Capas;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Capas, string> orderingFunction = (c => sortColumnIndex == 1 ? c.NombreCaracterizacion :
                                                                 c.NombreCaracterizacion);

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
                .Select(c => new { c.CapaId, c.NombreCaracterizacion });
   return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.Capas.Count(),
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
