using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaExperto.Models
{
    public class TipoSuelo
    {
        //Código del tipo de suelo
        [Key]
        [DisplayName("Código")]
        public int TipoSueloId { get; set; }

        //Nombre o identificador del tipo de suelo
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string Nombre { get; set; }

        //Nombre o identificador del tipo de suelo
        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Es necesario definir una descripción")]
        public string Descripcion { get; set; }

        public virtual ICollection<Zona> Zona { get; set; }

        public virtual ICollection<SueloProductividad> SueloProductividad { get; set; }
    }
}
