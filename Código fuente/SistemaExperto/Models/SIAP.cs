using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class SIAP
    {
        [Key]
        [DisplayName("Código")]
        public int CondicionId { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Es necesario definir un nombre para la categoria")]
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
    }
}