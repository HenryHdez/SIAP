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
    public class OpcionTecnologicaController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /OpcionTecnologica/
        public ActionResult Index()
        {
            var opciontecnologica = db.OpcionTecnologica.Include(o => o.AreaTematica);
            return View(opciontecnologica.ToList());
        }

        // GET: /OpcionTecnologica/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpcionTecnologica opciontecnologica = db.OpcionTecnologica.Find(id);
            if (opciontecnologica == null)
            {
                return HttpNotFound();
            }
            return View(opciontecnologica);
        }

        // GET: /OpcionTecnologica/Crear
        public ActionResult Crear()
        {
            ViewBag.AreaTematicaId = new SelectList(db.AreaTematica, "AreaTematicaId", "Nombre");
            return View();
        }

        // POST: /OpcionTecnologica/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "OpcionTecnologicaId,Nombre,AreaTematicaId")] OpcionTecnologica opciontecnologica)
        {
            if (ModelState.IsValid)
            {
                db.OpcionTecnologica.Add(opciontecnologica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaTematicaId = new SelectList(db.AreaTematica, "AreaTematicaId", "Nombre", opciontecnologica.AreaTematicaId);
            return View(opciontecnologica);
        }

        // GET: /OpcionTecnologica/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpcionTecnologica opciontecnologica = db.OpcionTecnologica.Find(id);
            if (opciontecnologica == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaTematicaId = new SelectList(db.AreaTematica, "AreaTematicaId", "Nombre", opciontecnologica.AreaTematicaId);
            return View(opciontecnologica);
        }

        // POST: /OpcionTecnologica/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="OpcionTecnologicaId,Nombre,AreaTematicaId")] OpcionTecnologica opciontecnologica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opciontecnologica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaTematicaId = new SelectList(db.AreaTematica, "AreaTematicaId", "Nombre", opciontecnologica.AreaTematicaId);
            return View(opciontecnologica);
        }

        // GET: /OpcionTecnologica/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpcionTecnologica opciontecnologica = db.OpcionTecnologica.Find(id);
            if (opciontecnologica == null)
            {
                return HttpNotFound();
            }
            return View(opciontecnologica);
        }

        // POST: /OpcionTecnologica/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            OpcionTecnologica opciontecnologica = db.OpcionTecnologica.Find(id);
            db.OpcionTecnologica.Remove(opciontecnologica);
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

            IEnumerable<OpcionTecnologica> filteredCompanies = db.OpcionTecnologica;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.OpcionTecnologica
                         .Where(c => c.Nombre.Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.OpcionTecnologica;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<OpcionTecnologica, string> orderingFunction = (c => c.Nombre);

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
                .Select(c => new { c.OpcionTecnologicaId, c.Nombre });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.OpcionTecnologica.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}
