using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;

namespace SE.Controllers
{
    public class SueloProductividadController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: SueloProductividad
        public ActionResult Index()
        {
            var sueloProductividad = db.SueloProductividad.Include(s => s.TipoSuelo);
            return View(sueloProductividad.ToList());
        }

        // GET: SueloProductividad/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SueloProductividad sueloProductividad = db.SueloProductividad.Find(id);
            if (sueloProductividad == null)
            {
                return HttpNotFound();
            }
            return View(sueloProductividad);
        }

        // GET: SueloProductividad/Crear
        public ActionResult Crear()
        {
            ViewBag.TipoSueloId = new SelectList(db.TipoSuelo, "TipoSueloId", "Nombre");
            return View();
        }

        // POST: SueloProductividad/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "SueloProductividadId,CC,CCMenor,CCMayor,PMP,PMPMenor,PMPMayor,Da,DaMenor,DaMayor,TipoSueloId")] SueloProductividad sueloProductividad)
        {
            if (ModelState.IsValid)
            {
                db.SueloProductividad.Add(sueloProductividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoSueloId = new SelectList(db.TipoSuelo, "TipoSueloId", "Nombre", sueloProductividad.TipoSueloId);
            return View(sueloProductividad);
        }

        // GET: SueloProductividad/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SueloProductividad sueloProductividad = db.SueloProductividad.Find(id);
            if (sueloProductividad == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoSueloId = new SelectList(db.TipoSuelo, "TipoSueloId", "Nombre", sueloProductividad.TipoSueloId);
            return View(sueloProductividad);
        }

        // POST: SueloProductividad/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "SueloProductividadId,CC,CCMenor,CCMayor,PMP,PMPMenor,PMPMayor,Da,DaMenor,DaMayor,TipoSueloId")] SueloProductividad sueloProductividad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sueloProductividad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoSueloId = new SelectList(db.TipoSuelo, "TipoSueloId", "Nombre", sueloProductividad.TipoSueloId);
            return View(sueloProductividad);
        }

        // GET: SueloProductividad/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SueloProductividad sueloProductividad = db.SueloProductividad.Find(id);
            if (sueloProductividad == null)
            {
                return HttpNotFound();
            }
            return View(sueloProductividad);
        }

        // POST: SueloProductividad/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            SueloProductividad sueloProductividad = db.SueloProductividad.Find(id);
            db.SueloProductividad.Remove(sueloProductividad);
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
    }
}
