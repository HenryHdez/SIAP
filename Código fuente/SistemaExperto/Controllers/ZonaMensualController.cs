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
    public class ZonaMensualController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /ZonaMensual/
        public ActionResult Index()
        {
            var balancehidrico = db.ZonaMensual.Include(b => b.Zona);
            //ViewBag.idZona = balancehidrico.FirstOrDefault().ZonaId;
            return View(balancehidrico.ToList());
        }

        // GET: /ZonaMensual/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZonaMensual zonamensual = db.ZonaMensual.Find(id);
            if (zonamensual == null)
            {
                return HttpNotFound();
            }
            return View(zonamensual);
        }

        // GET: /ZonaMensual/Crear
        public ActionResult Crear(int? id)
        {
            //Búsqueda de la zona correspondiente para asignar datos
            Zona zona = db.Zona.Find(id);
            if (zona != null)
            {
                //SistemaExperto envía la variable con el valor seleccionado de la zona
                ViewBag.ZonaId = new SelectList(db.Zona, "ZonaId", "Nombre", zona.ZonaId);
            }
            else
            {
                ViewBag.ZonaId = new SelectList(db.Zona, "ZonaId", "Nombre");
            }

            return View();
        }

        // POST: /ZonaMensual/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ZonaId,Fecha,Ss0,Su0")] ZonaMensual zonamensual)
        {
            // consulta en BD para existencia de datos con la misma fecha y zona
            IEnumerable<ZonaMensual> listaDatos = db.ZonaMensual.Where(em => em.Fecha.Year == zonamensual.Fecha.Year && em.Fecha.Month == zonamensual.Fecha.Month && em.ZonaId==zonamensual.ZonaId);

            // si existen datos SistemaExperto envía mensaje de error, si no, SistemaExperto crea el registro
            if (listaDatos.Count() == 0)
            {
                if (ModelState.IsValid)
                {
                    db.ZonaMensual.Add(zonamensual);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.MensajeError = "Ya SistemaExperto registraron datos para la zona y mes seleccionado";
            }

            ViewBag.ZonaId = new SelectList(db.Zona, "ZonaId", "Nombre", zonamensual.ZonaId);
            return View(zonamensual);
        }

        // GET: /ZonaMensual/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZonaMensual disponibilidadagua = db.ZonaMensual.Find(id);
            if (disponibilidadagua == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZonaId = new SelectList(db.Zona, "ZonaId", "Nombre", disponibilidadagua.ZonaId);
            return View(disponibilidadagua);
        }

        // POST: /ZonaMensual/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ZonaId,Fecha,Ss0,Su0,ResultadoDA,ZonaMensualId")] ZonaMensual zonamensual)
        {
            Zona zona = db.Zona.Find(zonamensual.ZonaId);

            if (ModelState.IsValid)
            {
                db.Entry(zonamensual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZonaId = new SelectList(db.Zona, "ZonaId", "Nombre", zonamensual.ZonaId);
            return View(zonamensual);
        }

        // GET: /ZonaMensual/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZonaMensual zonamensual = db.ZonaMensual.Find(id);
            if (zonamensual == null)
            {
                return HttpNotFound();
            }
            return View(zonamensual);
        }

        // POST: /ZonaMensual/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            ZonaMensual zonamensual = db.ZonaMensual.Find(id);
            db.ZonaMensual.Remove(zonamensual);
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

        public EstacionMensual CalcularPrediccionZona(int codigoZona, DateTime fecha)
        {
            EstacionMensual prediccionZona = new EstacionMensual();

            var zonaEstacion = from ze in db.ZonaEstacion
                               where ze.ZonaId == codigoZona
                               select ze;

            List<EstacionMensual> listaPredicciones = new List<EstacionMensual>();

            foreach (var item in zonaEstacion)
            {
                EstacionMensual datosEstacion = (from p in db.EstacionMensual where (p.EstacionId == item.EstacionId && p.Fecha.Month == fecha.Month) select p).FirstOrDefault();
                datosEstacion.Precipitacion = datosEstacion.Precipitacion * item.Porcentaje / 100;
                datosEstacion.ETo = datosEstacion.ETo * item.Porcentaje / 100;
                listaPredicciones.Add(datosEstacion);
            }

            foreach (var item in listaPredicciones)
            {
                prediccionZona.Precipitacion = prediccionZona.Precipitacion + item.Precipitacion;
                prediccionZona.ETo = prediccionZona.ETo + item.ETo;
            }

            return prediccionZona;
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
           // int ZonaId = int.Parse(Request.QueryString["ZonaId"]);

            IEnumerable<ZonaMensual> filteredCompanies = db.ZonaMensual;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.ZonaMensual/*.Where(c => c.ZonaId == ZonaId)*/
                         .Where(c =>
                          c.Zona.Nombre.Contains(param.sSearch)
                                     ||
                                      c.Fecha.Year.ToString().Contains(param.sSearch)
                                      ||
                                      c.Fecha.Month.ToString().Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.ZonaMensual;/*.Where(c => c.ZonaId == ZonaId);*/
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<ZonaMensual, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Zona.Nombre :
                                                                sortColumnIndex == 2 ? Convert.ToString(c.Fecha.Year) :
                                                                 Convert.ToString(c.Fecha.Month));

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
                .Select(c => new { c.ZonaMensualId, c.Zona.Nombre, c.Fecha.Date.Year, c.Fecha.Date.Month });

         
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.ZonaMensual.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                            JsonRequestBehavior.AllowGet);
        }
    }
}
