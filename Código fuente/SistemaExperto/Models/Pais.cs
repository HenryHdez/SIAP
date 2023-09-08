using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace SistemaExperto.Models
{
    public class Pais
    {
        [Key]
        [DisplayName("Código de país")]
        public int PaisId { get; set; }

        [DisplayName("País")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }

    }
}