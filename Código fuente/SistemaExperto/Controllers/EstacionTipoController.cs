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
    public class EstacionTipoController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /EstacionTipo/
        public ActionResult Index()
        {
            return View(db.EstacionTipo.ToList());
        }

        // GET: /EstacionTipo/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionTipo estaciontipo = db.EstacionTipo.Find(id);
            if (estaciontipo == null)
            {
                return HttpNotFound();
            }
            return View(estaciontipo);
        }

        // GET: /EstacionTipo/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: /EstacionTipo/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "EstacionTipoId,Tipo,Radio")] EstacionTipo estaciontipo)
        {
            if (ModelState.IsValid)
            {
                db.EstacionTipo.Add(estaciontipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estaciontipo);
        }

        // GET: /EstacionTipo/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionTipo estaciontipo = db.EstacionTipo.Find(id);
            if (estaciontipo == null)
            {
                return HttpNotFound();
            }
            return View(estaciontipo);
        }

        // POST: /EstacionTipo/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="EstacionTipoId,Tipo,Radio")] EstacionTipo estaciontipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estaciontipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estaciontipo);
        }

        // GET: /EstacionTipo/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionTipo estaciontipo = db.EstacionTipo.Find(id);
            if (estaciontipo == null)
            {
                return HttpNotFound();
            }
            return View(estaciontipo);
        }

        // POST: /EstacionTipo/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            EstacionTipo estaciontipo = db.EstacionTipo.Find(id);
            db.EstacionTipo.Remove(estaciontipo);
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
