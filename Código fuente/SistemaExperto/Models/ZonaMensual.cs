using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class ZonaMensual
    {
        [Key]
        [DisplayName("Código")]
        public int ZonaMensualId { get; set; }

        [DisplayName("Zona")]
        [Required(ErrorMessage = "Es necesario definir una zona")]
        public int ZonaId { get; set; }

        [DisplayName("Fecha")]
        [Required(ErrorMessage = "Es necesario definir un mes")]
        public DateTime Fecha { get; set; }

        [DisplayName("Humedad inicial para la capa superior")]
        [Required(ErrorMessage = "Es necesario definir el valor de Ss0")]
        public double Ss0 { get; set; }

        [DisplayName("Humedad inicial para la capa inferior")]
        [Required(ErrorMessage = "Es necesario definir el valor de Su0")]
        public double Su0 { get; set; }

        public virtual Zona Zona { get; set; }
    }
}