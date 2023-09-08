using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class Efectos
    {
        [Key]
        [DisplayName("Código")]
        public int EfectoId { get; set; }

        [DisplayName("Efecto")]
        public string Nombre { get; set; }
    }
}