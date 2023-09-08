using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class EfectosOpciones
    {
        [Key]
        [DisplayName("Código")]
        public int OfectoOpcionId { get; set; }

        [DisplayName("Efecto")]
        public int EfectoId { get; set; }

        [DisplayName("Opcion")]
        public int OpcionId { get; set; }

        //Llaves a
        public virtual Efectos Efecto { get; set; }
        public virtual Opciones Opciones { get; set; }
    }
}