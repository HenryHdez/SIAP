using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class OpcionesVisualizacion
    {
        [Key]
        [DisplayName("Código")]
        public int OpcionVisualizacionId { get; set; }

        [DisplayName("Tipo opción - etiqueta")]
        public string NombreTipoOpcion { get; set; }

        [DisplayName("Nombre opción -botón")]
        public string NombreOpcion { get; set; }

        [DisplayName("Nombre corto opción")]
        public string NombreCortoOpcion { get; set; }

        [DisplayName("Nombre clase JScript que se llama")]
        public string NombreOpcionJScript { get; set; }

        [DisplayName("Capa")]
        [Required(ErrorMessage = "Es necesario asignar una capa")]
        public int CapaId{ get; set; }

        //Llaves a
        public virtual Capas Capa { get; set; }


    }
}