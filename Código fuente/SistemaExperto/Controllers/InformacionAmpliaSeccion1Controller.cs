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
    public class InformacionAmpliaSeccion1Controller : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /InformacionAmpliaSeccion1/
        public ActionResult Index()
        {
            var informacionampliaseccion1 = db.InformacionAmpliaSeccion1.Include(i => i.CapasDepartamentos);
            return View(informacionampliaseccion1.ToList());
        }

        // GET: /InformacionAmpliaSeccion1/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionAmpliaSeccion1 informacionampliaseccion1 = db.InformacionAmpliaSeccion1.Find(id);

            if (informacionampliaseccion1 == null)
            {
                return HttpNotFound();
            }
            return View(informacionampliaseccion1);
        }

        // GET: /InformacionAmpliaSeccion1/Crear
        public ActionResult Crear()
        {
            ViewData["CapaDepartamentoId"] =
          new SelectList((from cd in db.CapasDepartamentos
                          join c in db.Capas on cd.CapaId equals c.CapaId
                          join d in db.Departamento
                          on cd.DepartamentoId equals d.DepartamentoId
                          select new
                          {
                              IDCapa = cd.CapaDepartamentoId,
                              FullName = c.NombreCaracterizacion + " - " + d.Nombre
                          }).ToList(),
          "IDCapa", "FullName");
            //ViewBag.CapaDepartamentoId = new SelectList(db.CapasDepartamentos, "CapaDepartamentoId", "CapaDepartamentoId");
            return View();
        }

        // POST: /InformacionAmpliaSeccion1/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "InformacionAmpliaSeccion1Id,CapaDepartamentoId,TituloSeccion1,InformacionMapa,NombreMapa")] InformacionAmpliaSeccion1 informacionampliaseccion1)
        {
            if (ModelState.IsValid)
            {
                db.InformacionAmpliaSeccion1.Add(informacionampliaseccion1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CapaDepartamentoId"] =
           new SelectList((from cd in db.CapasDepartamentos
                           join c in db.Capas on cd.CapaId equals c.CapaId
                           join d in db.Departamento
                           on cd.DepartamentoId equals d.DepartamentoId
                           select new
                           {
                               IDCapa = cd.CapaDepartamentoId,
                               FullName = c.NombreCaracterizacion + " - " + d.Nombre
                           }).ToList(),
           "IDCapa", "FullName", informacionampliaseccion1.CapaDepartamentoId);
            //ViewBag.CapaDepartamentoId = new SelectList(db.CapasDepartamentos, "CapaDepartamentoId", "CapaDepartamentoId", informacionampliaseccion1.CapaDepartamentoId);
            return View(informacionampliaseccion1);
        }

        // GET: /InformacionAmpliaSeccion1/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionAmpliaSeccion1 informacionampliaseccion1 = db.InformacionAmpliaSeccion1.Find(id);
            if (informacionampliaseccion1 == null)
            {
                return HttpNotFound();
            }
            ViewData["CapaDepartamentoId"] =
         new SelectList((from cd in db.CapasDepartamentos
                         join c in db.Capas on cd.CapaId equals c.CapaId
                         join d in db.Departamento
                         on cd.DepartamentoId equals d.DepartamentoId
                         select new
                         {
                             IDCapa = cd.CapaDepartamentoId,
                             FullName = c.NombreCaracterizacion + " - " + d.Nombre
                         }).ToList(),
         "IDCapa", "FullName", informacionampliaseccion1.CapaDepartamentoId);
            //ViewBag.CapaDepartamentoId = new SelectList(db.CapasDepartamentos, "CapaDepartamentoId", "CapaDepartamentoId", informacionampliaseccion1.CapaDepartamentoId);
            //ViewBag.CapaDepartamentoId = new SelectList(db.Capas, "CapaId", "CapaId", informacionampliaseccion1.CapaDepartamentoId);
            return View(informacionampliaseccion1);
        }

        // POST: /InformacionAmpliaSeccion1/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "InformacionAmpliaSeccion1Id,CapaDepartamentoId,TituloSeccion1,InformacionMapa,NombreMapa")] InformacionAmpliaSeccion1 informacionampliaseccion1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informacionampliaseccion1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CapaDepartamentoId"] =
            new SelectList((from cd in db.CapasDepartamentos
                join c in db.Capas on cd.CapaId equals c.CapaId
                join d in db.Departamento
                on cd.DepartamentoId equals d.DepartamentoId
                select new
                {
                    IDCapa = cd.CapaDepartamentoId,
                    FullName = c.NombreCaracterizacion + " - " + d.Nombre
                }).ToList(),
            "IDCapa", "FullName", informacionampliaseccion1.CapaDepartamentoId);

            //ViewBag.CapaDepartamentoId = new SelectList(db.CapasDepartamentos, "CapaDepartamentoId", "CapaDepartamentoId", informacionampliaseccion1.CapaDepartamentoId);
            return View(informacionampliaseccion1);
        }

        // GET: /InformacionAmpliaSeccion1/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionAmpliaSeccion1 informacionampliaseccion1 = db.InformacionAmpliaSeccion1.Find(id);
            if (informacionampliaseccion1 == null)
            {
                return HttpNotFound();
            }
            return View(informacionampliaseccion1);
        }

        // POST: /InformacionAmpliaSeccion1/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            InformacionAmpliaSeccion1 informacionampliaseccion1 = db.InformacionAmpliaSeccion1.Find(id);
            db.InformacionAmpliaSeccion1.Remove(informacionampliaseccion1);
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

            IEnumerable<InformacionAmpliaSeccion1> filteredCompanies = db.InformacionAmpliaSeccion1;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.InformacionAmpliaSeccion1
                         .Where(c =>
                          c.CapasDepartamentos.Capa.NombreCaracterizacion.Contains(param.sSearch) || c.CapasDepartamentos.Departamento.Nombre.Contains(param.sSearch)
                          || c.TituloSeccion1.Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.InformacionAmpliaSeccion1;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<InformacionAmpliaSeccion1, string> orderingFunction = (c => sortColumnIndex == 1 ? c.CapasDepartamentos.Capa.NombreCaracterizacion :
                                                                sortColumnIndex == 2 ? c.CapasDepartamentos.Departamento.Nombre : c.TituloSeccion1);

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
                .Select(c => new { c.InformacionAmpliaSeccion1Id, c.CapasDepartamentos.Capa.NombreCaracterizacion, c.CapasDepartamentos.Departamento.Nombre, c.TituloSeccion1 });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.InformacionAmpliaSeccion1.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}
