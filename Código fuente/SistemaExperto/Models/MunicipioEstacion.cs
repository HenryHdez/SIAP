using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class MunicipioEstacion
    {
        [Key]
        [DisplayName("Código")]
        public int MunicipioEstacionId { get; set; }

        [DisplayName("Estación")]
        [Required(ErrorMessage = "Es necesario definir una estación")]
        public int EstacionId { get; set; }

        [DisplayName("Municipio")]
        [Required(ErrorMessage = "Es necesario definir un municipio")]
        public int MunicipioId { get; set; }

        //Llave a la tabla de estación
        //public virtual ICollection<Estacion> Estacion { get; set; }
        public virtual Estacion Estacion { get; set; }

        //Llave a la tabla de municipio
        //public virtual ICollection<Municipio> Municipio { get; set; }
        public virtual Municipio Municipio { get; set; }

    }
}