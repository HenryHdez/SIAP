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
    public class InformacionAmpliaSec2McipioController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /InformacionAmpliaSec2Mcipio/
        public ActionResult Index()
        {
            var informacionampliasec2mcipio = db.InformacionAmpliaSec2Mcipio.Include(i => i.CapasMunicipios);
            return View(informacionampliasec2mcipio.ToList());
        }

        // GET: /InformacionAmpliaSec2Mcipio/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionAmpliaSec2Mcipio informacionampliasec2mcipio = db.InformacionAmpliaSec2Mcipio.Find(id);
            if (informacionampliasec2mcipio == null)
            {
                return HttpNotFound();
            }
            return View(informacionampliasec2mcipio);
        }

        // GET: /InformacionAmpliaSec2Mcipio/Create
        public ActionResult Crear()
        {
            ViewData["CapaMunicipioId"] =
               new SelectList((from cm in db.CapasMunicipios
                               join c in db.Capas on cm.CapaId equals c.CapaId
                               join m in db.Municipio
                               on cm.MunicipioId equals m.MunicipioId
                               select new
                               {
                                   IDCapa = cm.CapaMunicipioId,
                                   FullName = c.NombreCaracterizacion + " - " + m.Nombre
                               }).ToList(),
               "IDCapa", "FullName");
            //ViewBag.CapaMunicipioId = new SelectList(db.CapasMunicipios, "CapaMunicipioId", "CapaMunicipioId");
            return View();
        }

        // POST: /InformacionAmpliaSec2Mcipio/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include="InformacionAmpliaSec2McipioId,CapaMunicipioId,NombreCortoSeccion2,TituloSeccion2Mcipio,Descripcion")] InformacionAmpliaSec2Mcipio informacionampliasec2mcipio)
        {
            if (ModelState.IsValid)
            {
                db.InformacionAmpliaSec2Mcipio.Add(informacionampliasec2mcipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CapaMunicipioId"] =
               new SelectList((from cm in db.CapasMunicipios
                               join c in db.Capas on cm.CapaId equals c.CapaId
                               join m in db.Municipio
                               on cm.MunicipioId equals m.MunicipioId
                               select new
                               {
                                   IDCapa = cm.CapaMunicipioId,
                                   FullName = c.NombreCaracterizacion + " - " + m.Nombre
                               }).ToList(),
               "IDCapa", "FullName", informacionampliasec2mcipio.CapaMunicipioId);
            //ViewBag.CapaMunicipioId = new SelectList(db.CapasMunicipios, "CapaMunicipioId", "CapaMunicipioId", informacionampliasec2mcipio.CapaMunicipioId);
            return View(informacionampliasec2mcipio);
        }

        // GET: /InformacionAmpliaSec2Mcipio/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionAmpliaSec2Mcipio informacionampliasec2mcipio = db.InformacionAmpliaSec2Mcipio.Find(id);
            if (informacionampliasec2mcipio == null)
            {
                return HttpNotFound();
            }

            ViewData["CapaMunicipioId"] =
               new SelectList((from cm in db.CapasMunicipios
                               join c in db.Capas on cm.CapaId equals c.CapaId
                               join m in db.Municipio
                               on cm.MunicipioId equals m.MunicipioId
                               select new
                               {
                                   IDCapa = cm.CapaMunicipioId,
                                   FullName = c.NombreCaracterizacion + " - " + m.Nombre
                               }).ToList(),
               "IDCapa", "FullName", informacionampliasec2mcipio.CapaMunicipioId);
            //ViewBag.CapaMunicipioId = new SelectList(db.CapasMunicipios, "CapaMunicipioId", "CapaMunicipioId", informacionampliasec2mcipio.CapaMunicipioId);
            return View(informacionampliasec2mcipio);
        }

        // POST: /InformacionAmpliaSec2Mcipio/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="InformacionAmpliaSec2McipioId,CapaMunicipioId,NombreCortoSeccion2,TituloSeccion2Mcipio,Descripcion")] InformacionAmpliaSec2Mcipio informacionampliasec2mcipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informacionampliasec2mcipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CapaMunicipioId"] =
              new SelectList((from cm in db.CapasMunicipios
                              join c in db.Capas on cm.CapaId equals c.CapaId
                              join m in db.Municipio
                              on cm.MunicipioId equals m.MunicipioId
                              select new
                              {
                                  IDCapa = cm.CapaMunicipioId,
                                  FullName = c.NombreCaracterizacion + " - " + m.Nombre
                              }).ToList(),
              "IDCapa", "FullName", informacionampliasec2mcipio.CapaMunicipioId);
            //ViewBag.CapaMunicipioId = new SelectList(db.CapasMunicipios, "CapaMunicipioId", "CapaMunicipioId", informacionampliasec2mcipio.CapaMunicipioId);
            return View(informacionampliasec2mcipio);
        }

        // GET: /InformacionAmpliaSec2Mcipio/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionAmpliaSec2Mcipio informacionampliasec2mcipio = db.InformacionAmpliaSec2Mcipio.Find(id);
            if (informacionampliasec2mcipio == null)
            {
                return HttpNotFound();
            }
            return View(informacionampliasec2mcipio);
        }

        // POST: /InformacionAmpliaSec2Mcipio/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            InformacionAmpliaSec2Mcipio informacionampliasec2mcipio = db.InformacionAmpliaSec2Mcipio.Find(id);
            db.InformacionAmpliaSec2Mcipio.Remove(informacionampliasec2mcipio);
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
