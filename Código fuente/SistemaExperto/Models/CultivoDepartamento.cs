using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class CultivoDepartamento
    {
        [Key]
        [DisplayName("Código")]
        public int CultivoDepartamentoId { get; set; }

        [DisplayName("Cultivo Productividad")]
        [Required(ErrorMessage = "Es necesario definir un cultivo")]
        public int CultivoProductividadId { get; set; }

        [DisplayName("Departamento")]
        [Required(ErrorMessage = "Es necesario definir un departamento")]
        public int DepartamentoId { get; set; }

        [DisplayName("Imagen")]
        //[Required(ErrorMessage = "Es necesario definir una imagen")]
        public string RutaMapa { get; set; }

        //Llave a la tabla de Departamento
        public virtual Departamento Departamento { get; set; }

        //Llave a la tabla de cultivoProductividad
        public virtual CultivoProductividad CultivoProductividad { get; set; }
    }
}