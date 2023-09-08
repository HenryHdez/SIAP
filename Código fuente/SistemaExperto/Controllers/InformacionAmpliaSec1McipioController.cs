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
    public class InformacionAmpliaSec1McipioController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /InformacionAmpliaSec1Mcipio/
        public ActionResult Index()
        {
            var informacionampliasec1mcipio = db.InformacionAmpliaSec1Mcipio.Include(i => i.CapasMunicipios);
            return View(informacionampliasec1mcipio.ToList());
        }

        // GET: /InformacionAmpliaSec1Mcipio/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionAmpliaSec1Mcipio informacionampliasec1mcipio = db.InformacionAmpliaSec1Mcipio.Find(id);
            if (informacionampliasec1mcipio == null)
            {
                return HttpNotFound();
            }
            return View(informacionampliasec1mcipio);
        }

        // GET: /InformacionAmpliaSec1Mcipio/Crear
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

          //  ViewBag.CapaMunicipioId = new SelectList(db.CapasMunicipios, "CapaMunicipioId", "CapaMunicipioId");
            return View();
        }

        // POST: /InformacionAmpliaSec1Mcipio/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "InformacionAmpliaSec1McipioId,CapaMunicipioId,TituloSeccion1Mcipio,InformacionMapa,NombreMapa")] InformacionAmpliaSec1Mcipio informacionampliasec1mcipio)
        {
            if (ModelState.IsValid)
            {
                db.InformacionAmpliaSec1Mcipio.Add(informacionampliasec1mcipio);
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
               "IDCapa", "FullName", informacionampliasec1mcipio.CapaMunicipioId);

            //ViewBag.CapaMunicipioId = new SelectList(db.CapasMunicipios, "CapaMunicipioId", "CapaMunicipioId", informacionampliasec1mcipio.CapaMunicipioId);
            return View(informacionampliasec1mcipio);
        }

        // GET: /InformacionAmpliaSec1Mcipio/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionAmpliaSec1Mcipio informacionampliasec1mcipio = db.InformacionAmpliaSec1Mcipio.Find(id);
            if (informacionampliasec1mcipio == null)
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
                "IDCapa", "FullName", informacionampliasec1mcipio.CapaMunicipioId);
            //ViewBag.CapaMunicipioId = new SelectList(db.CapasMunicipios, "CapaMunicipioId", "CapaMunicipioId", informacionampliasec1mcipio.CapaMunicipioId);
            return View(informacionampliasec1mcipio);
        }

        // POST: /InformacionAmpliaSec1Mcipio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="InformacionAmpliaSec1McipioId,CapaMunicipioId,TituloSeccion1Mcipio,InformacionMapa,NombreMapa")] InformacionAmpliaSec1Mcipio informacionampliasec1mcipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informacionampliasec1mcipio).State = EntityState.Modified;
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
               "IDCapa", "FullName", informacionampliasec1mcipio.CapaMunicipioId);
            //ViewBag.CapaMunicipioId = new SelectList(db.CapasMunicipios, "CapaMunicipioId", "CapaMunicipioId", informacionampliasec1mcipio.CapaMunicipioId);
            return View(informacionampliasec1mcipio);
        }

        // GET: /InformacionAmpliaSec1Mcipio/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionAmpliaSec1Mcipio informacionampliasec1mcipio = db.InformacionAmpliaSec1Mcipio.Find(id);
            if (informacionampliasec1mcipio == null)
            {
                return HttpNotFound();
            }
            return View(informacionampliasec1mcipio);
        }

        // POST: /InformacionAmpliaSec1Mcipio/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            InformacionAmpliaSec1Mcipio informacionampliasec1mcipio = db.InformacionAmpliaSec1Mcipio.Find(id);
            db.InformacionAmpliaSec1Mcipio.Remove(informacionampliasec1mcipio);
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
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<InformacionAmpliaSec1Mcipio> filteredCompanies = db.InformacionAmpliaSec1Mcipio;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.InformacionAmpliaSec1Mcipio
                         .Where(c =>
                          c.CapasMunicipios.Capa.NombreCaracterizacion.Contains(param.sSearch) || c.CapasMunicipios.Municipio.Nombre.Contains(param.sSearch)
                          || c.TituloSeccion1Mcipio.Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.InformacionAmpliaSec1Mcipio;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<InformacionAmpliaSec1Mcipio, string> orderingFunction = (c => sortColumnIndex == 1 ? c.CapasMunicipios.Capa.NombreCaracterizacion :
                                                                sortColumnIndex == 2 ? c.CapasMunicipios.Municipio.Nombre : c.TituloSeccion1Mcipio);

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredCompanies = filteredCompanies.OrderBy(orderingFunction);
            else
                filteredCompanies = filteredCompanies.OrderByDescending(orderingFunction);
            // fin para orden
            var displayedCompanies = filteredCompanies
                        .Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);


            var result = displayedCompanies
                .Select(c => new { c.InformacionAmpliaSec1McipioId, c.CapasMunicipios.Capa.NombreCaracterizacion, c.CapasMunicipios.Municipio.Nombre, c.TituloSeccion1Mcipio });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.InformacionAmpliaSec1Mcipio.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}
