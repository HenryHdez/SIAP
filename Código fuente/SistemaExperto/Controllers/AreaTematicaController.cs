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
    public class AreaTematicaController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /AreaTematica/
        public ActionResult Index()
        {
            return View(db.AreaTematica.ToList());
        }

        // GET: /AreaTematica/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaTematica areatematica = db.AreaTematica.Find(id);
            if (areatematica == null)
            {
                return HttpNotFound();
            }
            return View(areatematica);
        }

        // GET: /AreaTematica/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: /AreaTematica/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "AreaTematicaId,Codigo,Nombre")] AreaTematica areatematica)
        {
            if (ModelState.IsValid)
            {
                db.AreaTematica.Add(areatematica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(areatematica);
        }

        // GET: /AreaTematica/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaTematica areatematica = db.AreaTematica.Find(id);
            if (areatematica == null)
            {
                return HttpNotFound();
            }
            return View(areatematica);
        }

        // POST: /AreaTematica/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="AreaTematicaId,Codigo,Nombre")] AreaTematica areatematica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areatematica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(areatematica);
        }

        // GET: /AreaTematica/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaTematica areatematica = db.AreaTematica.Find(id);
            if (areatematica == null)
            {
                return HttpNotFound();
            }
            return View(areatematica);
        }

        // POST: /AreaTematica/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            AreaTematica areatematica = db.AreaTematica.Find(id);
            db.AreaTematica.Remove(areatematica);
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

            IEnumerable<AreaTematica> filteredCompanies = db.AreaTematica;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.AreaTematica
                         .Where(c =>
                          System.Data.Entity.SqlServer.SqlFunctions.StringConvert((double)c.Codigo).Contains(param.sSearch) 
                          || c.Nombre.Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.AreaTematica;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<AreaTematica, string> orderingFunction = (c => c.Nombre);

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
                .Select(c => new { c.AreaTematicaId, c.Codigo, c.Nombre });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.AreaTematica.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}

