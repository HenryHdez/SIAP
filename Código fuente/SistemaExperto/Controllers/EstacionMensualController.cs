using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;
using MathNet.Numerics.Distributions;

namespace SistemaExperto.Controllers
{
    public class EstacionMensualController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /EstacionMensual/
        public ActionResult Index(int id = 0)
        {
            var datosEstacion = db.EstacionMensual.Include(p => p.Estacion).Where(c => c.EstacionId == id);
            ViewBag.idEstacion = id;
            return View(datosEstacion.ToList());
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            int EstacionId = int.Parse(Request.QueryString["EstacionId"]);

            IEnumerable<EstacionMensual> filteredCompanies = db.EstacionMensual;
            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.EstacionMensual.Where(c => c.EstacionId == EstacionId)
                         .Where(c =>
                          c.Estacion.Nombre.Contains(param.sSearch)
                                     ||
                                      c.Fecha.Year.ToString().Contains(param.sSearch)
                                     );

            }
            else
            {
                filteredCompanies = db.EstacionMensual.Where(c => c.EstacionId == EstacionId);
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<EstacionMensual, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Estacion.Nombre :
                                                                sortColumnIndex == 2 ? Convert.ToString(c.Tmin) :
                                                                 Convert.ToString(c.Tmax));

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredCompanies = filteredCompanies.OrderBy(orderingFunction);
            else
                filteredCompanies = filteredCompanies.OrderByDescending(orderingFunction);
            // fin para orden
            var displayedCompanies = filteredCompanies
                        .Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);
            //var fecha = displayedCompanies.Select(c => c.Fecha).ToString();
            //string Fecha = String.Format("{0:MM/dd/yy}", displayedCompanies.Select(c => c.Fecha).ToString());
            //var Fecha = displayedCompanies.Select(c => DateTime.ParseExact(c.Fecha, "yyyyMMdd"));
            //var Fecha = DateTime.ParseExact(fecha, "yyyyMMDD", '');
            //var Fecha = fecha.ToString("d");
            //fecha = DateTime.Parse(fecha);
            // DateTime dt = DateTime.Parse(Fecha);

            var result = displayedCompanies
                .Select(c => new { c.EstacionMensualId, c.Estacion.Nombre, c.Fecha.Date.Year, c.Fecha.Date.Month, c.Tmin, c.Tmax, c.Precipitacion, c.ETo });

            //.Select(c => new { c.EstacionMensualId, c.Estacion.Nombre, fecha, c.Tmin, c.Tmax });
            //ok .Select(c => new { c.EstacionMensualId, c.Estacion.Nombre, c.Fecha, c.Tmin, c.Tmax });

            // .Select(c => new { c.EstacionMensualId, c.Estacion.Nombre, dt, c.Tmin, c.Tmax });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.EstacionMensual.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                            JsonRequestBehavior.AllowGet);
        }

        // GET: /EstacionMensual/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionMensual datosEstacion = db.EstacionMensual.Find(id);

            if (datosEstacion.CategoriaProbabilidadId > 0)
            {

                var datoCategoria = from s in db.CategoriaProbabilidad
                                    where (s.CategoriaProbabilidadId == datosEstacion.CategoriaProbabilidadId)
                                    select s.Descripcion;
                string categoria = datoCategoria.First();
                ViewBag.Categoria = categoria;
            }
            if (datosEstacion == null)
            {
                return HttpNotFound();
            }
            return View(datosEstacion);
        }

        // GET: /EstacionMensual/Crear
        public ActionResult Crear(int? id)
        {
            //Búsqueda de la estación correspondiente para asignar datos
            Estacion estacion = db.Estacion.Find(id);
            if (estacion != null)
            {
                //SistemaExperto envía la variable con el valor seleccionado de la estación
                ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", estacion.EstacionId);
            }
            else
            {
                ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre");
            }

            return View();
        }

        // POST: /EstacionMensual/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "EstacionMensualId,EstacionId,Fecha,Tmin,Tmax,Viento,Precipitacion,ETo,SPI,pptDebajo,pptDentro,pptSobre,ProbabilidadPpt,TminReal,TmaxReal,VientoReal,PrecipitacionReal,EToReal,SPIReal,ValorMinimo,ValorMaximo")] EstacionMensual datosEstacion)
        {
            // Consulta en BD para existencia de datos con la misma fecha y estación
            IEnumerable<EstacionMensual> listaDatos = db.EstacionMensual.Where(em => em.Fecha.Year == datosEstacion.Fecha.Year && em.Fecha.Month == datosEstacion.Fecha.Month && em.EstacionId == datosEstacion.EstacionId);

            // Si existen datos SistemaExperto envía mensaje de error. Si no, SistemaExperto crea el registro
            if (listaDatos.Count() == 0)
            {
                // Validación de datos de temperatura
                //if (datosEstacion.Tmax >= datosEstacion.Tmin)
                //{
                if (ModelState.IsValid)
                {
                    int diasMes = System.DateTime.DaysInMonth(datosEstacion.Fecha.Year, datosEstacion.Fecha.Month);

                    double totalETo;
                    double totalEToReal;

                    if ((datosEstacion.Viento != null) && (datosEstacion.Tmax != null) && (datosEstacion.Tmin != null))
                    {
                        totalETo = 0;
                        for (int dia = 0; dia < diasMes; dia++)
                        {
                            DateTime fecha = new DateTime(datosEstacion.Fecha.Year, datosEstacion.Fecha.Month, dia + 1);
                            totalETo = totalETo + CalcularEToDiario(datosEstacion, fecha);
                        }

                        datosEstacion.ETo = totalETo;
                    }

                    if ((datosEstacion.VientoReal == null) || (datosEstacion.TmaxReal == null) || (datosEstacion.TminReal == null) || (datosEstacion.PrecipitacionReal == null))
                    {
                        datosEstacion.VientoReal = datosEstacion.Viento;
                        datosEstacion.TmaxReal = datosEstacion.Tmax;
                        datosEstacion.TminReal = datosEstacion.Tmin;
                        datosEstacion.PrecipitacionReal = datosEstacion.Precipitacion;
                    }
                    else
                    {
                        totalEToReal = 0;
                        for (int dia = 0; dia < diasMes; dia++)
                        {
                            DateTime fecha = new DateTime(datosEstacion.Fecha.Year, datosEstacion.Fecha.Month, dia + 1);
                            totalEToReal = totalEToReal + CalcularEToDiarioReal(datosEstacion, fecha);
                        }
                        datosEstacion.EToReal = totalEToReal;
                    }

                    //evalua si en la vista de crear se asignaron los datos de pptsobre, pptdebajo y pptDentro, en caso
                    //de no ser asi asigna valor por default de 4( corresponde a <<Dato no calculado>> de tabla de parametros)
                    if (datosEstacion.pptSobre == 0 && datosEstacion.pptDebajo == 0 && datosEstacion.pptDentro == 0)
                    {
                        datosEstacion.CategoriaProbabilidadId = 4;
                    }
                    else
                    {
                        datosEstacion.ProbabilidadPpt = CalcularProbabilidadPpt(datosEstacion);
                        datosEstacion.CategoriaProbabilidadId = (int)TempData["IdCategoria"];
                    }

                    //# CambioPalmerSPI
                    if (datosEstacion.SPI != 0) { datosEstacion.ExistePrediccion = true; }
                    else { datosEstacion.ExistePrediccion = false; }

                    db.EstacionMensual.Add(datosEstacion);
                    db.SaveChanges();

                    EstacionMensual estacionMensual = db.EstacionMensual.Where(em => em.EstacionId == datosEstacion.EstacionId && em.Fecha.Month == datosEstacion.Fecha.Month && em.Fecha.Year == datosEstacion.Fecha.Year).FirstOrDefault();

                    if (datosEstacion.PrecipitacionReal != null)
                    {
                        int indicadorRecalculo = RecalcularEstacionValor(12, estacionMensual.Fecha.Year, estacionMensual.EstacionId, (double)datosEstacion.PrecipitacionReal);
                    }
                    else
                    {
                        int indicadorRecalculo = RecalcularEstacionValor(12, estacionMensual.Fecha.Year, estacionMensual.EstacionId, datosEstacion.Precipitacion);
                    }

                    datosEstacion.SPI = CalcularSPI(datosEstacion);

                    //#CambioPalmerSPI 
                    if (datosEstacion.SPI != 0) { datosEstacion.ExistePrediccion = true; }
                    else { datosEstacion.ExistePrediccion = false; }

                    estacionMensual.SPI = datosEstacion.SPI;

                    //si precipitacionReal es nulo: No calcula SPIReal
                    if (datosEstacion.PrecipitacionReal != null)
                    {
                        datosEstacion.SPIReal = CalcularSPIReal(datosEstacion);
                        estacionMensual.SPIReal = datosEstacion.SPIReal;
                    }

                    db.Entry(estacionMensual).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("/Detalles/" + datosEstacion.EstacionMensualId);
                }
            }
            else
            {
                ViewBag.MensajeError = "Ya se registraron datos para la estación y mes seleccionado";
            }

            ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", datosEstacion.EstacionId);
            return View(datosEstacion);
        }

        public int RecalcularEstacionValor(int mesRegistro, int anioRegistro, int idEstacion, double PPTActual)
        {
            int indicaRegistro = 0;
            //-- CONSTANTE M
            //busca id de la constante m
            var buscaIdTipoConstanteM = from etip in db.EstacionTipoConstante
                                        where etip.Nombre == "m"
                                        select etip.EstacionTipoConstanteId;
            int idTipoConstanteM = buscaIdTipoConstanteM.FirstOrDefault();

            //busca id del valor de constante m para el año
            var buscaRegistroEstacionValor = from ev in db.EstacionValores
                                             where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteM
                                             select ev.EstacionValoresId;
            if (buscaRegistroEstacionValor != null && buscaRegistroEstacionValor.Count() > 0)
            {
                EstacionValores datosEstacionRecalcula = new EstacionValores();
                int idEstacionValor = buscaRegistroEstacionValor.FirstOrDefault();
                //actualiza registro de valores de la constante
                datosEstacionRecalcula = db.EstacionValores.Find(idEstacionValor);
                //EstacionValores datosEstacionRecalcula = db.EstacionValores.Find(idEstacionValor);
                datosEstacionRecalcula = preparaEstacionValoresM(datosEstacionRecalcula, anioRegistro, mesRegistro, idEstacion, PPTActual);
                datosEstacionRecalcula.EstacionTipoConstanteId = idTipoConstanteM;
                db.Entry(datosEstacionRecalcula).State = EntityState.Modified;
                db.SaveChanges();

                // busca si relacion estacion-valor constante existe
                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValor
                                              && ec.EstacionId == idEstacion
                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante != null && buscaEstacionConstante.Count() == 0)
                {
                    //  inserta relacion estacion valor constante
                    EstacionConstantes estacionConstante = new EstacionConstantes();
                    estacionConstante.EstacionId = idEstacion;

                    estacionConstante.EstacionValoresId = idEstacionValor;
                    db.EstacionConstantes.Add(estacionConstante);
                    db.SaveChanges();
                }


            }
            else
            { // si no existe el valor de la constante para el año.. crea registro
                EstacionValores datosEstacionRecalcula = new EstacionValores();

                datosEstacionRecalcula = preparaEstacionValoresM(datosEstacionRecalcula, anioRegistro, mesRegistro, idEstacion, PPTActual);

                datosEstacionRecalcula.EstacionTipoConstanteId = buscaIdTipoConstanteM.FirstOrDefault();
                db.EstacionValores.Add(datosEstacionRecalcula);
                db.SaveChanges();

                // busca id del registro creado de EstacionValores
                var buscaInsertadoEstacionValor = from ev in db.EstacionValores
                                                  where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteM
                                                  select ev.EstacionValoresId;

                int idEstacionValoresNuevo = buscaInsertadoEstacionValor.FirstOrDefault();

                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValoresNuevo

                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante.Count() == 0)
                {
                    // SI no existe, inserta relacion de valor de constante-estacion 
                    EstacionConstantes estacionConstante = new EstacionConstantes();
                    estacionConstante.EstacionId = idEstacion;
                    // estacionConstante.EstacionTipoConstanteId = idTipoConstanteM;
                    estacionConstante.EstacionValoresId = idEstacionValoresNuevo;
                    db.EstacionConstantes.Add(estacionConstante);
                    db.SaveChanges();
                }
            }

            //CONSTANTE N

            //busca id de la constante n
            var buscaIdTipoConstanteN = from etip in db.EstacionTipoConstante
                                        where etip.Nombre == "n"
                                        select etip.EstacionTipoConstanteId;
            int idTipoConstanteN = buscaIdTipoConstanteN.FirstOrDefault();

            //busca id del valor de constante -N para el año EstacionValores
            var buscaRegistroEstacionValorN = from ev in db.EstacionValores
                                              where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteN
                                              select ev.EstacionValoresId;
            if (buscaRegistroEstacionValorN != null && buscaRegistroEstacionValorN.Count() > 0)
            {
                EstacionValores datosEstacionRecalculaN = new EstacionValores();
                int idEstacionValorN = buscaRegistroEstacionValorN.FirstOrDefault();
                //actualiza registro de valores de la constante EstacionValores
                //EstacionValores datosEstacionRecalculaN = db.EstacionValores.Find(idEstacionValorN);
                datosEstacionRecalculaN = db.EstacionValores.Find(idEstacionValorN);
                datosEstacionRecalculaN = preparaEstacionValoresN(datosEstacionRecalculaN, anioRegistro, idEstacion, idTipoConstanteM);
                datosEstacionRecalculaN.EstacionTipoConstanteId = idTipoConstanteN;
                db.Entry(datosEstacionRecalculaN).State = EntityState.Modified;
                db.SaveChanges();

                // busca si relacion estacion-valor constante existe - EstacionConstante
                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValorN
                                              && ec.EstacionId == idEstacion
                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante != null && buscaEstacionConstante.Count() == 0)
                {
                    //  inserta relacion estacion valor constante EstacionConstante
                    EstacionConstantes estacionConstanteN = new EstacionConstantes();
                    estacionConstanteN.EstacionId = idEstacion;

                    estacionConstanteN.EstacionValoresId = idEstacionValorN;
                    db.EstacionConstantes.Add(estacionConstanteN);
                    db.SaveChanges();
                }


            }
            else
            { // si no existe el valor de la constante para el año.. crea registro
                EstacionValores datosEstacionRecalcula = new EstacionValores();

                datosEstacionRecalcula = preparaEstacionValoresN(datosEstacionRecalcula, anioRegistro, idEstacion, idTipoConstanteM);

                datosEstacionRecalcula.EstacionTipoConstanteId = idTipoConstanteN;
                db.EstacionValores.Add(datosEstacionRecalcula);
                db.SaveChanges();

                // busca id del registro creado de EstacionValores
                var buscaInsertadoEstacionValor = from ev in db.EstacionValores
                                                  where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteN
                                                  select ev.EstacionValoresId;

                int idEstacionValoresNuevo = buscaInsertadoEstacionValor.FirstOrDefault();

                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValoresNuevo

                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante.Count() == 0)
                {
                    // SI no existe, inserta relacion de valor de constante-estacion 
                    EstacionConstantes estacionConstante = new EstacionConstantes();
                    estacionConstante.EstacionId = idEstacion;

                    estacionConstante.EstacionValoresId = idEstacionValoresNuevo;
                    db.EstacionConstantes.Add(estacionConstante);
                    db.SaveChanges();
                }
            }

            //
            //CONSTANTE q

            //busca id de la constante Q
            var buscaIdTipoConstanteQ = from etip in db.EstacionTipoConstante
                                        where etip.Nombre == "q"
                                        select etip.EstacionTipoConstanteId;
            int idTipoConstanteQ = buscaIdTipoConstanteQ.FirstOrDefault();

            //busca id del valor de constante -Q para el año
            var buscaRegistroEstacionValorQ = from ev in db.EstacionValores
                                              where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteQ
                                              select ev.EstacionValoresId;
            if (buscaRegistroEstacionValorQ != null && buscaRegistroEstacionValorQ.Count() > 0)
            {
                EstacionValores datosEstacionRecalculaQ = new EstacionValores();

                int idEstacionValorQ = buscaRegistroEstacionValorQ.FirstOrDefault();
                //actualiza registro de valores de la constante
                //EstacionValores datosEstacionRecalculaQ = db.EstacionValores.Find(idEstacionValorQ);
                datosEstacionRecalculaQ = db.EstacionValores.Find(idEstacionValorQ);
                datosEstacionRecalculaQ = preparaEstacionValoresQ(datosEstacionRecalculaQ, anioRegistro, idTipoConstanteM, idTipoConstanteN);
                datosEstacionRecalculaQ.EstacionTipoConstanteId = idTipoConstanteQ;
                db.Entry(datosEstacionRecalculaQ).State = EntityState.Modified;
                db.SaveChanges();

                // busca si relacion estacion-valor constante existe
                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValorQ
                                              && ec.EstacionId == idEstacion
                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante != null && buscaEstacionConstante.Count() == 0)
                {
                    //  inserta relacion estacion valor constante
                    EstacionConstantes estacionConstanteQ = new EstacionConstantes();
                    estacionConstanteQ.EstacionId = idEstacion;

                    estacionConstanteQ.EstacionValoresId = idEstacionValorQ;
                    db.EstacionConstantes.Add(estacionConstanteQ);
                    db.SaveChanges();
                }


            }
            else
            { // si no existe el valor de la constante para el año.. crea registro
                EstacionValores datosEstacionRecalcula = new EstacionValores();

                datosEstacionRecalcula = preparaEstacionValoresQ(datosEstacionRecalcula, anioRegistro, idTipoConstanteM, idTipoConstanteN);

                datosEstacionRecalcula.EstacionTipoConstanteId = idTipoConstanteQ;
                db.EstacionValores.Add(datosEstacionRecalcula);
                db.SaveChanges();

                // busca id del registro creado de EstacionValores
                var buscaInsertadoEstacionValor = from ev in db.EstacionValores
                                                  where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteQ
                                                  select ev.EstacionValoresId;

                int idEstacionValoresNuevo = buscaInsertadoEstacionValor.FirstOrDefault();

                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValoresNuevo

                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante.Count() == 0)
                {
                    // SI no existe, inserta relacion de valor de constante-estacion 
                    EstacionConstantes estacionConstante = new EstacionConstantes();
                    estacionConstante.EstacionId = idEstacion;

                    estacionConstante.EstacionValoresId = idEstacionValoresNuevo;
                    db.EstacionConstantes.Add(estacionConstante);
                    db.SaveChanges();
                }
            }
            //
            //CONSTANTE P

            //busca id de la constante p
            var buscaIdTipoConstanteP = from etip in db.EstacionTipoConstante
                                        where etip.Nombre == "p"
                                        select etip.EstacionTipoConstanteId;
            int idTipoConstanteP = buscaIdTipoConstanteP.FirstOrDefault();

            //busca id del valor de constante -P para el año EstacionValores
            var buscaRegistroEstacionValorP = from ev in db.EstacionValores
                                              where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteP
                                              select ev.EstacionValoresId;
            if (buscaRegistroEstacionValorP != null && buscaRegistroEstacionValorP.Count() > 0)
            {
                EstacionValores datosEstacionRecalculaP = new EstacionValores();
                int idEstacionValorP = buscaRegistroEstacionValorP.FirstOrDefault();
                //actualiza registro de valores de la constante EstacionValores
                //EstacionValores datosEstacionRecalculaP = db.EstacionValores.Find(idEstacionValorP);
                datosEstacionRecalculaP = db.EstacionValores.Find(idEstacionValorP);
                datosEstacionRecalculaP = preparaEstacionValoresP(datosEstacionRecalculaP, anioRegistro, idEstacion, idTipoConstanteQ);
                datosEstacionRecalculaP.EstacionTipoConstanteId = idTipoConstanteP;
                db.Entry(datosEstacionRecalculaP).State = EntityState.Modified;
                db.SaveChanges();

                // busca si relacion estacion-valor constante existe - EstacionConstante
                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValorP
                                              && ec.EstacionId == idEstacion
                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante != null && buscaEstacionConstante.Count() == 0)
                {
                    //  inserta relacion estacion valor constante EstacionConstante
                    EstacionConstantes estacionConstanteP = new EstacionConstantes();
                    estacionConstanteP.EstacionId = idEstacion;

                    estacionConstanteP.EstacionValoresId = idEstacionValorP;
                    db.EstacionConstantes.Add(estacionConstanteP);
                    db.SaveChanges();
                }


            }
            else
            { // si no existe el valor de la constante para el año.. crea registro
                EstacionValores datosEstacionRecalcula = new EstacionValores();

                datosEstacionRecalcula = preparaEstacionValoresP(datosEstacionRecalcula, anioRegistro, idEstacion, idTipoConstanteQ);

                datosEstacionRecalcula.EstacionTipoConstanteId = idTipoConstanteP;
                db.EstacionValores.Add(datosEstacionRecalcula);
                db.SaveChanges();

                // busca id del registro creado de EstacionValores
                var buscaInsertadoEstacionValor = from ev in db.EstacionValores
                                                  where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteP
                                                  select ev.EstacionValoresId;

                int idEstacionValoresNuevo = buscaInsertadoEstacionValor.FirstOrDefault();

                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValoresNuevo

                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante.Count() == 0)
                {
                    // SI no existe, inserta relacion de valor de constante-estacion 
                    EstacionConstantes estacionConstante = new EstacionConstantes();
                    estacionConstante.EstacionId = idEstacion;

                    estacionConstante.EstacionValoresId = idEstacionValoresNuevo;
                    db.EstacionConstantes.Add(estacionConstante);
                    db.SaveChanges();
                }
            }
            //
            //CONSTANTE A

            //busca id de la constante A
            var buscaIdTipoConstanteA = from etip in db.EstacionTipoConstante
                                        where etip.Nombre == "A"
                                        select etip.EstacionTipoConstanteId;
            int idTipoConstanteA = buscaIdTipoConstanteA.FirstOrDefault();

            //busca id del valor de constante -A para el año EstacionValores
            var buscaRegistroEstacionValorA = from ev in db.EstacionValores
                                              where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteA
                                              select ev.EstacionValoresId;
            if (buscaRegistroEstacionValorA != null && buscaRegistroEstacionValorA.Count() > 0)
            {
                EstacionValores datosEstacionRecalculaA = new EstacionValores();
                int idEstacionValorA = buscaRegistroEstacionValorA.FirstOrDefault();
                //actualiza registro de valores de la constante EstacionValores
                //  EstacionValores datosEstacionRecalculaA = db.EstacionValores.Find(idEstacionValorA);
                datosEstacionRecalculaA = db.EstacionValores.Find(idEstacionValorA);
                datosEstacionRecalculaA = preparaEstacionValoresA(datosEstacionRecalculaA, anioRegistro, mesRegistro, idEstacion, idTipoConstanteN, PPTActual);
                datosEstacionRecalculaA.EstacionTipoConstanteId = idTipoConstanteA;
                db.Entry(datosEstacionRecalculaA).State = EntityState.Modified;
                db.SaveChanges();

                // busca si relacion estacion-valorconstante existe - EstacionConstante
                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValorA
                                              && ec.EstacionId == idEstacion
                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante != null && buscaEstacionConstante.Count() == 0)
                {
                    //  inserta relacion estacion valor constante EstacionConstante
                    EstacionConstantes estacionConstanteA = new EstacionConstantes();
                    estacionConstanteA.EstacionId = idEstacion;

                    estacionConstanteA.EstacionValoresId = idEstacionValorA;
                    db.EstacionConstantes.Add(estacionConstanteA);
                    db.SaveChanges();
                }


            }
            else
            { // si no existe el valor de la constante para el año.. crea registro
                EstacionValores datosEstacionRecalcula = new EstacionValores();

                datosEstacionRecalcula = preparaEstacionValoresA(datosEstacionRecalcula, anioRegistro, mesRegistro, idEstacion, idTipoConstanteN, PPTActual);

                datosEstacionRecalcula.EstacionTipoConstanteId = idTipoConstanteA;
                db.EstacionValores.Add(datosEstacionRecalcula);
                db.SaveChanges();

                // busca id del registro creado de EstacionValores
                var buscaInsertadoEstacionValor = from ev in db.EstacionValores
                                                  where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteA
                                                  select ev.EstacionValoresId;

                int idEstacionValoresNuevo = buscaInsertadoEstacionValor.FirstOrDefault();

                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValoresNuevo

                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante.Count() == 0)
                {
                    // SI no existe, inserta relacion de valor de constante-estacion 
                    EstacionConstantes estacionConstante = new EstacionConstantes();
                    estacionConstante.EstacionId = idEstacion;

                    estacionConstante.EstacionValoresId = idEstacionValoresNuevo;
                    db.EstacionConstantes.Add(estacionConstante);
                    db.SaveChanges();
                }
            }

            //
            //CONSTANTE ALFA

            //busca id de la constante Alfa
            var buscaIdTipoConstanteAlfa = from etip in db.EstacionTipoConstante
                                           where etip.Nombre == "Alfa"
                                           select etip.EstacionTipoConstanteId;
            int idTipoConstanteAlfa = buscaIdTipoConstanteAlfa.FirstOrDefault();

            //busca id del valor de constante -Alfa para el año EstacionValores
            var buscaRegistroEstacionValorAlfa = from ev in db.EstacionValores
                                                 where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteAlfa
                                                 select ev.EstacionValoresId;
            if (buscaRegistroEstacionValorAlfa != null && buscaRegistroEstacionValorAlfa.Count() > 0)
            {
                EstacionValores datosEstacionRecalculaAlfa = new EstacionValores();
                int idEstacionValorAlfa = buscaRegistroEstacionValorAlfa.FirstOrDefault();
                //actualiza registro de valores de la constante EstacionValores
                // EstacionValores datosEstacionRecalculaAlfa = db.EstacionValores.Find(idEstacionValorAlfa);
                datosEstacionRecalculaAlfa = db.EstacionValores.Find(idEstacionValorAlfa);
                datosEstacionRecalculaAlfa = preparaEstacionValoresAlfa(datosEstacionRecalculaAlfa, anioRegistro, idEstacion, idTipoConstanteA);
                datosEstacionRecalculaAlfa.EstacionTipoConstanteId = idTipoConstanteAlfa;
                db.Entry(datosEstacionRecalculaAlfa).State = EntityState.Modified;
                db.SaveChanges();

                // busca si relacion estacion-valor constante existe - EstacionConstante
                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValorAlfa
                                              && ec.EstacionId == idEstacion
                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante != null && buscaEstacionConstante.Count() == 0)
                {
                    //  inserta relacion estacion valor constante EstacionConstante
                    EstacionConstantes estacionConstanteAlfa = new EstacionConstantes();
                    estacionConstanteAlfa.EstacionId = idEstacion;

                    estacionConstanteAlfa.EstacionValoresId = idEstacionValorAlfa;
                    db.EstacionConstantes.Add(estacionConstanteAlfa);
                    db.SaveChanges();
                }


            }
            else
            { // si no existe el valor de la constante para el año.. crea registro en EstacionValores
                EstacionValores datosEstacionRecalcula = new EstacionValores();

                datosEstacionRecalcula = preparaEstacionValoresAlfa(datosEstacionRecalcula, anioRegistro, idEstacion, idTipoConstanteA);

                datosEstacionRecalcula.EstacionTipoConstanteId = idTipoConstanteAlfa;
                db.EstacionValores.Add(datosEstacionRecalcula);
                db.SaveChanges();

                // busca id del registro recien creado de EstacionValores
                var buscaInsertadoEstacionValor = from ev in db.EstacionValores
                                                  where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteAlfa
                                                  select ev.EstacionValoresId;

                int idEstacionValoresNuevo = buscaInsertadoEstacionValor.FirstOrDefault();

                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValoresNuevo

                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante.Count() == 0)
                {
                    // SI no existe, inserta relacion de valor de constante-estacion 
                    EstacionConstantes estacionConstante = new EstacionConstantes();
                    estacionConstante.EstacionId = idEstacion;

                    estacionConstante.EstacionValoresId = idEstacionValoresNuevo;
                    db.EstacionConstantes.Add(estacionConstante);
                    db.SaveChanges();
                }
            }

            //
            //CONSTANTE BETA

            //busca id de la constante Beta
            var buscaIdTipoConstanteBeta = from etip in db.EstacionTipoConstante
                                           where etip.Nombre == "Beta"
                                           select etip.EstacionTipoConstanteId;
            int idTipoConstanteBeta = buscaIdTipoConstanteBeta.FirstOrDefault();

            //busca id del valor de constante -Beta para el año EstacionValores
            var buscaRegistroEstacionValorBeta = from ev in db.EstacionValores
                                                 where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteBeta
                                                 select ev.EstacionValoresId;
            if (buscaRegistroEstacionValorBeta != null && buscaRegistroEstacionValorBeta.Count() > 0)
            {
                EstacionValores datosEstacionRecalculaBeta = new EstacionValores();
                int idEstacionValorBeta = buscaRegistroEstacionValorBeta.FirstOrDefault();
                //actualiza registro de valores de la constante EstacionValores
                datosEstacionRecalculaBeta = db.EstacionValores.Find(idEstacionValorBeta);
                datosEstacionRecalculaBeta = preparaEstacionValoresBeta(datosEstacionRecalculaBeta, anioRegistro, mesRegistro, idEstacion, idTipoConstanteN, idTipoConstanteAlfa, PPTActual);
                datosEstacionRecalculaBeta.EstacionTipoConstanteId = idTipoConstanteBeta;
                db.Entry(datosEstacionRecalculaBeta).State = EntityState.Modified;
                db.SaveChanges();

                // busca si relacion estacion-valor constante existe - EstacionConstante
                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValorBeta
                                              && ec.EstacionId == idEstacion
                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante != null && buscaEstacionConstante.Count() == 0)
                {
                    //  inserta relacion estacion valor constante EstacionConstante
                    EstacionConstantes estacionConstanteBeta = new EstacionConstantes();
                    estacionConstanteBeta.EstacionId = idEstacion;

                    estacionConstanteBeta.EstacionValoresId = idEstacionValorBeta;
                    db.EstacionConstantes.Add(estacionConstanteBeta);
                    db.SaveChanges();
                }


            }
            else
            { // si no existe el valor de la constante para el año.. crea registro en EstacionValores
                EstacionValores datosEstacionRecalcula = new EstacionValores();

                datosEstacionRecalcula = preparaEstacionValoresBeta(datosEstacionRecalcula, anioRegistro, mesRegistro, idEstacion, idTipoConstanteN, idTipoConstanteAlfa, PPTActual);

                datosEstacionRecalcula.EstacionTipoConstanteId = idTipoConstanteBeta;
                db.EstacionValores.Add(datosEstacionRecalcula);
                db.SaveChanges();

                // busca id del registro recien creado de EstacionValores
                var buscaInsertadoEstacionValor = from ev in db.EstacionValores
                                                  where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == idTipoConstanteBeta
                                                  select ev.EstacionValoresId;

                int idEstacionValoresNuevo = buscaInsertadoEstacionValor.FirstOrDefault();

                var buscaEstacionConstante = from ec in db.EstacionConstantes
                                             where ec.EstacionValoresId == idEstacionValoresNuevo

                                             select ec.EstacionConstantesId;


                if (buscaEstacionConstante.Count() == 0)
                {
                    // SI no existe, inserta relacion de valor de constante-estacion 
                    EstacionConstantes estacionConstante = new EstacionConstantes();
                    estacionConstante.EstacionId = idEstacion;

                    estacionConstante.EstacionValoresId = idEstacionValoresNuevo;
                    db.EstacionConstantes.Add(estacionConstante);
                    db.SaveChanges();
                }
            }



            indicaRegistro = 1;
            return indicaRegistro;
        }

        public int calculaM(int mes, int estacionId, int anioActual, int mesActual, double PPTActual)
        {
            int resultado = 0;

            //para el calculoM se cuenta <<precipitacionReal>> sin tener en cuenta el mes actual
            // y se suma la <<Precipitacion>> del mes actual si es cero
            if (mesActual == mes)
            {
                //Precipitacion Real de otros años
                var mReal = from em in db.EstacionMensual
                            where em.Fecha.Month == mes
                                 && em.PrecipitacionReal == 0
                                 && em.EstacionId == estacionId
                                 && em.Fecha.Year != anioActual
                            select em;
                resultado = mReal.Count();

                if (PPTActual.Equals(0))
                {
                    resultado = resultado + 1;
                }

            }
            else
            {
                // si el calculoM no es para el mes actual, se cuentan todas las precipitacionesReales en Cero
                var m = from em in db.EstacionMensual
                        where em.Fecha.Month == mes
                             && em.PrecipitacionReal == 0
                             && em.EstacionId == estacionId
                        select em;

                resultado = m.Count();

            }
            return resultado;
        }

        public EstacionValores preparaEstacionValoresM(EstacionValores datosEstacionRecalcula, int anioRegistro, int mesRegistro, int estacionId, double PPTActual)
        {
            datosEstacionRecalcula.Anio = anioRegistro;

            int indicaRegistroM1 = calculaM(1, estacionId, anioRegistro, mesRegistro, PPTActual);

            datosEstacionRecalcula.Enero = indicaRegistroM1;
            int indicaRegistroM2 = calculaM(2, estacionId, anioRegistro, mesRegistro, PPTActual);
            datosEstacionRecalcula.Febrero = indicaRegistroM2;
            int indicaRegistroM3 = calculaM(3, estacionId, anioRegistro, mesRegistro, PPTActual);
            datosEstacionRecalcula.Marzo = indicaRegistroM3;
            int indicaRegistroM4 = calculaM(4, estacionId, anioRegistro, mesRegistro, PPTActual);
            datosEstacionRecalcula.Abril = indicaRegistroM4;
            int indicaRegistroM5 = calculaM(5, estacionId, anioRegistro, mesRegistro, PPTActual);
            datosEstacionRecalcula.Mayo = indicaRegistroM5;
            int indicaRegistroM6 = calculaM(6, estacionId, anioRegistro, mesRegistro, PPTActual);
            datosEstacionRecalcula.Junio = indicaRegistroM6;
            int indicaRegistroM7 = calculaM(7, estacionId, anioRegistro, mesRegistro, PPTActual);
            datosEstacionRecalcula.Julio = indicaRegistroM7;
            int indicaRegistroM8 = calculaM(8, estacionId, anioRegistro, mesRegistro, PPTActual);
            datosEstacionRecalcula.Agosto = indicaRegistroM8;
            int indicaRegistroM9 = calculaM(9, estacionId, anioRegistro, mesRegistro, PPTActual);
            datosEstacionRecalcula.Septiembre = indicaRegistroM9;
            int indicaRegistroM10 = calculaM(10, estacionId, anioRegistro, mesRegistro, PPTActual);
            datosEstacionRecalcula.Octubre = indicaRegistroM10;
            int indicaRegistroM11 = calculaM(11, estacionId, anioRegistro, mesRegistro, PPTActual);
            datosEstacionRecalcula.Noviembre = indicaRegistroM11;
            int indicaRegistroM12 = calculaM(12, estacionId, anioRegistro, mesRegistro, PPTActual);
            datosEstacionRecalcula.Diciembre = indicaRegistroM12;

            return datosEstacionRecalcula;
        }

        public int calculaN(int mes, int estacionId, int anio, int tipoConstanteIdM)
        {
            int resultado = 0;
            float cuentaM = 0;
            var m = from em in db.EstacionMensual
                    where em.Fecha.Month == mes
                         && em.EstacionId == estacionId
                    select em;

            // busca el valor de M previamente calculado para el mes
            switch (mes)
            {
                case 1:
                    var nMes1 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Enero;
                    cuentaM = nMes1.FirstOrDefault();
                    break;
                case 2:
                    var nMes2 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Febrero;
                    cuentaM = nMes2.FirstOrDefault();
                    break;
                case 3:
                    var nMes3 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Marzo;
                    cuentaM = nMes3.FirstOrDefault();
                    break;
                case 4:
                    var nMes4 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Abril;
                    cuentaM = nMes4.FirstOrDefault();
                    break;
                case 5:
                    var nMes5 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Mayo;
                    cuentaM = nMes5.FirstOrDefault();
                    break;
                case 6:
                    var nMes6 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Junio;
                    cuentaM = nMes6.FirstOrDefault();
                    break;
                case 7:
                    var nMes7 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Julio;
                    cuentaM = nMes7.FirstOrDefault();
                    break;
                case 8:
                    var nMes8 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Agosto;
                    cuentaM = nMes8.FirstOrDefault();
                    break;
                case 9:
                    var nMes9 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Septiembre;
                    cuentaM = nMes9.FirstOrDefault();
                    break;
                case 10:
                    var nMes10 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                 select ev.Octubre;
                    cuentaM = nMes10.FirstOrDefault();
                    break;
                case 11:
                    var nMes11 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                 select ev.Noviembre;
                    cuentaM = nMes11.FirstOrDefault();
                    break;
                case 12:
                    var nMes12 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                 select ev.Diciembre;
                    cuentaM = nMes12.FirstOrDefault();
                    break;
                default:
                    cuentaM = 0;
                    break;
            }

            if (m.Count() > 0)
            {
                //n = total registros que aparecen en EstacionMensual - valor de M del mes
                resultado = m.Count() - System.Convert.ToInt32(cuentaM);
            }



            return resultado;
        }

        public EstacionValores preparaEstacionValoresN(EstacionValores datosEstacionRecalcula, int anioRegistro, int estacionId, int tipoConstanteM)
        {
            datosEstacionRecalcula.Anio = anioRegistro;

            int indicaRegistroN1 = calculaN(1, estacionId, anioRegistro, tipoConstanteM);

            datosEstacionRecalcula.Enero = indicaRegistroN1;
            int indicaRegistroN2 = calculaN(2, estacionId, anioRegistro, tipoConstanteM);
            datosEstacionRecalcula.Febrero = indicaRegistroN2;
            int indicaRegistroN3 = calculaN(3, estacionId, anioRegistro, tipoConstanteM);
            datosEstacionRecalcula.Marzo = indicaRegistroN3;
            int indicaRegistroN4 = calculaN(4, estacionId, anioRegistro, tipoConstanteM);
            datosEstacionRecalcula.Abril = indicaRegistroN4;
            int indicaRegistroN5 = calculaN(5, estacionId, anioRegistro, tipoConstanteM);
            datosEstacionRecalcula.Mayo = indicaRegistroN5;
            int indicaRegistroN6 = calculaN(6, estacionId, anioRegistro, tipoConstanteM);
            datosEstacionRecalcula.Junio = indicaRegistroN6;
            int indicaRegistroN7 = calculaN(7, estacionId, anioRegistro, tipoConstanteM);
            datosEstacionRecalcula.Julio = indicaRegistroN7;
            int indicaRegistroN8 = calculaN(8, estacionId, anioRegistro, tipoConstanteM);
            datosEstacionRecalcula.Agosto = indicaRegistroN8;
            int indicaRegistroN9 = calculaN(9, estacionId, anioRegistro, tipoConstanteM);
            datosEstacionRecalcula.Septiembre = indicaRegistroN9;
            int indicaRegistroN10 = calculaN(10, estacionId, anioRegistro, tipoConstanteM);
            datosEstacionRecalcula.Octubre = indicaRegistroN10;
            int indicaRegistroN11 = calculaN(11, estacionId, anioRegistro, tipoConstanteM);
            datosEstacionRecalcula.Noviembre = indicaRegistroN11;
            int indicaRegistroN12 = calculaN(12, estacionId, anioRegistro, tipoConstanteM);
            datosEstacionRecalcula.Diciembre = indicaRegistroN12;

            return datosEstacionRecalcula;
        }

        public double calculaQ(int mes, int anio, int tipoConstanteIdM, int tipoConstanteIdN)
        {
            double resultado = 0;
            double cuentaM = 0;
            double cuentaN = 0;


            switch (mes)
            {
                case 1:
                    var mMes1 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Enero;
                    cuentaM = mMes1.FirstOrDefault();
                    var nMes1 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Enero;
                    cuentaN = nMes1.FirstOrDefault();

                    break;
                case 2:
                    var mMes2 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Febrero;
                    cuentaM = mMes2.FirstOrDefault();
                    var nMes2 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Febrero;
                    cuentaN = nMes2.FirstOrDefault();
                    break;
                case 3:
                    var mMes3 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Marzo;
                    cuentaM = mMes3.FirstOrDefault();
                    var nMes3 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Marzo;
                    cuentaN = nMes3.FirstOrDefault();
                    break;
                case 4:
                    var mMes4 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Abril;
                    cuentaM = mMes4.FirstOrDefault();
                    var nMes4 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Abril;
                    cuentaN = nMes4.FirstOrDefault();

                    break;
                case 5:
                    var mMes5 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Mayo;
                    cuentaM = mMes5.FirstOrDefault();
                    var nMes5 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Mayo;
                    cuentaN = nMes5.FirstOrDefault();

                    break;
                case 6:
                    var mMes6 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Junio;
                    cuentaM = mMes6.FirstOrDefault();
                    var nMes6 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Junio;
                    cuentaN = nMes6.FirstOrDefault();
                    break;
                case 7:
                    var mMes7 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Julio;
                    cuentaM = mMes7.FirstOrDefault();
                    var nMes7 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Julio;
                    cuentaN = nMes7.FirstOrDefault();
                    break;
                case 8:
                    var mMes8 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Agosto;
                    cuentaM = mMes8.FirstOrDefault();
                    var nMes8 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Agosto;
                    cuentaN = nMes8.FirstOrDefault();
                    break;
                case 9:
                    var mMes9 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                select ev.Septiembre;
                    cuentaM = mMes9.FirstOrDefault();
                    var nMes9 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Septiembre;
                    cuentaN = nMes9.FirstOrDefault();
                    break;
                case 10:
                    var mMes10 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                 select ev.Octubre;
                    cuentaM = mMes10.FirstOrDefault();
                    var nMes10 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                 select ev.Septiembre;
                    cuentaN = nMes10.FirstOrDefault();

                    break;
                case 11:
                    var mMes11 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                 select ev.Noviembre;
                    cuentaM = mMes11.FirstOrDefault();
                    var nMes11 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                 select ev.Noviembre;
                    cuentaN = nMes11.FirstOrDefault();
                    break;
                case 12:
                    var mMes12 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdM
                                 select ev.Diciembre;
                    cuentaM = mMes12.FirstOrDefault();
                    var nMes12 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                 select ev.Diciembre;
                    cuentaN = nMes12.FirstOrDefault();
                    break;
                default:
                    cuentaM = 0;
                    cuentaN = 0;
                    break;
            }

            double deno = cuentaN + cuentaM;

            if (deno > 0)
            {
                // q = valor m / (valor n + valor m) por cada mes
                resultado = cuentaM / deno;
            }


            return resultado;
        }

        public EstacionValores preparaEstacionValoresQ(EstacionValores datosEstacionRecalcula, int anioRegistro, int tipoConstanteIDM, int tipoConstanteIDN)
        {
            datosEstacionRecalcula.Anio = anioRegistro;

            double indicaRegistroM1 = calculaQ(1, anioRegistro, tipoConstanteIDM, tipoConstanteIDN);

            datosEstacionRecalcula.Enero = (float)indicaRegistroM1;
            double indicaRegistroM2 = calculaQ(2, anioRegistro, tipoConstanteIDM, tipoConstanteIDN);
            datosEstacionRecalcula.Febrero = (float)indicaRegistroM2;
            double indicaRegistroM3 = calculaQ(3, anioRegistro, tipoConstanteIDM, tipoConstanteIDN);
            datosEstacionRecalcula.Marzo = (float)indicaRegistroM3;
            double indicaRegistroM4 = calculaQ(4, anioRegistro, tipoConstanteIDM, tipoConstanteIDN);
            datosEstacionRecalcula.Abril = (float)indicaRegistroM4;
            double indicaRegistroM5 = calculaQ(5, anioRegistro, tipoConstanteIDM, tipoConstanteIDN);
            datosEstacionRecalcula.Mayo = (float)indicaRegistroM5;
            double indicaRegistroM6 = calculaQ(6, anioRegistro, tipoConstanteIDM, tipoConstanteIDN);
            datosEstacionRecalcula.Junio = (float)indicaRegistroM6;
            double indicaRegistroM7 = calculaQ(7, anioRegistro, tipoConstanteIDM, tipoConstanteIDN);
            datosEstacionRecalcula.Julio = (float)indicaRegistroM7;
            double indicaRegistroM8 = calculaQ(8, anioRegistro, tipoConstanteIDM, tipoConstanteIDN);
            datosEstacionRecalcula.Agosto = (float)indicaRegistroM8;
            double indicaRegistroM9 = calculaQ(9, anioRegistro, tipoConstanteIDM, tipoConstanteIDN);
            datosEstacionRecalcula.Septiembre = (float)indicaRegistroM9;
            double indicaRegistroM10 = calculaQ(10, anioRegistro, tipoConstanteIDM, tipoConstanteIDN);
            datosEstacionRecalcula.Octubre = (float)indicaRegistroM10;
            double indicaRegistroM11 = calculaQ(11, anioRegistro, tipoConstanteIDM, tipoConstanteIDN);
            datosEstacionRecalcula.Noviembre = (float)indicaRegistroM11;
            double indicaRegistroM12 = calculaQ(12, anioRegistro, tipoConstanteIDM, tipoConstanteIDN);
            datosEstacionRecalcula.Diciembre = (float)indicaRegistroM12;



            return datosEstacionRecalcula;
        }
        //
        public double calculaP(int mes, int anio, int tipoConstanteIdQ)
        {
            double resultado = 0;
            double cuentaQ = 0;


            // busca el valor de Q previamente calculado para el mes
            switch (mes)
            {
                case 1:
                    var qMes1 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdQ
                                select ev.Enero;
                    cuentaQ = qMes1.FirstOrDefault();
                    break;
                case 2:
                    var qMes2 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdQ
                                select ev.Febrero;
                    cuentaQ = qMes2.FirstOrDefault();
                    break;
                case 3:
                    var qMes3 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdQ
                                select ev.Marzo;
                    cuentaQ = qMes3.FirstOrDefault();
                    break;
                case 4:
                    var qMes4 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdQ
                                select ev.Abril;
                    cuentaQ = qMes4.FirstOrDefault();
                    break;
                case 5:
                    var qMes5 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdQ
                                select ev.Mayo;
                    cuentaQ = qMes5.FirstOrDefault();
                    break;
                case 6:
                    var qMes6 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdQ
                                select ev.Junio;
                    cuentaQ = qMes6.FirstOrDefault();
                    break;
                case 7:
                    var qMes7 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdQ
                                select ev.Julio;
                    cuentaQ = qMes7.FirstOrDefault();
                    break;
                case 8:
                    var qMes8 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdQ
                                select ev.Agosto;
                    cuentaQ = qMes8.FirstOrDefault();
                    break;
                case 9:
                    var qMes9 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdQ
                                select ev.Septiembre;
                    cuentaQ = qMes9.FirstOrDefault();
                    break;
                case 10:
                    var qMes10 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdQ
                                 select ev.Octubre;
                    cuentaQ = qMes10.FirstOrDefault();
                    break;
                case 11:
                    var qMes11 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdQ
                                 select ev.Noviembre;
                    cuentaQ = qMes11.FirstOrDefault();
                    break;
                case 12:
                    var qMes12 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdQ
                                 select ev.Diciembre;
                    cuentaQ = qMes12.FirstOrDefault();
                    break;
                default:
                    cuentaQ = 0;
                    break;
            }


            //p = 1 - valor de Q del mes
            resultado = 1 - cuentaQ;




            return resultado;
        }

        public EstacionValores preparaEstacionValoresP(EstacionValores datosEstacionRecalcula, int anioRegistro, int estacionId, int tipoConstanteQ)
        {
            datosEstacionRecalcula.Anio = anioRegistro;

            double indicaRegistroQ1 = calculaP(1, anioRegistro, tipoConstanteQ);

            datosEstacionRecalcula.Enero = (float)indicaRegistroQ1;
            double indicaRegistroQ2 = calculaP(2, anioRegistro, tipoConstanteQ);
            datosEstacionRecalcula.Febrero = (float)indicaRegistroQ2;
            double indicaRegistroQ3 = calculaP(3, anioRegistro, tipoConstanteQ);
            datosEstacionRecalcula.Marzo = (float)indicaRegistroQ3;
            double indicaRegistroQ4 = calculaP(4, anioRegistro, tipoConstanteQ);
            datosEstacionRecalcula.Abril = (float)indicaRegistroQ4;
            double indicaRegistroQ5 = calculaP(5, anioRegistro, tipoConstanteQ);
            datosEstacionRecalcula.Mayo = (float)indicaRegistroQ5;
            double indicaRegistroQ6 = calculaP(6, anioRegistro, tipoConstanteQ);
            datosEstacionRecalcula.Junio = (float)indicaRegistroQ6;
            double indicaRegistroQ7 = calculaP(7, anioRegistro, tipoConstanteQ);
            datosEstacionRecalcula.Julio = (float)indicaRegistroQ7;
            double indicaRegistroQ8 = calculaP(8, anioRegistro, tipoConstanteQ);
            datosEstacionRecalcula.Agosto = (float)indicaRegistroQ8;
            double indicaRegistroQ9 = calculaP(9, anioRegistro, tipoConstanteQ);
            datosEstacionRecalcula.Septiembre = (float)indicaRegistroQ9;
            double indicaRegistroQ10 = calculaP(10, anioRegistro, tipoConstanteQ);
            datosEstacionRecalcula.Octubre = (float)indicaRegistroQ10;
            double indicaRegistroQ11 = calculaP(11, anioRegistro, tipoConstanteQ);
            datosEstacionRecalcula.Noviembre = (float)indicaRegistroQ11;
            double indicaRegistroQ12 = calculaP(12, anioRegistro, tipoConstanteQ);
            datosEstacionRecalcula.Diciembre = (float)indicaRegistroQ12;



            return datosEstacionRecalcula;
        }
        public double calculaA(int mes, int anioActual, int estacionId, int tipoConstanteIdN, int mesActual, double PPTActual)
        {

            //calcula LN de cada ppt donde el mes coincida:
            double resultado = 0;
            double cuentaN = 0;
            double sumaLN = 0;
            double sumaPPT = 0;

            if (mes == mesActual)
            {
                //calculo de LN  teniendo en cuenta la precipitacionReal de los meses anteriores y Precipitacion del mes actual

                //var m = from em in db.EstacionMensual
                //        where em.Fecha.Month == mes
                //        && em.Fecha.Year == anioActual
                //             && em.EstacionId == estacionId
                //        select em.Precipitacion;

                //sumaPPT = sumaPPT + m.FirstOrDefault();

                sumaPPT = sumaPPT + PPTActual;



                double LN = 0;

                // if (m.FirstOrDefault() != 0 )
                if (PPTActual != 0)
                {
                    LN = Math.Log(PPTActual);
                }

                sumaLN = sumaLN + LN;

                IEnumerable<EstacionMensual> emReal = from em in db.EstacionMensual
                                                      where em.Fecha.Month == mes
                                                      && em.Fecha.Year != anioActual
                                                           && em.EstacionId == estacionId
                                                      select em;

                for (int i = 0; i <= emReal.Count(); i++)
                {
                    foreach (var item in emReal.Skip(i).Take(1))
                    {
                        sumaPPT = sumaPPT + (double)item.PrecipitacionReal;
                        /* Cálculo de LN*/
                        double LNReal = 0;

                        if ((double)item.PrecipitacionReal != 0)
                        {
                            LNReal = Math.Log((double)item.PrecipitacionReal);
                        }

                        sumaLN = sumaLN + LNReal;

                    }
                }
            }
            else
            {
                //calculo de LN  teniendo en cuenta la precipitacionReal
                IEnumerable<EstacionMensual> emReal = from em in db.EstacionMensual
                                                      where em.Fecha.Month == mes
                                                      && em.EstacionId == estacionId
                                                      select em;

                for (int i = 0; i <= emReal.Count(); i++)
                {
                    foreach (var item in emReal.Skip(i).Take(1))
                    {
                        sumaPPT = sumaPPT + (double)item.PrecipitacionReal;
                        /* Cálculo de LN*/
                        double LNReal = 0;

                        if ((double)item.PrecipitacionReal != 0)
                        {
                            LNReal = Math.Log((double)item.PrecipitacionReal);
                        }

                        sumaLN = sumaLN + LNReal;

                    }
                }

            }

            //calcula n del mes:

            switch (mes)
            {
                case 1:
                    var nMes1 = from ev in db.EstacionValores
                                where ev.Anio == anioActual && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Enero;
                    cuentaN = nMes1.FirstOrDefault();
                    break;
                case 2:
                    var nMes2 = from ev in db.EstacionValores
                                where ev.Anio == anioActual && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Febrero;
                    cuentaN = nMes2.FirstOrDefault();
                    break;
                case 3:
                    var nMes3 = from ev in db.EstacionValores
                                where ev.Anio == anioActual && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Marzo;
                    cuentaN = nMes3.FirstOrDefault();
                    break;
                case 4:
                    var nMes4 = from ev in db.EstacionValores
                                where ev.Anio == anioActual && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Abril;
                    cuentaN = nMes4.FirstOrDefault();
                    break;
                case 5:
                    var nMes5 = from ev in db.EstacionValores
                                where ev.Anio == anioActual && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Mayo;
                    cuentaN = nMes5.FirstOrDefault();
                    break;
                case 6:
                    var nMes6 = from ev in db.EstacionValores
                                where ev.Anio == anioActual && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Junio;
                    cuentaN = nMes6.FirstOrDefault();
                    break;
                case 7:
                    var nMes7 = from ev in db.EstacionValores
                                where ev.Anio == anioActual && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Julio;
                    cuentaN = nMes7.FirstOrDefault();
                    break;
                case 8:
                    var nMes8 = from ev in db.EstacionValores
                                where ev.Anio == anioActual && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Agosto;
                    cuentaN = nMes8.FirstOrDefault();
                    break;
                case 9:
                    var nMes9 = from ev in db.EstacionValores
                                where ev.Anio == anioActual && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Septiembre;
                    cuentaN = nMes9.FirstOrDefault();
                    break;
                case 10:
                    var nMes10 = from ev in db.EstacionValores
                                 where ev.Anio == anioActual && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                 select ev.Octubre;
                    cuentaN = nMes10.FirstOrDefault();
                    break;
                case 11:
                    var nMes11 = from ev in db.EstacionValores
                                 where ev.Anio == anioActual && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                 select ev.Noviembre;
                    cuentaN = nMes11.FirstOrDefault();
                    break;
                case 12:
                    var nMes12 = from ev in db.EstacionValores
                                 where ev.Anio == anioActual && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                 select ev.Diciembre;
                    cuentaN = nMes12.FirstOrDefault();
                    break;
                default:
                    cuentaN = 0;
                    break;
            }

            if (cuentaN > 0 && sumaPPT > 0)
            {
                //A = LN (suma ppt de mes similar/n)-(suma cada LN de PPT del mes similar/n)
                resultado = Math.Log(sumaPPT / cuentaN) - (sumaLN / cuentaN);
            }

            return resultado;

        }

        public EstacionValores preparaEstacionValoresA(EstacionValores datosEstacionRecalcula, int anioRegistro, int mesRegistro, int estacionId, int tipoConstanteN, double PPTActual)
        {
            datosEstacionRecalcula.Anio = anioRegistro;

            double indicaRegistroA1 = calculaA(1, anioRegistro, estacionId, tipoConstanteN, mesRegistro, PPTActual);
            datosEstacionRecalcula.Enero = (float)indicaRegistroA1;
            double indicaRegistroA2 = calculaA(2, anioRegistro, estacionId, tipoConstanteN, mesRegistro, PPTActual);
            datosEstacionRecalcula.Febrero = (float)indicaRegistroA2;
            double indicaRegistroA3 = calculaA(3, anioRegistro, estacionId, tipoConstanteN, mesRegistro, PPTActual);
            datosEstacionRecalcula.Marzo = (float)indicaRegistroA3;
            double indicaRegistroA4 = calculaA(4, anioRegistro, estacionId, tipoConstanteN, mesRegistro, PPTActual);
            datosEstacionRecalcula.Abril = (float)indicaRegistroA4;
            double indicaRegistroA5 = calculaA(5, anioRegistro, estacionId, tipoConstanteN, mesRegistro, PPTActual);
            datosEstacionRecalcula.Mayo = (float)indicaRegistroA5;
            double indicaRegistroA6 = calculaA(6, anioRegistro, estacionId, tipoConstanteN, mesRegistro, PPTActual);
            datosEstacionRecalcula.Junio = (float)indicaRegistroA6;
            double indicaRegistroA7 = calculaA(7, anioRegistro, estacionId, tipoConstanteN, mesRegistro, PPTActual);
            datosEstacionRecalcula.Julio = (float)indicaRegistroA7;
            double indicaRegistroA8 = calculaA(8, anioRegistro, estacionId, tipoConstanteN, mesRegistro, PPTActual);
            datosEstacionRecalcula.Agosto = (float)indicaRegistroA8;
            double indicaRegistroA9 = calculaA(9, anioRegistro, estacionId, tipoConstanteN, mesRegistro, PPTActual);
            datosEstacionRecalcula.Septiembre = (float)indicaRegistroA9;
            double indicaRegistroA10 = calculaA(10, anioRegistro, estacionId, tipoConstanteN, mesRegistro, PPTActual);
            datosEstacionRecalcula.Octubre = (float)indicaRegistroA10;
            double indicaRegistroA11 = calculaA(11, anioRegistro, estacionId, tipoConstanteN, mesRegistro, PPTActual);
            datosEstacionRecalcula.Noviembre = (float)indicaRegistroA11;
            double indicaRegistroA12 = calculaA(12, anioRegistro, estacionId, tipoConstanteN, mesRegistro, PPTActual);
            datosEstacionRecalcula.Diciembre = (float)indicaRegistroA12;



            return datosEstacionRecalcula;
        }


        public double calculaAlfa(int mes, int anio, int tipoConstanteIdA)
        {
            double resultado = 0;
            double cuentaA = 0;


            // busca el valor de A previamente calculado para el mes
            switch (mes)
            {
                case 1:
                    var aMes1 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdA
                                select ev.Enero;
                    cuentaA = aMes1.FirstOrDefault();
                    break;
                case 2:
                    var aMes2 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdA
                                select ev.Febrero;
                    cuentaA = aMes2.FirstOrDefault();
                    break;
                case 3:
                    var aMes3 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdA
                                select ev.Marzo;
                    cuentaA = aMes3.FirstOrDefault();
                    break;
                case 4:
                    var aMes4 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdA
                                select ev.Abril;
                    cuentaA = aMes4.FirstOrDefault();
                    break;
                case 5:
                    var aMes5 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdA
                                select ev.Mayo;
                    cuentaA = aMes5.FirstOrDefault();
                    break;
                case 6:
                    var aMes6 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdA
                                select ev.Junio;
                    cuentaA = aMes6.FirstOrDefault();
                    break;
                case 7:
                    var aMes7 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdA
                                select ev.Julio;
                    cuentaA = aMes7.FirstOrDefault();
                    break;
                case 8:
                    var aMes8 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdA
                                select ev.Agosto;
                    cuentaA = aMes8.FirstOrDefault();
                    break;
                case 9:
                    var aMes9 = from ev in db.EstacionValores
                                where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdA
                                select ev.Septiembre;
                    cuentaA = aMes9.FirstOrDefault();
                    break;
                case 10:
                    var aMes10 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdA
                                 select ev.Octubre;
                    cuentaA = aMes10.FirstOrDefault();
                    break;
                case 11:
                    var aMes11 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdA
                                 select ev.Noviembre;
                    cuentaA = aMes11.FirstOrDefault();
                    break;
                case 12:
                    var aMes12 = from ev in db.EstacionValores
                                 where ev.Anio == anio && ev.EstacionTipoConstanteId == tipoConstanteIdA
                                 select ev.Diciembre;
                    cuentaA = aMes12.FirstOrDefault();
                    break;
                default:
                    cuentaA = 0;
                    break;
            }

            if (cuentaA > 0)
            {
                double raiz = Math.Sqrt((1 + (4 * cuentaA / 3)));
                resultado = (1 / (4 * cuentaA)) * (1 + raiz);
            }

            return resultado;
        }

        public EstacionValores preparaEstacionValoresAlfa(EstacionValores datosEstacionRecalcula, int anioRegistro, int estacionId, int tipoConstanteA)
        {
            datosEstacionRecalcula.Anio = anioRegistro;

            double indicaRegistroQ1 = calculaAlfa(1, anioRegistro, tipoConstanteA);

            datosEstacionRecalcula.Enero = (float)indicaRegistroQ1;
            double indicaRegistroQ2 = calculaAlfa(2, anioRegistro, tipoConstanteA);
            datosEstacionRecalcula.Febrero = (float)indicaRegistroQ2;
            double indicaRegistroQ3 = calculaAlfa(3, anioRegistro, tipoConstanteA);
            datosEstacionRecalcula.Marzo = (float)indicaRegistroQ3;
            double indicaRegistroQ4 = calculaAlfa(4, anioRegistro, tipoConstanteA);
            datosEstacionRecalcula.Abril = (float)indicaRegistroQ4;
            double indicaRegistroQ5 = calculaAlfa(5, anioRegistro, tipoConstanteA);
            datosEstacionRecalcula.Mayo = (float)indicaRegistroQ5;
            double indicaRegistroQ6 = calculaAlfa(6, anioRegistro, tipoConstanteA);
            datosEstacionRecalcula.Junio = (float)indicaRegistroQ6;
            double indicaRegistroQ7 = calculaAlfa(7, anioRegistro, tipoConstanteA);
            datosEstacionRecalcula.Julio = (float)indicaRegistroQ7;
            double indicaRegistroQ8 = calculaAlfa(8, anioRegistro, tipoConstanteA);
            datosEstacionRecalcula.Agosto = (float)indicaRegistroQ8;
            double indicaRegistroQ9 = calculaAlfa(9, anioRegistro, tipoConstanteA);
            datosEstacionRecalcula.Septiembre = (float)indicaRegistroQ9;
            double indicaRegistroQ10 = calculaAlfa(10, anioRegistro, tipoConstanteA);
            datosEstacionRecalcula.Octubre = (float)indicaRegistroQ10;
            double indicaRegistroQ11 = calculaAlfa(11, anioRegistro, tipoConstanteA);
            datosEstacionRecalcula.Noviembre = (float)indicaRegistroQ11;
            double indicaRegistroQ12 = calculaAlfa(12, anioRegistro, tipoConstanteA);
            datosEstacionRecalcula.Diciembre = (float)indicaRegistroQ12;
            return datosEstacionRecalcula;
        }

        //
        public double calculaBeta(int mes, int anioRegistro, int mesRegistro, int estacionId, int tipoConstanteIdN, int tipoConstanteIdAlfa, double PPTActual)
        {

            double resultado = 0;
            double cuentaN = 0;
            double cuentaAlfa = 0;

            double sumaPPT = 0;

            // si el mes de registro es igual al mes del calculo se tiene en cuenta la Precipitacion del mes y  la precipitacionReal de otros meses.

            if (mes == mesRegistro)
            {

                sumaPPT = sumaPPT + PPTActual;

                var mReal = from em in db.EstacionMensual
                            where em.Fecha.Month == mes
                                  && em.EstacionId == estacionId
                                  && em.Fecha.Year != anioRegistro
                            select em.PrecipitacionReal;

                sumaPPT = sumaPPT + (double)mReal.ToList().Sum();
            }
            else
            {
                var m = from em in db.EstacionMensual
                        where em.Fecha.Month == mes
                              && em.EstacionId == estacionId
                        select em.PrecipitacionReal;

                sumaPPT = (double)m.ToList().Sum();
            }

            switch (mes)
            {
                case 1:
                    var nMes1 = from ev in db.EstacionValores
                                where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Enero;
                    cuentaN = nMes1.FirstOrDefault();
                    var alfaMes1 = from ev in db.EstacionValores
                                   where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdAlfa
                                   select ev.Enero;
                    cuentaAlfa = alfaMes1.FirstOrDefault();
                    break;
                case 2:
                    var nMes2 = from ev in db.EstacionValores
                                where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Febrero;
                    cuentaN = nMes2.FirstOrDefault();
                    var alfaMes2 = from ev in db.EstacionValores
                                   where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdAlfa
                                   select ev.Febrero;
                    cuentaAlfa = alfaMes2.FirstOrDefault();
                    break;
                case 3:
                    var nMes3 = from ev in db.EstacionValores
                                where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Marzo;
                    cuentaN = nMes3.FirstOrDefault();
                    var alfaMes3 = from ev in db.EstacionValores
                                   where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdAlfa
                                   select ev.Marzo;
                    cuentaAlfa = alfaMes3.FirstOrDefault();
                    break;
                case 4:
                    var nMes4 = from ev in db.EstacionValores
                                where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Abril;
                    cuentaN = nMes4.FirstOrDefault();
                    var alfaMes4 = from ev in db.EstacionValores
                                   where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdAlfa
                                   select ev.Abril;
                    cuentaAlfa = alfaMes4.FirstOrDefault();
                    break;
                case 5:
                    var nMes5 = from ev in db.EstacionValores
                                where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Mayo;
                    cuentaN = nMes5.FirstOrDefault();
                    var alfaMes5 = from ev in db.EstacionValores
                                   where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdAlfa
                                   select ev.Mayo;
                    cuentaAlfa = alfaMes5.FirstOrDefault();
                    break;
                case 6:
                    var nMes6 = from ev in db.EstacionValores
                                where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Junio;
                    cuentaN = nMes6.FirstOrDefault();
                    var alfaMes6 = from ev in db.EstacionValores
                                   where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdAlfa
                                   select ev.Junio;
                    cuentaAlfa = alfaMes6.FirstOrDefault();
                    break;
                case 7:
                    var nMes7 = from ev in db.EstacionValores
                                where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Julio;
                    cuentaN = nMes7.FirstOrDefault();
                    var alfaMes7 = from ev in db.EstacionValores
                                   where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdAlfa
                                   select ev.Julio;
                    cuentaAlfa = alfaMes7.FirstOrDefault();
                    break;
                case 8:
                    var nMes8 = from ev in db.EstacionValores
                                where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Agosto;
                    cuentaN = nMes8.FirstOrDefault();
                    var alfaMes8 = from ev in db.EstacionValores
                                   where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdAlfa
                                   select ev.Agosto;
                    cuentaAlfa = alfaMes8.FirstOrDefault();
                    break;
                case 9:
                    var nMes9 = from ev in db.EstacionValores
                                where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                select ev.Septiembre;
                    cuentaN = nMes9.FirstOrDefault();
                    var alfaMes9 = from ev in db.EstacionValores
                                   where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdAlfa
                                   select ev.Septiembre;
                    cuentaAlfa = alfaMes9.FirstOrDefault();
                    break;
                case 10:
                    var nMes10 = from ev in db.EstacionValores
                                 where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                 select ev.Octubre;
                    cuentaN = nMes10.FirstOrDefault();
                    var alfaMes10 = from ev in db.EstacionValores
                                    where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdAlfa
                                    select ev.Octubre;
                    cuentaAlfa = alfaMes10.FirstOrDefault();
                    break;
                case 11:
                    var nMes11 = from ev in db.EstacionValores
                                 where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                 select ev.Noviembre;
                    cuentaN = nMes11.FirstOrDefault();
                    var alfaMes11 = from ev in db.EstacionValores
                                    where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdAlfa
                                    select ev.Noviembre;
                    cuentaAlfa = alfaMes11.FirstOrDefault();
                    break;
                case 12:
                    var nMes12 = from ev in db.EstacionValores
                                 where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdN
                                 select ev.Diciembre;
                    cuentaN = nMes12.FirstOrDefault();
                    var alfaMes12 = from ev in db.EstacionValores
                                    where ev.Anio == anioRegistro && ev.EstacionTipoConstanteId == tipoConstanteIdAlfa
                                    select ev.Diciembre;
                    cuentaAlfa = alfaMes12.FirstOrDefault();
                    break;
                default:
                    cuentaN = 0;
                    cuentaAlfa = 0;
                    break;
            }

            if (cuentaN > 0 && cuentaAlfa > 0 && sumaPPT > 0)
            {
                //Beta = (suma ppt de meses similares/n)/(Alfa)
                resultado = (sumaPPT / cuentaN) / cuentaAlfa;
            }

            return resultado;

        }

        public EstacionValores preparaEstacionValoresBeta(EstacionValores datosEstacionRecalcula, int anioRegistro, int mesRegistro, int estacionId, int tipoConstanteN, int tipoConstanteAlfa, double PPTActual)
        {
            datosEstacionRecalcula.Anio = anioRegistro;

            double indicaRegistroBeta1 = calculaBeta(1, anioRegistro, mesRegistro, estacionId, tipoConstanteN, tipoConstanteAlfa, PPTActual);

            datosEstacionRecalcula.Enero = (float)indicaRegistroBeta1;
            double indicaRegistroBeta2 = calculaBeta(2, anioRegistro, mesRegistro, estacionId, tipoConstanteN, tipoConstanteAlfa, PPTActual);
            datosEstacionRecalcula.Febrero = (float)indicaRegistroBeta2;
            double indicaRegistroBeta3 = calculaBeta(3, anioRegistro, mesRegistro, estacionId, tipoConstanteN, tipoConstanteAlfa, PPTActual);
            datosEstacionRecalcula.Marzo = (float)indicaRegistroBeta3;
            double indicaRegistroBeta4 = calculaBeta(4, anioRegistro, mesRegistro, estacionId, tipoConstanteN, tipoConstanteAlfa, PPTActual);
            datosEstacionRecalcula.Abril = (float)indicaRegistroBeta4;
            double indicaRegistroBeta5 = calculaBeta(5, anioRegistro, mesRegistro, estacionId, tipoConstanteN, tipoConstanteAlfa, PPTActual);
            datosEstacionRecalcula.Mayo = (float)indicaRegistroBeta5;
            double indicaRegistroBeta6 = calculaBeta(6, anioRegistro, mesRegistro, estacionId, tipoConstanteN, tipoConstanteAlfa, PPTActual);
            datosEstacionRecalcula.Junio = (float)indicaRegistroBeta6;
            double indicaRegistroBeta7 = calculaBeta(7, anioRegistro, mesRegistro, estacionId, tipoConstanteN, tipoConstanteAlfa, PPTActual);
            datosEstacionRecalcula.Julio = (float)indicaRegistroBeta7;
            double indicaRegistroBeta8 = calculaBeta(8, anioRegistro, mesRegistro, estacionId, tipoConstanteN, tipoConstanteAlfa, PPTActual);
            datosEstacionRecalcula.Agosto = (float)indicaRegistroBeta8;
            double indicaRegistroBeta9 = calculaBeta(9, anioRegistro, mesRegistro, estacionId, tipoConstanteN, tipoConstanteAlfa, PPTActual);
            datosEstacionRecalcula.Septiembre = (float)indicaRegistroBeta9;
            double indicaRegistroBeta10 = calculaBeta(10, anioRegistro, mesRegistro, estacionId, tipoConstanteN, tipoConstanteAlfa, PPTActual);
            datosEstacionRecalcula.Octubre = (float)indicaRegistroBeta10;
            double indicaRegistroBeta11 = calculaBeta(11, anioRegistro, mesRegistro, estacionId, tipoConstanteN, tipoConstanteAlfa, PPTActual);
            datosEstacionRecalcula.Noviembre = (float)indicaRegistroBeta11;
            double indicaRegistroBeta12 = calculaBeta(12, anioRegistro, mesRegistro, estacionId, tipoConstanteN, tipoConstanteAlfa, PPTActual);
            datosEstacionRecalcula.Diciembre = (float)indicaRegistroBeta12;



            return datosEstacionRecalcula;
        }
        // GET: /EstacionMensual/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionMensual datosEstacion = db.EstacionMensual.Find(id);
            if (datosEstacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", datosEstacion.EstacionId);
            return View(datosEstacion);
        }

        // POST: /EstacionMensual/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "EstacionMensualId,EstacionId,Fecha,Tmin,Tmax,Viento,Precipitacion,ETo,SPI,pptDebajo,pptDentro,pptSobre,ProbabilidadPpt,TminReal,TmaxReal,VientoReal,PrecipitacionReal,EToReal,SPIReal,ValorMinimo,ValorMaximo")] EstacionMensual datosEstacion)
        {
            EstacionMensual estacionMensual = db.EstacionMensual.Find(datosEstacion.EstacionMensualId);

            if (ModelState.IsValid)
            {
                estacionMensual.Fecha = datosEstacion.Fecha;

                //si viento, tmax o tmin son nulo: No calcula Eto
                if (datosEstacion.Viento != null && (datosEstacion.Tmax != null) && (datosEstacion.Tmin != null))
                {
                    estacionMensual.Viento = datosEstacion.Viento;
                    estacionMensual.Tmax = datosEstacion.Tmax;
                    estacionMensual.Tmin = datosEstacion.Tmin;
                    estacionMensual.ETo = CalcularETo(estacionMensual);
                }

                //si vientoReal, tmaxReal o tminReal son nulo: No calcula EtoReal
                if ((datosEstacion.VientoReal != null )&& (datosEstacion.TmaxReal != null) && (datosEstacion.TminReal != null))
                {
                    estacionMensual.VientoReal = datosEstacion.VientoReal;
                    estacionMensual.TmaxReal = datosEstacion.TmaxReal;
                    estacionMensual.TminReal = datosEstacion.TminReal;
                    estacionMensual.EToReal = CalcularEToReal(estacionMensual);
                    estacionMensual.PrecipitacionReal = datosEstacion.PrecipitacionReal;
                }

                if (!((datosEstacion.VientoReal == null) || (datosEstacion.TmaxReal == null) || (datosEstacion.TminReal == null) || (datosEstacion.PrecipitacionReal == null)))
                {
                    estacionMensual.VientoReal = datosEstacion.VientoReal;
                    estacionMensual.TmaxReal = datosEstacion.TmaxReal;
                    estacionMensual.TminReal = datosEstacion.TminReal;
                    estacionMensual.EToReal = CalcularEToReal(estacionMensual);
                    estacionMensual.PrecipitacionReal = datosEstacion.PrecipitacionReal;
                }
                else
                {
                    datosEstacion.VientoReal = estacionMensual.VientoReal;
                    datosEstacion.TmaxReal=estacionMensual.TmaxReal;
                    datosEstacion.TminReal=estacionMensual.TminReal;
                    datosEstacion.EToReal = estacionMensual.EToReal;
                    datosEstacion.PrecipitacionReal = estacionMensual.PrecipitacionReal;
                }

                estacionMensual.Precipitacion = datosEstacion.Precipitacion;
                estacionMensual.ValorMinimo = datosEstacion.ValorMinimo;
                estacionMensual.ValorMaximo = datosEstacion.ValorMaximo;

                //evalua si en la vista de editar se asignaron los datos de pptsobre, pptdebajo y pptDentro, en caso
                //de no ser asì asigna valor por default de 4( corresponde a <<Dato no calculado>> de tabla de parametros)
                estacionMensual.pptSobre = datosEstacion.pptSobre;
                estacionMensual.pptDebajo = datosEstacion.pptDebajo;
                estacionMensual.pptDentro = datosEstacion.pptDentro;

                if (estacionMensual.pptSobre == 0 && estacionMensual.pptDebajo == 0 && estacionMensual.pptDentro == 0)
                {

                    estacionMensual.CategoriaProbabilidadId = 4;
                }
                else
                {
                    estacionMensual.ProbabilidadPpt = CalcularProbabilidadPpt(estacionMensual);
                    estacionMensual.CategoriaProbabilidadId = (int)TempData["IdCategoria"];
                }

                if (datosEstacion.PrecipitacionReal != null)
                {
                    int indicadorRecalculo = RecalcularEstacionValor(12, estacionMensual.Fecha.Year, estacionMensual.EstacionId, (double)datosEstacion.PrecipitacionReal);
                }
                else
                {
                    int indicadorRecalculo = RecalcularEstacionValor(12, estacionMensual.Fecha.Year, estacionMensual.EstacionId, datosEstacion.Precipitacion);
                }


                db.Entry(estacionMensual).State = EntityState.Modified;
                db.SaveChanges();

                datosEstacion.SPI = CalcularSPI(datosEstacion);

               

                estacionMensual.SPI = datosEstacion.SPI;
                
                //#CambioPalmerSPI 
                if (datosEstacion.SPI != 0) { estacionMensual.ExistePrediccion = true; }
                else { estacionMensual.ExistePrediccion = false; }

                //si precipitacionReal es nulo: No calcula SPIReal
                if (datosEstacion.PrecipitacionReal != null)
                {
                    datosEstacion.SPIReal = CalcularSPIReal(datosEstacion);
                    estacionMensual.SPIReal = datosEstacion.SPIReal;
                }

                db.Entry(estacionMensual).State = EntityState.Modified;
                db.SaveChanges();

                ViewBag.Categoria = estacionMensual.CategoriaProbabilidadId;
                ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", estacionMensual.EstacionId);

                return RedirectToAction("Index/" + estacionMensual.EstacionId);
            }
            ViewBag.EstacionId = new SelectList(db.Estacion, "EstacionId", "Nombre", datosEstacion.EstacionId);
            return View(datosEstacion);
        }

        // GET: /EstacionMensual/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstacionMensual datosEstacion = db.EstacionMensual.Find(id);
            if (datosEstacion == null)
            {
                return HttpNotFound();
            }
            return View(datosEstacion);
        }

        // POST: /EstacionMensual/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            EstacionMensual datosEstacion = db.EstacionMensual.Find(id);
            db.EstacionMensual.Remove(datosEstacion);
            db.SaveChanges();
            return RedirectToAction("Index", id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /* Cálculo de ETo mensual*/
        public double CalcularETo(EstacionMensual datosEstacion)
        {
            /* Inicialización de variables para el cálculo */
            double ETo = 0;

            /* Variables de la estación */
            Estacion estacion = db.Estacion.Find(datosEstacion.EstacionId);
            double altura = estacion.Altitud;
            double latitud = estacion.Latitud;
            double viento = (double)datosEstacion.Viento;


            /* Temperatura media*/
            double tmed = ((double)datosEstacion.Tmax + (double)datosEstacion.Tmin) / 2;

            /* Cálculo de la presión de saturación
            /* e0: presión media de saturación de vapor, [kPa]
             */
            double e0 = 0.6108 * Math.Exp((17.27 * tmed) / (tmed + 237.3));

            /* Pendiente de la curva de presión de saturación de vapor
             * d: pendiente de la curva de presión de saturación de vapor, [kPa °C-1]
             */
            double d = (4098 * e0) / Math.Pow((tmed + 237.3), 2);

            /* Constante psicrométrica
             * g: constante psicrométrica [kPa °C-1]
             * presion: presión atmosférica local, [kPa]  
             */
            double presion = 101.3 * Math.Pow(((293 - 0.0065 * altura) / 293), 5.26);
            double g = (0.001013 * presion) / (0.622 * 2.45);

            /* Radiación solar extraterrestre
             * Ra: radiación solar extraterrestr, [mm/día]
             * phi: 
             * dias: cantidad de días del año
             * dr:
             * del: 
             * ws:
             * Gs:  % constante solar Mj m-2 min-1
             */
            double Gs = 0.082;
            double phi = latitud * Math.PI / 180;
            int dias = datosEstacion.Fecha.DayOfYear;
            double dr = 1 + (0.033 * Math.Cos(2 * Math.PI * dias / 365));
            double del = 0.409 * Math.Sin((2 * Math.PI * dias / 365) - 1.39);
            double ws = Math.Acos(-Math.Tan(phi) * Math.Tan(del));
            double Ra = (24 * 60 / Math.PI) * (Gs * dr) * ((ws * Math.Sin(phi) * Math.Sin(del)) + (Math.Cos(phi) * Math.Cos(del) * Math.Sin(ws)));

            /* Cálculo del déficit de presión de vapor, [kPa]
             * es:
             * ea:
             * eomin: 
             * eomax: 
             */
            double eomin = 0.6108 * Math.Exp((17.27 * (double)datosEstacion.Tmin) / ((double)datosEstacion.Tmin + 237.3));
            double eomax = 0.6108 * Math.Exp((17.27 * (double)datosEstacion.Tmax) / ((double)datosEstacion.Tmax + 237.3));
            double es = (eomin + eomax) / 2;
            double ea = eomin;

            /* Cálculo de Radiación neta
             * Rn: radiación neta, [MJ m-2 dia-1]
             * Rs: radiación solar incidente, [mm/día]
             * Rnl: radiación neta de onda larga
             * Rns: % radiación neta solar o de onda corta
             * alpha = % albedo
             * ks: 
             * s: % constante de stefan-boltzmann
             */
            double ks = 0.16;
            double alpha = 0.23;
            double s = 4.903 * Math.Pow(10, -9);
            double Rso = (0.75 + (2 * Math.Pow(10, -5) * altura)) * Ra;
            double Rs = ks * (Math.Pow(((double)datosEstacion.Tmax - (double)datosEstacion.Tmin), 0.5) * Ra);
            double Rnl = s * ((Math.Pow(((double)datosEstacion.Tmax + 273.16), 4) + Math.Pow(((double)datosEstacion.Tmin + 273.16), 4)) / 2) * (0.34 - 0.14 * Math.Pow(ea, 0.5)) * ((1.35 * (Rs / Rso)) - 0.35);
            double Rns = (1 - alpha) * Rs;
            double Rn = Rns - Rnl;

            /* Flujo de calor en el suelo
             * G: flujo de calor en el suelo, [MJ m-2 dia-1]
             */
            int G = 0;

            ETo = ((0.408 * d * (Rn - G)) + (g * (900 / (tmed + 273.15)) * viento * (es - ea))) / (d + (g * (1 + 0.34 * viento)));

            int diasMes = System.DateTime.DaysInMonth(datosEstacion.Fecha.Year, datosEstacion.Fecha.Month);
            ETo = Math.Round(ETo * diasMes, 4);


            return ETo;
        }
        public double CalcularEToReal(EstacionMensual datosEstacion)
        {
            /* Inicialización de variables para el cálculo */
            double ETo = 0;

            /* Variables de la estación */
            Estacion estacion = db.Estacion.Find(datosEstacion.EstacionId);
            double altura = estacion.Altitud;
            double latitud = estacion.Latitud;
            double viento = (double)datosEstacion.VientoReal;

            /* Temperatura media*/
            double tmed = ((double)datosEstacion.TmaxReal + (double)datosEstacion.TminReal) / 2;

            /* Cálculo de la presión de saturación
            /* e0: presión media de saturación de vapor, [kPa]
             */
            double e0 = 0.6108 * Math.Exp((17.27 * tmed) / (tmed + 237.3));

            /* Pendiente de la curva de presión de saturación de vapor
             * d: pendiente de la curva de presión de saturación de vapor, [kPa °C-1]
             */
            double d = (4098 * e0) / Math.Pow((tmed + 237.3), 2);

            /* Constante psicrométrica
             * g: constante psicrométrica [kPa °C-1]
             * presion: presión atmosférica local, [kPa]  
             */
            double presion = 101.3 * Math.Pow(((293 - 0.0065 * altura) / 293), 5.26);
            double g = (0.001013 * presion) / (0.622 * 2.45);

            /* Radiación solar extraterrestre
             * Ra: radiación solar extraterrestr, [mm/día]
             * phi: 
             * dias: cantidad de días del año
             * dr:
             * del: 
             * ws:
             * Gs:  % constante solar Mj m-2 min-1
             */
            double Gs = 0.082;
            double phi = latitud * Math.PI / 180;
            int dias = datosEstacion.Fecha.DayOfYear;
            double dr = 1 + (0.033 * Math.Cos(2 * Math.PI * dias / 365));
            double del = 0.409 * Math.Sin((2 * Math.PI * dias / 365) - 1.39);
            double ws = Math.Acos(-Math.Tan(phi) * Math.Tan(del));
            double Ra = (24 * 60 / Math.PI) * (Gs * dr) * ((ws * Math.Sin(phi) * Math.Sin(del)) + (Math.Cos(phi) * Math.Cos(del) * Math.Sin(ws)));

            /* Cálculo del déficit de presión de vapor, [kPa]
             * es:
             * ea:
             * eomin: 
             * eomax: 
             */
            double eomin = 0.6108 * Math.Exp((17.27 * (double)datosEstacion.TminReal) / ((double)datosEstacion.TminReal + 237.3));
            double eomax = 0.6108 * Math.Exp((17.27 * (double)datosEstacion.TmaxReal) / ((double)datosEstacion.TmaxReal + 237.3));
            double es = (eomin + eomax) / 2;
            double ea = eomin;

            /* Cálculo de Radiación neta Real
             * Rn: radiación neta, [MJ m-2 dia-1]
             * Rs: radiación solar incidente, [mm/día]
             * Rnl: radiación neta de onda larga
             * Rns: % radiación neta solar o de onda corta
             * alpha = % albedo
             * ks: 
             * s: % constante de stefan-boltzmann
             */
            double ks = 0.16;
            double alpha = 0.23;
            double s = 4.903 * Math.Pow(10, -9);
            double Rso = (0.75 + (2 * Math.Pow(10, -5) * altura)) * Ra;
            double Rs = ks * (Math.Pow(((double)datosEstacion.TmaxReal - (double)datosEstacion.TminReal), 0.5) * Ra);
            double Rnl = s * ((Math.Pow(((double)datosEstacion.TmaxReal + 273.16), 4) + Math.Pow(((double)datosEstacion.TminReal + 273.16), 4)) / 2) * (0.34 - 0.14 * Math.Pow(ea, 0.5)) * ((1.35 * (Rs / Rso)) - 0.35);
            double Rns = (1 - alpha) * Rs;
            double Rn = Rns - Rnl;

            /* Flujo de calor en el suelo
             * G: flujo de calor en el suelo, [MJ m-2 dia-1]
             */
            int G = 0;

            ETo = ((0.408 * d * (Rn - G)) + (g * (900 / (tmed + 273.15)) * viento * (es - ea))) / (d + (g * (1 + 0.34 * viento)));

            int diasMes = System.DateTime.DaysInMonth(datosEstacion.Fecha.Year, datosEstacion.Fecha.Month);
            ETo = Math.Round(ETo * diasMes, 4);

            return ETo;
        }

        /* Cálculo de ETo diario*/
        public double CalcularEToDiario(EstacionMensual datosEstacion, DateTime fecha)
        {
            /* Inicialización de variables para el cálculo */
            double ETo;

            /* Variables de la estación */
            Estacion estacion = db.Estacion.Find(datosEstacion.EstacionId);
            double altura = estacion.Altitud;
            double latitud = estacion.Latitud;
            double viento = (double)datosEstacion.Viento;

            //EstacionMensual datosEstacion2 = db.EstacionMensual.Where(em => em.EstacionId == datosEstacion.EstacionId && em.Fecha.Month == fecha.Month && em.Fecha.Year == fecha.Year).FirstOrDefault();

            /* Temperatura media*/
            double tmed = ((double)datosEstacion.Tmax + (double)datosEstacion.Tmin) / 2;

            /* Cálculo de la presión de saturación
            /* e0: presión media de saturación de vapor, [kPa]
             */
            double e0 = 0.6108 * Math.Exp((17.27 * tmed) / (tmed + 237.3));

            /* Pendiente de la curva de presión de saturación de vapor
             * d: pendiente de la curva de presión de saturación de vapor, [kPa °C-1]
             */
            double d = (4098 * e0) / Math.Pow((tmed + 237.3), 2);

            /* Constante psicrométrica
             * g: constante psicrométrica [kPa °C-1]
             * presion: presión atmosférica local, [kPa]  
             */
            double presion = 101.3 * Math.Pow(((293 - 0.0065 * altura) / 293), 5.26);
            double g = (0.001013 * presion) / (0.622 * 2.45);

            /* Radiación solar extraterrestre
             * Ra: radiación solar extraterrestr, [mm/día]
             * phi: 
             * dias: cantidad de días del año
             * dr:
             * del: 
             * ws:
             * Gs:  % constante solar Mj m-2 min-1
             */
            double Gs = 0.082;
            double phi = latitud * Math.PI / 180;
            int dias = fecha.DayOfYear;
            double dr = 1 + (0.033 * Math.Cos(2 * Math.PI * dias / 365));
            double del = 0.409 * Math.Sin((2 * Math.PI * dias / 365) - 1.39);
            double ws = Math.Acos(-Math.Tan(phi) * Math.Tan(del));
            double Ra = (24 * 60 / Math.PI) * (Gs * dr) * ((ws * Math.Sin(phi) * Math.Sin(del)) + (Math.Cos(phi) * Math.Cos(del) * Math.Sin(ws)));

            /* Cálculo del déficit de presión de vapor, [kPa]
             * es:
             * ea:
             * eomin: 
             * eomax: 
             */
            double eomin = 0.6108 * Math.Exp((17.27 * (double)datosEstacion.Tmin) / ((double)datosEstacion.Tmin + 237.3));
            double eomax = 0.6108 * Math.Exp((17.27 * (double)datosEstacion.Tmax) / ((double)datosEstacion.Tmax + 237.3));
            double es = (eomin + eomax) / 2;
            double ea = eomin;

            /* Cálculo de Radiación neta
             * Rn: radiación neta, [MJ m-2 dia-1]
             * Rs: radiación solar incidente, [mm/día]
             * Rnl: radiación neta de onda larga
             * Rns: % radiación neta solar o de onda corta
             * alpha = % albedo
             * ks: 
             * s: % constante de stefan-boltzmann
             */
            double ks = 0.16;
            double alpha = 0.23;
            double s = 4.903 * Math.Pow(10, -9);
            double Rso = (0.75 + (2 * Math.Pow(10, -5) * altura)) * Ra;
            double Rs = ks * (Math.Pow(((double)datosEstacion.Tmax - (double)datosEstacion.Tmin), 0.5) * Ra);
            double Rnl = s * ((Math.Pow(((double)datosEstacion.Tmax + 273.16), 4) + Math.Pow(((double)datosEstacion.Tmin + 273.16), 4)) / 2) * (0.34 - 0.14 * Math.Pow(ea, 0.5)) * ((1.35 * (Rs / Rso)) - 0.35);
            double Rns = (1 - alpha) * Rs;
            double Rn = Rns - Rnl;

            /* Flujo de calor en el suelo
             * G: flujo de calor en el suelo, [MJ m-2 dia-1]
             */
            int G = 0;

            ETo = Math.Round(((0.408 * d * (Rn - G)) + (g * (900 / (tmed + 273.15)) * viento * (es - ea))) / (d + (g * (1 + 0.34 * viento))), 4);

            return ETo;
        }
        /* Cálculo de ETo diario- con Datos Reales*/
        public double CalcularEToDiarioReal(EstacionMensual datosEstacion, DateTime fecha)
        {
            /* Inicialización de variables para el cálculo */
            double EToReal = 0;

            /* Variables de la estación */
            Estacion estacion = db.Estacion.Find(datosEstacion.EstacionId);
            double altura = estacion.Altitud;
            double latitud = estacion.Latitud;
            double vientoReal = (double)datosEstacion.VientoReal;

            //EstacionMensual datosEstacion2 = db.EstacionMensual.Where(em => em.EstacionId == datosEstacion.EstacionId && em.Fecha.Month == fecha.Month && em.Fecha.Year == fecha.Year).FirstOrDefault();

            /* Temperatura media*/
            double tmed = ((double)datosEstacion.TmaxReal + (double)datosEstacion.TminReal) / 2;

            /* Cálculo de la presión de saturación
            /* e0: presión media de saturación de vapor, [kPa]
             */
            double e0 = 0.6108 * Math.Exp((17.27 * tmed) / (tmed + 237.3));

            /* Pendiente de la curva de presión de saturación de vapor
             * d: pendiente de la curva de presión de saturación de vapor, [kPa °C-1]
             */
            double d = (4098 * e0) / Math.Pow((tmed + 237.3), 2);

            /* Constante psicrométrica
             * g: constante psicrométrica [kPa °C-1]
             * presion: presión atmosférica local, [kPa]  
             */
            double presion = 101.3 * Math.Pow(((293 - 0.0065 * altura) / 293), 5.26);
            double g = (0.001013 * presion) / (0.622 * 2.45);

            /* Radiación solar extraterrestre
             * Ra: radiación solar extraterrestr, [mm/día]
             * phi: 
             * dias: cantidad de días del año
             * dr:
             * del: 
             * ws:
             * Gs:  % constante solar Mj m-2 min-1
             */
            double Gs = 0.082;
            double phi = latitud * Math.PI / 180;
            int dias = fecha.DayOfYear;
            double dr = 1 + (0.033 * Math.Cos(2 * Math.PI * dias / 365));
            double del = 0.409 * Math.Sin((2 * Math.PI * dias / 365) - 1.39);
            double ws = Math.Acos(-Math.Tan(phi) * Math.Tan(del));
            double Ra = (24 * 60 / Math.PI) * (Gs * dr) * ((ws * Math.Sin(phi) * Math.Sin(del)) + (Math.Cos(phi) * Math.Cos(del) * Math.Sin(ws)));

            /* Cálculo del déficit de presión de vapor, [kPa]
             * es:
             * ea:
             * eomin: 
             * eomax: 
             */
            double eominReal = 0.6108 * Math.Exp((17.27 * (double)datosEstacion.TminReal) / ((double)datosEstacion.TminReal + 237.3));
            double eomaxReal = 0.6108 * Math.Exp((17.27 * (double)datosEstacion.TmaxReal) / ((double)datosEstacion.TmaxReal + 237.3));
            double esReal = (eominReal + eomaxReal) / 2;
            double eaReal = eominReal;

            /* Cálculo de Radiación neta
             * Rn: radiación neta, [MJ m-2 dia-1]
             * Rs: radiación solar incidente, [mm/día]
             * Rnl: radiación neta de onda larga
             * Rns: % radiación neta solar o de onda corta
             * alpha = % albedo
             * ks: 
             * s: % constante de stefan-boltzmann
             */
            double ks = 0.16;
            double alpha = 0.23;
            double s = 4.903 * Math.Pow(10, -9);
            double Rso = (0.75 + (2 * Math.Pow(10, -5) * altura)) * Ra;
            double Rs = ks * (Math.Pow(((double)datosEstacion.Tmax - (double)datosEstacion.Tmin), 0.5) * Ra);
            double Rnl = s * ((Math.Pow(((double)datosEstacion.Tmax + 273.16), 4) + Math.Pow(((double)datosEstacion.Tmin + 273.16), 4)) / 2) * (0.34 - 0.14 * Math.Pow(eaReal, 0.5)) * ((1.35 * (Rs / Rso)) - 0.35);
            double Rns = (1 - alpha) * Rs;
            double Rn = Rns - Rnl;

            /* Flujo de calor en el suelo
             * G: flujo de calor en el suelo, [MJ m-2 dia-1]
             */
            int G = 0;

            EToReal = Math.Round(((0.408 * d * (Rn - G)) + (g * (900 / (tmed + 273.15)) * vientoReal * (esReal - eaReal))) / (d + (g * (1 + 0.34 * vientoReal))), 4);

            return EToReal;
        }
        public double CalcularSPI(EstacionMensual datosEstacion)
        {
            /* Inicialización de variables para el cálculo */
            double SPI = 0;
            double LN = 0;
            float valorAlfa, valorBeta, valorP, valorQ;
            valorAlfa = valorBeta = valorP = valorQ = 0;

            /*Parametros*/
            double c0 = 2.515517;
            double c1 = 0.802853;
            double c2 = 0.010328;
            double d1 = 1.432788;
            double d2 = 0.189269;
            double d3 = 0.001308;

            /* Variables de la estación */
            int anno = datosEstacion.Fecha.Year;
            int mes = datosEstacion.Fecha.Month;
            double PPT = datosEstacion.Precipitacion;

            /* Cálculo de LN*/
            if (PPT != 0)
            {
                LN = Math.Log(PPT);
            }

            int valorIDAlfa = consultaIDEstacionValor("Alfa", datosEstacion.EstacionId, anno);

            /*Valor BETA*/
            int valorIDBeta = consultaIDEstacionValor("Beta", datosEstacion.EstacionId, anno);

            /*Valor q*/
            int valorIDq = consultaIDEstacionValor("q", datosEstacion.EstacionId, anno);

            /*Valor p*/
            int valorIDp = consultaIDEstacionValor("p", datosEstacion.EstacionId, anno);

            /*Buscando a partir del Id el valor de la constante en el mes*/
            // Departamento departamento = db.Departamento.Where(cd => cd.CodigoDane == codigoDane).FirstOrDefault();
            // EstacionValores departamento = db.EstacionValores.Where(cd => cd.EstacionValoresId == valorIDAlfa).FirstOrDefault();
            EstacionValores valoresAlfa = db.EstacionValores.Find(valorIDAlfa);
            EstacionValores valoresBeta = db.EstacionValores.Find(valorIDBeta);
            EstacionValores valoresq = db.EstacionValores.Find(valorIDq);
            EstacionValores valoresp = db.EstacionValores.Find(valorIDp);

            if (mes != 0)
            {
                switch (mes)
                {
                    case 1:
                        valorAlfa = valoresAlfa.Enero;
                        valorBeta = valoresBeta.Enero;
                        valorQ = valoresq.Enero;
                        valorP = valoresp.Enero;
                        break;
                    case 2:
                        valorAlfa = valoresAlfa.Febrero;
                        valorBeta = valoresBeta.Febrero;
                        valorQ = valoresq.Febrero;
                        valorP = valoresp.Febrero;
                        break;
                    case 3:
                        valorAlfa = valoresAlfa.Marzo;
                        valorBeta = valoresBeta.Marzo;
                        valorQ = valoresq.Marzo;
                        valorP = valoresp.Marzo;
                        break;
                    case 4:
                        valorAlfa = valoresAlfa.Abril;
                        valorBeta = valoresBeta.Abril;
                        valorQ = valoresq.Abril;
                        valorP = valoresp.Abril;
                        break;
                    case 5:
                        valorAlfa = valoresAlfa.Mayo;
                        valorBeta = valoresBeta.Mayo;
                        valorQ = valoresq.Mayo;
                        valorP = valoresp.Mayo;
                        break;
                    case 6:
                        valorAlfa = valoresAlfa.Junio;
                        valorBeta = valoresBeta.Junio;
                        valorQ = valoresq.Junio;
                        valorP = valoresp.Junio;
                        break;
                    case 7:
                        valorAlfa = valoresAlfa.Julio;
                        valorBeta = valoresBeta.Julio;
                        valorQ = valoresq.Julio;
                        valorP = valoresp.Julio;
                        break;
                    case 8:
                        valorAlfa = valoresAlfa.Agosto;
                        valorBeta = valoresBeta.Agosto;
                        valorQ = valoresq.Agosto;
                        valorP = valoresp.Agosto;
                        break;
                    case 9:
                        valorAlfa = valoresAlfa.Septiembre;
                        valorBeta = valoresBeta.Septiembre;
                        valorQ = valoresq.Septiembre;
                        valorP = valoresp.Septiembre;
                        break;
                    case 10:
                        valorAlfa = valoresAlfa.Octubre;
                        valorBeta = valoresBeta.Octubre;
                        valorQ = valoresq.Octubre;
                        valorP = valoresp.Octubre;
                        break;
                    case 11:
                        valorAlfa = valoresAlfa.Noviembre;
                        valorBeta = valoresBeta.Noviembre;
                        valorQ = valoresq.Noviembre;
                        valorP = valoresp.Noviembre;
                        break;
                    case 12:
                        valorAlfa = valoresAlfa.Diciembre;
                        valorBeta = valoresBeta.Diciembre;
                        valorQ = valoresq.Diciembre;
                        valorP = valoresp.Diciembre;
                        break;
                    default:
                        valorAlfa = 0;
                        valorBeta = 0;
                        valorQ = 0;
                        valorP = 0;
                        break;
                }
            }

            /*Calculo valores Gamma*/
            var valorGamma = MathNet.Numerics.Distributions.Gamma.CDF(valorAlfa, 1 / valorBeta, PPT);

            /* Calculo de H(x) */

            var Hx = valorQ + (valorP * valorGamma);

            /*Calculo t*/
            double valorHxElevado, t;

            if (Hx <= 0.5) { valorHxElevado = Math.Pow(Hx, 2); }
            else { valorHxElevado = Math.Pow((1 - Hx), 2); }

            if (valorHxElevado != 0)
            {
                //Calcular t
                t = System.Math.Sqrt(System.Math.Log(1 / valorHxElevado));

                /*Calculando SPI*/
                double numeradorSPI, denominadorSPI = 0;
                numeradorSPI = (c0 + (c1 * t) + (c2 * (Math.Pow(t, 2))));
                denominadorSPI = (1 + (d1 * t) + (d2 * (Math.Pow(t, 2))) + (d3 * (Math.Pow(t, 3))));

                if (Hx <= 0.5) { SPI = -(t - (numeradorSPI / denominadorSPI)); }
                else { SPI = (t - (numeradorSPI) / (denominadorSPI)); }

            }
            else { SPI = 0; }

            SPI = Math.Round(SPI, 2);
            return SPI;
        }

        public double CalcularSPIReal(EstacionMensual datosEstacion)
        {
            /* Inicialización de variables para el cálculo */
            double SPI = 0;
            double LN = 0;
            float valorAlfa, valorBeta, valorP, valorQ;
            valorAlfa = valorBeta = valorP = valorQ = 0;

            /*Parametros*/
            double c0 = 2.515517;
            double c1 = 0.802853;
            double c2 = 0.010328;
            double d1 = 1.432788;
            double d2 = 0.189269;
            double d3 = 0.001308;

            /* Variables de la estación */
            int anno = datosEstacion.Fecha.Year;
            int mes = datosEstacion.Fecha.Month;
            double PPT = (double)datosEstacion.PrecipitacionReal;

            /* Cálculo de LN*/
            if (PPT != 0)
            {
                LN = Math.Log(PPT);
            }

            int valorIDAlfa = consultaIDEstacionValor("Alfa", datosEstacion.EstacionId, anno);

            /*Valor BETA*/
            int valorIDBeta = consultaIDEstacionValor("Beta", datosEstacion.EstacionId, anno);

            /*Valor q*/
            int valorIDq = consultaIDEstacionValor("q", datosEstacion.EstacionId, anno);

            /*Valor p*/
            int valorIDp = consultaIDEstacionValor("p", datosEstacion.EstacionId, anno);

            /*Buscando a partir del Id el valor de la constante en el mes*/
            EstacionValores valoresAlfa = db.EstacionValores.Find(valorIDAlfa);
            EstacionValores valoresBeta = db.EstacionValores.Find(valorIDBeta);
            EstacionValores valoresq = db.EstacionValores.Find(valorIDq);
            EstacionValores valoresp = db.EstacionValores.Find(valorIDp);

            if (mes != 0)
            {
                switch (mes)
                {
                    case 1:
                        valorAlfa = valoresAlfa.Enero;
                        valorBeta = valoresBeta.Enero;
                        valorQ = valoresq.Enero;
                        valorP = valoresp.Enero;
                        break;
                    case 2:
                        valorAlfa = valoresAlfa.Febrero;
                        valorBeta = valoresBeta.Febrero;
                        valorQ = valoresq.Febrero;
                        valorP = valoresp.Febrero;
                        break;
                    case 3:
                        valorAlfa = valoresAlfa.Marzo;
                        valorBeta = valoresBeta.Marzo;
                        valorQ = valoresq.Marzo;
                        valorP = valoresp.Marzo;
                        break;
                    case 4:
                        valorAlfa = valoresAlfa.Abril;
                        valorBeta = valoresBeta.Abril;
                        valorQ = valoresq.Abril;
                        valorP = valoresp.Abril;
                        break;
                    case 5:
                        valorAlfa = valoresAlfa.Mayo;
                        valorBeta = valoresBeta.Mayo;
                        valorQ = valoresq.Mayo;
                        valorP = valoresp.Mayo;
                        break;
                    case 6:
                        valorAlfa = valoresAlfa.Junio;
                        valorBeta = valoresBeta.Junio;
                        valorQ = valoresq.Junio;
                        valorP = valoresp.Junio;
                        break;
                    case 7:
                        valorAlfa = valoresAlfa.Julio;
                        valorBeta = valoresBeta.Julio;
                        valorQ = valoresq.Julio;
                        valorP = valoresp.Julio;
                        break;
                    case 8:
                        valorAlfa = valoresAlfa.Agosto;
                        valorBeta = valoresBeta.Agosto;
                        valorQ = valoresq.Agosto;
                        valorP = valoresp.Agosto;
                        break;
                    case 9:
                        valorAlfa = valoresAlfa.Septiembre;
                        valorBeta = valoresBeta.Septiembre;
                        valorQ = valoresq.Septiembre;
                        valorP = valoresp.Septiembre;
                        break;
                    case 10:
                        valorAlfa = valoresAlfa.Octubre;
                        valorBeta = valoresBeta.Octubre;
                        valorQ = valoresq.Octubre;
                        valorP = valoresp.Octubre;
                        break;
                    case 11:
                        valorAlfa = valoresAlfa.Noviembre;
                        valorBeta = valoresBeta.Noviembre;
                        valorQ = valoresq.Noviembre;
                        valorP = valoresp.Noviembre;
                        break;
                    case 12:
                        valorAlfa = valoresAlfa.Diciembre;
                        valorBeta = valoresBeta.Diciembre;
                        valorQ = valoresq.Diciembre;
                        valorP = valoresp.Diciembre;
                        break;
                    default:
                        valorAlfa = 0;
                        valorBeta = 0;
                        valorQ = 0;
                        valorP = 0;
                        break;
                }
            }

            /*Calculo valores Gamma*/
            var valorGamma = MathNet.Numerics.Distributions.Gamma.CDF(valorAlfa, 1 / valorBeta, PPT);

            /* Calculo de H(x) */

            var Hx = valorQ + (valorP * valorGamma);

            /*Calculo t*/
            double valorHxElevado, t;

            if (Hx <= 0.5) { valorHxElevado = Math.Pow(Hx, 2); }
            else { valorHxElevado = Math.Pow((1 - Hx), 2); }

            if (valorHxElevado != 0)
            {
                //Calcular t
                t = System.Math.Sqrt(System.Math.Log(1 / valorHxElevado));

                /*Calculando SPI*/
                double numeradorSPI, denominadorSPI = 0;
                numeradorSPI = (c0 + (c1 * t) + (c2 * (Math.Pow(t, 2))));
                denominadorSPI = (1 + (d1 * t) + (d2 * (Math.Pow(t, 2))) + (d3 * (Math.Pow(t, 3))));

                if (Hx <= 0.5) { SPI = -(t - (numeradorSPI / denominadorSPI)); }
                else { SPI = (t - (numeradorSPI) / (denominadorSPI)); }

            }
            else { SPI = 0; }

            SPI = Math.Round(SPI, 2);
            return SPI;
        }

        public int consultaIDEstacionValor(string nombreConstante, int estacionId, int anio)
        {

            /*ALFA*/
            /*Buscando id de constante alfa en EstacionTipoConstante */


            int tipoConstanteID = (from s in db.EstacionTipoConstante
                                   where (s.Nombre == nombreConstante)
                                   select s.EstacionTipoConstanteId).First(); ;

            /*averiguar el ID de estacion valor para Alfa*/
            var estacionValorId = from n in db.EstacionConstantes
                                  join v in db.EstacionValores
                                  on n.EstacionValoresId equals v.EstacionValoresId
                                  where (v.EstacionTipoConstanteId == tipoConstanteID && n.EstacionId == estacionId && v.Anio == anio)
                                  //select n.EstacionConstantesId;
                                  select v.EstacionValoresId;

            int valorID = estacionValorId.First();

            return valorID;
        }
        public double CalcularProbabilidadPpt(EstacionMensual datosEstacion)
        {
            /* Inicialización de variables para el cálculo */

            double PPTDebajo = datosEstacion.pptDebajo;
            double PPTDentro = datosEstacion.pptDentro;
            double PPTSobre = datosEstacion.pptSobre;

            double resultadoProbabilidad = 0;

            /* Cálculo de probabilidad precipitacion
             SI(O(Y(B2>C2;C2>D2);Y(D2>C2;C2>B2));SI(B2>D2;B2;D2);C2)
             */
            if (((PPTDebajo > PPTDentro) && (PPTDentro > PPTSobre)) | ((PPTSobre > PPTDentro) && (PPTDentro > PPTDebajo)))
            {
                if (PPTDebajo > PPTSobre)
                {
                    resultadoProbabilidad = Math.Round(PPTDebajo, 1);

                    // se almacena en la temporal el 1 que indica DEBAJO (posterior consulta de nombre de categoria)
                    TempData["IdCategoria"] = 1;
                }
                else { resultadoProbabilidad = Math.Round(PPTSobre, 1); TempData["IdCategoria"] = 2; }

            }
            else { resultadoProbabilidad = Math.Round(PPTDentro, 1); TempData["IdCategoria"] = 3; }


            return resultadoProbabilidad;
        }

    }
}
