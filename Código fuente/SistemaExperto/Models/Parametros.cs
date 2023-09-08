using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaExperto.Models
{
    public class Parametros
    {
        [Key]
        [DisplayName("Consecutivo parámetro ")]
        [Required(ErrorMessage = "Es necesario definir un ID para Tabla de Parametros")]
        public int ParametrosId{ get; set; }

        [DisplayName("Código de parámetro")]
        [Required(ErrorMessage = "Es necesario definir un codigo para el parametro")]
        public int Codigo { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Es necesario definir el nombre del parametro")]
        public string Nombre { get; set; }

        [DisplayName("Parámetro en base de datos")]
        public string NombreBD { get; set; }

        [DisplayName("Valor del parámetro")]
        [Required(ErrorMessage = "Es necesario definir el nombre del parametro")]
        public string Valor { get; set; }

        [DisplayName("Descripción del parámetro")]
        public string Descripcion { get; set; }
    }
}