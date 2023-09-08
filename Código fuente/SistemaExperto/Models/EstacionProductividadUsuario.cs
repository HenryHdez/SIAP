using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace SistemaExperto.Models
{
    public class EstacionProductividadUsuario
    {
        //Código de la estacion de productividad
        [Key]
        [DisplayName("Código")]
        public int EstacionProductividadUsuarioId { get; set; }

        //identificador del usuario
        [DisplayName("Usuario")]
        [Required(ErrorMessage = "Es necesario definir un usuario")]
        public int UsuarioId { get; set; }

        //Fecha de registro de datos en formato (AAAA,MM,DD)
        [DisplayName("Fecha sistema")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        [Required(ErrorMessage = "Es necesario definir un día de sistema")]
        public DateTime FechaSistema { get; set; }

        //Fecha de productividad en formato (AAAA,MM,DD)
        [DisplayName("Fecha productividad")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        [Required(ErrorMessage = "Es necesario definir un día de registro")]
        public DateTime FechaProductividad { get; set; }

        [DisplayName("Precipitación")]
        [Required(ErrorMessage = "Es necesario definir el valor de la precipitación")]
        public double Precipitacion { get; set; }

        [DisplayName("Temp. mínima")]
        [Required(ErrorMessage = "Es necesario definir la temperatura mínima")]
        public double? Tmin { get; set; }

        [DisplayName("Temp. máxima")]
        [Required(ErrorMessage = "Es necesario definir la temperatura máxima")]
        public double? Tmax { get; set; }
    }
}