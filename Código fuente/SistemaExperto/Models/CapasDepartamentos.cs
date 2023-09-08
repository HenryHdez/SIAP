using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class CapasDepartamentos
    {
        [Key]
        [DisplayName("Código")]
        public int CapaDepartamentoId { get; set; }

        [DisplayName("Capa")]
        [Required(ErrorMessage = "Es necesario definir una capa")]
        public int CapaId { get; set; }

        [DisplayName("Departamento")]
        [Required(ErrorMessage = "Es necesario definir un departamento")]
        public int DepartamentoId { get; set; }

        [DisplayName("Explicacion de mapa")]
        public string ExplicacionMapa { get; set; }

        [DisplayName("Visible")]
        public bool Visible { get; set; }

        //Llaves a
        public virtual Capas Capa { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}