using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class InformacionAmpliaSec1Mcipio
    {
        [Key]
        [DisplayName("Código")]
        public int InformacionAmpliaSec1McipioId { get; set; }

        [DisplayName("Capa de municipio")]
        [Required(ErrorMessage = "Es necesario asignar una capa municipio")]
        public int CapaMunicipioId { get; set; }

        [DisplayName("Título de la sección")]
        public string TituloSeccion1Mcipio { get; set; }

        [DisplayName("Información de mapa")]
        public string InformacionMapa { get; set; }

        [DisplayName("Nombre del mapa")]
        public string NombreMapa { get; set; }

        //Llaves a
        public virtual CapasMunicipios CapasMunicipios { get; set; }
    }
}