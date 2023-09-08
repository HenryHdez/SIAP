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
    public class MunicipioEstacionController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /MunicipioEstacion/
        public ActionResult Index()
        {
            var municipioestacions = db.MunicipioEstacions.Include(m => m.Estacion).Include(m => m.Municipio);
            return View(municipioestacions.ToList());
        }

        // GET: /MunicipioEstacion/Details/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipioEstacion municipioestacion = db.MunicipioEstacions.Find(id);
            if (municipioestacion == null)
            {
                return HttpNotFound();
            }
            return View(municipioestacion);
        }

        // GET: /MunicipioEstacion/Crear
        public ActionResult Crear()
        {
            ViewBag.EstacionId = new SelectList(db.Estacion.OrderBy(e=>e.Nombre), "EstacionId", "Nombre");
            ViewBag.MunicipioId = new SelectList(db.Municipio.OrderBy(m => m.Nombre), "MunicipioId", "Nombre");
            return View();
        }

        // POST: /MunicipioEstacion/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "MunicipioEstacionId,EstacionId,MunicipioId")] MunicipioEstacion municipioestacion)
        {
            if (ModelState.IsValid)
            {
                db.MunicipioEstacions.Add(municipioestacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", municipioestacion.EstacionId);
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", municipioestacion.MunicipioId);
            return View(municipioestacion);
        }

        // GET: /MunicipioEstacion/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipioEstacion municipioestacion = db.MunicipioEstacions.Find(id);
            if (municipioestacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", municipioestacion.EstacionId);
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", municipioestacion.MunicipioId);
            return View(municipioestacion);
        }

        // POST: /MunicipioEstacion/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "MunicipioEstacionId,EstacionId,MunicipioId")] MunicipioEstacion municipioestacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipioestacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", municipioestacion.EstacionId);
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", municipioestacion.MunicipioId);
            return View(municipioestacion);
        }

        // GET: /MunicipioEstacion/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipioEstacion municipioestacion = db.MunicipioEstacions.Find(id);
            if (municipioestacion == null)
            {
                return HttpNotFound();
            }
            return View(municipioestacion);
        }

        // POST: /MunicipioEstacion/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            MunicipioEstacion municipioestacion = db.MunicipioEstacions.Find(id);
            db.MunicipioEstacions.Remove(municipioestacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<MunicipioEstacion> filteredCompanies = db.MunicipioEstacions;

            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.MunicipioEstacions
                         .Where(c =>
                         c.Estacion.Nombre.Contains(param.sSearch)
                          || c.Municipio.Nombre.Contains(param.sSearch)
                                     //|| Convert.ToString(c.Administrador).Contains(param.sSearch)
                                     );
            }
            else
            {
                filteredCompanies = db.MunicipioEstacions;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<MunicipioEstacion, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Estacion.Nombre :  c.Municipio.Nombre );

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
                .Select(c => new { c.MunicipioEstacionId,Estacion = c.Estacion.Nombre, Municipio = c.Municipio.Nombre});
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.MunicipioEstacions.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);
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
