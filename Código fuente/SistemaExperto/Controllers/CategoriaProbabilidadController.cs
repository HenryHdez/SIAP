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
    public class CategoriaProbabilidadController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /CategoriaProbabilidad/
        public ActionResult Index()
        {
            return View(db.CategoriaProbabilidad.ToList());
        }

        // GET: /CategoriaProbabilidad/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProbabilidad categoriaprobabilidad = db.CategoriaProbabilidad.Find(id);
            if (categoriaprobabilidad == null)
            {
                return HttpNotFound();
            }
            return View(categoriaprobabilidad);
        }

        // GET: /CategoriaProbabilidad/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: /CategoriaProbabilidad/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "CategoriaProbabilidadId,Descripcion")] CategoriaProbabilidad categoriaprobabilidad)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaProbabilidad.Add(categoriaprobabilidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaprobabilidad);
        }

        // GET: /CategoriaProbabilidad/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProbabilidad categoriaprobabilidad = db.CategoriaProbabilidad.Find(id);
            if (categoriaprobabilidad == null)
            {
                return HttpNotFound();
            }
            return View(categoriaprobabilidad);
        }

        // POST: /CategoriaProbabilidad/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="CategoriaProbabilidadId,Descripcion")] CategoriaProbabilidad categoriaprobabilidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaprobabilidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaprobabilidad);
        }

        // GET: /CategoriaProbabilidad/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProbabilidad categoriaprobabilidad = db.CategoriaProbabilidad.Find(id);
            if (categoriaprobabilidad == null)
            {
                return HttpNotFound();
            }
            return View(categoriaprobabilidad);
        }

        // POST: /CategoriaProbabilidad/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            CategoriaProbabilidad categoriaprobabilidad = db.CategoriaProbabilidad.Find(id);
            db.CategoriaProbabilidad.Remove(categoriaprobabilidad);
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
