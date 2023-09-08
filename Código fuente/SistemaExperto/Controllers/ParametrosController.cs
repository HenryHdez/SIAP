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
    public class ParametrosController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: Parametros
        public ActionResult Index()
        {
            return View(db.Parametros.ToList());
        }

        // GET: Parametros/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parametros parametros = db.Parametros.Find(id);
            if (parametros == null)
            {
                return HttpNotFound();
            }
            return View(parametros);
        }

        // GET: Parametros/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Parametros/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ParametrosId,Codigo,Nombre,NombreBD,Valor,Descripcion")] Parametros parametros)
        {
            if (ModelState.IsValid)
            {
                db.Parametros.Add(parametros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parametros);
        }

        // GET: Parametros/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parametros parametros = db.Parametros.Find(id);
            if (parametros == null)
            {
                return HttpNotFound();
            }
            return View(parametros);
        }

        // POST: Parametros/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ParametrosId,Codigo,Nombre,NombreBD,Valor,Descripcion")] Parametros parametros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parametros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parametros);
        }

        // GET: Parametros/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parametros parametros = db.Parametros.Find(id);
            if (parametros == null)
            {
                return HttpNotFound();
            }
            return View(parametros);
        }

        // POST: Parametros/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            Parametros parametros = db.Parametros.Find(id);
            db.Parametros.Remove(parametros);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<Parametros> filteredCompanies = db.Parametros;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.Parametros
                         .Where(c =>
                          c.Codigo.ToString().Contains(param.sSearch) ||
                          c.Nombre.Contains(param.sSearch) 
                                     );

            }
            else
            {
                filteredCompanies = db.Parametros;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Parametros, string> orderingFunction = (c => sortColumnIndex == 1 ?  Convert.ToString(c.Codigo) :
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
                  .Select(c => new { c.ParametrosId, c.Codigo, c.Nombre });

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.Parametros.Count(),
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
