using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;
using System.Globalization;

namespace SE.Controllers
{
    public class RegionalController : Controller
    {
        private SEEntities db = new SEEntities();

        //Fecha actual del sistema
        DateTime fechaActual = System.DateTime.Today;

        //
        // GET: /Regional/

        public ActionResult Pais()
        {
            IEnumerable<Departamento> departamentos = db.Departamento
                .Where(d => d.Coordenadas != null)
                .OrderBy(d => d.Nombre);
            return View(departamentos);
        }

        public ActionResult Departamento(string codigoDane)
        {
            //Consulta del departamento seleccionado
            Departamento departamento = db.Departamento.Where(cd => cd.CodigoDane == codigoDane).FirstOrDefault();

            //ViewBag.Dpto = codigoDane;
            //ViewBag.DptoNom = departamento.Nombre;
            //ViewBag.Coordenadas = departamento.Coordenadas;

            int DepartamentoId = departamento.DepartamentoId;

            IEnumerable<Municipio> municipio = db.Municipio.Where(z => z.Departamento.DepartamentoId.Equals(DepartamentoId))
                .Where(d=>d.Box!=null).OrderBy(m => m.Nombre);

            IEnumerable<CapasDepartamentos> capasDepartamento = db.CapasDepartamentos.Where(cd => cd.DepartamentoId == DepartamentoId);

            IEnumerable<Capas> capas = from Capas in db.Capas.AsEnumerable()
                                       select Capas;

            IEnumerable<OpcionesVisualizacion> opciones = from OpcionesVisualizacion in db.OpcionesVisualizacion.AsEnumerable()
                                                          select OpcionesVisualizacion;

            IEnumerable<Convenciones> convenciones = db.Convenciones.Where(c => c.OpcionVisualizacionId <= 20);

            IEnumerable<InformacionAmpliaSeccion1> infoAmpliaSeccion1 = from informacionAmpliaSeccion1 in db.InformacionAmpliaSeccion1.AsEnumerable()
                                                                        select informacionAmpliaSeccion1;
            IEnumerable<InformacionAmpliaSeccion2> infoAmpliaSeccion2 = from informacionAmpliaSeccion2 in db.InformacionAmpliaSeccion2.AsEnumerable()
                                                                        select informacionAmpliaSeccion2;

            IEnumerable<Conglomerado> conglomerados = db.Conglomerado.Where(c => c.DepartamentoId == DepartamentoId);
            
            //para lista de otros departamentos
            IEnumerable<Departamento> OtrosDeptos = db.Departamento.Where(c => c.DepartamentoId != DepartamentoId)
                .Where(d => d.Coordenadas != null)
                .OrderBy(d=>d.Nombre);

            foreach (Convenciones convencion in convenciones.Where(c => c.OpcionVisualizacionId == 4))
            {
                foreach (Conglomerado conglomerado in conglomerados)
                {
                    if (conglomerado.CodigoMapa.ToString() == convencion.ValorLayer)
                    {
                        convencion.NombreIndicador = conglomerado.Nombre;
                    }
                }
            }

            //Convenciones que se envían al script de estilos para visualización de leyenda
            IEnumerable<DepartamentoViewModel.ListaConvenciones> listaConvenciones = convenciones.Select(s => new DepartamentoViewModel.ListaConvenciones()
            {
                ListaConvencionesId = s.ConvencionId,
                Convencion = s.NombreIndicador,
                Categoria = s.ValorLayer,
                CodigoCapa = s.OpcionVisualizacionId
            });

            //Carga de lista de subzonas para globos de mapas
            IEnumerable<DepartamentoViewModel.ListaSubzonas> subzonas = db.OpcionesVisualizacion.Join(db.Convenciones, op => op.OpcionVisualizacionId, c => c.OpcionVisualizacionId, (op, c) => new { op, c }).Where(me => me.op.Capa.IdentificadorCaracterizacion == "subzonas")
                .Select(subzona => new DepartamentoViewModel.ListaSubzonas { OpcionId = subzona.op.OpcionVisualizacionId, ConvencionId = subzona.c.ConvencionId, Identificador = subzona.op.NombreCortoOpcion, Categoria = subzona.c.ValorLayer, Convencion = subzona.c.NombreIndicador });

            //Carga de lista de conglomerados
            IEnumerable<DepartamentoViewModel.ListaConglomerados> lconglomerados = db.Conglomerado.Where(me => me.DepartamentoId == DepartamentoId)
                .Select(cong => new DepartamentoViewModel.ListaConglomerados { Layer = cong.CodigoMapa.ToString(), Convencion = cong.Nombre });


            //Carga de lista de convencionescaracterizacion para globos de mapas
            IEnumerable<DepartamentoViewModel.ListaCaracterizaciones> caracterizaciones = db.OpcionesVisualizacion.Join(db.Convenciones, op => op.OpcionVisualizacionId, c => c.OpcionVisualizacionId, (op, c) => new { op, c }).Where(me => me.op.Capa.CapaId > 2).Where(me => me.op.Capa.CapaId < 9)
                .Select(conv => new DepartamentoViewModel.ListaCaracterizaciones { CapaId = conv.op.CapaId, OpcionId = conv.op.OpcionVisualizacionId, ConvencionId = conv.c.ConvencionId, Identificador = conv.op.NombreCortoOpcion, Categoria = conv.c.ValorLayer, Convencion = conv.c.NombreIndicador });

            //Carga de lista de convencionesnino y nina ppt y temperatura para globos de mapas
            IEnumerable<DepartamentoViewModel.ListaNinoNina> ninonina = db.OpcionesVisualizacion.Join(db.Convenciones, op => op.OpcionVisualizacionId, c => c.OpcionVisualizacionId, (op, c) => new { op, c }).Where(me => me.op.Capa.CapaId > 8).Where(me => me.op.Capa.CapaId < 11)
                .Select(conv => new DepartamentoViewModel.ListaNinoNina { CapaId = conv.op.CapaId, OpcionId = conv.op.OpcionVisualizacionId, ConvencionId = conv.c.ConvencionId, Identificador = conv.op.NombreCortoOpcion, Categoria = conv.c.ValorLayer, Convencion = conv.c.NombreIndicador });

            //Carga de lista de convenciones Amenazas para globos de mapas
            IEnumerable<DepartamentoViewModel.ListaAmenazas> amenazas = db.OpcionesVisualizacion.Join(db.Convenciones, op => op.OpcionVisualizacionId, c => c.OpcionVisualizacionId, (op, c) => new { op, c }).Where(me => me.op.Capa.CapaId > 10).Where(me => me.op.Capa.CapaId < 13)
                .Select(conv => new DepartamentoViewModel.ListaAmenazas { CapaId = conv.op.CapaId, OpcionId = conv.op.OpcionVisualizacionId, ConvencionId = conv.c.ConvencionId, Identificador = conv.op.NombreCortoOpcion, Categoria = conv.c.ValorLayer, Convencion = conv.c.NombreIndicador });

            // para glosario:
            IEnumerable<Termino> terminos = db.Termino;
            return View(new DepartamentoViewModel()
            {
                Departamento = departamento,
                OtrosDepartamentos = OtrosDeptos,
                CapasDepartamentos = capasDepartamento,
                Municipio = municipio,
                OpcionesVisualizacion = opciones,
                Capas = capas,
                Convenciones = listaConvenciones,
                ListaSubzona = subzonas,
                ListaCaracterizacion = caracterizaciones,
                ListaConglomerado = lconglomerados,
                ListaNinoNinaPptT = ninonina,
                ListaAmenaza = amenazas,
                InformacionAmpliaSeccion1 = infoAmpliaSeccion1,
                InformacionAmpliaSeccion2 = infoAmpliaSeccion2,
                Conglomerados = conglomerados,
                Terminos = terminos
            });
        }

        public ActionResult Municipio(string codigoDane)
        {

            //ViewBag.Coordenadas = box;
            ViewBag.Municipio = codigoDane;
            ViewBag.TieneZonas = "si";

            Municipio municipio = db.Municipio.Where(cd => cd.CodigoDane == codigoDane).FirstOrDefault();
            int MunicipioId = db.Municipio.Where(cd => cd.CodigoDane == codigoDane).FirstOrDefault().MunicipioId;

            int DepartamentoId = db.Municipio.Where(cd => cd.CodigoDane == codigoDane).FirstOrDefault().DepartamentoId;

            Zona zonaV = db.Zona.Where(z => z.Municipio.CodigoDane == codigoDane).FirstOrDefault();

            IEnumerable<Zona> zona = new List<Zona>();

            // CultivoCiclo cicloCultivo = municipio.CultivoCiclo.FirstOrDefault();

            CultivoCiclo cicloCultivo = db.CultivoCiclo.Where(c => c.MunicipioId == MunicipioId).FirstOrDefault();

            ViewBag.NoEscenarios = "false";

            if (cicloCultivo != null)
            {
                CultivoTipoEtapa primeraEtapaCultivo = cicloCultivo.CultivoTipoEtapa.FirstOrDefault();

                if (primeraEtapaCultivo != null)
                {
                    //Ajuste en caso de que no se tengan todas las condiciones (húmedo, normal, seco)
                    int filtroCondicion = 0;
                    if (municipio.CultivoCiclo.Where(c => c.CondicionId == 0).Count() == 0)
                    {
                        filtroCondicion = 1;
                    }
                    else if (municipio.CultivoCiclo.Where(c => c.CondicionId == 1).Count() == 0)
                    {
                        filtroCondicion = 2;
                    }

                    var mesInicio = municipio.CultivoCiclo.Where(c => c.CondicionId == filtroCondicion).FirstOrDefault().CultivoTipoEtapa.OrderBy(ce => ce.CultivoEtapa.Orden).FirstOrDefault().MesInicio;
                    var mesFinal = municipio.CultivoCiclo.LastOrDefault(c => c.CondicionId == filtroCondicion).CultivoTipoEtapa.OrderBy(ce => ce.CultivoEtapa.Orden).LastOrDefault().MesInicio;
                    var duracion = municipio.CultivoCiclo.FirstOrDefault(c => c.CondicionId == filtroCondicion).CultivoTipoEtapa.OrderBy(ce => ce.CultivoEtapa.Orden).LastOrDefault().Duracion;
                    if (mesInicio > mesFinal)
                    {
                        mesFinal = mesFinal + 12;
                    }
                    ViewBag.CultivoDuracion = (mesFinal + duracion) - mesInicio;
                    ViewBag.CultivoInicio = mesInicio;
                }
                else
                {
                    ViewBag.NoEscenarios = "true";
                }

            }
            else
            {
                ViewBag.NoEscenarios = "true";
            }

            //Búsqueda de ciclos en el municipio seleccionado
            IEnumerable<CultivoCiclo> listaCultivoCiclo = db.CultivoCiclo.Where(cc => cc.MunicipioId == MunicipioId);

            //Lista de meses que se deben solicitar para cargar los mapas según los ciclos encontrados
            HashSet<int> meses = new HashSet<int>();
            foreach (CultivoCiclo cultivoCiclo in listaCultivoCiclo)
            {
                IEnumerable<CultivoTipoEtapa> listaCultivoTipoEtapa = db.CultivoTipoEtapa.Where(cte => cte.CultivoCicloId == cultivoCiclo.CultivoCicloId);

                foreach (CultivoTipoEtapa cultivoTipoEtapa in listaCultivoTipoEtapa)
                {
                    int mesInicial = cultivoTipoEtapa.MesInicio;
                    int duracionMeses = cultivoTipoEtapa.Duracion;
                    for (int i = mesInicial; i <= mesInicial + duracionMeses; i++)
                    {
                        int j = i;
                        if (j > 12) j = j - 12;
                        meses.Add(j);
                    }
                }
            }
            ViewBag.NumerosMeses = meses.ToList();

            if (municipio.CultivoCiclo.FirstOrDefault() != null)
                ViewBag.CultivoNombre = municipio.CultivoCiclo.FirstOrDefault().Cultivo.IndicadorMapa;

            if (zonaV != null)
            {
                zona = db.Zona.Where(z => z.Municipio.CodigoDane.Equals(codigoDane));

                int zonaId = db.Zona.Where(z => z.Municipio.CodigoDane == codigoDane).FirstOrDefault().ZonaId;

                Cultivo cultivo = db.Cultivo.Where(z => z.CultivoId == zona.FirstOrDefault().CultivoId).FirstOrDefault();
            }
            else
            {
                zona = db.Zona;
                ViewBag.TieneZonas = "no";
            }

            IEnumerable<CapasMunicipios> capasMunicipio = db.CapasMunicipios.Where(cd => cd.MunicipioId == MunicipioId);

            IEnumerable<Capas> capas = from Capas in db.Capas.AsEnumerable()
                                       select Capas;

            IEnumerable<OpcionesVisualizacion> opciones = from OpcionesVisualizacion in db.OpcionesVisualizacion.AsEnumerable()
                                                          select OpcionesVisualizacion;

            IEnumerable<MunicipioViewModel.ListaConvenciones> convenciones = from Convenciones in db.Convenciones.Where(c => c.OpcionVisualizacionId > 20)
                                                                             select new MunicipioViewModel.ListaConvenciones()
                                                                             {
                                                                                 ListaConvencionesId = Convenciones.ConvencionId,
                                                                                 Convencion = Convenciones.NombreIndicador,
                                                                                 Categoria = Convenciones.ValorLayer,
                                                                                 OpcionPadre= Convenciones.OpcionVisualizacionId,
                                                                                 color = Convenciones.Color
                                                                             };
            
            MunicipioEstacion estacionesV = db.MunicipioEstacions.Where(z => z.MunicipioId == MunicipioId).FirstOrDefault();        
            IEnumerable<MunicipioEstacion> estaciones = new List<MunicipioEstacion>();

            IEnumerable<EstacionMensual> estacionMensual = new List<EstacionMensual>();

            ViewBag.TieneEstaciones = "si";

            if (estacionesV != null)
            {
                estaciones = db.MunicipioEstacions.Where(z => z.MunicipioId == MunicipioId);

                //DateTime hoy = System.DateTime.Today.AddMonths(1);
                DateTime hoy = System.DateTime.Today.AddDays(15);
                estacionMensual = db.EstacionMensual.Where(z => z.Fecha.Month == hoy.Month && z.Fecha.Year == hoy.Year);
            }
            else
            {
                estaciones = db.MunicipioEstacions;
                estacionMensual = db.EstacionMensual;
                ViewBag.TieneEstaciones = "no";
            }

            IEnumerable<InformacionAmpliaSec1Mcipio> informacionAmpliaSec1Mcipio = from informacionAmpliaSeccion1 in db.InformacionAmpliaSec1Mcipio.AsEnumerable()
                                                                                   select informacionAmpliaSeccion1;

            IEnumerable<InformacionAmpliaSec2Mcipio> informacionAmpliaSec2Mcipio = from InformacionAmpliaSec2Mcipio in db.InformacionAmpliaSec2Mcipio.AsEnumerable()
                                                                                   select InformacionAmpliaSec2Mcipio;

            //Valida si se tiene prediccion para Ingresar al modulo Local
            //Revisa si el mes ya pasó del día 15, para saber si hace el cálculo con el mes actual o con el siguiente
            if (fechaActual.Day > 15)
            {
                fechaActual = fechaActual.AddMonths(1);
            }
            int mesActual = fechaActual.Month;
            string nombreMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mesActual).ToString();
            ViewBag.Mes = nombreMes;

            Zona zonaPrediccion = db.Zona.Where(z => z.Municipio.CodigoDane == codigoDane).FirstOrDefault();

            if (zonaPrediccion != null)
            {   
                //#CambioPalmerSPI
                //int zonaIdP = db.Zona.Where(z => z.Municipio.CodigoDane == codigoDane).FirstOrDefault().ZonaId;

                int zonaIdP = zonaPrediccion.ZonaId;
                IQueryable<ZonaEstacion> estacionesZona = db.ZonaEstacion.Where(e => e.ZonaId == zonaIdP);
                EstacionMensual estacionMensual1 = db.EstacionMensual.Where(pc => pc.EstacionId == estacionesZona.FirstOrDefault().EstacionId).
                    Where(pc => pc.Fecha.Year == fechaActual.Year).Where(pc => pc.Fecha.Month == fechaActual.Month).FirstOrDefault();

                // if (prediccion != null)
                if (estacionMensual1 != null)
                {
                    bool existe = estacionMensual1.ExistePrediccion;
                    if (existe)
                    {
                        ViewBag.IndicadorPrediccion = 1;
                    }
                    else
                    {
                        ViewBag.IndicadorPrediccion = 0;
                    }
                }
            }
            else
            {
                ViewBag.IndicadorPrediccion = 0;
            }

            //Carga de lista de escenarios
            IEnumerable<MunicipioViewModel.ListaEscenarios> escenarios = db.MunicipioEscenario.Where(me => me.MunicipioId == MunicipioId).Select(escenario => new MunicipioViewModel.ListaEscenarios {
                Categoria = escenario.Codigo,
                Convencion = escenario.Descripcion,
                CondicionId = escenario.CondicionId,
                Mes = escenario.Mes
            });

            //Carga de lista de aptitudes
            IEnumerable<MunicipioViewModel.ListaAptitudes> aptitudes = db.OpcionesVisualizacion.Join(db.Convenciones, op => op.OpcionVisualizacionId, c => c.OpcionVisualizacionId, (op, c) => new { op, c }).Where(me => me.op.Capa.IdentificadorCaracterizacion == "aptitud")
                .Select(aptitud => new MunicipioViewModel.ListaAptitudes {
                    OpcionId = aptitud.op.OpcionVisualizacionId,
                    ConvencionId = aptitud.c.ConvencionId,
                    Identificador = aptitud.op.NombreCortoOpcion,
                    Categoria = aptitud.c.ValorLayer,
                    Convencion = aptitud.c.NombreIndicador
                });

            //List<Condicion> condiciones = db.Condicion.ToList();
            IEnumerable<Condicion> condicion = from Condicion in db.Condicion.AsEnumerable()
                                               select Condicion;

            //para lista de otros departamentos
            //IEnumerable<Departamento> OtrosDeptos = db.Departamento.Where(c => c.DepartamentoId != DepartamentoId).OrderBy(d => d.Nombre);
            IEnumerable<Departamento> OtrosDeptos = db.Departamento
                .Where(d=>d.Coordenadas!=null)
                .OrderBy(d => d.Nombre);

            //Para lista de otros municipios
            IEnumerable<Municipio> OtrosMunicipios = db.Municipio.Where(z => z.Departamento.DepartamentoId.Equals(DepartamentoId))
                .Where(m => m.Box != null)
                .Where(m=>m.MunicipioId!=MunicipioId)
                .OrderBy(m => m.Nombre);

            return View(new MunicipioViewModel()
            {
                Municipio = municipio,
                OtrosDepartamentos = OtrosDeptos,
                OtrosMunicipios =OtrosMunicipios,
                CapasMunicipios = capasMunicipio,
                Zona = zona,
                OpcionesVisualizacion = opciones,
                Capas = capas,
                Convenciones = convenciones,
                MunicipioEstacion = estaciones,
                EstacionMensual = estacionMensual,
                ListaEscenario = escenarios,
                ListaAptitud = aptitudes,
                InformacionAmpliaSec1Mcipio = informacionAmpliaSec1Mcipio,
                InformacionAmpliaSec2Mcipio = informacionAmpliaSec2Mcipio,
                condiciones = condicion
            });
        }
    }
}
