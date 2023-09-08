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
    public class TipoPrediccionesController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: TipoPredicciones
        public ActionResult Index()
        {
            return View(db.TipoPrediccion.ToList());
        }

        // GET: TipoPredicciones/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPrediccion tipoPrediccion = db.TipoPrediccion.Find(id);
            if (tipoPrediccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoPrediccion);
        }

        // GET: TipoPredicciones/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: TipoPredicciones/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "TipoPrediccionId,Nombre,Maximo,Minimo")] TipoPrediccion tipoPrediccion)
        {
            if (ModelState.IsValid)
            {
                db.TipoPrediccion.Add(tipoPrediccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPrediccion);
        }

        // GET: TipoPredicciones/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPrediccion tipoPrediccion = db.TipoPrediccion.Find(id);
            if (tipoPrediccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoPrediccion);
        }

        // POST: TipoPredicciones/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "TipoPrediccionId,Nombre,Maximo,Minimo")] TipoPrediccion tipoPrediccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPrediccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPrediccion);
        }

        // GET: TipoPredicciones/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPrediccion tipoPrediccion = db.TipoPrediccion.Find(id);
            if (tipoPrediccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoPrediccion);
        }

        // POST: TipoPredicciones/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            TipoPrediccion tipoPrediccion = db.TipoPrediccion.Find(id);
            db.TipoPrediccion.Remove(tipoPrediccion);
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
