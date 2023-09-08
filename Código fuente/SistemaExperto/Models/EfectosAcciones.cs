using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class EfectosAcciones
    {
        [Key]
        [DisplayName("Código")]
        public int EfectoAccionId { get; set; }

        [DisplayName("Efecto")]
        public int EfectoId { get; set; }

        [DisplayName("Acción")]
        public int AccionId { get; set; }

        //Llaves a
        public virtual Efectos Efecto { get; set; }
        public virtual OpcionTecnologica Accion { get; set; }
    }
}