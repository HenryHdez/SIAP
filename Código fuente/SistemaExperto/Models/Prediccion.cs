using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class Prediccion
    {
        [Key]
        [DisplayName("Código")]
        public int PrediccionId { get; set; }

        [DisplayName("Zona - Estación")]
        [Required(ErrorMessage = "Es necesario definir una estación")]
        public int ZonaEstacionId { get; set; }

        [DisplayName("Fecha")]
        public DateTime Fecha { get; set; }

        [DisplayName("R")]
        public double R { get; set; }

        [DisplayName("L")]
        public double L { get; set; }

        [DisplayName("S (Cantidad de agua disponible)")]
        public double S { get; set; }

        [DisplayName("PR (Recarga potencial)")]
        public double PR { get; set; }

        [DisplayName("PL (Pérdida potencial)")]
        public double PL { get; set; }

        [DisplayName("ETr")]
        public double ETr { get; set; }

        [DisplayName("RO")]
        public double RO { get; set; }

        [DisplayName("PRO")]
        public double PRO { get; set; }

        [DisplayName("d (Deficiencia hídrica)")]
        public double d { get; set; }

        [DisplayName("Z")]
        public double Z { get; set; }

        [DisplayName("X")]
        public double X { get; set; }

        public virtual ZonaEstacion ZonaEstacion { get; set; }
    }
}