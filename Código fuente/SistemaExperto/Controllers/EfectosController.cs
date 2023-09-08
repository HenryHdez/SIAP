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
    public class EfectosController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: Efectos
        public ActionResult Index()
        {
            return View(db.Efectos.ToList());
        }

        // GET: Efectos/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Efectos efectos = db.Efectos.Find(id);
            if (efectos == null)
            {
                return HttpNotFound();
            }
            return View(efectos);
        }

        // GET: Efectos/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Efectos/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "EfectoId,Nombre")] Efectos efectos)
        {
            if (ModelState.IsValid)
            {
                db.Efectos.Add(efectos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(efectos);
        }

        // GET: Efectos/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Efectos efectos = db.Efectos.Find(id);
            if (efectos == null)
            {
                return HttpNotFound();
            }
            return View(efectos);
        }

        // POST: Efectos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "EfectoId,Nombre")] Efectos efectos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(efectos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(efectos);
        }

        // GET: Efectos/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Efectos efectos = db.Efectos.Find(id);
            if (efectos == null)
            {
                return HttpNotFound();
            }
            return View(efectos);
        }

        // POST: Efectos/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            Efectos efectos = db.Efectos.Find(id);
            db.Efectos.Remove(efectos);
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

        public ActionResult CargarDatosTabla(jQueryDataTableParamModel param)
        {
            //Lista de registros de la tabla
            IEnumerable<Efectos> filtroEfectos = db.Efectos;

            //Búsqueda según el filtro digitado
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filtroEfectos = db.Efectos
                         .Where(
                         c => c.Nombre.Contains(param.sSearch)
                         );
            }
            else
            {
                filtroEfectos = db.Efectos;
            }

            //Ordenamiento de columna
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<EstacionMensual, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Estacion.Nombre :
                                                                sortColumnIndex == 2 ? Convert.ToString(c.Tmin) :
                                                                 Convert.ToString(c.Tmax));
            var sortDirection = Request["sSortDir_0"];

            //Paginación de la tabla
            var displayedCompanies = filtroEfectos
                        .Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            //Consulta a mostrar
            var result = displayedCompanies
                .Select(c => new { c.EfectoId, c.Nombre });

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.Efectos.Count(),
                iTotalDisplayRecords = filtroEfectos.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }
    }
}
