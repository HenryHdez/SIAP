using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;
using System.Data.Entity.SqlServer;

namespace SistemaExperto.Controllers
{
    public class ConglomeradoController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: Conglomerado
        public ActionResult Index()
        {
            var conglomerado = db.Conglomerado.Include(c => c.Departamento);
            return View(conglomerado.ToList());
        }

        // GET: Conglomerado/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conglomerado conglomerado = db.Conglomerado.Find(id);
            if (conglomerado == null)
            {
                return HttpNotFound();
            }
            return View(conglomerado);
        }

        // GET: Conglomerado/Crear
        public ActionResult Crear()
        {
            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre");
            return View();
        }

        // POST: Conglomerado/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ConglomeradoId,DepartamentoId,CodigoMapa,Nombre")] Conglomerado conglomerado)
        {
            if (ModelState.IsValid)
            {
                db.Conglomerado.Add(conglomerado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre", conglomerado.DepartamentoId);
            return View(conglomerado);
        }

        // GET: Conglomerado/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conglomerado conglomerado = db.Conglomerado.Find(id);
            if (conglomerado == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre", conglomerado.DepartamentoId);
            return View(conglomerado);
        }

        // POST: Conglomerado/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ConglomeradoId,DepartamentoId,CodigoMapa,Nombre")] Conglomerado conglomerado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conglomerado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "CodigoDane", conglomerado.DepartamentoId);
            return View(conglomerado);
        }

        // GET: Conglomerado/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conglomerado conglomerado = db.Conglomerado.Find(id);
            if (conglomerado == null)
            {
                return HttpNotFound();
            }
            return View(conglomerado);
        }

        // POST: Conglomerado/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            Conglomerado conglomerado = db.Conglomerado.Find(id);
            db.Conglomerado.Remove(conglomerado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<Conglomerado> filteredCompanies = db.Conglomerado;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.Conglomerado
                         .Where(c => c.Nombre.Contains(param.sSearch) || SqlFunctions.StringConvert((double)c.CodigoMapa).Contains(param.sSearch));
            }
            else
            {
                filteredCompanies = db.Conglomerado;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Conglomerado, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Nombre :
                                                                SqlFunctions.StringConvert((double)c.CodigoMapa));

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
                .Select(c => new { c.ConglomeradoId, Nombre = c.Nombre, CodigoMapa = c.CodigoMapa});
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.ListaOpciones.Count(),
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
