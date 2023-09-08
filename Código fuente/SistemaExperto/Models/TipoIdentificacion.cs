using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class TipoIdentificacion
    {
        [Key]
        [DisplayName("Código")]
        public int TipoIdentificacionId { get; set; }

        [DisplayName("TipoIdentificacion")]
        public string Nombre { get; set; }
        //Llamado desde la tabla de Usuarios
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
