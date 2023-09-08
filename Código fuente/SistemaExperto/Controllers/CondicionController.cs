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
    public class CondicionController : Controller
    {
        private SEEntities db = new SEEntities();
        //
        // GET: /Condicion/
        public ActionResult Index()
        {
            return View(db.Condicion.ToList());
        }

        //
        // GET: /Condicion/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion condicion = db.Condicion.Find(id);
            if (condicion == null)
            {
                return HttpNotFound();
            }
            return View(condicion);
        }

        //
        // GET: /Condicion/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: EstacionTipoConstantes/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "CondicionId,Nombre,Descripcion")] Condicion condicion)
        {
            if (ModelState.IsValid)
            {
                db.Condicion.Add(condicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condicion);
        }


        // GET: Condicion/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion condicion = db.Condicion.Find(id);
            if (condicion == null)
            {
                return HttpNotFound();
            }
            return View(condicion);
        }

        // POST: Condicion/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "CondicionId,Nombre,Descripcion")] Condicion condicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condicion);
        }


        // GET: Condicion/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion condicion = db.Condicion.Find(id);
            if (condicion == null)
            {
                return HttpNotFound();
            }
            return View(condicion);
        }

        // POST: condicion/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            Condicion condicion = db.Condicion.Find(id);
            db.Condicion.Remove(condicion);
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
