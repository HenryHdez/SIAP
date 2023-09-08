using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class OpcionTecnologica
    {
        [Key]
        [DisplayName("Código")]
        public int OpcionTecnologicaId { get; set; }

        [DisplayName("Nombre OT")]
        public string Nombre { get; set; }

        [DisplayName("Código Area Temática")]
        public int AreaTematicaId { get; set; }

        public virtual AreaTematica AreaTematica { get; set; }
    }
}