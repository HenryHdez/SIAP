using System.Collections.Generic;
using SistemaExperto.Models;

public class MunicipioViewModel
{
    public Municipio Municipio { get; set; }
    public IEnumerable<Departamento> OtrosDepartamentos { get; set; }
    public IEnumerable<Municipio> OtrosMunicipios { get; set; }
    public IEnumerable<CapasMunicipios> CapasMunicipios { get; set; }
    public IEnumerable<Zona> Zona { get; set; }
    public IEnumerable<Capas> Capas { get; set; }
    public IEnumerable<OpcionesVisualizacion> OpcionesVisualizacion { get; set; }
    public IEnumerable<MunicipioEstacion> MunicipioEstacion { get; set; }
    public IEnumerable<EstacionMensual> EstacionMensual { get; set; }
    public IEnumerable<ListaEscenarios> ListaEscenario { get; set; }
    public IEnumerable<ListaAptitudes> ListaAptitud { get; set; }
    public IEnumerable<ListaConvenciones> Convenciones { get; set; }

    
    //public IEnumerable<Convenciones> ConvencionEstacionMunicipio { get; set; }
    public IEnumerable<InformacionAmpliaSec1Mcipio> InformacionAmpliaSec1Mcipio { get; set; }
    public IEnumerable<InformacionAmpliaSec2Mcipio> InformacionAmpliaSec2Mcipio { get; set; }

    public IEnumerable<Condicion> condiciones { get; set; }
    public class ListaEscenarios
    {
        public string Categoria { get; set; }
        public string Convencion { get; set; }
        public int Mes { get; set; }
        public int CondicionId { get; set; }
    };
    public class ListaAptitudes
    {
        public int OpcionId { get; set; }
        public int ConvencionId { get; set; }
        public string Identificador { get; set; }
        public string Categoria { get; set; }
        public string Convencion { get; set; }
    };

    public class ListaConvenciones
    {
        public int ListaConvencionesId { get; set; }
        public string Convencion { get; set; }
        public string Categoria { get; set; }

        public int OpcionPadre { get; set; }

        public string color { get; set; }
    }
}
