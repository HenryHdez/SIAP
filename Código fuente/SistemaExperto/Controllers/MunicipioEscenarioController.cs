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
    public class MunicipioEscenarioController : Controller
    {
        private SEEntities db = new SEEntities();
        //
        // GET: /MunicipioEscenario/
        public ActionResult Index()
        {
            return View(db.MunicipioEscenario.ToList());
        }

        //
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipioEscenario municipioEscenario = db.MunicipioEscenario.Find(id);
            if (municipioEscenario == null)
            {
                return HttpNotFound();
            }
            return View(municipioEscenario);
        }

        // GET: /EstacionMensual/Crear
        public ActionResult Crear(int? id)
        {
            //Búsqueda de la condicion correspondiente para asignar datos
            Condicion condicion = db.Condicion.Find(id);
            if (condicion != null)
            {
                //SistemaExperto envía la variable con el valor seleccionado de la estación
                ViewBag.CondicionId = new SelectList(db.Condicion, "CondicionId", "Nombre", condicion.CondicionId);
            }
            else
            {
                ViewBag.CondicionId = new SelectList(db.Condicion, "CondicionId", "Nombre");
            }

            //Búsqueda de municipio correspondiente para asignar datos
            Municipio municipio = db.Municipio.Find(id);
            if (municipio != null)
            {
                //SistemaExperto envía la variable con el valor seleccionado de la estación
                ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", municipio.MunicipioId);
            }
            else
            {
                ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre");
            }

            return View();
        }

        // POST: municipioEscenario/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "MunicipioEscenarioId,MunicipioId,CondicionId,Mes,Codigo,Descripcion")] MunicipioEscenario municipioEscenario)
        {
            if (ModelState.IsValid)
            {
                db.MunicipioEscenario.Add(municipioEscenario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CondicionId = new SelectList(db.Condicion, "CondicionId", "Nombre", municipioEscenario.CondicionId);
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", municipioEscenario.MunicipioId);

            return View(municipioEscenario);
        }


        // GET: municipioEscenario/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipioEscenario municipioEscenario = db.MunicipioEscenario.Find(id);
            if (municipioEscenario == null)
            {
                return HttpNotFound();
            }
            ViewBag.CondicionId = new SelectList(db.Condicion, "CondicionId", "Nombre", municipioEscenario.CondicionId);
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", municipioEscenario.MunicipioId);

            return View(municipioEscenario);
        }

        // POST: municipioEscenario/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "MunicipioEscenarioId,MunicipioId,CondicionId,Mes,Codigo,Descripcion")]  MunicipioEscenario municipioEscenario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipioEscenario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CondicionId = new SelectList(db.Condicion, "CondicionId", "Nombre", municipioEscenario.CondicionId);
            ViewBag.MunicipioId = new SelectList(db.Municipio, "MunicipioId", "Nombre", municipioEscenario.MunicipioId);
            return View(municipioEscenario);
        }


        // GET: municipioEscenario/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipioEscenario municipioEscenario = db.MunicipioEscenario.Find(id);
            if (municipioEscenario == null)
            {
                return HttpNotFound();
            }
            return View(municipioEscenario);
        }

        // POST: condicion/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            MunicipioEscenario municipioEscenario = db.MunicipioEscenario.Find(id);
            db.MunicipioEscenario.Remove(municipioEscenario);
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

            IEnumerable<MunicipioEscenario> filteredCompanies = db.MunicipioEscenario;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.MunicipioEscenario
                         .Where(c => c.Condicion.Nombre.Contains(param.sSearch) || c.Codigo.Contains(param.sSearch)
                         || c.Municipio.Nombre.Contains(param.sSearch) || System.Data.Entity.SqlServer.SqlFunctions.StringConvert((double)c.Mes).Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.MunicipioEscenario;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<MunicipioEscenario, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Condicion.Nombre :
                                                                sortColumnIndex == 2 ? c.Codigo :
                                                                sortColumnIndex == 3 ? c.Municipio.Nombre :
                                                                System.Data.Entity.SqlServer.SqlFunctions.StringConvert((double)c.Mes));


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
                .Select(c => new { c.MunicipioEscenarioId, Condicion = c.Condicion.Nombre, c.Codigo, Municipio = c.Municipio.Nombre, c.Mes });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.MunicipioEscenario.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}
