using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SistemaExperto.Models
{
    public class SEEntities: DbContext
    {

        public DbSet<EstacionTipo> EstacionTipo { get; set; }
        public DbSet<Estacion> Estacion { get; set; }
        public DbSet<EstacionTipoConstante> EstacionTipoConstante { get; set; }
        public DbSet<EstacionValores> EstacionValores { get; set; }
        public DbSet<EstacionConstantes> EstacionConstantes { get; set; }
        public DbSet<Zona> Zona { get; set; }
        public DbSet<EstacionMensual> EstacionMensual { get; set; }
        public DbSet<ZonaMensual> ZonaMensual { get; set; }
        public DbSet<ZonaEstacion> ZonaEstacion { get; set; }
        public DbSet<ZonaEstacionMensual> ZonaEstacionMensual { get; set; }
        public DbSet<TipoSuelo> TipoSuelo { get; set; }

        public DbSet<Condicion> Condicion { get; set; }
        public DbSet<Cultivo> Cultivo { get; set; }
        public DbSet<CultivoCiclo> CultivoCiclo { get; set; }
        public DbSet<CultivoTipoEtapa> CultivoTipoEtapa { get; set; }

        public DbSet<Departamento> Departamento { get; set; }

        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<MunicipioEscenario> MunicipioEscenario { get; set; }

        public DbSet<Prediccion> Prediccion { get; set; }
        public DbSet<VariablesHistoricas> VariablesHistoricas { get; set; }
      
        public DbSet<TipoPrediccion> TipoPrediccion { get; set; }
        public DbSet<CultivoEtapa> CultivoEtapa { get; set; }

        public DbSet<Ofertas> Ofertas { get; set; }
        public DbSet<Efectos> Efectos { get; set; }
        public DbSet<EfectosAcciones> EfectosAcciones { get; set; }
        public DbSet<TipoOferta> TipoOferta { get; set; }
        public DbSet<AreaTematica> AreaTematica { get; set; }
        public DbSet<OpcionTecnologica> OpcionTecnologica { get; set; }

        public DbSet<ListaOpciones> ListaOpciones { get; set; }

        public DbSet<FichaOpcion> FichaOpcion { get; set; }

        public DbSet<AccionesOpciones> AccionesOpciones { get; set; }
        public DbSet<Opciones> Opciones { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Capas> Capas { get; set; }
        public DbSet<CapasDepartamentos> CapasDepartamentos { get; set; }
        public DbSet<OpcionesVisualizacion> OpcionesVisualizacion { get; set; }
        public DbSet<Convenciones> Convenciones { get; set; }
        public DbSet<Conglomerado> Conglomerado { get; set; }

        public DbSet<CapasMunicipios> CapasMunicipios { get; set; }

        public DbSet<InformacionAmpliaSeccion1> InformacionAmpliaSeccion1 { get; set; }
        public DbSet<InformacionAmpliaSeccion2> InformacionAmpliaSeccion2 { get; set; }

        public DbSet<InformacionAmpliaSec1Mcipio> InformacionAmpliaSec1Mcipio { get; set; }
        public DbSet<InformacionAmpliaSec2Mcipio> InformacionAmpliaSec2Mcipio { get; set; }
        public DbSet<CategoriaProbabilidad> CategoriaProbabilidad { get; set; }

        public DbSet<MunicipioEstacion> MunicipioEstacions { get; set; }

        public DbSet<Termino> Termino { get; set; }
        public DbSet<CultivoProductividad> CultivoProductividad { get; set; }
        //
        public DbSet<ParametrosCargueMasivo> ParametrosCargueMasivo { get; set; }
        //
        public DbSet<CultivoDepartamento> CultivoDepartamento { get; set; }
        public DbSet<EstacionProductividad> EstacionProductividad { get; set; }
        public DbSet<Parametros> Parametros { get; set; }

        public DbSet<SueloProductividad> SueloProductividad { get; set; }
        public DbSet<GrupoCultivo> GrupoCultivo { get; set; }
        public DbSet<EtapaGrupo> EtapaGrupo { get; set; }
        public DbSet<EstacionProductividadUsuario> EstacionProductividadUsuario { get; set; }

        public DbSet<CultivoMunicipio> CultivoMunicipio { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public DbSet<Actividad> Actividad { get; set; }
        public DbSet<SITB_Estacion_1> SITB_Estacion_1 { get; set; }
        public DbSet<SITB_Estacion_2> SITB_Estacion_2 { get; set; }
        public DbSet<SITB_Estacion_3> SITB_Estacion_3 { get; set; }
        public DbSet<SITB_RegIng> SITB_RegIng { get; set; }
        public DbSet<SITB_RegEst> SITB_RegEst { get; set; }
        public DbSet<SIAP> SIAP { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }

}