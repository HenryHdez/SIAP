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
    public class CapasMunicipiosController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /CapasMunicipios/
        public ActionResult Index()
        {
            var capasmunicipios = db.CapasMunicipios.Include(c => c.Capa).Include(c => c.Municipio);
            return View(capasmunicipios.ToList());
        }

        // GET: /CapasMunicipios/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapasMunicipios capasmunicipios = db.CapasMunicipios.Find(id);
            if (capasmunicipios == null)
            {
                return HttpNotFound();
            }
            return View(capasmunicipios);
        }

        // GET: /CapasMunicipios/Crear
        public ActionResult Crear()
        {
            ViewBag.CapaId = new SelectList(db.Capas, "CapaId", "NombreCaracterizacion");
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre");
            return View();
        }

        // POST: /CapasMunicipios/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "CapaMunicipioId,CapaId,MunicipioId,ExplicacionMapa,Visible")] CapasMunicipios capasmunicipios)
        {
            if (ModelState.IsValid)
            {
                db.CapasMunicipios.Add(capasmunicipios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CapaId = new SelectList(db.Capas, "CapaId", "NombreCaracterizacion", capasmunicipios.CapaId);
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", capasmunicipios.MunicipioId);
            return View(capasmunicipios);
        }

        // GET: /CapasMunicipios/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapasMunicipios capasmunicipios = db.CapasMunicipios.Find(id);
            if (capasmunicipios == null)
            {
                return HttpNotFound();
            }
            ViewBag.CapaId = new SelectList(db.Capas, "CapaId", "NombreCaracterizacion", capasmunicipios.CapaId);
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", capasmunicipios.MunicipioId);
            return View(capasmunicipios);
        }

        // POST: /CapasMunicipios/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include= "CapaMunicipioId,CapaId,MunicipioId,ExplicacionMapa,Visible")] CapasMunicipios capasmunicipios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(capasmunicipios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CapaId = new SelectList(db.Capas, "CapaId", "NombreCaracterizacion", capasmunicipios.CapaId);
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", capasmunicipios.MunicipioId);
            return View(capasmunicipios);
        }

        // GET: /CapasMunicipios/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapasMunicipios capasmunicipios = db.CapasMunicipios.Find(id);
            if (capasmunicipios == null)
            {
                return HttpNotFound();
            }
            return View(capasmunicipios);
        }

        // POST: /CapasMunicipios/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            CapasMunicipios capasmunicipios = db.CapasMunicipios.Find(id);
            db.CapasMunicipios.Remove(capasmunicipios);
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

            IEnumerable<CapasMunicipios> filteredCompanies = db.CapasMunicipios;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.CapasMunicipios
                         .Where(c =>
                          c.Capa.NombreCaracterizacion.Contains(param.sSearch) || c.Municipio.Nombre.Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.CapasMunicipios;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<CapasMunicipios, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Capa.NombreCaracterizacion :
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
                .Select(c => new { c.CapaMunicipioId, c.Capa.NombreCaracterizacion, c.Municipio.Nombre });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.CapasMunicipios.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}
