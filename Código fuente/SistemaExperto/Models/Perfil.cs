using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaExperto.Models
{
    public class Perfil
    {
        [Key]
        [DisplayName("Código")]
        public int PerfilId { get; set; }

        [DisplayName("Nombre Perfil")]
        [Required(ErrorMessage = "Es necesario definir un perfil")]
        public string Nombre { get; set; }

        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }
    }
}
