using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class Opciones
    {
        [Key]
        [DisplayName("Código")]
        public int OpcionId { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Resumen")]
        public string Resumen { get; set; }

        [DisplayName("Explicación")]
        public string Explicacion { get; set; }

        [DisplayName("Información adicional")]
        public string InformacionAdicional { get; set; }
    }
}