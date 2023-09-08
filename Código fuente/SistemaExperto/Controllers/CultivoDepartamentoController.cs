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
    public class CultivoDepartamentoController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: cultivoDepartamento
        public ActionResult Index()
        {
            var CultivoDepartamento = db.CultivoDepartamento.Include(c => c.CultivoProductividad).Include(c => c.Departamento);
            return View(CultivoDepartamento.ToList());
        }

        // GET: CultivoDepartamento/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoDepartamento cultivoDepartamento = db.CultivoDepartamento.Find(id);
            if (cultivoDepartamento == null)
            {
                return HttpNotFound();
            }
            return View(cultivoDepartamento);
        }

        // GET: CultivoDepartamento/Crear
        public ActionResult Crear()
        {
            ViewBag.CultivoProductividadId = new SelectList((from c in db.Cultivo
                                                             join cp in db.CultivoProductividad on c.CultivoId equals cp.CultivoId
                                                            select new
                                                            {
                                                                Text = c.Nombre,
                                                                Value = cp.CultivoProductividadId
                                                            }).OrderBy(o => o.Text).ToList().Distinct(), "Value", "Text");
            ViewBag.DepartamentoId = new SelectList(db.Departamento.OrderBy(d=>d.Nombre), "DepartamentoId", "Nombre");
            return View();
        }

        // POST: CultivoDepartamento/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "CultivoDepartamentoId,CultivoProductividadId,DepartamentoId")] CultivoDepartamento cultivoDepartamento)
        {
            if (ModelState.IsValid)
            {
                db.CultivoDepartamento.Add(cultivoDepartamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CultivoProductividadId = new SelectList((from c in db.Cultivo.OrderBy(c => c.Nombre)
                                                             join cp in db.CultivoProductividad on c.CultivoId equals cp.CultivoId
                                                             select new
                                                             {
                                                                 Text = c.Nombre,
                                                                 Value = cp.CultivoProductividadId
                                                             }).OrderBy(o => o.Text).ToList().Distinct(), "Value", "Text");
            ViewBag.DepartamentoId = new SelectList(db.Departamento.OrderBy(d => d.Nombre), "DepartamentoId", "Nombre");

            return View(cultivoDepartamento);
        }

        // GET: CultivoDepartamento/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoDepartamento cultivoDepartamento = db.CultivoDepartamento.Find(id);
            if (cultivoDepartamento == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CultivoProductividadId = new SelectList(db.CultivoProductividad, "CultivoProductividadId", "CultivoProductividadId", cultivoDepartamento.CultivoProductividadId);
            ViewBag.CultivoProductividadId = new SelectList((from c in db.Cultivo
                                                             join cp in db.CultivoProductividad on c.CultivoId equals cp.CultivoId
                                                             select new
                                                             {
                                                                 Text = c.Nombre,
                                                                 Value = cp.CultivoProductividadId
                                                             }).OrderBy(o => o.Text).ToList().Distinct(), "Value", "Text", cultivoDepartamento.CultivoProductividadId);
            ViewBag.DepartamentoId = new SelectList(db.Departamento.OrderBy(d => d.Nombre), "DepartamentoId", "Nombre", cultivoDepartamento.DepartamentoId);
            return View(cultivoDepartamento);
        }

        // POST: cultivoDepartamento/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "CultivoDepartamentoId,CultivoProductividadId,DepartamentoId")] CultivoDepartamento cultivoDepartamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cultivoDepartamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CultivoProductividadId = new SelectList(db.CultivoProductividad, "CultivoProductividadId", "CultivoProductividadId", cultivoDepartamento.CultivoProductividadId);
            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "CodigoDane", cultivoDepartamento.DepartamentoId);
            return View(cultivoDepartamento);
        }

        // GET: cultivoDepartamento/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoDepartamento cultivoDepartamento = db.CultivoDepartamento.Find(id);
            if (cultivoDepartamento == null)
            {
                return HttpNotFound();
            }
            return View(cultivoDepartamento);
        }

        // POST: cultivoDepartamento/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            CultivoDepartamento cultivoDepartamento = db.CultivoDepartamento.Find(id);
            db.CultivoDepartamento.Remove(cultivoDepartamento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<CultivoDepartamento> filteredCompanies = db.CultivoDepartamento;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.CultivoDepartamento
                         .Where(c =>
                          c.CultivoProductividad.Cultivo.Nombre.Contains(param.sSearch) || c.Departamento.Nombre.Contains(param.sSearch) ||
                          c.Departamento.Nombre.Contains(param.sSearch) 
                                     );

            }
            else
            {
                filteredCompanies = db.CultivoDepartamento;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<CultivoDepartamento, string> orderingFunction = (c => sortColumnIndex == 1 ? c.CultivoProductividad.Cultivo.Nombre : c.Departamento.Nombre);

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
                  .Select(c => new { c.CultivoDepartamentoId, CultivoProductividad= c.CultivoProductividad.Cultivo.Nombre,  Departamento = c.Departamento.Nombre });

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.CultivoDepartamento.Count(),
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
