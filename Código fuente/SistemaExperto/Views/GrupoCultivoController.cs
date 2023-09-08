using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;

namespace SE.Views
{
    public class GrupoCultivoController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: GrupoCultivo
        public ActionResult Index()
        {
            return View(db.GrupoCultivo.ToList());
        }

        // GET: GrupoCultivo/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoCultivo grupoCultivo = db.GrupoCultivo.Find(id);
            if (grupoCultivo == null)
            {
                return HttpNotFound();
            }
            return View(grupoCultivo);
        }

        // GET: GrupoCultivo/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: GrupoCultivo/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "GrupoCultivoId,Nombre")] GrupoCultivo grupoCultivo)
        {
            if (ModelState.IsValid)
            {
                db.GrupoCultivo.Add(grupoCultivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupoCultivo);
        }

        // GET: GrupoCultivo/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoCultivo grupoCultivo = db.GrupoCultivo.Find(id);
            if (grupoCultivo == null)
            {
                return HttpNotFound();
            }
            return View(grupoCultivo);
        }

        // POST: GrupoCultivo/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "GrupoCultivoId,Nombre")] GrupoCultivo grupoCultivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoCultivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoCultivo);
        }

        // GET: GrupoCultivo/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoCultivo grupoCultivo = db.GrupoCultivo.Find(id);
            if (grupoCultivo == null)
            {
                return HttpNotFound();
            }
            return View(grupoCultivo);
        }

        // POST: GrupoCultivo/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            GrupoCultivo grupoCultivo = db.GrupoCultivo.Find(id);
            db.GrupoCultivo.Remove(grupoCultivo);
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
