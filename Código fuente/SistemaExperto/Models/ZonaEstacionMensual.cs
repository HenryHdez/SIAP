using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class ZonaEstacionMensual
    {
        [Key]
        [DisplayName("Código")]
        public int ZonaEstacionMensualId { get; set; }

        [DisplayName("Zona - Estacion")]
        public int ZonaEstacionId { get; set; }

        [DisplayName("Mes")]
        public int Mes { get; set; }

        [DisplayName("Año")]
        public int Anho { get; set; }

        [DisplayName("ET")]
        public double ET { get; set; }

        [DisplayName("PE")]
        public double PE { get; set; }

        [DisplayName("RO")]
        public double RO { get; set; }

        [DisplayName("PRO")]
        public double PRO { get; set; }

        [DisplayName("R")]
        public double R { get; set; }

        [DisplayName("PR")]
        public double PR { get; set; }

        [DisplayName("L")]
        public double L { get; set; }

        [DisplayName("PL")]
        public double PL { get; set; }

        [DisplayName("K")]
        public double K { get; set; }

        [DisplayName("Z")]
        public double Z { get; set; }

        [DisplayName("X1")]
        public double X1 { get; set; }

        [DisplayName("X2")]
        public double X2 { get; set; }

        [DisplayName("X3")]
        public double X3 { get; set; }

        public virtual ZonaEstacion ZonaEstacion { get; set; }
    }
}