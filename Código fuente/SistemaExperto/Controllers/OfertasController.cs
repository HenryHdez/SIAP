using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;
using RazorPDF;
using Rotativa;

namespace SE.Controllers
{
    public class OfertasController : Controller
    {
        private SEEntities db = new SEEntities();

        //Fecha actual del sistema
        //DateTime fechaActual = new DateTime(2012, 01, 01);
        DateTime fechaActual = System.DateTime.Today;

        //
        // GET: /Ofertas/

        public ActionResult Index()
        {
            var ofertas = db.Ofertas.Include(o => o.CultivoEtapa).Include(o => o.TipoPrediccion).Include(o => o.Cultivo).Include(o => o.Efectos);
            return View(ofertas.ToList());
        }

        //
        // GET: /Ofertas/Details/5

        public ActionResult Detalles(int id = 0)
        {
            Ofertas ofertas = db.Ofertas.Find(id);
            if (ofertas == null)
            {
                return HttpNotFound();
            }
            return View(ofertas);
        }

        //
        // GET: /Ofertas/Create

        public ActionResult Create()
        {
            ViewBag.CultivoEtapaId = new SelectList(db.CultivoEtapa, "CultivoEtapaId", "Nombre");
            ViewBag.TipoPrediccionId = new SelectList(db.TipoPrediccion, "TipoPrediccionId", "Nombre");
            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre");
            

            //ViewBag.EfectoId = new SelectList(db.Acciones, "AccionId", "Nombre");
            ViewBag.EfectoId = new SelectList(db.OpcionTecnologica, "OpcionTecnologicaId", "Nombre");
            return View();
        }

        //
        // POST: /Ofertas/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ofertas ofertas)
        {
            if (ModelState.IsValid)
            {
                db.Ofertas.Add(ofertas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CultivoEtapaId = new SelectList(db.CultivoEtapa, "CultivoEtapaId", "Nombre", ofertas.CultivoEtapaId);
            ViewBag.TipoPrediccionId = new SelectList(db.TipoPrediccion, "TipoPrediccionId", "Nombre", ofertas.TipoPrediccionId);
            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre", ofertas.CultivoId);

            //OpcionTecnologica ViewBag.EfectoId = new SelectList(db.Acciones, "EfectoId", "Nombre", ofertas.EfectoId);
            ViewBag.EfectoId = new SelectList(db.OpcionTecnologica, "EfectoId", "Nombre", ofertas.EfectoId);
            return View(ofertas);
        }

        //
        // GET: /Ofertas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ofertas ofertas = db.Ofertas.Find(id);
            if (ofertas == null)
            {
                return HttpNotFound();
            }
            ViewBag.CultivoEtapaId = new SelectList(db.CultivoEtapa, "CultivoEtapaId", "Nombre", ofertas.CultivoEtapaId);
            ViewBag.TipoPrediccionId = new SelectList(db.TipoPrediccion, "TipoPrediccionId", "Nombre", ofertas.TipoPrediccionId);
            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre", ofertas.CultivoId);
            
            ViewBag.EfectoId = new SelectList(db.OpcionTecnologica, "EfectoId", "Nombre", ofertas.EfectoId);
            //ViewBag.EfectoId = new SelectList(db.Acciones, "EfectoId", "Nombre", ofertas.EfectoId);
           
            return View(ofertas);
        }

        //
        // POST: /Ofertas/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ofertas ofertas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ofertas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CultivoEtapaId = new SelectList(db.CultivoEtapa, "CultivoEtapaId", "Nombre", ofertas.CultivoEtapaId);
            ViewBag.TipoPrediccionId = new SelectList(db.TipoPrediccion, "TipoPrediccionId", "Nombre", ofertas.TipoPrediccionId);
            ViewBag.CultivoId = new SelectList(db.Cultivo, "CultivoId", "Nombre", ofertas.CultivoId);

            ViewBag.EfectoId = new SelectList(db.OpcionTecnologica, "EfectoId", "Nombre", ofertas.EfectoId);
            //OpcionTecnologica ViewBag.EfectoId = new SelectList(db.Acciones, "EfectoId", "Nombre", ofertas.EfectoId);
            return View(ofertas);
        }

        //
        // GET: /Ofertas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ofertas ofertas = db.Ofertas.Find(id);
            if (ofertas == null)
            {
                return HttpNotFound();
            }
            return View(ofertas);
        }

        //
        // POST: /Ofertas/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ofertas ofertas = db.Ofertas.Find(id);
            db.Ofertas.Remove(ofertas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult CultivoEtapa(int ZonaId = 0)
        {
            Zona zonaCultivo = db.Zona.Find(ZonaId);

            ViewBag.CultivoEtapaId = new SelectList(db.CultivoEtapa, "CultivoEtapaId", "Nombre", null);

            if (zonaCultivo == null)
            {
                return HttpNotFound();
            }
            return View(zonaCultivo);
        }

        public ActionResult OpcionesLocal(int ZonaId, int CultivoEtapaId = 5)
        {
            List<string> condiciones = db.Condicion.Select(c => c.Nombre).ToList();
            ViewBag.Condiciones = condiciones;

            Session["CultivoEtapa"] = CultivoEtapaId;

            DateTime fecha = fechaActual;

            // Valida si se tiene prediccion para Ingresar al modulo Local
            //Revisa si el mes ya pasó del día 15, para saber si hace el cálculo con el mes actual o con el siguiente
            if (fechaActual.Day > 15)
            {
                fecha = fechaActual.AddMonths(1);
            }

            Zona zona = db.Zona.Find(ZonaId);
            ViewBag.Zona = zona;

            ViewBag.ZonaId = ZonaId;

           int municipioId = db.Zona.Find(ZonaId).MunicipioId;
           ViewBag.MunicipioId = municipioId;
           Municipio municipio = db.Municipio.Where(cd => cd.MunicipioId == municipioId).FirstOrDefault();

            IQueryable<ZonaEstacion> estacionesZona = db.ZonaEstacion.Where(e => e.ZonaId == ZonaId);
            EstacionMensual estacionMensual = db.EstacionMensual.Where(pc => pc.EstacionId == estacionesZona.FirstOrDefault().EstacionId).
                Where(pc => pc.Fecha.Year == fecha.Year).Where(pc => pc.Fecha.Month == fecha.Month).FirstOrDefault();           
            int tipoPrediccionId = 2;
            if (estacionMensual != null)
            {
                double spiZona = estacionMensual.SPI;
                if (spiZona >= 1)
                {
                    tipoPrediccionId = 1;
                }
                else
                {
                    if (spiZona <= -1)
                    {
                        tipoPrediccionId = 3;
                    }
                }
                ViewBag.X = spiZona;
            }
         
            ViewBag.TipoPrediccion = tipoPrediccionId;

            int tipoCultivo = db.Zona.Find(ZonaId).CultivoId;
            TipoPrediccion tipoPrediccion = db.TipoPrediccion.Where(d => d.TipoPrediccionId == tipoPrediccionId).FirstOrDefault();

            ViewBag.CultivoId = tipoCultivo;
            Cultivo cultivo = db.Cultivo.Where(c => c.CultivoId == tipoCultivo).FirstOrDefault();

            IEnumerable<Ofertas> efectos = (db.Ofertas.Where(p => p.TipoPrediccionId == tipoPrediccionId)).Where(p => p.CultivoId == tipoCultivo).Where(p => p.IndicadorLocal == true);

            foreach (var item in efectos)
            {
                ViewBag.Efectos = ViewBag.Efectos + "&#9642; " + item.Efectos.Nombre + "<br><br>";
            }

            IEnumerable<TipoOferta> tipoOferta = from TipoOferta in db.TipoOferta.AsEnumerable() select TipoOferta;
            IEnumerable<OpcionTecnologica> opcionTecnologica = from OpcionTecnologica in db.OpcionTecnologica.AsEnumerable() select OpcionTecnologica;
            IEnumerable<ListaOpciones> listaOpciones = (db.ListaOpciones.Where(p => p.CultivoId == tipoCultivo).Where(p => p.MunicipioId == municipioId).Where(p => p.TipoPrediccionId == tipoPrediccionId).Where(p=> p.IndicadorLocal ==false));

            return View(new ListaOpcionesViewModel()
                 {
                     Municipio = municipio,
                     Cultivo = cultivo,
                     TipoOferta = tipoOferta,
                     TipoPrediccion = tipoPrediccion,
                     OpcionTecnologica = opcionTecnologica,
                     ListaOpciones = listaOpciones
                  
                  });
        }

        public ActionResult OpcionesRegional(int CultivoEtapaId = 5, int CondicionId=0, int MunicipioId=1, int CultivoId=1)
        {
            List<string> condiciones = db.Condicion.Select(c => c.Nombre).ToList();
            ViewBag.Condiciones = condiciones;

            CondicionId = CondicionId + 1;
            Municipio municipio = db.Municipio.Where(cd => cd.MunicipioId == MunicipioId).FirstOrDefault();

            //double prediccionZona = (db.Prediccion.Where(p => p.ZonaEstacion.ZonaId == ZonaId).Where(p => p.Fecha.Year == fecha.Year).Where(p => p.Fecha.Month == fecha.Month).FirstOrDefault()).X;

            //int tipoPrediccionId = (db.TipoPrediccion.Where(p => p.Maximo > prediccionZona).Where(p => p.Minimo < prediccionZona).FirstOrDefault()).TipoPrediccionId;

            ViewBag.TipoPrediccion = CondicionId;

            //int tipoCultivo = db.Zona.Find(ZonaId).CultivoId;
            TipoPrediccion tipoPrediccion = db.TipoPrediccion.Where(d => d.TipoPrediccionId == CondicionId).FirstOrDefault();

            ViewBag.CultivoId = CultivoId;
            Cultivo cultivo = db.Cultivo.Where(c => c.CultivoId == CultivoId).FirstOrDefault();


            IEnumerable<Ofertas> efectos = (db.Ofertas.Where(p => p.TipoPrediccionId == CondicionId)).Where(p => p.CultivoId == CultivoId).Where(p => p.IndicadorLocal == false);

            foreach (var item in efectos)
            {
                ViewBag.Efectos = ViewBag.Efectos + "&#9642; " + item.Efectos.Nombre + "<br><br>";
            }

          

            IEnumerable<TipoOferta> tipoOferta = from TipoOferta in db.TipoOferta.AsEnumerable() select TipoOferta;
            IEnumerable<OpcionTecnologica> opcionTecnologica = from OpcionTecnologica in db.OpcionTecnologica.AsEnumerable() select OpcionTecnologica;
            IEnumerable<ListaOpciones> listaOpciones = (db.ListaOpciones.Where(p => p.CultivoId == CultivoId).Where(p => p.MunicipioId == MunicipioId).Where(p => p.TipoPrediccionId == CondicionId).Where(p => p.IndicadorLocal == false));

            return View(new ListaOpcionesViewModel()
            {
                Municipio = municipio,
                Cultivo = cultivo,
                TipoOferta = tipoOferta,
                TipoPrediccion = tipoPrediccion,
                OpcionTecnologica = opcionTecnologica,
                ListaOpciones = listaOpciones

            });
        }
        public ActionResult Opciones(int AccionId = 0, int CultivoEtapaId=0, int ZonaId=0)
        {
            //ViewBag.ZonaId = ZonaId;
            //ViewBag.CultivoEtapaId = CultivoEtapaId;
            
            // antes Accion:
            OpcionTecnologica opcionTecnologica = db.OpcionTecnologica.Find(AccionId);

            Zona zonaCultivo = db.Zona.Find(ZonaId);
            ViewBag.Zona = zonaCultivo;
            
            IEnumerable<AccionesOpciones> opciones = (db.AccionesOpciones.Where(p => p.AccionId == AccionId));

            if (opcionTecnologica == null)
            {
                return HttpNotFound();
            }
            
            return View(opciones);
        }

        public ActionResult OpcionesTecnologicas()
        {
            return View();
        }

        public ActionResult FichaOTLocal(int? id)
        {
             
           
               // FichaOpcion fichaOpcion = db.FichaOpcion.Find(id);
                //FichaOpcion fichaOpcion = db.FichaOpcion.Where(op => op.ListaOpcionesId == id).FirstOrDefault();
               // int listaopcion = fichaOpcion.ListaOpcionesId;
                var listaopcion = id;

                ListaOpciones listaOpciones = db.ListaOpciones.Where(o => o.ListaOpcionesId == listaopcion).FirstOrDefault();
              //  IEnumerable<ListaOpciones> listaOpciones = db.ListaOpciones.Where(cd => cd.ListaOpcionesId == listaopcion);
               // int opcion = listaOpciones.OpcionTecnologicaId;

                IEnumerable<FichaOpcion> fichaOpcion = db.FichaOpcion.Where(cd => cd.ListaOpcionesId == listaopcion);

                OpcionTecnologica opcionTecnologica = db.OpcionTecnologica.Where(t => t.OpcionTecnologicaId == listaopcion).FirstOrDefault();

                int municipioId = listaOpciones.MunicipioId;

                Municipio municipio = db.Municipio.Where(m => m.MunicipioId == municipioId).FirstOrDefault();

                int zona = municipio.Zona.FirstOrDefault().ZonaId;
                ViewBag.ZonaId = zona;

                int tipoPrediccionId = listaOpciones.TipoPrediccionId;

                TipoPrediccion tipoPrediccion = db.TipoPrediccion.Where(d => d.TipoPrediccionId == tipoPrediccionId).FirstOrDefault();

                int cultivoId = listaOpciones.CultivoId;
                Cultivo cultivo = db.Cultivo.Where(c => c.CultivoId == cultivoId).FirstOrDefault();

                int tipoOfertaId = listaOpciones.TipoOfertaId;

                TipoOferta tipoOferta = db.TipoOferta.Where(t => t.TipoOfertaId == tipoOfertaId).FirstOrDefault();
                

            return View(new FichaOpcionViewModel()
            {
                Municipio = municipio,
                Cultivo = cultivo,
                OpcionTecnologica = opcionTecnologica,
                ListaOpciones = listaOpciones,
                TipoPrediccion = tipoPrediccion,
                TipoOferta = tipoOferta,
                FichaOpcion = fichaOpcion
               
            }
                );
           
        }
        public ActionResult FichaOTRegional(int? id)
        {

            //FichaOpcion fichaOpcion = db.FichaOpcion.Find(id);

           // int listaopcion = fichaOpcion.ListaOpcionesId;
            var listaopcion = id;
           // IEnumerable<ListaOpciones> listaOpciones = from ListaOpciones in db.ListaOpciones.AsEnumerable()
             //                                          select ListaOpciones;
           // IEnumerable<ListaOpciones> listaOpciones = db.ListaOpciones.Where(cd => cd.ListaOpcionesId == listaopcion);

            ListaOpciones listaOpciones = db.ListaOpciones.Where(o => o.ListaOpcionesId == listaopcion).FirstOrDefault();

            //int opcion = listaOpciones.OpcionTecnologicaId.FirstOrDefault();

            //IEnumerable<FichaOpcion> fichaOpcion = db.FichaOpcion.Where(cd => cd.ListaOpcionesId == listaopcion);
            IEnumerable<FichaOpcion> fichaOpcion = from FichaOpcion in db.FichaOpcion.AsEnumerable()
                                                   select FichaOpcion;

            OpcionTecnologica opcionTecnologica = db.OpcionTecnologica.Where(t => t.OpcionTecnologicaId == listaopcion).FirstOrDefault();

            int municipioId = listaOpciones.MunicipioId;

            Municipio municipio = db.Municipio.Where(m => m.MunicipioId == municipioId).FirstOrDefault();

            //int zona = municipio.Zona.FirstOrDefault().ZonaId;
            //ViewBag.ZonaId = zona;

            int tipoPrediccionId = listaOpciones.TipoPrediccionId;

            TipoPrediccion tipoPrediccion = db.TipoPrediccion.Where(d => d.TipoPrediccionId == tipoPrediccionId).FirstOrDefault();

            int cultivoId = listaOpciones.CultivoId;
            Cultivo cultivo = db.Cultivo.Where(c => c.CultivoId == cultivoId).FirstOrDefault();

            int tipoOfertaId = listaOpciones.TipoOfertaId;

            TipoOferta tipoOferta = db.TipoOferta.Where(t => t.TipoOfertaId == tipoOfertaId).FirstOrDefault();


            return View(new FichaOpcionViewModel()
            {
                Municipio = municipio,
                Cultivo = cultivo,
                OpcionTecnologica = opcionTecnologica,
                ListaOpciones = listaOpciones,
                TipoPrediccion = tipoPrediccion,
                TipoOferta = tipoOferta,
                FichaOpcion = fichaOpcion

            }
                );

        }

        public ActionResult Informe(int id)
        {
            // var listaopcion = id;


            //IEnumerable<FichaOpcion> FichaOpcion = from l in db.FichaOpcion
            //                                       where l.ListaOpcionesId == listaopcion
            //                                       select l;


            //OpcionTecnologica opcionTecnologica = db.OpcionTecnologica.Where(t => t.OpcionTecnologicaId == FichaOpcion.FirstOrDefault().ListaOpciones.OpcionTecnologicaId).FirstOrDefault();

            //ViewBag.NombreOT = opcionTecnologica.Nombre;

            //var ot = new List<DatosOT>();
            ////int contadorAnalisis = 0;

            //return View(FichaOpcion);

            //FichaOpcion fichaOpcion = db.FichaOpcion.Find(id);

            // int listaopcion = fichaOpcion.ListaOpcionesId;
            var listaopcion = id;
            // IEnumerable<ListaOpciones> listaOpciones = from ListaOpciones in db.ListaOpciones.AsEnumerable()
            //                                          select ListaOpciones;
            // IEnumerable<ListaOpciones> listaOpciones = db.ListaOpciones.Where(cd => cd.ListaOpcionesId == listaopcion);

            ListaOpciones listaOpciones = db.ListaOpciones.Where(o => o.ListaOpcionesId == listaopcion).FirstOrDefault();

            //int opcion = listaOpciones.OpcionTecnologicaId.FirstOrDefault();

            IEnumerable<FichaOpcion> fichaOpcion = db.FichaOpcion.Where(cd => cd.ListaOpcionesId == listaopcion);
            //IEnumerable<FichaOpcion> fichaOpcion = from FichaOpcion in db.FichaOpcion.AsEnumerable()
            //                                       select FichaOpcion;

            OpcionTecnologica opcionTecnologica = db.OpcionTecnologica.Where(t => t.OpcionTecnologicaId == listaopcion).FirstOrDefault();

            int municipioId = listaOpciones.MunicipioId;

            Municipio municipio = db.Municipio.Where(m => m.MunicipioId == municipioId).FirstOrDefault();

           // int zona = municipio.Zona.FirstOrDefault().ZonaId;
           // ViewBag.ZonaId = zona;

            int tipoPrediccionId = listaOpciones.TipoPrediccionId;

            TipoPrediccion tipoPrediccion = db.TipoPrediccion.Where(d => d.TipoPrediccionId == tipoPrediccionId).FirstOrDefault();

            int cultivoId = listaOpciones.CultivoId;
            Cultivo cultivo = db.Cultivo.Where(c => c.CultivoId == cultivoId).FirstOrDefault();

            int tipoOfertaId = listaOpciones.TipoOfertaId;

            TipoOferta tipoOferta = db.TipoOferta.Where(t => t.TipoOfertaId == tipoOfertaId).FirstOrDefault();


            return View(new FichaOpcionViewModel()
            {
                Municipio = municipio,
                Cultivo = cultivo,
                OpcionTecnologica = opcionTecnologica,
                ListaOpciones = listaOpciones,
                TipoPrediccion = tipoPrediccion,
                TipoOferta = tipoOferta,
                FichaOpcion = fichaOpcion

            }
                );
        }
        //Objeto de datos de análisis
        public class DatosOT
        {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
        }


        public ActionResult AccionInforme(string id)
        {
            int IdLista = int.Parse(id);

            ActionAsPdf pdf = new ActionAsPdf(
                           "Informe",
                           new {
                               id = IdLista
                           })
            {
                FileName = "FichaOT_" + id + ".pdf"
            };

            return pdf;
        }

        public ActionResult Menu()
        {
            return View();
        }

    }
}