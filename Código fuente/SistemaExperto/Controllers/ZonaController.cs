using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;
using SistemaExperto.Controllers;

namespace SistemaExperto.Controllers
{
    public class ZonaController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /Zona/
        public ActionResult Index(int? codigoMunicipio)
        {
            var zona = db.Zona.Include(z => z.Cultivo).Include(z => z.Municipio);

            if (codigoMunicipio!=null)
            {
                zona = zona.Where(z => z.MunicipioId.Equals(codigoMunicipio));
            }

            return View(zona.ToList());
        }

        // GET: /Zona/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }

            return View(zona);
        }

        public class PuntosPoligono
        {
            public double Latitud { get; set; }
            public double Longitud { get; set; }
        }


        // GET: /Zona/Crear
        public ActionResult Crear()
        {
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre");
            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre");
            ViewBag.TipoSueloId = new SelectList(db.TipoSuelo, "TipoSueloId", "Nombre");
            return View();
        }

        // POST: /Zona/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ZonaId,CultivoId,MunicipioId,Nombre,Latitud,Longitud,Coordenadas,AWCs,AWCu,CC,PMP,TipoSueloId")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                db.Zona.Add(zona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre", zona.CultivoId);
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", zona.MunicipioId);
            ViewBag.TipoSueloId = new SelectList(db.TipoSuelo, "TipoSueloId", "Nombre", zona.TipoSueloId);
            return View(zona);
        }

        // GET: /Zona/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            ViewBag.CultivoId = new SelectList(db.Cultivo.OrderBy(c=>c.Nombre), "CultivoId", "Nombre", zona.CultivoId);
            ViewBag.MunicipioId = new SelectList(db.Municipio.OrderBy(m => m.Nombre), "MunicipioId", "Nombre", zona.MunicipioId);
            ViewBag.TipoSueloId = new SelectList(db.TipoSuelo.OrderBy(m => m.Nombre), "TipoSueloId", "Nombre", zona.TipoSueloId);
            return View(zona);
        }

        // POST: /Zona/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ZonaId,CultivoId,MunicipioId,Nombre,Latitud,Longitud,Coordenadas,AWCs,AWCu,CC,PMP,TasaMax,TipoSueloId")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre", zona.CultivoId);
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", zona.MunicipioId);
            ViewBag.TipoSueloId = new SelectList(db.TipoSuelo, "TipoSueloId", "Nombre", zona.CultivoId);
            return View(zona);
        }

        // GET: /Zona/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            return View(zona);
        }

        // POST: /Zona/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            Zona zona = db.Zona.Find(id);
            db.Zona.Remove(zona);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<Zona> filteredCompanies = db.Zona;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.Zona
                         .Where(c =>
                          c.Nombre.Contains(param.sSearch) || c.Cultivo.Nombre.Contains(param.sSearch) ||
                          c.Municipio.Nombre.Contains(param.sSearch) 
                                     );

            }
            else
            {
                filteredCompanies = db.Zona;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Zona, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Nombre :
                                                                    sortColumnIndex == 2 ? c.Cultivo.Nombre :
                                                                   c.Municipio.Nombre);

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
                  .Select(c => new { c.ZonaId, c.Nombre, Cultivo=c.Cultivo.Nombre, Municipio= c.Municipio.Nombre });

            return Json(new 
            {
                sEcho = param.sEcho,
                iTotalRecords = db.Zona.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
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
