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
    public class ListaOpcionesController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /ListaOpciones/
        public ActionResult Index()
        {
            var listaopciones = db.ListaOpciones.Include(l => l.Cultivo).Include(l => l.Municipio).Include(l => l.OpcionTecnologica).Include(l => l.TipoOferta).Include(l => l.TipoPrediccion);
            return View(listaopciones.ToList());
        }

        // GET: /ListaOpciones/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaOpciones listaopciones = db.ListaOpciones.Find(id);
            if (listaopciones == null)
            {
                return HttpNotFound();
            }
            return View(listaopciones);
        }

        // GET: /ListaOpciones/Crear
        public ActionResult Crear()
        {
            //ViewBags de listas de selección
            ViewBag.CultivoId = new SelectList(db.Cultivo.OrderBy(c => c.Nombre), "CultivoId", "Nombre");
            ViewBag.MunicipioId = new SelectList(from m in db.Municipio.OrderBy(mu => mu.Nombre)
                                                 select new
                                                 {
                                                     MunicipioId = m.MunicipioId,
                                                     NombreMunicipio = m.Nombre + " (" + m.Departamento.Nombre + ")"
                                                 }, "MunicipioId", "NombreMunicipio");
            ViewBag.OpcionTecnologicaId = new SelectList(db.OpcionTecnologica.OrderBy(ot => ot.Nombre), "OpcionTecnologicaId", "Nombre");
            ViewBag.TipoOfertaId = new SelectList(db.TipoOferta.OrderBy(to => to.Nombre), "TipoOfertaId", "Nombre");
            ViewBag.TipoPrediccionId = new SelectList(db.TipoPrediccion.OrderBy(tp => tp.Nombre), "TipoPrediccionId", "Nombre");

            return View();
        }

        // POST: /ListaOpciones/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include="ListaOpcionesId,CultivoId,MunicipioId,TipoOfertaId,TipoPrediccionId,OpcionTecnologicaId,EstadoDesarrolloCultivo,IndicadorLocal")] ListaOpciones listaopciones)
        {
            if (ModelState.IsValid)
            {
                db.ListaOpciones.Add(listaopciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBags de listas de selección
            ViewBag.CultivoId = new SelectList(db.Cultivo.OrderBy(c => c.Nombre), "CultivoId", "Nombre", listaopciones.CultivoId);
            ViewBag.MunicipioId = new SelectList(from m in db.Municipio.OrderBy(mu => mu.Nombre)
                                                 select new
                                                 {
                                                     MunicipioId = m.MunicipioId,
                                                     NombreMunicipio = m.Nombre + " (" + m.Departamento.Nombre + ")"
                                                 }, "MunicipioId", "NombreMunicipio", listaopciones.MunicipioId);
            ViewBag.OpcionTecnologicaId = new SelectList(db.OpcionTecnologica.OrderBy(o => o.Nombre), "OpcionTecnologicaId", "Nombre", listaopciones.OpcionTecnologicaId);
            ViewBag.TipoOfertaId = new SelectList(db.TipoOferta.OrderBy(to => to.Nombre), "TipoOfertaId", "Nombre", listaopciones.TipoOfertaId);
            ViewBag.TipoPrediccionId = new SelectList(db.TipoPrediccion.OrderBy(tp => tp.Nombre), "TipoPrediccionId", "Nombre", listaopciones.TipoPrediccionId);

            return View(listaopciones);
        }

        // GET: /ListaOpciones/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaOpciones listaopciones = db.ListaOpciones.Find(id);
            if (listaopciones == null)
            {
                return HttpNotFound();
            }

            //ViewBags de listas de selección
            ViewBag.CultivoId = new SelectList(db.Cultivo.OrderBy(c => c.Nombre), "CultivoId", "Nombre", listaopciones.CultivoId);
            ViewBag.MunicipioId = new SelectList(from m in db.Municipio.OrderBy(mu => mu.Nombre)
                                                 select new
                                                 {
                                                     MunicipioId = m.MunicipioId,
                                                     NombreMunicipio = m.Nombre + " (" + m.Departamento.Nombre + ")"
                                                 }, "MunicipioId", "NombreMunicipio", listaopciones.MunicipioId);
            ViewBag.OpcionTecnologicaId = new SelectList(db.OpcionTecnologica.OrderBy(o => o.Nombre), "OpcionTecnologicaId", "Nombre", listaopciones.OpcionTecnologicaId);
            ViewBag.TipoOfertaId = new SelectList(db.TipoOferta.OrderBy(to => to.Nombre), "TipoOfertaId", "Nombre", listaopciones.TipoOfertaId);
            ViewBag.TipoPrediccionId = new SelectList(db.TipoPrediccion.OrderBy(tp => tp.Nombre), "TipoPrediccionId", "Nombre", listaopciones.TipoPrediccionId);

            return View(listaopciones);
        }

        // POST: /ListaOpciones/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="ListaOpcionesId,CultivoId,MunicipioId,TipoOfertaId,TipoPrediccionId,OpcionTecnologicaId,EstadoDesarrolloCultivo,IndicadorLocal")] ListaOpciones listaopciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaopciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBags de listas de selección
            ViewBag.CultivoId = new SelectList(db.Cultivo.OrderBy(c => c.Nombre), "CultivoId", "Nombre", listaopciones.CultivoId);
            ViewBag.MunicipioId = new SelectList(from m in db.Municipio.OrderBy(mu => mu.Nombre)
                                                 select new
                                                 {
                                                     MunicipioId = m.MunicipioId,
                                                     NombreMunicipio = m.Nombre + " (" + m.Departamento.Nombre + ")"
                                                 }, "MunicipioId", "NombreMunicipio", listaopciones.MunicipioId);
            ViewBag.OpcionTecnologicaId = new SelectList(db.OpcionTecnologica.OrderBy(o => o.Nombre), "OpcionTecnologicaId", "Nombre", listaopciones.OpcionTecnologicaId);
            ViewBag.TipoOfertaId = new SelectList(db.TipoOferta.OrderBy(to => to.Nombre), "TipoOfertaId", "Nombre", listaopciones.TipoOfertaId);
            ViewBag.TipoPrediccionId = new SelectList(db.TipoPrediccion.OrderBy(tp => tp.Nombre), "TipoPrediccionId", "Nombre", listaopciones.TipoPrediccionId);

            return View(listaopciones);
        }

        // GET: /ListaOpciones/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaOpciones listaopciones = db.ListaOpciones.Find(id);
            if (listaopciones == null)
            {
                return HttpNotFound();
            }
            return View(listaopciones);
        }

        // POST: /ListaOpciones/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            ListaOpciones listaopciones = db.ListaOpciones.Find(id);
            db.ListaOpciones.Remove(listaopciones);
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

            IEnumerable<ListaOpciones> filteredCompanies = db.ListaOpciones;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.ListaOpciones
                         .Where(c => c.Municipio.Nombre.Contains(param.sSearch) || c.OpcionTecnologica.Nombre.Contains(param.sSearch)
                         || c.TipoPrediccion.Nombre.Contains(param.sSearch)
                                     );
            }
            else
            {
                filteredCompanies = db.ListaOpciones;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<ListaOpciones, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Municipio.Nombre :
                                                                sortColumnIndex == 2 ? c.OpcionTecnologica.Nombre : c.TipoPrediccion.Nombre);

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
                .Select(c => new { c.ListaOpcionesId, Municipio = c.Municipio.Nombre, OpcionTecnologica = c.OpcionTecnologica.Nombre, TipoPrediccion = c.TipoPrediccion.Nombre, c.IndicadorLocal });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.ListaOpciones.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }
    }
}
