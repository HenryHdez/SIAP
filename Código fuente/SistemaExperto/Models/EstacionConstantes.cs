using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class EstacionConstantes
    {
        //Código 
        [Key]
        [DisplayName("Código")]
        public int EstacionConstantesId { get; set; }

        //Identificador de la estación
        [DisplayName("Estación")]
        [Required(ErrorMessage = "Es necesario definir una estación")]
        public int EstacionId { get; set; }

        //Identificador del nombre de la constante
        //[DisplayName("Constante")]
        //[Required(ErrorMessage = "Es necesario definir una constante")]
        //public int EstacionTipoConstanteId { get; set; }

        //Identificador de los valores de la constante
        [DisplayName("Valor")]
        [Required(ErrorMessage = "Es necesario definir un valor")]
        public int EstacionValoresId { get; set; }

        //Llave a la tabla de tipos de constante
       // public virtual EstacionTipoConstante EstacionTipoConstante { get; set; }
        //Llave a la tabla de valores
        public virtual EstacionValores EstacionValores { get; set; }

        //Llamado a la tabla de estaciones
        public virtual Estacion Estacion { get; set; }
    }
}