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
    public class CapasDepartamentosController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /CapasDepartamentos/
        public ActionResult Index()
        {
            var capasdepartamentos = db.CapasDepartamentos.Include(c => c.Capa).Include(c => c.Departamento);
            return View(capasdepartamentos.ToList());
        }

        // GET: /CapasDepartamentos/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapasDepartamentos capasdepartamentos = db.CapasDepartamentos.Find(id);
            if (capasdepartamentos == null)
            {
                return HttpNotFound();
            }
            return View(capasdepartamentos);
        }

        // GET: /CapasDepartamentos/Crear
        public ActionResult Crear()
        {
            ViewBag.CapaId = new SelectList(db.Capas, "CapaId", "NombreCaracterizacion");
            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre");
            return View();
        }

        // POST: /CapasDepartamentos/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "CapaDepartamentoId,CapaId,DepartamentoId,Visible,ExplicacionMapa")] CapasDepartamentos capasdepartamentos)
        {
            if (ModelState.IsValid)
            {
                db.CapasDepartamentos.Add(capasdepartamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CapaId = new SelectList(db.Capas, "CapaId", "NombreCaracterizacion", capasdepartamentos.CapaId);
            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre", capasdepartamentos.DepartamentoId);
            return View(capasdepartamentos);
        }

        // GET: /CapasDepartamentos/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapasDepartamentos capasdepartamentos = db.CapasDepartamentos.Find(id);
            if (capasdepartamentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CapaId = new SelectList(db.Capas, "CapaId", "NombreCaracterizacion", capasdepartamentos.CapaId);
            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre", capasdepartamentos.DepartamentoId);
            return View(capasdepartamentos);
        }

        // POST: /CapasDepartamentos/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "CapaDepartamentoId,CapaId,DepartamentoId,ExplicacionMapa,Visible")] CapasDepartamentos capasdepartamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(capasdepartamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CapaId = new SelectList(db.Capas, "CapaId", "NombreCaracterizacion", capasdepartamentos.CapaId);
            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "CodigoDane", capasdepartamentos.DepartamentoId);
            return View(capasdepartamentos);
        }

        // GET: /CapasDepartamentos/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapasDepartamentos capasdepartamentos = db.CapasDepartamentos.Find(id);
            if (capasdepartamentos == null)
            {
                return HttpNotFound();
            }
            return View(capasdepartamentos);
        }

        // POST: /CapasDepartamentos/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            CapasDepartamentos capasdepartamentos = db.CapasDepartamentos.Find(id);
            db.CapasDepartamentos.Remove(capasdepartamentos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
          
            IEnumerable<CapasDepartamentos> filteredCompanies = db.CapasDepartamentos;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.CapasDepartamentos
                         .Where(c =>
                          c.Capa.NombreCaracterizacion.Contains(param.sSearch) || c.Departamento.Nombre.Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.CapasDepartamentos;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<CapasDepartamentos, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Capa.NombreCaracterizacion :
                                                                 c.Departamento.Nombre);

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
                .Select(c => new { c.CapaDepartamentoId, c.Capa.NombreCaracterizacion, c.Departamento.Nombre });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.CapasDepartamentos.Count(),
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
