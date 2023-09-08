using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class InformacionAmpliaSec2Mcipio
    {
        [Key]
        [DisplayName("Código")]
        public int InformacionAmpliaSec2McipioId { get; set; }

        [DisplayName("Capa Municipio")]
        [Required(ErrorMessage = "Es necesario asignar una capa municipio")]
        public int CapaMunicipioId { get; set; }

        [DisplayName("Nombre corto item")]
        public string NombreCortoSeccion2 { get; set; }

        [DisplayName("Titulo de seccion 2")]
        public string TituloSeccion2Mcipio { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }


        //Llaves a
        public virtual CapasMunicipios CapasMunicipios { get; set; }

    }
}