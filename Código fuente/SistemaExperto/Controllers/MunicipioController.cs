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
    public class MunicipioController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /Municipio/
        public ActionResult Index(int id=0)
        {
            var municipio = db.Municipio.Include(m => m.Departamento);

            if (id != 0)
            {
                ViewBag.CodigoDepartamento = id.ToString();
                municipio = municipio.Where(m => m.DepartamentoId.Equals(id));
            }

            return View(municipio);
        }

        // GET: /Municipio/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        // GET: /Municipio/Crear
        public ActionResult Crear()
        {
            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre");
            return View();
        }

        // POST: /Municipio/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include= "MunicipioId,Nombre,Descripcion,DepartamentoId,CodigoDane,Box,RutaImagen")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Municipio.Add(municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre", municipio.DepartamentoId);
            return View(municipio);
        }

        // GET: /Municipio/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre", municipio.DepartamentoId);
            return View(municipio);
        }

        // POST: /Municipio/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include= "MunicipioId,Nombre,Descripcion,DepartamentoId,CodigoDane,Box,RutaImagen")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre", municipio.DepartamentoId);
            return View(municipio);
        }

        // GET: /Municipio/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        // POST: /Municipio/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            Municipio municipio = db.Municipio.Find(id);
            db.Municipio.Remove(municipio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<Municipio> filteredCompanies = db.Municipio;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.Municipio
                         .Where(c =>
                          c.Departamento.Nombre.Contains(param.sSearch) || c.Nombre.Contains(param.sSearch) ||
                          c.CodigoDane.Contains(param.sSearch) 
                                     );

            }
            else
            {
                filteredCompanies = db.Municipio;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Municipio, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Departamento.Nombre :
                                                                    sortColumnIndex == 2 ? c.Nombre :
                                                                     c.CodigoDane );

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
                  .Select(c => new { c.MunicipioId, Departamento=c.Departamento.Nombre, c.Nombre, c.CodigoDane });

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.Municipio.Count(),
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
