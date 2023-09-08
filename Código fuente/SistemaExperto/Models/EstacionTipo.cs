using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class EstacionTipo
    {
        [Key]
        [DisplayName("Código")]
        public int EstacionTipoId { get; set; }

        [DisplayName("Tipo")]
        public string Tipo { get; set; }

        [DisplayName("Radio")]
        public double Radio { get; set; }

        //Llamado desde la tabla estación
        public virtual ICollection<Estacion> Estacion { get; set; }
    }
}