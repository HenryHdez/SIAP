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
    public class FichaOpcionController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /FichaOpcion/
        public ActionResult Index()
        {
            var fichaopcion = db.FichaOpcion.Include(f => f.ListaOpciones);
            return View(fichaopcion.ToList().OrderBy(f=> f.Orden).OrderBy(f=> f.ListaOpcionesId));
        }

        // GET: /FichaOpcion/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaOpcion fichaopcion = db.FichaOpcion.Find(id);
            if (fichaopcion == null)
            {
                return HttpNotFound();
            }
            return View(fichaopcion);
        }

        // GET: /FichaOpcion/Crear
        public ActionResult Crear()
        {
            //SelectList custList = new SelectList(query);
            ViewData["ListaOpcionesId"] =
                new SelectList((from s in db.ListaOpciones
                                             join o in db.OpcionTecnologica
                                             on s.OpcionTecnologicaId equals o.OpcionTecnologicaId
                                             join m in db.Municipio
                                             on s.MunicipioId equals m.MunicipioId
                                             join p in db.TipoPrediccion
                                             on s.TipoPrediccionId equals p.TipoPrediccionId
                                select new
                                {
                                    IDOpcion = s.ListaOpcionesId,
                                    FullName = o.Nombre + " - " + m.Nombre + "-" + p.Nombre
                                }).ToList(),
                "IDOpcion", "FullName");

            //ViewBag.ListaOpcionesId = custList;

           // ViewBag.ListaOpcionesId = new SelectList(db.ListaOpciones, "ListaOpcionesId", "ListaOpcionesId");
         
            return View();
        }

        // POST: /FichaOpcion/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "FichaOpcionId,Titulo, Informacion,ListaOpcionesId,Orden")] FichaOpcion fichaopcion)
        {
            if (ModelState.IsValid)
            {
                db.FichaOpcion.Add(fichaopcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["ListaOpcionesId"] =
            new SelectList((from s in db.ListaOpciones
                    join o in db.OpcionTecnologica
                    on s.OpcionTecnologicaId equals o.OpcionTecnologicaId
                    join m in db.Municipio
                    on s.MunicipioId equals m.MunicipioId
                    join p in db.TipoPrediccion
                    on s.TipoPrediccionId equals p.TipoPrediccionId
                    select new
                    {
                        IDOpcion = s.ListaOpcionesId,
                        FullName = o.Nombre + " - " + m.Nombre + "-" + p.Nombre
                    }).ToList(),
            "IDOpcion", "FullName", fichaopcion.ListaOpcionesId);
            //ViewBag.ListaOpcionesId = new SelectList(db.ListaOpciones, "ListaOpcionesId", "ListaOpcionesId", fichaopcion.ListaOpcionesId);
            return View(fichaopcion);
        }

        // GET: /FichaOpcion/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaOpcion fichaopcion = db.FichaOpcion.Find(id);
            if (fichaopcion == null)
            {
                return HttpNotFound();
            }
            ViewData["ListaOpcionesId"] =
             new SelectList((from s in db.ListaOpciones
                       join o in db.OpcionTecnologica
                       on s.OpcionTecnologicaId equals o.OpcionTecnologicaId
                       join m in db.Municipio
                       on s.MunicipioId equals m.MunicipioId
                       join p in db.TipoPrediccion
                       on s.TipoPrediccionId equals p.TipoPrediccionId
                       select new
                       {
                           IDOpcion = s.ListaOpcionesId,
                           FullName = o.Nombre + " - " + m.Nombre + "-" + p.Nombre
                       }).ToList(),
             "IDOpcion", "FullName", fichaopcion.ListaOpcionesId);
            //ViewBag.ListaOpcionesId = new SelectList(db.ListaOpciones, "ListaOpcionesId", "ListaOpcionesId", fichaopcion.ListaOpcionesId);
            return View(fichaopcion);
        }

        // POST: /FichaOpcion/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include="FichaOpcionId,Titulo,Informacion,ListaOpcionesId,Orden")] FichaOpcion fichaopcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fichaopcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["ListaOpcionesId"] =
             new SelectList((from s in db.ListaOpciones
                       join o in db.OpcionTecnologica
                       on s.OpcionTecnologicaId equals o.OpcionTecnologicaId
                       join m in db.Municipio
                       on s.MunicipioId equals m.MunicipioId
                       join p in db.TipoPrediccion
                       on s.TipoPrediccionId equals p.TipoPrediccionId
                       select new
                       {
                           IDOpcion = s.ListaOpcionesId,
                           FullName = o.Nombre + " - " + m.Nombre + "-" + p.Nombre
                       }).ToList(),
            "IDOpcion", "FullName", fichaopcion.ListaOpcionesId);
            //ViewBag.ListaOpcionesId = new SelectList(db.ListaOpciones, "ListaOpcionesId", "ListaOpcionesId", fichaopcion.ListaOpcionesId);
            return View(fichaopcion);
        }

        // GET: /FichaOpcion/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaOpcion fichaopcion = db.FichaOpcion.Find(id);
            if (fichaopcion == null)
            {
                return HttpNotFound();
            }
            return View(fichaopcion);
        }

        // POST: /FichaOpcion/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            FichaOpcion fichaopcion = db.FichaOpcion.Find(id);
            db.FichaOpcion.Remove(fichaopcion);
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

            IEnumerable<FichaOpcion> filteredCompanies = db.FichaOpcion;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.FichaOpcion
                         .Where(c => c.ListaOpciones.OpcionTecnologica.Nombre.Contains(param.sSearch) || c.ListaOpciones.Municipio.Nombre.Contains(param.sSearch)
                         || c.Titulo.Contains(param.sSearch) || System.Data.Entity.SqlServer.SqlFunctions.StringConvert((double)c.Orden).Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.FichaOpcion;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<FichaOpcion, string> orderingFunction = (c => sortColumnIndex == 1 ? c.ListaOpciones.OpcionTecnologica.Nombre :
                                                                sortColumnIndex == 2 ? c.ListaOpciones.Municipio.Nombre : sortColumnIndex == 3 ? c.Titulo : System.Data.Entity.SqlServer.SqlFunctions.StringConvert((double)c.Orden));


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
                .Select(c => new { c.FichaOpcionId, OpcionTecnologica= c.ListaOpciones.OpcionTecnologica.Nombre, Municipio = c.ListaOpciones.Municipio.Nombre, c.Titulo, c.Orden, OpcionT= c.ListaOpciones.OpcionTecnologica.Nombre });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.FichaOpcion.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}
