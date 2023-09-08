using System;
using System.IO;
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
    public class EstacionController : Controller
    {
        private SistemaExperto.Controllers.ArchivoController archivo= new ArchivoController();
        private SEEntities db = new SEEntities();

        // GET: /Estacion/
        public ActionResult Index()
        {
            return View(db.Estacion.ToList());
        }

        // GET: /Estacion/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacion estacion = db.Estacion.Find(id);
            if (estacion == null)
            {
                return HttpNotFound();
            }
            return View(estacion);
        }

        public ActionResult Crear(int? id)
        {
            //Búsqueda de la estación correspondiente para asignar datos
            EstacionTipo estacionTipo = db.EstacionTipo.Find(id);
            if (estacionTipo != null)
            {
                //SistemaExperto envía la variable con el valor seleccionado de la estación
                ViewBag.EstacionTipoId = new SelectList(db.EstacionTipo, "EstacionTipoId", "Tipo", estacionTipo.EstacionTipoId);
            }
            else
            {
                ViewBag.EstacionTipoId = new SelectList(db.EstacionTipo, "EstacionTipoId", "Tipo");
            }

            return View();
        }

        // POST: /Estacion/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "EstacionId,Nombre,CodigoIdeam,Latitud,Longitud,Altitud,CadenaAlfas,CadenaBetas,CadenaGammas,CadenaDeltas,CadenaKs,CadenaZs,CadenaX1s,CadenaX2s,CadenaX3s,RutaImagen,EstacionTipoId")] Estacion estacion, HttpPostedFileBase imagenAdjunta)
        {
            if (ModelState.IsValid)
            {
                string ruta = archivo.GuardarArchivo(estacion.EstacionId, imagenAdjunta, 1);
                
                if (ruta != null)
                {
                    estacion.RutaImagen = ruta;
                }

                db.Estacion.Add(estacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstacionTipoId = new SelectList(db.EstacionTipo, "EstacionTipoId", "Tipo", estacion.EstacionTipoId);

            return View(estacion);
        }

        // GET: /Estacion/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacion estacion = db.Estacion.Find(id);
            if (estacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstacionTipoId = new SelectList(db.EstacionTipo, "EstacionTipoId", "Tipo", estacion.EstacionTipoId);
            return View(estacion);
        }

        // POST: /Estacion/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "EstacionId,Nombre,CodigoIdeam,Latitud,Longitud,Altitud,CadenaAlfas,CadenaBetas,CadenaGammas,CadenaDeltas,CadenaKs,CadenaZs,CadenaX1s,CadenaX2s,CadenaX3s,RutaImagen,EstacionTipoId")] Estacion estacion, HttpPostedFileBase imagenAdjunta)
        {
            if (ModelState.IsValid)
            {
                //Validación de existencia de directorio del Conjunto, si no existe SistemaExperto crea
                string ubicacionDirectorio = Server.MapPath("~/Content/archivos/" + estacion.EstacionId);
                CrearDirectorio(ubicacionDirectorio);

                //Registro de imagen adjunta
                if (imagenAdjunta != null && imagenAdjunta.ContentLength != 0)
                {
                    //Almacenamiento de imagen en el servidor
                    string rutaImagen = Path.Combine(ubicacionDirectorio, Path.GetFileName(imagenAdjunta.FileName));
                    imagenAdjunta.SaveAs(rutaImagen);

                    //Modificación del valor Ruta en Conjunto
                    estacion.RutaImagen = "/Content/archivos/" + estacion.EstacionId + "/" + Path.GetFileName(imagenAdjunta.FileName);
                }

                db.Entry(estacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstacionTipoId = new SelectList(db.EstacionTipo, "EstacionTipoId", "Nombre", estacion.EstacionTipoId);
            return View(estacion);
        }

        // GET: /Estacion/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacion estacion = db.Estacion.Find(id);
            if (estacion == null)
            {
                return HttpNotFound();
            }
            return View(estacion);
        }

        // POST: /Estacion/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            Estacion estacion = db.Estacion.Find(id);
            db.Estacion.Remove(estacion);
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

        //Creación de directorio en el servidor
        private bool CrearDirectorio(string ruta)
        {
            bool resultado = true;
            if (!Directory.Exists(ruta))
            {
                try
                {
                    Directory.CreateDirectory(ruta);
                }
                catch (Exception)
                {
                    //Manejo de la excepción
                    resultado = false;
                }
            }
            return resultado;
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<Estacion> filteredCompanies = db.Estacion;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.Estacion
                         .Where(c =>
                          c.Nombre.Contains(param.sSearch) 
                                     );

            }
            else
            {
                filteredCompanies = db.Estacion;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Estacion, string> orderingFunction = (c => c.Nombre );

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
                  .Select(c => new { c.EstacionId, c.Nombre});

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.Estacion.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }
    }
}
