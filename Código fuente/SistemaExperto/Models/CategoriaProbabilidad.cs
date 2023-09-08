using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace SistemaExperto.Models
{
    public class CategoriaProbabilidad
    {
        //Código para el registro de categoria
        [Key]
        [DisplayName("Código")]
        public int CategoriaProbabilidadId { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Es necesario definir una descripcion para la categoria")]
        public string Descripcion { get; set; }

        
    }
}