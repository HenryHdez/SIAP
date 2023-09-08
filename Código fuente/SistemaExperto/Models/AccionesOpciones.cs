using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class AccionesOpciones
    {
        [Key]
        [DisplayName("Código")]
        public int AccionOpcionId { get; set; }

        [DisplayName("Acción")]
        public int AccionId { get; set; }

        [DisplayName("Opcion")]
        public int OpcionId { get; set; }

        //Llaves a
        public virtual OpcionTecnologica Accion { get; set; }
        public virtual Opciones Opciones { get; set; }
    }
}