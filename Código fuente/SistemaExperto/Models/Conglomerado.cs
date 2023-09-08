using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class Conglomerado
    {
        [Key]
        [DisplayName("Código")]
        public int ConglomeradoId { get; set; }

        [DisplayName("Departamento")]
        [Required(ErrorMessage = "Es necesario definir un municipio")]
        public int DepartamentoId { get; set; }

        [DisplayName("Código en el mapa")]
        public int CodigoMapa { get; set; }
        
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string Nombre { get; set; }

        //Llave a la tabla de departamentos
        public virtual Departamento Departamento { get; set; }
    }
}