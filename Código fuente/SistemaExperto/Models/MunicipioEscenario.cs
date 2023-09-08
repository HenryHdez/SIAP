using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class MunicipioEscenario
    {
        [Key]
        [DisplayName("Código")]
        public int MunicipioEscenarioId { get; set; }

        [DisplayName("Municipio")]
        [Required(ErrorMessage = "Es necesario definir una estación")]
        public int MunicipioId { get; set; }

        [DisplayName("Condición")]
        [Required(ErrorMessage = "Es necesario definir una condición")]
        public int CondicionId { get; set; }

        [DisplayName("Mes")]
        [Required(ErrorMessage = "Es necesario definir un mes")]
        public int Mes { get; set; }

        [DisplayName("Código")]
        [Required(ErrorMessage = "Es necesario definir un código")]
        public string Codigo { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        //Llave a la tabla de municipio
        public virtual Municipio Municipio { get; set; }

        //Llave a la tabla de condición
        public virtual Condicion Condicion { get; set; }

    }
}