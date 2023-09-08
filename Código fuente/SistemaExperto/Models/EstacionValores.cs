using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class EstacionValores
    {
        //Código 
        [Key]
        [DisplayName("Código")]
        public int EstacionValoresId { get; set; }

        [DisplayName("Año")]
        public int Anio { get; set; }

        //Identificador del nombre de la constante
        [DisplayName("Constante Id")]
        [Required(ErrorMessage = "Es necesario definir un id de la constante")]
        public int EstacionTipoConstanteId { get; set; }

        //Valor Enero
        [DisplayName("Enero")]
        [Required(ErrorMessage = "Es necesario definir un valor")]
        public float Enero { get; set; }

        //Valor Febrero
        [DisplayName("Febrero")]
        [Required(ErrorMessage = "Es necesario definir un valor")]
        public float Febrero { get; set; }

        //Valor Marzo
        [DisplayName("Marzo")]
        [Required(ErrorMessage = "Es necesario definir un valor")]
        public float Marzo { get; set; }

        //Valor Abril
        [DisplayName("Abril")]
        [Required(ErrorMessage = "Es necesario definir un valor")]
        public float Abril { get; set; }

        //Valor Mayo
        [DisplayName("Mayo")]
        [Required(ErrorMessage = "Es necesario definir un valor")]
        public float Mayo { get; set; }

        //Valor Junio
        [DisplayName("Junio")]
        [Required(ErrorMessage = "Es necesario definir un valor")]
        public float Junio { get; set; }

        //Valor Julio
        [DisplayName("Julio")]
        [Required(ErrorMessage = "Es necesario definir un valor")]
        public float Julio { get; set; }

        //Valor Agosto
        [DisplayName("Agosto")]
        [Required(ErrorMessage = "Es necesario definir un valor")]
        public float Agosto { get; set; }

        //Valor Septiembre
        [DisplayName("Septiembre")]
        [Required(ErrorMessage = "Es necesario definir un valor")]
        public float Septiembre { get; set; }

        //Valor Octubre
        [DisplayName("Octubre")]
        [Required(ErrorMessage = "Es necesario definir un valor")]
        public float Octubre { get; set; }

        //Valor Noviembre
        [DisplayName("Noviembre")]
        [Required(ErrorMessage = "Es necesario definir un valor")]
        public float Noviembre { get; set; }

        //Valor Diciembre
        [DisplayName("Diciembre")]
        [Required(ErrorMessage = "Es necesario definir un valor")]
        public float Diciembre { get; set; }
        
        // referencia a tabla EstacionTipoConstante
        public virtual EstacionTipoConstante EstacionTipoConstante { get; set; }

        //Llamado desde la tabla de relación entre constantes y estación
        public virtual ICollection<EstacionConstantes> EstacionConstantes { get; set; }
    }
}