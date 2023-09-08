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
    public class CultivoCicloController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /CultivoCiclo/
        public ActionResult Index()
        {
            var cultivociclo = db.CultivoCiclo.Include(c => c.Cultivo).Include(c => c.Municipio);
            return View(cultivociclo.ToList());
        }

        // GET: /CultivoCiclo/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoCiclo cultivociclo = db.CultivoCiclo.Find(id);
            if (cultivociclo == null)
            {
                return HttpNotFound();
            }
            return View(cultivociclo);
        }

        // GET: /CultivoCiclo/Crear
        public ActionResult Crear()
        {
            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre");
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre");
            ViewBag.CondicionId = new SelectList(db.Condicion, "CondicionId", "Nombre");
            return View();
        }

        // POST: /CultivoCiclo/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "CultivoCicloId,Nombre,CultivoId,MunicipioId,CondicionId")] CultivoCiclo cultivociclo)
        {
            if (ModelState.IsValid)
            {
                db.CultivoCiclo.Add(cultivociclo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre", cultivociclo.CultivoId);
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", cultivociclo.MunicipioId);
            ViewBag.CondicionId = new SelectList(db.Condicion, "CondicionId", "Nombre", cultivociclo.CondicionId);
            return View(cultivociclo);
        }

        // GET: /CultivoCiclo/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoCiclo cultivociclo = db.CultivoCiclo.Find(id);
            if (cultivociclo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CultivoId = new SelectList(db.Cultivo.OrderBy(c=>c.Nombre), "CultivoId", "Nombre", cultivociclo.CultivoId);
            ViewBag.MunicipioId = new SelectList(db.Municipio.OrderBy(c => c.Nombre), "MunicipioId", "Nombre", cultivociclo.MunicipioId);
            ViewBag.CondicionId = new SelectList(db.Condicion.OrderBy(c => c.Nombre), "CondicionId", "Nombre", cultivociclo.CondicionId);
            return View(cultivociclo);
        }

        // POST: /CultivoCiclo/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="CultivoCicloId,Nombre,CultivoId,MunicipioId,CondicionId")] CultivoCiclo cultivociclo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cultivociclo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre", cultivociclo.CultivoId);
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", cultivociclo.MunicipioId);
            ViewBag.CondicionId = new SelectList(db.Condicion, "CondicionId", "Nombre", cultivociclo.CondicionId);
            return View(cultivociclo);
        }

        // GET: /CultivoCiclo/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoCiclo cultivociclo = db.CultivoCiclo.Find(id);
            if (cultivociclo == null)
            {
                return HttpNotFound();
            }
            return View(cultivociclo);
        }

        // POST: /CultivoCiclo/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            CultivoCiclo cultivociclo = db.CultivoCiclo.Find(id);
            db.CultivoCiclo.Remove(cultivociclo);
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

            IEnumerable<CultivoCiclo> filteredCompanies = db.CultivoCiclo;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.CultivoCiclo
                         .Where(c => c.Cultivo.Nombre.Contains(param.sSearch) || c.Municipio.Nombre.Contains(param.sSearch)
                         || c.Condicion.Nombre.Contains(param.sSearch) || c.Nombre.Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.CultivoCiclo;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<CultivoCiclo, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Cultivo.Nombre :
                                                                sortColumnIndex == 2 ? c.Municipio.Nombre :
                                                                sortColumnIndex == 3 ? c.Condicion.Nombre :
                                                                c.Nombre);


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
                .Select(c => new { c.CultivoCicloId, Cultivo = c.Cultivo.Nombre, Municipio = c.Municipio.Nombre + " (" + c.Municipio.Departamento.Nombre+ ")", Condicion = c.Condicion.Nombre, c.Nombre });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.CultivoCiclo.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}
