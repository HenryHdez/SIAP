using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class AreaTematica
    {
        [Key]
        [DisplayName("Identificador Area")]
        public int AreaTematicaId { get; set; }

        [DisplayName("Código Area")]
        public int Codigo { get; set; }

        [DisplayName("Nombre Area")]
        public string Nombre { get; set; }
    }
}