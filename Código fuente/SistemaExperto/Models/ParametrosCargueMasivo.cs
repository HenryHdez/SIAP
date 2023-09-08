using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaExperto.Models
{
    public class ParametrosCargueMasivo
    {
        [Key]
        [DisplayName("Consecutivo Parametro Cargue Excel")]
        [Required(ErrorMessage = "Es necesario definir un ID para Tabla de Parametros")]
        public int ParametrosCargueMasivoID { get; set; }

        [DisplayName("Identificador de parametro")]
        [Required(ErrorMessage = "Es necesario definir un identificador para el parametro")]
        public string Identificador { get; set; }

        [DisplayName("Nombre Tabla de BD Cargue")]
        [Required(ErrorMessage = "Es necesario definir la Tabla de Cargue BD")]
        public string NombreTablaBD { get; set; }

        [DisplayName("Nombre de la columna en Excel")]
        [Required(ErrorMessage = "Es necesario definir una columna Excel")]
        public string NombreColumnaExcel { get; set; }

        [DisplayName("Nombre de la columna en BD")]
        [Required(ErrorMessage = "Es necesario definir una columna equivalente en BD")]
        public string NombreColumnaBD { get; set; }

        [DisplayName("Descripcion del parametro")]
        public string Descripcion { get; set; }
     
    }
}