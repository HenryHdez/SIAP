using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaExperto.Models;
using System.Web.Mvc;
using System.Data.Entity;
using OfficeOpenXml;
using System.Data;

namespace SistemaExperto.Controllers
{
    public class ProductividadController : Controller
    {
        private SEEntities db = new SEEntities();
        private SistemaExperto.Controllers.ArchivoController archivo = new ArchivoController();
        private SistemaExperto.Controllers.EstacionMensualController estacionMensualC = new EstacionMensualController();

        //Fecha actual del sistema
        DateTime fechaActual = System.DateTime.Today;

        public ActionResult Productividad2()
        {
            return View();
        }
        public ActionResult Index()
        {
            //buscando Id usuario conectado
            string userid = User.Identity.Name.Split('|')[3];
            int userIDAutentica = Convert.ToInt32(userid);
            ViewBag.UsuarioAutentica = userIDAutentica;

            //Consulta de cultivos registrados para productividad
            ViewBag.ListaCultivos = new List<Opcion>((from r in db.CultivoProductividad
                                                      orderby r.Cultivo.Nombre
                                                      select new Opcion
                                                      {
                                                          codigo = r.CultivoId,
                                                          nombre = r.Cultivo.Nombre
                                                      }).ToList().Distinct());

            ViewBag.ListaSuelos = new List<Opcion>((from e in db.SueloProductividad
                                                    select new Opcion
                                                    {
                                                        codigo = e.SueloProductividadId,
                                                        nombre = e.TipoSuelo.Nombre
                                                    }).ToList().Distinct());

            ViewBag.Consulta = false;

            ViewBag.CoordenadasDepartamentos = new List<Opcion>(
                from d in db.Departamento
                where d.Coordenadas != null
                select new Opcion
                {
                    codigo = d.DepartamentoId,
                    dato1 = d.Coordenadas,
                    dato2 = d.CodigoDane
                });

            return View(db.CultivoDepartamento.ToList());
        }

        public JsonResult ConsultaDepartamentos(int id)
        {
            //Consulta de departamentos en los que se tiene el cultivo con código id
            List<Opcion> listaDepartamentos =
                new List<Opcion>((from c in db.CultivoProductividad
                                  join cm in db.CultivoDepartamento on c.CultivoProductividadId equals cm.CultivoProductividadId
                                  join d in db.Departamento on cm.DepartamentoId equals d.DepartamentoId
                                  where cm.CultivoProductividad.CultivoId == id
                                  orderby d.Nombre
                                  select new Opcion
                                  {
                                      codigo = d.DepartamentoId,
                                      nombre = d.Nombre,
                                      dato1 = d.CodigoDane,
                                      dato2 = d.Coordenadas
                                  }).ToList().Distinct());

            return Json(listaDepartamentos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsultaEstaciones(int id)
        {
            List<Opcion> listaEstaciones =
                new List<Opcion>((from me in db.MunicipioEstacions
                                  join e in db.Estacion on me.EstacionId equals e.EstacionId
                                  join m in db.Municipio on me.MunicipioId equals m.MunicipioId
                                  join d in db.Departamento on m.DepartamentoId equals d.DepartamentoId
                                  join ep in db.EstacionProductividad on e.EstacionId equals ep.EstacionId
                                  where d.DepartamentoId == id
                                  select new Opcion
                                  {
                                      nombre = "Estación " + e.Nombre + " - " + e.CodigoIdeam,
                                      codigo = e.EstacionId,
                                      dato1 = e.CodigoIdeam
                                  }).Distinct().ToList());

            return Json(listaEstaciones, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsultaAnho(int id)
        {
            List<Opcion> listaEstaciones =
                new List<Opcion>((from ep in db.EstacionProductividad
                                  where ep.EstacionId == id
                                  orderby ep.Fecha.Year
                                  select new Opcion
                                  {
                                      codigo = ep.Fecha.Year,
                                      nombre = ep.Fecha.Year.ToString()

                                  }).Distinct().ToList());

            return Json(listaEstaciones, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsultaAnhoUsuario(int id)
        {
            //se busca usuario autenticado para consultar los anios que ha cargado masivamente.
            string userid = User.Identity.Name.Split('|')[3];
            int userIDAutentica = Convert.ToInt32(userid);
            ViewBag.UsuarioAutentica = userIDAutentica;

            List<Opcion> listaAnhos =
                            new List<Opcion>((from ep in db.EstacionProductividadUsuario
                                              where ep.UsuarioId == userIDAutentica
                                              orderby ep.FechaProductividad.Year
                                              select new Opcion
                                              {
                                                  codigo = ep.FechaProductividad.Year,
                                                  nombre = ep.FechaProductividad.Year.ToString()
                                              }).Distinct().ToList());

            //new List<Opcion>((from ep in db.EstacionProductividadUsuario
            //                  where ep.UsuarioId == userIDAutentica
            //                  group ep by ep.FechaProductividad.Year into grupos
            //                  select grupos.OrderBy(p=>p)

            return Json(listaAnhos, JsonRequestBehavior.AllowGet);
        }
        public class Opcion
        {
            public int codigo { get; set; }
            public string nombre { get; set; }
            public string dato1 { get; set; }
            public string dato2 { get; set; }
        }

        [HttpPost]
        // public ActionResult Index (DateTime FechaSiembra, string seleccionCultivo, string seleccionDepartamento, string seleccionEstacion, string seleccionOrigenDatos, string CC, string PMP, string Da, string seleccionSuelo, string seleccionAnho, string seleccionAnhoUsuario)
        public ActionResult Index(ProductividadInfo productividadInfo)
        {
            int id = int.Parse(productividadInfo.seleccionCultivo);
            int idDepto = int.Parse(productividadInfo.seleccionDepartamento);
            // int idEstacion = int.Parse(seleccionEstacion);
            int idEstacion = 0;
            int idSueloProductividad = int.Parse(productividadInfo.seleccionSuelo);
            double ccEntrada = double.Parse(productividadInfo.CC.Replace(".", ","));
            double pmpEntrada = double.Parse(productividadInfo.PMP.Replace(".", ","));
            double daEntrada = double.Parse(productividadInfo.Da.Replace(".", ","));
            DateTime fechaSiembra = productividadInfo.FechaSiembra;

            //buscando Id usuario conectado
            string userid = User.Identity.Name.Split('|')[3];
            int userIDAutentica = Convert.ToInt32(userid);


            Departamento departamento = db.Departamento.Find(idDepto);
            //si se selecciona origen como Sistema se busca datos de la estacion

            if (productividadInfo.seleccionOrigenDatos == null)
            {
                TempData["Mensaje"] = "No se ha seleccionado el origen de los datos de clima, por favor revisar.";
                ViewBag.ListaCultivos = new List<Opcion>((from r in db.CultivoProductividad
                                                          select new Opcion
                                                          {
                                                              codigo = r.CultivoId,
                                                              nombre = r.Cultivo.Nombre
                                                          }).ToList().Distinct());

                ViewBag.ListaSuelos = new List<Opcion>((from e in db.SueloProductividad
                                                        select new Opcion
                                                        {
                                                            codigo = e.SueloProductividadId,
                                                            nombre = e.TipoSuelo.Nombre
                                                        }).ToList().Distinct());

                ViewBag.AnhoUsuario = new List<Opcion>((from ep in db.EstacionProductividadUsuario
                                                        where ep.UsuarioId == userIDAutentica
                                                        select new Opcion
                                                        {
                                                            codigo = ep.FechaProductividad.Year,
                                                            nombre = ep.FechaProductividad.Year.ToString()

                                                        }).Distinct().ToList());
                return Json(new { success = false });
                // return View();
            }
            if (productividadInfo.seleccionOrigenDatos.Equals("1"))
            {
                idEstacion = int.Parse(productividadInfo.seleccionEstacion);
                Estacion estacion = db.Estacion.Find(idEstacion);
            }

            SueloProductividad suelo = db.SueloProductividad.Find(idSueloProductividad);

            ViewBag.Prueba = id;

            double raizMin;
            double raizMax;
            double jInicial;
            double jMaxima;
            double porcentajeCC;
            double porcentajePMP;
            double AMP;
            double ADT;
            double AFA;
            double KyInicial;
            double KyDesarrollo;
            double KyMedio;
            double KyFinal;
            double kcInicial;
            double KcMedio;
            double KcFinal;
            int tiempoInicial;
            int tiempoDesarrollo;
            int tiempoMedia;
            int tiempoFinal;
            int indicadorDatosUsuario = 0;



            //Si se selecciona que los datos de clima se toman de los insertados por el usuario el indicador queda en 1
            if (productividadInfo.seleccionOrigenDatos.Equals("2"))
            { indicadorDatosUsuario = 1; }

            ////INICIO DATOS ENTRADA:
            int cultivoId = 0;
            //List<ListaEtoPptDiaria> listadatosEtoPpt = new List<ListaEtoPptDiaria>();
            List<ListaEtapas_JKc> listadatosEtapas = new List<ListaEtapas_JKc>();

            //busca cultivoId partiendo del id de entrada
            CultivoProductividad cultivoProductividad = db.CultivoProductividad.Where(cp => cp.CultivoId == id).FirstOrDefault();

            cultivoId = cultivoProductividad.CultivoId;

            ////llena vector datos de etapas
            listadatosEtapas = LlenaVectorEtapas(listadatosEtapas, cultivoId, (DateTime)fechaSiembra);

            ViewBag.Titulo = cultivoProductividad.Cultivo.Nombre;//"Cultivo de tomate";

            /////FIN DATOS ENTRADA

            ////Lectura de BD y calculo de productividad            
            Cultivo cultivo = db.Cultivo.Find(cultivoId);

            if (cultivo != null)
            {
                raizMin = cultivo.ZrMin;
                raizMax = cultivo.ZrMax;
                jInicial = cultivo.JMin;
                jMaxima = cultivo.JMax;
                kcInicial = cultivo.KInicial;
                KcMedio = cultivo.KMedia;
                KcFinal = cultivo.KFinal;
                tiempoInicial = cultivo.TiempoInicial;
                tiempoMedia = cultivo.TiempoMedia;
                tiempoDesarrollo = cultivo.TiempoDesarrollo;
                tiempoFinal = cultivo.TiempoFinal;

                if (cultivoProductividad != null)
                {
                    //Asigna variables de suelo de acuerdo a datos editados en la vista y envia a viewbag para resultados
                    porcentajeCC = ccEntrada;
                    porcentajePMP = pmpEntrada;
                    //Da = daEntrada;
                    ViewBag.CCEntrada = porcentajeCC;
                    ViewBag.PMPEntrada = porcentajePMP;
                    ViewBag.DaEntrada = daEntrada;

                    // calculos de ADT y AFA
                    AMP = cultivoProductividad.AMP;
                    if (porcentajeCC > porcentajePMP)
                    {
                        ADT = 1000 * ((porcentajeCC - porcentajePMP) / 100) * daEntrada;

                    }
                    else { ADT = 0; }
                    AFA = Math.Round(AMP * ADT);
                    //para visualizar resultado de adt y afa
                    ViewBag.AMPLeido = AMP;
                    ViewBag.ADTCalculado = ADT;
                    ViewBag.AFACalculado = AFA;

                    KyInicial = cultivoProductividad.KyInicial;
                    KyDesarrollo = cultivoProductividad.KyDesarrollo;
                    KyMedio = cultivoProductividad.KyMedio;
                    KyFinal = cultivoProductividad.KyFinal;

                    List<ListaResultadosProductividad> listaResultadoProductividad = new List<ListaResultadosProductividad>();
                    listaResultadoProductividad = calculaProductividad(listaResultadoProductividad, listadatosEtapas, jMaxima, raizMin, raizMax, jInicial, AFA, kcInicial, KcMedio, KcFinal, ADT, KyInicial, KyMedio, KyDesarrollo, KyFinal, (int)idEstacion, cultivoId, indicadorDatosUsuario, userIDAutentica);

                    if (listaResultadoProductividad.Count() == 0)
                    {
                        ViewBag.Mensaje = TempData["Mensaje"];
                        return View();
                    }
                    //**Envio resultados para AMBOS escenarios**//
                    ViewBag.data = listaResultadoProductividad;

                    string datosProductividad = "";
                    string perdidaAcumulada = "";
                    string datosPpt = "";
                    string datosETo = "";
                    string datosETc = "";
                    string datosAFA = "";
                    string datosAgotamiento = "";
                    string datosETcAdj = "";
                    double sumaDecadaPpt = 0;
                    double sumaDecadaETo = 0;

                    int contador = 0;
                    foreach (ListaResultadosProductividad dato in listaResultadoProductividad)
                    {
                        sumaDecadaPpt = sumaDecadaPpt + dato.PPtEntrada;
                        sumaDecadaETo = sumaDecadaETo + dato.EToEntrada;

                        if (contador % 10 == 0)
                        {
                            if (dato.Productividad < 0)
                            {
                                dato.Productividad = 0;
                            }
                            datosProductividad = datosProductividad + (Math.Round(dato.Productividad, 0)).ToString() + ";";
                            perdidaAcumulada = perdidaAcumulada + (Math.Round(dato.PerdidaAcumulada, 0)).ToString() + ";";
                            datosETc = datosETc + (Math.Round(dato.ETc, 0)).ToString() + ";";
                            datosETcAdj = datosETcAdj + (Math.Round(dato.ETCadj, 0)).ToString() + ";";
                            datosAFA = datosAFA + (Math.Round(dato.AFAZr, 0)).ToString() + ";";
                            datosAgotamiento = datosAgotamiento + (Math.Round(dato.DrFinal, 0)).ToString() + ";";
                            datosPpt = datosPpt + (Math.Round(sumaDecadaPpt, 0)).ToString() + ";";
                            datosETo = datosETo + (Math.Round(sumaDecadaETo, 0)).ToString() + ";";

                            sumaDecadaPpt = 0;
                            sumaDecadaETo = 0;
                        }

                        contador++;
                    }

                    datosProductividad = datosProductividad.Substring(0, datosProductividad.Length - 1);
                    perdidaAcumulada = perdidaAcumulada.Substring(0, perdidaAcumulada.Length - 1);
                    datosETc = datosETc.Substring(0, datosETc.Length - 1);
                    datosETcAdj = datosETcAdj.Substring(0, datosETcAdj.Length - 1);
                    datosAFA = datosAFA.Substring(0, datosAFA.Length - 1);
                    datosAgotamiento = datosAgotamiento.Substring(0, datosAgotamiento.Length - 1);
                    datosPpt = datosPpt.Substring(0, datosPpt.Length - 1);
                    datosETo = datosETo.Substring(0, datosETo.Length - 1);

                    return Json(new
                    {
                        datos = listaResultadoProductividad,
                        DatosProductividad = datosProductividad,
                        PerdidaAcumulada = perdidaAcumulada,
                        DatosAFA = datosAFA,
                        DatoADT = ADT,
                        DatosAgotamiento = datosAgotamiento,
                        DatosETo = datosETo,
                        DatosPpt = datosPpt,
                        iTotalRecords = listaResultadoProductividad.Count()
                    }, JsonRequestBehavior.AllowGet);

                }
            }

            ViewBag.ListaCultivos = new List<Opcion>((from r in db.CultivoProductividad
                                                      select new Opcion
                                                      {
                                                          codigo = r.CultivoId,
                                                          nombre = r.Cultivo.Nombre
                                                      }).ToList().Distinct());

            ViewBag.ListaSuelos = new List<Opcion>((from e in db.SueloProductividad
                                                    select new Opcion
                                                    {
                                                        codigo = e.SueloProductividadId,
                                                        nombre = e.TipoSuelo.Nombre
                                                    }).ToList().Distinct());

            ViewBag.AnhoUsuario = new List<Opcion>((from ep in db.EstacionProductividadUsuario
                                                    where ep.UsuarioId == userIDAutentica
                                                    select new Opcion
                                                    {
                                                        codigo = ep.FechaProductividad.Year,
                                                        nombre = ep.FechaProductividad.Year.ToString()

                                                    }).Distinct().ToList());

            ViewBag.Consulta = true;

            ViewBag.Selecciones = cultivo.CultivoId + ";" + departamento.DepartamentoId + ";" +/* estacion.EstacionId*/idEstacion + ";" + productividadInfo.seleccionAnho + ";" + suelo.SueloProductividadId + ";" + ccEntrada + ";" + pmpEntrada + ";" + daEntrada + ";" + productividadInfo.seleccionAnhoUsuario;
            return Json(new { success = true });
            // return View();
        }

        public class ProductividadInfo
        {
            public DateTime FechaSiembra { get; set; }
            public string seleccionCultivo { get; set; }
            public string seleccionDepartamento { get; set; }
            public string seleccionEstacion { get; set; }
            public string seleccionOrigenDatos { get; set; }
            public string CC { get; set; }
            public string PMP { get; set; }
            public string Da { get; set; }
            public string seleccionSuelo { get; set; }
            public string seleccionAnho { get; set; }
            public string seleccionAnhoUsuario { get; set; }
        }
        public double calculoZrDiario(double J, double jMaxima, double raizMin, double raizMax, double jInicial)
        {
            double Zr = 0;

            if (J < jMaxima)
            {
                Zr = raizMin + ((raizMax - raizMin) * ((J - jInicial) / (jMaxima - jInicial)));

            }
            else
            {
                Zr = raizMax;
            }

            return Zr;
        }

        /*CALCULO DE PRODUCTIVIDAD DE ACUERDO A LAS ECUACIONES DEL EXCEL SIN REDONDEOS*/
        public List<ListaResultadosProductividad> calculaProductividad(List<ListaResultadosProductividad> listaResultadoProductividad, List<ListaEtapas_JKc> listadatosEtapas, /*List<ListaEtoPptDiaria> listadatosEtoPpt,*/
          double jMaxima, double raizMin, double raizMax, double jInicial, double AFA, double kcInicial, double KcMedio, double KcFinal,
          double ADT, double KyInicial, double kyMedio, double KyDesarrollo, double KyFinal, int estacionId, int cultivoId, int indicaDatosUsuario, int usuarioId)
        {
            int inicioCC = 0;
            double DrFinalAnterior = 0;
            int J = 0;
            double Kc;
            double ETo = 0;
            double P = 0;
            double viento = 0;
            double tmax = 0;
            double tmin = 0;
            double ppt = 0;
            double altura = 4;
            double latitud = 10.500276;

            // TODO: antes de poder cargar datos de clima de usuario para calcularETO se requiere altitud y latitud y se calcula leyendo la estacion.
            //pendiente definir que valores debemos poner si son datos de clima del usuario.

            int anioFechaSiembra = (int)listadatosEtapas[0].fecha.Year;
            IQueryable<EstacionProductividad> datosEstacionProductividad = db.EstacionProductividad.Where(c => c.Fecha.Year == anioFechaSiembra && c.Estacion.EstacionId == estacionId);

            //Ciclo para calcular datos de acuerdo a lista
            for (int a = 0; a < listadatosEtapas.Count; a++)
            {
                J = listadatosEtapas[a].J;
                listaResultadoProductividad.Add(new ListaResultadosProductividad());
                listaResultadoProductividad[a].J = J;
                listaResultadoProductividad[a].Dia = listadatosEtapas[a].fecha.Day;
                listaResultadoProductividad[a].Mes = listadatosEtapas[a].fecha.Month;
                listaResultadoProductividad[a].Anio = listadatosEtapas[a].fecha.Year;
                listaResultadoProductividad[a].Etapa = listadatosEtapas[a].Etapa;
                // calculo dia anterior
                if (J > 1 && listaResultadoProductividad.Count() > 0)
                {
                    DrFinalAnterior = listaResultadoProductividad[a - 1].DrFinal;
                }

                ////busqueda ETO y P en lista de acuerdo a fecha  
                //calculando el dato de fecha:
                int anio = (int)listadatosEtapas[a].fecha.Year;
                int mes = (int)listadatosEtapas[a].fecha.Month;
                int dia = (int)listadatosEtapas[a].fecha.Day;

                DateTime fecha = new DateTime(anio, mes, dia);

                //Búsqueda en BD de Precipitacion tmax y tmin
                //Verifica si el origen de los datos de clima es de sistema o son cargados por el usuario                         
                if (indicaDatosUsuario == 1)
                {
                    var coeficientesDiarioUsuario = db.EstacionProductividadUsuario.Where(c => c.FechaProductividad == fecha && c.UsuarioId == usuarioId);
                    if (coeficientesDiarioUsuario != null && coeficientesDiarioUsuario.Count() != 0)
                    {
                        tmax = (double)coeficientesDiarioUsuario.FirstOrDefault().Tmax;
                        tmin = (double)coeficientesDiarioUsuario.FirstOrDefault().Tmin;
                        ppt = (double)coeficientesDiarioUsuario.FirstOrDefault().Precipitacion;
                    }
                    else
                    {
                        TempData["Mensaje"] = "Favor revise la carga de datos de clima, no hay Tmax, Tmin, precipitacion para la fecha:" + fecha.ToString("yyyy MMM d");
                        return listaResultadoProductividad;
                    }
                }
                else
                {
                    Estacion estacion = db.Estacion.Find(estacionId);
                    altura = estacion.Altitud;
                    latitud = estacion.Latitud;

                    EstacionProductividad coeficientesDiario = datosEstacionProductividad.Where(c => c.Fecha == fecha && c.Estacion.EstacionId == estacionId).FirstOrDefault();

                    if (coeficientesDiario != null)
                    {
                        tmax = (double)coeficientesDiario.Tmax;
                        tmin = (double)coeficientesDiario.Tmin;
                        ppt = (double)coeficientesDiario.Precipitacion;
                    }
                }

                P = ppt;

                ETo = CalcularEToDiario(altura, latitud, viento, tmax, tmin, fecha);
                listaResultadoProductividad[a].EToEntrada = Math.Round(ETo, 4);
                listaResultadoProductividad[a].PPtEntrada = Math.Round(P, 2);

                //calculo Zr

                listaResultadoProductividad[a].Zr = Math.Round(calculoZrDiario((double)J, jMaxima, raizMin, raizMax, jInicial), 2);
                //calculo AFA

                listaResultadoProductividad[a].AFAZr = Math.Round(AFA * listaResultadoProductividad[a].Zr, 2);
                //calculo RO
                if (J == 1)
                {
                    if (inicioCC == 0) { listaResultadoProductividad[a].RO = P /*A-Math.Round(P, 0) */; }
                    else { listaResultadoProductividad[a].RO = 0; }
                }
                else
                {
                    if (DrFinalAnterior <= 0)
                    {
                        listaResultadoProductividad[a].RO = P /*A-Math.Round(P, 0)*/;
                    }
                    else
                    {
                        if (P > DrFinalAnterior) { listaResultadoProductividad[a].RO = /*(P - DrFinalAnterior)*/Math.Round((P - DrFinalAnterior), 2); }
                        else { listaResultadoProductividad[a].RO = 0; }
                    }
                }

                //calculo p-ro

                listaResultadoProductividad[a].PRO = P - listaResultadoProductividad[a].RO;

                //calculo kc de acerdo a valores de la estaciòn registrados en BD. 
                Kc = CalculaKc(cultivoId, J);
                listaResultadoProductividad[a].Kc = Math.Round(Kc, 2);


                //calculo ETC
                listaResultadoProductividad[a].ETc = Math.Round(Kc * ETo, 2);

                //Calculo Dr Inicial
                if (J == 1) { listaResultadoProductividad[a].DrInicial = (double)inicioCC; }
                else { listaResultadoProductividad[a].DrInicial = Math.Round(DrFinalAnterior, 2); }
                //calculo KS

                if (listaResultadoProductividad[a].DrInicial > listaResultadoProductividad[a].AFAZr)
                {

                    listaResultadoProductividad[a].Ks = Math.Round(((ADT * raizMax) - listaResultadoProductividad[a].DrInicial) / ((ADT * raizMax) - listaResultadoProductividad[a].AFAZr), 2);
                }
                else
                { listaResultadoProductividad[a].Ks = 1; }

                //calculo ETC adj  
                listaResultadoProductividad[a].ETCadj = Math.Round(listaResultadoProductividad[a].Ks * Kc * ETo, 2);

                //calculo DP
                double tempdp = 0;
                if (J == 1)
                {
                    tempdp = listaResultadoProductividad[a].PRO - listaResultadoProductividad[a].ETCadj - (double)inicioCC;
                }
                else
                {
                    tempdp = listaResultadoProductividad[a].PRO - listaResultadoProductividad[a].ETCadj - DrFinalAnterior;
                }
                if (tempdp > 0)
                {
                    listaResultadoProductividad[a].DP = Math.Round(tempdp, 2);
                }
                else { listaResultadoProductividad[a].DP = 0; }
                // calculo DR Final
                if (J == 1)
                {
                    listaResultadoProductividad[a].DrFinal = Math.Round(((double)inicioCC - listaResultadoProductividad[a].PRO + listaResultadoProductividad[a].ETCadj + listaResultadoProductividad[a].DP), 2);
                }
                else
                {
                    double tmp = listaResultadoProductividad[a].DrInicial - listaResultadoProductividad[a].PRO + listaResultadoProductividad[a].ETCadj + listaResultadoProductividad[a].DP;
                    listaResultadoProductividad[a].DrFinal = Math.Round((listaResultadoProductividad[a].DrInicial - listaResultadoProductividad[a].PRO + listaResultadoProductividad[a].ETCadj + listaResultadoProductividad[a].DP), 2);
                }

                //seleccion de Ky de acuerdo a etapa:
                double ky = 0.0;
                if (listadatosEtapas[a].Etapa == "Inicial")
                {
                    ky = KyInicial;
                }
                else if (listadatosEtapas[a].Etapa == "Desarrollo")
                {
                    ky = KyDesarrollo;
                }
                else if (listadatosEtapas[a].Etapa == "Media")
                {
                    ky = kyMedio;
                }
                else if (listadatosEtapas[a].Etapa == "Final")
                {
                    ky = KyFinal;
                }

                //calculos productividad
                double tmpETCadj_ETC;
                double tmpETCadj_1;
                double tmpETCKy;
                double perdidaAcumAnterior;
                double tempResultadoPerdidaAcumulada;

                tmpETCadj_ETC = listaResultadoProductividad[a].ETCadj / listaResultadoProductividad[a].ETc;
                tmpETCadj_1 = 1 - tmpETCadj_ETC;

                tmpETCKy = ky * tmpETCadj_1;

                if (J == 1)
                {
                    listaResultadoProductividad[a].PerdidaAcumulada = Math.Round(tmpETCKy, 2);
                    listaResultadoProductividad[a].Productividad = Math.Round((100 - tmpETCKy), 2);
                }
                else
                {
                    perdidaAcumAnterior = listaResultadoProductividad[a - 1].PerdidaAcumulada;
                    tempResultadoPerdidaAcumulada = tmpETCKy + perdidaAcumAnterior;
                    listaResultadoProductividad[a].PerdidaAcumulada = Math.Round((tmpETCKy + perdidaAcumAnterior), 2);
                    listaResultadoProductividad[a].Productividad = Math.Round((100 - tempResultadoPerdidaAcumulada), 2);
                }

            }
            return listaResultadoProductividad;
        }


        /*Calcula las etapas y llena el vector de ListadatosEtapas partiendo de la fecha de siembra que viene como parametro
        y del cultivo*/
        public List<ListaEtapas_JKc> LlenaVectorEtapas(List<ListaEtapas_JKc> listadatosEtapas, int cultivoId, DateTime fechaSiembra)
        {

            Cultivo cultivo = db.Cultivo.Find(cultivoId);
            int duracionCultivo = cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia + cultivo.TiempoFinal;
            int limiteCultivoInicial = 0;
            int limiteCultivoDesarrollo = 0;
            int limiteCultivoMedia = 0;
            int limiteCultivoFinal = 0;

            limiteCultivoInicial = cultivo.TiempoInicial;
            limiteCultivoDesarrollo = cultivo.TiempoInicial + cultivo.TiempoDesarrollo;
            limiteCultivoMedia = cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia;
            limiteCultivoFinal = duracionCultivo;

            //llena datos de etapa Inicial
            for (int et = 0; et < limiteCultivoInicial; et++)
            {
                listadatosEtapas.Add(new ListaEtapas_JKc());

                listadatosEtapas[et].fecha = fechaSiembra.AddDays((double)et);
                listadatosEtapas[et].Etapa = "Inicial";
                listadatosEtapas[et].J = et + 1;
            }
            //llena datos de etapa Desarrollo
            for (int et = limiteCultivoInicial; et < limiteCultivoDesarrollo; et++)
            {
                listadatosEtapas.Add(new ListaEtapas_JKc());

                listadatosEtapas[et].fecha = listadatosEtapas[et - 1].fecha.AddDays((double)1);
                listadatosEtapas[et].Etapa = "Desarrollo";
                listadatosEtapas[et].J = et + 1;
            }
            //llena datos de etapa Media
            for (int et = limiteCultivoDesarrollo; et < limiteCultivoMedia; et++)
            {
                listadatosEtapas.Add(new ListaEtapas_JKc());

                listadatosEtapas[et].fecha = listadatosEtapas[et - 1].fecha.AddDays((double)1);
                listadatosEtapas[et].Etapa = "Media";
                listadatosEtapas[et].J = et + 1;
            }
            //llena datos de etapa final
            for (int et = limiteCultivoMedia; et < limiteCultivoFinal; et++)
            {
                listadatosEtapas.Add(new ListaEtapas_JKc());

                listadatosEtapas[et].fecha = listadatosEtapas[et - 1].fecha.AddDays((double)1);
                listadatosEtapas[et].Etapa = "Final";
                listadatosEtapas[et].J = et + 1;
            }
            return listadatosEtapas;
        }


        public class ListaEtoPptDiaria
        {
            public double CodigoIdeamEstacion { get; set; }
            public double Anio { get; set; }
            public double Mes { get; set; }
            public double Dia { get; set; }
            public double ETo { get; set; }
            public double Precipitacion { get; set; }

        }

        public class ListaEtapas_JKc
        {
            public double CodigoIdeamEstacion { get; set; }
            public double Anio { get; set; }
            public double Mes { get; set; }
            public double Dia { get; set; }
            public DateTime fecha { get; set; }
            public string Etapa { get; set; }
            public int J { get; set; }
            public double Kc { get; set; }
            //public double Ky { get; set; }

        }

        public class ListaResultadosProductividad
        {
            // public double CodigoIdeamEstacion { get; set; }
            public double Anio { get; set; }
            public double Mes { get; set; }
            public double Dia { get; set; }
            public string Etapa { get; set; }
            public double EToEntrada { get; set; }
            public double PPtEntrada { get; set; }
            public int J { get; set; }
            public double Zr { get; set; }
            public double AFAZr { get; set; }
            public double RO { get; set; }
            public double PRO { get; set; }
            public double Kc { get; set; }
            // public double KcFormula { get; set; }
            public double ETc { get; set; }
            public double DrInicial { get; set; }
            public double Ks { get; set; }
            public double ETCadj { get; set; }
            public double DP { get; set; }
            public double DrFinal { get; set; }
            // public double DrFinalRound { get; set; }
            public double PerdidaAcumulada { get; set; }
            public double Productividad { get; set; }
        }

        /*Metodo para calculo del ETO diario partiendo del estacionId, viento, temperatura mazim, temperatura minima y fecha registradas en la BD*/
        public double CalcularEToDiario(double altura, double latitud, double viento, double temMax, double temMin, DateTime fecha)
        {
            /* Inicialización de variables para el cálculo */
            double ETo;

            /* Variables de la estación */
            // Estacion estacion = db.Estacion.Find(estacionId);
            // double altura = estacion.Altitud;
            //double latitud = estacion.Latitud;
            // double viento = (double)datosEstacion.Viento;

            /* Temperatura media*/
            double tmed = (temMax + temMin) / 2;

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
            double eomin = 0.6108 * Math.Exp((17.27 * temMin) / (temMin + 237.3));
            double eomax = 0.6108 * Math.Exp((17.27 * temMax) / (temMax + 237.3));
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
            double Rs = ks * (Math.Pow((temMax - temMin), 0.5) * Ra);
            double Rnl = s * ((Math.Pow((temMax + 273.16), 4) + Math.Pow((temMin + 273.16), 4)) / 2) * (0.34 - 0.14 * Math.Pow(ea, 0.5)) * ((1.35 * (Rs / Rso)) - 0.35);
            double Rns = (1 - alpha) * Rs;
            double Rn = Rns - Rnl;

            /* Flujo de calor en el suelo
             * G: flujo de calor en el suelo, [MJ m-2 dia-1]
             */
            int G = 0;

            ETo = Math.Round(((0.408 * d * (Rn - G)) + (g * (900 / (tmed + 273.15)) * viento * (es - ea))) / (d + (g * (1 + 0.34 * viento))), 4);

            return ETo;
        }

        /*Metodo para calculo de Kc para el dia, la variable diasPrediccion equivale a la misma columna J del excel de productividad*/
        public double CalculaKc(int cultivoId, int diasPrediccion)
        {
            double Kc = 0;

            Cultivo cultivo = db.Cultivo.Find(cultivoId);
            int duracionCultivo = cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia + cultivo.TiempoFinal;

            //Etapa inicial
            if (diasPrediccion <= cultivo.TiempoInicial)
            {
                //Kc = Math.Round(cultivo.KInicial, 3);
                Kc = cultivo.KInicial;
            }
            //Etapa desarrollo
            else if (diasPrediccion <= (cultivo.TiempoInicial + cultivo.TiempoDesarrollo))
            {

                //primer dia de desarrollo se calcula con misma formula de la etapa inicial
                if (diasPrediccion - 1 <= cultivo.TiempoInicial)
                {
                    //Kc = Math.Round(cultivo.KInicial, 3)
                    Kc = cultivo.KInicial;
                }
                else if (diasPrediccion >= cultivo.TiempoInicial && diasPrediccion < duracionCultivo)
                {
                    //A- Kc = Math.Round(cultivo.KInicial + (double)((double)((diasPrediccion-1) - cultivo.TiempoInicial) / cultivo.TiempoDesarrollo) * (cultivo.KMedia - cultivo.KInicial), 3);
                    Kc = cultivo.KInicial + (double)((double)((diasPrediccion - 1) - cultivo.TiempoInicial) / cultivo.TiempoDesarrollo) * (cultivo.KMedia - cultivo.KInicial);
                }
            }
            //Etapa media
            else if (diasPrediccion <= (cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia))
            {

                if (diasPrediccion >= cultivo.TiempoInicial && diasPrediccion < cultivo.TiempoInicial + cultivo.TiempoDesarrollo)
                {
                    //A- Kc = Math.Round(cultivo.KInicial + (double)((double)(diasPrediccion + 1 - cultivo.TiempoInicial) / cultivo.TiempoDesarrollo) * (cultivo.KMedia - cultivo.KInicial), 3);
                    Kc = cultivo.KInicial + (double)((double)(diasPrediccion + 1 - cultivo.TiempoInicial) / cultivo.TiempoDesarrollo) * (cultivo.KMedia - cultivo.KInicial);
                }
                if (diasPrediccion >= (cultivo.TiempoInicial + cultivo.TiempoDesarrollo) && diasPrediccion < duracionCultivo)
                {
                    //A-Kc = Math.Round(cultivo.KMedia, 3)
                    Kc = cultivo.KMedia;
                }
            }
            //Etapa final
            else
            {

                //primer dia de etapa final se calcula con misma formula de etapa Media
                if (diasPrediccion >= (cultivo.TiempoInicial + cultivo.TiempoDesarrollo) && diasPrediccion - 1 <= cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia)
                {
                    //A-Kc = Math.Round(cultivo.KMedia, 3);
                    Kc = cultivo.KMedia;
                }
                else if (diasPrediccion > (cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia) && diasPrediccion <= duracionCultivo)
                {
                    //A-Kc = Math.Round(cultivo.KMedia + (double)((double)(diasPrediccion - 1 - (cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia)) / cultivo.TiempoFinal) * (cultivo.KFinal - cultivo.KMedia), 3);
                    Kc = cultivo.KMedia + (double)((double)(diasPrediccion - 1 - (cultivo.TiempoInicial + cultivo.TiempoDesarrollo + cultivo.TiempoMedia)) / cultivo.TiempoFinal) * (cultivo.KFinal - cultivo.KMedia);
                }
            }

            return Kc;
        }
        /* Método que envía una lista deptos a partir de un cultivo*/
        //public JsonResult AutoFiltroDepartamento(int term)
        //{

        //    var result = (from c in db.CultivoProductividad
        //                  join cm in db.CultivoDepartamento
        //                  on c.CultivoProductividadId equals cm.CultivoProductividadId
        //                  join m in db.Municipio
        //                  on cm.DepartamentoId equals m.MunicipioId
        //                  join d in db.Departamento
        //                  on m.DepartamentoId equals d.DepartamentoId
        //                  where (c.CultivoProductividadId == term)
        //                  select new
        //                  {
        //                      Text = d.Nombre,
        //                      Value = d.DepartamentoId

        //                  }).ToList().Distinct();

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        /*Ajax para modificar filtro de estaciones partiendo del valor seleccionado de departamento*/
        //public JsonResult AutoFiltroEstaciones(int term)
        //{

        //    var result = (from d in db.Departamento
        //                  join m in db.Municipio
        //                  on d.DepartamentoId equals m.DepartamentoId
        //                  join me in db.MunicipioEstacions
        //                  on m.MunicipioId equals me.MunicipioId
        //                  join e in db.Estacion
        //                  on me.EstacionId equals e.EstacionId
        //                  join ep in db.EstacionProductividad
        //                  on e.EstacionId equals ep.EstacionId
        //                  where (d.DepartamentoId == term)
        //                  select new
        //                  {
        //                      Text = "Estación " + e.Nombre + " - " + e.CodigoIdeam,
        //                      Value = e.EstacionId

        //                  }).ToList().Distinct();

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        /*Ajax para modificar filtro de anios  partiendo del valor seleccionado de estaciones*/
        //public JsonResult AutoFiltroAnios(int term)
        //{
        //    var result = (from ep in db.EstacionProductividad
        //                  where (ep.EstacionId == term)
        //                  select new
        //                  {
        //                      Text = ep.Fecha.Year,
        //                      Value = ep.Fecha.Year
        //                  }).ToList().Distinct();

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        /*ajax para consulta de los datos detallados de suelo dependiendo del valor seleccionado en la vista*/
        public ActionResult AutoFiltroSuelo(int term)
        {
            var result = (from d in db.SueloProductividad
                          where (d.SueloProductividadId == term)
                          select new
                          {
                              CC = d.CC,
                              PMP = d.PMP,
                              da = d.Da,
                              ////da = String.Format("{0:#.##}", d.Da),
                              SueloProductividadid = d.SueloProductividadId

                          }).ToList().Distinct();

            return Json(new
            {
                CC = result.FirstOrDefault().CC,
                PMP = result.FirstOrDefault().PMP,
                Da = result.FirstOrDefault().da,
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult LeeExcelProductividad(HttpPostedFileBase excelAdjunto)
        {
            //buscando usuario conectado:
            string userid = User.Identity.Name.Split('|')[3];
            int userIDAutentica = Convert.ToInt32(userid);

            using (SEEntities db2 = new SEEntities())
            {
                IEnumerable<EstacionProductividadUsuario> registrosAnteriores = db2.EstacionProductividadUsuario.Where
                    (ep => ep.UsuarioId == userIDAutentica);
                db2.EstacionProductividadUsuario.RemoveRange(registrosAnteriores);
                db2.SaveChanges();
            }


            string sArchivo = "";
            string mensaje = "";
            if (ModelState.IsValid)
            //if (excelAdjunto != null && excelAdjunto.ContentLength > 0)
            {
                sArchivo = archivo.GuardarArchivoExcel(excelAdjunto);

                List<ResultadoCargueBD> listaResultados = new List<ResultadoCargueBD>();
                if (sArchivo != null)
                {

                    string paramColumnaAnio, paramColumnaMes, paramColumnaDia, paramColumnaTMin,
                        paramColumnaTMax, paramColumnaPrecipitacion;

                    paramColumnaAnio = paramColumnaMes = paramColumnaDia = paramColumnaTMin =
                       paramColumnaTMax = paramColumnaPrecipitacion = "";

                    //buscando parametros del excel en la BD (a partir de identificador del parametro se consulta el dato del nombre de la columna en excel que està 
                    //parametrizada en la tabla de parametrosCargueAnalisis consultaParametroNombreColumnaExcel ):
                    paramColumnaAnio = consultaParametroNombreColumnaExcel("COLUMNA_ANIO_PRODUCTIVIDAD_USUARIO");
                    paramColumnaMes = consultaParametroNombreColumnaExcel("COLUMNA_MES_PRODUCTIVIDAD_USUARIO");
                    paramColumnaDia = consultaParametroNombreColumnaExcel("COLUMNA_DIA_PRODUCTIVIDAD_USUARIO");
                    paramColumnaTMin = consultaParametroNombreColumnaExcel("COLUMNA_TMIN_PRODUCTIVIDAD_USUARIO");
                    paramColumnaTMax = consultaParametroNombreColumnaExcel("COLUMNA_TMAX_PRODUCTIVIDAD_USUARIO");
                    paramColumnaPrecipitacion = consultaParametroNombreColumnaExcel("COLUMNA_PPT_PRODUCTIVIDAD_USUARIO");


                    List<ListaExcel> listadatosexcel = new List<ListaExcel>();

                    ExcelPackage package = new ExcelPackage();

                    using (var stream = System.IO.File.OpenRead(sArchivo))
                    {
                        package.Load(stream);
                    }

                    ExcelWorkbook exlWbook = package.Workbook;

                    if (exlWbook != null)
                    {
                        if (exlWbook.Worksheets.Count > 0)
                        {
                            ExcelWorksheet exlWsheet = exlWbook.Worksheets.First();

                            int columnaInicial = exlWsheet.Dimension.Start.Column;
                            int columnaFinal = exlWsheet.Dimension.End.Column;
                            int filaInicial = exlWsheet.Dimension.Start.Row;
                            int filaFinal = exlWsheet.Dimension.End.Row;

                            ExcelRange exlRange = exlWsheet.Cells[filaInicial, columnaInicial, filaFinal, columnaFinal];

                            //leyendo row de encabezado:
                            List<ListaEncabezadoExcel> encabezadoExcel = new List<ListaEncabezadoExcel>();
                            for (int j = 1; j <= (columnaFinal); j++)
                            {
                                encabezadoExcel.Add(new ListaEncabezadoExcel
                                {
                                    PosicionColumna = j,
                                    NombreColumna = (exlWsheet.Cells[1, j] as ExcelRange).Value.ToString().Trim()
                                });
                            }

                            //leyendo cuerpo Excel:

                            for (int i = 2; i <= (filaFinal); i++)
                            {
                                int posRes = i - 2;
                                listadatosexcel.Add(new ListaExcel());

                                for (int j = 0; j < encabezadoExcel.Count(); j++)
                                {
                                    int posicion = encabezadoExcel[j].PosicionColumna;
                                    //valida que no vengan caracteres alfabeticos
                                    var valida = (exlWsheet.Cells[i, posicion] as ExcelRange).Value;
                                    if (validaNumero(Convert.ToString(valida)))
                                    {
                                        //

                                        if (encabezadoExcel[j].NombreColumna == paramColumnaAnio) { listadatosexcel[posRes].Anio = Convert.ToDouble((exlWsheet.Cells[i, posicion] as ExcelRange).Value); }
                                        else if (encabezadoExcel[j].NombreColumna == paramColumnaMes) { listadatosexcel[posRes].Mes = Convert.ToDouble((exlWsheet.Cells[i, posicion] as ExcelRange).Value); }
                                        else if (encabezadoExcel[j].NombreColumna == paramColumnaDia) { listadatosexcel[posRes].Dia = Convert.ToDouble((exlWsheet.Cells[i, posicion] as ExcelRange).Value); }
                                        else if (encabezadoExcel[j].NombreColumna == paramColumnaTMin) { listadatosexcel[posRes].Tmin = Convert.ToDouble((exlWsheet.Cells[i, posicion] as ExcelRange).Value); }
                                        else if (encabezadoExcel[j].NombreColumna == paramColumnaTMax) { listadatosexcel[posRes].Tmax = Convert.ToDouble((exlWsheet.Cells[i, posicion] as ExcelRange).Value); }
                                        else if (encabezadoExcel[j].NombreColumna == paramColumnaPrecipitacion) { listadatosexcel[posRes].Precipitacion = Convert.ToDouble((exlWsheet.Cells[i, posicion] as ExcelRange).Value); }
                                    }
                                    else
                                    {
                                        mensaje = " Existe un dato erroneo (con letras o caracter especial) o nulo en la columna No. " + posicion;
                                        //ViewBag.data = listaResultados;
                                        return Json(new { success = false, Mensaje = mensaje });
                                    }
                                }
                            }

                            List<ListaExcel> listadatoscargados = new List<ListaExcel>();
                            listadatoscargados = listadatosexcel;

                            //Indicadores de cantidad de registros insertados (para informe de resultados):
                            int resultadoAlmacenaBD;

                            resultadoAlmacenaBD = 0;

                            //Ciclo para almacenar datos del excel en la BD y asignar resultados para visualizar
                            for (int a = 0; a < listadatoscargados.Count; a++)
                            {
                                string mensajeValidacion = validaDatos(listadatoscargados[a]);
                                /*Validación de fecha*/
                                if (mensajeValidacion == "Ok")
                                {
                                    EstacionProductividadUsuario EstacionProductividadUsuario = new EstacionProductividadUsuario();

                                        //calculando el dato de fecha:
                                        int anio = (int)listadatoscargados[a].Anio;
                                        int mes = (int)listadatoscargados[a].Mes;
                                        int dia = (int)listadatoscargados[a].Dia;

                                        DateTime fecha = new DateTime(anio, mes, dia);
                                        int diasMes = System.DateTime.DaysInMonth(anio, mes);

                                        EstacionProductividadUsuario datosEstacion = new EstacionProductividadUsuario();
                                        datosEstacion.UsuarioId = userIDAutentica;
                                        datosEstacion.Tmin = (float)listadatoscargados[a].Tmin;
                                        datosEstacion.Tmax = (float)listadatoscargados[a].Tmax;
                                        datosEstacion.Precipitacion = (float)listadatoscargados[a].Precipitacion;
                                        datosEstacion.FechaProductividad = fecha;
                                        datosEstacion.FechaSistema = fechaActual;

                                        resultadoAlmacenaBD = guardaActualizaEstacionProductividadUsuario(userIDAutentica, datosEstacion.FechaSistema, datosEstacion.FechaProductividad, (float)datosEstacion.Tmin,
                                            (float)datosEstacion.Tmax, (float)datosEstacion.Precipitacion);

                                        asignaResultado(listaResultados, "EstacionProductividadUsuario " + datosEstacion.UsuarioId, resultadoAlmacenaBD, "registro almacenado en BD para año:" + anio + " mes:" + mes + " dia:" + dia);
                                }
                                else
                                {
                                    mensaje = mensajeValidacion;
                                    return Json(new { success = false, Mensaje = mensaje });
                                }

                            }//for
                            mensaje = "Cargue realizado";
                            ViewBag.data = listaResultados;
                            return Json(new { success = true, Mensaje = mensaje });
                        } //if sArchivo es null
                    }//if count>0
                }//if book!=null
                else
                {
                    asignaResultado(listaResultados, "Todos", 0, "Error en Paso 1 del cargue masivo");
                    ViewBag.data = listaResultados;

                    mensaje = "No se ha leido correctamente el excel, por favor intente nuevamente realizar el Paso 2";
                    return Json(new { success = false, Mensaje = mensaje });
                }
            }

            mensaje = "No se ha leido correctamente el excel, por favor intente nuevamente realizar el Paso 2";
            return Json(new { success = false, Mensaje = mensaje });

        }

        public bool validaNumero(string dato)
        {
            {
                try
                {
                    double x = Convert.ToDouble(dato);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }
        public bool validaFecha(double dia, double mes, double anio)
        {
            {
                try
                {
                    int diaC = Convert.ToInt16(dia);
                    int mesC = Convert.ToInt16(mes);
                    int anioC = Convert.ToInt16(anio);
                    DateTime fecha = new DateTime(anioC, mesC, diaC);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool validaTemperaturas(double? Tmin, double? Tmax)
        {
            if (Tmin != null && Tmax != null)
            {
                if (Tmax > Tmin)
                {
                    if (Tmin > -10 && Tmin < 35 && Tmax > 0 && Tmax < 50)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool validaPrecipitacion(double ppt)
        {
            if (ppt >= 0 && ppt < 150)
            {
                return true;
            }
            return false;
        }

        public string validaDatos(ListaExcel datos)
        {
            string mensaje = "Ok";

            if (!validaFecha(datos.Dia, datos.Mes, datos.Anio))
            {
                mensaje = "Error al validar los datos de la fecha (dia mes año), por favor revisar el archivo";
                return mensaje;
            }

            if (!validaTemperaturas((float)datos.Tmin, (float)datos.Tmax))
            {
                mensaje = "Error al validar los datos de las temperaturas (temperatura mínima mayor que la máxima o rangos no permitidos), por favor revisar el archivo";
                return mensaje;
            }

            if (!validaPrecipitacion(datos.Precipitacion))
            {
                mensaje = "Error al validar los datos de la precipitación (menor a 0 o mayor a 150mm), por favor revisar el archivo";
                return mensaje;
            }

            return mensaje;
        }

        public class ResultadoCargueBD
        {
            public string Variable { get; set; }
            public int Resultado { get; set; }
            public string Mensaje { get; set; }
        }
        public class ListaEncabezadoExcel
        {
            public int PosicionColumna { get; set; }
            public string NombreColumna { get; set; }

        }

        public class ListaExcel
        {

            public double Anio { get; set; }
            public double Mes { get; set; }
            public double Dia { get; set; }
            public double Tmin { get; set; }
            public double Tmax { get; set; }
            public double Precipitacion { get; set; }



        }

        /*Metodo que permite consultar a partir de un identificador el nombre de la columna del excel parametrizada*/
        public string consultaParametroNombreColumnaExcel(string identificador)
        {
            ParametrosCargueMasivo ParametrosBD = new ParametrosCargueMasivo();
            string nombreParametroColumna = "";
            var parametros = from s in db.ParametrosCargueMasivo
                             where (s.Identificador == identificador)
                             select s.NombreColumnaExcel;
            if (parametros.Count() == 1)
            {

                nombreParametroColumna = parametros.FirstOrDefault().Trim();

            }

            return nombreParametroColumna;
        }

        public void asignaResultado(List<ResultadoCargueBD> lista, string variable, int resultado, string mensaje)
        {

            lista.Add(new ResultadoCargueBD
            {
                Variable = variable,
                Resultado = resultado,
                Mensaje = mensaje
            });
        }

        /*En este metodo, a partir de los datos de entrada se crea nueva clase referente  y se asignan los valores
         a insertar, luego se va actualizando el indicador de total de datos de anàlisis insertados (variable retorno) que posrteriormente es leido 
        en la vista  (en el informe de resultados de cargue).*/
        public int guardaActualizaEstacionProductividadUsuario(int usuarioId, DateTime fechaSistema, DateTime fechaProductividad, float valorTmin, float valorTmax,
            float valorPrecipitacion)
        {
            int resultadoAnalisis = 0;

            EstacionProductividadUsuario registro = new EstacionProductividadUsuario();
            registro.UsuarioId = usuarioId;
            registro.FechaProductividad = fechaProductividad;
            registro.FechaSistema = fechaSistema;
            registro.Tmin = valorTmin;
            registro.Tmax = valorTmax;
            registro.Precipitacion = valorPrecipitacion;

            try
            {
                db.EstacionProductividadUsuario.Add(registro);
                db.SaveChanges();
                resultadoAnalisis = resultadoAnalisis + 1;
                return resultadoAnalisis;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                System.Console.WriteLine(e.Message);
                ViewBag.Errores = string.Join("; ", e.Errors);
                return 0;
            }

        }
        /*FIN CARGUE MASIVO EXCEL*/
    }
}