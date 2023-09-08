using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class ZonaEstacion
    {
        [Key]
        [DisplayName("Código")]
        public int ZonaEstacionId { get; set; }

        [DisplayName("Zona")]
        [Required(ErrorMessage = "Es necesario definir una zona")]
        public int ZonaId { get; set; }

        [DisplayName("Estación")]
        [Required(ErrorMessage = "Es necesario definir una estación")]
        public int EstacionId { get; set; }

        [DisplayName("Porcentaje")]
        [Required(ErrorMessage = "Es necesario definir el porcentaje de la estación para la zona")]
        public int Porcentaje { get; set; }

        [DisplayName("Cadena ET (mm/mes)")]
        [Required(ErrorMessage = "Error")]
        public string CadenaET { get; set; }

        [DisplayName("Cadena PE (mm/mes)")]
        [Required(ErrorMessage = "Error")]
        public string CadenaPE { get; set; }

        [DisplayName("Cadena RO (mm/mes)")]
        [Required(ErrorMessage = "Error")]
        public string CadenaRO { get; set; }

        [DisplayName("Cadena PRO (mm/mes)")]
        [Required(ErrorMessage = "Error")]
        public string CadenaPRO { get; set; }

        [DisplayName("Cadena R (mm/mes)")]
        [Required(ErrorMessage = "Error")]
        public string CadenaR { get; set; }

        [DisplayName("Cadena PR (mm/mes)")]
        [Required(ErrorMessage = "Error")]
        public string CadenaPR { get; set; }

        [DisplayName("Cadena L (mm/mes)")]
        [Required(ErrorMessage = "Es necesario definir la cadena de datos de L")]
        public string CadenaL { get; set; }

        [DisplayName("Cadena PL (mm/mes)")]
        [Required(ErrorMessage = "Es necesario definir la cadena de datos de PL")]
        public string CadenaPL { get; set; }

        [DisplayName("Cantidad de años en la cadena")]
        [Required(ErrorMessage = "Es necesario definir la cantidad a tener en cuenta para el promedio de los coeficientes")]
        public int CantidadCadenas { get; set; }

        [DisplayName("K")]
        [Required(ErrorMessage = "Es necesario definir el factor climático de la estación")]
        public string CadenaKs { get; set; }

        [DisplayName("Z")]
        [Required(ErrorMessage = "Es necesario definir el factor climático de la estación")]
        public string CadenaZs { get; set; }

        [DisplayName("X1")]
        [Required(ErrorMessage = "Es necesario definir el factor climático de la estación")]
        public string CadenaX1s { get; set; }

        [DisplayName("X2")]
        [Required(ErrorMessage = "Es necesario definir el factor climático de la estación")]
        public string CadenaX2s { get; set; }

        [DisplayName("X3")]
        [Required(ErrorMessage = "Es necesario definir el factor climático de la estación")]
        public string CadenaX3s { get; set; }

        public virtual Zona Zona { get; set; }
        public virtual Estacion Estacion { get; set; }

        public virtual ICollection<ZonaEstacionMensual> ZonaEstacionMensual { get; set; }
    }
}