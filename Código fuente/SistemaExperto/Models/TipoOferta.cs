using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class TipoOferta
    {
        [Key]
        [DisplayName("Código")]
        public int TipoOfertaId { get; set; }

        [DisplayName("Nombre Opción")]
        public string Nombre { get; set; }
        
    }
}