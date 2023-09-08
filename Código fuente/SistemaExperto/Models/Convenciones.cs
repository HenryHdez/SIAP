using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class Convenciones
    {
        [Key]
        [DisplayName("Código")]
        public int ConvencionId { get; set; }

        [DisplayName("Nombre indicador convención")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string NombreIndicador { get; set; }

        [DisplayName("Valor convención layer")]
        //[Required(ErrorMessage = "Es necesario definir un valor")]
        public string ValorLayer { get; set; }

        [DisplayName("Color indicador convención")]
        public string Color { get; set; }

        [DisplayName("Opción visualización")]
        [Required(ErrorMessage = "Es necesario asignar una opción de visualización")]
        public int OpcionVisualizacionId { get; set; }


        //Llaves a
        public virtual OpcionesVisualizacion OpcionVisualizacion { get; set; }


    }
}