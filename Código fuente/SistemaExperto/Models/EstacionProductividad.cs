using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class EstacionProductividad
    {
        //Código de la estacion de productividad
        [Key]
        [DisplayName("Código")]
        public int EstacionProductividadId { get; set; }

        //identificador de la estación
        [DisplayName("Estacion")]
        [Required(ErrorMessage = "Es necesario definir una estación")]
        public int EstacionId { get; set; }

        //Fecha de registro de datos en formato (AAAA,MM,DD)
        [DisplayName("Fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        [Required(ErrorMessage = "Es necesario definir un dia")]
        public DateTime Fecha { get; set; }

        [DisplayName("Precipitación")]
        [Required(ErrorMessage = "Es necesario definir el valor de la precipitación")]
        public double Precipitacion { get; set; }

        [DisplayName("Temp. mínima")]
        [Required(ErrorMessage = "Es necesario definir la temperatura mínima")]
        public double? Tmin { get; set; }

        [DisplayName("Temp. máxima")]
        [Required(ErrorMessage = "Es necesario definir la temperatura máxima")]
        public double? Tmax { get; set; }

        [DisplayName("Tipo año cultivo")]      
        public string AnioTipo { get; set; }

        //Llave a la tabla de estación
        public virtual Estacion Estacion { get; set; }
    }
}