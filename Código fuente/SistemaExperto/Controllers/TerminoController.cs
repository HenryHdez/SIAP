using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;
using Rotativa;
using System.Data.Entity.Infrastructure;

namespace SistemaExperto.Controllers
{
    public class TerminoController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: Terminos
        public ActionResult Index(string texto)
        {
            ViewBag.mensaje = texto;

            var termino = db.Termino;
            return View(termino.ToList());
        }

        //public ActionResult InicioVideos() => (ActionResult)this.View((object)this.db.Termino.ToList<Termino>());
        public ActionResult InicioVideos()
        {
            DateTime fechaActual = DateTime.Now;
            string fechaString1 = fechaActual.ToString("yyyy-MM-dd HH:mm:ss");

            SITB_RegIng Registro = new SITB_RegIng();
            Registro.Fecha = fechaString1;
            Registro.Modulo = "C";
            Registro.Submodulo = "Glosario especializado";
            try
            {
                db.SITB_RegIng.Add(Registro);  // Esta es la línea que faltaba
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
            }
            var terminos = db.Termino.ToList<Termino>();
            return View(terminos);
        }
        // GET: Terminos/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termino termino = db.Termino.Find(id);
            if (termino == null)
            {
                return HttpNotFound();
            }
            return View(termino);
        }

        // GET: Terminos/Crear
        public ActionResult Crear()
        {
            ViewBag.CodigoPadreId = new SelectList(db.Termino, "TerminoId", "NombreTermino");
            return View();
        }

        // POST: Terminos/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "TerminoId,NombreTermino,Codigo,Comodin,DefinicionBreve,DefinicionAmplia,Fuente,InformacionApoyo,Etiquetas,Orden,CodigoPadreId")] Termino termino)
        {
            if (ModelState.IsValid)
            {
                db.Termino.Add(termino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoPadreId = new SelectList(db.Termino, "TerminoId", "NombreTermino", termino.CodigoPadreId);
            return View(termino);
        }

        // GET: Terminos/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termino termino = db.Termino.Find(id);
            if (termino == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoPadreId = new SelectList(db.Termino, "TerminoId", "NombreTermino", termino.CodigoPadreId);
            return View(termino);
        }
        public ActionResult DefinicionAmplia(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termino termino = db.Termino.Find(id);
            if (termino == null)
            {
                return HttpNotFound();
            }
            // ViewBag.CodigoPadreId = new SelectList(db.Termino, "TerminoId", "NombreTermino", termino.CodigoPadreId);
            return View(termino);
        }

        public ActionResult Arbol(string id)
        {
            if (id != null)
            {
                ViewBag.CodigoTerminoInicial = id;
            }

            IEnumerable<Termino> terminos = db.Termino.OrderBy(t=>t.Orden);
            IEnumerable<Termino> terminosNoPadre = terminos.Where(t => t.CodigoPadre != null);
            IEnumerable<Termino> terminosPadre = terminos.Where(t => t.CodigoPadre == null);
            List<int> vectorTerminosPadre = new List<int>();
            foreach (Termino terminoPadre in terminosPadre)
            {
                vectorTerminosPadre.Add(terminoPadre.TerminoId);
            }

            IEnumerable<Termino> terminosHijo = terminosNoPadre.Where(t => vectorTerminosPadre.Contains((int)t.CodigoPadreId));
            List<int> vectorTerminosHijo = new List<int>();
            foreach (Termino terminoHijo in terminosHijo)
            {
                vectorTerminosHijo.Add(terminoHijo.TerminoId);
            }

            IEnumerable<Termino> terminosNieto = terminosNoPadre.Where(t => vectorTerminosHijo.Contains((int)t.CodigoPadreId));

            TerminoViewModel ListaTerminos = new TerminoViewModel
            {
                TerminosPadre = terminosPadre,
                TerminosHijo = terminosHijo,
                TerminosNieto = terminosNieto
            };

            return View(ListaTerminos);
        }

        // POST: Terminos/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "TerminoId,NombreTermino,Codigo,Comodin,DefinicionBreve,DefinicionAmplia,Fuente,InformacionApoyo,Etiquetas,Orden,CodigoPadreId")] Termino termino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(termino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoPadreId = new SelectList(db.Termino, "TerminoId", "NombreTermino", termino.CodigoPadreId);
            return View(termino);
        }

        // GET: Terminos/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termino termino = db.Termino.Find(id);
            if (termino == null)
            {
                return HttpNotFound();
            }
            return View(termino);
        }

        // POST: Terminos/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            string mensaje = "Registro eliminado";

            Termino termino = db.Termino.Find(id);
            try
            {
                db.Termino.Remove(termino);
                db.SaveChanges();
            }
            catch (Exception error)
            {
                mensaje = "Error al eliminar. Revise que el registro no tenga términos hijos";
            }
            return RedirectToAction("Index", new { texto = mensaje });
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<Termino> filteredCompanies = db.Termino;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.Termino
                         .Where(c => c.NombreTermino.Contains(param.sSearch) ||
                          c.Codigo.Contains(param.sSearch)
                          || c.Etiquetas.Contains(param.sSearch)
                                     );
            }
            else
            {
                filteredCompanies = db.Termino;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Termino, string> orderingFunction = (c => sortColumnIndex == 1 ? c.NombreTermino : sortColumnIndex == 2 ? c.Codigo : c.Etiquetas);

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
                .Select(c => new { c.TerminoId, c.NombreTermino, c.Codigo, c.Etiquetas, c.Orden });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.Termino.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
        public ActionResult AccionInforme(string id)
        {
            int IdLista = int.Parse(id);

            ActionAsPdf pdf = new ActionAsPdf(
                           "Informe",
                           new
                           {
                               id = IdLista
                           })
            {
                FileName = "Termino_" + id + ".pdf"
            };

            return pdf;
        }
        public ActionResult Informe(int id)
        {

            var listaopcion = id;
            Termino termino = db.Termino.Where(o => o.TerminoId == listaopcion).FirstOrDefault();

            return View(termino
                );
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
