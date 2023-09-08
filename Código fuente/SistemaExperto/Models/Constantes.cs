using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class Constantes
    {
        [Key]
        [DisplayName("Código")]
        public int ConstanteId { get; set; }

        [DisplayName("Gs (Constante Solar)")]
        [Required(ErrorMessage = "Es necesario definir la constante solar")]
        public double Gs { get; set; }

        [DisplayName("Ks")]
        [Required(ErrorMessage = "Es necesario definir Ks")]
        public double Ks { get; set; }

        [DisplayName("Alpha")]
        [Required(ErrorMessage = "Es necesario definir Alpha")]
        public double Alpha { get; set; }

        [DisplayName("S")]
        [Required(ErrorMessage = "Es necesario definir S")]
        public double S { get; set; }

        [DisplayName("G")]
        [Required(ErrorMessage = "Es necesario definir G")]
        public double G { get; set; }
    }
}