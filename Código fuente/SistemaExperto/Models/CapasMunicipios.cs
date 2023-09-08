using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class CapasMunicipios
    {
        [Key]
        [DisplayName("Código")]
        public int CapaMunicipioId{ get; set; }

        [DisplayName("Capa")]
        [Required(ErrorMessage = "Es necesario definir una capa")]
        public int CapaId { get; set; }

        [DisplayName("Municipio")]
        [Required(ErrorMessage = "Es necesario definir un municipio")]
        public int MunicipioId { get; set; }

        [DisplayName("Explicacion de  mapa")]
        public string ExplicacionMapa { get; set; }

        [DisplayName("Visible")]
        public bool Visible { get; set; }

        //Llaves a
        public virtual Capas Capa { get; set; }
        public virtual Municipio Municipio { get; set; }
    }
}