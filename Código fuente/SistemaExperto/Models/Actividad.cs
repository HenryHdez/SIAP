
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaExperto.Models
{
    public class Actividad
    {
        [Key]
        [DisplayName("Código")]
        public int ActividadId { get; set; }

        [DisplayName("Municipio")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string Nombre { get; set; }

        public virtual ICollection<SistemaExperto.Models.Usuario> Usuario { get; set; }
    }
}