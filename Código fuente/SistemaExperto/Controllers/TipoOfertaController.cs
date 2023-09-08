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
    public class TipoOfertaController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /TipoOferta/
        public ActionResult Index()
        {
            return View(db.TipoOferta.ToList());
        }

        // GET: /TipoOferta/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoOferta tipooferta = db.TipoOferta.Find(id);
            if (tipooferta == null)
            {
                return HttpNotFound();
            }
            return View(tipooferta);
        }

        // GET: /TipoOferta/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: /TipoOferta/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "TipoOfertaId,Nombre")] TipoOferta tipooferta)
        {
            if (ModelState.IsValid)
            {
                db.TipoOferta.Add(tipooferta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipooferta);
        }

        // GET: /TipoOferta/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoOferta tipooferta = db.TipoOferta.Find(id);
            if (tipooferta == null)
            {
                return HttpNotFound();
            }
            return View(tipooferta);
        }

        // POST: /TipoOferta/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="TipoOfertaId,Nombre")] TipoOferta tipooferta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipooferta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipooferta);
        }

        // GET: /TipoOferta/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoOferta tipooferta = db.TipoOferta.Find(id);
            if (tipooferta == null)
            {
                return HttpNotFound();
            }
            return View(tipooferta);
        }

        // POST: /TipoOferta/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            TipoOferta tipooferta = db.TipoOferta.Find(id);
            db.TipoOferta.Remove(tipooferta);
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
