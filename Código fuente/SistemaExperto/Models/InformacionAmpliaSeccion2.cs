using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class InformacionAmpliaSeccion2
    {
        [Key]
        [DisplayName("Código")]
        public int InformacionAmpliaSeccion2Id { get; set; }

        [DisplayName("Capa Departamento")]
        [Required(ErrorMessage = "Es necesario asignar una capa departamento")]
        public int CapaDepartamentoId { get; set; }

        [DisplayName("Nombre corto item")]
        public string NombreCortoSeccion2 { get; set; }

        [DisplayName("Titulo de seccion 2")]
        public string TituloSeccion2 { get; set; }

        [DisplayName("Icono")]
        public string Icono { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }


        //Llaves a
        public virtual CapasDepartamentos CapasDepartamentos { get; set; }

    }
}