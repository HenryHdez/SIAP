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
    public class InformacionAmpliaSeccion2Controller : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /InformacionAmpliaSeccion2/
        public ActionResult Index()
        {
            var informacionampliaseccion2 = db.InformacionAmpliaSeccion2.Include(i => i.CapasDepartamentos);
            return View(informacionampliaseccion2.ToList());
        }

        // GET: /InformacionAmpliaSeccion2/Details/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionAmpliaSeccion2 informacionampliaseccion2 = db.InformacionAmpliaSeccion2.Find(id);
            if (informacionampliaseccion2 == null)
            {
                return HttpNotFound();
            }
            return View(informacionampliaseccion2);
        }

        // GET: /InformacionAmpliaSeccion2/Crear
        public ActionResult Crear()
        {
            ViewData["CapaDepartamentoId"] =
             new SelectList((from cd in db.CapasDepartamentos
                    join c in db.Capas on cd.CapaId equals c.CapaId
                    join d in db.Departamento
                    on cd.DepartamentoId equals d.DepartamentoId
                    select new
                    {
                        IDCapa = cd.CapaDepartamentoId,
                        FullName = c.NombreCaracterizacion + " - " + d.Nombre
                    }).ToList(),
               "IDCapa", "FullName");

            //ViewBag.CapaDepartamentoId = new SelectList(db.CapasDepartamentos, "CapaDepartamentoId", "CapaDepartamentoId");
            return View();
        }

        // POST: /InformacionAmpliaSeccion2/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "InformacionAmpliaSeccion2Id,CapaDepartamentoId,NombreCortoSeccion2,TituloSeccion2,Icono,Descripcion")] InformacionAmpliaSeccion2 informacionampliaseccion2)
        {
            if (ModelState.IsValid)
            {
                db.InformacionAmpliaSeccion2.Add(informacionampliaseccion2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CapaDepartamentoId"] =
           new SelectList((from cd in db.CapasDepartamentos
                           join c in db.Capas on cd.CapaId equals c.CapaId
                           join d in db.Departamento
                           on cd.DepartamentoId equals d.DepartamentoId
                           select new
                           {
                               IDCapa = cd.CapaDepartamentoId,
                               FullName = c.NombreCaracterizacion + " - " + d.Nombre
                           }).ToList(),
           "IDCapa", "FullName", informacionampliaseccion2.CapaDepartamentoId);
            //ViewBag.CapaDepartamentoId = new SelectList(db.CapasDepartamentos, "CapaDepartamentoId", "CapaDepartamentoId", informacionampliaseccion2.CapaDepartamentoId);
            return View(informacionampliaseccion2);
        }

        // GET: /InformacionAmpliaSeccion2/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionAmpliaSeccion2 informacionampliaseccion2 = db.InformacionAmpliaSeccion2.Find(id);
            if (informacionampliaseccion2 == null)
            {
                return HttpNotFound();
            }
            ViewData["CapaDepartamentoId"] =
            new SelectList((from cd in db.CapasDepartamentos
                join c in db.Capas on cd.CapaId equals c.CapaId
                join d in db.Departamento
                on cd.DepartamentoId equals d.DepartamentoId
                select new
                {
                    IDCapa = cd.CapaDepartamentoId,
                    FullName = c.NombreCaracterizacion + " - " + d.Nombre
                }).ToList(),
            "IDCapa", "FullName", informacionampliaseccion2.CapaDepartamentoId);

            //ViewBag.CapaDepartamentoId = new SelectList(db.CapasDepartamentos, "CapaDepartamentoId", "CapaDepartamentoId", informacionampliaseccion2.CapaDepartamentoId);
            return View(informacionampliaseccion2);
        }

        // POST: /InformacionAmpliaSeccion2/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="InformacionAmpliaSeccion2Id,CapaDepartamentoId,NombreCortoSeccion2,TituloSeccion2,Icono,Descripcion")] InformacionAmpliaSeccion2 informacionampliaseccion2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informacionampliaseccion2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CapaDepartamentoId"] =
            new SelectList((from cd in db.CapasDepartamentos
                join c in db.Capas on cd.CapaId equals c.CapaId
                join d in db.Departamento
                on cd.DepartamentoId equals d.DepartamentoId
                select new
                {
                    IDCapa = cd.CapaDepartamentoId,
                    FullName = c.NombreCaracterizacion + " - " + d.Nombre
                }).ToList(),
            "IDCapa", "FullName", informacionampliaseccion2.CapaDepartamentoId);

            //ViewBag.CapaDepartamentoId = new SelectList(db.CapasDepartamentos, "CapaDepartamentoId", "CapaDepartamentoId", informacionampliaseccion2.CapaDepartamentoId);
            return View(informacionampliaseccion2);
        }

        // GET: /InformacionAmpliaSeccion2/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionAmpliaSeccion2 informacionampliaseccion2 = db.InformacionAmpliaSeccion2.Find(id);
            if (informacionampliaseccion2 == null)
            {
                return HttpNotFound();
            }
            return View(informacionampliaseccion2);
        }

        // POST: /InformacionAmpliaSeccion2/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            InformacionAmpliaSeccion2 informacionampliaseccion2 = db.InformacionAmpliaSeccion2.Find(id);
            db.InformacionAmpliaSeccion2.Remove(informacionampliaseccion2);
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
