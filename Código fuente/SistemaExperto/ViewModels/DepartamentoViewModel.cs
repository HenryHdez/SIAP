using System.Collections.Generic;
using SistemaExperto.Models;

public class DepartamentoViewModel
{
    public Departamento Departamento { get; set; }

    public IEnumerable<Departamento>OtrosDepartamentos { get; set; }
    public IEnumerable<CapasDepartamentos> CapasDepartamentos { get; set; }
    public IEnumerable<Municipio> Municipio { get; set; }

    //public Capas Capas { get; set; }
    public IEnumerable<Capas> Capas { get; set; }
    public IEnumerable<OpcionesVisualizacion> OpcionesVisualizacion { get; set; }
    public IEnumerable<ListaConvenciones> Convenciones { get; set; }
    public IEnumerable<ListaCaracterizaciones> ListaCaracterizacion { get; set; }
    public IEnumerable<InformacionAmpliaSeccion1> InformacionAmpliaSeccion1 { get; set; }
    public IEnumerable<InformacionAmpliaSeccion2> InformacionAmpliaSeccion2 { get; set; }
    public IEnumerable<ListaSubzonas> ListaSubzona { get; set; }
    public IEnumerable<ListaConglomerados> ListaConglomerado { get; set; }
    public IEnumerable<ListaNinoNina> ListaNinoNinaPptT { get; set; }
    public IEnumerable<ListaAmenazas> ListaAmenaza { get; set; }
    public IEnumerable<Conglomerado> Conglomerados { get; set; }

    public IEnumerable<Termino> Terminos { get; set; }
    public class ListaConvenciones
    {
        public int ListaConvencionesId { get; set; }
        public string Convencion { get; set; }
        public string Categoria { get; set; }
        public int CodigoCapa { get; set; }
    }
    public class ListaSubzonas
    {
        public int OpcionId { get; set; }
        public int ConvencionId { get; set; }
        public string Identificador { get; set; }
        public string Categoria { get; set; }
        public string Convencion { get; set; }
    };
    public class ListaConglomerados
    {
        public string Layer { get; set; }
        public string Convencion { get; set; }
    };
    public class ListaCaracterizaciones
    {

        public int CapaId { get; set; }
        public int OpcionId { get; set; }
        public int ConvencionId { get; set; }
        public string Identificador { get; set; }
        public string Categoria { get; set; }
        public string Convencion { get; set; }
    };
    public class ListaNinoNina
    {
        public int CapaId { get; set; }
        public int OpcionId { get; set; }
        public int ConvencionId { get; set; }
        public string Identificador { get; set; }
        public string Categoria { get; set; }
        public string Convencion { get; set; }
    };
    public class ListaAmenazas
    {
        public int CapaId { get; set; }
        public int OpcionId { get; set; }
        public int ConvencionId { get; set; }
        public string Identificador { get; set; }
        public string Categoria { get; set; }
        public string Convencion { get; set; }
    };
}