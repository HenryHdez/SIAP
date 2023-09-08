using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;
using System.Data.SqlClient;

namespace SistemaExperto.Controllers
{
    public class EstacionValoresController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /EstacionValores/
        public ActionResult Index()
        {
            return View(db.EstacionValores.ToList());
        }

        // GET: /EstacionValores/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionValores estacionvalores = db.EstacionValores.Find(id);
            if (estacionvalores == null)
            {
                return HttpNotFound();
            }
            return View(estacionvalores);
        }

        // GET: /EstacionValores/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: /EstacionValores/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "EstacionValoresId,Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Septiembre,Octubre,Noviembre,Diciembre,EstacionTipoConstanteId")] EstacionValores estacionvalores)
        {
            if (ModelState.IsValid)
            {
                db.EstacionValores.Add(estacionvalores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estacionvalores);
        }

        // GET: /EstacionValores/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionValores estacionvalores = db.EstacionValores.Find(id);
            if (estacionvalores == null)
            {
                return HttpNotFound();
            }
            return View(estacionvalores);
        }

        // POST: /EstacionValores/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "EstacionValoresId,Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Septiembre,Octubre,Noviembre,Diciembre,EstacionTipoConstanteId")] EstacionValores estacionvalores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estacionvalores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estacionvalores);
        }

        // GET: /EstacionValores/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionValores estacionvalores = db.EstacionValores.Find(id);
            if (estacionvalores == null)
            {
                return HttpNotFound();
            }
            return View(estacionvalores);
        }

        // POST: /EstacionValores/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            EstacionValores estacionvalores = db.EstacionValores.Find(id);
            db.EstacionValores.Remove(estacionvalores);
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

            IEnumerable<EstacionValores> filteredCompanies = db.EstacionValores;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //tring cod = Convert.ToString(codigoIdeamEstacionExcel).Trim();
                var filtro =
                filteredCompanies = db.EstacionValores
                         .Where(c =>
                          c.EstacionTipoConstante.Nombre.Contains(param.sSearch) 
                          || System.Data.Entity.SqlServer.SqlFunctions.StringConvert((double)c.Anio).Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.EstacionValores;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<EstacionValores, string> orderingFunction = (c => sortColumnIndex == 1 ? c.EstacionTipoConstante.Nombre :
                                                                Convert.ToString(c.Anio));

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredCompanies = filteredCompanies.OrderBy(orderingFunction);
            else
                filteredCompanies = filteredCompanies.OrderByDescending(orderingFunction);
            // fin para orden
            var displayedCompanies = filteredCompanies
                        .Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            //var estacionNombre = displayedCompanies.Select();

            var result = displayedCompanies
                .Select(c => new { c.EstacionValoresId, c.EstacionTipoConstante.Nombre, c.Anio, c.Enero });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.EstacionValores.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}

