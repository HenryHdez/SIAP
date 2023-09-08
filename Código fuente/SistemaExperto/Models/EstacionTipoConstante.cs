using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class EstacionTipoConstante
    {
        //Código 
        [Key]
        [DisplayName("Código")]
        public int EstacionTipoConstanteId { get; set; }

        //Nombre de la constante 
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string Nombre { get; set; }

        //Etiqueta de la constante 
        [DisplayName("Etiqueta")]
        [Required(ErrorMessage = "Es necesario definir una etiqueta")]
        public string Etiqueta { get; set; }

        //Llamado desde la tabla de relación entre constantes y estación
        //public virtual ICollection<EstacionConstantes> EstacionConstantes { get; set; }

        //Llamado desde la tabla de relación entre constantes y estación
        public virtual ICollection<EstacionValores> EstacionValores { get; set; }
    }
}