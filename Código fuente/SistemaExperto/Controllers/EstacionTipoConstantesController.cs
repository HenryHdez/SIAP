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
    public class EstacionTipoConstantesController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: EstacionTipoConstantes
        public ActionResult Index()
        {
            return View(db.EstacionTipoConstante.ToList());
        }

        // GET: EstacionTipoConstantes/Details/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionTipoConstante estacionTipoConstante = db.EstacionTipoConstante.Find(id);
            if (estacionTipoConstante == null)
            {
                return HttpNotFound();
            }
            return View(estacionTipoConstante);
        }

        // GET: EstacionTipoConstantes/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: EstacionTipoConstantes/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "EstacionTipoConstanteId,Nombre,Etiqueta")] EstacionTipoConstante estacionTipoConstante)
        {
            if (ModelState.IsValid)
            {
                db.EstacionTipoConstante.Add(estacionTipoConstante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estacionTipoConstante);
        }

        // GET: EstacionTipoConstantes/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionTipoConstante estacionTipoConstante = db.EstacionTipoConstante.Find(id);
            if (estacionTipoConstante == null)
            {
                return HttpNotFound();
            }
            return View(estacionTipoConstante);
        }

        // POST: EstacionTipoConstantes/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "EstacionTipoConstanteId,Nombre,Etiqueta")] EstacionTipoConstante estacionTipoConstante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estacionTipoConstante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estacionTipoConstante);
        }

        // GET: EstacionTipoConstantes/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionTipoConstante estacionTipoConstante = db.EstacionTipoConstante.Find(id);
            if (estacionTipoConstante == null)
            {
                return HttpNotFound();
            }
            return View(estacionTipoConstante);
        }

        // POST: EstacionTipoConstantes/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            EstacionTipoConstante estacionTipoConstante = db.EstacionTipoConstante.Find(id);
            db.EstacionTipoConstante.Remove(estacionTipoConstante);
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
