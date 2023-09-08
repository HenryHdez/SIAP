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
    public class CultivoTipoEtapaController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /CultivoTipoEtapa/
        public ActionResult Index()
        {
            var cultivotipoetapa = db.CultivoTipoEtapa.Include(c => c.CultivoCiclo).Include(c => c.CultivoEtapa);
            return View(cultivotipoetapa.ToList());
        }

        // GET: /CultivoTipoEtapa/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoTipoEtapa cultivotipoetapa = db.CultivoTipoEtapa.Find(id);
            if (cultivotipoetapa == null)
            {
                return HttpNotFound();
            }
            return View(cultivotipoetapa);
        }

        // GET: /CultivoTipoEtapa/Crear
        public ActionResult Crear()
        {
           // ViewBag.CultivoCicloId = new SelectList(db.CultivoCiclo, "CultivoCicloId", "Nombre");
            ViewData["CultivoCicloId"] =
                new SelectList((from cm in db.CultivoCiclo
                                join c in db.Cultivo on cm.CultivoId equals c.CultivoId
                                join m in db.Municipio
                                on cm.MunicipioId equals m.MunicipioId
                                join co in db.Condicion
                                on cm.CondicionId equals co.CondicionId
                                select new
                                {
                                    ID = cm.CultivoCicloId,
                                    FullName = c.Nombre + " - " + m.Nombre + " - " + cm.Nombre + " - " + co.Nombre
                                }).ToList(),
                "ID", "FullName");
            ViewBag.CultivoEtapaId = new SelectList(db.CultivoEtapa, "CultivoEtapaId", "Nombre");
            return View();
        }

        // POST: /CultivoTipoEtapa/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include="CultivoTipoEtapaId,Duracion,MesInicio,CultivoCicloId,CultivoEtapaId")] CultivoTipoEtapa cultivotipoetapa)
        {
            if (ModelState.IsValid)
            {
                db.CultivoTipoEtapa.Add(cultivotipoetapa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CultivoCicloId = new SelectList(db.CultivoCiclo, "CultivoCicloId", "Nombre", cultivotipoetapa.CultivoCicloId);
            ViewData["CultivoCicloId"] =
             new SelectList((from cm in db.CultivoCiclo
                    join c in db.Cultivo on cm.CultivoId equals c.CultivoId
                    join m in db.Municipio
                    on cm.MunicipioId equals m.MunicipioId
                     join co in db.Condicion
                     on cm.CondicionId equals co.CondicionId
                             select new
                    {
                        ID = cm.CultivoCicloId,
                        FullName = c.Nombre + " - " + m.Nombre + " - " + cm.Nombre + " - " + co.Nombre
                             }).ToList(),
              "ID", "FullName", cultivotipoetapa.CultivoCicloId);

            ViewBag.CultivoEtapaId = new SelectList(db.CultivoEtapa, "CultivoEtapaId", "Nombre", cultivotipoetapa.CultivoEtapaId);
            return View(cultivotipoetapa);
        }

        // GET: /CultivoTipoEtapa/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoTipoEtapa cultivotipoetapa = db.CultivoTipoEtapa.Find(id);
            if (cultivotipoetapa == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CultivoCicloId = new SelectList(db.CultivoCiclo, "CultivoCicloId", "Nombre", cultivotipoetapa.CultivoCicloId);
            ViewData["CultivoCicloId"] =
             new SelectList((from cm in db.CultivoCiclo
                             join c in db.Cultivo on cm.CultivoId equals c.CultivoId
                             join m in db.Municipio
                             on cm.MunicipioId equals m.MunicipioId
                             join co in db.Condicion
                               on cm.CondicionId equals co.CondicionId
                             select new
                             {
                                 ID = cm.CultivoCicloId,
                                 FullName = c.Nombre + " - " + m.Nombre + " - " + cm.Nombre + " - " + co.Nombre
                             }).ToList(),
              "ID", "FullName", cultivotipoetapa.CultivoCicloId);
            ViewBag.CultivoEtapaId = new SelectList(db.CultivoEtapa, "CultivoEtapaId", "Nombre", cultivotipoetapa.CultivoEtapaId);
            return View(cultivotipoetapa);
        }

        // POST: /CultivoTipoEtapa/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="CultivoTipoEtapaId,Duracion,MesInicio,CultivoCicloId,CultivoEtapaId")] CultivoTipoEtapa cultivotipoetapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cultivotipoetapa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CultivoCicloId = new SelectList(db.CultivoCiclo, "CultivoCicloId", "Nombre", cultivotipoetapa.CultivoCicloId);
            ViewData["CultivoCicloId"] =
             new SelectList((from cm in db.CultivoCiclo
                             join c in db.Cultivo on cm.CultivoId equals c.CultivoId
                             join m in db.Municipio
                             on cm.MunicipioId equals m.MunicipioId
                             join co in db.Condicion
                               on cm.CondicionId equals co.CondicionId
                             select new
                             {
                                 ID = cm.CultivoCicloId,
                                 FullName = c.Nombre + " - " + m.Nombre + " - " + cm.Nombre + " - " + co.Nombre
                             }).ToList(),
              "ID", "FullName", cultivotipoetapa.CultivoCicloId);
            ViewBag.CultivoEtapaId = new SelectList(db.CultivoEtapa, "CultivoEtapaId", "Nombre", cultivotipoetapa.CultivoEtapaId);
            return View(cultivotipoetapa);
        }

        // GET: /CultivoTipoEtapa/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoTipoEtapa cultivotipoetapa = db.CultivoTipoEtapa.Find(id);
            if (cultivotipoetapa == null)
            {
                return HttpNotFound();
            }
            return View(cultivotipoetapa);
        }

        // POST: /CultivoTipoEtapa/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            CultivoTipoEtapa cultivotipoetapa = db.CultivoTipoEtapa.Find(id);
            db.CultivoTipoEtapa.Remove(cultivotipoetapa);
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

            IEnumerable<CultivoTipoEtapa> filteredCompanies = db.CultivoTipoEtapa;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.CultivoTipoEtapa
                         .Where(c => c.CultivoCiclo.Nombre.Contains(param.sSearch) || c.CultivoCiclo.Municipio.Nombre.Contains(param.sSearch)
                         || c.CultivoCiclo.Condicion.Nombre.Contains(param.sSearch) || c.CultivoEtapa.Nombre.Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.CultivoTipoEtapa;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<CultivoTipoEtapa, string> orderingFunction = (c => sortColumnIndex == 1 ? c.CultivoCiclo.Nombre :
                                                                sortColumnIndex == 2 ? c.CultivoCiclo.Municipio.Nombre : 
                                                                sortColumnIndex == 3 ? c.CultivoCiclo.Condicion.Nombre : 
                                                                c.CultivoEtapa.Nombre);


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
                .Select(c => new { c.CultivoTipoEtapaId, CultivoCiclo = c.CultivoCiclo.Nombre, Municipio = c.CultivoCiclo.Municipio.Nombre, Condicion=c.CultivoCiclo.Condicion.Nombre, c.CultivoEtapa.Nombre });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.CultivoTipoEtapa.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}
