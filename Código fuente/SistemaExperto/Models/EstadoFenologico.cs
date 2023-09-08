using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class EstadoFenologico
    {
        [Key]
        [DisplayName("Código")]
        public int EstadoFenologicoId { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }
    }
}