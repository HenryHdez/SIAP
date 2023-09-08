using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class InformacionAmpliaSeccion1
    {
        [Key]
        [DisplayName("Código")]
        public int InformacionAmpliaSeccion1Id { get; set; }

        [DisplayName("Capa - Departamento")]
        [Required(ErrorMessage = "Es necesario asignar una capa departamento")]
        public int CapaDepartamentoId { get; set; }

        [DisplayName("Titulo de sección")]
        public string TituloSeccion1 { get; set; }

        [DisplayName("Información del mapa")]
        public string InformacionMapa { get; set; }

        [DisplayName("Nombre del mapa")]
        public string NombreMapa { get; set; }

        //Llaves a
        public virtual CapasDepartamentos CapasDepartamentos { get; set; }

    }
}