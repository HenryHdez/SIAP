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
    public class CultivoController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /Cultivo/
        public ActionResult Index()
        {
            return View(db.Cultivo.ToList());
        }

        // GET: /Cultivo/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cultivo cultivo = db.Cultivo.Find(id);
            if (cultivo == null)
            {
                return HttpNotFound();
            }
            return View(cultivo);
        }

        // GET: /Cultivo/Crear
        public ActionResult Crear()
        {
            ViewBag.GrupoCultivoId = new SelectList(db.GrupoCultivo, "GrupoCultivoId", "Nombre");
            return View();
        }

        // POST: /Cultivo/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "CultivoId,Nombre,Descripcion,TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia, ACFinal,ZrMin,ZrMax,JMin,JMax,RutaIcono,RutaImagen,IndicadorMapa,GrupoCultivoId")] Cultivo cultivo)
        {
            if (ModelState.IsValid)
            {
                db.Cultivo.Add(cultivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrupoCultivoId = new SelectList(db.GrupoCultivo, "GrupoCultivoId", "Nombre", cultivo.GrupoCultivoId);
            return View(cultivo);
        }

        // GET: /Cultivo/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cultivo cultivo = db.Cultivo.Find(id);
            if (cultivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrupoCultivoId = new SelectList(db.GrupoCultivo, "GrupoCultivoId", "Nombre", cultivo.GrupoCultivoId);
            return View(cultivo);
        }

        // POST: /Cultivo/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "CultivoId,Nombre,Descripcion,TiempoInicial,TiempoDesarrollo,TiempoMedia,TiempoFinal,KInicial,KMedia,KFinal,ACInicial,ACMedia, ACFinal,ZrMin,ZrMax,JMin,JMax,RutaIcono,RutaImagen,IndicadorMapa,GrupoCultivoId")] Cultivo cultivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cultivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrupoCultivoId = new SelectList(db.GrupoCultivo, "GrupoCultivoId", "Nombre", cultivo.GrupoCultivoId);
            return View(cultivo);
        }

        // GET: /Cultivo/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cultivo cultivo = db.Cultivo.Find(id);
            if (cultivo == null)
            {
                return HttpNotFound();
            }
            return View(cultivo);
        }

        // POST: /Cultivo/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            Cultivo cultivo = db.Cultivo.Find(id);
            db.Cultivo.Remove(cultivo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<Cultivo> filteredCompanies = db.Cultivo;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.Cultivo
                         .Where(c =>
                          c.Nombre.Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.Cultivo;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Cultivo, string> orderingFunction = (c => c.Nombre );

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
                  .Select(c => new { c.CultivoId, c.Nombre });

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.Cultivo.Count(),
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
