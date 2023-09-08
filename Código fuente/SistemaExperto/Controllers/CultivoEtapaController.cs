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
    public class CultivoEtapaController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /CultivoEtapa/
        public ActionResult Index()
        {
            return View(db.CultivoEtapa.ToList());
        }

        // GET: /CultivoEtapa/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoEtapa cultivoetapa = db.CultivoEtapa.Find(id);
            if (cultivoetapa == null)
            {
                return HttpNotFound();
            }
            return View(cultivoetapa);
        }

        // GET: /CultivoEtapa/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: /CultivoEtapa/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include="CultivoEtapaId,Nombre,Orden,Clase,RutaIcono")] CultivoEtapa cultivoetapa)
        {
            if (ModelState.IsValid)
            {
                db.CultivoEtapa.Add(cultivoetapa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cultivoetapa);
        }

        // GET: /CultivoEtapa/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoEtapa cultivoetapa = db.CultivoEtapa.Find(id);
            if (cultivoetapa == null)
            {
                return HttpNotFound();
            }
            return View(cultivoetapa);
        }

        // POST: /CultivoEtapa/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="CultivoEtapaId,Nombre,Orden,Clase,RutaIcono")] CultivoEtapa cultivoetapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cultivoetapa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cultivoetapa);
        }

        // GET: /CultivoEtapa/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CultivoEtapa cultivoetapa = db.CultivoEtapa.Find(id);
            if (cultivoetapa == null)
            {
                return HttpNotFound();
            }
            return View(cultivoetapa);
        }

        // POST: /CultivoEtapa/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            CultivoEtapa cultivoetapa = db.CultivoEtapa.Find(id);
            db.CultivoEtapa.Remove(cultivoetapa);
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
